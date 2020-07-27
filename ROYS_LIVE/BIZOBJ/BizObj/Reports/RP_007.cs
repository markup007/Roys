using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
    public class RP_007:IGetData
    {
        PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

        public RP_007()
		{
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
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("rpt_sales", Xml, 1, this._objDb), true);
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
