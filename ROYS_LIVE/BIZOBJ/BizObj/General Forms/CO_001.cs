﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
    public class CO_001 : BizObj.IGetData
    {
        PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

        public CO_001()
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
                    return PLABS .Utils .CnvDataSetToXml(objDbHelper.SelectSP("ordrfrmpopup_SEL", Xml, 1, this._objDb),true);

                }
                else if (Mode == "I" || Mode == "U")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("gefrmmast_IU", Xml, this._objDb);
                }
                else if (Mode == "D")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("gefrmmast_DEL", Xml, this._objDb);
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
