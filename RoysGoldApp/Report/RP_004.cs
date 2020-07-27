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
    public partial class RP_004 : PLABS.MasterForm
    {
        #region Gloabal variable
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public RP_004()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            

            this.loadControls();
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.btn_load.Click += new EventHandler(btn_load_Click);
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.ddl_smth_nam.SelectedValueChanged += new EventHandler(ddl_smth_nam_SelectedValueChanged);
            base.OnLoad(e);
        }

       
        #endregion
        #region Events

        void btn_print_Click(object sender, EventArgs e)
        {

        }

        void btn_load_Click(object sender, EventArgs e)
        {
            this.LoadClick();
        }

        void btn_exit_Click(object sender, EventArgs e)
        {

        }
        void ddl_smth_nam_SelectedValueChanged(object sender, EventArgs e)
        {
            this.LoadClick();
        }
        #endregion
        #region Methods

        private void loadControls()
        {
            try
            {
                dp_frm.ControlValue = "04-" + "01-" + "2010";// DateTime.Now.ToString("MMM-yyyy");
                DateTime dt = DateTime.Now.AddMonths(1);
                dt = new DateTime(dt.Year, dt.Month, 1);
                dt = dt.AddDays(-1);
                dp_to.ControlValue = dt.ToString("dd-MMM-yyyy");

                
                DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")), this.ddl_smth_nam.ControlValue);

                this.ddl_smth_nam.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_nam", "addr_id");
                this.LoadReport(ds);
               
               
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0002");
            }
        }
        public void print(DataTable master,DataTable detail)
        {

            int len = 88;
            double iss_wt = 0;
            double rcpt_wt = 0;
           
           
            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();

            for (int j = 0; j < master.Rows.Count; j++)
            {
                int k = 0;
                double issrecwt = 0.00;
                double ttl = 0.00;
              
                string shp_nam = "";
                shp_nam = PLABS.Utils.CnvToStr(master.Rows[j]["addr_nam"]);

                objRptTextCntr.GF_AddNewLine(1);

                for (int i = 0; i < detail.Rows.Count; i++)
                {
                    string pur_nam = "";
                    pur_nam = PLABS.Utils.CnvToStr(detail.Rows[i]["smith"]);
                    if (shp_nam == pur_nam)
                    {

                        if (k == 0)
                        {

                            objRptTextCntr.Gf_DrawText(pur_nam, RptControl.TextAlign.Center, len, false);
                            objRptTextCntr.GF_AddNewLine(0);
                            objRptTextCntr.GF_DrawLine(len);

                            objRptTextCntr.Gf_AddSeperator();
                            objRptTextCntr.Gf_DrawText("Date", RptControl.TextAlign.Center, 13, true);
                            objRptTextCntr.Gf_DrawText("Item Name", RptControl.TextAlign.Center, 12, true);
                            objRptTextCntr.Gf_DrawText("purity", RptControl.TextAlign.Center, 13, true);
                            objRptTextCntr.Gf_DrawText("Issue Weight", RptControl.TextAlign.Center, 12, true);
                            objRptTextCntr.Gf_DrawText("Reciept Weight", RptControl.TextAlign.Center, 12, true);
                            objRptTextCntr.Gf_DrawText("MC", RptControl.TextAlign.Center, 8, true);
                            objRptTextCntr.Gf_DrawText("Balance", RptControl.TextAlign.Center, 12, true);
                           
                            objRptTextCntr.GF_AddNewLine(0);
                            objRptTextCntr.GF_DrawLine(len);
                            k++;
                            iss_wt = 0;
                            rcpt_wt = 0;


                        }

                        string dat = "";
                        dat = PLABS.Utils.CnvToDate(detail.Rows[i]["date"]).ToString("dd-MMM-yyyy");

                        objRptTextCntr.Gf_AddSeperator();
                        objRptTextCntr.Gf_DrawText(dat, RptControl.TextAlign.Left, 13, true);
                        objRptTextCntr.Gf_DrawText(detail.Rows[i]["gold"], RptControl.TextAlign.Left, 12, true);
                        objRptTextCntr.Gf_DrawText(detail.Rows[i]["purty"], RptControl.TextAlign.Right, 13, true, "F2");
                        if (detail.Rows[i]["vou_typ_id"].ToString() == "2")
                        {
                            rcpt_wt += Convert.ToDouble(detail.Rows[i]["grs_wgt"]);
                            objRptTextCntr.Gf_DrawText("             ", RptControl.TextAlign.Left, 12, true);


                            objRptTextCntr.Gf_DrawText(detail.Rows[i]["grs_wgt"], RptControl.TextAlign.Right, 12, true, "F3");
                            objRptTextCntr.Gf_DrawText(detail.Rows[i]["mc"], RptControl.TextAlign.Right, 8, true, "F3");
                            if (PLABS.Utils.CnvToStr(detail.Rows[i]["mc_ratio"]) == "2")
                            {
                                issrecwt -= Convert.ToDouble(detail.Rows[i]["grs_wgt"])
                                           + Convert.ToDouble(detail.Rows[i]["mc"]);
                            }
                            else
                            {
                                issrecwt -= Convert.ToDouble(detail.Rows[i]["grs_wgt"]);
                            }
                           
                          
                           
                        }
                        else if (detail.Rows[i]["vou_typ_id"].ToString() == "1")
                        {
                            iss_wt += Convert.ToDouble(detail.Rows[i]["grs_wgt"]);
                             
                            objRptTextCntr.Gf_DrawText(detail.Rows[i]["grs_wgt"], RptControl.TextAlign.Right, 12, true, "F3");
                            objRptTextCntr.Gf_DrawText("             ", RptControl.TextAlign.Left, 12, true);
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 8, true);
                            issrecwt += Convert.ToDouble(detail.Rows[i]["grs_wgt"]);
                            
                        }
                        ttl += Convert.ToDouble(detail.Rows[i]["grs_wgt"]);
                        objRptTextCntr.Gf_DrawText(issrecwt.ToString("N3"), RptControl.TextAlign.Right, 12, true);
                       
                        
                        objRptTextCntr.GF_AddNewLine(0);

                    }
                    if (i ==detail.Rows.Count - 1)
                    {

                        int n = 0;
                        while (n < 3)
                        {
                            objRptTextCntr.Gf_AddSeperator();
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 13, true);
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 13, true);
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                          
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 8, true);
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                            objRptTextCntr.GF_AddNewLine(0);
                            n++;

                        }

                        objRptTextCntr.GF_DrawLine(len);
                        objRptTextCntr.Gf_AddSeperator();
                        objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 26, true);
                        objRptTextCntr.Gf_DrawText("Total", RptControl.TextAlign.Right, 13, true);
                        objRptTextCntr.Gf_DrawText(iss_wt, RptControl.TextAlign.Right, 12, true,"F3");

                        objRptTextCntr.Gf_DrawText(rcpt_wt, RptControl.TextAlign.Right, 12, true, "F3");
                        objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 8, true);
                        objRptTextCntr.Gf_DrawText(issrecwt.ToString("N3"), RptControl.TextAlign.Right, 12, true);
                        objRptTextCntr.GF_AddNewLine(0);
                        objRptTextCntr.GF_DrawLine(len);

                    }

                }

                string print = objRptTextCntr.GF_GetPrintString();
                this.rtxt_purchase.Text = print;


            }

        }
        private String getSelectArgs(String as_mode, String as_frm_date, String as_to_date, String ai_smth_nam)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "as_frm_date", as_frm_date);
                argXml = PLABS.Utils.addNode(argXml, "as_to_date", as_to_date);
                argXml = PLABS.Utils.addNode(argXml, "ai_smth_nam", ai_smth_nam);
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
                //BizObj.RP_004 objrptiss_recpt = new BizObj.RP_004();
                //xmlData = objrptiss_recpt.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0009");
            }
            return xmlData;
        }

        private void DoClear()
        {
            this.rtxt_purchase.Clear();

        }
        private DataSet GetDataSet(String as_mode, String as_frm_date, String as_to_date, String ai_smth_nam)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, as_frm_date, as_to_date, ai_smth_nam));
                xmlData = this.CallWS(xmlData, "BizObj.RP_004,BizObj", "S");
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
                if (ds.Tables.Count > 2)
                {
                    if (ds.Tables[1].Rows.Count != 0 && ds.Tables[2].Rows.Count != 0)
                    {
                        this.print(ds.Tables[1], ds.Tables[2]);
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
        private void LoadClick()
        {
            try 
            {
                DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")), this.ddl_smth_nam.ControlValue);
                this.LoadReport(ds);
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
