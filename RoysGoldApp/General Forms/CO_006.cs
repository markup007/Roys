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
    public partial class CO_006 : PLABS.MasterForm
    {
        #region global variable

        String[] _parameters = new String[4];
        int _month=0;
        #endregion

        #region properties

        public String[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        #endregion

        #region Contructor

        public CO_006()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.loadControls();
            this.btn_exit.Click+=new EventHandler(btn_exit_Click);
            this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
            this.grd_data.CellDoubleClick += new DataGridViewCellEventHandler(grd_data_CellDoubleClick);
            this.grd_data.KeyDown += new KeyEventHandler(grd_data_KeyDown);
            this.btn_prvmth.Click += new EventHandler(btn_prvmth_Click);
          
        }

        void btn_prvmth_Click(object sender, EventArgs e)
        {
            try
            {
              _month ++;
                string frmdt=DateTime .Now.AddMonths(-_month).ToString("yyyy-MM-dd");
                DataSet ds = this.GetDataSet("DM", frmdt,"", Parameters[3]);
              DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
              this.grd_data.DataSource = dt;
              this.ZeroRemove();

            }
            catch (Exception ex)
            {
 
            }
        }

      

      
        #endregion

        #region events

        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void grd_data_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GotoWeightLeger(this.grd_data.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {

            }
        }

        void grd_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.GotoWeightLeger(e.RowIndex);
            }
            catch (Exception ex)
            {

            }
        }

        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Methods

        private void loadControls()
        {
            try
            {
                DataSet ds = this.GetDataSet(Parameters[0], Parameters[1], Parameters[2],Parameters[3]);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                this.grd_data.DataSource = dt;
                this.ZeroRemove();
              
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private DataSet GetDataSet(String as_mode, String ai_frm, String ai_to,String ai_addr_id)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_frm, ai_to, ai_addr_id));
                xmlData = this.CallWS(xmlData, "BizObj.CO_005,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
              
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private String getSelectArgs(String as_mode, String ai_frm, String ai_to, String ai_addr_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_frm", ai_frm);
                argXml = PLABS.Utils.addNode(argXml, "ai_to", ai_to);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
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
        //private void RemoveZerosAndNulls()
        //{
        //    try
        //    {
        //        DataTable dt = (DataTable)this.grd_data.DataSource;


        //        dt.DefaultView.RowFilter = "dft<>NULL OR dft<>0";

        //        DataTable newTble = dt.DefaultView.ToTable();

        //        this.grd_data.DataSource = newTble;

        //        //for (int i = 0; i < dt.Rows.Count; i++)
        //        //{
        //        //    double wt = PLABS.Utils.CnvToDouble(dt.Rows[i]["nw"]);
        //        //    double dft = PLABS.Utils.CnvToDouble(dt.Rows[i]["dft"]);

        //        //    if (wt == 0 && dft == 0)
        //        //    {
        //        //        dt.Rows.RemoveAt(i);
        //        //    }
        //        //}

        //        //this.grd_data.DataSource = dt;

        //    }
        //    catch (Exception ex)
        //    {
 
        //    }
        //}
        private void ZeroRemove()
        {
            try
            {
               
                foreach (DataGridViewRow dr in this.grd_data.Rows)
                {
                    foreach (DataGridViewCell cell in dr.Cells)
                    {
                        int colIndex = cell.ColumnIndex;
                        string header = grd_data.Columns[colIndex].HeaderText;
                        if (header == "PAYMENT" || header == "RECEIPT")
                        {
                            if (PLABS.Utils.CnvToDouble(cell.Value) == 0)
                            {
                                cell.Value = DBNull.Value;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void GotoWeightLeger(int rowNum)
        {
            try
            {
                FL_002 obj = new FL_002();
                obj.IdFromFL_003 =PLABS.Utils .CnvToStr (this.grd_data.Rows[rowNum].Cells["txt_id_gv"].Value);
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
    }
}
