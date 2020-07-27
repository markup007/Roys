using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RoysGold
{
    public partial class DC_001 : PLABS.MasterForm
    {
        #region Global Variables
        string masterKey = string.Empty;
        #endregion
        #region Constructor
        public DC_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.loadControls();
            this.SaveBeforeClick += new EventHandler(DC_001_SaveBeforeClick);
            this.SaveAfterClick += new EventHandler(DC_001_SaveAfterClick);
            this.grd_data.CellEndEdit += new DataGridViewCellEventHandler(grd_data_CellEndEdit);
            base.OnLoad(e);
        }
        #endregion
        #region Events
        void grd_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double stk = 0.00;
            double shrt = 0.00;
            double srplx = 0.00;
            double cls = 0.00;
           string  sk = PLABS .Utils .CnvToStr(grd_data.Rows[e.RowIndex].Cells["txt_wt_gv"].Value);


           
           string sht = PLABS.Utils.CnvToStr(grd_data.Rows[e.RowIndex].Cells["txt_shrt_gv"].Value);


           string splx = PLABS.Utils.CnvToStr(grd_data.Rows[e.RowIndex].Cells["txt_srplx_gv"].Value);
           double shet = PLABS.Utils.CnvToDouble(grd_data.Rows[e.RowIndex].Cells["txt_sheetwt_gv"].Value);
            string colName = grd_data.Columns[e.ColumnIndex].HeaderText;
            if (colName == "SHORT" || colName == "SURPLUS")
            {
                if (sk != "")
                {
                    stk = Convert.ToDouble(grd_data.Rows[e.RowIndex].Cells["txt_wt_gv"].Value);
                }

                if (sht != "")
                {
                    shrt = Convert.ToDouble(grd_data.Rows[e.RowIndex].Cells["txt_shrt_gv"].Value);
                }
                if (splx != "")
                {
                    srplx = Convert.ToDouble(grd_data.Rows[e.RowIndex].Cells["txt_srplx_gv"].Value);
                }
                cls = stk - shrt + srplx+shet;
                grd_data.Rows[e.RowIndex].Cells["txt_cls_gv"].Value = cls;
            }
            //if(colName==)
        }

        void DC_001_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrgrup", "0012");
            }
        }

        void DC_001_SaveBeforeClick(object sender, EventArgs e)
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
                //ErrorLog.Insert(ex.Message,"maaddrgrup", "0011");
            }
        }
        #endregion
        #region method
        private void loadControls()
        {
            try
            {
                this.loadGrid();
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
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG"));
                xmlData = this.CallWS(xmlData, "BizObj.DC_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                DataTable grdSource = ds.Tables[0];
                this.grd_data.DataSource = grdSource;
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
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("SE"));
                    xmlData = this.CallWS(xmlData, "BizObj.DC_001,BizObj", "S");
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

                try
                {
                    MemoryStream memStream = new MemoryStream();
                    byte[] data = Encoding.Default.GetBytes(xmlData);
                    memStream.Write(data, 0, data.Length);
                    memStream.Position = 0;
                    XmlReader reader = XmlReader.Create(memStream);
                }
                catch 
                {

                    
                }
              


                xmlData = PLABS.Utils.addNode(xmlData, "ai_user", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                xmlData = this.CallWS(xmlData, "BizObj.DC_001,BizObj", "I");
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
                    PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    Properties.Settings.Default.id = -1;
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
                xmlData = this.CallWS(xmlData, "BizObj.DC_001,BizObj", "D");
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
                masterKey = "0";
                //this.btn_saveas.Enabled = false;
                //this.txt_amount.Focus();
                this.grd_data.ClearControl(true);
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

        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);

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
                //BizObj.DC_001 objmaitemgrpmast = new BizObj.DC_001();
                //xmlData = objmaitemgrpmast.GetData(Xml, ClassName, Mode);
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
