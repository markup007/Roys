using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace BizObj
{
    public class GB_009 : BizObj.IGetData
	{
		PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

		public GB_009()
		{
			// this._objDb = ConfigurationManager.AppSettings[""].ToString();
		}
		#region IGetData Members
		public string GetData(string Xml,  string AddParams,string Mode)
		{
			String retXml = string.Empty;
			try
			{
				if (Mode == "S")
				{
					PLABS.DAL objDbHelper = new PLABS.DAL();
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("ge_bckups_sel", Xml, 1, this._objDb), true);

				}
				else if (Mode == "I" || Mode == "U"  )
				{
                   
                    
				}
				else if (Mode == "R")
				{
                    return this.Restore(Xml);
				}
                else if (Mode == "D")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("ge_bckups_del", Xml, this._objDb);
                }
			}
			catch (Exception ex)
			{
				return ex.Message;
			} 
			return "";
		}
  
        private string Restore(string rstrId)
        {
            try
            {
                StringBuilder Xml = new StringBuilder();
                Xml.Append("<root>");
                Xml.Append("<dtls><arg>as_mode</arg><val>RD</val></dtls>");
                Xml.Append("<dtls><arg>ai_bckup_id</arg><val>" + rstrId + "</val></dtls>");
                Xml.Append("</root>");
                PLABS.DAL objDbHelper = new PLABS.DAL();
                System.Data.DataSet ds = objDbHelper.SelectSP("ge_bckups_sel", Xml.ToString(), 1, this._objDb);
                if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string restoreFile = PLABS.Utils.Decompress(PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["dump"]));
                    string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    using (StreamWriter outfile = new StreamWriter(mydocpath + @"\AllTxtFiles.txt"))
                    {
                        outfile.Write(restoreFile);
                    }
                    string temp =PLABS.CreateProcessXml.FormatString(restoreFile);

                    Xml = new StringBuilder();
                    Xml.Append("<root>");
                    Xml.Append("<dtls><arg>as_mode</arg><val>R</val></dtls>");
                    Xml.Append("<dtls><arg>as_TblNam</arg><val></val></dtls>");
                    Xml.Append("<dtls><arg>as_Restore_data</arg><val>" + temp + "</val></dtls>");
                    Xml.Append("</root>");
                     String status = objDbHelper.insertSP("BKP_PRO", Xml.ToString(), this._objDb);
                     return status;
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }
        private string GetTableNames()
        {
            try
            {
                
                StringBuilder Xml = new StringBuilder();
                Xml.Append("<root>");
                Xml.Append("<dtls><arg>as_mode</arg><val>T</val></dtls>");
                Xml.Append("<dtls><arg>ai_bckup_id</arg><val>1</val></dtls>");
                Xml.Append("</root>");
                PLABS.DAL objDbHelper = new PLABS.DAL();
                System .Data.DataSet ds = objDbHelper.SelectSP("ge_bckups_sel", Xml.ToString(), 1, this._objDb);
                if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["nam"]);
                   
                }
                return "";
            }
            catch (Exception ex)
            {
 
            }
            return "";
        }
		#endregion
	}
}

