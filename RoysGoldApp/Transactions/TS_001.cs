using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
    public partial class TS_001 : PLABS.MasterForm
    {
        #region globalvariable
        String masterKey = "0";
        bool _isLoading = true;
        double _opnWt = 0.00;
        int _isFirst = 0;
        bool _addrRfrsh = true;
        bool _itmRfrsh = true;
        #endregion
        #region constructors
        public TS_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {

                this.loadControls();
                this.SaveBeforeClick += new EventHandler(trsmthissrecmast_SaveBeforeClick);
                this.SaveAfterClick += new EventHandler(trsmthissrecmast_SaveAfterClick);
                this.DeleteBeforeClick += new EventHandler(trsmthissrecmast_DeleteBeforeClick);
                this.ClearAfterClick += new EventHandler(trsmthissrecmast_ClearAfterClick);
                this.fnd_smth_id.AfterFind += new EventHandler(fnd_smth_id_AfterFind);
                this.grd_data.CellEndEdit += new DataGridViewCellEventHandler(grd_data_CellEndEdit);
                this.grd_data.NewRowIdentity += new EventHandler(grd_data_NewRowIdentity);
                this.btn_refrsh.Click += new EventHandler(btn_refrsh_Click);
                this.btn_addrfrsh.Click += new EventHandler(btn_addrfrsh_Click);
                //this.txt_grswt.KeyDown += new KeyEventHandler(txt_grswt_KeyDown);
                this.grd_data.RowsAdded += new DataGridViewRowsAddedEventHandler(grd_data_RowsAdded);
                this.grd_data.RowsRemoved += new DataGridViewRowsRemovedEventHandler(grd_data_RowsRemoved);
                this.rtxt_desc.KeyDown += new KeyEventHandler(rtxt_desc_KeyDown);
                this.grd_data.CellDoubleClick += new DataGridViewCellEventHandler(grd_data_CellDoubleClick);
                this.btn_find.Click += new EventHandler(btn_find_Click);
                this.btn_clr_F.Click += new EventHandler(btn_clr_F_Click);
                this.lst_search.DoubleClick += new EventHandler(lst_search_DoubleClick);
                this.lst_search.KeyDown += new KeyEventHandler(lst_search_KeyDown);
                this.btn_delete.Click += new EventHandler(btn_delete_Click);
                this.fnd_gold_id.Leave += new EventHandler(fnd_gold_id_Leave);
                this.rtxt_desc.KeyDown += new KeyEventHandler(rtxt_desc_KeyDown);
                this.DeleteAfterClick += new EventHandler(TS_001_DeleteAfterClick);

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
            this.fnd_smth_id.Focus();
            base.OnActivated(e);
        }
        #endregion
        #region Events
        void TS_001_DeleteAfterClick(object sender, EventArgs e)
        {
            this.doDelete();
            this.LoadGrid();
        }
        private void trsmthissrecmast_SaveBeforeClick(object sender, EventArgs e)
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
                    //    if (this.FindID != "")
                    //        //this.FindID = this.masterKey;
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsmthissrecmast", "0011");
            }
        }
        private void trsmthissrecmast_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
                this.LoadGrid();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsmthissrecmast", "0012");
            }
        }
        private void trsmthissrecmast_ClearAfterClick(object sender, EventArgs e)
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
        private void trsmthissrecmast_DeleteBeforeClick(object sender, EventArgs e)
        {
            try
            {
                //this.doDelete();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0014");
            }
        }
        void fnd_smth_id_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this._isLoading = false;
                this.SmithNameChanged();
                this._isLoading = true;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0002");
            }


        }
        private void grd_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //this.CellEndEdit(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception ex)
            {

            }

        }
        void btn_refrsh_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (_itmRfrsh)
                {
                    dt = this.RefreshClick("MA", "1", this.fnd_smth_id.ControlValue);
                    _itmRfrsh = false;
                }
                else
                {
                    dt = this.RefreshClick("SM", "1", this.fnd_smth_id.ControlValue);
                    _itmRfrsh = true;
                }
                this.fnd_gold_id.LoadData(dt, "itm", "cd", "id");
                this.fnd_gold_id.Focus();
            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_NewRowIdentity(object sender, EventArgs e)
        {
            this.btn_save.Focus();
        }
        void rtxt_desc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _isFirst++;
                if (_isFirst % 2 != 0)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.AddGrid();
                        this._isLoading = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {

                this.GridRowAdd();
            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.GridRowAdd();
        }
        void grd_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.GridDoubleClick(e.RowIndex);
            }
            catch (Exception ex)
            {
            }
        }
        void btn_clr_F_Click(object sender, EventArgs e)
        {
            try
            {
                this.doFClear();
            }
            catch (Exception ex)
            {

            }

        }
        void btn_find_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        }
        void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                //this.doDelete();
                //this.LoadGrid();
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
        void fnd_gold_id_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.fnd_gold_id.ControlValue == "")
                    this.btn_save.Focus();
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
                    dt = this.RefreshClick("ST", "2", "");
                    _addrRfrsh = true;
                }
                this.fnd_smth_id.LoadData(dt, "cd", "nam", "id");
                this.fnd_smth_id.Focus();
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


                DataSet ds = this.GetDataSet("LO", "", "");
                this.fnd_smth_id.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");
                this.fnd_smth_id_F.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");
                //this.fnd_gold_id.LoadData(PLABS.Utils.GetDataTable(ds, 1), "itm", "cd", "id");
                this.PopulateModeCombo();
                this.fnd_smth_id.Focus();

                this.LoadGrid();
                this.BindGrid();

                if (this.FindID != string.Empty)
                {
                    this.masterKey = FindID;
                    this.doFind(FindID);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0002");
            }
        }
        private void LoadGrid()
        {
            DataSet ds = this.GetDataSet("LG", this.fnd_smth_id_F.ControlValue, "");
            this.lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));

        }
        private void doSave()
        {
            try
            {

                string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "as_smt_iss", PLABS.Utils.CnvToDouble(this.txt_smtiss.Text).ToString("F3"));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));

                xmlData = this.CallWS(xmlData, "BizObj.TS_001,BizObj", "I");
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
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0005");
            }
        }
        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_tr_smth_issrec_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.TS_001,BizObj", "D");
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
                masterKey = "0";

                this.btn_save.Enabled = true;
                //this.txt_amount.Focus();
                this.grd_data.ClearControl(true);
                this.fnd_smth_id.Enabled = true;
                this.fnd_smth_id.Focus();
                this.ddl_mode.Enabled = true;
                this.ValueChangedStatus = false;
                this.txt_grswt.SmartTab = true;
                this.ddl_mode.ControlValue = "1";
                //this._isFirstGridRow = true;
                this._isFirst = 0;

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
                    DataSet ds = this.GetDataSet("SE", "", PrimaryKeyID);
                    DataTable master = ds.Tables[0];
                    DataTable detail = ds.Tables[1];

                    this.fnd_smth_id.SelectedValue = PLABS.Utils.CnvToStr(master.Rows[0]["smth_id"]);
                    this.ddl_mode.ControlValue = PLABS.Utils.CnvToStr(master.Rows[0]["vtyp"]);


                    this.tb_smithissue.SelectedTab = this.tp_create;

                    this.grd_data.DataSource = detail;
                    this.ValueChangedStatus = true;
                    //_isFirstGridRow = false;
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
            try
            {
                this.fnd_smth_id_F.ClearControl(true);
                this.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }
        private bool isValidData()
        {
            if (this.grd_data.Rows.Count == 0)
            {
                PLABS.MessageBoxPL.Show("Please Add Items To The Grid");
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
        private String getSelectArgs(String as_mode, String ai_smth_id, String ai_tr_smth_issrec_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_smth_id", ai_smth_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_tr_smth_issrec_id", ai_tr_smth_issrec_id);
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
                //BizObj.TS_001 objtrsmthissue = new BizObj.TS_001();
                //xmlData = objtrsmthissue.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0009");
            }
            return xmlData;
        }
        private void SmithNameChanged()
        {
            try
            {


                this.rtxt_template.ClearControl(true);
                this.fnd_gold_id.ClearControl(true);
                DataSet ds = this.GetDataSet("LT", this.fnd_smth_id.ControlValue, "");

                //if (_isFirstGridRow)
                //{
                this.txt_opnwt.Text = "0";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.txt_opnwt.Text = PLABS.Utils.CnvToDouble(ds.Tables[0].Rows[0]["wt"]).ToString("N3");
                    this.txt_opnamt.Text = PLABS.Utils.CnvToDouble(ds.Tables[0].Rows[0]["amt"]).ToString("N2");
                    _opnWt = PLABS.Utils.CnvToDouble(ds.Tables[0].Rows[0]["wt"]);

                }
                //this.grd_data.ClearControl(true);
                this.txt_smtiss.Text = string.Empty;


                this.txt_smtiss.Clear();

                if (ds.Tables[2].Rows.Count > 0)
                {

                    this.rtxt_template.Text = PLABS.Utils.CnvToStr(ds.Tables[2].Rows[0][0]);
                }

                //}
                //if (!_isLoading)
                //{
                //    _isFirstGridRow = false;
                //}
                this.fnd_gold_id.LoadData(PLABS.Utils.GetDataTable(ds, 1), "itm", "cd", "id");

                this.rtxt_template.ControlValue = PLABS.Utils.GetDataTable(ds, 2).Rows[0][""].ToString();  

            }
            catch (Exception ex)
            {

            }
        }
        //private void CellEndEdit(int rowIndex, int colIndex)
        //{
        //    try
        //    {

        //        if (PLABS.Utils.CnvToInt(this.ddl_smithname.SelectedValue) > 0)
        //        {
        //            string colName = grd_data.Columns[colIndex].HeaderText.ToString();

        //            if (PLABS.Utils.CnvToStr(grd_data.Rows[rowIndex].Cells["ddl_grd_gld"].EditedFormattedValue) != "")
        //            {
        //                if (colName == "Gold")
        //                {
        //                    object val = grd_data.Rows[rowIndex].Cells["ddl_grd_gld"].Value;
        //                    this.cmb_gold.SelectedValue = val;
        //                }
        //                if (colName == "Gross Weight")
        //                {
        //                    double purity = PLABS.Utils.CnvToDouble(((DataRowView)(((ComboBox)(this.cmb_gold)).SelectedItem)).Row.ItemArray[2].ToString());
        //                    Utils objcon = new Utils();
        //                    double weight = Convert.ToDouble(grd_data.Rows[rowIndex].Cells["GrossWeight"].Value);
        //                    double conval = objcon.PurityConversion(purity, weight);
        //                    grd_data.Rows[rowIndex].Cells["smt_iss"].Value = conval;
        //                    double ttlconval = 0;
        //                    for (int i = 0; i < grd_data.Rows.Count - 1; i++)
        //                    {

        //                        ttlconval += Convert.ToDouble(grd_data.Rows[i].Cells["smt_iss"].Value);
        //                        this.txt_smtiss.Text = ttlconval.ToString("N3");
        //                    }
        //                    double opn = 0.00;
        //                    double smtiss = 0.00;
        //                    if (this.txt_opnwt.Text != "")
        //                    {
        //                        opn = Convert.ToDouble(this.txt_opnwt.Text);
        //                    }
        //                    smtiss = Convert.ToDouble(this.txt_smtiss.Text);
        //                    this.txt_ttlwt.Text = (opn + smtiss).ToString("F3");
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
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
        private DataSet GetDataSet(String as_mode, String ai_smth_id, String ai_tr_smth_issrec_id)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_smth_id, ai_tr_smth_issrec_id));
                xmlData = this.CallWS(xmlData, "BizObj.TS_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private bool ValidationForGridEntry()
        {
            if (this.fnd_smth_id.SelectedValue == string.Empty)
            {
                PLABS.MessageBoxPL.Show("Please Select A Smith");
                return false;
            }
            else if (this.fnd_gold_id.SelectedValue == string.Empty)
            {
                PLABS.MessageBoxPL.Show("Please Select A Item");
                return false;
            }
            else if (this.txt_grswt.Text == string.Empty)
            {
                PLABS.MessageBoxPL.Show("Please Enter Gross Weight");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void AddGrid()
        {
            if (this.ValidationForGridEntry())
            {
                //DataGridViewRow dr = new DataGridViewRow();
                //dr.CreateCells(this.grd_data);
                DataTable dt = (DataTable)this.grd_data.DataSource;

                DataRow dr = dt.NewRow();

                Utils objcon = new Utils();
                double grswt = PLABS.Utils.CnvToDouble(this.txt_grswt.Text);
                double purity = PLABS.Utils.CnvToDouble(this.fnd_gold_id.SelectedDescription);

                dr["itm_id"] = this.fnd_gold_id.ControlValue;
                dr["gold"] = (PLABS.Utils.CnvToStr(this.fnd_gold_id.SelectedCode) + " [ " + PLABS.Utils.CnvToStr(this.fnd_gold_id.SelectedDescription + " ]"));
                dr["grss_wght"] = this.txt_grswt.Text;
                dr["dsc"] = this.rtxt_desc.Text.Trim();
                dr["iss"] = objcon.PurityConversion(purity, grswt, 100);

                dt.Rows.Add(dr);
                //this.SmithNameChanged();
                //grd_data.Rows.Add(dr);
                if (!_itmRfrsh)
                {
                    dt = this.RefreshClick("SM", "1", this.fnd_smth_id.ControlValue);
                    _itmRfrsh = true;
                    this.fnd_gold_id.LoadData(dt, "itm", "cd", "id");
                }

                this.fnd_smth_id.Enabled = false;
                this.fnd_gold_id.ClearControl(true);
                this.ddl_mode.Enabled = false;
                this.txt_grswt.ClearControl(true);
                this.fnd_gold_id.Focus();
                this.rtxt_desc.ClearControl(true);
            }
        }
        private void GridRowAdd()
        {
            try
            {
                double ttlIssWt = 0.00;
                double ttlWt = 0.00;
                //double opnWt = 0.00;
                for (int i = 0; i < grd_data.Rows.Count; i++)
                {
                    ttlIssWt += PLABS.Utils.CnvToDouble(this.grd_data.Rows[i].Cells["smt_iss"].Value);
                }
                //opnWt = PLABS.Utils.CnvToDouble(this.txt_opnwt.Text);
                if (this.ddl_mode.ControlValue == "1")
                {
                    ttlWt = _opnWt + ttlIssWt;
                }
                else
                {
                    ttlWt = _opnWt - ttlIssWt;
                }
                this.txt_smtiss.Text = PLABS.Utils.CnvToDouble(ttlIssWt).ToString("N3");
                this.txt_opnwt.Text = PLABS.Utils.CnvToDouble(ttlWt).ToString("N3");
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
                    DataTable dt = this.RefreshClick("MA", "1", this.fnd_smth_id.ControlValue);
                    _itmRfrsh = false;
                    this.fnd_gold_id.LoadData(dt, "itm", "cd", "id");
                }
                this.fnd_gold_id.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_itm_id_gv"].Value);
                this.txt_grswt.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["grossweight"].Value);
                this.rtxt_desc.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_desc_gv"].Value);
                this.grd_data.Rows.Remove(grd_data.Rows[rowNum]);
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

                dt.Columns.Add("itm_id", typeof(string));
                dt.Columns.Add("gold", typeof(string));
                dt.Columns.Add("grss_wght", typeof(double));
                dt.Columns.Add("iss", typeof(double));
                dt.Columns.Add("dsc", typeof(string));


                this.grd_data.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
        }
        private void PopulateModeCombo()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("name");

            DataRow dr = dt.NewRow();

            dr["id"] = PLABS.Utils.CnvToStr(PLABS.Utils.CnvToInt(Enums.VoucherType.SmithIssue));
            dr["name"] = PLABS.Utils.CnvToStr(Enums.VoucherType.SmithIssue);

            DataRow dr1 = dt.NewRow();

            dr1["id"] = PLABS.Utils.CnvToStr(PLABS.Utils.CnvToInt(Enums.VoucherType.SmithReturn));
            dr1["name"] = PLABS.Utils.CnvToStr(Enums.VoucherType.SmithReturn);


            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);


            this.ddl_mode.LoadData(dt, "name", "id");

            this.ddl_mode.ControlValue = "1";
        }
        #endregion
    }
}

