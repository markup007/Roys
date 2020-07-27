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
    public partial class AF_001 : PLABS .MasterForm
    {
        #region Global Variables
        String _status = string.Empty;
        DateTime _dtme;
        #endregion
        #region Properties
        #endregion
        #region Constructors
        public AF_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls("L");
            this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
            this.SaveBeforeClick += new EventHandler(AF_001_SaveBeforeClick);
            this.SaveAfterClick += new EventHandler(AF_001_SaveAfterClick);
            this.ClearBeforeClick += new EventHandler(AF_001_ClearBeforeClick);
            this.ClearAfterClick += new EventHandler(AF_001_ClearAfterClick);
            this.dtp_curdate.Leave += new EventHandler(dtp_curdate_Leave);
            this.grd_data.CellEndEdit += new DataGridViewCellEventHandler(grd_data_CellEndEdit);
            this.ValueChangedStatus = true;
            this.btn_prev.Click += new EventHandler(btn_prev_Click);
            this.btn_next.Click += new EventHandler(btn_next_Click);
            base.OnLoad(e);
        }

        void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtp_curdate.Value = this.dtp_curdate.Value.AddDays(1);
                this.LoadControls("");
            }
            catch (Exception ex)
            {
                
                 
            }
        }

        void btn_prev_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtp_curdate.Value = this.dtp_curdate.Value.AddDays(-1);
                this.LoadControls("");
            }
            catch (Exception ex)
            {


            }
        }

        void grd_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName=this.grd_data.Columns[e.ColumnIndex].Name ;
                if (colName == "ddl_type_gv")
                {
                    this.GridColour();
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
        #region Events
        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          
        }
        void AF_001_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    this.DoSave();
                }
            }
            catch (Exception ex)
            {

            }
        }
        void AF_001_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                this.ValueChangedStatus = true;
            }
            catch (Exception ex)
            {

            }
        }
        void AF_001_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.DoClear();
            }
            catch (Exception ex)
            {

            }
        }
        void AF_001_ClearBeforeClick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        void dtp_curdate_Leave(object sender, EventArgs e)
        {
            try
            {
                this.LoadControls("");
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region Methods
        private void LoadControls(string mode)
        {
            try
            {
                this.ValueChangedStatus = true;
                if (mode == "L")
                {
                    this.dtp_curdate.Value = DateTime.Now;
                }
                else 
                {
                    if (string.IsNullOrEmpty(this.dtp_curdate.ControlValue))
                    {
                        this.dtp_curdate.Value = DateTime.Now;
                    }
                }

                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LO"));
                xmlData = this.CallWS(xmlData, "BizObj.AF_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                ds.DataSetName = "ResultDS";
                this.ddl_type_gv.DataSource = PLABS.Utils.GetDataTable(ds, 2);
                this.ddl_type_gv.DisplayMember = "nam";
                this.ddl_type_gv.ValueMember = "id";
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);

                this.grd_data.DataSource = dt;
                this.ValueChangedStatus = true;
                this._status = PLABS .Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 1).Rows[0]["status"]);
                _dtme = PLABS.Utils.CnvToDate(PLABS.Utils.GetDataTable(ds,3).Rows[0]["date"]);
                this.GridColour();
                

            }
            catch (Exception ex)
            {
                PLABS.MessageBoxPL.Show(ex.ToString());
            }
        }
        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ad_date", this.dtp_curdate.Value.ToString("yyyy-MM-dd"));


                //argXml = PLABS.Utils.addNode(argXml, "as_addr_code", as_addr_code);
                //argXml = PLABS.Utils.addNode(argXml, "ai_addr_grup_id", ai_addr_grup_id);
                //argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                //argXml = PLABS.Utils.addNode(argXml, "as_addr_nam", as_addr_nam);


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
        private void DoClear()
        {
            try
            {
                this.LoadControls("L");
            }
            catch (Exception ex)
            {
 
            }
        }
        private void DoSave()
        {
            try
            {
                
                DataTable dt = (DataTable)this.grd_data.DataSource;
                dt.TableName = "Rslt";
                dt = dt.DefaultView.ToTable(true, new string[] { "id", "typ", "dsc" });

                string xml = PLABS.Utils.CnvDataTableToXml(dt,false);
                xml = xml.Replace("DocumentElement", "ResultDS");

                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "I");
                xmlData = PLABS.Utils.addNode(xmlData, "ad_dt", this.dtp_curdate.Value.ToString("yyyy-MM-dd")+" "+DateTime.Now.ToString("HH:mm:ss"));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id",PLABS .Utils.CnvToStr(Properties.Settings .Default.id));
                xmlData = PLABS.Utils.addNode(xmlData, "v_xmlData", PLABS.CreateXml.FormatString(xml));

                xmlData = this.CallWS(xmlData, "BizObj.AF_001,BizObj", "I");

                if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Save Successfully");
                    this.LoadControls("L");
                }
                else
                {
                    PLABS.MessageBoxPL.Show(xmlData);
                    this.DoClear();
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void GridColour()
        {
            try 
            {
                foreach (DataGridViewRow dr in grd_data.Rows)
                {
                    if (dr.Index % 2 == 0)
                    {
                        dr.DefaultCellStyle.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        dr.DefaultCellStyle.BackColor = Color.White;
                    }


                    if (PLABS.Utils.CnvToStr(dr.Cells["ddl_type_gv"].Value) == "2")
                    {
                        dr.DefaultCellStyle.BackColor = Color.Silver;
                    }
                    else if (PLABS.Utils.CnvToStr(dr.Cells["ddl_type_gv"].Value) == "3")
                    {
                        dr.DefaultCellStyle.BackColor = Color.SkyBlue;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        private bool IsValidData()
        {
            try
            {
                if (_status == "U")
                {
                    if (Properties.Settings.Default.id == 4)
                    {
                        return true;
                    }
                    else
                    {
                        PLABS.MessageBoxPL.Show("Aleady Done");
                        return false;
                    }
                }
                else if ((this.dtp_curdate.Value.Date != _dtme.Date) && (Properties.Settings.Default.id != 4))
                {
                    PLABS.MessageBoxPL.Show("Error Date");
                    return false;
                }
                else 
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
 
            }
            return false;
        }
        #endregion
    }
}
