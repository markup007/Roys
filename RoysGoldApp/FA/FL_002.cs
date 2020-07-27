using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RoysGold
{
    public partial class FL_002 : PLABS.MasterForm
    {
        #region Global Variables
        string _idFromFL_003 = string.Empty;
        string _dtId = string.Empty;
        string _date = string.Empty;
        string _printRpt = string.Empty;
        Font _printFont;
        #endregion
        #region Properties
        public string IdFromFL_003
        {
            set { _idFromFL_003 = value; }
            get { return _idFromFL_003; }
        }
        public string DtId
        {
            get { return _dtId; }
            set { _dtId = value; }
        }
        private string lege_Date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion
        #region Constructors
        

        public string Lege_Date
{
  get { return lege_Date; }
  set { lege_Date = value; }
}
        public FL_002()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.fnd_addr.AfterFind += new EventHandler(fnd_addr_AfterFind);
            this.dtp_to.Leave += new EventHandler(dtp_to_Leave);
            this.grd_data.CellEnter += new DataGridViewCellEventHandler(grd_data_CellEnter);
            this.dtp_frm.Leave += new EventHandler(dtp_frm_Leave);
            this.SaveAfterClick += new EventHandler(FL_002_SaveAfterClick);
            this.SaveBeforeClick += new EventHandler(FL_002_SaveBeforeClick);
            this.fnd_Grup.AfterFind += new EventHandler(fnd_Grup_AfterFind);
            this.btn_prt.Click += new EventHandler(btn_prt_Click);
            //this.grd_data.Leave += new EventHandler(grd_data_Leave);
            base.OnLoad(e);
        }   

        protected override void OnActivated(EventArgs e)
        {
            if (_idFromFL_003 != string.Empty)
            {
                this.grd_data.Focus();
            }
            base.OnActivated(e);
        }
        #endregion
        #region Events
        void btn_prt_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadReport();

            }
            catch (Exception ex)
            {
             
            }
        }
        void dtp_frm_Leave(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
                this.grd_data.Focus();
            }
            catch (Exception ex)
            {

            }
        }
        void dtp_to_Leave(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }
        void fnd_addr_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.grd_data.ClearControl(true);
                this.LoadGrid();
                this.grd_data.Focus();
            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                this.rtxt_desc.ClearControl(true);
                this.txt_wgt.ClearControl(true);
                this.txt_cash.ClearControl(true);
                this.rtxt_desc.Text = PLABS.Utils.CnvToStr(this.grd_data.CurrentRow.Cells["txt_desc_gv"].Value);
                this.txt_wgt.Text = PLABS.Utils.CnvToDouble(this.grd_data.CurrentRow.Cells["txt_balwt_gv"].Value).ToString ("F3");
                this.txt_cash.Text = PLABS.Utils.CnvToDouble(this.grd_data.CurrentRow.Cells["txt_cashbal_gv"].Value).ToString ("N2");

                CnvToCurncy obj = new CnvToCurncy();
                this.lbl_amtwrd.Text = obj.get(PLABS.Utils.CnvToDouble(this.txt_cash.Text));
            }
            catch
            {

            }
        }
        //void grd_data_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.rtxt_desc.ClearControl(true);
        //        this.txt_wgt.ClearControl(true);
        //        this.txt_cash.ClearControl(true);
        //    }
        //    catch (Exception ex)
        //    {
 
        //    }
        //}

        void FL_002_SaveBeforeClick(object sender, EventArgs e)
        {

        }

        void FL_002_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch(Exception ex)
            {
            }
        }

        void fnd_Grup_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.grd_data.ClearControl(true);
                this.fnd_addr.ClearControl(true);
                this.LoadHeadNames();
            }
            catch(Exception ex)
            {
            }
        }
        #endregion
        #region Methods
        private void LoadReport()
        {
            try
            {
                int PAGE_WIDTH = 111;               
                DataTable dgvDt = (DataTable)grd_data.DataSource;
               // DataTable dgvDt_Head = dgvDt.Clone();

                RptControl.RptTextCntrl objRptTextCntrl = new RptControl.RptTextCntrl();
                objRptTextCntrl.GV_TopMargineLineCnt = 5;
                objRptTextCntrl.GV_BottomMargineLineCnt = 5;
                objRptTextCntrl.GV_LeftMargineLineCnt = 3;

                #region HEADER
                //objRptTextCntrl.Gf_DrawText("Weight Ledger", RptControl.TextAlign.Center, PAGE_WIDTH, false);
                //objRptTextCntrl.GF_AddNewLine(2);

                objRptTextCntrl.Gf_DrawText("Group : " + fnd_Grup.SelectedCode + "                         To : " + fnd_addr.SelectedCode, RptControl.TextAlign.Left, PAGE_WIDTH, false);
                objRptTextCntrl.GF_AddNewLine(2);

                objRptTextCntrl.Gf_DrawText("From Date : " + dtp_frm.Value.Date.ToShortDateString() + "                 To Date : " + dtp_to.Value.ToShortDateString(), RptControl.TextAlign.Left, PAGE_WIDTH , false);
                objRptTextCntrl.GF_AddNewLine(2);
                #endregion

                #region DETAILS HEADER
                objRptTextCntrl.GF_DrawLine(PAGE_WIDTH);
                objRptTextCntrl.Gf_AddSeperator();

                objRptTextCntrl.Gf_DrawText("DATE", RptControl.TextAlign.Center, 10, true); 
                objRptTextCntrl.Gf_DrawText("ITEM", RptControl.TextAlign.Center, 22, true); 
                objRptTextCntrl.Gf_DrawText("WT", RptControl.TextAlign.Center, 8, true); 
                objRptTextCntrl.Gf_DrawText("ISSUE", RptControl.TextAlign.Center, 8, true); 
                objRptTextCntrl.Gf_DrawText("RECEIPT", RptControl.TextAlign.Center,8, true); 
                objRptTextCntrl.Gf_DrawText("MC", RptControl.TextAlign.Center, 10, true);  
                objRptTextCntrl.Gf_DrawText("MCRATE", RptControl.TextAlign.Center, 8, true); 
                objRptTextCntrl.Gf_DrawText("PAYMENT", RptControl.TextAlign.Center, 12, true); 
                objRptTextCntrl.Gf_DrawText("RECEIPT", RptControl.TextAlign.Center, 12, true); 
                objRptTextCntrl.Gf_DrawText("USER", RptControl.TextAlign.Center, 4, true); 
                objRptTextCntrl.GF_AddNewLine(0);
                objRptTextCntrl.GF_DrawLine(PAGE_WIDTH);


                #endregion

                #region DETAILS DATA
               
                int itemCount = dgvDt.Rows.Count;
                for (int i = 0; i < itemCount; i++)
                {

                    String WT = String.Empty;
                    String ISSUE = String.Empty;
                    String RECEIPT = String.Empty;
                    String MC = String.Empty;
                    String MCRATE = String.Empty;
                    String PAYMENT = String.Empty;
                    String RECEIPT1 = String.Empty;


                    String DATE = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToStr(dgvDt.Rows[i]["date"]));
                    String ITEM = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToStr(dgvDt.Rows[i]["item"]));

                    if (PLABS.Utils.CnvToStr(dgvDt.Rows[i]["wt"]) == "")
                        WT = "";
                    else
                        WT = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToDouble(dgvDt.Rows[i]["wt"]).ToString("F3"));

                    if (PLABS.Utils.CnvToStr(dgvDt.Rows[i]["isswt"]) == "")
                        ISSUE = "";
                    else
                        ISSUE = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToDouble(dgvDt.Rows[i]["isswt"]).ToString("F3"));

                    if (PLABS.Utils.CnvToStr(dgvDt.Rows[i]["recwt"]) == "")
                        RECEIPT = "";
                    else
                        RECEIPT = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToDouble(dgvDt.Rows[i]["recwt"]).ToString("F3"));

                    if (PLABS.Utils.CnvToStr(dgvDt.Rows[i]["mc"]) == "")
                        MC = "";
                    else
                        MC = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToStr(dgvDt.Rows[i]["mc"]));

                    if (PLABS.Utils.CnvToStr(dgvDt.Rows[i]["mcrt"]) == "")
                        MCRATE = "";
                    else
                        MCRATE = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToDouble(dgvDt.Rows[i]["mcrt"]).ToString("F3"));

                    if (PLABS.Utils.CnvToStr(dgvDt.Rows[i]["dr"]) == "")
                        PAYMENT = "";
                    else
                        PAYMENT = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToDouble(dgvDt.Rows[i]["dr"]).ToString("F3"));


                    if (PLABS.Utils.CnvToStr(dgvDt.Rows[i]["cr"]) == "")
                        RECEIPT1 = "";
                    else
                        RECEIPT1 = PLABS.Utils.CnvToSentenceCase(PLABS.Utils.CnvToDouble(dgvDt.Rows[i]["cr"]).ToString("F3"));

                    String USER = PLABS.Utils.CnvToStr(dgvDt.Rows[i]["usr_nam"]);

                    objRptTextCntrl.Gf_AddSeperator();
                    objRptTextCntrl.Gf_DrawText(" " + DATE, RptControl.TextAlign.Left, 10, true);
                    objRptTextCntrl.Gf_DrawText(" " + ITEM, RptControl.TextAlign.Left, 22, true);
                    objRptTextCntrl.Gf_DrawText(" " + WT, RptControl.TextAlign.Right, 8, true);
                    objRptTextCntrl.Gf_DrawText(" " + ISSUE, RptControl.TextAlign.Right, 8, true);
                    objRptTextCntrl.Gf_DrawText(" " + RECEIPT, RptControl.TextAlign.Right, 8, true);
                    objRptTextCntrl.Gf_DrawText(" " + MC, RptControl.TextAlign.Right, 10, true);
                    objRptTextCntrl.Gf_DrawText(" " + MCRATE, RptControl.TextAlign.Right, 8, true);
                    objRptTextCntrl.Gf_DrawText(" " + PAYMENT, RptControl.TextAlign.Right, 12, true);
                    objRptTextCntrl.Gf_DrawText(" " + RECEIPT1, RptControl.TextAlign.Right,12, true);
                    objRptTextCntrl.Gf_DrawText(" " + USER, RptControl.TextAlign.Right, 4, true);
                    

                    objRptTextCntrl.GF_AddNewLine(0);

                    if (i == itemCount - 2)
                    {
                        //objRptTextCntrl.GF_AddNewLine(1);
                        objRptTextCntrl.GF_DrawLine(PAGE_WIDTH);

                    }
                }
                objRptTextCntrl.GF_DrawLine(PAGE_WIDTH);

                #endregion


                #region FOOTER
                //objRptTextCntrl.Gf_AddSeperator();
                //objRptTextCntrl.Gf_DrawText("Weight " + txt_wgt.Text + "                 Cash " + txt_cash.Text, RptControl.TextAlign.Left, PAGE_WIDTH, false);                  
                #endregion



                _printRpt = objRptTextCntrl.GF_GetPrintString();
               
                // DRAFT PRINT
                /*
                String path =  "D:\\Print.txt";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                System.IO.File.WriteAllText(path, _printRpt);
                string mode = "/d:lpt1:";
               

                DraftPrint_cmd(path, mode);

                */

              // USB PRINT
              GetPrinters();
                
            }
            catch (Exception ex)
            {
                PLABS.MessageBoxPL.Show(ex.Message);
            }
        }

        public static void DraftPrint_cmd(String FilePath, String printCmd)
        {


            if (printCmd.ToUpper().StartsWith("LPT"))
                printCmd = "/d:" + printCmd.Replace(":", "").ToUpper().Trim() + ": \"" + FilePath + "\"";
            else
                printCmd = printCmd.ToUpper().Trim() + " " + FilePath;

            System.Diagnostics.Process.Start("Print", printCmd);


        }

        public void GetPrinters()
        {
            try
            {

                _printFont = new Font("lucida console", 8);
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
                pd.Print();
                //pd.Print();//For Sales Order 2 prints required
            }
            catch (Exception ex)
            {
               
            }
        }
        void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawString(_printRpt, _printFont, Brushes.Black, 10, 10);
            }
            catch (Exception ex)
            {
               
            }
        }
        private void LoadControls()
        {
            try
            {

                if (Properties.Settings.Default.id == 4)
                {
                    txt_stat_gv.Visible = true;
                }
                else
                {
                    txt_stat_gv.Visible = false;
                }


                if (!string.IsNullOrEmpty(_date))
                {
                    this.dtp_frm.ControlValue = PLABS.Utils.CnvToDate(_date).ToString("yyyy-MM-dd");
                    this.dtp_to.ControlValue = PLABS.Utils.CnvToDate(_date).ToString("yyyy-MM-dd");
                }
                else
                {
                    this.dtp_frm.ControlValue = DateTime.Now.AddDays(-7).ToString("MMM-dd-yyyy");
                    this.dtp_to.ControlValue = DateTime.Now.ToString("MMM-dd-yyyy");
                }
               
               
                 
              
                   DataSet ds = this.GetDataSet("LO", "", "", "", "");
              
             
               this.fnd_Grup.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_grup_code", "addr_grup_nam", "addr_grup_id");
               this.fnd_addr.LoadData(PLABS.Utils.GetDataTable(ds, 1), "addr_code", "addr_nam", "addr_id");
                if (IdFromFL_003 != "")
                {
                    this.fnd_addr.ControlValue = _idFromFL_003;
                    this.LoadGrid();
                }
                _date = string.Empty;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0002");
            }
        }
        public void LoadGrid()
        {
            try
            {
                this.PopulateGrid();
            }
            catch (Exception ex)
            {

            }
        }
        private void LoadHeadNames()
        {
            String xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LA", this.fnd_Grup.ControlValue, "","",this.fnd_Grup.ControlValue));
            xmlData = this.CallWS(xmlData, "BizObj.FL_002,BizObj", "S");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            this.fnd_addr.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
        }
        private DataSet GetDataSet(String as_mode, String ai_addr_id, String ad_frm, String ad_to, String ai_grp_id)
        {
            try
            {
               
              

                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_addr_id, ad_frm, ad_to, ""));


                xmlData = this.CallWS(xmlData, "BizObj.FL_002,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private String getSelectArgs(String as_mode, String ai_addr_id, String ad_frm, String ad_to,String ai_grp_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                argXml = PLABS.Utils.addNode(argXml, "ad_frm", ad_frm);
                argXml = PLABS.Utils.addNode(argXml, "ad_to", ad_to);
                argXml = PLABS.Utils.addNode(argXml, "ai_grp_id", ai_grp_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id",Properties .Settings .Default .id.ToString ());
                // argXml = PLABS.Utils.addNode(argXml, "ad_from", ad_from);
                //argXml = PLABS.Utils.addNode(argXml, "ad_to", ad_to);
                //argXml = PLABS.Utils.addNode(argXml, "ai_shop_id", ai_shop_id);
                //argXml = PLABS.Utils.addNode(argXml, "ai_wt", ai_wt);
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0010");
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
                //BizObj.FL_002 obj = new BizObj.FL_002();
                //xmlData = obj.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0009");
            }
            return xmlData;
        }
        private void doSave()
        {
            String xmlData = this.getBlankXml();
            xmlData = this.ProcessXml;
            int jnl_lastid = 0;
            int smth_lastid = 0;
            int jnl_fid = 0;
            int smth_fid = 0;
           // xmlData = PLABS.Utils.addNode(xmlData, "ad_frm_dt", dtp_frm.Value.ToString("yyy-MM-dd"));
           // xmlData = PLABS.Utils.addNode(xmlData, "ad_to_dt", dtp_to.Value.ToString("yyy-MM-dd"));
            DataTable dt =(DataTable)(grd_data.DataSource);

            DataRow[] dr = dt.Select("tble='j'");
            if (dr.Length > 0)
            {
                jnl_fid = dr.Min(dr1 => (int)dr1["id"]);
                jnl_lastid = dr.Max(dr1 => (int)dr1["id"]);
            }
          
                dr = dt.Select("tble='s'");
                if (dr.Length > 0)
                {
                smth_fid = dr.Min(dr1 => (int)dr1["dtid"]);
                smth_lastid = dr.Max(dr1 => (int)dr1["dtid"]);
                }

                dt.DefaultView.RowFilter = "stat=0 and tble='j'";
            DataTable jnldt = dt.DefaultView.ToTable(false,"id", "stat");
            dt.DefaultView.RowFilter = "stat=0 and tble='s'";
            DataTable dtsmith = dt.DefaultView.ToTable(false, "dtid", "stat");
            dt.DefaultView.RowFilter = "tble='s'";
            DataTable dtlsId = dt.DefaultView.ToTable(true,"id","dtid");
           
            DataSet ds = new DataSet();
            dtlsId.TableName = "Rslt";
            ds.Tables.Add(dtlsId.Copy());
            ds.DataSetName = "ResultDS";

            xmlData = PLABS.Utils.addNode(xmlData, "as_dtlsIdXml", PLABS.CreateXml.FormatString(PLABS.Utils.CnvDataSetToXml(ds, false)));

             ds = new DataSet();
            jnldt.TableName = "Rslt";
            ds.Tables.Add(jnldt.Copy());
            ds.DataSetName = "ResultDS";

            xmlData = PLABS.Utils.addNode(xmlData,"as_jnlXml",PLABS.CreateXml.FormatString(PLABS.Utils.CnvDataSetToXml(ds, false)));
            ds = new DataSet();
            dtsmith.TableName = "Rslt";
            ds.Tables.Add(dtsmith.Copy());
            ds.DataSetName = "ResultDS";
            xmlData = PLABS.Utils.addNode(xmlData, "as_smthXml", PLABS.CreateXml.FormatString(PLABS.Utils.CnvDataSetToXml(ds, false)));
            xmlData = PLABS.Utils.addNode(xmlData, "ai_jnllastid", PLABS.Utils.CnvToStr(jnl_lastid));
            xmlData = PLABS.Utils.addNode(xmlData, "ai_smthlastid", PLABS.Utils.CnvToStr(smth_lastid));
            xmlData = PLABS.Utils.addNode(xmlData, "ai_jnl_fid", PLABS.Utils.CnvToStr(jnl_fid));
            xmlData = PLABS.Utils.addNode(xmlData, "ai_smth_fid", PLABS.Utils.CnvToStr(smth_fid));
            xmlData = this.CallWS(xmlData, "BizObj.FL_002,BizObj", "LU");
            if (xmlData.Length < 7)
            {
                PLABS.MessageBoxPL.Show("Saved Successfully");
            }
            else
            {
                this.CancelProcess = true;

             }
            
        }
        private void BindGrid()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("stat", typeof(int));
            dt.Columns.Add("item", typeof(string));
            dt.Columns.Add("wt", typeof(double));
            dt.Columns.Add("isswt", typeof(double));
            dt.Columns.Add("recwt", typeof(double));
            dt.Columns.Add("mc", typeof(string));
            dt.Columns.Add("mcrt", typeof(double));
            dt.Columns.Add("dr", typeof(double));
            dt.Columns.Add("cr", typeof(double));
            dt.Columns.Add("desc", typeof(string));
            dt.Columns.Add("bal", typeof(double));
            dt.Columns.Add("cashbal", typeof(double));
            dt.Columns.Add("dtid", typeof(int));
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("tble", typeof(string));
            dt.Columns.Add("usr_nam", typeof(string));
            
            this.grd_data.DataSource = dt;
        }
        private void PopulateGrid()
        {
            try
            {
                double bal = 0.00;
                double cashBal = 0.00;
                double ttlpayment = 0.00;
                double ttlrec = 0.00;
                double opnWt = 0.000;
                double opnAmt = 0.00;

                this.BindGrid();
                DataSet ds = this.GetDataSet("LG", this.fnd_addr.ControlValue,this.dtp_frm.Value.ToString("yyyy-MM-dd"),this.dtp_to.Value.ToString("yyyy-MM-dd"),"");
                DataTable dtOpn = PLABS.Utils.GetDataTable(ds, 0);
                if (dtOpn.Rows.Count > 0)
                {
                    opnWt += PLABS.Utils.CnvToDouble(dtOpn.Rows[0]["grs_wgt"]);
                    opnAmt += PLABS.Utils.CnvToDouble(dtOpn.Rows[0]["amt"]);
                }
               
                DataTable dt = (DataTable)this.grd_data.DataSource;
                DataTable master = PLABS.Utils.GetDataTable(ds, 1);
                DataRow opnRow =master .NewRow ();
                opnRow["date"] = this.dtp_frm.Value.ToString("dd-MMM-yyyy");
                opnRow["grs_wgt"] = opnWt;
                if (opnAmt < 0)
                {
                    opnRow["dr"] = opnAmt;
                }
                else if (opnAmt > 0)
                {
                    opnRow["dr"] = Math.Abs(opnAmt);
                }
                master.Rows.InsertAt(opnRow, 0);
                foreach (DataRow dr in master.Rows)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["date"] = (PLABS.Utils.CnvToDate(dr["date"])).ToString("dd-MMM-yy");
                    newRow["stat"] = dr["stat"];
                    newRow["item"] = dr["name"];
                    newRow["wt"] = dr["prwt"];
                    if (PLABS.Utils.CnvToDouble(dr["grs_wgt"]) > 0)
                    {
                        newRow["isswt"] = PLABS.Utils.CnvToDouble(dr["grs_wgt"]);
                        bal += PLABS.Utils.CnvToDouble(dr["grs_wgt"]);
                    }
                    else if (PLABS.Utils.CnvToDouble(dr["grs_wgt"]) < 0)
                    {
                        newRow["recwt"] = -PLABS.Utils.CnvToDouble(dr["grs_wgt"]);
                        bal += PLABS.Utils.CnvToDouble(dr["grs_wgt"]);
                    }
                    newRow["bal"] = bal;
                    newRow["mc"] = dr["mc"];
                    newRow["mcrt"] = dr["mc_rate"];
                    newRow["dr"] = dr["dr"];
                    newRow["cr"] = dr["cr"];
                    newRow["dtid"] = dr["dtid"];
                    cashBal+=PLABS.Utils.CnvToDouble(dr["dr"]) - PLABS.Utils.CnvToDouble(dr["cr"]);
                    if (cashBal != 0)
                    {
                        newRow["cashbal"] = cashBal;
                    }
                    else
                    {
                        newRow["cashbal"] = DBNull.Value;
                    }
                    newRow["desc"] = dr["descr"];
                    //newRow
                    newRow["id"] = dr["id"];
                    newRow["tble"] = dr["tble"];
                    newRow["usr_nam"] = dr["usr_nam"];


                    dt.Rows.Add(newRow);
                }
                // dt.DefaultView.Sort = "date ASC"; 
                ttlpayment = PLABS.Utils.CnvToDouble(dt.Compute("SUM(dr)", ""));
                ttlrec = PLABS.Utils.CnvToDouble(dt.Compute("SUM(cr)", ""));
                double clsAmt = ttlpayment - ttlrec;
                DataRow clsRow = dt.NewRow();
                clsRow["date"] = "31-Mar-12";
                clsRow["item"] = "CLOSING";
                clsRow["recwt"] = bal;
                clsRow["bal"] = bal;
                clsRow["cr"] = clsAmt;
                clsRow["cashbal"] = cashBal;
                dt.Rows.Add(clsRow);
                this.RemovalOfZeros();

                if (_dtId != string.Empty)
                {
                    this.GetRowFocus();
                }

            }
            catch (Exception ex)
            {
            }
        }
        private void LoadDescription(int rowNum)
        {
            try
            {

            }
            catch
            {

            }
        }
        private void RemovalOfZeros()
        {
            try
            {
                DataTable dt = (DataTable)(grd_data.DataSource);
                for (int i = 0; i < (dt.Rows.Count - 1); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string colName = dt.Columns[j].ColumnName;

                        if (colName == "wt" || colName == "isswt" || colName == "recwt" || colName == "bal" || colName == "mcrt" || colName == "dr" || colName == "cr")
                        {
                            if (PLABS.Utils.CnvToDouble(dt.Rows[i][j]) == 0)
                            {
                                dt.Rows[i][j] = DBNull.Value;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void GetRowFocus()
        {
            try
            {
                DataTable dt = (DataTable)grd_data.DataSource;

                DataRow[] dr = dt.Select(string.Format("dtid='{0}'", _dtId));

                if (dr.Length > 0)
                {
                    this.grd_data.Rows[0].Selected = false;
                    this.grd_data.Rows[dt.Rows.IndexOf(dr[0])].Selected = true ;
                }

            }
            catch (Exception ex)
            {
 
            }
        }
    
        #endregion
    }
}
