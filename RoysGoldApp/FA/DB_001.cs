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

    public partial class DB_001 : PLABS.MasterForm
    {
        #region Global variable
        //string masterKey = "0";
        DataTable dtNotFinalize = new DataTable();
        DataTable dtRmvFinalized = new DataTable();
        ArrayList _dateArray = new ArrayList();
        int _arrIndex = 0;
        int Indx = 0;
        //string _nxtDateForConfirm = string.Empty;
        //string _prvDateForConfirm = string.Empty;
        #endregion
        #region Properties
        #endregion
        #region Contructor
        public DB_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            
            this.loadControls();
           
            this.btn_pre.Click += new EventHandler(btn_pre_Click);
            this.btn_nxt.Click += new EventHandler(btn_nxt_Click);
            this.btn_fnlize.Click += new EventHandler(btn_fnlize_Click);
            this.tab_main.Selected += new TabControlEventHandler(tab_main_Selected);
            this.grd_gldrgtr.CellDoubleClick += new DataGridViewCellEventHandler(grd_gldrgtr_CellDoubleClick);
            this.dtp_curdt.Leave += new EventHandler(dtp_curdt_Leave);
            this.SaveAfterClick += new EventHandler(DB_001_SaveAfterClick);
            this.btn_rmove.Click += new EventHandler(btn_rmove_Click);
            this.btn_save.Click += new EventHandler(btn_save_Click);
            this.btn_save1.Click += new EventHandler(btn_save1_Click);
            this.btn_cnfirm.Click += new EventHandler(btn_cnfirm_Click);
            this.btn_cnfirmall.Click += new EventHandler(btn_cnfirmall_Click);
            this.btn_pendingall.Click += new EventHandler(btn_pendingall_Click);
            this.grd_cashbook.DataError += new DataGridViewDataErrorEventHandler(grd_cashbook_DataError);
            this.grd_confirm.DataError += new DataGridViewDataErrorEventHandler(grd_confirm_DataError);
            this.grd_gldrgtr.DataError += new DataGridViewDataErrorEventHandler(grd_gldrgtr_DataError);
            this.grd_last.DataError += new DataGridViewDataErrorEventHandler(grd_last_DataError);
            this.grd_confirm.CellDoubleClick += new DataGridViewCellEventHandler(grd_confirm_CellDoubleClick);
            this.grd_confirm.KeyDown += new KeyEventHandler(grd_confirm_KeyDown);
            this.grd_last.CellDoubleClick+=new DataGridViewCellEventHandler(grd_last_CellDoubleClick);
            this.grd_last.KeyDown+=new KeyEventHandler(grd_last_KeyDown);
            this.grd_cashbook.CellDoubleClick += new DataGridViewCellEventHandler(grd_cashbook_CellDoubleClick);
            this.grd_cashbook.KeyDown += new KeyEventHandler(grd_cashbook_KeyDown);         
            this.tab_main.SelectedIndexChanged += new EventHandler(tab_main_SelectedIndexChanged);        
            this.btn_cptlcnfrm.Click += new EventHandler(btn_cptlcnfrm_Click);
            this.btn_dayfnlizegld.Click += new EventHandler(btn_dayfnlizegld_Click);
            this.grd_cptlpnding.CellDoubleClick += new DataGridViewCellEventHandler(grd_cptlpnding_CellDoubleClick);
            this.grd_cptlpnding.KeyDown += new KeyEventHandler(grd_cptlpnding_KeyDown);
            this.btn_stk.Click += new EventHandler(btn_stk_Click);
            this.btn_sheet.Click += new EventHandler(btn_sheet_Click);
            this.btn_ttl.Click += new EventHandler(btn_ttl_Click);
            this.btn_totlsal.Click += new EventHandler(btn_totlsal_Click);
            this.btn_confirm.Click += new EventHandler(btn_confirm_Click);
            this.btn_save_pc.Click += new EventHandler(btn_save_pc_Click);
            this.btn_confirm__template.Click += new EventHandler(btn_confirm__template_Click);
            base.OnLoad(e);
        }

       

          
       
        protected override void OnActivated(EventArgs e)
        {
            this.grd_gldrgtr.Focus();
            base.OnActivated(e);
        }
         #endregion
        #region event 
        void btn_confirm__template_Click(object sender, EventArgs e)
        {
            try
            {
                ConfrmTemplate();
            }
            catch
            {
            }
        }
        void btn_save_pc_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    this.SavePCRegister();
                }
            }
            catch (Exception ex)
            {

            }
        }  
        void btn_totlsal_Click(object sender, EventArgs e)
        {
            try
            {
                RP_007 obj = new RP_007();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

            }

        }
        void tab_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TabChangFocus(); 
        }
        void grd_cashbook_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
                if (e.KeyCode == Keys.Enter)
                {
                   
                    this.GotoWeightLedger(this.grd_cashbook.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_cashbook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.GotoWeightLedger(e.RowIndex);
            }
            catch
            {
            }
        }
        void grd_last_KeyDown(object sender, KeyEventArgs e)
          {
 	        try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GotoWeightLedger(this.grd_last.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
 
            }
}
        void grd_last_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
          {
              try
              {
                     this.GotoWeightLedger(e.RowIndex);
              }
              catch
              {
              }
          }                 
        void btn_nxt_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._dateArray.Count - 1 == _arrIndex)
                {
                    PLABS.MessageBoxPL.Show("No Data Fount");
                }
                else
                {
                    this._arrIndex++;
                    this.dtp_curdt.ControlValue = PLABS.Utils.CnvToDate(_dateArray[_arrIndex]).ToString();
                    this.NextClick();
                }
                
            }
            catch (Exception ex)
            {

            }
        }
        void btn_pre_Click(object sender, EventArgs e)
        {

            if (this._arrIndex == -1 || this._arrIndex == 0)
            {
                PLABS.MessageBoxPL.Show("No Data Fount");
                return;
            }
            else
            {
                this._arrIndex--;
                this.dtp_curdt.ControlValue = PLABS.Utils.CnvToDate(_dateArray[_arrIndex]).ToString();
                this.NextClick();
            }
           

        }
        void btn_chk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        void btn_fnlize_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Properties.Settings.Default.id == -1)
                //{
                    if (PLABS.MessageBoxPL.Show("Do You Really Want To Finalize?", "Warning", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning) == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        string xmlData = this.getBlankXml();
                        xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "F");
                        if (xmlData.Length < 7)
                        {
                            PLABS.MessageBoxPL.Show("Records Are Removed And Openings Are Forwarded");
                        }
                        else 
                        {
                            PLABS.MessageBoxPL.Show(xmlData);
                        }
                    }
                //}
                //else
                //{
                //    PLABS.MessageBoxPL.Show("Please Close This Day Before Finalize");
                //}
            }
            catch (Exception ex)
            {

            }
        }
        void tab_main_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                string tabPage = e.TabPage.Name;
                if (tabPage == "tp_gldreg")
                {
                    this.PopulateGrid("GR", "", this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
                }
                else if (tabPage == "tp_cashbook")
                {

                    this.CashBookPopulate("CB", "", this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
                }
                else if (tabPage == "tp_cnfirm")
                {
                    this.PopulateGrid("CM", "",this.dtp_curdt .Value .ToString("yyyy-MM-dd"));
                }
                else if (tabPage == "tp_late_att")
                {
                    this.LateAttendanceDtls();
                }
                else if (tabPage == "tp_pcregister")
                {
                    this.LoadControls();
                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_gldrgtr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = this.grd_gldrgtr.Columns[e.ColumnIndex].HeaderText;
                if (colName == "WGT IN" || colName == "WGT OUT")
                    this.GridDoubleClick(e.RowIndex, e.ColumnIndex, colName);
            }
            catch (Exception ex)
            {
            }
        }
        void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                this.Finalize();
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_save1_Click(object sender, EventArgs e)
        {
            this.SaveCashBook();
        }
        void btn_rmove_Click(object sender, EventArgs e)
        {
            try
            {
                this.RemoveFinalized();
            }
            catch
            {
            }
        }
        void DB_001_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.Finalize();
            }
            catch
            {
            }
        }
        void dtp_curdt_Leave(object sender, EventArgs e)
        {
            try
            {
                _arrIndex = _dateArray.IndexOf(dtp_curdt.Value.ToString("dd-MMM-yy"));
                
                if (_arrIndex == -1)
                {
                    this.grd_gldrgtr.ClearControl(true);
                    PLABS.MessageBoxPL.Show("No Records Found");

                }
                else
                {
                    this.PopulateGrid("GR", "", dtp_curdt.Value.ToString("yyyy-MM-dd"));
                }

            }
            catch (Exception ex)
            {

            }
        }
        void btn_cnfirmall_Click(object sender, EventArgs e)
        {
            try
            {
                this.Confirmation("A");
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_cnfirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.Confirmation("C");
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_pendingall_Click(object sender, EventArgs e)
        {
            try
            {
                this.PendingAllPopUp();
            }
            catch (Exception ex)
            {
 
            }
        }
        void grd_last_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        void grd_gldrgtr_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        void grd_confirm_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        void grd_cashbook_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        void grd_confirm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GotoWeightLedger(this.grd_confirm.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        void grd_confirm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.GotoWeightLedger(e.RowIndex);
            }
            catch (Exception ex)
            {
 
            }
        }
        void grd_cptlpnding_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GotoWeightLedger(this.grd_cptlpnding.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_cptlpnding_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.GotoWeightLedger(e.RowIndex);
            }
            catch (Exception ex)
            {

            }
        }
        void btn_dayfnlizegld_Click(object sender, EventArgs e)
        {
            try
            {
                this.DayFinalize();
            }
            catch (Exception ex)
            {

            }
        }
        void btn_cptlcnfrm_Click(object sender, EventArgs e)
        {
            try
            {
                this.Confirmation("CP");
            }
            catch (Exception ex)
            {

            }
        }
        void btn_stk_Click(object sender, EventArgs e)
        {
            try
            {
                RP_006 obj = new RP_006();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void btn_sheet_Click(object sender, EventArgs e)
        {
            try
            {
                TD_001 obj = new TD_001();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void btn_ttl_Click(object sender, EventArgs e)
        {
            try
            {
                FL_003 obj = new FL_003();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd_late_att.Rows.Count-1 > 0)
                {
                    DateTime mnth = PLABS.Utils.CnvToDate(grd_late_att.Rows[0].Cells["txt_adate_gv"].Value);
                    this.ConfrmLteAtt(PLABS.Utils.CnvToStr(mnth.Month), PLABS.Utils.CnvToStr(mnth.Year));
                }
                else
                {
                    PLABS.MessageBoxPL.Show("No Records..");
                }
            }
            catch (Exception ex)
            {

            }
        }
       
        #endregion
        #region common method

        private void loadControls()
        {
            try
            {
                if (dtNotFinalize.Columns.Count == 0)
                {
                    this.AddColsToGblTable();
                }
                this.BindCashBookGrid();
                DataSet ds= this.GetDataSet("LO", "", "");
                DataTable dt=PLABS .Utils .GetDataTable (ds,0);
                
                if (dt.Rows.Count > 0)
                {
                    _dateArray.Clear();
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        _dateArray.Add(dt.Rows[i]["dt"]);
                    }
                }
                if (_dateArray.Count > 0)
                {
                    this.dtp_curdt.ControlValue = PLABS.Utils.CnvToStr( _dateArray[0]);
                    this.loadGrid();
                }
                this.LastGrid();
                this.ConfirmGrid();
                this.CptlPending();
                this.tab_main.SelectedIndex = 0;
                this.grd_template.DataSource = PLABS.Utils.GetDataTable(ds, 1);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0002");
            }
        }
        private void loadGrid()
        {
            try
            {
                this.PopulateGrid("GR", "",dtp_curdt.Value.ToString("yyyy-MM-dd"));
                
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0003");
            }
        }
        private void doFind(String PrimaryKeyID)
        {
            try
            {
                //this.btn_saveas.Enabled = true;
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
                    string xmlData = this.getBlankXml();
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("", "SE", ""));
                    xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "S");
                    this.DataSource = xmlData;
                    this.ValueChangedStatus = false;
                    //this.txt_code.Focus();
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrgrup", "0004");
            }
        }  
        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;

                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        String Key ="";
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
                    this.loadGrid();
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
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0005");
            }
        }
        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_addr_grup_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "D");
                if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Deleted Successfully", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.loadGrid();
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
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0006");
            }
        }
        private void doClear()
        {
            try
            {
                //masterKey = "0";
                //this.btn_saveas.Enabled = false;
                //this.txt_amount.Focus();
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0007");
            }
        }
        private void doFClear()
        {
        }
        private bool isValidData()
        {
            return true;
        }
        private String getSelectArgs(String as_tabmode, String as_mode, String as_dt)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_tabmode", as_tabmode);
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ad_dt", as_dt);

                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0010");
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
                //BizObj.DB_001 objmaitemgrpmast = new BizObj.DB_001();
                //xmlData = objmaitemgrpmast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0009");
            }
            return xmlData;
        }
        private DataSet GetDataSet(String tabmode, String as_mode, String as_dt)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(tabmode, as_mode, as_dt));
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
        #endregion
        #region additional method

        private void PopulateGrid(String as_tabmode, String as_mode, String as_dt)
        {
            DataSet ds = this.GetDataSet(as_tabmode, as_mode, as_dt);
            //int tableNum = 0;
            //if (as_mode == "LG")
            //{
            //    //string date = (PLABS.Utils.CnvToDate(ds.Tables[0].Rows[0][0])).ToString("dd-MMM-yyyy");
            //    //this.lbl_curdt.Text = date;
            //    tableNum = 1;
            //}
            DataTable dt = ds.Tables[0];

            if (as_tabmode == "GR")
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0;  i < dt.Rows.Count; i++)
                    {
                       double  opn = PLABS.Utils.CnvToDouble(dt.Rows[i]["opnwt"]);
                       double wgtin = PLABS.Utils.CnvToDouble(dt.Rows[i]["wgtin"]);
                       double wgtout = PLABS.Utils.CnvToDouble(dt.Rows[i]["wgtout"]);
                        double sursht = PLABS.Utils.CnvToDouble(dt.Rows[i]["cls"]);
                        double sheWt = PLABS.Utils.CnvToDouble(dt.Rows[i]["shetwt"]);
                        if(sheWt!=0)
                        {
                            dt.Rows[i]["opnwt"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["opnwt"]) + PLABS.Utils.CnvToDouble(dt.Rows[i]["stwtopn"]);
                        }
                        DataRow dr = dt.Rows[i];
                        dr["cls"] = (opn + wgtin - wgtout + sursht).ToString("N3");
                       

                    }
                    dt.Columns.Remove("stwtopn");
                    this.grd_gldrgtr.DataSource = dt;
                   

                    DataRow[] selecedRows = dtNotFinalize.Select("date='" + as_dt + "'");
                    for (int j = 0; j < selecedRows.Length; j++)
                    {
                        DataRow row = selecedRows[j];
                        DataRow[] sourceRow = dt.Select("item_id='" + row["grp_id"] + "'");
                        if (sourceRow.Length != 0)
                        {
                            switch (PLABS.Utils.CnvToStr(row["IO"]))
                            {

                                case "I":
                                    sourceRow[0]["WgtInXml"] = row["Xml"];
                                    break;
                                case "O":
                                    sourceRow[0]["WgtOutXml"] = row["Xml"];
                                    break;
                            }
                        }
                    }
                    this.RemoveZeros(this.grd_gldrgtr);
                }
                else
                {
                    this.grd_gldrgtr.ClearControl(true);
                    PLABS.MessageBoxPL.Show("No Record Found");
                    //this.lbl_curdt.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
            }
            else if (as_tabmode == "CB")
            {
                PLABS.MessageBoxPL.Show("Work Pending");
            }
            else if (as_tabmode == "CM")
            {
                if (dt.Rows.Count != 0)
                {
                 this.grd_confirm.DataSource = dt;
                //    if (ds.Tables[1].Rows.Count != 0)
                //        this._nxtDateForConfirm = (PLABS.Utils.CnvToDate(ds.Tables[1].Rows[0][0]).AddDays(-1)).ToString("dd-MMM-yyyy");
                //    if (ds.Tables[2].Rows.Count != 0)
                //        this._prvDateForConfirm = (PLABS.Utils.CnvToDate(ds.Tables[2].Rows[0][0]).AddDays(+1)).ToString("dd-MMM-yyyy");


                }
                else
                {
                    this.grd_confirm.ClearControl(true);
                    //PLABS.MessageBoxPL.Show("No Recoeds Found");

                }
            }
           

        }
        private void NotFinalizedRowColloction(String grpId, String inOrOut, String type, String xml)
        {
            string date = (this.dtp_curdt.Value).ToString("yyyy-MM-dd");
            DataRow[] rowForDelete = dtNotFinalize.Select("date='" + date + "' AND grp_id='" + grpId + "'AND IO='" + inOrOut + "' AND type='" + type + "'");
            if (rowForDelete.Length != 0)
            {
                int j = 0;
                while (j < rowForDelete.Length)
                {
                    DataRow dr = rowForDelete[j];
                    dtNotFinalize.Rows.Remove(dr);
                    j++;
                }
            }
            //for (int i = 0; i<grd_gldrgtr.Rows.Count; i++)
            //{

            if (xml != string.Empty)
            {
                DataRow dr1 = dtNotFinalize.NewRow();

                dr1["grp_id"] = grpId;
                dr1["date"] = date;
                dr1["type"] = type;
                dr1["IO"] = inOrOut;
                dr1["Xml"] = xml;
                dtNotFinalize.Rows.Add(dr1);
            }
            if (dtNotFinalize.Select("date='" + date + "' AND grp_id='" + grpId + "'AND IO='" + inOrOut + "' AND type='0'").Length == 0)
            {
                DataRow dr2 = dtNotFinalize.NewRow();

                dr2["grp_id"] = grpId;
                dr2["date"] = date;
                dr2["type"] = 0;
                dr2["IO"] = inOrOut;
                dr2["Xml"] = xml;
                dtNotFinalize.Rows.Add(dr2);
            }
            /*if (PLABS.Utils.CnvToStr(grd_gldrgtr.Rows[i].Cells["chk_mark_gv"].FormattedValue) == "True") 
            {
                DataRow dr = dtNotFinalize.NewRow();
                    
                dr["Id"] = PLABS.Utils.CnvToStr(this.grd_gldrgtr.Rows[i].Cells["txt_id_gv"].Value);
                dr["date"] =date;
                dtNotFinalize.Rows.Add(dr);
            }*/

            //}
        }
        private void AddColsToGblTable()
        {
            dtNotFinalize.Columns.Add("grp_id");
            dtNotFinalize.Columns.Add("date");
            dtNotFinalize.Columns.Add("type");
            dtNotFinalize.Columns.Add("IO");
            dtNotFinalize.Columns.Add("Xml");
        }
        /* private void HoldStatus(string date)
         {
            
             dtNotFinalize.DefaultView.RowFilter = "date='" + date + "' AND id NOT IN (0)";
             DataTable sortTable = dtNotFinalize.DefaultView.ToTable();
             dtNotFinalize.DefaultView.RowFilter = "date='" + date + "' AND id IN (0)";
             DataTable conTable = dtNotFinalize.DefaultView.ToTable();
             string gridId = string.Empty;
             int j = 0;
             if (sortTable.Rows.Count != 0)
             {
                 for (j = 0; j < grd_gldrgtr.Rows.Count; j++)
                 {
                     for (int i = 0; i < sortTable.Rows.Count; i++)
                     {
                         string id = PLABS.Utils.CnvToStr(sortTable.Rows[i]["id"]);


                         gridId = PLABS.Utils.CnvToStr(grd_gldrgtr.Rows[j].Cells["txt_id_gv"].Value);
                         if (id == gridId)
                         {
                             grd_gldrgtr.Rows[j].Cells["chk_mark_gv"].Value = true;
                             grd_gldrgtr.Rows[j].DefaultCellStyle.BackColor = Color.Gold;

                         }
                         else
                         {
                             if (PLABS.Utils.CnvToStr(grd_gldrgtr.Rows[i].Cells["chk_mark_gv"].FormattedValue) == "false")
                             {
                                 grd_gldrgtr.Rows[j].Cells["chk_mark_gv"].Value = true;
                                 grd_gldrgtr.Rows[j].DefaultCellStyle.BackColor = Color.Gold;
                             }
                             else
                             {
                                 grd_gldrgtr.Rows[j].Cells["chk_mark_gv"].Value = false;
                                 grd_gldrgtr.Rows[j].DefaultCellStyle.BackColor = Color.White;
                             }
                         }


                     }
                 }
             }
             else if(conTable .Rows.Count!=0)
             {
                 for (int i = 0; i < grd_gldrgtr.Rows.Count; i++)
                 {
                     grd_gldrgtr.Rows[i].Cells["chk_mark_gv"].Value = false;
                     grd_gldrgtr.Rows[i].DefaultCellStyle.BackColor = Color.White;
                 }
             }


            
         }*/
        private void Finalize()
        {
            //DataRow[] dr = dtNotFinalize.Select("id='0'");
            //if (dr.Length != 0)
            //{
                //int i = 0;
               // while (i < dr.Length)
                //{
                   // dtNotFinalize.Rows.Remove(dr[i]);
                    //i++;
                //}
           // }
            DataRow[] nullRows = dtNotFinalize.Select("type='0'");
            if (nullRows.Length != 0) 
            {
                foreach (DataRow dr in nullRows)
                {
                    dtNotFinalize.Rows.Remove(dr);
                }
            }
            DataSet ds = new DataSet();
            ds.DataSetName = "ResultDS";
            dtNotFinalize.TableName = "Rslt";
            dtNotFinalize=dtNotFinalize.DefaultView.ToTable(true,new string[]{"date","xml"});
            ds.Tables.Add(dtNotFinalize);
            string xml = PLABS.Utils.CnvDataTableToXml(dtNotFinalize, false);
            string xmlData = this.getBlankXml();
            if (dtNotFinalize.Rows.Count != 0)
            {
                    xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "D");
                }
                else
                {
                    xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "");
                }
                xmlData = PLABS.Utils.addNode(xmlData, "v_Xmldata", PLABS.CreateXml.FormatString(xml));
                xmlData = PLABS.Utils.addNode(xmlData, "ad_date", this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "I");
                ds.Tables.Remove(dtNotFinalize);
                if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Records Are Moved To Pending List");
                    this.dtp_curdt.ControlValue = DateTime.Now.ToString("dd-MMM-yyyy");
                    //this.loadGrid();
                    this.LastGrid();
                }           

            dtNotFinalize.Columns.Remove("date");
            dtNotFinalize.Columns.Remove("xml" );
            this.AddColsToGblTable();
        }
        private void NextClick()
        {
            try
            {
                DateTime curdate = new DateTime();
                DateTime rsltdate = new DateTime();
                string as_tabmode = string.Empty;
                string as_mode = string.Empty;
                string tabPage = this.tab_main.SelectedTab.Name;
                switch (tabPage)
                {
                    case "tp_gldreg":
                        //this.NotFinalizedRowColloction();
                        as_tabmode = "GR";
                        this.PopulateGrid(as_tabmode,"",dtp_curdt.Value .ToString("yyyy-MM-dd"));
                        break;
                    case "tp_cashbook":
                        this.CashBookPopulate("CB", "", dtp_curdt.Value.ToString("yyyy-MM-dd"));
                        break;
                    case "tp_cnfirm":
                        //if (_nxtDateForConfirm != string.Empty)
                        //{
                        //    this.lbl_curdt.Text = _nxtDateForConfirm;
                        //}
                        as_tabmode = "CM";
                        //curdate = PLABS.Utils.CnvToDate(this.lbl_curdt.Text);
                        //rsltdate = curdate.AddDays(1);
                        this.PopulateGrid(as_tabmode,"",this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
                        //this.lbl_curdt.Text = rsltdate.ToString("dd-MMM-yyyy");
                        break;

                }
                //DateTime curdate = PLABS.Utils.CnvToDate(this.lbl_curdt.Text);
                //DateTime rsltdate = curdate.AddDays(1);
                //this.lbl_curdt.Text = rsltdate.ToString("dd-MMM-yyyy");

               
                //if (tabPage == "tp_gldreg")
                //{
                //this.HoldStatus((PLABS.Utils.CnvToDate(rsltdate)).ToString("yyyy-MM-dd"));
                //}
            }
            catch (Exception ex)
            {

            }
        }
        //private void PreviousClick()
        //{
        //    try
        //    {
        //         DateTime curdate=new DateTime ();
        //         DateTime rsltdate=new DateTime ();
        //        string as_tabmode = string.Empty;
        //        string as_mode = string.Empty;
        //        string tabPage = this.tab_main.SelectedTab.Name;
        //        switch (tabPage)
        //        {
        //            case "tp_gldreg":
        //                //this.NotFinalizedRowColloction();
        //                as_tabmode = "GR";
        //                //as_mode = "LS";
        //                //curdate = PLABS.Utils.CnvToDate(this.lbl_curdt.Text);
        //                rsltdate = curdate.AddDays(-1);
        //                this.lbl_curdt.Text = rsltdate.ToString("dd-MMM-yyyy");
        //                break;
        //            case "tp_cashbook":
        //                DateTime curdat = PLABS.Utils.CnvToDate(this.lbl_curdt.Text);
        //                DateTime rsltdat = curdat.AddDays(-1);
        //                this.lbl_curdt.Text = rsltdat.ToString("dd-MMM-yyyy");

        //                this.CashBookPopulate("CB", "", rsltdat.ToString("yyyy-MM-dd"));
        //                break;
        //            case "tp_cnfirm":
        //                if (_nxtDateForConfirm != string.Empty)
        //                {
        //                    this.lbl_curdt.Text = _prvDateForConfirm;
        //                }

        //                as_tabmode = "CM";
        //                curdate = PLABS.Utils.CnvToDate(this.lbl_curdt.Text);
        //                rsltdate = curdate.AddDays(-1);
        //                this.lbl_curdt.Text = rsltdate.ToString("dd-MMM-yyyy");
        //                break;

        //        }

        //        //DateTime curdate = PLABS.Utils.CnvToDate(this.lbl_curdt.Text);
        //        //DateTime rsltdate = curdate.AddDays(-1);
        //        //this.lbl_curdt.Text = rsltdate.ToString("dd-MMM-yyyy");


        //        this.PopulateGrid(as_tabmode, as_mode, rsltdate.ToString("yyyy-MM-dd"));
        //        //if (tabPage == "tp_gldreg")
        //        //this.HoldStatus((PLABS.Utils.CnvToDate(rsltdate)).ToString("yyyy-MM-dd"));
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private void GridDoubleClick(int rowNum, int colNum, String colName)
        {
            String[] parameters = new String[5];


            switch (colName)
            {
                case "WGT IN":
                    parameters[0] = "I";
                    break;
                case "WGT OUT":
                    parameters[0] = "O";
                    break;
            }
            parameters[1] = this.dtp_curdt.Value .ToString("yyyy-MM-dd");
            parameters[2] = PLABS.Utils.CnvToStr(this.grd_gldrgtr.Rows[rowNum].Cells["txt_id_gv"].Value);
            switch (parameters[0])
            {
                case "I":
                    parameters[3] = PLABS.Utils.CnvToStr(this.grd_gldrgtr.Rows[rowNum].Cells["txt_wgtinxml_gv"].Value);
                    break;
                case "O":
                    parameters[3] = PLABS.Utils.CnvToStr(this.grd_gldrgtr.Rows[rowNum].Cells["txt_wgtoutxml_gv"].Value);
                    break;
            }            
            if(dtNotFinalize.Select("date='" + parameters [1]+ "' AND grp_id='" +parameters[2] + "'AND IO='" + parameters[0] + "' AND type='0'").Length != 0)
            {
                parameters[4] = "S";
            }
            else
            {
                parameters[4] = "F";
            }
            CO_002 objpopup = new CO_002();
            objpopup.Parameters = parameters;

            objpopup.ShowDialog();
            switch (parameters[0])
            {
                case "I":
                    this.grd_gldrgtr.Rows[rowNum].Cells["txt_wgtinxml_gv"].Value = objpopup.Xml;
                    break;
                case "O":
                    this.grd_gldrgtr.Rows[rowNum].Cells["txt_wgtoutxml_gv"].Value = objpopup.Xml;
                    break;
            }           
            string xml = objpopup.Xml;
            objpopup.Close();
            this.NotFinalizedRowColloction(parameters[2], parameters[0], "1", xml);

        }
        private void CashBookPopulate(String as_tabmode, String as_mode, String as_dt)
        {
            try
            {
                int cashBookEnd=1;
                int jrnlEnd;
                this.BindCashBookGrid();
                DataTable dt = (DataTable)grd_cashbook.DataSource;
                DataSet ds = this.GetDataSet(as_tabmode, as_mode, as_dt);
                for (int i=1; i < ds.Tables.Count; i++)
                {
                    double opening = PLABS.Utils.CnvToDouble(PLABS.Utils.GetDataTable(ds, 0).Rows[0][0]);
                    DataRow opnRow = dt.NewRow();
                    dt.Rows.Add(opnRow);
                    if (i == 1)
                    {
                        //opnRow["head"] = "OPENING";

                        //if (opening < 0)
                        //{

                        //    opnRow["dr"] = (0 - opening).ToString();
                        //}
                        //else
                        //{

                        //    opnRow["cr"] = opening.ToString("F2");
                        //}
                    }
                       
                    else if (i == 2)
                    {
                        DataRow jrnlStart = dt.NewRow();
                        jrnlStart["nar"] = "JOURNEL";
                        dt.Rows.Add(jrnlStart);
                    }
                    
                    foreach (DataRow dr in PLABS.Utils.GetDataTable(ds, i).Rows)
                    {
                        DataRow dtRow = dt.NewRow();

                        dtRow["head"] = dr["head"];
                        dtRow["nar"] = dr["nar"];
                        dtRow["vid"] = dr["VID"];
                        dtRow["chk"] = dr["chk"];
                        dtRow["Sid"] = dr["Sid"];

                        if (PLABS.Utils.CnvToDouble(dr["dr"]) > 0)
                        {
                            dtRow["dr"] = dr["dr"];
                        }
                        if (PLABS.Utils.CnvToDouble(dr["cr"]) > 0)
                        {
                            dtRow["cr"] = dr["cr"];
                        }

                        dt.Rows.Add(dtRow);
                    }
                    double ttldr = PLABS.Utils.CnvToDouble(dt.Compute("SUM(dr)", ""));
                    double ttlcr = PLABS.Utils.CnvToDouble(dt.Compute("SUM(cr)", ""));
                    
                    if (i == 1)
                    {
                        DataRow ttlRow = dt.NewRow();
                        ttlRow["head"] = "TOTAL";
                        ttlRow["dr"] = ttldr;
                        ttlRow["cr"] = ttlcr;
                        dt.Rows.Add(ttlRow);
                        double closing = ttldr - ttlcr;
                        DataRow clsRow = dt.NewRow();
                        clsRow["head"] = "CLOSING";
                        clsRow["cr"] = closing;
                        dt.Rows.Add(clsRow);
                        cashBookEnd = dt.Rows.Count;
                    }
                }
                this.grd_cashbook.Rows[cashBookEnd-1].DefaultCellStyle.BackColor = Color.AliceBlue;
                this.grd_cashbook.Rows[cashBookEnd-1].DefaultCellStyle.Font = new Font("ARIEL", 10, FontStyle.Bold);
                //this.grd_cashbook.Rows[cashBookEnd].DefaultCellStyle.BackColor = Color.AliceBlue;
                //this.grd_cashbook.Rows[cashBookEnd].DefaultCellStyle.Font = new Font("ARIEL", 10, FontStyle.Bold);
                this.grd_cashbook.Rows[cashBookEnd-2].DefaultCellStyle.BackColor = Color.AliceBlue;
               this.grd_cashbook.Rows[cashBookEnd -2].DefaultCellStyle.Font = new Font("ARIEL", 10, FontStyle.Bold);
               this.grd_cashbook.Rows[cashBookEnd + 1].DefaultCellStyle.BackColor = Color.AliceBlue;
               this.grd_cashbook.Rows[cashBookEnd + 1].DefaultCellStyle.Font = new Font("ARIEL", 10, FontStyle.Bold);
               this.grd_cashbook.Rows[cashBookEnd + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
            catch (Exception)
            {

            }
        }
        private void BindCashBookGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("vid", typeof(int));
            dt.Columns.Add("head", typeof(string));
            dt.Columns.Add("nar", typeof(string));
            dt.Columns.Add("dr", typeof(double));
            dt.Columns .Add ("cr",typeof (double));
            dt.Columns.Add("chk", typeof(double));
            dt.Columns.Add("Sid", typeof(double));


            this.grd_cashbook.DataSource = dt;


         
        }
        private void RemoveZeros(PLABSn.DataGridViewPL grd)
        {
            try
            {
                DataTable dt = (DataTable)grd.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type tp = dt.Columns[j].DataType;

                        if (tp.Name == "Double" && PLABS.Utils.CnvToDouble(dt.Rows[i][j]) == 0)
                        {
                            dt.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void LastGrid()
        {
            try
            {
                string xmlData = this.getBlankXml();             
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("","LW",""));
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                grd_last.DataSource = ds.Tables[0];               
            }
            catch (Exception ex)
            {
                
            }
        }
        private void UpdateDtls()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "I");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                grd_last.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
               
            }
        }
        private void RemoveFinalized()
        {
            try
            {
                DataTable dt = (DataTable)grd_last.DataSource;
                dt.TableName = "Rslt";
                dt.DefaultView.RowFilter = "chk=0";
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "v_Xmldata", PLABS.CreateXml.FormatString(PLABS.Utils.CnvDataTableToXml(dt.DefaultView.ToTable(true, new string[] { "DETID" }), false)));
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "D");
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "D");
                if (xmlData.Length < 7)
                {                 
                    this.LastGrid();
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }

            }
            catch
            {
            }

        }
        private void SaveCashBook()
        {
            try
            {
                DataTable dt = (DataTable)grd_cashbook.DataSource;
                dt.TableName = "Rslt";
                dt.DefaultView.RowFilter = "chk=1";
                
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "v_Xmldata", PLABS.CreateXml.FormatString(PLABS.Utils.CnvDataTableToXml(dt.DefaultView.ToTable(true, new string[] { "VID","nar" }), false)));
                xmlData = PLABS.Utils.addNode(xmlData, "ad_date", this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode","CV");
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "I");
                if (xmlData.Length < 7)
                {
                    
                    this.CashBookPopulate("CB", "", this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }

            }
            catch
            {
            }
        }
        private void ConfirmGrid()
        {
            try
            {
                string xmlData = this.getBlankXml();
                 //dtp_curdt.Value.ToString("yyyy-MM-dd")
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("CM", "",""));
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                grd_confirm.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {

            }
        }
        private void Confirmation(string cnfirMode)
        {
            try
            {
                string xml = string.Empty;
                if (cnfirMode == "C")
                {
                    string selectRow = string.Empty;
                    foreach (DataGridViewRow row in this.grd_confirm.SelectedRows)
                    {
                        string id = PLABS.Utils.CnvToStr(row.Cells["txt_id_gvcfrm"].Value);
                        selectRow += "<Rslt><vid>" + id + "</vid></Rslt>";
                    }
                    xml = "<DocumentElement>" + selectRow + "</DocumentElement>";
                }
                else if (cnfirMode == "A")
                {
                    string allRows = string.Empty;
                    foreach (DataGridViewRow row in this.grd_confirm.Rows)
                    {
                        string id = PLABS.Utils.CnvToStr(row.Cells["txt_id_gvcfrm"].Value);
                        allRows += "<Rslt><vid>" + id + "</vid></Rslt>";
                    }
                    xml = "<DocumentElement>" + allRows + "</DocumentElement>";
                }
                else if (cnfirMode=="CP")
                {
                    string selectRow1 = string.Empty;
                    foreach (DataGridViewRow row in this.grd_cptlpnding.SelectedRows)
                    {
                        string id = PLABS.Utils.CnvToStr(row.Cells["txt_id_gvcfrms"].Value);
                        selectRow1 += "<Rslt><vid>" + id + "</vid></Rslt>";
                    }
                    xml = "<DocumentElement>" + selectRow1 + "</DocumentElement>";
 
                }
               
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "v_Xmldata", PLABS.CreateXml.FormatString(xml));
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "CR");
                xmlData = PLABS.Utils.addNode(xmlData, "ad_date", this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "I");
                if (xmlData.Length < 7)
                {

                    if (cnfirMode == "CP")
                    {
                        this.CptlPending();
                    }
                    else
                    {
                        this.ConfirmGrid();
                    }
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void PendingAllPopUp()
        {
            try
            {
                CO_007 obj = new CO_007();
                obj.ShowDialog();
                this.CashBookPopulate("CB", "", this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
            }
            catch (Exception ex)
            {
 
            }
        }
        private void GotoWeightLedger(int rowNum)
        {
            try
            {
                String id = null;
                String dtId = string.Empty;
                int Indx = this.tab_main.SelectedIndex;
                if (Indx ==1)
                {
                    id = PLABS.Utils.CnvToStr(this.grd_cashbook.Rows[rowNum].Cells["txt_sidc_gv"].Value);
                    dtId = PLABS.Utils.CnvToStr(this.grd_cashbook.Rows[rowNum].Cells["txt_vid_gv"].Value);
                }
                else if (Indx == 2)
                {
                     id = PLABS.Utils.CnvToStr(this.grd_confirm.Rows[rowNum].Cells["txt_sid_gv"].Value);
                     dtId = PLABS.Utils.CnvToStr(this.grd_confirm.Rows[rowNum].Cells["txt_id_gvcfrm"].Value);
                }
                else if (Indx == 3)
                {
                    id = PLABS.Utils.CnvToStr(this.grd_last.Rows[rowNum].Cells["txt_sidp_gv"].Value);
                    dtId = PLABS.Utils.CnvToStr(this.grd_last.Rows[rowNum].Cells["id"].Value);
                }
                else if (Indx == 4)
                {
                    id = PLABS.Utils.CnvToStr(this.grd_cptlpnding.Rows[rowNum].Cells["txt_addr_gv"].Value);
                    dtId = PLABS.Utils.CnvToStr(this.grd_cptlpnding.Rows[rowNum].Cells["txt_id_gvcfrms"].Value);
                }
                FL_002 obj = new FL_002();
                obj.IdFromFL_003 = id;
                obj.DtId = dtId;
                obj.ShowDialog();


            }
            catch (Exception ex)
            {
 
            }
        }
        private void TabChangFocus()
        {
            try
            {

                Indx = this.tab_main.SelectedIndex;
                if (Indx == 0)
                {
                    this.grd_gldrgtr.Focus();
                }
                else if (Indx == 1)
                {
                    this.grd_cashbook.Focus();
                }
                else if (Indx == 2)
                {
                    this.grd_confirm.Focus();
                }
                else if (Indx == 3)
                {
                    this.grd_last.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void LateAttendanceDtls()
        {
            string xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNode(xmlData,"as_mode","LA");
            xmlData = PLABS.Utils.addNode(xmlData, "ai_mnth",PLABS.Utils.CnvToStr(DateTime.Now.Month));
            xmlData = PLABS.Utils.addNode(xmlData, "ai_year",PLABS.Utils.CnvToStr(DateTime.Now.Year));            
            xmlData = this.CallWS(xmlData,"BizObj.DB_001,BizObj","LA");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            this.grd_late_att.DataSource = PLABS.Utils.GetDataTable(ds, 0);


        }
        private void CptlPending()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("", "CP", ""));
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                grd_cptlpnding.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {

            }
        }
        private void DayFinalize()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "DF");
                xmlData = PLABS.Utils.addNode(xmlData, "v_Xmldata", "");
                xmlData = PLABS.Utils.addNode(xmlData, "ad_date", this.dtp_curdt.Value.ToString("yyyy-MM-dd"));
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "I");
                if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Day Finalized");
                    this.loadControls();

                }
                else
                {
                    PLABS.MessageBoxPL.Show(xmlData);
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void ConfrmLteAtt(String ai_mnth,String ai_year)
        {
            String xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "LU");
            xmlData = PLABS.Utils.addNode(xmlData, "ad_dt", "");
            xmlData = PLABS.Utils.addNode(xmlData, "ai_mnth", ai_mnth);
            xmlData = PLABS.Utils.addNode(xmlData, "ai_year", ai_year);
            xmlData = PLABS.Utils.addNode(xmlData, "v_XmlData", "");
            xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "LU");
            if(xmlData.Length < 7)
            {
                PLABS.MessageBoxPL.Show("Confirmed","Information",PLABS.MessageBoxPL.PLMessageBoxButtons.OK,PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                this.grd_late_att.ClearControl(true);
            }
        }
        private void ConfrmTemplate()
        {
            String xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "CT");
            xmlData = PLABS.Utils.addNode(xmlData, "ad_date", "");
            xmlData = PLABS.Utils.addNode(xmlData, "v_XmlData", PLABS.CreateProcessXml.FormatString(grd_template.ControlValue));
            xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "I");
            if (xmlData.Length < 7)
            {
                PLABS.MessageBoxPL.Show("Confirmed", "Information", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                this.grd_template.ClearControl(true);
            }
        }
        private void SavePCRegister()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "I");
                xmlData = PLABS.Utils.addNode(xmlData, "v_xml", PLABS.CreateXml.FormatString(this.GetXml()));

                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "PI");

                if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Saved Successfully");
                    this.LoadControls();
                }
                else
                {
                    PLABS.MessageBoxPL.Show(xmlData);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private string GetXml()
        {
            try
            {
                DataTable dt = (DataTable)grd_pcregister.DataSource;
                string xmlData = "<ResultDS>";
                foreach (DataRow dr in dt.Rows)
                {
                    xmlData += "<Rslt><id>" + PLABS.Utils.CnvToStr(dr["id"]) + "</id><stus>" + PLABS.Utils.CnvToStr(dr["grnt"]) + "</stus></Rslt>";
                }
                xmlData += "</ResultDS>";

                return xmlData;
            }
            catch (Exception ex)
            {
                PLABS.MessageBoxPL.Show(ex.Message);
                return ex.Message;
            }
        }
        private bool IsValid()
        {
            try
            {
                if (grd_pcregister.Rows.Count == 0)
                {
                    PLABS.MessageBoxPL.Show("Invalid Data");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        private void LoadControls()
        {
            try
            {
                this.LoadCombo();
                string xmlData = this.getSelectArgsPC("LG");
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "PS");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);

                this.grd_pcregister.DataSource = dt;


            }
            catch (Exception ex)
            {

            }
        }
        private void LoadCombo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");

                dt.Rows.Add("Y", "YES");
                dt.Rows.Add("N", "NO");

                this.ddl_grnt_gv.DataSource = dt;
                this.ddl_grnt_gv.ValueMember = "id";
                this.ddl_grnt_gv.DisplayMember = "name";
            }
            catch (Exception ex)
            {

            }
        }
        private String getSelectArgsPC(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);

                return argXml;
            }
            catch (Exception ex)
            {
            }
            return string.Empty;
        }
        #endregion
    }
}
