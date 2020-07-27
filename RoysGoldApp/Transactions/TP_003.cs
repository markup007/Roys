using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
    public partial class TP_003 : PLABS.MasterForm
    {
        #region Global variable
        String masterKey = "0";
        bool OnLoadFocus = true;
        bool list = true;
        double _opnAmt = 0.00;
        double _opnWt = 0.00;
        double _opnGldWt = 0.00;
        bool _itmRfrsh = true;

        #endregion
        #region Properties
        #endregion
        #region Constructor
        public TP_003()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {

                this.loadControls();
                //this.KeyPreview = true;
                this.ddl_purchasemode.Focus();
                this.ExitBeforeClick += new EventHandler(trrawpurch_ExitBeforeClick);
                this.SaveBeforeClick += new EventHandler(trrawpurch_SaveBeforeClick);
                this.SaveAfterClick += new EventHandler(trrawpurch_SaveAfterClick);
                this.DeleteBeforeClick += new EventHandler(trrawpurch_DeleteBeforeClick);
                this.DeleteAfterClick += new EventHandler(TP_003_DeleteAfterClick);
                this.ClearAfterClick += new EventHandler(trrawpurch_ClearAfterClick);
                this.txt_rate.KeyDown += new KeyEventHandler(txt_rate_KeyDown);
                this.fnd_gold_id.AfterFind += new EventHandler(fnd_gold_id_AfterFind);
                this.fnd_address.AfterFind += new EventHandler(fnd_address_AfterFind);
                this.lst_search.KeyDown += new KeyEventHandler(lst_search_KeyDown);
                this.lst_search.DoubleClick += new EventHandler(lst_search_DoubleClick);
                this.ddl_purchasemode.SelectedIndexChanged += new EventHandler(ddl_purchasemode_SelectedIndexChanged);
                this.btn_delete.Click += new EventHandler(btn_delete_Click);
                this.fnd_address_F.AfterFind += new EventHandler(fnd_address_F_AfterFind);
                this.btn_refrsh.Click += new EventHandler(btn_refrsh_Click);
                this.txt_rate.TextChanged += new EventHandler(txt_rate_TextChanged);
                this.btn_itmrfrsh.Click += new EventHandler(btn_itmrfrsh_Click);
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0001");
            }
            base.OnLoad(e);
            //this.KeyPreview = false;
        }
        void fnd_address_F_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.loadGrid();
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnActivated(EventArgs e)
        {
            if (OnLoadFocus)
            {
                this.ddl_purchasemode.Focus();
                this.OnLoadFocus = false;
            }

            base.OnActivated(e);
        }
        #endregion
        #region Events

        private void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                this.loadGrid();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0010");
            }
        }

        private void btn_fClear_Click(object sender, EventArgs e)
        {
            //this.ddl_address_F.ClearControl( true );
            //this.txt_invoiceslno_F.ClearControl( true );
        }

        private void trrawpurch_ExitBeforeClick(object sender, EventArgs e)
        {
        }

        private void trrawpurch_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.isValidData())
                {
                    this.CancelProcess = true;

                }
                else
                {
                    this.btn_save.Enabled = false;
                    if (this.FindID != "")
                        this.FindID = this.masterKey;
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trrawpurch", "0011");
            }
        }

        private void trrawpurch_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trrawpurch", "0012");
            }
        }

        private void trrawpurch_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.CancelProcess)
                    this.doClear();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trrawpurch", "0013");
            }
        }

        private void trrawpurch_DeleteBeforeClick(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0014");
            }
        }

        void TP_003_DeleteAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0014");
            }
        }

        private void lst_Search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    String usrId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[6].Text;
                    if(usrId==PLABS .Utils .CnvToStr (Properties .Settings .Default.id))
                    {
                        String Key = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
                        if (Key != string.Empty)
                        {
                            this.masterKey = Key;
                            this.doFind(Key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trrawpurch", "0015");
            }
        }

        private void lst_Search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String usrId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[6].Text;
                if (usrId == PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
                {
                    String Key = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
                    if (Key != string.Empty)
                    {
                        this.masterKey = Key;
                        this.doFind(Key);
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0016");
            }
        }

        void txt_rate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    double ttlrte;
                    double rate = PLABS.Utils.CnvToDouble(this.txt_rate.Text);
                    double wght = PLABS.Utils.CnvToDouble(this.txt_weight.Text);
                    ttlrte = rate * wght;
                    this.txt_ttl_rt.Text = PLABS.Utils.CnvToStr(ttlrte);
                    CnvToCurncy obj = new CnvToCurncy();
                    this.lbl_amtwrd.Text=obj.get(PLABS .Utils .CnvToDouble(this.txt_ttl_rt.Text));
                    this.OpeningUpdation();
                    this.btn_save.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        void fnd_gold_id_AfterFind(object sender, EventArgs e)
        {
            this.GoldChanged();
        }

        void btn_prnt_Click(object sender, EventArgs e)
        {
            string xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("SE", "", "", "", ""));
            xmlData = this.CallWS(xmlData, "BizObj.TP_003,BizObj", "P");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            this.print(ds);
        }

        void fnd_address_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.rtxt_template.Text = string.Empty;
                this.ShopNameChanged();
            }
            catch (Exception ex)
            {

            }


        }
        void ddl_purchasemode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.FindID == "")
                {
                    this.fnd_address.ClearControl(true);
                    this.txt_description.ClearControl(true);
                    this.txt_rate.ClearControl(true);
                    this.txt_ttl_rt.ClearControl(true);
                    this.fnd_gold_id.ClearControl(true);
                    this.txt_weight.ClearControl(true);
                    this.txt_shpopnamt.ClearControl(true);
                    this.txt_shpopnwt.ClearControl(true);
                    this.txt_gld_wt.ClearControl(true);
                    this.fnd_address.Focus();



                    DataTable dt = new DataTable();

                    if (ddl_purchasemode.ControlValue == "3" || ddl_purchasemode.ControlValue == "10")
                    {
                        this.txt_rate.Text = "";
                        this.txt_rate.ReadOnly = false;
                        dt = this.RefreshClick("AA", "", "");

                    }
                    else if (ddl_purchasemode.ControlValue == "8" || ddl_purchasemode.ControlValue == "13")
                    {
                        this.txt_rate.Text = "0.00";
                        this.txt_rate.ReadOnly = true;
                        dt = this.RefreshClick("AT", "", "");
                    }
                    this.fnd_address.LoadData(dt, "cd", "nam", "id");
                }
            }
            catch (Exception ex)
            {

            }
        }
        void lst_search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                 String usrId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[6].Text;
                 if (usrId == PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
                 {

                     String Key = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
                     if (Key != string.Empty)
                     {
                         this.masterKey = Key;
                         this.doFind(Key);
                     }
                 }

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0015");
            }
        }

        void lst_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                     String usrId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[6].Text;
                     if (usrId == PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
                     {
                         String Key = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
                         if (Key != string.Empty)
                         {
                             this.masterKey = Key;
                             this.doFind(Key);
                         }
                     }
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0015");
            }
        }
        void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
                this.loadControls();
            }
            catch (Exception ex)
            {

            }
        }

        void btn_refrsh_Click(object sender, EventArgs e)
        {
            try
            {
                if (list == true)
                {
                    //this.RefreshClick();
                    list = false;
                }
                else
                {
                    DataSet ds = this.GetDataSet("LO", "", "", "", "");
                    this.fnd_address.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
                    list = true;
                }
            }
            catch
            {
            }
        }
        void txt_rate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetRateInWords();
            }
            catch (Exception ex)
            {

            }
        }

        void btn_itmrfrsh_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (_itmRfrsh)
                {
                    dt = this.RefreshClick("D", "","");
                    _itmRfrsh = false;
                }
                else
                {
                    dt = this.RefreshClick("D","1","");
                    _itmRfrsh = true;
                }
                this.fnd_gold_id.LoadData(dt, "nam", "cd", "id");
                this.fnd_gold_id.Focus();
               
            }
            catch (Exception ex)
            {

            }
        }


        #endregion
        #region Methods

        //private void RefreshClick()
        //{
        //    try
        //    {


        //        this.fnd_address.ClearControl(true);
        //        DataSet ds = this.GetDataSet("RC","","","","");
        //        this.fnd_address.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");

        //        //DataSet ds = this.GetDataSet("LO", "", "", "", "");
        //        //this.fnd_address.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        private void loadControls()
        {
            try
            {

                DataSet ds = this.GetDataSet("LO", "", "", "", "");
                this.fnd_address.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");
                this.fnd_gold_id.LoadData(PLABS.Utils.GetDataTable(ds, 1), "nam", "cd", "id");
                this.fnd_address_F.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");

                this.LoadModeCombo();
                this.fnd_address.BringToFront();
                this.txt_rate.ReadOnly = true;
                this.loadGrid();
                if (FindID != string.Empty)
                {
                    this.masterKey = FindID;
                    this.doFind(FindID);
                }

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0002");
            }
        }
        private void loadGrid()
        {
            try
            {
                DataSet ds = this.GetDataSet("LG", this.fnd_address_F.ControlValue, "", "", "");
                lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0003");
            }
        }
        private void doFind(String PrimaryKeyID)
        {
            try
            {
                //	this.btn_saveas.Enabled = true;
                this.CancelProcess = false;
                if (this.ValueChangedStatus)
                {
                    if (PLABS.MessageBoxPL.Show("Values are changed Do You Want To Save?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Question) == PLABS.MessageBoxPL.PLDialogResults.Yes)
                        this.DoSave(this);
                    else
                    {
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                    }
                }
                if (!this.CancelProcess)
                {
                    this.FindID = PrimaryKeyID;
                    string xmlData = this.getBlankXml();
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("SE", "", "", PrimaryKeyID, ""));
                    xmlData = this.CallWS(xmlData, "BizObj.TP_003,BizObj", "S");
                    DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //this.DataSource = xmlData;
                        this.ddl_purchasemode.ControlValue = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["vou_typ_id"]);
                        this.fnd_address.ControlValue = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["addr_id"]);
                        this.txt_description.ControlValue = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["descr"]);
                        this.fnd_gold_id.ControlValue = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["gold_id"]);
                        this.txt_weight.ControlValue = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["wt"]);
                        this.txt_rate.ControlValue = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["rate"]);
                        this.ShopNameChanged();
                        this.GoldChanged();
                        this.tb_rawpuchase.SelectedTab = this.tp_create;
                        this.ValueChangedStatus = true;
                    }
                    this.FindID = PrimaryKeyID;
                    //this.txt_code.Focus();
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trrawpurch", "0004");
            }
        }
        private void doSave()
        {
            try
            {
                
                string xmlData = this.ProcessXml;



                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));

                xmlData = this.CallWS(xmlData, "BizObj.TP_003,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        String Key = this.masterKey;
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                        doFind(Key);
                        this.loadGrid();
                        this.CancelProcess = true;
                    }
                    else
                    {
                        this.loadGrid();
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                        this.CancelProcess = true;
                    }
                }
                else if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.btn_save.Enabled = true;
                    this.doClear();
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0005");
            }
        }
        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_raw_purch_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.TP_003,BizObj", "D");
                if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Deleted Successfully", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    
                    this.doClear();
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0006");
            }
        }
        private void doClear()
        {
            try
            {
                masterKey = "0";
                //this.btn_saveas.Enabled = false;

                this.btn_save.Enabled = true;
                this.txt_rate.ReadOnly = false;
                this.ValueChangedStatus = false;
                this.ddl_purchasemode.ControlValue = "8";
                this.ddl_purchasemode.Focus();
                this.loadGrid();

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0007");
            }
        }
        private void doFClear()
        {
        }
        private bool isValidData()
        {
            if (Properties.Settings.Default.id == -1)
            {
                PLABS.MessageBoxPL.Show("Day Closed");
                return false;
            }
            else
            {
                return true;
            }
        }
        private String getSelectArgs(String as_mode, String ai_addr_id, String ai_invs_slno, String ai_raw_purch_id, String ai_gold_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_invs_slno", ai_invs_slno);
                argXml = PLABS.Utils.addNode(argXml, "ai_raw_purch_id", ai_raw_purch_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_gold_id", ai_gold_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id",Properties .Settings .Default .id.ToString());
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0010");
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
                //BizObj.TP_003 objtrrawpurch = new BizObj.TP_003();
                //xmlData = objtrrawpurch.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0009");
            }
            return xmlData;
        }
        public string header(DataSet ds)
        {

            int len = 79;


            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();

            objRptTextCntr.Gf_DrawText("Roys Gold", RptControl.TextAlign.Center, len, false);
            objRptTextCntr.GF_AddNewLine(0);

            return objRptTextCntr.GF_GetPrintString();


        }
        public void print(DataSet ds)
        {
            int len = 79;
            string header = this.header(ds);

            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();
            objRptTextCntr.GF_DrawLine(len);
            objRptTextCntr.Gf_AddSeperator();
            objRptTextCntr.Gf_DrawText("Purchaser Name", RptControl.TextAlign.Center, 15, true);
            objRptTextCntr.Gf_DrawText("Invoice Slno", RptControl.TextAlign.Center, 12, true);
            objRptTextCntr.Gf_DrawText("Date", RptControl.TextAlign.Center, 13, true);
            objRptTextCntr.Gf_DrawText("Gold", RptControl.TextAlign.Center, 14, true);
            objRptTextCntr.Gf_DrawText("Weight", RptControl.TextAlign.Center, 10, true);
            objRptTextCntr.Gf_DrawText("Rate", RptControl.TextAlign.Center, 10, true);
            objRptTextCntr.GF_AddNewLine(0);
            objRptTextCntr.GF_DrawLine(len);
            int i = 0;
            while (i < ds.Tables[0].Rows.Count)
            {
                objRptTextCntr.Gf_AddSeperator();

                objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["addr_nam"], RptControl.TextAlign.Left, 15, true);
                objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["invs_slno"], RptControl.TextAlign.Left, 12, true);
                objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["date"], RptControl.TextAlign.Left, 13, true);
                objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["itm_name"], RptControl.TextAlign.Left, 14, true);
                objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["wt"], RptControl.TextAlign.Left, 10, true);
                objRptTextCntr.Gf_DrawText(ds.Tables[0].Rows[i]["rate"], RptControl.TextAlign.Left, 10, true);
                objRptTextCntr.GF_AddNewLine(0);

                i++;
            }
            int n = 0;
            while (n < 5)
            {
                objRptTextCntr.Gf_AddSeperator();
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 15, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 13, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 14, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 10, true);
                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 10, true);
                objRptTextCntr.GF_AddNewLine(0);
                n++;
            }
            objRptTextCntr.GF_DrawLine(len);

            report_viewer objrpt = new report_viewer();
            string print = header;
            print += objRptTextCntr.GF_GetPrintString();
            objrpt.Print = print;
            objrpt.ShowDialog();

        }
        public void GoldChanged()
        {
            try
            {
                this.txt_gld_wt.ClearControl(true);
                DataSet ds = this.GetDataSet("G", this.fnd_address.ControlValue, "", "", this.fnd_gold_id.ControlValue);
                if (ds.Tables.Count != 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        this.txt_gld_wt.Text = PLABS.Utils.CnvToDouble(dt.Rows[0]["wt"]).ToString("N3");
                        _opnGldWt = PLABS.Utils.CnvToDouble(dt.Rows[0]["wt"]);
                    }
                    else
                    {
                        this.txt_gld_wt.Text = "0.000";
                        _opnGldWt = 0.00;
                    }

                    //if (ds.Tables[1].Rows.Count != 0)

                    //this.rtxt_template.Text = PLABS.Utils.CnvToStr(ds.Tables[1].Rows[0]["template"]);

                }



            }
            catch (Exception ex)
            {

            }
        }
        public DataSet GetDataSet(String as_mode, String ai_addr_id, String ai_invs_slno, String ai_raw_purch_id, String ai_gold_id)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_addr_id, ai_invs_slno, ai_raw_purch_id, ai_gold_id));
                xmlData = this.CallWS(xmlData, "BizObj.TP_003,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {
            }
            return ds;
        }
        private void LoadModeCombo()
        {
            try
            {

                DataTable dt = new DataTable();

                dt.Columns.Add("id");
                dt.Columns.Add("name");

                dt.Rows.Add(PLABS.Utils.CnvToInt(Enums.VoucherType.RawPurchase), "Capital");
                dt.Rows.Add(PLABS.Utils.CnvToInt(Enums.VoucherType.SalesReceipt), "Weight");
                dt.Rows.Add(PLABS.Utils.CnvToInt(Enums.VoucherType.DirectPurchaseReturn), "Capital Return");
                dt.Rows.Add(PLABS.Utils.CnvToInt(Enums.VoucherType.WeightPurchaseReturn), "Weight Return");

                this.ddl_purchasemode.LoadData(dt, "name", "id");
                ddl_purchasemode.SelectedValue = 8;
            }
            catch (Exception ex)
            {

            }
        }
        private void ShopNameChanged()
        {
            try
            {
                this.txt_shpopnamt.ClearControl(true);
                this.txt_shpopnwt.ClearControl(true);

                DataSet ds = this.GetDataSet("A",this.fnd_address.ControlValue, "", "", "");

                if (ds != null&&ds.Tables[0].Rows.Count>0)
                {
                    double wt = PLABS.Utils.CnvToDouble(ds.Tables[0].Rows[0]["wt"]);
                    double amt = PLABS.Utils.CnvToDouble(ds.Tables[0].Rows[0]["amt"]);

                    this.txt_shpopnamt.Text = amt.ToString("N2");
                    this.txt_shpopnwt.Text = wt.ToString("N3");

                    _opnAmt = amt;
                    _opnWt = wt;
                }

                this.rtxt_template.ControlValue = PLABS.Utils.GetDataTable(ds, 1).Rows[0]["tmplt"].ToString();

            }
            catch (Exception ex)
            {

            }
        }
        private DataTable RefreshClick(String mode, String ai_typ_id, String ai_addr_id)
        {
            DataTable dt = new DataTable();
            try
            {
                this.fnd_gold_id.ClearControl(true);
                Utils obj = new Utils();
                DataSet ds = obj.GetRefreshTables(mode, ai_typ_id, ai_addr_id);

                return PLABS.Utils.GetDataTable(ds, 0);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        private void OpeningUpdation()
        {
            try
            {
                Utils obj = new Utils();
                double wt= PLABS.Utils.CnvToDouble(this.txt_weight.Text);
                wt = obj.PurityConversion(PLABS.Utils.CnvToDouble(this.fnd_gold_id.SelectedRow["cd"]), wt, 100);
                if (ddl_purchasemode.ControlValue == "3" || ddl_purchasemode.ControlValue == "8")
                {
                    this.txt_gld_wt.Text = (_opnGldWt + wt).ToString("N3");
                }
                else
                {
                    this.txt_gld_wt.Text = (_opnGldWt -wt).ToString("N3");
                }
                if (ddl_purchasemode.ControlValue == "3")
                {

                    this.txt_shpopnamt.Text = (_opnAmt - PLABS.Utils.CnvToDouble(this.txt_ttl_rt.Text)).ToString("N2");
                }
                else if (ddl_purchasemode.ControlValue == "8")
                {

                    this.txt_shpopnwt.Text = (_opnWt - wt).ToString("N3");
                }
                else if (ddl_purchasemode.ControlValue == "10")
                {

                    this.txt_shpopnamt.Text = (_opnAmt + PLABS.Utils.CnvToDouble(this.txt_ttl_rt.Text)).ToString("N2");
                }
                else if (ddl_purchasemode.ControlValue == "13")
                {

                    this.txt_shpopnwt.Text = (_opnWt + wt).ToString("N3");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GetRateInWords()
        {
            try
            {
                CnvToCurncy obj = new CnvToCurncy();

                this.lbl_amtwrd.Text = obj.get(PLABS.Utils.CnvToDouble(this.txt_rate.Text));
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}

