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
    public partial class ML_001 : PLABS.MasterForm
    {
        #region Global variables
        String masterKey = "0";
        #endregion
        #region Constructors
        public ML_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.loadControls();
                this.ExitBeforeClick +=new EventHandler(ML_001_ExitBeforeClick);
                this.SaveBeforeClick +=new EventHandler(ML_001_SaveBeforeClick);
                this.SaveAfterClick +=new EventHandler(ML_001_SaveAfterClick);
                this.ClearAfterClick += new EventHandler(ML_001_ClearAfterClick);
                this.btn_F_clear.Click += new EventHandler(btn_F_clear_Click);
                this.btn_find.Click += new EventHandler(btn_find_Click);
                this.lst_search.KeyDown += new KeyEventHandler(lst_search_KeyDown);
                this.lst_search.DoubleClick += new EventHandler(lst_search_DoubleClick);
                this.KeyDown += new KeyEventHandler(ML_001_KeyDown);
                this.lnk_address.Click += new EventHandler(lnk_address_Click);
                this.lnk_rmdr.Click += new EventHandler(lnk_rmdr_Click);

               
            }
            catch(Exception ex)
            {
            }
            base.OnLoad(e);
        }
        protected override void OnActivated(EventArgs e)
        {
            this.fnd_addr.Focus();
            base.OnActivated(e);
        }
        #endregion Constructors
        #region Event
        void lst_search_DoubleClick(object sender, EventArgs e)
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
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0016");
            }
        }

        void lst_search_KeyDown(object sender, KeyEventArgs e)
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
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0015");
            }
        }
      
        void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                this.loadGrid();
                fnd_F_addr.Focus();
            }
            catch
            {
            }
        }

        void btn_F_clear_Click(object sender, EventArgs e)
        {
            this.fnd_F_addr.ClearControl(true);
            this.dp_F_date.ClearControl(true);
            this.lst_search.ClearControl(true);
            this.fnd_F_addr.Focus();
        }
        void lnk_rmdr_Click(object sender, EventArgs e)
        {
            
            try
            {
                GR_008 obj = new GR_008();
                obj.FrmId = "42";
                obj.IntrvlDays = "15";
                obj.ShowDialog();

            }
            catch
            {
            }
        }
        void lnk_address_Click(object sender, EventArgs e)
        {
            
            try
            {
                MA_002 obj = new MA_002();
                obj.ShowDialog();
                this.loadControls();
            }
            catch
            {
            }
        }

       
        void ML_001_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.CancelProcess)
                    this.doClear();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0013");
            }
        }

        void ML_001_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0012");
            }
        }

        void ML_001_SaveBeforeClick(object sender, EventArgs e)
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
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0011");
            }
        }

        void ML_001_ExitBeforeClick(object sender, EventArgs e)
        {
            
        }

        void ML_001_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                {
                    MA_002 obj = new MA_002();
                    obj.ShowDialog();
                    this.loadControls();
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R)
                {
                    GR_008 obj = new GR_008();
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Events
        #region Methods

        private void loadControls()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LO", "", "", ""));
                xmlData = this.CallWS(xmlData, "BizObj.ML_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                fnd_addr.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
                fnd_F_addr.LoadData(PLABS.Utils.GetDataTable(ds, 0).Copy(), "addr_code", "addr_nam", "addr_id");
                dp_date.ControlValue = DateTime.Now.Date.ToString();
                dp_F_date.ClearControl(true);
                this.loadGrid();
            }
            catch (Exception ex)
            {
            }
        }
        private void loadGrid()
        {
            try
            {
                string date=PLABS .Utils.CnvToDate(dp_F_date.ControlValue).ToString("yyyy-MM-dd") ;
                if (date == "0001-01-01")
                {
                    date = "";
                }
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG", "", fnd_F_addr.ControlValue,date));
                xmlData = this.CallWS(xmlData, "BizObj.ML_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0003");
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
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("SE",PrimaryKeyID, "", ""));
                    xmlData = this.CallWS(xmlData, "BizObj.ML_001,BizObj", "S");
                    this.DataSource = xmlData;
                    this.ValueChangedStatus = true;
                    tb_main.SelectedTab = this.tp_create;
                    this.fnd_addr.Focus();
                    
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0004");
            }
        }

        private void doSave()
        {
            try
            {
                String date = dp_date.Value.ToString("yyyy-MM-dd");
                string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "ad_land_dt", date);
                xmlData = this.CallWS(xmlData, "BizObj.ML_001,BizObj", "I");
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

                    this.fnd_addr.Focus();
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0005");
            }
        }
        private void doClear()
        {
            try
            {
               
                this.btn_save.Enabled = true;
                //this.btn_saveas.Enabled = false;
                //this.txt_amount.Focus();
                //this.ddl_amttype.SelectedValue = 1;
                //this.ddl_wttype.SelectedValue = 1;
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0007");
            }
        }

        private bool isValidData()
        {
            return true;
        }

        private String getSelectArgs(String as_mode, String ai_ma_land_id, String ai_addr_id, String ad_land_dt)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_ma_land_id", ai_ma_land_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                argXml = PLABS.Utils.addNode(argXml, "ad_land_dt", ad_land_dt);
                
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0010");
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
                //BizObj.MA_002 objmaaddrmast = new BizObj.MA_002();
                //xmlData =  objmaaddrmast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0009");
            }
            return xmlData;
        }


        #endregion Methods
    }
}
