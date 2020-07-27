using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
   public class SL_002 : BizObj.IGetData
    {
       PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

		public SL_002()
		{			
		}
		#region IGetData Members
        public string GetData(string Xml, string AddParams, string Mode)
        {
            String retXml = string.Empty;
            try
            {
                if (Mode == "S")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("alavance_sel", Xml, 1, this._objDb), true);
                }
                else if (Mode == "I")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("alavance_iu", Xml, this._objDb);
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
