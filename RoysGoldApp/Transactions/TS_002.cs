using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
    public partial class TS_002 : PLABS.MasterForm
    {
        #region Global Variables
        String _orderForm = string.Empty;
        String masterKey = "0";
        bool _editmode = true;
        bool _addrRfrsh = true;
        bool _itmRfrsh = true;
        double _opnWt = 0.00;
        double _opnAmt = 0.00;
        #endregion

        #region Properties

        public String OrderForm
        {
            get { return _orderForm; }
            set { _orderForm = value; }
        }

        #endregion

        #region Constructor

        public TS_002()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.loadControls();
                this.ExitBeforeClick += new EventHandler(trsales_ExitBeforeClick);
                this.SaveBeforeClick += new EventHandler(trsales_SaveBeforeClick);
                this.SaveAfterClick += new EventHandler(trsales_SaveAfterClick);
                this.DeleteBeforeClick += new EventHandler(trsales_DeleteBeforeClick);
                this.ClearAfterClick += new EventHandler(trsales_ClearAfterClick);
                this.grd_data.CellLeave += new DataGridViewCellEventHandler(grd_data_CellLeave);
                this.lnklbl_odrfrm.Click += new EventHandler(lnklbl_odrfrm_Click);
                this.grd_data.DoubleClick += new EventHandler(grd_data_DoubleClick);
                this.btn_sho_refrsh.Click += new EventHandler(btn_sho_refrsh_Click);
                this.btn_itm_ref.Click += new EventHandler(btn_itm_ref_Click);
                this.fnd_address.AfterFind += new EventHandler(fnd_address_AfterFind);
                this.fnd_item_id.AfterFind += new EventHandler(fnd_item_id_AfterFind);
                this.txt_grsswgt.KeyDown += new KeyEventHandler(txt_grsswgt_KeyDown);
                this.grd_data.DoubleClick += new EventHandler(grd_data_DoubleClick);
                this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
                this.fnd_item_id.Leave += new EventHandler(fnd_item_id_Leave);
                this.lst_search.DoubleClick += new EventHandler(lst_search_DoubleClick);
                this.lst_search.KeyDown += new KeyEventHandler(lst_search_KeyDown);
                this.DeleteBeforeClick += new EventHandler(TS_002_DeleteBeforeClick);
                this.DeleteAfterClick += new EventHandler(TS_002_DeleteAfterClick);
                this.ddl_mode.SelectedIndexChanged += new EventHandler(ddl_mode_SelectedIndexChanged);
                this.txt_brdrt.KeyDown += new KeyEventHandler(txt_brdrt_KeyDown);
                this.grd_data.RowsRemoved += new DataGridViewRowsRemovedEventHandler(grd_data_RowsRemoved);
                this.txt_roundoff.KeyDown += new KeyEventHandler(txt_roundoff_KeyDown);
                this.txt_cessratio.KeyDown += new KeyEventHandler(txt_cessratio_KeyDown);
                this.txt_taxratio.KeyDown += new KeyEventHandler(txt_taxratio_KeyDown);
                this.txt_brdrt.GotFocus += new EventHandler(txt_brdrt_GotFocus);
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0001");
            }
            base.OnLoad(e);
        }

       
        protected override void OnActivated(EventArgs e)
        {
            this.ddl_mode.Focus();
            base.OnActivated(e);
        }




        //void txt_stnwgt_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            if (ValidationForAddGrid())
        //                this.AddGrid();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }  
        //}



        #endregion

        #region Events
        //Button Click
        private void btn_fClear_Click(object sender, EventArgs e)
        {
            //this.ddl_shopname_F.ClearControl( true );
        }
        private void trsales_ExitBeforeClick(object sender, EventArgs e)
        {
        }
        private void trsales_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.isValidData())
                    this.CancelProcess = true;
                else
                {
                    this.btn_save.Enabled = false;
                    if (this.FindID != "")
                        this.FindID = this.masterKey;
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsales", "0011");
            }
        }
        private void trsales_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsales", "0012");
            }
        }
        private void trsales_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.CancelProcess)
                    this.doClear();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsales", "0013");
            }
        }
        private void trsales_DeleteBeforeClick(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0014");
            }
        }
        void TS_002_DeleteAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
              
            }
            catch (Exception ex)
            {

            }
        }
        void TS_002_DeleteBeforeClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        void btn_itm_ref_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (_itmRfrsh)
                {
                    dt = this.RefreshClick("SA", "2", this.fnd_address.ControlValue);
                    _itmRfrsh = false;
                }
                else
                {
                    dt = this.RefreshClick("SH", "2", this.fnd_address.ControlValue);
                    _itmRfrsh = true;
                }
                this.fnd_item_id.LoadData(dt, "itm", "cd", "id");
                this.fnd_item_id.Focus();
                this.txt_mc.Text = "0";
                txt_mcrate.Text = "0";
            }
            catch (Exception ex)
            {

            }
        }
        void btn_sho_refrsh_Click(object sender, EventArgs e)
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
                    dt = this.RefreshClick("ST", "1", "");
                    _addrRfrsh = true;
                }
                this.fnd_address.LoadData(dt, "cd", "nam", "id");
                this.fnd_address.Focus();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //After Find
        void fnd_address_AfterFind(object sender, EventArgs e)
        {
            try
            {
                _itmRfrsh = true;
                this.ShopNameChanged();
            }
            catch (Exception ex)
            {

            }
        }
        void fnd_item_id_AfterFind(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = this.GetDataSet("LM", this.fnd_item_id.ControlValue, this.fnd_address.ControlValue, "");
                this.txt_mc.Text = PLABS.Utils.CnvToStr(ds.Tables[0].Rows[0]["mc"]);
                this.ddl_ratio.SelectedValue = PLABS.Utils.CnvToStr(ds.Tables[0].Rows[0]["mc_ratio"]);
                this.txt_mcrate.Text = PLABS.Utils.CnvToStr(ds.Tables[0].Rows[0]["mc_rate"]);
                if (PLABS.Utils.CnvToInt(ds.Tables[0].Rows[0]["salesmode"]) == 1)
                {
                    this.txt_brdrt.ReadOnly = false;
                    //this.salemode = "1";
                    if(this.ddl_mode.ControlValue!="4")
                    {
                    this.ddl_mode.ControlValue = "1";
                    }
                    lbl_trasmode.Text = "Weight To Cash Transaction";
                }
                else
                {
                    this.txt_brdrt.ReadOnly = true;
                    //this.salemode = "2";
                    if (this.ddl_mode.ControlValue != "4")
                    {
                        this.ddl_mode.ControlValue = "2";
                    }
                    this.lbl_trasmode.Text = "Weight To Weight Transaction";
                }
            }
            catch (Exception ex)
            {

            }


        }
        void ddl_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ModeChanged();
            }
            catch (Exception ex)
            {

            }
        }
        //Grid Events
        void grd_data_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.CellLeave(e.ColumnIndex, e.RowIndex);
            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_editmode)
                {
                    this.GridDoubleClick(this.grd_data.CurrentRow.Index);
                    _editmode = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //void grd_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        string colName = grd_data.Columns[e.ColumnIndex].HeaderText;

        //        if (colName == "Item")
        //        {
        //            string item = PLABS.Utils.CnvToStr(grd_data.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
        //            int length = (item.Length) - 4;
        //            string gold = "Gold" + item.Substring(length);
        //            grd_data.Rows[e.RowIndex].Cells["ddl_gold_id"].Value = gold;
        //            string xmlData = this.getBlankXml();
        //            xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LI", _itemid, "", ""));
        //            xmlData = this.CallWS(xmlData, "BizObj.TS_002,BizObj", "S");
        //            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);




        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        void grd_data_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.TotalCalculation();
                this.GrandTotalCalculation();
            }
            catch (Exception ex)
            {

            }
        }
        //Key Events
        void txt_grsswgt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidationForAddGrid())
                {
                    this.AddGrid();
                    this.GrandTotalCalculation();
                }
            }
        }
        void txt_taxratio_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GrandTotalCalculation();
                }
            }
            catch (Exception ex)
            {

            }
        }
        void txt_cessratio_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GrandTotalCalculation();
                }
            }
            catch (Exception ex)
            {

            }
        }
        //void txt_touch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            if (ValidationForAddGrid())
        //                this.AddGrid();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //void txt_mc_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            if (ValidationForAddGrid())
        //                this.AddGrid();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        void lst_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                      String usrId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[5].Text;
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

            }
        }
        void lst_search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                  String usrId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[5].Text;
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

            }
        }
        void txt_roundoff_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.RoundOff();
                    this.btn_save.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }
        void txt_brdrt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GrandTotalCalculation();

                }
            }
            catch (Exception ex)
            {

            }
        }
        //Others
        void fnd_item_id_Leave(object sender, EventArgs e)
        {
            try
            {
                if (fnd_item_id.ControlValue == string.Empty)
                {
                    this.btn_save.Focus();
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        void lnklbl_odrfrm_Click(object sender, EventArgs e)
        {
            if (this.fnd_address.ControlValue == "")
            {
                PLABS.MessageBoxPL.Show("Make Sure The Shop Name Is Correct");
            }
            else
            {
                CO_001 objordrfrm = new CO_001();

                objordrfrm.Shpid = PLABS.Utils.CnvToInt(this.fnd_address.ControlValue);
                objordrfrm.ShowDialog();
                this.OrderForm = objordrfrm.GrdData;
            }

        }
        void txt_brdrt_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (this.ddl_mode.ControlValue == "1")
                {
                    this.txt_brdrt.ReadOnly = false;
                }
                else if (this.ddl_mode.ControlValue == "2" || this.ddl_mode.ControlValue == "4")
                {
                    this.txt_brdrt.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        #endregion

        #region Methods

        private void loadControls()
        {
            try
            {

                DataSet ds = this.GetDataSet("LO", "", "", "");

                // common cmb

                this.fnd_address.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");
                this.fnd_smth_id_F.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");

                this.ddl_ratio.LoadData(PLABS.Utils.GetDataTable(ds, 1), "name", "id");
                this.ddl_ratio.ControlValue = "2";


                this.ddl_stnless.AddRow("Yes", 1);
                this.ddl_stnless.AddRow("No", 0);

                this.LoadModeCombo();
                this.ddl_stnless.ControlValue = "1";

                //gridview cmb

                this.ddl_mc_ratio_gv.DataSource = PLABS.Utils.GetDataTable(ds, 1);
                this.ddl_mc_ratio_gv.DisplayMember = "name";
                this.ddl_mc_ratio_gv.ValueMember = "id";

                DataTable dt = new DataTable();

                dt.Columns.Add("id");
                dt.Columns.Add("name");
                dt.Rows.Add("1", "Yes");
                dt.Rows.Add("0", "No");
                this.ddl_stne_less_gv.DataSource = dt;
                this.ddl_stne_less_gv.DisplayMember = "name";
                this.ddl_stne_less_gv.ValueMember = "id";
                this.ddl_brdrt.ControlValue = "99.5";
                //this.PopulateStnLess();

                this.LoadGrid();

                if (this.FindID != string.Empty)
                {
                    this.masterKey = FindID;
                    this.doFind(FindID);
                }



            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0002");
            }
        }
        private void LoadGrid()
        {
            DataSet ds = this.GetDataSet("LG", this.fnd_smth_id_F.ControlValue, "", "");
            this.lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));

        }
        //private void RefreshClick(String ID)
        //{
        //    try
        //    {
        //        if (ID == "S")
        //        {
        //            this.fnd_address.ClearControl(true);
        //            DataSet ds = this.GetDataSet("RS", "", "", "");
        //            this.fnd_address.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
        //        }
        //        else if (ID == "I")
        //        {
        //            this.fnd_item_id.ClearControl(true);
        //            DataSet ds = this.GetDataSet("RI", "", "", "");
        //            this.fnd_item_id.LoadData(PLABS.Utils.GetDataTable(ds, 0), "itm_name", "Gold", "itm_id");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;
               
                string ai_vou_type = (PLABS.Utils.CnvToStr(PLABS.Utils.CnvToInt(Enums.VoucherType.Sales)));
                if (this.ddl_mode.ControlValue == "4")
                {
                    ai_vou_type = (PLABS.Utils.CnvToStr(PLABS.Utils.CnvToInt(Enums.VoucherType.SalesReturn)));
                }
              
                xmlData = PLABS.Utils.addNode(xmlData, "ai_sales_mode", this.ddl_mode.ControlValue);
              
                if (this.OrderForm != "")
                {
                    xmlData = PLABS.Utils.addNode(xmlData, "as_orderform", PLABS.CreateXml.FormatString(this.OrderForm));
                }
                else
                {
                    xmlData = PLABS.Utils.addNode(xmlData, "as_orderform", "");
                }

                xmlData = PLABS.Utils.addNode(xmlData, "ai_vou_type", ai_vou_type);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));

                xmlData = this.CallWS(xmlData, "BizObj.TS_002,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        String Key = this.masterKey;
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
                //ErrorLog.Insert(ex.Message, "trsales", "0005");
            }
        }
        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_sales_mast_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.TS_002,BizObj", "D");
                if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Deleted Successfully", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    //this.loadGrid();
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
                //ErrorLog.Insert(ex.Message, "trsales", "0006");
            }
        }
        private void doClear()
        {
            try
            {
                masterKey = "0";
                this.btn_save.Enabled = true;
                //this.btn_saveas.Enabled = false;
                //this.txt_amount.Focus();
                this.grd_data.ClearControl(true);

                this.fnd_address.Enabled = true;

                this.txt_brdrt.ReadOnly = false;
                this.ValueChangedStatus = false;
                this.lbl_NetWt.ClearControl(true);
                this.lbl_ttlCashMc.ClearControl(true);
                this.lbl_ttlmcrate.ClearControl(true);
                this.lbl_ttlrate.ClearControl(true);
                this.lbl_ttWt.ClearControl(true);
                this.ddl_mode.Enabled = true;
                this.lbl_ttlWtMc.ClearControl(true);
                this.ddl_stnless.ControlValue = "0";
                this.ddl_mode.ControlValue = "2";
                this.ddl_ratio.ControlValue = "2";
                this.ddl_stnless.ControlValue = "1";
                this.txt_brdrtpercent.ControlValue = "1";
                this.ddl_brdrt.ControlValue = "99.5";
                this.ddl_mode.Focus();
                this._editmode = true;
                this.LoadGrid();


            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0007");
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
                    DataSet ds = this.GetDataSet("SE", PrimaryKeyID, "", "");
                    DataTable master = ds.Tables[0];
                    DataTable detail = ds.Tables[1];

                    this.fnd_address.SelectedValue = PLABS.Utils.CnvToStr(master.Rows[0]["smth_id"]);
                    this.ddl_mode.ControlValue = PLABS.Utils.CnvToStr(master.Rows[0]["salesMode"]);
                    this.txt_brdrt.ControlValue = PLABS.Utils.CnvToStr(master.Rows[0]["brd_rt"]);
                    this.txt_taxratio.Text = PLABS.Utils.CnvToStr(master.Rows[0]["txrtio"]);
                    this.txt_cessratio.Text = PLABS.Utils.CnvToStr(master.Rows[0]["csrtio"]);
                    //this.txt_description.Text = PLABS.Utils.CnvToStr(master.Rows[0]["desc"]);
                    this.tab_main.SelectedTab = this.tb_create;

                    this.BindGrid();
                    foreach (DataRow dr in detail.Rows)
                    {
                        DataTable dt = (DataTable)this.grd_data.DataSource;
                        DataRow newRow = dt.NewRow();
                        newRow["Item_id"] = dr["imId"];
                        newRow["item"] = dr["im"];
                        newRow["gold"] = "Gold" + PLABS.Utils.CnvToStr(dr["gld"]);
                        newRow["grs_wgt"] = dr["gw"];
                        newRow["stne_wgt"] = dr["sw"];
                        newRow["stne_less"] = PLABS.Utils.CnvToStr(dr["sl"]);
                        newRow["net_wt"] = dr["nw"];
                        newRow["mc"] = dr["mc"];
                        newRow["mc_ratio"] = PLABS.Utils.CnvToStr(dr["mcr"]);
                        newRow["mcrate"] = dr["mcrt"];
                        newRow["ttlmcrate"] = dr["tmcrt"];
                        newRow["mcttl"] = dr["tmcw"];
                        newRow["ttlwt"] = dr["tw"];
                        newRow["purewt"] = (PLABS.Utils.CnvToDouble(dr["nw"]) * PLABS.Utils.CnvToDouble(dr["gld"])) / 100;
                        newRow["desc"] = dr["descr"];
                        if (PLABS.Utils.CnvToStr(this.txt_brdrt.Text) != string.Empty)
                        {
                            newRow["rate"] = this.BoardRateCalculation() * PLABS.Utils.CnvToDouble(newRow["purewt"]);
                        }

                        dt.Rows.Add(newRow);
                    }
                    this.TotalCalculation();
                    this.GrandTotalCalculation();
                    this.ValueChangedStatus = true;
                    //this.txt_code.Focus();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
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
        private String getSelectArgs(String as_mode, String ai_sales_mast_id, String ai_shop_id, String ai_wt)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_sales_mast_id", ai_sales_mast_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_shop_id", ai_shop_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_wt", ai_wt);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", Properties.Settings.Default.id.ToString());
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
                //BizObj.TS_002 objtrsales = new BizObj.TS_002();
                //xmlData = objtrsales.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0009");
            }
            return xmlData;
        }
        private void PopulateStnLess()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("name");

            DataRow dr = dt.NewRow();

            dr["id"] = "Y";
            dr["name"] = "Yes";

            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();

            dr1["id"] = "N";
            dr1["name"] = "No";

            dt.Rows.Add(dr1);

            this.ddl_stne_less_gv.DataSource = dt;
            this.ddl_stne_less_gv.ValueMember = "id";
            this.ddl_stne_less_gv.DisplayMember = "name";



        }
        private void CellLeave(int colIndex, int rowIndex)
        {
            try
            {
                double mc = 0.00;
                double ttlmc;
                string colName = grd_data.Columns[colIndex].HeaderText;

                if (colName == "Gross Weight" || colName == "Stone Weignt" || colName == "Stone Less")
                {
                    if (this.txt_brdrt.Text != string.Empty)
                    {
                        // Code For NetWt Calculation On The Basic Of Conditions
                        double netwt = 0.00;
                        double stnwt = 0.00;
                        double grosswt = 0.00;
                        double brdrt = PLABS.Utils.CnvToDouble(this.txt_brdrt.Text);
                        grosswt = Convert.ToDouble(this.grd_data.Rows[rowIndex].Cells["txt_grs_wgt_gv"].Value);
                        stnwt = Convert.ToDouble(this.grd_data.Rows[rowIndex].Cells["txt_stne_wgt_gv"].Value);
                        string isless = this.grd_data.Rows[rowIndex].Cells["ddl_stne_less_gv"].EditedFormattedValue.ToString();
                        switch (isless)
                        {
                            case "Yes":
                                netwt = grosswt - stnwt;
                                break;
                            case "No":
                                netwt = grosswt;
                                break;

                        }
                        grd_data.Rows[rowIndex].Cells["ddl_netwt"].Value = netwt;


                        //Code For Mc And McRatio Calculation And Populate It to Grid

                        string itemId = this.grd_data.Rows[rowIndex].Cells["cmb_itm_id"].Value.ToString();
                        string shopid = this.fnd_address.ControlValue;

                        DataSet ds = this.GetDataSet("LM", itemId, shopid, netwt.ToString("N3"));
                        if (ds.Tables.Count != 0)
                        {
                            DataTable dt = ds.Tables[0];
                            this.grd_data.Rows[rowIndex].Cells["txt_mc_gv"].Value = dt.Rows[0][0].ToString();
                            this.grd_data.Rows[rowIndex].Cells["ddl_mc_ratio_gv"].Value = dt.Rows[0][1].ToString();
                            mc = PLABS.Utils.CnvToDouble(dt.Rows[0][0].ToString());
                        }
                        double rate = (netwt * brdrt) + mc;

                        this.grd_data.Rows[rowIndex].Cells["txt_rate_gv"].Value = rate;

                    }
                    else
                    {
                        PLABS.MessageBoxPL.Show("Please Enter Board Rate");
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        private DataSet GetDataSet(String as_mode, String itemId, String shopId, String netWt)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, itemId, shopId, netWt));
                xmlData = this.CallWS(xmlData, "BizObj.TS_002,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private bool ValidationForAddGrid()
        {
            try
            {
                if (this.ddl_mode.ControlValue == string.Empty)
                {
                    PLABS.MessageBoxPL.Show("Please Select A Mode");
                    this.ddl_mode.Focus();
                    return false;
                }
                else if (this.fnd_address.ControlValue == string.Empty)
                {
                    PLABS.MessageBoxPL.Show("Please Select A Shop");
                    this.fnd_address.Focus();
                    return false;
                }


                else if (this.fnd_item_id.ControlValue == string.Empty)
                {
                    PLABS.MessageBoxPL.Show("Please Select An Item");
                    this.fnd_item_id.Focus();
                    return false;
                }
                else if (this.txt_grsswgt.Text.Trim() == string.Empty)
                {
                    PLABS.MessageBoxPL.Show("Please Enter Gross Weight");
                    this.txt_grsswgt.Focus();
                    return false;
                }
                else if (this.txt_mc.Text.Trim() == string.Empty)
                {
                    PLABS.MessageBoxPL.Show("Please Enter Mc");
                    this.txt_mc.Focus();
                    return false;
                }
                //else if (this.txt_stncsh.Text.Trim() == string.Empty)
                //{
                //    PLABS.MessageBoxPL.Show("Please Enter Stone Cash");
                //    this.txt_stncsh.Focus();
                //    return false;
                //}
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        private void AddGrid()
        {
            try
            {
                string itemId = this.fnd_item_id.ControlValue;
                string item = this.fnd_item_id.SelectedCode;
                string gold = "Gold " + PLABS.Utils.CnvToStr(this.fnd_item_id.SelectedDescription);
                double purity = PLABS.Utils.CnvToDouble(this.fnd_item_id.SelectedDescription);
                double grs_wgt = PLABS.Utils.CnvToDouble(this.txt_grsswgt.Text);
                double stn_wgt = PLABS.Utils.CnvToDouble(this.txt_stnwgt.Text);
                double net_wt = grs_wgt;
                double mc = PLABS.Utils.CnvToDouble(this.txt_mc.Text);
                double ttlwt = 0.00;
                double ttlrt = PLABS.Utils.CnvToDouble(this.txt_brdrt.Text);
                double touch = PLABS.Utils.CnvToDouble(this.txt_mcrate.Text);



                if (this.txt_stnwgt.Text != string.Empty)
                {
                    if (this.ddl_stnless.ControlValue == "1")
                        net_wt = grs_wgt - stn_wgt;
                }
                Utils objutils = new Utils();

                double mcttl = objutils.McCalculation(net_wt, PLABS.Utils.CnvToInt(this.ddl_ratio.SelectedValue), mc, purity);
                ttlwt = net_wt;
                if (this.ddl_ratio.ControlValue == "2")
                {
                    ttlwt = objutils.PurityConversion(purity, ttlwt, 100) + mcttl;
                    ttlrt = ttlwt * ttlrt;
                }
                else
                {
                    ttlwt = objutils.PurityConversion(purity, ttlwt, 100);
                    ttlrt = (ttlwt * ttlrt) + mcttl;
                }
                if (grd_data.Rows.Count == 0)
                {

                    this.BindGrid();

                }

                DataTable dt = (DataTable)(this.grd_data.DataSource);

                DataRow dr = dt.NewRow();

                dr["Item_id"] = itemId;
                dr["item"] = item;
                dr["gold"] = gold;
                dr["grs_wgt"] = PLABS.Utils.CnvToDouble(this.txt_grsswgt.Text);
                dr["stne_wgt"] = PLABS.Utils.CnvToDouble(this.txt_stnwgt.Text);
                dr["stne_less"] = this.ddl_stnless.ControlValue;
                dr["net_wt"] = net_wt;
                dr["purewt"] = objutils.PurityConversion(purity, net_wt, 100);
                dr["mc"] = mc;
                dr["mc_ratio"] = this.ddl_ratio.ControlValue;
                dr["mcttl"] = (mcttl).ToString("N3");
                dr["ttlwt"] = (ttlwt).ToString("N3");
                dr["rate"] = (((objutils.PurityConversion(purity, net_wt, 100) * 100) / 99.5) * (PLABS.Utils.CnvToDouble(this.txt_brdrt.Text))).ToString("N2");
                dr["mcrate"] = (touch).ToString("N2");
                dr["ttlmcrate"] = (touch * net_wt);
                dr["stne_csh"] =PLABS.Utils .CnvToDouble(this.txt_stncsh.Text);
                dr["desc"] = this.txt_description.Text.ToString();


                dt.Rows.Add(dr);
                this.TotalCalculation();
                // this.grd_data.DataSource = dt;



                if (!_itmRfrsh)
                {
                    DataTable dtItm = this.RefreshClick("SH", "2", this.fnd_address.ControlValue);
                    _itmRfrsh = true;
                    this.fnd_item_id.LoadData(dtItm, "itm", "cd", "id");
                }

                this.fnd_address.Focus();
                this.fnd_address.Enabled = false;

                //this.txt_brdrt.ReadOnly = true;
                this.fnd_item_id.ClearControl(true);
                this.txt_grsswgt.ClearControl(true);
                this.txt_stnwgt.ClearControl(true);
                this.txt_stncsh.ClearControl(true);
                this.txt_mc.ClearControl(true);
                this.txt_mcrate.ClearControl(true);
                this.ddl_mode.Enabled = false;
                this._editmode = true;
                this.txt_grsswgt.SmartTab = false;
                this.txt_description.ClearControl(true);
                this.ddl_stnless.ControlValue = "1";
                this.ddl_ratio.ControlValue = "2";
                this.fnd_item_id.Focus();

            }
            catch (Exception ex)
            {

            }


        }
        private void BindGrid()
        {
            try
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("Item_id");
                dt.Columns.Add("item");
                dt.Columns.Add("gold");
                dt.Columns.Add("grs_wgt");
                dt.Columns.Add("stne_wgt");
                dt.Columns.Add("stne_less", typeof(string));
                dt.Columns.Add("net_wt", typeof(double));
                dt.Columns.Add("mc", typeof(double));
                dt.Columns.Add("mc_ratio", typeof(string));
                dt.Columns.Add("mcttl", typeof(double));
                dt.Columns.Add("ttlwt", typeof(double));
                dt.Columns.Add("rate", typeof(double));
                dt.Columns.Add("mcrate", typeof(double));
                dt.Columns.Add("ttlmcrate", typeof(double));
                dt.Columns.Add("stne_csh", typeof(double));
                dt.Columns.Add("purewt", typeof(double));
                dt.Columns.Add("desc", typeof(string));

                this.grd_data.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
        }
        private void GridDoubleClick(int rowNum)
        {
            try
            {
                if (_itmRfrsh)
                {
                    DataTable dt = this.RefreshClick("SA", "", this.fnd_address.ControlValue);
                    _itmRfrsh = false;
                    this.fnd_item_id.LoadData(dt, "itm", "cd", "id");
                }


                this.fnd_item_id.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_Item_id_gv"].Value);
                this.txt_grsswgt.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_grs_wgt_gv"].Value);
                this.txt_stnwgt.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_stne_wgt_gv"].Value);
                this.ddl_stnless.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["ddl_stne_less_gv"].Value);
                this.txt_mc.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_mc_gv"].Value);
                this.ddl_ratio.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["ddl_mc_ratio_gv"].Value);
                this.txt_mcrate.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_touch_gv"].Value);
                this.txt_description.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_desc"].Value);
                this.txt_stncsh.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_stncsh_gv"].Value);
                this.grd_data.Rows.RemoveAt(rowNum);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void TotalCalculation()
        {
            try
            {
                DataTable dt = (DataTable)this.grd_data.DataSource;
                double netWt = PLABS.Utils.CnvToDouble(dt.Compute("sum(net_wt)", ""));
                double ttlTchMc = PLABS.Utils.CnvToDouble(dt.Compute("sum(mcttl)", "mc_ratio='2'"));
                double ttlCashMc = PLABS.Utils.CnvToDouble(dt.Compute("sum(mcttl)", "mc_ratio<>'2'"));
                double ttlWt = PLABS.Utils.CnvToDouble(dt.Compute("sum(ttlwt)", ""));
                double ttlMcRate = PLABS.Utils.CnvToDouble(dt.Compute("sum(ttlmcrate)", ""));
                double ttlRate = PLABS.Utils.CnvToDouble(dt.Compute("sum(rate)", ""));
                double ttlPureWt = PLABS.Utils.CnvToDouble(dt.Compute("sum(purewt)", ""));
                double ttlStnCsh = PLABS.Utils.CnvToDouble(dt.Compute("sum(stne_csh)", ""));
                this.lbl_NetWt.Text = netWt.ToString("F3");
                this.lbl_ttlWtMc.Text = ttlTchMc.ToString("F3");
                this.lbl_ttlCashMc.Text = ttlCashMc.ToString("F3");
                this.lbl_ttWt.Text = ttlWt.ToString("F3");
                this.lbl_ttlmcrate.Text = ttlMcRate.ToString("F2");
                this.lbl_ttlrate.Text = ttlRate.ToString("F3");
                this.lbl_purewt.Text = ttlPureWt.ToString("F3");
                this.lbl_stncsh.Text = ttlStnCsh.ToString("F2");

            }
            catch (Exception ex)
            {

            }
        }   //For Labels lbl_ttlmcrate
        private void ModeChanged()
        {
            try
            {
                if (ddl_mode.ControlValue == "3")
                {
                    this.txt_taxratio.Text = "2";
                    this.txt_cessratio.Text = "0";
                    //this.txt_brdrt.ReadOnly = false;
                    //this.txt_taxratio.ReadOnly = false;
                    this.txt_cessratio.ReadOnly = false;
                }
                else if (ddl_mode.ControlValue == "1")
                {
                    this.txt_taxratio.Text = "4";
                    this.txt_cessratio.Text = "1";
                    //this.txt_brdrt.ReadOnly = false;
                    this.txt_taxratio.ReadOnly = false;
                    this.txt_cessratio.ReadOnly = false;
                }
                else if (ddl_mode.ControlValue == "2")
                {
                    this.txt_taxratio.ClearControl(true);
                    this.txt_cessratio.ClearControl(true);
                    //this.txt_brdrt.ReadOnly = true;
                    //this.txt_taxratio.ReadOnly = true;
                    this.txt_brdrt.ClearControl(true);
                    this.txt_cessratio.ReadOnly = true;
                }
                else if (ddl_mode.ControlValue == "4")
                {
                    this.txt_taxratio.ClearControl(true);
                    this.txt_cessratio.ClearControl(true);
                    //this.txt_brdrt.ReadOnly = true;
                    this.txt_taxratio.ReadOnly = true;
                    this.txt_cessratio.ReadOnly = true;
                    this.txt_brdrt.ClearControl(true);
                }

                this.GrandTotalCalculation();
                //this.RoundOff();
            }
            catch (Exception ex)
            {

            }
        }
        //private void TotalRateCalculation()
        //{
        //    try
        //    {
        //        double netWt = PLABS.Utils.CnvToDouble(this.lbl_NetWt.Text);
        //        double brdRt = PLABS.Utils.CnvToDouble(this.txt_brdrt.Text);

        //        this.txt_ttlrate.Text = (netWt * brdRt).ToString("N2");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //private void TotalTaxCalculation()
        //{
        //    try
        //    {
        //        double tax = (PLABS.Utils.CnvToDouble(this.txt_ttlrate.Text) * PLABS.Utils.CnvToDouble(this.txt_taxratio.Text)) / 100;
        //        double cess = (tax * PLABS.Utils.CnvToDouble(this.txt_cessratio.Text)) / 100;

        //        this.txt_tax.Text = tax.ToString("N2");
        //        this.txt_cess.Text = cess.ToString("N2");

        //        this.txt_ttltax.Text = (tax + cess).ToString("N2");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //private void TotalMcCalculation()
        //{
        //    try
        //    {
        //        double totalMc = ((PLABS.Utils.CnvToDouble(lbl_ttlCashMc.Text) *
        //                        PLABS.Utils.CnvToDouble(txt_brdrt.Text)) +
        //                        PLABS.Utils.CnvToDouble(lbl_ttlWtMc.Text)+
        //                        PLABS .Utils .CnvToDouble (lbl_ttlmcrate .Text));


        //        this.txt_ttlmc.Text = totalMc.ToString("N2");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        private void GrandTotalCalculation()
        {
            try
            {

                Utils obj = new Utils();
                double brdrt = this.BoardRateCalculation();
                double ttlPurewt = PLABS.Utils.CnvToDouble(this.lbl_purewt.Text);
                double ttlmcwt = PLABS.Utils.CnvToDouble(this.lbl_ttlWtMc.Text);
                double ttlmccash = PLABS.Utils.CnvToDouble(this.lbl_ttlCashMc.Text);
                double ttlmcrt = PLABS.Utils.CnvToDouble(this.lbl_ttlmcrate.Text);

                double taxratio = PLABS.Utils.CnvToDouble(this.txt_taxratio.Text);
                double cessratio = PLABS.Utils.CnvToDouble(this.txt_cessratio.Text);
                double ttlstnCsh = PLABS.Utils.CnvToDouble(this.lbl_stncsh.Text); 
                // ttlStnCsh



                txt_ttlmc.Text = ((ttlmcwt * brdrt) + ttlmccash + ttlmcrt).ToString("F2");
                txt_ttlrate.Text = (ttlPurewt * brdrt).ToString("F2");

                this.txt_tax.ClearControl(true);
                this.txt_cess.ClearControl(true);


                /*if (ddl_mode.ControlValue == "3")lbl_ttlCashMc
                 {
                     txt_ttlrate.ClearControl(true);
                     txt_ttltax.ClearControl(true);
                     txt_tax.Text = ((PLABS.Utils.CnvToDouble(txt_ttlmc.Text) * taxratio) / 100).ToString("F2");
                     txt_cess.Text = ((PLABS.Utils.CnvToDouble(txt_tax.Text) * cessratio) / 100).ToString("F2");
                     this.txt_total.Text = (PLABS.Utils.CnvToDouble(txt_ttlmc.Text)).ToString("F2");

                 }*/

                if (ddl_mode.ControlValue == "1")
                {

                    txt_tax.Text = (((PLABS.Utils.CnvToDouble(txt_ttlrate.Text) + PLABS.Utils.CnvToDouble(txt_ttlmc.Text)) * taxratio) / 100).ToString("F2");
                    txt_cess.Text = ((PLABS.Utils.CnvToDouble(txt_tax.Text) * cessratio) / 100).ToString("F2");
                    this.txt_total.Text = (PLABS.Utils.CnvToDouble(txt_ttlmc.Text)
                                       + PLABS.Utils.CnvToDouble(txt_ttlrate.Text)
                                       + PLABS.Utils.CnvToDouble(txt_tax.Text)
                                       + PLABS.Utils.CnvToDouble(txt_cess.Text)).ToString("F2");
                    this.txt_ttltax.Text = (PLABS.Utils.CnvToDouble(this.txt_tax.Text)
                                        + PLABS.Utils.CnvToDouble(this.txt_cess.Text)).ToString("F2");
                }
                else if (this.ddl_mode.ControlValue == "2" || this.ddl_mode.ControlValue == "9")
                {
                    this.txt_tax.Text = ((PLABS.Utils.CnvToDouble(this.txt_ttlmc.Text) * taxratio) / 100).ToString("F2");
                    this.txt_ttltax.Text = this.txt_tax.Text;
                     this.txt_total.Text=PLABS.Utils.CnvToDouble(this.txt_ttlmc.Text).ToString("F2");
                                        
                }
                this.RoundOff();


            }
            catch (Exception ex)
            {

            }
        }
        private void RoundOff()
        {
            try
            {
                this.txt_grdttl.Text = (PLABS.Utils.CnvToDouble(this.txt_total.Text) +
                    PLABS.Utils.CnvToDouble(this.txt_roundoff.Text)).ToString("F2");
                this.OpeningUpdation();
                CnvToCurncy obj = new CnvToCurncy();
                this.lbl_grdttlamt.Text = obj.get(PLABS.Utils.CnvToDouble(this.txt_grdttl.Text));

            }
            catch (Exception ex)
            {

            }
        }
        private double BoardRateCalculation()
        {
            try
            {
                Utils obj = new Utils();
                double pureRate = obj.PurityConversion(100, PLABS.Utils.CnvToDouble(this.txt_brdrt.Text),PLABS .Utils .CnvToDouble(this.ddl_brdrt.ControlValue));
                double discountPrRt = pureRate - ((pureRate * PLABS.Utils.CnvToDouble(this.txt_brdrtpercent.Text)) / 100);
                return discountPrRt;
            }
            catch (Exception ex)
            {

            }
            return 0;
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
        private void ShopNameChanged()
        {
            try
            {
                DataSet ds = this.GetDataSet("LA", "", this.fnd_address.ControlValue, "");
                this.fnd_item_id.LoadData(PLABS.Utils.GetDataTable(ds, 0), "itm", "cd", "id");
                _opnAmt = PLABS.Utils.CnvToDouble(ds.Tables[1].Rows[0]["amt"]);
                _opnWt = PLABS.Utils.CnvToDouble(ds.Tables[1].Rows[0]["wt"]);
                this.txt_shopamtop.Text = PLABS.Utils.CnvToDouble(ds.Tables[1].Rows[0]["amt"]).ToString("N2");
                this.txt_shop_OP.Text = PLABS.Utils.CnvToDouble(ds.Tables[1].Rows[0]["wt"]).ToString("F3");
                this.txtTemplate.ControlValue = PLABS.Utils.GetDataTable(ds, 2).Rows[0]["template"].ToString();

            }
            catch (Exception ex)
            {

            }
        }
        private void LoadModeCombo()
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("id");
                dt.Columns.Add("name");

                //dt.Rows.Add("3","Contract");
                dt.Rows.Add("1", "Sale(Capital)");
                dt.Rows.Add("2", "Weight");
                dt.Rows.Add("4", "Sales Return");


                ddl_mode.LoadData(dt, "name", "id");
                

                this.ddl_mode.ControlValue = "2";


                DataTable dt1 = new DataTable();

               
                dt1.Columns.Add("name");

                dt1.Rows.Add("99.5");
                dt1.Rows.Add("100");

                ddl_brdrt.LoadData(dt1, "name", "name");
                
              
            }
            catch (Exception ex)
            {

            }
        }
        private void OpeningUpdation()
        {
            try
            {
                if (this.ddl_mode.ControlValue == "1")
                {
                    this.txt_shopamtop.Text = (_opnAmt + PLABS.Utils.CnvToDouble(this.txt_grdttl.Text)).ToString("N2");
                }
                else if (this.ddl_mode.ControlValue == "2")
                {
                    this.txt_shop_OP.Text = (_opnWt + PLABS.Utils.CnvToDouble(this.lbl_ttWt.Text)).ToString("N3");

                }
                else if (this.ddl_mode.ControlValue == "4")
                {
                    this.txt_shop_OP.Text = (_opnWt - PLABS.Utils.CnvToDouble(this.lbl_ttWt.Text)).ToString("N3");

                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}

