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
    public partial class CB_002 : PLABS.MasterForm
    {
        #region Global variable
        String masterKey = "0";
        int _SelectedColIndex = -1;
        int _count = 0;
        int _check = 0;
        string _headDescMaster = string.Empty;
        int _vou_id = -1;
        double _opnAmt = 0.00;
       
        #endregion

        #region Properties
        public string HeadDescMaster
        {
            set { _headDescMaster = value; }
            get { return _headDescMaster; }
        }
        #endregion

        #region Constructor

        public CB_002()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.KeyPreview = true;
                this.loadControls();
              
                this.ValueChangedStatus = true;
                this.ExitBeforeClick += new EventHandler(CB_002_ExitBeforeClick);
                this.SaveBeforeClick += new EventHandler(CB_002_SaveBeforeClick);
                this.SaveAfterClick += new EventHandler(CB_002_SaveAfterClick);
                this.ClearAfterClick += new EventHandler(CB_002_ClearAfterClick);
                this.rtxt_nara.KeyDown += new KeyEventHandler(rtxt_nara_KeyDown);
                this.btn_remove.Click += new EventHandler(btn_remove_Click);
                this.txt_amount.TextChanged += new EventHandler(txt_amount_TextChanged);
                this.ddl_type.SelectedIndexChanged += new EventHandler(ddl_type_SelectedIndexChanged);
                //this.lst_Data.DoubleClick += new EventHandler(lst_Data_DoubleClick);
               
                this.fnd_Acc_Head.AfterFind += new EventHandler(fnd_Acc_Head_AfterFind);
                this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
                this.grd_data.DoubleClick += new EventHandler(grd_data_DoubleClick);
                this.fnd_Acc_Head.Leave += new EventHandler(fnd_Acc_Head_Leave);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0001");
            }
            base.OnLoad(e);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                if (this.doValidate())
                {
                  
                        this.doSave();
                   
                }
                else 
                {
                    if (PLABS.MessageBoxPL.Show("Do You Really Want To Close", "Warning", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Question) == PLABS.MessageBoxPL.PLDialogResults.No)
                    {
                        e.Cancel = true;
                    }
                    
                }

            }
            catch (Exception ex)
            {

            }

            base.OnClosing(e);
        }
        #endregion

        #region Events

        void CB_002_ExitBeforeClick(object sender, EventArgs e)
        {

        }
        void CB_002_SaveAfterClick(object sender, EventArgs e)
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
        void CB_002_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                this.ValueChangedStatus = true;
                if (!this.doValidate())
                    this.CancelProcess = true;

            }
            catch (Exception ex)
            {

            }

        }
        void CB_002_ClearAfterClick(object sender, EventArgs e)
        {
            this.doClear();
        }
        void rtxt_nara_KeyDown(object sender, KeyEventArgs e)
        {
            //if (UserId == PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
            //{
                if (e.KeyCode == Keys.Enter)
                {
                    this.AddGrid();
                }
            //}
        }
        //void lst_Data_DoubleClick(object sender, EventArgs e)
        //{
        //    if (_SelectedColIndex > -1)
        //    {
        //        this.lst_Data.Items[_SelectedColIndex].BackColor = Color.Silver;
        //        this.masterKey = "0";
        //    }
        //    this._check = 0;
        //    this._SelectedColIndex = ((System.Windows.Forms.ListView)(sender)).FocusedItem.Index;
        //    this.LstDoubleClick();
        //}       
        void fnd_Acc_Head_AfterFind(object sender, EventArgs e)
        {
            try
            {
               this.HeadAfterFind();
                this.HeadBalanceUpdation();
                this.getTemplate();
            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (RemoveValidation())
                {
                    string Amt = lbl_opn.Text;
                    if (Amt == "")
                    {
                        this.GridDoubleClick(this.grd_data.CurrentRow.Index, this.grd_data.CurrentCell.ColumnIndex);
                    }
                    else
                    {
                        _opnAmt = 0.00;
                        this.GridDoubleClick(this.grd_data.CurrentRow.Index, this.grd_data.CurrentCell.ColumnIndex);
                    }
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
        }
        void fnd_Acc_Head_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.fnd_Acc_Head.ControlValue == string.Empty)
                    this.btn_save.Focus();
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {    
                 //string UserId = PLABS.Utils.CnvToStr(grd_data.SelectedCells

                if (RemoveValidation())
                {
                    this.doDelete();
                }
                else 
                {
                    PLABS.MessageBoxPL.Show("This Values Are Entered By Another User");
                }
                    
                
            }
            catch (Exception ex)
            {
 
            }
        }
        void txt_amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.HeadBalanceUpdation();
                this.AmountToWords(PLABS.Utils.CnvToDouble(this.txt_amount.Text));
            }
            catch (Exception ex)
            {
 
            }
        }
        void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.HeadBalanceUpdation();
            }
            catch (Exception ex)
            {
 
            }
        }

        #endregion

        #region Methods

        private DataTable open()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Type");

            DataRow dr = dt.NewRow();
            dr["ID"] = "0";
            dr["Type"] = "Payment";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = "1";
            dr["Type"] = "Receipt";
            
            dt.Rows.Add(dr);
            return dt;
        }
        private void loadControls()
        {
            try
            {
                DataSet ds = this.GetDataSet("PC", "");
                this.fnd_Acc_Head.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");
                this.ddl_type.LoadData(open(), "Type", "ID");
                this.ddl_type.SelectedIndex = 0;

                //string UserId = PLABS.Utils.CnvToStr(grd_data.Rows[0].Cells["txt_id_gv"].Value);
                //if (UserId == PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
                //{
                    this.loadGrid();
                //}
                if (HeadDescMaster != string.Empty)
                {
                    this.fnd_Acc_Head.ControlValue = "138";
                    this.HeadAfterFind();
                }
              
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0002");
                throw (ex);
            }
        }
        private void loadGrid()
        {
            try
            {
                DataSet ds = this.GetDataSet("PL", "");
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
               
                this.BindGrid();
                DataTable Source = (DataTable)this.grd_data.DataSource;
                //if (dt.Rows.Count > 0)
                //{
                //    double amt = PLABS.Utils.CnvToDouble(dt.Rows[0][0]);


                //    DataRow opn = Source.NewRow();
                //    opn["vou_id"] = DBNull.Value;
                //    opn["head_id"] = DBNull.Value;
                //    opn["name"] = "Opening Cash Balance";
                //    opn["nar"] = DBNull.Value;
                //    if (amt < 0)
                //    {
                //        opn["pmt"] = Math.Abs(amt);
                //    }
                //    else
                //    {
                //        opn["rpt"] = amt;
                //    }
                //    opn["hddesc"] = DBNull.Value;


                //    Source.Rows.Add(opn);
                //}
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        double amt = PLABS.Utils.CnvToDouble(dt.Rows[i]["amt"]);
                        DataRow dr = Source.NewRow();
                        dr["vou_id"] = PLABS.Utils.CnvToInt(dt.Rows[i]["vou_id"]);
                        dr["head_id"] = PLABS.Utils.CnvToInt(dt.Rows[i]["addr_id"]);
                        dr["name"] = PLABS.Utils.CnvToStr(dt.Rows[i]["addr_nam"]);
                        dr["nar"] = PLABS.Utils.CnvToStr(dt.Rows[i]["nar"]);
                        dr["tem"] = PLABS.Utils.CnvToStr(dt.Rows[i]["tem"]);
                        if (amt < 0)
                        {
                            dr["pmt"] = Math.Abs(amt);
                        }

                        else if(amt>0)
                        {
                            dr["rpt"] = amt;
                        }

                        dr["hddesc"] = PLABS.Utils.CnvToStr(dt.Rows[i]["hdsc"]);
                        dr["usr_id"] = PLABS.Utils.CnvToInt(dt.Rows[i]["usr_id"]);
                        Source.Rows.Add(dr);
                    }

                }

                //if (dt2.Rows.Count > 0)
                //{
                //    this.lbl_balan.Text = PLABS.Utils.CnvToStr(dt2.Rows[0][0]);
                //}

                this.BalanceCalculation();
                //this._count = this.lst_Data.Items.Count;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0003");
            }
        }
        private bool doAddValidate()
        {
            if (PLABS.Utils.CnvToDouble(this.txt_amount.Text) <= 0)
            {
                PLABS.MessageBoxPL.Show("Enter Amount");
                this.txt_amount.Focus();
                return false;
            }
            else if (this.ddl_type.SelectedValue == DBNull.Value)
            {
                PLABS.MessageBoxPL.Show("Select DR & CR Type");
                this.ddl_type.Focus();
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
        private bool doValidate()
        {

            if (PLABS.Utils.CnvToDouble(this.lbl_balan.Text) < 0)
            {
                PLABS.MessageBoxPL.Show("No Balance");
                this.fnd_Acc_Head.Focus();
                return false;
            }
            DataTable dt = (DataTable)this.grd_data.DataSource;

            dt.DefaultView.RowFilter = "Type=1";

            dt = dt.DefaultView.ToTable();

            if (dt.Rows.Count == 0)
            {
                PLABS.MessageBoxPL.Show("No Changes Made");
                this.fnd_Acc_Head.Focus();
                return false;
            }
           
            return true;
        }
        private void doSave()
        {
            try
            {

                //String xmlData = this.ProcessXml;
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_petty_id", this.FindID);
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "I");
                xmlData = PLABS.Utils.addNode(xmlData, "ai_dtlXml",PLABS.CreateXml.FormatString(this.GetGridXml()));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_vou_mast", PLABS.Utils.CnvToStr(Convert.ToInt16(Enums.VoucherType.PettyCash)));
                xmlData = PLABS.Utils.addNode(xmlData, "as_template", this.rtxt_template.ControlValue);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                xmlData = this.CallWS(xmlData, "BizObj.CB_002,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        String Key = this.masterKey;
                        this.ValueChangedStatus = true;
                        this.DoClear(this);
                        this.CancelProcess = true;
                    }
                    else
                    {
                        this.ValueChangedStatus = true;
                        this.DoClear(this);
                        this.CancelProcess = true;
                    }

                }
                else if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.doClear();
                    this.loadGrid();
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
                throw (ex);
            }
        }
        private void doClear()
        {
            try
            {
                //this.btn_saveas.Enabled = false;
                this.fnd_Acc_Head.ClearControl(true);
                this.txt_amount.ClearControl(true);
                this.ddl_type.ControlValue ="0";
                this.rtxt_nara.ClearControl(true);
                this.fnd_Acc_Head.Focus();
                this.lbl_opn.ClearControl(true);
                this.ValueChangedStatus = true;
                this.rtxt_template.ClearControl(true);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0007");
            }
        }
        private String getSelectArgs(String as_mode, String ai_addr_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", Properties.Settings.Default.id.ToString());
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
                //BizObj.CB_002 objjour = new BizObj.CB_002();
                //xmlData = objjour.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0009");
            }
            return xmlData;
        }
        public DataSet GetDataSet(String as_mode, String ai_addr_id)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_addr_id));
                xmlData = this.CallWS(xmlData, "BizObj.CB_002,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }
        private void doDelete()
        {
            try
            {
                // string UserId = PLABS.Utils.CnvToStr(dr.Cells["txt_vou_id_gv"].Value;
                //if (UserId ==PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
                //{
              
                double pmt=0.00;
                double rpt=0.00;
                string xml = "<ResultDS>";
                foreach (DataGridViewRow dr in this.grd_data.SelectedRows)
                {
                    if (PLABS.Utils.CnvToStr(dr.Cells["txt_vou_id_gv"].Value) != "-100")
                    {
                        pmt += PLABS.Utils.CnvToDouble(dr.Cells["txt_payment_gv"].Value);
                        rpt += PLABS.Utils.CnvToDouble(dr.Cells["txt_receipt_gv"].Value);
                       
                        string i = PLABS.Utils.CnvToStr(dr.Cells["txt_vou_id_gv"].Value);
                        xml += string.Format("<Rslt><id>{0}</id></Rslt>", i);
                    }
                    
                }
                xml += "</ResultDS>";
                if ((PLABS.Utils.CnvToDouble(this.lbl_balan.Text) - (rpt - pmt)) > 0)
                {
                    string xmlData = this.getBlankXml();
                    xmlData = PLABS.Utils.addNode(xmlData, "v_xml",PLABS .CreateXml.FormatString( xml));
                    //xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                    xmlData = this.CallWS(xmlData, "BizObj.CB_002,BizObj", "D");
                    //string UserId = PLABS.Utils.CnvToStr(grd_data.Rows[0].Cells["txt_id_gv"].Value);
                   
                   
                        this.loadControls();
                
                    //this.loadGrid();
                }
                else 
                {
                    PLABS.MessageBoxPL.Show("No Balance");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void HeadAfterFind()
        {
            try
            {
                double opn = PLABS.Utils.CnvToDouble(fnd_Acc_Head.SelectedRow["cd"]);
                this.lbl_opn.Text = opn.ToString("N2");
                _opnAmt = opn;
                if (fnd_Acc_Head.SelectedValue == "138")
                {
                    CO_003 obj = new CO_003();
                    if (HeadDescMaster != string.Empty)
                    {
                        obj.HeadDesc = HeadDescMaster;
                    }
                    obj.ShowDialog();
                    HeadDescMaster = obj.HeadDesc;
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void BindGrid()
        {
            try
            {
                //DataSet ds = new DataSet("ResultDS");
                DataTable dt = new DataTable("Rslt");

                dt.Columns.Add("vou_id", typeof(int));
                dt.Columns.Add("head_id", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("nar", typeof(string));
                dt.Columns.Add("pmt", typeof(double));
                dt.Columns.Add("rpt", typeof(double));
                dt.Columns.Add("hddesc", typeof(string));
                dt.Columns.Add("type", typeof(int));
                dt.Columns.Add("usr_id", typeof(int));
                dt.Columns.Add("tem", typeof(string));
                dt.Columns["type"].DefaultValue = -1;

                this.grd_data.DataSource = dt;

            }
            catch (Exception ex)
            {

            }
        }
        private void AddGrid()
        {
            try
            {
                DataTable dt = (DataTable)this.grd_data.DataSource;
               
                DataRow dr = dt.NewRow();

                dr["vou_id"] = _vou_id;
                dr["head_id"] = this.fnd_Acc_Head.ControlValue;
                dr["name"] = this.fnd_Acc_Head.SelectedRow["nam"];
                dr["nar"] = this.rtxt_nara.Text .Trim();
                if (this.ddl_type.ControlValue == "0")
                {
                    dr["pmt"] = PLABS.Utils.CnvToDouble(this.txt_amount.ControlValue);
                    dr["rpt"] = DBNull.Value;
                }
                else if (this.ddl_type.ControlValue == "1")
                {
                    dr["pmt"] = DBNull.Value;
                    dr["rpt"] = PLABS.Utils.CnvToDouble(this.txt_amount.ControlValue);
                }
                dr["hddesc"] = _headDescMaster;
                dr["Type"] = 1;
                dr["usr_id"] = PLABS.Utils.CnvToInt(Properties.Settings.Default.id);
                dr["tem"] = (rtxt_template.ControlValue).Trim();
                dt.Rows.Add(dr);
                _vou_id = -1;

               
                
                this.rtxt_nara.ClearControl(true);
                this.txt_amount.ClearControl(true);
                this.masterKey = "0";
                this.fnd_Acc_Head.ClearControl(true);
                this.fnd_Acc_Head.Focus();
                this.ValueChangedStatus = true;
                this.lbl_opn.ClearControl(true);
                this.rtxt_template.ClearControl(true);
                _headDescMaster = string.Empty;
                this.BalanceCalculation();


                
            }
            catch (Exception ex)
            {

            }
        }
        private void GridDoubleClick(int rowIndex, int colIndex)
        {
            try
            {
                _vou_id = PLABS.Utils.CnvToInt(this.grd_data.Rows[rowIndex].Cells["txt_vou_id_gv"].Value);
                this.fnd_Acc_Head.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowIndex].Cells["txt_head_id_gv"].Value);
                double amt = PLABS.Utils.CnvToDouble(this.grd_data.Rows[rowIndex].Cells["txt_payment_gv"].Value) -
                             PLABS.Utils.CnvToDouble(this.grd_data.Rows[rowIndex].Cells["txt_receipt_gv"].Value);

                this.txt_amount.Text = Math.Abs(amt).ToString("F2");

                if (amt < 0)
                {
                    this.ddl_type.ControlValue = "1";
                }
                else
                {
                    this.ddl_type.ControlValue = "0";
                }
                this.rtxt_nara.Text = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowIndex].Cells["txt_nar_gv"].Value);
                this._headDescMaster = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowIndex].Cells["txt_head_desc_gv"].Value);
                this.rtxt_template.ControlValue = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowIndex].Cells["txt_template_gv"].Value);
                this.grd_data.Rows.Remove(this.grd_data.Rows[rowIndex]);

                
                this.BalanceCalculation();
            }
            catch (Exception ex)
            {

            }
        }
        private void BalanceCalculation()
        {
            DataTable dt = (DataTable)this.grd_data.DataSource;

            double dr = PLABS.Utils.CnvToDouble(dt.Compute("SUM(pmt)",""));
            double cr = PLABS.Utils.CnvToDouble(dt.Compute("SUM(rpt)",""));

            this.lbl_balan.Text = (cr - dr).ToString("F2");
        }
        private String GetGridXml()
        {
            string xml = string.Empty;
            try
            {
                DataSet ds = new DataSet("ResultDS");
                DataTable dtXml = new DataTable("Rslt");
                ds.Tables.Add(dtXml);
                DataTable dt = (DataTable)this.grd_data.DataSource;
                dt.DefaultView.RowFilter = "type=1";
                dtXml = dt.DefaultView.ToTable();
               
                xml = PLABS.Utils.CnvDataTableToXml(dtXml.DefaultView.ToTable(false, new string[] { "vou_id", "head_id", "nar", "pmt", "rpt", "hddesc","tem" }), false);

                return xml;
                 
            }
            catch (Exception ex)
            {
 
            }

            return xml;

        }
        private void HeadBalanceUpdation()
        {
            try
            {
                DataTable dt = (DataTable)this.grd_data.DataSource;

                DataTable dtAmt = dt.Copy();

                dtAmt.DefaultView.RowFilter = "type=1";

                dtAmt = dtAmt.DefaultView.ToTable();



              double amt = PLABS.Utils.CnvToDouble(dtAmt.Compute("SUM(pmt)", string.Format("head_id={0}", this.fnd_Acc_Head.ControlValue)))
                    - PLABS.Utils.CnvToDouble(dtAmt.Compute("SUM(rpt)", string.Format("head_id={0}", this.fnd_Acc_Head.ControlValue)));

              double curAmt = PLABS.Utils.CnvToDouble(this.txt_amount.Text);
              if (this.ddl_type.ControlValue == "1")
              {
                  curAmt = -1 * curAmt;
              }
              string Amt1 = PLABS.Utils.CnvToStr(_opnAmt);
              //   string Amt = lbl_opn.Text;
                 //if (Amt == "")
                 //{
                     this.lbl_opn.Text = (_opnAmt + amt + curAmt).ToString("N2");
                     //PLABS .Utils .CnvToDouble (dt.Compute("SUM(rpt)","")))
                 //}
                 //else
                 //{
                 //    this.lbl_opn.Text = PLABS.Utils.CnvToStr(_opnAmt);
                 //}
            }
            catch (Exception ex)
            {
 
            }
        }
        private void AmountToWords(double amt)
        {
            try
            {
                CnvToCurncy obj = new CnvToCurncy();
                this.lbl_amtwrd.Text = obj.get(amt);
            }
            catch (Exception ex)
            {
 
            }
        }
        private bool RemoveValidation()
        {
            bool valid = false;
            try
            {
                foreach (DataGridViewRow row in this.grd_data.SelectedRows)
                {
                    string usrId = PLABS.Utils.CnvToStr(Properties.Settings.Default.id);
                    string curUsrId = PLABS.Utils.CnvToStr(row.Cells["txt_id_gv"].Value);
                    if (usrId == curUsrId)
                    {
                        valid = true;
                    }
                    else 
                    {
                        valid = false;
                        return valid;
                    }
                    
                }
                return valid;
            }
            catch (Exception ex)
            {
 
            }
            return valid;
        }
        private void getTemplate()
        {
            String xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LT", this.fnd_Acc_Head.ControlValue));
            xmlData = this.CallWS(xmlData, "BizObj.CB_002,BizObj","S");
           DataSet ds=PLABS.Utils.CnvXMLToDataSet(xmlData);
           this.rtxt_template.ControlValue = PLABS.Utils.GetDataTable(ds, 0).Rows[0]["template"].ToString(); ;
        }
        #endregion
    }
}
