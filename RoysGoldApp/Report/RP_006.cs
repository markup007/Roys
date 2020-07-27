using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoysGold
{
    public partial class RP_006 : PLABS.MasterForm
    {
        #region Global variables
        bool _Purewt = false;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public RP_006()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.rtxt_stock.Focus();
            this.LoadReport();
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.btn_purwt.Click += new EventHandler(btn_purwt_Click);
            //this.rad_expnd.CheckedChanged += new EventHandler(rad_expnd_CheckedChanged);
           
            base.OnLoad(e);
        }

       
        #endregion
        #region Events
        void btn_purwt_Click(object sender, EventArgs e)
        {
            try
            {
                _Purewt =!_Purewt;
                if (_Purewt)
                {
                    this.LoadReport();
                    //_Purewt = false;
                }
                else
                {
                    this.LoadReport();
                   // _Purewt = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        void btn_print_Click(object sender, EventArgs e)
        {
            PLABS.MessageBoxPL.Show("Print Code Will be Here");
        }

        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //void rad_expnd_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.LoadReport();
        //    }
        //    catch
        //    {
        //    }
        //}

        #endregion
        #region Methods
        private void LoadControls()
        {
            this.LoadReport();
        }
        public string header(DataSet ds)
        {

            int len = 61;


            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();

            objRptTextCntr.Gf_DrawText("STOCK REGISTER", RptControl.TextAlign.Center, len, false);
            objRptTextCntr.GF_AddNewLine(0);

            return objRptTextCntr.GF_GetPrintString();


        }

        public void print(DataSet ds)
        {
            int len;
            if (_Purewt)
            {
               len = 75;
            }
            else
            {
               len = 60;
            }
           
            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();
            //string header = this.header(ds);
            double PurTot = 0;   
          for(int j=0;j<ds.Tables [1].Rows.Count;j++)
          {
              double ttl_prty_wt = 0;
              double ttlwt = 0;
              
              string head=string .Empty ;
              objRptTextCntr.GF_AddNewLine(2);
              string vtypmast = ds.Tables[1].Rows[j][0].ToString ();
              int headId = Convert.ToInt32(vtypmast);
              if (_Purewt)
              {
                 
                  switch (headId)
                  {
                      case 1:
                          head = "SMITH REPORT";//Smith Issue
                          len = 75;
                          break;
                      case 2:
                          head = "ITEM REPORT";//Smith Reciept
                          len = 60;
                          break;
                      case 3:
                          head = "RAW REPORT";//Raw Purchase
                          len = 60;
                          break;
                  }
              }
              else
              {
                   headId = Convert.ToInt32(vtypmast);
                  switch (headId)
                  {
                      case 1:
                          head = "SMITH REPORT";//Smith Issue
                          len = 60;
                          break;
                      case 2:
                          head = "ITEM REPORT";//Smith Reciept
                          len = 45;
                          break;
                      case 3:
                          head = "RAW REPORT";//Raw Purchase
                          len = 45;
                          break;
                  }
              }
              objRptTextCntr.Gf_DrawText(head, RptControl.TextAlign.Center, len, false);
           
            objRptTextCntr.GF_DrawLine(len);
            objRptTextCntr.Gf_AddSeperator();
            if (headId == 1)
            {
                objRptTextCntr.Gf_DrawText("SMITH NAME", RptControl.TextAlign.Center, 14, true);
            }
            else
            {
                objRptTextCntr.Gf_DrawText("ITEM", RptControl.TextAlign.Center, 14, true);
            }
            objRptTextCntr.Gf_DrawText("PURITY", RptControl.TextAlign.Center, 14, true);
            objRptTextCntr.Gf_DrawText("ITEM WT", RptControl.TextAlign.Center, 15, true);
            if (_Purewt)
            {
                objRptTextCntr.Gf_DrawText("PURE WT", RptControl.TextAlign.Center, 14, true);
            }
            objRptTextCntr.GF_AddNewLine(0);
            objRptTextCntr.GF_DrawLine(len);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string vtypdet=ds.Tables[0].Rows [i]["vtyp"].ToString ();
                if (vtypmast == vtypdet)
                {     //coding for getting values horizontally
                    objRptTextCntr.Gf_AddSeperator();
                    objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["item"], RptControl.TextAlign.Left, 14, true);
                    objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["purty"], RptControl.TextAlign.Right, 14, true,"F2");
                    if (headId == 1)
                    {

                        objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 15, true);//item wt
                        objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["wt"], RptControl.TextAlign.Right, 14, true, "F3");//pure wt
                        ttl_prty_wt += Convert.ToDouble(ds.Tables[0].Rows[i]["wt"]);//code for pure wt total
                    }
                    else 
                    {
                       objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["wt"], RptControl.TextAlign.Right, 15, true, "F3");//item wt
                       if (_Purewt)
                       {                        
                           objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["purewt"], RptControl.TextAlign.Right, 14, true, "F3");//pure wt
                           headId = Convert.ToInt32(vtypmast);

                           switch (headId)
                           {
                               case 1:
                                   head = "SMITH REPORT";//Smith Issue
                                   len = 75;
                                   PurTot += Convert.ToDouble(ds.Tables[0].Rows[i]["purewt"]);
                                   break;
                               case 2:
                                   head = "ITEM REPORT";//Smith Reciept
                                   len = 60;
                                   PurTot += Convert.ToDouble(ds.Tables[0].Rows[i]["purewt"]);
                                   break;
                               case 3:
                                   head = "RAW REPORT";//Raw Purchase
                                   len = 60;
                                   PurTot += Convert.ToDouble(ds.Tables[0].Rows[i]["purewt"]);
                                   break;
                           }
                       }
                    }
                    objRptTextCntr.GF_AddNewLine(0);
                     ttlwt += Convert.ToDouble (ds.Tables[0].Rows[i]["wt"]);//coding for item wt total                   
                }
            }
            int n = 0;
            while (n < 3)
            {        //code for vertical line
                  objRptTextCntr.Gf_AddSeperator();
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 14, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 14, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 15, true);
                if (_Purewt)
                {
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 14, true);
                }
                
                objRptTextCntr.GF_AddNewLine(0);
                n++;
            }
            objRptTextCntr.GF_DrawLine(len);
           
           
          
        }
          if (_Purewt)
          {
              objRptTextCntr.Gf_AddSeperator();
              objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 14, false);
              objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 14, false);
              objRptTextCntr.Gf_DrawText("TOTAL", RptControl.TextAlign.Right, 17, true);
              objRptTextCntr.Gf_DrawText(PurTot, RptControl.TextAlign.Right, 14, false,"F3");


              objRptTextCntr.GF_DrawLine(len);
          }
           
           string print = objRptTextCntr.GF_GetPrintString();

            rtxt_stock.Text = print;

        }

        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                //argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);

                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0010");
            }
            return string.Empty;
        }

        private String CallWS(String Xml, String ClassName, String Mode)
        {
            string xmlData = string.Empty;
            try
            {
                // For Using Webservice
                UtilsApp.CallBO objServ = new UtilsApp.CallBO();
                xmlData = objServ.CallWS(Xml, ClassName, Mode);

                // For Using Reference
                //BizObj.RP_006 objreg = new BizObj.RP_006();
                //xmlData = objreg.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0009");
            }
            return xmlData;
        }

        private void DoClear()
        {
            this.rtxt_stock.Clear();
        }

        private void LoadReport()
        {
            try
            {
                //string mode = "E";
                //if (this.rad_cndtn.ControlValue == "C")
                //{
                //    mode = "C";
                //}

                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(""));
                xmlData = this.CallWS(xmlData, "BizObj.RP_006,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                if (ds.Tables.Count != 0)
                {
                    this.print(ds);

                }
                else
                {
                    this.DoClear();
                    PLABS.MessageBoxPL.Show("No Record Found");
                }
            }
            catch (Exception ex)
            { 
            }
        }

        #endregion
    }
}
