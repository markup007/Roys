using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace BizObj
{
    public class TS_003 : BizObj.IGetData
	{
		PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

		public TS_003()
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
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("tr_settlement_sel", Xml, 1, this._objDb), true);

				}
				else if (Mode == "I" || Mode == "U"  )
				{
					PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("tr_settlement_iu", Xml, this._objDb);
				}
				else if (Mode == "D")
				{
					PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("tr_settlement_del", Xml, this._objDb);
				}
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

