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
    public partial class CO_007 : PLABS.MasterForm
    {
        #region global variable

        //String[] _parameters = new String[3];

        #endregion

        #region properties

        //public String[] Parameters
        //{
        //    get { return _parameters; }
        //    set { _parameters = value; }
        //}

        #endregion

        #region Contructor

        public CO_007()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.loadControls();
            this.btn_exit.Click+=new EventHandler(btn_exit_Click);
            this.btn_load.Click += new EventHandler(btn_load_Click);
            this.btn_remov.Click += new EventHandler(btn_remov_Click);
        }
        void btn_remov_Click(object sender, EventArgs e)
        {
            RemovePending();
        }     
        #endregion

        #region events

        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadClick();
            }
            catch (Exception ex)
            { 
            }
        }

        #endregion

        #region Methods

        private void loadControls()
        {
            this.LoadPending();  
        }
        private DataSet GetDataSet(String as_mode, String ai_frm, String ai_to)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_frm, ai_to));
                xmlData = this.CallWS(xmlData, "BizObj.CO_007,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private String getSelectArgs(String as_mode, String ai_frm, String ai_to)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ad_from", ai_frm);
                argXml = PLABS.Utils.addNode(argXml, "ad_to", ai_to);
                
                return argXml;
            }
            catch (Exception ex)
            {
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
                //BizObj.CO_004 obj = new BizObj.CO_004();
                //xmlData = obj.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return xmlData;
        }
        private void LoadClick()
        {
            try
            {
                this.grd_data.ClearControl(true);
                DataSet ds= GetDataSet("LG",this.dtp_frm.Value.ToString("yyyy-MM-dd"),this.dtp_to.Value.ToString("yyyy-MM-dd"));
                this.PopulateGrid (PLABS.Utils.GetDataTable(ds, 0));

            }
            catch (Exception ex)
            {
 
            }
        }
        private void BindGrid()
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("dt", typeof(string));
                dt.Columns.Add("nam", typeof(string));
                dt.Columns.Add("dsc", typeof(string));
                dt.Columns .Add ("dr",typeof (double));
                dt.Columns.Add("cr", typeof(double));
                dt.Columns.Add("chk", typeof(double));
                dt.Columns.Add("id", typeof(int));
                this.grd_data.DataSource = dt;
            }
            catch (Exception ex)
            {
 
            }
        }
        private void PopulateGrid(DataTable dt)
        {
            try
            {
                DataTable source = (DataTable)this.grd_data.DataSource;

                foreach (DataRow dr in dt.Rows)
                {
                    DataRow newRow = source.NewRow();

                    newRow["dt"] = dr["dt"];
                    newRow["nam"] = dr["nam"];
                    newRow["dsc"] = dr["dsc"];
                    if (PLABS.Utils.CnvToDouble(dr["dr"]) == 0)
                    {
                        newRow["dr"] = DBNull.Value;
                    }
                    else
                    {
                        newRow["dr"] = dr["dr"];
                    }
                    if (PLABS.Utils.CnvToDouble(dr["cr"]) == 0)
                    {
                        newRow["cr"] = DBNull.Value;
                    }
                    else
                    {
                        newRow["cr"] = dr["cr"];
                    }
                    newRow["chk"] = dr["chk"];
                    newRow["id"] = dr["id"];
                    source.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void RemovePending()
        {
            try
            {
                DataTable dt = (DataTable)grd_data.DataSource;
                dt.TableName = "Rslt";
                dt.DefaultView.RowFilter = "chk=0";
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "v_Xmldata", PLABS.CreateXml.FormatString(PLABS.Utils.CnvDataTableToXml(dt.DefaultView.ToTable(true, new string[] { "ID" }), false)));
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "RP");
                xmlData = this.CallWS(xmlData, "BizObj.DB_001,BizObj", "D");
                if (xmlData.Length < 7)
                {
                    this.LoadPending();                  
                    
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
        private void LoadPending()
        {
            try
            {
                DataSet ds = GetDataSet("LO", "", "");
                if (ds.Tables.Count != 0)
                {
                    this.BindGrid();
                    this.dtp_frm.Value = PLABS.Utils.CnvToDate(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["frmdt"]);
                    this.dtp_to.Value = PLABS.Utils.CnvToDate(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["todt"]);
                    this.PopulateGrid(PLABS.Utils.GetDataTable(ds, 1));

                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}
