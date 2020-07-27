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
    public partial class CO_005 : PLABS.MasterForm
    {
        #region global variable

        String[] _parameters = new String[3];

        #endregion

        #region properties

        public String[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        #endregion

        #region Contructor

        public CO_005()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.loadControls();
            this.btn_exit.Click+=new EventHandler(btn_exit_Click);
            this.grd_data.CellDoubleClick += new DataGridViewCellEventHandler(grd_data_CellDoubleClick);
            this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
        }

     

      

        #endregion

        #region events

        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void grd_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.CallPopup(e.RowIndex);
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
                DataSet ds = this.GetDataSet(Parameters[0], Parameters[1], Parameters[2]);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                this.grd_data.DataSource = dt;
              
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private DataSet GetDataSet(String as_mode, String ai_frm, String ai_to)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_frm, ai_to));
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
        private String getSelectArgs(String as_mode, String ai_frm, String ai_to)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_frm", ai_frm);
                argXml = PLABS.Utils.addNode(argXml, "ai_to", ai_to);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", "");
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
        private void CallPopup(int rowNum)
        {
            try
            {
               

                string[] param = new string[4];

                param[0] = "DI";
                param[1] = Parameters[1];
                param[2] = Parameters[2];
                param[3] = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_id_gv"].Value);

                CO_006 objpopup = new CO_006();

                objpopup.Parameters = param;

                objpopup.ShowDialog();
            }
            catch (Exception ex)
            {
 
            }
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
        #endregion
    }
}
