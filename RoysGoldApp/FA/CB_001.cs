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
    public partial class CB_001 : PLABS.MasterForm
    {
        #region Global variable

        String masterKey = "0";
        int _SelectedColIndex = -1;
        double _opnAmt = 0.00;

        #endregion
        
        #region Properties

        #endregion

        #region Constructor

        public CB_001()
        {
            InitializeComponent();
        }
		protected override void OnLoad(EventArgs e)
		{
			try
			{
                this.loadControls();
                this.ExitBeforeClick += new EventHandler(CB_001_ExitBeforeClick);
                this.SaveBeforeClick += new EventHandler(CB_001_SaveBeforeClick);
                this.SaveAfterClick += new EventHandler(CB_001_SaveAfterClick);
                this.ClearAfterClick += new EventHandler(CB_001_ClearAfterClick);
                this.rtxt_nara.KeyDown += new KeyEventHandler(rtxt_nara_KeyDown);
                this.lst_Data.DoubleClick += new EventHandler(lst_Data_DoubleClick);
                this.btn_remove.Click += new EventHandler(btn_remove_Click);
                this.lst_search.DoubleClick += new EventHandler(lst_search_DoubleClick);
                this.lst_search.KeyDown += new KeyEventHandler(lst_search_KeyDown);
                this.DeleteBeforeClick += new EventHandler(CB_001_DeleteBeforeClick);
                this.DeleteAfterClick += new EventHandler(CB_001_DeleteAfterClick);
                this.fnd_Acc_Head.AfterFind += new EventHandler(fnd_Acc_Head_AfterFind);
                this.ClearAfterClick+=new EventHandler(CB_001_ClearAfterClick);
                this.txt_amount.TextChanged += new EventHandler(txt_amount_TextChanged);
                this.ddl_type.SelectedIndexChanged += new EventHandler(ddl_type_SelectedIndexChanged);
                this.fnd_Acc_Head.Focus();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trrawpurch", "0001");
			}
			base.OnLoad(e);
        }

      

       
        protected override void OnActivated(EventArgs e)
        {
            this.fnd_Acc_Head.Focus();
            base.OnActivated(e);
        }
      
       
        #endregion

        #region Events

        void CB_001_ExitBeforeClick(object sender, EventArgs e)
        {
            
        }
        void CB_001_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.isValidData())
                    this.CancelProcess = true;

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"trsmthissrecmast", "0011");
            }
        }
        void CB_001_SaveAfterClick(object sender, EventArgs e)
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
        void CB_001_ClearAfterClick(object sender, EventArgs e)
        {
            this.doClear();
        }
        void rtxt_nara_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AddData();
                this.fnd_Acc_Head.Focus();
                //this.ddl_type.SelectedIndex = 0;
            }
            this.rtxt_nara.Text.Trim();
        }
        void lst_Data_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String Key = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
                if (Key != string.Empty)
                {
                    this.masterKey = Key;
                }
                this._SelectedColIndex = ((System.Windows.Forms.ListView)(sender)).FocusedItem.Index;
                this.LstDoubleClick();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "gefrmmast", "0016");
            }
        }
        void CB_001_DeleteAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
            }
            catch (Exception ex)
            {
 
            }
        }
        void CB_001_DeleteBeforeClick(object sender, EventArgs e)
        {

        }
        void lst_search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string UserId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[4].Text;
                if (UserId ==PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
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
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0016");
            }
        }
        void lst_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 string UserId = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[4].Text;
                 if (UserId == PLABS.Utils.CnvToStr(Properties.Settings.Default.id))
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
        void fnd_Acc_Head_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.HeadNameChanged();
                this.HeadBalanceUpdation();
                this.getTemplate();
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
                this.RevomeListViewItems();
                this.BalanceCalculation();
                this.HeadBalanceUpdation();
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
            dr["Type"] = "Payment(+)";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = "1";
            dr["Type"] = "Receipt  (-)";
            dt.Rows.Add(dr);
            return dt;
        }
        private void loadControls()
        {
            try
            {
                DataSet ds = this.GetDataSet("JP","");
                this.fnd_Acc_Head.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
                this.ddl_type.LoadData(open(), "Type", "ID");
                this.LoadGrid();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0002");
                throw (ex);
            }
        }
        private void LoadGrid()
        {
            try
            {
                DataSet ds = this.GetDataSet("LG", "");
                this.lst_search.LoadData(PLABS .Utils .GetDataTable (ds,0));
            }
            catch (Exception ex)
            {

            }
        }
        private void AddData()
        {
            if (this.masterKey == "0")
            {
                ListViewItem lst = new ListViewItem();
                if (doAddValidate())
                {
                    lst.Text = PLABS.Utils.CnvToStr(this.fnd_Acc_Head.SelectedValue);
                    lst.SubItems.Add(PLABS.Utils.CnvToStr(this.fnd_Acc_Head.SelectedCode));
                    if (this.ddl_type.SelectedIndex <= 0)
                    {
                        lst.SubItems.Add(PLABS.Utils.CnvToStr(this.txt_amount.Text));
                        lst.SubItems.Add("-");
                    }
                    else
                    {
                        lst.SubItems.Add("-");
                        lst.SubItems.Add(PLABS.Utils.CnvToStr(this.txt_amount.Text));
                    }
                    lst.SubItems.Add(PLABS.Utils.CnvToStr(this.rtxt_template.ControlValue));
                    this.lst_Data.Items.Add(lst);
                }
            }
            else
            {
                if (doAddValidate())
                {
                    this.lst_Data.BeginUpdate();
                    this.lst_Data.Items[_SelectedColIndex].SubItems[0].Text = PLABS.Utils.CnvToStr(this.fnd_Acc_Head.SelectedValue);
                    this.lst_Data.Items[_SelectedColIndex].SubItems[1].Text = this.fnd_Acc_Head.SelectedCode;
                    //this.lst_Data.Items[_SelectedColIndex].SubItems[4].Text = PLABS.Utils.CnvToStr(this.rtxt_template.ControlValue);
                    if (this.ddl_type.SelectedIndex <= 0)
                    {
                        this.lst_Data.Items[_SelectedColIndex].SubItems[2].Text = this.txt_amount.Text;
                        this.lst_Data.Items[_SelectedColIndex].SubItems[3].Text = "-";
                    }
                    else
                    {
                        this.lst_Data.Items[_SelectedColIndex].SubItems[2].Text = "-";
                        this.lst_Data.Items[_SelectedColIndex].SubItems[3].Text = this.txt_amount.Text;
                    }
                   
                    this.lst_Data.EndUpdate();
                    this.lst_Data.Refresh();
                    this.lbl_opnamt.ClearControl(true);
                    this.masterKey = "0";

                   
                }
            }
           
            this.fnd_Acc_Head.ClearControl(true);
            this.txt_amount.Clear();
            this.rtxt_nara.Text.Trim();
            this.lbl_opnamt.ClearControl(true);
            //this.ddl_type.SelectedIndex = -1;
            this.BalanceCalculation();

            this.fnd_Acc_Head.Focus();
        }
        private void LstDoubleClick()
        {
            if (this._SelectedColIndex > -1)
            {
                this.masterKey = PLABS.Utils.CnvToStr(this.lst_Data.Items[_SelectedColIndex].SubItems[0].Text);
                this.fnd_Acc_Head.SelectedCode = this.lst_Data.Items[_SelectedColIndex].SubItems[1].Text;
                this.fnd_Acc_Head.SelectedValue = this.lst_Data.Items[_SelectedColIndex].SubItems[0].Text;
                Double amt = PLABS.Utils.CnvToDouble(this.lst_Data.Items[_SelectedColIndex].SubItems[2].Text);
                if (amt > 0)
                {
                    this.ddl_type.ControlValue = "0";
                    this.txt_amount.Text = amt.ToString();
                }
                else
                {
                    this.ddl_type.ControlValue = "1";
                    this.txt_amount.Text = this.lst_Data.Items[_SelectedColIndex].SubItems[3].Text;
                }
                this.rtxt_template.ControlValue = this.lst_Data.Items[_SelectedColIndex].SubItems[4].Text;
            }
        }

        private void doSave()
        {
            try
            {
                //if (doValidate())
                //{
                    String xmlData = this.ProcessXml;
                    String xmlGvData = "<root>";
                    string journelType = string.Empty;
                    int subItem = 0;
                    int subItemOpp = 0;
                    string oppHeadId = string.Empty;
                    string as_template = string.Empty;
                    if (this.NumberOfCrDrValidation() == "0")
                    {
                       
                        subItem = 2;
                        subItemOpp = 3;
                        journelType="DR";
                    }
                    else if (this.NumberOfCrDrValidation() == "1")
                    {
                        subItemOpp = 2;
                        subItem = 3;
                        journelType="CR";
                    }
                    for (int i = 0; i < lst_Data.Items.Count; i++)
                    {
                       
                       
                        Double amt = PLABS.Utils.CnvToDouble(this.lst_Data.Items[i].SubItems[subItem].Text);
                        Double oppAmt = PLABS.Utils.CnvToDouble(this.lst_Data.Items[i].SubItems[subItemOpp].Text);
                        if (amt>0)
                        {
                            
                            xmlGvData += "<row>";
                            xmlGvData += "<headid>" + PLABS.Utils.CnvToStr(lst_Data.Items[i].SubItems[0].Text + "</headid>");
                            xmlGvData += "<amt>" + PLABS.Utils.CnvToStr(amt + "</amt>");
                            xmlGvData += "<tem>" + lst_Data.Items[i].SubItems[4].Text.Trim() + "</tem>";
                            xmlGvData += "</row>";
                        }
                        if (oppAmt > 0)
                        {
                            oppHeadId = PLABS.Utils.CnvToStr(this.lst_Data.Items[i].Text);
                            as_template =this.lst_Data.Items[i].SubItems[4].Text.Trim();
                        }
                       
                       
                    }
                    xmlGvData += "</root>";

                    xmlGvData = PLABS.CreateXml.FormatString(xmlGvData);
                    xmlData = PLABS.Utils.addNode(xmlData, "as_journel_typ", journelType);
                    xmlData = PLABS.Utils.addNode(xmlData, "ai_opp_head_id", oppHeadId);
                    xmlData = PLABS.Utils.addNode(xmlData, "as_template", as_template.Trim());
                    xmlData = PLABS.Utils.addNode(xmlData, "ai_dtlXml", xmlGvData);
                    xmlData = PLABS.Utils.addNode(xmlData, "ai_vou_mast", PLABS.Utils.CnvToStr(Convert.ToInt16(Enums.VoucherType.Journel)));
                    xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                    xmlData = this.CallWS(xmlData, "BizObj.CB_001,BizObj", "I");
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
                        this.doClear();
                    }
                    else
                    {
                        this.CancelProcess = true;
                        PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    }
                //}
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
                this.lst_Data.Items.Clear();
                this.fnd_Acc_Head.Focus();
                this.masterKey = "0";
                this.ddl_type.ControlValue = "0";
                this.LoadGrid();
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0007");
            }
        }
        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_vou_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.CB_001,BizObj", "D");
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
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0006");
            }
        }

        private bool doAddValidate()
        {
           
            if (PLABS.Utils.CnvToDouble(this.txt_amount.Text) <= 0)
            {
                MessageBox.Show("Enter Amount");
                this.txt_amount.Focus();
                return false;
            }
            else if (this.ddl_type.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Select DR & CR Type");
                this.ddl_type.Focus();
                return false;
            }
            else if (this.fnd_Acc_Head.ControlValue == string.Empty)
            {
                PLABS.MessageBoxPL.Show("Select A Head");
                this.fnd_Acc_Head.Focus();
                return false;
            }
            else if (this.NumberOfCrDrValidation() != this.ddl_type.ControlValue)
            {
                PLABS.MessageBoxPL.Show("Either Dr Entry Or Cr Entry can be Repeat");
                this.ddl_type.Focus();
                return false;
            }
            
            return true;
        }
        private bool doValidate()
        {
            if (this.lst_Data.Items.Count > 0)
            {
                int cr_count = 0;
                int dr_count = 0;
                Double dr_tot = 0;
                Double cr_tot = 0;
                for (int i = 0; i < this.lst_Data.Items.Count; i++)
                {
                    Double dr_amt = PLABS.Utils.CnvToDouble(this.lst_Data.Items[i].SubItems[2].Text);
                    Double cr_amt = PLABS.Utils.CnvToDouble(this.lst_Data.Items[i].SubItems[3].Text);

                    dr_tot = dr_tot + dr_amt;
                    cr_tot = cr_tot + cr_amt;
                    if (dr_amt > 0)
                    {
                        dr_count = dr_count + 1;
                    }
                    else
                    {
                        cr_count = cr_count + 1;
                    }
                }
                if (dr_tot != cr_tot)
                {
                    MessageBox.Show("Amount Invalid");
                    return false;
                }
                if (this.lst_Data.Items.Count != 1)
                {
                    if (dr_count >= 2)
                    {
                        if (cr_count > 1)
                        {
                            MessageBox.Show("Entry Error");
                            return false;
                        }
                    }
                    else
                    {
                        if (dr_count > 1)
                        {
                            MessageBox.Show("Entry Error");
                            return false;
                        }
                    }
                }
            }
            return true;
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
                return this.doValidate();
            }
        }
        private string NumberOfCrDrValidation()
        {
            try
            {
                int dr = 0;
                int cr = 0;

                foreach (ListViewItem item in lst_Data.Items)
                {
                    
                    if (PLABS.Utils.CnvToDouble(item.SubItems[2].Text) > 0)
                    {
                        dr++;
                    }
                    if (PLABS.Utils.CnvToDouble(item.SubItems[3].Text) > 0)
                    {
                        cr++;
                    }
                }
                if (dr > 1&&cr==1)
                {
                    return "0";
                }
                else if (cr > 1 && dr == 1)
                {
                    return "1";
                }
                else
                {
                    return this.ddl_type.ControlValue;
                }
               
                
            }
            catch (Exception ex)
            {
 
            }
            return "";
        }

        private String getSelectArgs(String as_mode, String ai_addr_id, String ai_usr_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", ai_usr_id);
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
                //BizObj.CB_001 objjour = new BizObj.CB_001();
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
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_addr_id,Properties .Settings .Default .id .ToString ()));
                xmlData = this.CallWS(xmlData, "BizObj.CB_001,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }
        private void RevomeListViewItems()
        {
            try
            {
                foreach (ListViewItem lst in lst_Data.SelectedItems)
                {   
                   lst.Remove();
                }
                lst_Data.Refresh();
            }
            catch (Exception ex)
            {

            }
        }
        private void doFind(String PrimaryKeyID)
        {
            try
            {
                //this.btn_saveas.Enabled = true;
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
                    string xmlData = this.getBlankXml();                    
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("SE", PrimaryKeyID, ""));
                    xmlData = this.CallWS(xmlData, "BizObj.CB_001,BizObj", "S");
                    //this.DataSource = xmlData;
                    DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);

                    this.lst_Data.LoadData(PLABS.Utils.GetDataTable(ds, 0));
                    this.tb_main.SelectedTab = this.tp_create;
                    this.ValueChangedStatus = true;
                    //this.txt_code.Focus();
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0004");
            }
        }
        private void HeadNameChanged()
        {
            try
            {
                this.lbl_opnamt.Text = PLABS.Utils.CnvToDouble(this.fnd_Acc_Head.SelectedRow["addr_code"]).ToString("N2");
                _opnAmt = PLABS.Utils.CnvToDouble(this.fnd_Acc_Head.SelectedRow["addr_code"]);
            }
            catch (Exception ex)
            {
 
            }
        }
        private void BalanceCalculation()
        {
            try
            {
                double pmnt=0.00;
                double rct=0.00;
                foreach (ListViewItem lst in lst_Data.Items)
                {
                   pmnt +=PLABS.Utils.CnvToDouble(lst.SubItems[2].Text);
                   rct += PLABS.Utils.CnvToDouble(lst.SubItems[3].Text);
                }

                double ttl = pmnt - rct;

                if (ttl < 0)
                {
                    this.txt_amount.Text = (-1 * ttl).ToString("F2");
                    this.ddl_type.ControlValue = "0";
                }
                else if(ttl > 0)
                {
                    this.txt_amount.Text = (ttl).ToString("F2");
                    this.ddl_type.ControlValue = "1";
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void HeadBalanceUpdation()
        
        {
            try
            {
                if (this.fnd_Acc_Head.ControlValue != String.Empty)
                {
                    double amt = 0.00;
                    double curAmt = PLABS.Utils.CnvToDouble(this.txt_amount.Text);
                    if (this.ddl_type.ControlValue == "1")
                    {
                        curAmt = -1 * curAmt;
                    }


                    foreach (ListViewItem lst in lst_Data.Items)
                    {
                        string id = lst.SubItems[0].Text;
                        if (fnd_Acc_Head.ControlValue == id)
                        {
                            amt += PLABS.Utils.CnvToDouble(lst.SubItems[2].Text) - PLABS.Utils.CnvToDouble(lst.SubItems[3].Text);
                        }
                    }

                    this.lbl_opnamt.Text = (curAmt + _opnAmt + amt).ToString("N2");
                }


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
        private void getTemplate()
        {
            this.rtxt_template.ClearControl(true);
            String xmlData = this.getBlankXml();
           xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LT", this.fnd_Acc_Head.ControlValue,""));  
            xmlData = this.CallWS(xmlData, "BizObj.CB_001,BizObj", "S");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            this.rtxt_template.ControlValue = PLABS.Utils.GetDataTable(ds, 0).Rows[0]["template"].ToString(); ;
        }
        #endregion
    }
}
