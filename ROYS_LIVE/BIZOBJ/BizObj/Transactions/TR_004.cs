﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
    public class TR_004 : BizObj.IGetData
    {
        PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

        public TR_004()
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
                    return PLABS.Utils.CnvDataSetToXml( objDbHelper.SelectSP("trsmthreceipt_sel", Xml, 1, this._objDb),true);
                  //  return objDbHelper.SelectSP("trsmthreceipt_sel", Xml, 1, this._objDb).GetXml();

                }
                else if (Mode == "I" || Mode == "U")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("trsmthreceipt_iu", Xml, this._objDb);
                }
                else if (Mode == "D")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return objDbHelper.insertSP("trsmthreceipt_del", Xml, this._objDb);
                }
                else if (Mode == "P")
                {
                    PLABS.DAL objDbHelper = new PLABS.DAL();
                    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("rptsmithreceipt_sel", Xml, 1, this._objDb), true);
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
