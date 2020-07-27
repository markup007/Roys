using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace BizObj
{
    public class DB_001 : BizObj.IGetData
	{
		PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

		public DB_001()
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
                    return PLABS.Utils .CnvDataSetToXml( objDbHelper.SelectSP("dbgldregister_sel", Xml, 1, this._objDb),true);

				}
				else if (Mode == "I" || Mode == "U"  )
				{
					PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("dbgldregister_iu", Xml, this._objDb);
				}
				else if (Mode == "D")
				{
					PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("dbgldregister_del", Xml, this._objDb);
				}
                else if (Mode == "F")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("pr_opnfrwd", Xml, this._objDb);
                }
                else if (Mode == "LA")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("tr_slrypstng_sel", Xml, 1, this._objDb), true);

                }
                else if (Mode == "LU")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("tr_slrypstng_iu", Xml, this._objDb);
                }
                else if (Mode== "PI")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("ma_macaprvl_iu", Xml, this._objDb);
                }
                else if(Mode== "PS")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("ma_macaprvl_sel", Xml, 1, this._objDb), true);
                }
                else if (Mode == "PD")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("gemnumast_DEL", Xml, this._objDb);
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

