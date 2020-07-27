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
    public partial class FL_001 : PLABS.MasterForm
    {
        #region Global Variables
        #endregion
        #region Properties
        #endregion
        #region Constructors
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.btn_load.Click += new EventHandler(btn_load_Click);
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.fnd_addr.AfterFind += new EventHandler(fnd_addr_AfterFind);
            this.dtp_from.Leave += new EventHandler(dtp_from_Leave);
            this.dtp_to.Leave += new EventHandler(dtp_to_Leave);
            base.OnLoad(e);
        }





        public FL_001()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        void btn_exit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }
        void fnd_addr_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }

        void dtp_to_Leave(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }

        void dtp_from_Leave(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
        #region Common Methods
        private void LoadControls()
        {
            try
            {
               
                this.dtp_from.ControlValue = "04-01-2011";
                this.dtp_to.ControlValue = DateTime.Now.ToString("MMM-dd-yyyy");
                DataSet ds = this.GetDataSet("LO", "", "", "");
                this.fnd_addr.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0002");
            }
        }
        public void LoadGrid()
        {
            try
            {

                DataSet ds = this.GetDataSet("LG", this.fnd_addr.ControlValue, this.dtp_from.Value.ToString("yyyy-MM-dd"), this.dtp_to.Value.ToString("yyyy-MM-dd"));
                double opnAmt = PLABS.Utils.CnvToDouble(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["opnamt"]);
                double opnWt = PLABS.Utils.CnvToDouble(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["opnwt"]);
                this.grd_data.DataSource = PLABS.Utils.GetDataTable(ds, 1);
                Utils.CreateDatatable((DataTable)grd_data.DataSource, opnAmt, opnWt, "L");

                    foreach (DataGridViewRow grdRow in grd_data.Rows)
                {
                    foreach (DataGridViewCell grdCell in grdRow.Cells)
                    {
                        int colIndex = grdCell.ColumnIndex;
                        string colName =this.grd_data.Columns[colIndex].HeaderText;
                        if (colName == "Dr Amt" || colName == "Cr Amt" || colName == "Dr Wt" || colName == "Cr Wt")
                        {
                            if(PLABS .Utils .CnvToDouble (grdCell .Value)==0)
                            grdCell.Value = DBNull.Value;
                        }

                    }
                }
                int rowCount = this.grd_data.Rows.Count;
                this.grd_data.Rows[0].DefaultCellStyle.BackColor = Color.AliceBlue;
                this.grd_data.Rows[rowCount - 3].DefaultCellStyle.BackColor = Color.AliceBlue;
                this.grd_data.Rows[rowCount - 2].DefaultCellStyle.BackColor = Color.AliceBlue;
                this.grd_data.Rows[rowCount - 1].DefaultCellStyle.BackColor = Color.AliceBlue;

                this.grd_data.Rows[0].DefaultCellStyle.Font = new Font("ARIEL", 8, FontStyle.Bold);
                this.grd_data.Rows[rowCount - 3].DefaultCellStyle.Font = new Font("ARIEL", 8, FontStyle.Bold);
                this.grd_data.Rows[rowCount - 2].DefaultCellStyle.Font = new Font("ARIEL", 8, FontStyle.Bold);
                this.grd_data.Rows[rowCount - 1].DefaultCellStyle.Font = new Font("ARIEL", 8, FontStyle.Bold);

                //this.grd_data .Rows[rowCount].DefaultCellStyle .

                //object x = PLABS.Utils.GetDataTable(ds, 0).Compute("sum(cramt)", "");

            }
            catch (Exception ex)
            {

            }
        }
        private DataSet GetDataSet(String as_mode, String ai_addr_id, String ad_from, String ad_to)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_addr_id, ad_from, ad_to));
                xmlData = this.CallWS(xmlData, "BizObj.FL_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private String getSelectArgs(String as_mode, String ai_addr_id, String ad_from, String ad_to)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                argXml = PLABS.Utils.addNode(argXml, "ad_from", ad_from);
                argXml = PLABS.Utils.addNode(argXml, "ad_to", ad_to);
                //argXml = PLABS.Utils.addNode(argXml, "ai_shop_id", ai_shop_id);
                //argXml = PLABS.Utils.addNode(argXml, "ai_wt", ai_wt);
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0010");
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
                //BizObj.FL_001 obj = new BizObj.FL_001();
                //xmlData = obj.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0009");
            }
            return xmlData;
        }

        #endregion
    
    }
}
