using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RoysGold
{
    public partial class TR_004 : PLABS.MasterForm
    {
        #region Global variables
        string _check = "0";
        bool OnLoadFocus = true;
        bool IsLoading = false;
        bool _addrRfrsh = true;
        bool _itmRfrsh = true;
       double  _opnAmt=0.00;
       double  _opnWt=0.00;
        #endregion
        #region Constructor

        public TR_004()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.loadControls();
                this.ExitBeforeClick += new EventHandler(SmithReceipt_ExitBeforeClick);
                this.SaveBeforeClick += new EventHandler(SmithReceipt_SaveBeforeClick);
                this.SaveAfterClick += new EventHandler(SmithReceipt_SaveAfterClick);
                this.DeleteBeforeClick += new EventHandler(SmithReceipt_DeleteBeforeClick);
                this.ClearAfterClick += new EventHandler(SmithReceipt_ClearAfterClick);
                this.fnd_item_id.AfterFind += new EventHandler(fnd_item_id_AfterFind);
                this.txt_grss_wgt.KeyDown += new KeyEventHandler(txt_grss_wgt_KeyDown);
                this.fnd_smth_id.AfterFind += new EventHandler(fnd_smth_id_AfterFind);
                this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
                this.grd_data.CellDoubleClick += new DataGridViewCellEventHandler(grd_data_CellDoubleClick);
                this.txt_mc.KeyDown += new KeyEventHandler(txt_mc_KeyDown);
                this.lst_search.DoubleClick += new EventHandler(lst_search_DoubleClick);
                this.lst_search.KeyDown += new KeyEventHandler(lst_search_KeyDown);
                this.DeleteAfterClick += new EventHandler(TR_004_DeleteAfterClick);
                this.fnd_item_id.Leave += new EventHandler(fnd_item_id_Leave);
                this.fnd_smth_id_F.AfterFind += new EventHandler(fnd_smth_id_F_AfterFind);
                this.btn_itm_ref.Click += new EventHandler(btn_itm_ref_Click);
                this.btn_addrfrsh.Click += new EventHandler(btn_addrfrsh_Click);
                                    
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0001");
            }
            base.OnLoad(e);
        }

      
      
        protected override void OnActivated(EventArgs e)
        {
            if (OnLoadFocus)
            {
                this.fnd_smth_id.Focus();
              
            }
            base.OnActivated(e);
           
        }
        #endregion
        #region Events

        void grd_data_DeleteRowClick(object sender, EventArgs e)
        {
            this.grd_data.ReadOnly = false;
            this.calLables();
        }
        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        void grd_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.GridDoubleClick(e.RowIndex);
            this.calLables();
           
        }
        void SmithReceipt_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.CancelProcess)
                    this.doClear();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsmthissrecmast", "0013");
            }
        }
        void SmithReceipt_DeleteBeforeClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        void SmithReceipt_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsmthissrecmast", "0012");
            }
        }
        void SmithReceipt_SaveBeforeClick(object sender, EventArgs e)
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
                }

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsmthissrecmast", "0011");
            }
        }
        void SmithReceipt_ExitBeforeClick(object sender, EventArgs e)
        {
            this.Close();
        }
        void btn_itm_ref_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (_itmRfrsh)
                {
                    dt = this.RefreshClick("MA", "2",this.fnd_smth_id .ControlValue);
                    _itmRfrsh = false;
                }
                else
                {
                    dt = this.RefreshClick("SM", "2", this.fnd_smth_id.ControlValue);
                    _itmRfrsh = true;
                }
                this.fnd_item_id.LoadData(dt, "itm", "cd", "id");
                this.fnd_item_id.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void fnd_item_id_AfterFind(object sender, EventArgs e)
        {

            try
            {
                this.ItemNameChanged();
            }
            catch (Exception ex)
            {

            }

        }
        void fnd_smth_id_F_AfterFind(object sender, EventArgs e)
        {
            this.smithfind();
        }
        void fnd_item_id_Leave(object sender, EventArgs e)
        
        {
            
            //if (IsLoading)
            //{

                if (this.fnd_item_id.ControlValue == string.Empty)
                {
                    this.btn_save.Focus();
                }
            //}
        }
        void txt_grss_wgt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.IsMcChanged();
                this.addGrid();
            }
        }
        void fnd_smth_id_AfterFind(object sender, EventArgs e)
            {
            try
            {
                this._itmRfrsh = true;
                this.IsLoading = false;
                this.SmithNameChanged();
                this.IsLoading = true;
            }
            catch (Exception ex)
            {

            }

        }
        void txt_mc_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.IsMcChanged();
               // this.addGrid();
            }
        }
        void fnd_item_id_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
        void TR_004_DeleteAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
               
            }
            catch (Exception ex)
            {

            }
        }
        void lst_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    String usrId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[4].Text;
                    if(usrId==PLABS .Utils .CnvToStr (Properties .Settings .Default .id ))
                    {
                        String Key = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
                        if (Key != string.Empty)
                        {
                            //this.masterKey = Key;
                            this.doFind(Key);
                        }
                    }
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
                String usrId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[4].Text;
                if (usrId == PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
                {
                    String Key = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
                    if (Key != string.Empty)
                    {
                        //this.masterKey = Key;
                        this.doFind(Key);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        void btn_addrfrsh_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (_addrRfrsh)
                {
                    dt = this.RefreshClick("SA", "", "");
                    _addrRfrsh = false;
                }
                else
                {
                    dt = this.RefreshClick("ST","2","");
                    _addrRfrsh = true;
                }
                this.fnd_smth_id.LoadData(dt, "cd", "nam", "id");
                this.fnd_smth_id.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Methods

        private void addGrid()
        {
            try
            {
                this.ValueChangedStatus = true;
                double stnWt = 0;
                double itemMc = 0.00;

                DataRow selectedRow = fnd_item_id.SelectedRow;
                int ratioId = PLABS.Utils.CnvToInt(this.ddl_mc_ratio.ControlValue);

                double mc = PLABS.Utils.CnvToDouble(this.txt_mc.Text);
                
                double prty = PLABS.Utils.CnvToDouble(selectedRow["cd"]);
                int itmID = PLABS.Utils.CnvToInt(this.fnd_item_id.ControlValue);


                if (this.txt_stn_wgt.Text != "")
                {
                    stnWt = Convert.ToDouble(this.txt_stn_wgt.Text);
                }
                double grssWt = Convert.ToDouble(this.txt_grss_wgt.Text);
                double netWt = grssWt;

                if (PLABS.Utils.CnvToInt(this.ddl_stn_less.SelectedValue) == 1)
                {
                    netWt = grssWt - stnWt;
                }
                double smithWt = (netWt * prty) / 100;
                Utils objcon = new Utils();
                itemMc = objcon.McCalculation(netWt, ratioId, mc, prty);
                double totalWt = smithWt;
                if (ratioId == 2)
                {
                    totalWt = smithWt + itemMc;
                }
                double mcRate = 0;
                if (!string.IsNullOrEmpty(this.txtMcRate.Text))
                {
                    try
                    {
                        mcRate = Convert.ToDouble(this.txtMcRate.Text);
                    }
                    catch
                    {
                        mcRate = 0;
                    }
                }

                DataTable dt = new DataTable();
                if (grd_data.Rows.Count > 0)
                {
                    dt = (DataTable)grd_data.DataSource;
                }
                else
                {
                    dt = BindGrid();
                }

                DataRow dr = dt.NewRow();
                dr["item"] = PLABS .Utils .CnvToStr (this.fnd_item_id.SelectedCode)+" [ "+PLABS .Utils .CnvToStr(this.fnd_item_id .SelectedDescription)+" ]";
                dr["grss_wght"] = this.txt_grss_wgt.Text;
                dr["net_wt"] = netWt;
                dr["smthWt"] = smithWt;
                dr["makg_chrge"] = PLABS.Utils.CnvToStr(this.txt_mc.Text);
                dr["McRato"] = ratioId.ToString();
                dr["mc_tot"] = itemMc;
                dr["tot_Wt"] = totalWt;
                dr["stne_wgt"] = PLABS.Utils.CnvToDouble(this.txt_stn_wgt.Text);
                dr["stne_lss"] = this.ddl_stn_less.ControlValue;
                dr["stne_csh"] =PLABS .Utils.CnvToDouble (this.txt_stncsh.ControlValue);
                dr["itm_id"] = itmID;
                dr["mc_rate"] =this.ddl_stn_less.ControlValue=="1"?mcRate*netWt:mcRate*grssWt;
                dr["descr"] = this.txt_desc.Text.ToString();
                dt.Rows.Add(dr);

                if (!_itmRfrsh)
                {
                    DataTable dtFnd = this.RefreshClick("SM", "2", this.fnd_smth_id.ControlValue);
                    _itmRfrsh = true;
                    this.fnd_item_id.LoadData(dtFnd, "itm", "cd", "id");
                }

                this.grd_data.DataSource = dt;
                this.calLables();
                this.fnd_smth_id.Enabled = false;
                this.fnd_item_id .ClearControl(true);
                this.ddl_mc_ratio.ClearControl(true);
                this.txt_grss_wgt.ClearControl(true);
                this.txt_mc.ClearControl(true);
                this.txt_stn_wgt.ClearControl(true);
                this.txt_stncsh.ClearControl(true);
                this.ddl_mode.Enabled = false;
                this.txt_desc.ClearControl(true);
                this.txt_grss_wgt.SmartTab =false;
                this.ddl_mc_ratio.ControlValue = "2";
                this.fnd_item_id.Focus();
            }
            catch (Exception ex)
            {

            }


        }
        //private void RefreshClick()
        //{
        //    try
        //    {
        //        this.fnd_item_id.ClearControl(true);
        //        DataSet ds = this.GetDataSet("RI", "", "", "", "");
        //        this.fnd_item_id.LoadData(PLABS.Utils.GetDataTable(ds, 0), "itm_name", "purty", "itm_id");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        private void calLables()
        {
            double grssWt = 0, netWt = 0, smithWt = 0, McWt = 0, TotWt = 0, McTot = 0 ,StneCsh=0;
            double MCVal = 0,ttlMcRt=0;
            DataTable dt = (DataTable)(grd_data.DataSource);

            if (dt.Rows.Count > 0)
            {

                Hashtable ht = Utils.sumofdt(dt);

                //  object netWt1 = dt.Compute("Sum(stne_wgt)", "stne_lss like '"+ "1" + "'");
                smithWt = PLABS.Utils.CnvToDouble(ht["smthWt"]);
                TotWt = PLABS.Utils.CnvToDouble(ht["tot_Wt"]);
                McTot = PLABS.Utils.CnvToDouble(ht["mc_tot"]);
                StneCsh = PLABS.Utils.CnvToDouble(ht["stne_csh"]);
                McWt = TotWt - smithWt;
                MCVal = PLABS.Utils.CnvToDouble(McTot - McWt);
                ttlMcRt = PLABS.Utils.CnvToDouble(ht["mc_rate"]);

                this.txt_grssWt.Text = PLABS.Utils.CnvToDouble(ht["grss_wght"]).ToString("F3");
                this.txt_netWt.Text = PLABS.Utils.CnvToDouble(ht["net_wt"]).ToString("F3");
                this.txt_smthWt.Text = smithWt.ToString("F3");
                this.txt_totWt.Text = TotWt.ToString("F3");
                this.txt_mcGrm.Text = McWt.ToString("F3");
                this.txt_mcAmt.Text = MCVal.ToString("F2");
                this.txt_StneCsh.Text = StneCsh.ToString("F2");
                this.txtTtlMcRt.Text = ttlMcRt.ToString("F2");

                this.OpeningUpdataion();

              

            }
            else
            {

                this.txt_grssWt.ClearControl(true);
                this.txt_netWt.ClearControl(true);
                this.txt_smthWt.ClearControl(true);
                this.txt_totWt.ClearControl(true);
                this.txt_mcGrm.ClearControl(true);
                this.txt_mcAmt.ClearControl(true);

                this.OpeningUpdataion();
            }
              CnvToCurncy obj = new CnvToCurncy();
              this.lbl_smtamtwrd.Text = obj.get(PLABS.Utils.CnvToDouble(this.txt_amount.Text));
              this.lbl_smtmcwrd.Text = obj.get(PLABS.Utils.CnvToDouble(this.txt_mcAmt.Text));
        }
        private DataTable BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("item");
            dt.Columns.Add("grss_wght", typeof(double));
            dt.Columns.Add("net_wt", typeof(double));
            dt.Columns.Add("smthWt", typeof(double));
            dt.Columns.Add("stne_wgt", typeof(double));
            dt.Columns.Add("stne_lss");
            dt.Columns.Add("stne_csh", typeof(double));
            dt.Columns.Add("makg_chrge", typeof(double));
            dt.Columns.Add("McRato");
            dt.Columns.Add("mc_tot", typeof(double));
            dt.Columns.Add("tot_Wt", typeof(double));
            dt.Columns.Add("mc_rate", typeof(double));
            dt.Columns.Add("descr", typeof(string));
            dt.Columns.Add("itm_id");

            return dt;

        }
        private void loadControls()
        {
            try
            {

                DataSet ds = this.GetDataSet("LO", "", "", "", "");

                this.fnd_smth_id.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");

                this.cmb_LoadCombo();
                this.ddl_mc_ratio.LoadData(PLABS.Utils.GetDataTable(ds, 1), "Ratio", "Ratio_id");

                this.ddl_mc_ratio.ControlValue = "2";

                DataTable dt1 = PLABS.Utils.GetDataTable(ds, 1);
                this.ddl_grd_mc_ratio.DataSource = dt1;
                ddl_grd_mc_ratio.DisplayMember = "Ratio";
                ddl_grd_mc_ratio.ValueMember = "Ratio_id";

                //this.ddl_mode.AddRow("Receipt ", 1);
                //this.ddl_mode.AddRow("Receipt Return", 2);
                this.ddl_mode.SelectedValue = 1;

               this.LoadGrid();
               if (this.FindID != string.Empty)
               {
                   this.doFind(this.FindID);
               }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LoadGrid()
        {
            DataSet ds = this.GetDataSet("LG", this.fnd_smth_id_F.ControlValue, "","","");
            this.fnd_smth_id_F.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
            this.lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 1));

        }
        private void cmb_LoadCombo()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("stne");

            DataRow dr = dt.NewRow();
            dr["id"] = 1;
            dr["stne"] = "Yes";

            DataRow dr1 = dt.NewRow();
            dr1["id"] = 0;
            dr1["stne"] = "No";

            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);

            this.ddl_grd_stneless.DataSource = dt;
            ddl_grd_stneless.DisplayMember = "stne";
            ddl_grd_stneless.ValueMember = "id";

            this.ddl_stn_less.LoadData(dt, "stne", "id");
            this.ddl_stn_less.SelectedValue = 1;

            DataTable mode = new DataTable();

            mode.Columns.Add("id");
            mode.Columns.Add("Name");

            mode.Rows.Add("1", "Receipt");
            mode.Rows.Add("2", "Receipt Return");
            this.ddl_mode.LoadData(mode, "Name", "id");
        }
        private void doSave()
        {
            try
            {                        
                string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "ai_is_chkd", this._check);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                xmlData = this.CallWS(xmlData, "BizObj.TR_004,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        // String Key = this.masterKey;
                        this.ValueChangedStatus = false;
                        this.DoClear(this);

                        this.CancelProcess = true;
                    }
                    else
                    {

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
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0005");
            }
        }
        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_tr_smth_issrec_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.TR_004,BizObj", "D");
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
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0006");
            }
        }
        private void doClear()
        {
            try
            {
                this.btn_save.Enabled = true;
                this.txt_grss_wgt.ClearControl(true);
                this.txt_mc.ClearControl(true);
                this.txt_stn_wgt.ClearControl(true);
                //  this.grd_data.ClearControl(true);
                this.ValueChangedStatus = false;
                this.txt_smth_OP.ClearControl(true);
                this.grd_data.ClearControl(true);
                this.fnd_smth_id.Enabled = true;
                this.ddl_mode.Enabled = true;
                this._check = "0";
                this.fnd_smth_id.Focus();
                this.ddl_mc_ratio.ControlValue = "2";
                this.ddl_stn_less.ControlValue = "1";
                this.ddl_mode.ControlValue = "1";
                this.LoadGrid();
                //this.txt_grss_wgt.SmartTab = true;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0007");
            }
        }
        private void doFind(String PrimaryKeyID)
        {
            try
            {
                this.FindID = PrimaryKeyID;
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
                    DataSet ds = this.GetDataSet("SE", "", PrimaryKeyID,"","");
                    DataTable master = ds.Tables[0];
                    DataTable detail = ds.Tables[1];

                    this.fnd_smth_id.SelectedValue = PLABS.Utils.CnvToStr(master.Rows[0]["id"]);

                    //this.txt_desc.ControlValue = PLABS.Utils.CnvToStr(master.Rows[0]["desc"]);
                    this.ddl_mode.SelectedValue = PLABS.Utils.CnvToStr(master.Rows[0]["vmode"]);
                    this.tb_main.SelectedTab = this.tp_create;

                    this.grd_data.DataSource = detail;
                    this.ValueChangedStatus = true;
                    this.SmithNameChanged();
                    //this.txt_code.Focus();
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0004");
            }
        }
        private void doFClear()
        {
        }
        private bool isValidData()
        {
            if (this.grd_data.Rows.Count == 0)
            {
                PLABS.MessageBoxPL.Show("Please Add Items To Grid");
                return false;
            }
            else if (Properties.Settings.Default.id == -1)
            {
                PLABS.MessageBoxPL.Show("Day Closed");
                return false;
            }
            else
            {
                return true;
            }
        }
        private String getSelectArgs(String as_mode, String ai_smth_id, String ai_tr_smth_issrec_id, String ai_item_id, String ai_gld_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_smth_id", ai_smth_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_tr_smth_issrec_id", ai_tr_smth_issrec_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_item_id", ai_item_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_gld_id", ai_gld_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", Properties.Settings.Default.id.ToString());
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
                //BizObj.TR_004 objtrsmthreceipt = new BizObj.TR_004();
                //xmlData = objtrsmthreceipt.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0009");
            }
            return xmlData;
        }
        private void IsMcChanged()
        {
            try
            {
                string mc = string.Empty;
                string newMc = string.Empty;
                newMc = this.txt_mc.Text.Trim();
                DataRow dr = this.fnd_item_id.SelectedRow;
                mc = PLABS.Utils.CnvToStr(dr["mc"]);
                if (mc != newMc)
                {
                    _check = "3";
                }
            }
            catch (Exception ex)
            {
 
            }


        }
        private void SmithNameChanged()
        {
            try
            {
                //this.doClear();                

                DataSet ds = this.GetDataSet("SM", fnd_smth_id.ControlValue, "", "", "");

                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                if (dt.Rows.Count > 0)
                {
                    this.txt_smth_OP.Text = PLABS.Utils.CnvToDouble(dt.Rows[0]["wt"]).ToString ("N3");
                    this.txt_amount.Text = PLABS.Utils.CnvToDouble(ds.Tables[0].Rows[0]["amt"]).ToString("N3");
                    _opnAmt = PLABS.Utils.CnvToDouble(ds.Tables[0].Rows[0]["amt"]);
                    _opnWt = PLABS.Utils.CnvToDouble(dt.Rows[0]["wt"]);
                }
                this.fnd_item_id.LoadData(PLABS.Utils.GetDataTable(ds, 1), "itm", "cd", "id");
                if (ds.Tables[2].Rows.Count > 0)
                {
                    this.rtxt_template.Text = PLABS.Utils.CnvToStr(ds.Tables[2].Rows[0][0]);
                }
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        private DataSet GetDataSet(String as_mode, String ai_smth_id, String ai_tr_smth_issrec_id, String ai_item_id, String ai_gld_id)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_smth_id, ai_tr_smth_issrec_id, ai_item_id, ai_gld_id));
                xmlData = this.CallWS(xmlData, "BizObj.TR_004,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
        private void ItemNameChanged()
        {
            try
            {
                string McRatio = string.Empty;
                string Mc = string.Empty;
                DataRow dr = fnd_item_id.SelectedRow;
                Mc = PLABS.Utils.CnvToStr(dr["mc"]);
                McRatio = PLABS.Utils.CnvToStr(dr["mc_ratio"]);
                this.txt_mc.Text = Mc;
                this.ddl_mc_ratio.SelectedValue = McRatio;

                DataSet ds = this.GetDataSet("GL", fnd_smth_id.ControlValue, "", "", fnd_item_id.ControlValue);
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (PLABS.Utils.CnvToInt(ds.Tables[0].Rows[0][0]) == 0)
                        {
                            this.txt_mc.ReadOnly = true;
                        }
                        else
                        {
                            this.txt_mc.ReadOnly = false;
                        }
                    }
                   
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void smithfind()
        {
            DataSet ds = this.GetDataSet("LG", this.fnd_smth_id_F.ControlValue, "", "", "");
            this.lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 1));
            this.rtxt_template.ControlValue = PLABS.Utils.GetDataTable(ds, 2).Rows[0]["template"].ToString();

        }
        private void GridDoubleClick(int rowNum)
        {
            try
            {
                if (_itmRfrsh)
                {
                   DataTable  dt = this.RefreshClick("MA", "2", this.fnd_smth_id.ControlValue);
                    _itmRfrsh = false;
                    this.fnd_item_id.LoadData(dt, "itm", "cd", "id");
                }
               
                this.fnd_item_id.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["itm_id"].Value);
                this.txt_grss_wgt.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_gv_grssWt"].Value);
                this.txt_stn_wgt.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_gv_stnWt"].Value);
                this.ddl_stn_less.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["ddl_grd_stneless"].Value);
                this.txt_mc.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_gv_makg_chrge"].Value);
                this.ddl_mc_ratio.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["ddl_grd_mc_ratio"].Value);
                this.txt_desc.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_gv_desc"].Value);
                this.txt_stncsh.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_stncsh_grd"].Value);
                this.grd_data.Rows.Remove(grd_data.Rows[rowNum]);              
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private DataTable RefreshClick(String mode, String ai_typ_id, String ai_addr_id)
        {
            DataTable dt = new DataTable();
            try
            {
                //this.fnd_gold_id.ClearControl(true);
                Utils obj = new Utils();
                DataSet ds = obj.GetRefreshTables(mode, ai_typ_id, ai_addr_id);

                return PLABS.Utils.GetDataTable(ds, 0);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        private void OpeningUpdataion()
        {
            try
            {
                if(this.ddl_mode.ControlValue=="1")
                {
                this.txt_smth_OP.Text =( _opnWt-PLABS.Utils.CnvToDouble(this.txt_totWt.Text)).ToString("N3");
                    this.txt_amount.Text =(_opnAmt- PLABS.Utils.CnvToDouble(this.txt_mcAmt.Text)).ToString("N3");
                }
                else if(this.ddl_mode .ControlValue =="2")
                {
                    this.txt_smth_OP.Text = (_opnWt + PLABS.Utils.CnvToDouble(this.txt_totWt.Text)).ToString("N3");
                    this.txt_amount.Text = (_opnAmt + PLABS.Utils.CnvToDouble(this.txt_mcAmt.Text)).ToString("N3");
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
    }
}
