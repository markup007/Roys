using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
  public   class GA_007 : BizObj.IGetData
    {
      PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

        public GA_007()
		{
			// this._objDb = ConfigurationManager.AppSettings[""].ToString();
		}
		#region IGetData Members
		public string GetData(string Xml,  string AddParams,string mode)
		{
			String retXml = string.Empty;
			try
			{
                if (mode == "S")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("ge_addselect_sel", Xml, 1, this._objDb), true);
                }
                else if (mode == "I" || mode == "U")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("ge_addselect_iu", Xml, this._objDb);
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
