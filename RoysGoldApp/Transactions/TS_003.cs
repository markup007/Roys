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
    public partial class TS_003 : PLABS.MasterForm
    {
        #region Global variable

        String masterKey = "0";
        string did = "0";

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public TS_003()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.loadControls();
            this.SaveAfterClick += new EventHandler(TS_003_SaveAfterClick);
            this.SaveBeforeClick += new EventHandler(TS_003_SaveBeforeClick);
            this.DeleteBeforeClick += new EventHandler(TS_003_DeleteBeforeClick);
            this.DeleteAfterClick += new EventHandler(TS_003_DeleteAfterClick);
            this.ClearAfterClick += new EventHandler(TS_003_ClearAfterClick);
            this.ExitBeforeClick += new EventHandler(TS_003_ExitBeforeClick);
            this.fnd_smth_id.AfterFind += new EventHandler(fnd_smth_id_AfterFind);
            this.txt_bord.TextChanged += new EventHandler(txt_bord_TextChanged);
            this.txt_cas_wt.TextChanged += new EventHandler(txt_cas_wt_TextChanged);
            this.ddl_mode.SelectedValueChanged += new EventHandler(ddl_mode_SelectedValueChanged);
            this.lst_search.KeyDown += new KeyEventHandler(lst_search_KeyDown);
            this.lst_search.DoubleClick += new EventHandler(lst_search_DoubleClick);
            this.ValueChangedStatus = false;
        }

      
        #endregion

        #region Events

        private void TS_003_ExitBeforeClick(object sender, EventArgs e)
        {
        }
        private void TS_003_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.CancelProcess)
                    this.doClear();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        private void TS_003_SaveBeforeClick(object sender, EventArgs e)
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
                throw (ex);
            }
        }
        private void TS_003_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void fnd_smth_id_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.smithselect();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        private void txt_cas_wt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_bord.Text != string.Empty)
                    this.calaculate();
            }
            catch (Exception ex)
            { throw (ex); }
        }
        private void txt_bord_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_cas_wt.Text != string.Empty)
                    this.calaculate();
            }
            catch (Exception ex)
            { throw (ex); }
        }
        private void txt_round_KeyDown(object sender, KeyEventArgs e)
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
                throw (ex);
            }
        }
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

            }
        }
        void ddl_mode_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (fnd_smth_id.ControlValue != string.Empty)
                {
                    this.smithselect();
                }
                else
                {
                    this.txt_cas_wt.Text = "0.00";
                }
            }
          
            catch (Exception ex)
            {
 
            }
        }
        void TS_003_DeleteAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
                this.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }
        void TS_003_DeleteBeforeClick(object sender, EventArgs e)
        {

        }


        #endregion

        #region Methods

        private void loadControls()
        {
            try
            {
                DataSet ds = this.GetDataSet("LO", "");
                this.fnd_smth_id.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
                this.fnd_item_id.LoadData(PLABS.Utils.GetDataTable(ds, 1), "prty", "nam", "id");
                this.LoadGrid();
                this.loadcmb();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LoadGrid()
        {
            try
            {
                DataSet ds = this.GetDataSet("LG","");
                this.lst_search .LoadData (PLABS .Utils .GetDataTable (ds,0));
            }
            catch (Exception ex)
            {
 
            }
        }
        private void loadcmb()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("mode");

            DataRow dr = dt.NewRow();
            dr["id"] = "0";
            dr["mode"] = "WEIGHT TO CASH";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["id"] = "1";
            dr["mode"] = "CASH TO WEIGHT";
            dt.Rows.Add(dr);


            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ID");
            dt1.Columns.Add("Type");

            DataRow dr1 = dt1.NewRow();
            dr1["ID"] = "0";
            dr1["Type"] = "Payment";
            dt1.Rows.Add(dr1);

            dr1 = dt1.NewRow();
            dr1["ID"] = "1";
            dr1["Type"] = "Reciept";
            dt1.Rows.Add(dr1);

            this.ddl_mode.LoadData(dt, "mode", "id");
            this.ddl_type.LoadData(dt1, "Type", "id");
        }
        private void smithselect()
        {
            DataSet ds = new DataSet();
            if (PLABS.Utils.CnvToInt(ddl_mode.SelectedValue) == 0)
                ds = this.GetDataSet("SW", this.fnd_smth_id.ControlValue);
            else
                ds = this.GetDataSet("SC", this.fnd_smth_id.ControlValue);
            DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
            Double data = PLABS.Utils.CnvToDouble(dt.Rows[0][0]);
            if (data < 0)
            {
                this.ddl_type.SelectedValue = 1;
                data = 0 - data;
            }
            else
                this.ddl_type.SelectedValue = 0;
            this.txt_cas_wt.Text = data.ToString();
        }
        private void calaculate()
        {
            CnvToCurncy obj = new CnvToCurncy();
            Double wtcs = PLABS.Utils.CnvToDouble(this.txt_cas_wt.Text);
            Double rate = PLABS.Utils.CnvToDouble(this.txt_bord.Text);
            Double tot = 0.00;
            if (PLABS.Utils.CnvToInt(ddl_mode.SelectedValue) == 0)
            {
                tot = wtcs * rate;
                this.txt_conv.Text = tot.ToString("F3");
                this.lbl_amtwrd.Text = obj.get(PLABS.Utils.CnvToDouble(this.txt_conv.Text));
            }
            else
            {
                tot = wtcs / rate;
                this.txt_conv.Text = tot.ToString("F3");
                this.lbl_amtwrd.Text = obj.get(PLABS.Utils.CnvToDouble(this.txt_cas_wt.Text));
            }
           


           

            
        }
        private void RoundOff()
        {
            //this.txt_grdttl.Text = (PLABS.Utils.CnvToDouble(this.txt_conv.Text) +
            //    PLABS.Utils.CnvToDouble(this.txt_round.Text)).ToString("F2");
        }

        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));

                xmlData = this.CallWS(xmlData, "BizObj.TS_003,BizObj", "I");
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
                    PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
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
                throw (ex);
            }
        }   
        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_mast_id", did);
                xmlData = this.CallWS(xmlData, "BizObj.TS_003,BizObj", "D");
                if (xmlData.Length < 7)
                {
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
                throw (ex);
            }
        } 
        private void doClear()
        {
            try
            {
                masterKey = "0";
                this.btn_save.Enabled = true;
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void doFind(String PrimaryKeyID)
        {
            try
            {
                did = PrimaryKeyID; 
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
                    //DataSet ds = this.GetDataSet("SE",PrimaryKeyID);
                    string xmlData = this.getBlankXml();
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("SE", PrimaryKeyID));
                    xmlData = this.CallWS(xmlData, "BizObj.TS_003,BizObj", "S");
                    //DataTable master = ds.Tables[0];
                    this.DataSource = xmlData;
                    

                    //this.fnd_smth_id.SelectedValue = PLABS.Utils.CnvToStr(master.Rows[0]["smth_id"]);
                    this.tb_main.SelectedTab = this.tp_create;

                  
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

        private String getSelectArgs(String as_mode, String ai_smtId)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_smth_id", ai_smtId);
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
                //BizObj.TS_003 objtrrawpurch = new BizObj.TS_003();
                //xmlData = objtrrawpurch.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0009");
            }
            return xmlData;
        }        
        public DataSet GetDataSet(String as_mode, String ai_smtId)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_smtId));
                xmlData = this.CallWS(xmlData, "BizObj.TS_003,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }

        #endregion
    }
}
