using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace RoysGold
{
    public partial class GB_009 : PLABS .MasterForm
    {
        #region GlobalVaribles
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public GB_009()
        {
            InitializeComponent();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.btn_bckups.Click += new EventHandler(btn_bckups_Click);
            this.grd_data.CellClick += new DataGridViewCellEventHandler(grd_data_CellClick);
            this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
            this.DeleteBeforeClick += new EventHandler(GB_009_DeleteBeforeClick);
            this.DeleteAfterClick += new EventHandler(GB_009_DeleteAfterClick);
            base.OnLoad(e);
        }

       
        #endregion
        #region Events
        void grd_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grd_data.Columns[e.ColumnIndex].Name == "btn_restore_gv")
            {
                this.Restore(e.RowIndex);
            }
        }
        void btn_bckups_Click(object sender, EventArgs e)
        {
            try
            {
                if(BackUpValidation())
                {
                    this.BackUps("baburaj");
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        void GB_009_DeleteAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.DoDelete();
            }
            catch (Exception ex)
            {
 
            }
        }

        void GB_009_DeleteBeforeClick(object sender, EventArgs e)
        {
            this.FindID = "1";  
        }

        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
        }
        #endregion
        #region Method
        private void LoadControls()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("R"));
                xmlData = this.CallWS(xmlData, "BizObj.GB_009,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                this.grd_data .DataSource=dt;
            }
            catch (Exception ex)
            {
 
            }
        }
        private void BackUps(String DBName)
        {
            try
            {
                string xmlData = this.CallWS(this.txt_fileName.Text, "BizObj.BKP_001,BizObj", DBName);
                if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("DataBase Backup Has Been Completed Successfully!");
                    this.LoadControls();
                }
                else
                {

                    PLABS.MessageBoxPL.Show("The Operation Was Unsuccessfull");
                }
                
            }
            catch (Exception ex)
            {
                PLABS.MessageBoxPL.Show("The Operation Was Unsuccessfully");
            }
        }
    
        private bool BackUpValidation()
        {
            try
            {
                if (this.txt_fileName.Text == "")
                {
                    PLABS.MessageBoxPL.Show("Please Enter File Name");
                    txt_fileName.Focus();
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
        private String CallWS(String Xml, String ClassName, String Mode)
        {
            string xmlData = string.Empty;
            try
            {
                // For Using Webservice
                UtilsApp.CallBO objServ = new UtilsApp.CallBO();
                xmlData = objServ.CallWS(Xml, ClassName, Mode);

                // For Using Reference
                //BizObj.FL_002 obj = new BizObj.FL_002();
                //xmlData = obj.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0009");
            }
            return xmlData;
        }
        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_bckup_id", "");
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0010");
            }
            return string.Empty;
        }
        private void DoDelete()
        {
            try
            {
                string xml = "<root>";
                foreach (DataGridViewRow dr in grd_data.SelectedRows)
                {
                    string id = PLABS .Utils .CnvToStr(dr.Cells["txt_id_gv"].Value);
                    xml += "<row><id>" + id + "</id></row>";
                }
                xml += "</root>";
                string xmlData=this.getBlankXml() ;
                xmlData = PLABS.Utils.addNode(xmlData, "v_xmlData", PLABS.CreateXml.FormatString(xml));
               xmlData = this.CallWS(xmlData, "BizObj.GB_009,BizObj", "D");
               if (xmlData.Length < 7)
               {
                   PLABS.MessageBoxPL.Show("Delete Successfully");
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

        private string Restore(int rowNum)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "RD");
                String BACKID =PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_id_gv"].Value);
                xmlData = this.CallWS(BACKID, "BizObj.BKP_001,BizObj", "RD");
               
                if (xmlData == "1")
                {
                    this.LoadControls();
                    PLABS.MessageBoxPL.Show("Restore Operation Completed Successfully");
                }
                return xmlData;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }

        #endregion
    }
}
