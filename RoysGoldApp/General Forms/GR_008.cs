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

    public partial class GR_008 : PLABS.MasterForm
    {
        #region GlobalVariables
        String _frmId = String.Empty;
        String _intrvlDays = String.Empty;

        public String IntrvlDays
        {
            get { return _intrvlDays; }
            set { _intrvlDays = value; }
        }
        #endregion
        #region Properties
        public String FrmId
        {
            get { return _frmId; }
            set { _frmId = value; }
        }
        #endregion
        #region Constructor
        public GR_008()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.SaveBeforeClick += new EventHandler(GR_008_SaveBeforeClick);
            this.SaveAfterClick += new EventHandler(GR_008_SaveAfterClick);
            this.ddl_type.SelectedIndexChanged += new EventHandler(ddl_type_SelectedIndexChanged);
            base.OnLoad(e);
        }

        void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                if (this.ddl_type.ControlValue == "4")
                {
                    this.lbl_mnth.Visible = true;
                    this.txt_mnth.Visible = true;
                    this.lbl_week.Visible = true;
                    this.txt_week.Visible = true;
                    this.lbl_day.Visible = true;
                    this.txt_days.Visible = true;
                    this.txt_mnth.Focus();
                }
                else
                {
                    this.lbl_mnth.Visible = false;
                    this.txt_mnth.Visible = false;
                    this.lbl_week.Visible = false;
                    this.txt_week.Visible = false;
                    this.lbl_day.Visible = false;
                    this.txt_days.Visible =false;
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        void GR_008_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {
 
            }
        }

        void GR_008_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (!isValidData())
                    this.CancelProcess = true;
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
        #region Events
        #endregion
        #region Methods
        private void LoadControls()
        {
            try
            {
                if (IntrvlDays != string.Empty)
                {
                    this.dtp_date.Value = DateTime.Now.AddDays(PLABS.Utils.CnvToInt(IntrvlDays));
                }
                else
                {
                    this.dtp_date.Value = DateTime.Now;
                }
                this.LoadLoacalCombo();
            }
            catch (Exception ex)
            {
 
            }
        }
        private void LoadLoacalCombo()
        {
            try
            {
                DataTable dt = this.GetComboTble();

                dt.Rows.Add(0, "OFF");
                dt.Rows.Add(1, "WEEKLY");
                dt.Rows.Add(2, "MONTHLY");
                dt.Rows.Add(3, "YEARLY");
                dt.Rows.Add(4, "CUSTOM");

                ddl_type.LoadData(dt, "name", "id");

                DataTable dt1 = this.GetComboTble();

                dt1.Rows.Add(0, "GENERAL");
                dt1.Rows.Add(1, "PERSONAL");

                ddl_mode.LoadData(dt1, "name", "id");
           
            }
            catch (Exception ex)
            {
 
            }
        }
        private DataTable GetComboTble()
        {
            DataTable dt = new DataTable();
            try
            {
                
                dt.Columns.Add("id");
                dt.Columns.Add("name");

                return dt;

            }
            catch (Exception ex)
            {
 
            }
            return dt;
        }
        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "ad_date",this.dtp_date .Value .ToString("yyyy-MM-dd"));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_frm_id", FrmId);
                xmlData = this.CallWS(xmlData, "BizObj.GR_008,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        
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
        private bool isValidData()
        {
            if (ddl_type.ControlValue == "4" && (txt_mnth.ControlValue == ""&& txt_week.ControlValue=="" &&txt_days .ControlValue==""))
            {
                PLABS.MessageBoxPL.Show("Please Enter No.of Months");
                this.txt_mnth.Focus();
                return false;
            }
            else
            {
                return true;
            }
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
                //BizObj.MG_001 objmaaddrgrup = new BizObj.MG_001();
                //xmlData =  objmaaddrgrup.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0009");
            }
            return xmlData;
        }
        #endregion
    }

}
