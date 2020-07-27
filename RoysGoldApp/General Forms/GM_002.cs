using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
    public partial class GM_002 : PLABS.MasterForm
    {
        #region Global Variables
        String masterKey = "0";
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public GM_002()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.loadControls();
                this.ExitBeforeClick += new EventHandler(gemnumast_ExitBeforeClick);
                this.SaveBeforeClick += new EventHandler(gemnumast_SaveBeforeClick);
                this.SaveAfterClick += new EventHandler(gemnumast_SaveAfterClick);
                this.DeleteBeforeClick += new EventHandler(gemnumast_DeleteBeforeClick);
                this.ClearAfterClick += new EventHandler(gemnumast_ClearAfterClick);
                this.btn_find_F.Click += new EventHandler(btn_find_Click);
                this.lst_search.DoubleClick += new EventHandler(lst_Search_DoubleClick);
                this.lst_search.KeyDown += new KeyEventHandler(lst_Search_KeyDown);
                this.btn_clear_F.Click += new EventHandler(btn_fClear_Click);
                this.ddl_project.KeyDown += new KeyEventHandler(ddl_project_KeyDown);
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "gemnumast", "0001");
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
                //ErrorLog.Insert(ex.Message, "gemnumast", "0010");
            }
        }

        private void btn_fClear_Click(object sender, EventArgs e)
        {
            this.txt_menu_F.ClearControl(true);
            this.ddl_project_F.ClearControl(true);
            this.loadGrid();
        }
        private void gemnumast_ExitBeforeClick(object sender, EventArgs e)
        {
        }

        private void gemnumast_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.isValidData())
                    this.CancelProcess = true;
                else
                {
                    if (this.FindID != "")
                        this.FindID = this.masterKey;
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"gemnumast", "0011");
            }
        }

        private void gemnumast_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"gemnumast", "0012");
            }
        }

        private void gemnumast_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.CancelProcess)
                    this.doClear();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"gemnumast", "0013");
            }
        }

        private void gemnumast_DeleteBeforeClick(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "gemnumast", "0014");
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
                //ErrorLog.Insert(ex.Message,"gemnumast", "0015");
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
                //ErrorLog.Insert(ex.Message, "gemnumast", "0016");
            }
        }
        void ddl_project_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    this.btn_clear.Focus();
            }
            catch
            {

            }
        }

        #endregion
        #region Methods
        private void loadControls()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LO", "", "", ""));
                xmlData = this.CallWS(xmlData, "BizObj.GM_002,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                this.ddl_project.LoadData(PLABS.Utils.GetDataTable(ds, 0), "proj_nam", "proj_id");
                this.ddl_project_F.LoadData(PLABS.Utils.GetDataTable(ds, 0).Copy(), "proj_nam", "proj_id");
                this.loadGrid();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "gemnumast", "0002");
            }
        }

        private void loadGrid()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG", "", txt_menu_F.ControlValue, ddl_project_F.ControlValue));
                xmlData = this.CallWS(xmlData, "BizObj.GM_002,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "gemnumast", "0003");
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
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("SE", PrimaryKeyID, "", ""));
                    xmlData = this.CallWS(xmlData, "BizObj.GM_002,BizObj", "S");
                    this.DataSource = xmlData;
                    this.ValueChangedStatus = false;
                    //this.txt_code.Focus();
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"gemnumast", "0004");
            }
        }

        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;
                xmlData = this.CallWS(xmlData, "BizObj.GM_002,BizObj", "I");
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
                //ErrorLog.Insert(ex.Message, "gemnumast", "0005");
            }
        }

        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_mnu_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.GM_002,BizObj", "D");
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
                //ErrorLog.Insert(ex.Message, "gemnumast", "0006");
            }
        }

        private void doClear()
        {
            try
            {
                masterKey = "0";
                //this.btn_saveas.Enabled = false;
                //this.txt_amount.Focus();
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "gemnumast", "0007");
            }
        }

        private void doFClear()
        {
        }
        private bool isValidData()
        {
            return true;
        }

        private String getSelectArgs(String as_mode, String ai_mnu_id, String as_mnu_nam, String ai_proj_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_mnu_id", ai_mnu_id);
                argXml = PLABS.Utils.addNode(argXml, "as_mnu_nam", as_mnu_nam);
                argXml = PLABS.Utils.addNode(argXml, "ai_proj_id", ai_proj_id);
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "gemnumast", "0010");
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
                //BizObj.GM_002 objgemnumast = new BizObj.GM_002();
                //xmlData = objgemnumast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "gemnumast", "0009");
            }
            return xmlData;
        }

        #endregion
    }
}

