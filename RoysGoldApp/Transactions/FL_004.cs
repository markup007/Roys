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
   
    public partial class FL_004 :PLABS .MasterForm
    {
        #region Global Variables
        #endregion
        #region Properties
        #endregion
        #region Constructors
        public FL_004()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.txt_brdrt.TextChanged += new EventHandler(txt_brdrt_TextChanged);
            this.grd_data.CellClick += new DataGridViewCellEventHandler(grd_data_CellClick);
            base.OnLoad(e);
        }

        void grd_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grd_data.Columns[e.ColumnIndex].Name == "btn_cal")
            {
                this.CalculateCurval(e.RowIndex);
            }
        }

        void txt_brdrt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.GrValueCalculation();
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
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LG"));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_adde_id", "");
                xmlData = this.CallWS(xmlData, "BizObj.FL_004,BizObj", "S");
                DataSet ds = PLABS .Utils.CnvXMLToDataSet(xmlData);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                dt.Columns.Add("grval");
                dt.Columns["grval"].SetOrdinal(8);

                this.grd_data.DataSource = dt;
              
            }
            catch (Exception ex)
            {
 
            }
        }
        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ad_frm", "");
                argXml = PLABS.Utils.addNode(argXml, "ad_to", "");
                
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

        private void CalculateCurval(int rowNum)
        {
            String Lad_id = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_id"].Value);

            string xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LA"));
            xmlData = PLABS.Utils.addNode(xmlData, "ai_adde_id", Lad_id);
            xmlData = this.CallWS(xmlData, "BizObj.FL_004,BizObj", "S");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
            if (dt.Rows.Count != 0)
            {
                string curVAl = PLABS.Utils.CnvToStr(PLABS.Utils.CnvToDouble(dt.Rows[0]["crval"]),"F0");

                DataTable dt1 = (DataTable)this.grd_data.DataSource;
                dt1.Rows[rowNum]["crval"] = curVAl;
                curVAl = string.Empty;
            }
        }

        private void GrValueCalculation()
        {
            try
            {
                DataTable dt = (DataTable)this.grd_data.DataSource;

                foreach (DataRow dr in dt.Rows)
                {
                   double gld=(PLABS .Utils.CnvToDouble (dr["net_rt"]))/PLABS .Utils.CnvToDouble (dr["grt"]);
                   dr["grval"] = (gld * PLABS.Utils.CnvToDouble(this.txt_brdrt.Text)).ToString("F2");
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
    }
}
