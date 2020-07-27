using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.IO;
 
namespace BizObj
{
    public class BKP_001 : BizObj.IGetData
	{
		PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;
        #region Variable

        StringBuilder BACKUPSTRING = new StringBuilder();
        public Dictionary<string, string> dicTableCustomSql;
        public bool BackupTableStructure = true;
        public bool BackupRows = true;
        long max_allowed_packet = 1 * 1024 * 1024 * 1024;
        #endregion

		public BKP_001()
		{
			// this._objDb = ConfigurationManager.AppSettings[""].ToString();
		}


		#region IGetData Members
		public string GetData(string BackupName,  string AddParams,string DataBaseName)
		{
			String retXml = string.Empty;
			try
			{
				 
                  
                    //PLABS.DAL objDbHelper = new PLABS.DAL();
                    //return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("BKP_PRO", Xml, 1, this._objDb), true);
                if (DataBaseName == "RD")
                {
                  return  this.Restore(BackupName);
                }
                else
                {
                    return this.GetTables(DataBaseName, BackupName);
                  
                }

			 
              


               
			}
			catch (Exception ex)
			{
				return ex.Message;
			} 
			return "";
		}

      

		#endregion

        #region BACKUP

        private String GetTables(String DatabaseName,String BackupName)
        {
            try
            {



                String xmlData = this.CreateXml("S", "", "", "", "", "");
                String Data = string.Empty;
                PLABS.DAL objDbHelper = new PLABS.DAL();

                Data = PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("BKP_PRO", xmlData, 1, _objDb), true);

                DataSet ds = PLABS.Utils.CnvXMLToDataSet(Data);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);

                return this.Backup(dt, DatabaseName, BackupName);

               
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }

        Dictionary<string, string> GetTablesAndSQL(DataTable dt)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow dgvr in dt.Rows)
            {


                string table = dgvr[0].ToString();
                string sql = "";

                sql = "SELECT * FROM `" + table + "`;";


                dic.Add(table, sql);
            }
            return dic;
        }


        public String Backup(DataTable dt, String DatabaseName,String BackupName)
        {
            try
            {

                dicTableCustomSql = GetTablesAndSQL(dt);
                //   saltSize = methods.GetSaltSize(EncryptKey);



                #region Document Header



                //BACKUPSTRING.Append("-- MySQL Administrator dump 1.4");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("-- Dump time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("-- ------------------------------------------------------");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("-- Server version	5.1.63-community");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET NAMES utf8 */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("--");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("-- Create schema " + DatabaseName);
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("--");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("");
                BACKUPSTRING.Append("\n");

                BACKUPSTRING.Append("CREATE DATABASE IF NOT EXISTS " + DatabaseName + ";");
                BACKUPSTRING.Append("\n");
                BACKUPSTRING.Append("USE " + DatabaseName + ";");
                BACKUPSTRING.Append("\n");
                BACKUPSTRING.Append("SET FOREIGN_KEY_CHECKS=0;");

                #endregion

                foreach (KeyValuePair<string, string> kv in dicTableCustomSql)
                {
                    string table = kv.Key;

                    #region Table Header



                    if (BackupTableStructure)
                    {
                        BACKUPSTRING.Append("");
                        BACKUPSTRING.Append("");
                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append("-- ");
                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append("-- Definition of table `" + table + "` -- ;");
                        BACKUPSTRING.Append("\n");

                        BACKUPSTRING.Append("\n");

                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append("");
                        BACKUPSTRING.Append(" DROP TABLE IF EXISTS `" + table + "`;");
                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append(GetCreateTableSql(table));
                    }

                    if (BackupRows)
                    {
                        BACKUPSTRING.Append("");
                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append("-- ");
                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append("-- Dumping data for table `" + table + "`");
                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append("--");
                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append("");
                        BACKUPSTRING.Append("\n");
                        BACKUPSTRING.Append("/*!40000 ALTER TABLE `" + table + "` DISABLE KEYS */;");
                        BACKUPSTRING.Append("\n");
                    }


                    #endregion

                    if (BackupRows)
                        BackupTable(table);

                    #region Table Footer

                    if (BackupRows)
                    {
                        BACKUPSTRING.Append("/*!40000 ALTER TABLE `" + table + "` ENABLE KEYS */;");
                        BACKUPSTRING.Append("\n");

                    }
                    #endregion



                }

                #region Document Footer

                BACKUPSTRING.Append("SET FOREIGN_KEY_CHECKS=1;");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;");
                //BACKUPSTRING.Append("\n");
                //BACKUPSTRING.Append("/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;");


                #endregion

                #region Triggers
                String xml = this.CreateXml("T", "", "", "", "", "");
                String Data = string.Empty;
                PLABS.DAL objDbHelper = new PLABS.DAL();
                Data = PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("BKP_PRO", xml, 1, _objDb), true);
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(Data);
                DataTable triggers = PLABS.Utils.GetDataTable(ds, 0);

               

                for (int i = 0; i < triggers.Rows.Count; i++)
                {
                    BACKUPSTRING.Append("\n");
                    BACKUPSTRING.AppendLine(" DROP TRIGGER /*!50032 IF EXISTS */ " + "`" + triggers.Rows[i]["db"] + "`" + "." + "`" + triggers.Rows[i]["nam"] + "`" + ";");
                    BACKUPSTRING.AppendLine("");
                    BACKUPSTRING.AppendLine("DELIMITER $$");
                    BACKUPSTRING.AppendLine("");

                    BACKUPSTRING.AppendLine(" CREATE ");
                    BACKUPSTRING.AppendLine(" TRIGGER " + " `" + triggers.Rows[i]["nam"] + "` " + triggers.Rows[i]["evnt"] + " " + triggers.Rows[i]["event_action"] + " ON " + " " + "`" + triggers.Rows[i]["tble"] + "`");
                    BACKUPSTRING.AppendLine(" FOR EACH " + triggers.Rows[i]["orint"]);

                    BACKUPSTRING.AppendLine(triggers.Rows[i]["statmnt"] + ";");

                    BACKUPSTRING.AppendLine(" $$ ");
                   
                    BACKUPSTRING.AppendLine("DELIMITER ; ");

                }



                #endregion

              

                String xmlData = this.CreateXml("I", "", BackupName, PLABS.Utils.Compress(BACKUPSTRING.ToString()), "", "");
              
                string status = objDbHelper.insertSP("BKP_PRO", xmlData, this._objDb);

                return status;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }


        public string GetCreateTableSql(string table)
        {

           
          


            String xmlData = this.CreateXml("A", table,"","","","");
            String Data=string.Empty;
            PLABS.DAL objDbHelper = new PLABS.DAL();
            Data = PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("BKP_PRO", xmlData, 1, this._objDb), true);


            DataSet ds = PLABS.Utils.CnvXMLToDataSet(Data);
            DataTable dt = PLABS.Utils.GetDataTable(ds, 0);

            return dt.Rows[0][1].ToString().Replace("CREATE TABLE", "CREATE TABLE") + ";";
        }

        private void BackupTable(string table)
        {
         

            string InsertStatementHeader = null;
            int W = 0;

            

            String xmlData = this.CreateXml("B",table,"","","","");
            String Data = string.Empty;

            PLABS.DAL objDbHelper = new PLABS.DAL();
            DataSet ds=  objDbHelper.SelectSP("BKP_PRO", xmlData, 1, this._objDb);
           
            
            DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
           
        
            StringBuilder sb = new StringBuilder();
            long rowchek = 0;
            while (W < dt.Rows.Count)
            {
               
                if (InsertStatementHeader==null)
                {
                     
                    int fc = dt.Columns.Count;
                    string[] ColumnNames = new string[fc];
                    for (int ci = 0; ci < dt.Columns.Count; ci++)
                    {
                        ColumnNames[ci] = dt.Columns[ci].ToString();
                    }
                    InsertStatementHeader = GetInsertStatementHeader(table, ColumnNames);
                }
                

                object[] objectArray = new object[dt.Columns.Count];

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Rows[W][i] == System.DBNull.Value)
                    {
                        objectArray[i] = System.DBNull.Value;
                    }
                    else
                    {

                        Type tp= dt.Rows[W][i].GetType();

                        if (tp == typeof(DateTime))
                        {
                            objectArray[i] = PLABS.Utils.CnvToDate(dt.Rows[W][i]).ToString("yyyy-MM-dd hh:mm:ss");
                        }
                        else
                        {

                            objectArray[i] = dt.Rows[W][i].ToString();
                        }
                    }

                }

                
                string ValueString = GetSqlValueString(objectArray);

                if (sb.Length == 0 || rowchek==950)
                {
                    if (rowchek == 950)
                    {
                        sb.Append( "\n"+InsertStatementHeader + "\r\n" + ValueString );
                        rowchek = 0;
                    }
                    else
                    {
                        sb.Append(InsertStatementHeader + "\r\n" + ValueString);
                    }
                }             
                else
                {
                    if (rowchek == 949)
                    {
                        sb.Append(",\r\n" + ValueString + ";");
                    }
                    else
                    {
                        sb.Append(",\r\n" + ValueString );
                    }
                }
                //else if (((long)sb.Length + ValueString.Length + 10) < max_allowed_packet)
                //{
                    
                //}
                rowchek = rowchek + 1;

                W++;
            }


            if (sb.Length > 0 || rowchek != 1)
                sb.Append(";");

            BACKUPSTRING.Append(sb.ToString());
        }

        private string GetSqlValueString(object[] obs)
        {
            StringBuilder sbData = new StringBuilder();

            sbData.Append("(");

            foreach (object ob in obs)
            {
                sbData.Append(GetDataString(ob) + ",");
            }
            sbData.Remove(sbData.Length - 1, 1);
            sbData.Append(")");
            return sbData.ToString();
        }

        private string GetDataString(object ob)
        {
            if (ob is System.DBNull)
            {
                return "NULL";
            }
            else if (ob is System.DateTime)
            {
                return "'" + ((DateTime)ob).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (ob is System.Boolean)
            {
                return Convert.ToInt32(ob) + "";
            }
            else if (ob is System.Byte[])
            {
                return GetBLOBSqlDataStringFromBytes(((byte[])ob));
            }
            else if (ob is System.String)
            {
                string data = ob.ToString();

                EscapeStringSequence(ref data);

                return ("'" + data + "'");
            }
            else
            {
                string a = ob.ToString();
                double d = 0;
                if (double.TryParse(a, out d))
                {
                    return a;
                }
                else
                {
                    EscapeStringSequence(ref a);
                    return "'" + a + "'";
                }
            }
        }

        public string GetBLOBSqlDataStringFromBytes(byte[] ba)
        {
            // Method 1 (slower)
            //return "0x"+ BitConverter.ToString(bytes).Replace("-", string.Empty);

            // Method 2 (faster)
            char[] c = new char[ba.Length * 2 + 2];
            byte b;
            c[0] = '0'; c[1] = 'x';
            for (int y = 0, x = 2; y < ba.Length; ++y, ++x)
            {
                b = ((byte)(ba[y] >> 4));
                c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(ba[y] & 0xF));
                c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }
            return new string(c);
        }
        private void EscapeStringSequence(ref string data)
        {
            data = data.Replace("\\", "\\\\"); // Backslash
            data = data.Replace("\r", "\\r");  // Carriage return
            data = data.Replace("\n", "\\n");  // New Line
            data = data.Replace("\a", "\\a");  // Vertical tab
            data = data.Replace("\b", "\\b");  // Backspace
            data = data.Replace("\f", "\\f");  // Formfeed
            data = data.Replace("\t", "\\t");  // Horizontal tab
            data = data.Replace("\v", "\\v");  // Vertical tab
            data = data.Replace("\"", "\\\""); // Double quotation mark
            data = data.Replace("'", "\\'");   // Single quotation mark
        }
        private string GetInsertStatementHeader(string table, string[] columnNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO `" + table + "` (");
            foreach (string s in columnNames)
            {
                sb.Append("`" + s + "`,");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(") VALUES");
            return sb.ToString();
        }
        private String CreateXml(String as_mode, String as_TblNam, String as_file, String as_dump, String ai_bckup_id, String as_Restore_data)
        {
            StringBuilder xmlData = new StringBuilder();

            
            xmlData.Append("<root>");
            xmlData.Append("<dtls>");
            xmlData.Append("<arg>as_mode</arg><val>"+as_mode+"</val></dtls>");
            xmlData.Append("<dtls>");
            xmlData.Append("<arg>as_TblNam</arg><val>"+as_TblNam+"</val></dtls>");
            xmlData.Append("<dtls>");
            xmlData.Append("<arg>as_file</arg><val>"+as_file+"</val></dtls>");
            xmlData.Append("<dtls>");
            xmlData.Append("<arg>as_dump</arg><val>"+as_dump+"</val></dtls>");
            xmlData.Append("<dtls>");
            xmlData.Append("<arg>ai_bckup_id</arg><val>"+ai_bckup_id+"</val></dtls>");
            xmlData.Append("<dtls>");
            xmlData.Append("<arg>as_Restore_data</arg><val>"+as_Restore_data+"</val></dtls>");
            xmlData.Append("</root>");
            return xmlData.ToString();
        }
        private string Restore(string rstrId)
        {
            string restoreFile = string.Empty;
            int status=0;
            PLABS.DAL objDbHelper = new PLABS.DAL();
            String xmlData = this.CreateXml("RD", "", "", "", rstrId, "");
            System.Data.DataSet ds = objDbHelper.SelectSP("BKP_PRO", xmlData, 1, this._objDb);

            if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count > 0)
            {
              restoreFile = PLABS.Utils.Decompress(PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["dump"]));
             // restoreFile = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["dump"]);
            }

          
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = "server=173.248.142.18; User Id=baburajps;password=babups@501;Persist Security Info=True;database = baburaj";  
            connection.Open();
            MySqlScript script = new MySqlScript(connection, restoreFile);
            try
            {
              
                status= script.Execute();

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                connection.Close();
                 
                connection.Dispose();
            }

            

            return "1";
        }
       

       


        #endregion
	}
  
}
