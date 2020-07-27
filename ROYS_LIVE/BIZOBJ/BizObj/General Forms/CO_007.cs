using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
    public class CO_007 : BizObj.IGetData
    {
        PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

        public CO_007()
        {
            // this._objDb = ConfigurationManager.AppSettings[""].ToString();
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
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("dbcshbkpndng_sel", Xml, 1, this._objDb), true);
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
