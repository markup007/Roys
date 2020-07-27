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
    public partial class RP_003 : PLABS.MasterForm
    {
        #region Global variable
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public RP_003()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.loadControls();
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.btn_load.Click += new EventHandler(btn_load_Click);
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.ddl_pur_nam.SelectedValueChanged += new EventHandler(ddl_pur_nam_SelectedValueChanged);
            base.OnLoad(e);
        }
        #endregion
        #region Events

        void btn_print_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(@"D:\print.txt", Print);
            //System.Diagnostics.Process.Start("C:\\print\\print.bat");
        }

        void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadClick();
            }
            catch (Exception ex)
            {
 
            }
           
        }

        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ddl_pur_nam_SelectedValueChanged(object sender, EventArgs e)
        {
            this.LoadClick();
        }

        #endregion
        #region Methods

        private void loadControls()
        {
            try
            {
                this.rtxt_purchase.Focus();

                dp_frm.ControlValue = "04-" + "01-" + "2010"; //DateTime.Now.ToString("MMM-yyyy");
                DateTime dt = DateTime.Now.AddMonths(1);
                dt = new DateTime(dt.Year, dt.Month, 1);
                dt = dt.AddDays(-1);
                dp_to.ControlValue = dt.ToString("dd-MMM-yyyy");

                DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")), this.ddl_pur_nam.ControlValue);

                this.ddl_pur_nam.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_nam", "addr_id");
                this.LoadReport(ds);
               
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0002");
            }
        }

        
        public void print(DataTable  rpt)
        {

            int len =92;
            //double wt = 0;
            //double rate = 0;

            double purewt = 0;
            double pureWtForAvgRt = 0;
            //double weight = 0;
            double rte = 0;
            double ttlrt = 0;

            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();


            objRptTextCntr.GF_AddNewLine(1);
            objRptTextCntr.Gf_DrawText("RAW PARCHASE", RptControl.TextAlign.Center, len, false);
           
            objRptTextCntr.GF_AddNewLine(1);
            objRptTextCntr.GF_DrawLine(len);



            objRptTextCntr.Gf_AddSeperator();
            objRptTextCntr.Gf_DrawText("DATE", RptControl.TextAlign.Center, 11, true);
            objRptTextCntr.Gf_DrawText("PARCHASER", RptControl.TextAlign.Center, 10, true);
            objRptTextCntr.Gf_DrawText("GOLD NAME", RptControl.TextAlign.Center, 10, true);
            objRptTextCntr.Gf_DrawText("PURITY", RptControl.TextAlign.Center, 6, true);
            objRptTextCntr.Gf_DrawText("GOLD WT", RptControl.TextAlign.Center, 8, true);
            objRptTextCntr.Gf_DrawText("RATE/GRM", RptControl.TextAlign.Center, 9, true);
            objRptTextCntr.Gf_DrawText("PURE WT", RptControl.TextAlign.Center, 7, true);
            objRptTextCntr.Gf_DrawText("TOTAL RATE", RptControl.TextAlign.Center, 11, true);
            objRptTextCntr.Gf_DrawText("DESCRIPTION", RptControl.TextAlign.Center, 12, true);
            objRptTextCntr.GF_AddNewLine(0);
            objRptTextCntr.GF_DrawLine(len);

                for (int i = 0; i < rpt.Rows.Count; i++)
                {

                        string dat = "";
                        dat = PLABS.Utils.CnvToDate(rpt.Rows[i]["date"]).ToString("dd-MMM-yyyy");

                        objRptTextCntr.Gf_AddSeperator();
                        objRptTextCntr.Gf_DrawText(dat, RptControl.TextAlign.Left, 11, true);
                        objRptTextCntr.Gf_DrawText(rpt.Rows[i]["addr_nam"], RptControl.TextAlign.Left, 10, true);
                        objRptTextCntr.Gf_DrawText(rpt.Rows[i]["gold"], RptControl.TextAlign.Left, 10, true);
                        objRptTextCntr.Gf_DrawText(rpt.Rows[i]["purty"], RptControl.TextAlign.Right, 6, true, "F2");
                        objRptTextCntr.Gf_DrawText(rpt.Rows[i]["wt"], RptControl.TextAlign.Right, 8, true, "F3");
                        objRptTextCntr.Gf_DrawText(rpt.Rows[i]["rate"], RptControl.TextAlign.Right, 9, true, "F2");
                        objRptTextCntr.Gf_DrawText(rpt.Rows[i]["purewt"], RptControl.TextAlign.Right, 7, true, "F3");
                        objRptTextCntr.Gf_DrawText(rpt.Rows[i]["ttlamt"], RptControl.TextAlign.Right, 11, true, "F2");
                        objRptTextCntr.Gf_DrawText(rpt.Rows[i]["descr"], RptControl.TextAlign.Left, 12, true);
                        //objRptTextCntr.Gf_DrawText("Total", RptControl.TextAlign.Right, 11, true, "F2");
                        objRptTextCntr.GF_AddNewLine(0);

                        //wt += Convert.ToDouble(rpt.Rows[i]["wt"]);
                        //rate += Convert.ToDouble(rpt.Rows[i]["rate"]);
                        purewt += Convert.ToDouble(rpt.Rows[i]["purewt"]);
                        if (PLABS.Utils.CnvToInt(rpt.Rows[i]["vou_typ_id"]) == PLABS.Utils.CnvToInt(Enums.VoucherType.RawPurchase))
                        {
                           pureWtForAvgRt+=PLABS .Utils .CnvToDouble(rpt.Rows[i]["purewt"]);
                        }
                        ttlrt +=PLABS .Utils.CnvToDouble (rpt.Rows [i]["ttlamt"]);
                        //cnt++;
                 

                                          

                }
                int n = 0;
                while (n < 3)
                {
                    objRptTextCntr.Gf_AddSeperator();
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 11, true);
                    //objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 15, true);
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 10, true);
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 10, true);
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 6, true);
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 8, true);
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 9, true);
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 7, true);
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 11, true);
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                    objRptTextCntr.GF_AddNewLine(0);
                    n++;

                }

                objRptTextCntr.GF_DrawLine(len);
                objRptTextCntr.Gf_AddSeperator();
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 11, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 10, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 10, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 6, true);
                objRptTextCntr.Gf_DrawText("TOTAL", RptControl.TextAlign.Right, 8, true);
                objRptTextCntr.Gf_DrawText(ttlrt / pureWtForAvgRt, RptControl.TextAlign.Right, 9, true, "F2");
                objRptTextCntr.Gf_DrawText(purewt, RptControl.TextAlign.Right, 7, true, "F3");
                objRptTextCntr.Gf_DrawText(ttlrt, RptControl.TextAlign.Right, 11, true,"F2");
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 12, true);
                objRptTextCntr.GF_AddNewLine(0);
                objRptTextCntr.GF_DrawLine(len);


                string print = objRptTextCntr.GF_GetPrintString();

                rtxt_purchase.Text = print;
            //}


        }

        private String getSelectArgs(String as_mode, String as_frm_date, String as_to_date, String ai_pur_nam)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "as_frm_date", as_frm_date);
                argXml = PLABS.Utils.addNode(argXml, "as_to_date", as_to_date);
                argXml = PLABS.Utils.addNode(argXml, "ai_pur_nam", ai_pur_nam);
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
                //BizObj.RP_003 objrptraw = new BizObj.RP_003();
                //xmlData = objrptraw.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0009");
            }
            return xmlData;
        }
        private void LoadClick()
        {
            try
            {
                DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")), this.ddl_pur_nam.ControlValue);
                this.LoadReport(ds);
            }
            catch (Exception ex)
            {
 
            }
        }
        private DataSet GetDataSet(String as_mode, String as_frm_date, String as_to_date, String ai_pur_nam)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, as_frm_date, as_to_date, ai_pur_nam));
                xmlData = this.CallWS(xmlData, "BizObj.RP_003,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            { 
            }
            return ds;
        }
        private void LoadReport(DataSet ds)
        {
            try
            {
                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[1].Rows.Count != 0)
                    {
                        this.print(ds.Tables[1]);
                    }
                    else
                    {
                        this.rtxt_purchase.Clear();
                        PLABS.MessageBoxPL.Show("No Records Found");
                    }
                }
                else
                {
                    this.rtxt_purchase.Clear();
                    PLABS.MessageBoxPL.Show("No Records Found");
                }

            }
            catch (Exception ex)
            {
               
            }
        }
        #endregion
    }

}
