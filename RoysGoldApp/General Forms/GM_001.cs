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
    public partial class GM_001 : PLABS.MasterForm
    {
        #region Global Variable
        #endregion
        #region Properties
        #endregion
        #region Constructors
        public GM_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.btn_save.Click += new EventHandler(btn_save_Click);
            base.OnLoad(e);
        }

     

        void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    this.DoSave();
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
        #region Events
        #endregion
        #region Menthods
        private void LoadControls()
        {
            try
            {
                this.LoadCombo();

                string xmlData = this.getSelectArgs("LG");
                xmlData = this.CallWS(xmlData, "BizObj.GM_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);

                this.grd_data.DataSource = dt;


            }
            catch (Exception ex)
            {
 
            }
        }
        private void LoadCombo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");

                dt.Rows.Add("Y", "YES");
                dt.Rows.Add("N", "NO");

                this.ddl_grnt_gv.DataSource = dt;
                this.ddl_grnt_gv.ValueMember = "id";
                this.ddl_grnt_gv.DisplayMember = "name";
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
            }
            return string.Empty;
        }
        private void DoSave()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode","I");
                xmlData = PLABS.Utils.addNode(xmlData, "v_xml", PLABS.CreateXml.FormatString(this.GetXml()));

                xmlData = this.CallWS(xmlData, "BizObj.GM_001,BizObj", "I");

                if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Saved Successfully");
                    this.LoadControls();
                }
                else
                {
                    PLABS.MessageBoxPL.Show(xmlData);
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private string GetXml()
        {
            try
            {
                DataTable dt = (DataTable)grd_data.DataSource;
                string xmlData = "<ResultDS>";
                foreach (DataRow dr in dt.Rows)
                {
                    xmlData += "<Rslt><id>" + PLABS.Utils.CnvToStr(dr["id"]) + "</id><stus>" + PLABS.Utils.CnvToStr(dr["grnt"]) + "</stus></Rslt>";
                }
                xmlData += "</ResultDS>";

                return xmlData;
            }
            catch (Exception ex)
            {
                PLABS.MessageBoxPL.Show(ex.Message);
                return ex.Message;
            }
        }
        private bool IsValid()
        {
            try
            {
                if (grd_data.Rows.Count == 0)
                {
                    PLABS.MessageBoxPL.Show("Invalid Data");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        #endregion
    }
}
