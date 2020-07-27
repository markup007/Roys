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
    public partial class CO_008 : PLABS .MasterForm 
    {
        #region Globalvariable
        DataTable _dt = new DataTable();
        #endregion
        #region Properties
        public DataTable Dt
        {
            get { return _dt; }
            set { _dt = value; }
        }
        #endregion
        #region Constructor
        public CO_008()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
            this.grd_data.CellClick += new DataGridViewCellEventHandler(grd_data_CellClick);
            base.OnLoad(e);
        }

        void grd_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = this.grd_data.Columns[e.ColumnIndex].Name;
                if (colName == "btn_delete_gv")
                {
                    if (PLABS.MessageBoxPL.Show("Do You Really Want to Delete?", "Question", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Question) == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        this.Delete(e.RowIndex);
                    }
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
        #endregion
        #region Methods
        private void LoadControls()
        {
            try
            {
                
                this.LoadLoacalCombo();
                this.grd_data.DataSource = Dt;
                //string xmlData = this.getBlankXml();
                //xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "");
                //xmlData = this.CallWS(xmlData, "BizObj.CO_008,BizObj", "S");
                //DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                //if (ds.Tables.Count != 0)
                //{
                //    this.grd_data.DataSource = PLABS.Utils.GetDataTable(ds, 0);
                //}
            }
            catch (Exception ex)
            {

            }
        }
        private void LoadLoacalCombo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");

                dt.Rows.Add(0, "OFF");
                dt.Rows.Add(1, "WEEKLY");
                dt.Rows.Add(2, "MONTHLY");
                dt.Rows.Add(3, "YEARLY");
                dt.Rows.Add(4, "CUSTOM");

                ddl_typ_gv.DataSource = dt;
                ddl_typ_gv.ValueMember = "id";
                ddl_typ_gv.DisplayMember = "name";

            }
            catch (Exception ex)
            {

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
        private void Delete(int rowIndex)
        {
            try
            {
                string id = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowIndex].Cells["txt_id_gv"].Value);

                string xmlData = this.getBlankXml();

                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "D");
                xmlData = PLABS.Utils.addNode(xmlData, "ai_rmdr_id", id);

                xmlData = this.CallWS(xmlData, "BizObj.CO_008,BizObj", "D");

                if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Deleted Successfully");
                    this.LoadControls();
                }
                else 
                {
                    PLABS.MessageBoxPL.Show(xmlData);
                }

            }
            catch (Exception ex)
            {
                PLABS.MessageBoxPL.Show(ex.Message);
            }
        }
        #endregion
    }
}
