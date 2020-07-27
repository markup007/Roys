using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
    public class TF_005 : BizObj.IGetData
    {
        PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

        public TF_005()
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
                    return PLABS .Utils .CnvDataSetToXml(objDbHelper.SelectSP("orderform_sel", Xml, 1, this._objDb),true);

                }
                else if (Mode == "I" || Mode == "U")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("orderform_iu", Xml, this._objDb);
                }
                else if (Mode == "D")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("orderform_del", Xml, this._objDb);
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
