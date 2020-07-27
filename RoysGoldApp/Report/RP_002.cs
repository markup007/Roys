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
    public partial class RP_002 : PLABS.MasterForm
    {
        #region Global variables
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public RP_002()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.btn_load.Click += new EventHandler(btn_load_Click);
            this.ddl_smth.SelectedValueChanged += new EventHandler(ddl_smth_SelectedValueChanged);
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
        void ddl_smth_SelectedValueChanged(object sender, EventArgs e)
        {
            this.LoadClick();
        }

        #endregion
        #region Methods
        private void LoadControls()
        {
            this.rtxt_smthrecpt.Focus();

            dp_frm.ControlValue = "04-" + "01-" + "2010"; //DateTime.Now.ToString("MMM-yyyy");
            DateTime dt = DateTime.Now.AddMonths(1);
            dt = new DateTime(dt.Year, dt.Month, 1);
            dt = dt.AddDays(-1);
            dp_to.ControlValue = dt.ToString("dd-MMM-yyyy");

            DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")), this.ddl_smth.ControlValue);

            this.ddl_smth.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_nam", "addr_id");
            this.LoadReport(ds);
        }
        public string header()
        {

            int len = 105;


            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();

            objRptTextCntr.Gf_DrawText("SMITH RECEIPT", RptControl.TextAlign.Center, len, false);
            objRptTextCntr.GF_AddNewLine(0);

            return objRptTextCntr.GF_GetPrintString();


        }

        public void print(DataTable rpt)
        {
            int len = 105;//previous 88
            double ttl_prty_wt = 0;
            double ttlGain=0.00;
            string header = this.header();

            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();
            objRptTextCntr.GF_DrawLine(len);
            objRptTextCntr.Gf_AddSeperator();
            objRptTextCntr.Gf_DrawText("Date", RptControl.TextAlign.Center, 11, true);
            objRptTextCntr.Gf_DrawText("Smith Name", RptControl.TextAlign.Center, 10, true);
            objRptTextCntr.Gf_DrawText("Receipt Gold Name", RptControl.TextAlign.Center, 17, true);
            objRptTextCntr.Gf_DrawText("Purity", RptControl.TextAlign.Center, 7, true);
            objRptTextCntr.Gf_DrawText("WT", RptControl.TextAlign.Center, 9, true);
            objRptTextCntr.Gf_DrawText("Pure WT", RptControl.TextAlign.Center, 7, true);
            objRptTextCntr.Gf_DrawText("Making Charge",RptControl.TextAlign.Center,15,true);//modified here
            objRptTextCntr.Gf_DrawText("Description", RptControl.TextAlign.Center, 12, true);
            objRptTextCntr.Gf_DrawText("Gain", RptControl.TextAlign.Center, 9, true);
            
            objRptTextCntr.GF_AddNewLine(0);
            objRptTextCntr.GF_DrawLine(len);
            int i = 0;
            while (i < rpt.Rows.Count)
            {
                double wt = 0;
                wt = Convert.ToDouble(rpt.Rows[i]["grs_wgt"]);

                double purty = 0;
                purty = Convert.ToDouble(rpt.Rows[i]["purty"]);

                double pur_wt = 0;
                pur_wt = (purty * wt) / 100;

                objRptTextCntr.Gf_AddSeperator();
                DateTime date = PLABS.Utils.CnvToDate(rpt.Rows[i]["date"]);
                string Date = date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();

                objRptTextCntr.Gf_DrawText(Date, RptControl.TextAlign.Left, 11, true);
                objRptTextCntr.Gf_DrawText(rpt.Rows[i]["addr_nam"], RptControl.TextAlign.Left, 10, true);
                objRptTextCntr.Gf_DrawText(rpt.Rows[i]["itm_name"], RptControl.TextAlign.Left, 17, true);
                objRptTextCntr.Gf_DrawText(rpt.Rows[i]["purty"], RptControl.TextAlign.Right, 7, true,"F2");
                objRptTextCntr.Gf_DrawText(rpt.Rows[i]["grs_wgt"], RptControl.TextAlign.Right, 9, true,"F3");
                objRptTextCntr.Gf_DrawText(pur_wt, RptControl.TextAlign.Right, 7, true,"F3");
                objRptTextCntr.Gf_DrawText(rpt.Rows[i]["mc"],RptControl.TextAlign.Right,15,true,"F3");
                objRptTextCntr.Gf_DrawText(rpt.Rows [i]["descr"], RptControl.TextAlign.Left, 12, true);
                objRptTextCntr.Gf_DrawText(rpt.Rows[i]["Gain"], RptControl.TextAlign.Right, 9, true);
                objRptTextCntr.GF_AddNewLine(0);
                ttlGain+=PLABS .Utils.CnvToDouble (rpt.Rows[i]["Gain"]);
                ttl_prty_wt += pur_wt;

                i++;
            }
            int n = 0;
            while (n < 5)
            {
                objRptTextCntr.Gf_AddSeperator();
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 11, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 10, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 17, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 7, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 9, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 7, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 15, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 9, true);
                objRptTextCntr.GF_AddNewLine(0);
                n++;
            }

            objRptTextCntr.GF_DrawLine(len);
            objRptTextCntr.Gf_AddSeperator();

            objRptTextCntr.Gf_DrawText("Total", RptControl.TextAlign.Right, 58, true);
            objRptTextCntr.Gf_DrawText(ttl_prty_wt, RptControl.TextAlign.Right, 7, true,"F3");
            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 15, true);
            objRptTextCntr.Gf_DrawText(ttlGain.ToString ("N3"), RptControl.TextAlign.Right,22 , true);
            objRptTextCntr.GF_AddNewLine(0);
            objRptTextCntr.GF_DrawLine(len);

            string print = header;
            print += objRptTextCntr.GF_GetPrintString();

            rtxt_smthrecpt.Text = print;

        }

        private String getSelectArgs(String as_mode, String as_frm_date, String as_to_date, String ai_smth_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "as_frm_date", as_frm_date);
                argXml = PLABS.Utils.addNode(argXml, "as_to_date", as_to_date);
                argXml = PLABS.Utils.addNode(argXml, "ai_smth_id", ai_smth_id);
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
                //BizObj.RP_002 objrptsnthiss = new BizObj.RP_002();
                //xmlData = objrptsnthiss.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0009");
            }
            return xmlData;
        }

        private void DoClear()
        {
            this.rtxt_smthrecpt.Clear();
        }
        private void LoadClick()
        {
            try
            {
                DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")), this.ddl_smth.ControlValue);
                this.LoadReport(ds);
            }
            catch (Exception ex)
            {
 
            }
        }
        private DataSet GetDataSet(String as_mode, String as_frm_date, String as_to_date, String ai_smth_id)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, as_frm_date, as_to_date, ai_smth_id));
                xmlData = this.CallWS(xmlData, "BizObj.RP_002,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            }
            catch(Exception ex)
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
                        this.rtxt_smthrecpt.Clear();
                        PLABS.MessageBoxPL.Show("No Records Found");
                    }
                }
                else
                {
                    this.rtxt_smthrecpt.Clear();
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
