using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj 
{
    public class RP_013 : BizObj.IGetData
    {
        PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;
        public RP_013()
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
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("rpt_attendance", Xml, 1, this._objDb), true);

                }
                else if (Mode == "L")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("tr_leave_dtls_sel", Xml, 3, this._objDb), true);
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
