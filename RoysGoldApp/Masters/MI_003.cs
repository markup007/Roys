using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RoysGold
{
    public partial class MI_003 : PLABS.MasterForm
    {
        #region Global Variable
        String masterKey = "0";
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public MI_003()
        {
            InitializeComponent();
            lst_search.HideSelection = false;
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.loadControls();
                this.ExitBeforeClick += new EventHandler(maitmmast_ExitBeforeClick);
                this.SaveBeforeClick += new EventHandler(maitmmast_SaveBeforeClick);
                this.SaveAfterClick += new EventHandler(maitmmast_SaveAfterClick);
                this.DeleteBeforeClick += new EventHandler(maitmmast_DeleteBeforeClick);
                this.ClearAfterClick += new EventHandler(maitmmast_ClearAfterClick);
                this.btn_find_F.Click += new EventHandler(btn_find_Click);
                this.lst_search.DoubleClick += new EventHandler(lst_Search_DoubleClick);
                this.lst_search.KeyDown += new KeyEventHandler(lst_Search_KeyDown);
                this.btn_clear_F.Click += new EventHandler(btn_fClear_Click);
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0001");
            }
            base.OnLoad(e);
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
                //ErrorLog.Insert(ex.Message, "maitmmast", "0010");
            }
        }

        private void btn_fClear_Click(object sender, EventArgs e)
        {
            this.txt_code_F.ClearControl(true);
            this.txt_name_F.ClearControl(true);
            this.loadGrid();
        }
        private void maitmmast_ExitBeforeClick(object sender, EventArgs e)
        {
        }

        private void maitmmast_SaveBeforeClick(object sender, EventArgs e)
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
                //ErrorLog.Insert(ex.Message,"maitmmast", "0011");
            }
        }

        private void maitmmast_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maitmmast", "0012");
            }
        }

        private void maitmmast_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.CancelProcess)
                    this.doClear();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maitmmast", "0013");
            }
        }

        private void maitmmast_DeleteBeforeClick(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0014");
            }
        }

        private void lst_Search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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
                //ErrorLog.Insert(ex.Message,"maitmmast", "0015");
            }
        }

        private void lst_Search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String Key = ((PLABSn.ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
                if (Key != string.Empty)
                {
                    this.masterKey = Key;
                    this.doFind(Key);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0016");
            }
        }

        #endregion
        #region Methods
        private void loadControls()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LO", "", "", ""));
                xmlData = this.CallWS(xmlData, "BizObj.MI_003,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);

                this.ddl_itm_typ.LoadData(PLABS.Utils.GetDataTable(ds, 0), "name", "id");
                //this.ddl_itmgld.LoadData(PLABS.Utils.GetDataTable(ds, 1), "name", "id");
                this.ddl_pur_status.AddRow("Yes", 1);
                this.ddl_pur_status.AddRow("No", 0);
                this.ddl_pur_status.SelectedValue = 0;

                this.loadGrid();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0002");
            }
        }

        private void loadGrid()
        {

            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG", txt_code_F.ControlValue, "", txt_name_F.ControlValue));
                xmlData = this.CallWS(xmlData, "BizObj.MI_003,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);

                lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
                // ListViewItem lst=new ListViewItem();
                for (int i = 0; i < lst_search.RowCount; i++)
                {
                    if (lst_search.Items[i].SubItems[4].Text == "1")
                    {
                        lst_search.Items[i].BackColor = Color.Silver;
                    }

                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0003");
            }
        }

        private void doFind(String PrimaryKeyID)
        {
            try
            {
                //this.btn_saveas.Enabled = true;
                //this.loadControls();
                // this.ddl_itmgld.ClearControl(true);
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
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("SE", "", PrimaryKeyID, ""));
                    xmlData = this.CallWS(xmlData, "BizObj.MI_003,BizObj", "S");
                    this.DataSource = xmlData;
                    this.ValueChangedStatus = false;
                    //this.txt_code.Focus();
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maitmmast", "0004");
            }
        }

        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;
                xmlData = this.CallWS(xmlData, "BizObj.MI_003,BizObj", "I");
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
                    this.loadGrid();
                    this.doClear();
                    this.txt_code.Focus();
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0005");
            }
        }

        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_itm_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.MI_003,BizObj", "D");
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
                //ErrorLog.Insert(ex.Message, "maitmmast", "0006");
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
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0007");
            }
        }

        private void doFClear()
        {
        }
        private bool isValidData()
        {
            return true;
        }

        private String getSelectArgs(String as_mode, String as_itm_code, String ai_itm_id, String as_itm_name)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "as_itm_code", as_itm_code);
                argXml = PLABS.Utils.addNode(argXml, "ai_itm_id", ai_itm_id);
                argXml = PLABS.Utils.addNode(argXml, "as_itm_name", as_itm_name);
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0010");
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
                //BizObj.MI_003 objmaitmmast = new BizObj.MI_003();
                //xmlData =  objmaitmmast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maitmmast", "0009");
            }
            return xmlData;
        }



        #endregion
    }
}

