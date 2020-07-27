using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace BizObj
{
    public class Utils : BizObj.IGetData
	{
		PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

		public Utils()
		{
			// this._objDb = ConfigurationManager.AppSettings[""].ToString();
		}
		#region IGetData Members
		public string GetData(string Xml,  string AddParams,string Mode)
		{
			String retXml = string.Empty;
			try
			{
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return PLABS .Utils.CnvDataSetToXml(objDbHelper.SelectSP("pr_refresh_load", Xml,0,this._objDb),true);
                
			}
			catch (Exception ex)
			{
				return ex.Message;
			} 
			return "";
		}
		#endregion
	}
}

