﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
    public class RP_011 : BizObj.IGetData
    {
        PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

        public RP_011()
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
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("rpt_mnthcptl", Xml, 1, this._objDb), true);
                }
                else if (Mode == "I" || Mode == "U")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("direct_sel_pur_iu", Xml, this._objDb);
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
