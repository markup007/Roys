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
    public partial class RP_007 : PLABS.MasterForm
    {
        #region Variables

        #endregion

        #region Constructor

        public RP_007()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.LoadControls();
            this.ddl_addr.SelectedIndexChanged += new EventHandler(ddl_addr_SelectedIndexChanged);
            this.ddl_mnth.SelectedIndexChanged += new EventHandler(ddl_mnth_SelectedIndexChanged);
            this.dp_frm.Leave += new EventHandler(dp_frm_Leave);
            this.dp_to.Leave += new EventHandler(dp_to_Leave);
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            
        }

        void dp_to_Leave(object sender, EventArgs e)
        {
            try
            {
                this.GrupItem();
            }
            catch (Exception ex)
            {

            }
        }

        void dp_frm_Leave(object sender, EventArgs e)
        {
            try
            {
                this.GrupItem();
            }
            catch (Exception ex)
            {
 
            }
        }

       

        #endregion

        #region Events

        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ddl_addr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt_Report.Clear();
              this.GrupItem();
        }
        void ddl_mnth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dp_frm.ControlValue = "01-" + this.ddl_mnth.ControlValue + "-" + PLABS.Utils.CnvToStr(DateTime.Now.Year);
               // dp_frm.ControlValue = "01-" + this.ddl_mnth.ControlValue + "-" + PLABS.Utils.CnvToStr(DateTime.Now.Year);
                dp_to.Value = PLABS.Utils.CnvToDate(dp_frm.ControlValue).AddMonths(1).AddDays(-1);
                this.GrupItem();


               

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Methods
        private void LoadControls()
        {
            this.LoadCombo();
           // dp_frm.ControlValue  = "01-" + PLABS.Utils.CnvToStr(DateTime.Now.Month)+"-"+PLABS.Utils.CnvToStr(DateTime.Now.Year);
            //dp_to.Value = PLABS.Utils.CnvToDate(dp_frm.ControlValue).AddMonths(1).AddDays(-1);
            dp_frm.ControlValue =  "01-" + DateTime.Now.Month +'-' + PLABS.Utils.CnvToStr(DateTime.Now.Year);
            dp_to.Value = DateTime.Now;
            DataSet ds = this.GetDataSet("LO", this.ddl_addr.ControlValue);
            this.ddl_addr.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_nam", "addr_id");
            this.GrupItem();      
        }
        private String LoadRpt(DataTable master,String heading)
        {
            try
            {
                RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();

                int len = 88;
                if (!master.Columns.Contains("mcamt"))
                    len = 75;
                double gTtlSal = 0.000;
                double gTtlRet = 0.000;
                double gTtlMc = 0.000;
                double gTtlMcAmt = 0.000;
                // DataSet ds = this.GetDataSet("LR", PLABS.Utils.CnvToStr(this.ddl_addr.ControlValue));
                //DataTable master = PLABS.Utils.GetDataTable(ds, 0);
                DataTable dtDate=master.DefaultView.ToTable(true,new string[] {"date"});
                dtDate.DefaultView.Sort = "date ASC";
                dtDate = dtDate.DefaultView.ToTable();
                           //DataTable name = (DataTable)ddl_addr.DataSource;
                           //DataTable Item = ds.Tables[1];
                          //DataTable Group = ds.Tables[2];
                objRptTextCntr.GF_AddNewLine(1);
                objRptTextCntr.Gf_DrawText(heading, RptControl.TextAlign.Center, len, false);
                objRptTextCntr.GF_AddNewLine(1);
                foreach (DataRow dtDr in dtDate.Rows)
                {
                    double bal = 0.000;
                    double ttlSal = 0.00;
                    double ttlRet = 0.000;
                    objRptTextCntr.Gf_DrawText(string.Format("DATE:-{0}", PLABS.Utils.CnvToDate(dtDr["date"]).ToString("dd/MMM/yyyy")), RptControl.TextAlign.Left, len, false);
                    objRptTextCntr.GF_AddNewLine(0);
                    objRptTextCntr.GF_DrawLine(len);

                    objRptTextCntr.Gf_AddSeperator();
                    objRptTextCntr.Gf_DrawText("SHOP", RptControl.TextAlign.Center, 13, true);
                    objRptTextCntr.Gf_DrawText("ITEM", RptControl.TextAlign.Center, 12, true);
                    objRptTextCntr.Gf_DrawText("NET WT", RptControl.TextAlign.Center, 13, true);
                    objRptTextCntr.Gf_DrawText("SALES", RptControl.TextAlign.Center, 12, true);
                    objRptTextCntr.Gf_DrawText("RETURN", RptControl.TextAlign.Center, 12, true);
                    objRptTextCntr.Gf_DrawText("MC WT", RptControl.TextAlign.Center, 8, true);
                    if (master.Columns.Contains("mcamt"))
                        objRptTextCntr.Gf_DrawText("MC AMT", RptControl.TextAlign.Center, 12, true);
                    //objRptTextCntr.Gf_DrawText("BALANCE", RptControl.TextAlign.Center, 12, true);

                    objRptTextCntr.GF_AddNewLine(0);
                    objRptTextCntr.GF_DrawLine(len);
                    master.DefaultView.RowFilter=string.Format("date='{0}'",dtDr["date"]);
                    Double mcw=0;
                    Double mcamt=0;
                    foreach (DataRow masterDr in master.DefaultView.ToTable().Rows)
                    {
                        
                        objRptTextCntr.Gf_AddSeperator();
                        mcw += PLABS.Utils.CnvToDouble(masterDr["mc"]);
                        if (master.Columns.Contains("mcamt"))
                            mcamt += PLABS.Utils.CnvToDouble(masterDr["mcamt"]);
                        objRptTextCntr.Gf_DrawText(masterDr["name"], RptControl.TextAlign.Left, 13, true);
                        objRptTextCntr.Gf_DrawText(masterDr["itm"], RptControl.TextAlign.Left, 12, true);
                        objRptTextCntr.Gf_DrawText(masterDr["nw"], RptControl.TextAlign.Right, 13, true);
                        if (PLABS.Utils.CnvToDouble(masterDr["pw"]) > 0)
                        {
                            
                            objRptTextCntr.Gf_DrawText(masterDr["pw"], RptControl.TextAlign.Right, 12, true, "F3");
                            ttlSal += PLABS.Utils.CnvToDouble(masterDr["pw"]);
                            gTtlSal += PLABS.Utils.CnvToDouble(masterDr["pw"]);
                        }
                        else
                        {
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 12, true);
                        }


                        if (PLABS.Utils.CnvToDouble(masterDr["pw"]) < 0)
                        {
                            objRptTextCntr.Gf_DrawText(Math.Abs(PLABS.Utils.CnvToDouble(masterDr["pw"])), RptControl.TextAlign.Right, 12, true, "F3");
                            ttlRet +=Math.Abs(PLABS.Utils.CnvToDouble(masterDr["pw"]));
                            gTtlRet += Math.Abs(PLABS.Utils.CnvToDouble(masterDr["pw"]));
                        }
                        else
                        {
                            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 12, true);
                        }
                        if (PLABS.Utils.CnvToDouble(masterDr["mc"]) > 0)
                        {
                            objRptTextCntr.Gf_DrawText(masterDr["mc"], RptControl.TextAlign.Right, 8, true, "F3");
                        }
                        else
                        {
                            objRptTextCntr.Gf_DrawText(masterDr["mc"], RptControl.TextAlign.Right, 8, true, "F3");
                        }

                        if (master.Columns.Contains("mcamt"))
                            if (PLABS.Utils.CnvToDouble(masterDr["mcamt"]) > 0)
                            {
                                objRptTextCntr.Gf_DrawText(masterDr["mcamt"], RptControl.TextAlign.Right, 12, true, "F3");
                            }
                            else
                            {
                                objRptTextCntr.Gf_DrawText(masterDr["mcamt"], RptControl.TextAlign.Right, 12, true, "F3");
                            }

                        gTtlMc += PLABS.Utils.CnvToDouble(masterDr["mc"]);

                        if (master.Columns.Contains("mcamt"))
                            gTtlMcAmt += PLABS.Utils.CnvToDouble(masterDr["mcamt"]);
                        bal += PLABS.Utils.CnvToDouble(masterDr["pw"]);
                        //objRptTextCntr.Gf_DrawText(bal, RptControl.TextAlign.Center, 12, true,"F3");

                        objRptTextCntr.GF_AddNewLine(0);
                        //objRptTextCntr.GF_DrawLine(len);
                    }
                    objRptTextCntr.GF_DrawLine(len);
                    objRptTextCntr.Gf_AddSeperator();
                    //objRptTextCntr.Gf_DrawText("SHOP", RptControl.TextAlign.Center, 13, true);
                    //objRptTextCntr.Gf_DrawText("ITEM", RptControl.TextAlign.Center, 12, true);
                    objRptTextCntr.Gf_DrawText("TOTAL", RptControl.TextAlign.Right,40, true);
                    objRptTextCntr.Gf_DrawText(ttlSal, RptControl.TextAlign.Right, 12, true,"F3");
                    objRptTextCntr.Gf_DrawText(ttlRet, RptControl.TextAlign.Right, 12, true,"F3");
                    objRptTextCntr.Gf_DrawText(mcw, RptControl.TextAlign.Right, 8, true, "F3");
                    objRptTextCntr.Gf_DrawText(mcamt, RptControl.TextAlign.Right, 12, true, "F3");
                    //objRptTextCntr.Gf_DrawText("BALANCE", RptControl.TextAlign.Center, 12, true);
                    objRptTextCntr.GF_AddNewLine(0);
                    
                    objRptTextCntr.GF_DrawLine(len);
                   
                    objRptTextCntr.GF_AddNewLine(2);
                }

                objRptTextCntr.GF_DrawLine(len);
                objRptTextCntr.Gf_AddSeperator();
                Double temp = 0.000;
                temp = gTtlSal - gTtlRet;
                objRptTextCntr.Gf_DrawText("TOTAL", RptControl.TextAlign.Right, 40, true);
                objRptTextCntr.Gf_DrawText(temp, RptControl.TextAlign.Right, 12, true, "F3");
                objRptTextCntr.Gf_DrawText(gTtlRet, RptControl.TextAlign.Right, 12, true, "F3");
                objRptTextCntr.Gf_DrawText(gTtlMc, RptControl.TextAlign.Right, 8, true,"F3");
                if (master.Columns.Contains("mcamt"))
                    objRptTextCntr.Gf_DrawText(gTtlMcAmt, RptControl.TextAlign.Right, 12, true,"F3");
                //objRptTextCntr.Gf_DrawText("BALANCE", RptControl.TextAlign.Center, 12, true);
                objRptTextCntr.GF_AddNewLine(8);
             
                return objRptTextCntr.GF_GetPrintString();
            }
            catch (Exception ex)
            {
                //throw (ex);
            }
            return "";
        }
        private void GrupItem()
        {
            DataSet ds = this.GetDataSet("LR", PLABS.Utils.CnvToStr(this.ddl_addr.ControlValue));
            DataTable master = PLABS.Utils.GetDataTable(ds, 0); 
            master.DefaultView.RowFilter = "itm_typ_id=2";
            DataTable itmtype = master.DefaultView.ToTable(true, new string[] { "itm_typ_id" });
            String rptstr = string.Empty;
            string head;
            foreach (DataRow dr in itmtype.Rows)
            {
                master.DefaultView.RowFilter = string.Format("itm_typ_id ={0}",dr["itm_typ_id"]);
                if(PLABS.Utils.CnvToInt(dr["itm_typ_id"])==1)
                {
                    head="RAW";
                }
                else
                {
                    head="ITEM";
                }
                rptstr += this.LoadRpt(master.DefaultView.ToTable(),head);
            }
            this.txt_Report.Text = rptstr;
        }
        private String getSelectArgs(String as_mode,String ai_addr_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_shp_id",ddl_addr.ControlValue);
                argXml = PLABS.Utils.addNode(argXml, "ad_frm",dp_frm.Value.ToString("yyyy-MM-dd"));
                argXml = PLABS.Utils.addNode(argXml, "ad_to", dp_to.Value.ToString("yyyy-MM-dd"));
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
                // proj.CallWebService objServ = new proj.CallWebService();
                // xmlData = objServ.CallWS(Xml, ClassName, Mode);

                // For Using Reference
                UtilsApp.CallBO objServ = new UtilsApp.CallBO();
                xmlData = objServ.CallWS(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0009");
            }
            return xmlData;
        }
        private DataSet GetDataSet(String as_mode,String ai_addr_id)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_addr_id));
                xmlData = this.CallWS(xmlData, "BizObj.RP_007,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {
                //throw (ex);
            }
            DataSet ret = new DataSet();
            return ret;
        }
        private void LoadCombo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");


                dt.Rows.Add(1, "January");
                dt.Rows.Add(2, "February");
                dt.Rows.Add(3, "March");
                dt.Rows.Add(4, "April");
                dt.Rows.Add(5, "May");
                dt.Rows.Add(6, "June");
                dt.Rows.Add(7, "July");
                dt.Rows.Add(8, "August");
                dt.Rows.Add(9, "September");
                dt.Rows.Add(10, "October");
                dt.Rows.Add(11, "November");
                dt.Rows.Add(12, "December");

                this.ddl_mnth.LoadData(dt, "name", "id");
                this.ddl_mnth.ControlValue = PLABS.Utils.CnvToStr(DateTime.Now.Month);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
