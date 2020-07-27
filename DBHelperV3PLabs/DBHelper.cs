using System;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web;

namespace PLABS
{
    public enum DbProvider
    {
        Oracle,
        MSSql,
        MySql
    }

    public enum ConnectionModes
    {
        WebDB,
        LocalDB
    }

    public class DAL
    {
        String _localPath = "bin";
        String _settingsFileName = "DBSettings.xml";
        ConnectionModes _ConnectionMode = ConnectionModes.WebDB;

        public ConnectionModes ConnectionMode
        {
            get { return _ConnectionMode; }
            set { _ConnectionMode = value; }
        }


        public String SettingsFileName
        {
            get { return _settingsFileName; }
            set { _settingsFileName = value; }
        }

        public String LocalPath
        {
            get { return _localPath; }
            set { _localPath = value; }
        }

        public DAL()
        {

        }

        #region Common Methods
        public DataSet SelectSP(String SpName, String XmlParams, int ReturnTableCount, DbProvider SelectedDataBase)
        {
            if (SelectedDataBase == DbProvider.MSSql)
                return MSSelectSP(SpName, XmlParams);
           
            else if (SelectedDataBase == DbProvider.MySql)
                return MySelectSP(SpName, XmlParams, ReturnTableCount);

            return new DataSet();
        }
        public String insertSP(String SpName, String XmlParams, DbProvider SelectedDataBase)
        {
            if (SelectedDataBase == DbProvider.MSSql)
                return MSinsertSP(SpName, XmlParams);
        
            else if (SelectedDataBase == DbProvider.MySql)
                return MyInsertSP(SpName, XmlParams);

            return string.Empty;
        }
        #endregion

        #region MSSql Region
        private DataSet MSSelectSP(String SpName, String XmlParams)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                con = MSCreateConnection(false);
                cmd = con.CreateCommand();
                cmd.CommandText = SpName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (XmlParams.Trim() != String.Empty)
                    this.GetSqlParams(XmlParams, cmd);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("RslDS");
                da.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception("PLError " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("PLError " + ex.Message + " PLError:- 002");
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
        }
        private String MSinsertSP(String SpName, String XmlParams)
        {
            String status = "0";
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                con = MSCreateConnection(false);
                cmd = new SqlCommand(SpName, con);

                if (XmlParams.Trim() != String.Empty)
                    this.GetSqlParams(XmlParams, cmd);

                cmd.CommandType = CommandType.StoredProcedure;
                status = cmd.ExecuteNonQuery().ToString();
            }
            catch (SqlException ex)
            {
                status = "PLError " + ex.Message;
            }
            catch (Exception ex)
            {
                status = "PLError " + ex.Message;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
            return status;
        }

        private void GetSqlParams(String XmlParams, SqlCommand cmd)
        {

            try
            {
                XmlDocument xmlDom = new XmlDocument();
                xmlDom.LoadXml(XmlParams);
                foreach (XmlElement parEle in xmlDom)
                {
                    String Paramater = string.Empty;
                    object value = DBNull.Value;
                    String dataType = string.Empty;
                    foreach (XmlElement ele in parEle)
                    {
                        try
                        {
                            Paramater = "@" + ele["arg"].InnerText.Trim().Replace("@", "");
                            value = ele["val"].InnerText;
                            //      dataType = ele["DataType"].InnerText.Trim();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + "Paramater name Not Correct PLError:- 003");
                        }

                        if (value != null && value.ToString().Trim() != string.Empty)
                            value = value.ToString().Replace("'", "''");
                        else if (value.ToString().Trim() == string.Empty)
                            value = DBNull.Value;


                        cmd.Parameters.Add(new SqlParameter(Paramater, value));
                    }
                    break;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message + "Level :- 004");
            }
        }

        private SqlConnection MSCreateConnection(bool Transaction)
        {
            // int checkPoint  = 0 ;
            String ConnectionString = String.Empty;
            try
            {
                ConnectionString = getConnectionStr(DbProvider.MSSql);
                SqlConnection connection = new SqlConnection();
                try
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("PLError" + ex.Message + "Could not Open MS Sql Connection PLError:- 004");
                }
                //finally
                //{
                //    connection.Close();
                //}
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("PLError" + ex.Message + "Connection String Not Found 005 :---> [ " + ConnectionString + "]");
            }
        }
        #endregion

        

        #region MySql Region
        private DataSet MySelectSP(String SpName, String XmlParams, int v_recordsetCount)
        {
            MySqlConnection con = MyCreateConnection(false);
            MySqlCommand cmd = con.CreateCommand();

            try
            {

                cmd.CommandText = SpName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (XmlParams.Trim() != String.Empty)
                    this.GetMySqlParams(XmlParams, cmd);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet("ResultDS");
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                String Status = "Closed";

                if (con.State == ConnectionState.Open)
                    Status = "Open";

                throw new Exception(ex.Message);
            }
        }
        private String MyInsertSP(String SpName, String XmlParams)
        {
            MySqlConnection con = MyCreateConnection(false);
            MySqlCommand cmd = new MySqlCommand(SpName, con);
            String status = "0";

            try
            {
                if (XmlParams.Trim() != String.Empty)
                    this.GetMySqlParams(XmlParams, cmd);

                cmd.CommandType = CommandType.StoredProcedure;
                status = cmd.ExecuteNonQuery().ToString();

            }
            catch (MySqlException ex)
            {

                status = "PLError 02 MyInsertSP MySqlException :- " + ex.Message;
            }
            catch (Exception ex)
            {
                status = "PLError 03 MyInsertSP Exception :- " + ex.Message;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
            return status;
        }
        private void GetMySqlParams(String XmlParams, MySqlCommand cmd)
        {
            try
            {
                String Paramater = string.Empty;
                object value = DBNull.Value;
                String dataType = string.Empty;


                XmlDocument xmlDom = new XmlDocument();
                xmlDom.LoadXml(XmlParams);
                foreach (XmlElement parEle in xmlDom)
                {
                    foreach (XmlElement ele in parEle)
                    {
                        try
                        {
                            Paramater = ele["arg"].InnerText.Trim().Replace("@", "");
                            value = ele["val"].InnerText;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + "\nParamater name Not Correct");
                        }

                        if (value != null && value.ToString() != String.Empty)
                            value = value.ToString().Replace("'", "''");
                        else if (value != null && value.ToString().Trim() == string.Empty)
                            value = DBNull.Value;

                        cmd.Parameters.Add(new MySqlParameter(Paramater, value));
                    }
                    break;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PLError 04 GetMySqlParams Exception :- " + ex.Message);
            }
        }

        private MySqlConnection MyCreateConnection(bool Transaction)
        {
            String ConnectionString = getConnectionStr(DbProvider.MySql);
            MySqlConnection connection = new MySqlConnection(ConnectionString);

            try
            {
                //   ConnectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString.ToString();
                // connection.ConnectionString = ;
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("PLError 05 MyCreateConnection Exception :- " + ex.Message);
            }
            return connection;

        }

        private String getConnectionStr(DbProvider DbProvider)
        {
            String ConProv = "MsSqlCon";

            switch (DbProvider)
            {
                case DbProvider.MySql:
                    ConProv = "MySqlCon";
                    break;
                case DbProvider.Oracle:
                    ConProv = "OracleCon";
                    break;
            }


            System.Xml.XmlDocument obj = new XmlDocument();
            string appPath = string.Empty;

         /*   if (this._ConnectionMode == ConnectionModes.LocalDB)
                appPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\" + this._settingsFileName;
            else
                appPath = HttpContext.Current.Server.MapPath("~") +"\\"+ this._localPath + "\\" + this._settingsFileName;
            */
            try
            {
                // return "server=216.244.85.226;User ID=UD041804;Password=)@a#!&@2017;Persist Security Info=True;database=abcd;";
                //return "server=216.244.85.226;User ID=root;Password=)@a#!&@2017;Persist Security Info=True;database=ekmadm_dev;";
                return "server=localhost;User ID=root;Password=admin5555;Persist Security Info=True;database=ekmadm;";
                //return "server=216.244.85.226;User ID=root;Password=)@a#!&@2017;Persist Security Info=True;database=dtdekm;";
                //return "server=216.244.85.226;User ID=root;Password=)@a#!&@2017;Persist Security Info=True;database=caloram;";
                //return "server=216.244.85.226;User ID=UGOG;Password=&e0G0705;Persist Security Info=True;database=gog0705;";
                //return "server=216.244.85.226;User ID=root;Password=)@a#!&@2017;Persist Security Info=True;database=test_raa;";
                //return "server=localhost;User ID=root;Password=admin5555;Persist Security Info=True;database=dtdekm;";
                //return "server=216.244.85.226;User ID=root;Password=)@a#!&@2017;Persist Security Info=True;database=gog0705";
                //return "server=216.244.85.226;User ID=root;Password=)@a#!&@2017;Persist Security Info=True;database=ekmadm;";
            }
            catch (Exception ex)
            {
                return "PLError" + appPath;//ex.Message + " Connection String Reading Error [" + obj.InnerXml + "]";
            }
        }
        #endregion

    }
}