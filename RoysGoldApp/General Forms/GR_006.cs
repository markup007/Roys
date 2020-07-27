using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
	public partial class GR_006 : PLABS.MasterForm
    {
        #region Global variable
        String masterKey = "0";

        #endregion
        #region Properties
        #endregion


        public GR_006()
		{
			InitializeComponent();
		}
		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.loadControls();
				this.ExitBeforeClick += new EventHandler(geusrrolemast_ExitBeforeClick);
				this.SaveBeforeClick += new EventHandler(geusrrolemast_SaveBeforeClick);
				this.SaveAfterClick += new EventHandler(geusrrolemast_SaveAfterClick);
				;
				this.ClearAfterClick  += new EventHandler(geusrrolemast_ClearAfterClick);				
               
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0001");
			}
			base.OnLoad(e);
		}

		#region Events

		private void geusrrolemast_ExitBeforeClick(object sender, EventArgs e)
		{
 		}

		private void geusrrolemast_SaveBeforeClick(object sender, EventArgs e)
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
				 //ErrorLog.Insert(ex.Message,"geusrrolemast", "0011");
			}
		}

		private void geusrrolemast_SaveAfterClick(object sender, EventArgs e)
		{
			try
			{
				this.doSave();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"geusrrolemast", "0012");
			}
		}

		private void geusrrolemast_ClearAfterClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.CancelProcess)
				this.doClear();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"geusrrolemast", "0013");
			}
		}

		#endregion

		#region Methods
		private void loadControls()
		{
			try
			{
				string xmlData = this.getBlankXml();
				 xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LO",""));
                 xmlData = this.CallWS(xmlData, "BizObj.GR_006,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                this.ddl_user.LoadData(PLABS.Utils.GetDataTable(ds, 0),"usr_nam", "usr_id");                
               
            }
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0002");
			 }
		}
		private void loadGrid()
		{
			try
			{
				string xmlData = this.getBlankXml();
                if (ddl_user.ControlValue!="")
                {
                    xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG", ddl_user.ControlValue));
                    xmlData = this.CallWS(xmlData, "BizObj.GR_006,BizObj", "S");
                    DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                    DataTable dtDate= PLABS.Utils.GetDataTable(ds, 1);
                    this.gv_frm.DataSource = PLABS.Utils.GetDataTable(ds, 0);
                    this.gv_ldgr.DataSource = PLABS.Utils.GetDataTable(ds, 2);
                    this.UsrPrvlgDate.Value = PLABS.Utils.CnvToDate(dtDate.Rows[0]["prvlg_dt"]);
                }
            }
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0003");
			}
		}
        private void doSave()
        {
            try
            {
                string xmlData = this.getBlankXml(); 

                string xmlGvData = "<root>";
                string mode = "I";
                for (int i = 0; gv_frm.Rows.Count > i; i++)
                {
                    if (PLABS.Utils.CnvToInt(gv_frm.Rows[i].Cells[3].Value) > -1)
                        mode = "U";
                    if (PLABS.Utils.CnvToStr(gv_frm.Rows[i].Cells[2].Value) == "True" || PLABS.Utils.CnvToInt(gv_frm.Rows[i].Cells[2].Value)==1)
                    { 
                        xmlGvData += "<row>";
                        xmlGvData += "<rptid>" + PLABS.Utils.CnvToStr(gv_frm.Rows[i].Cells[0].Value + "</rptid>");
                       
                        xmlGvData += "</row>";
                    }
                }
                xmlGvData += "</root>";

                string xmlLGData = "<root>";
                string mode1 = "I";
                for (int i = 0; gv_ldgr.Rows.Count > i; i++)
                {
                    if (PLABS.Utils.CnvToInt(gv_ldgr.Rows[i].Cells[4].Value) > -1)
                        mode1 = "U";
                    if (PLABS.Utils.CnvToStr(gv_ldgr.Rows[i].Cells[3].Value) == "True" || PLABS.Utils.CnvToInt(gv_ldgr.Rows[i].Cells[3].Value) == 1)
                    {
                        xmlLGData += "<row>";
                        xmlLGData += "<addr>" + PLABS.Utils.CnvToStr(gv_ldgr.Rows[i].Cells[0].Value + "</addr>");

                        xmlLGData += "</row>";
                    }
                }
                xmlLGData += "</root>";

                xmlGvData = PLABS.CreateXml.FormatString(xmlGvData);

                xmlLGData = PLABS.CreateXml.FormatString(xmlLGData);
                xmlData = PLABS.Utils.addNodes(xmlData, getSaveArgs(mode, ddl_user.ControlValue,(UsrPrvlgDate.Value.ToString("yyyy_MM_dd")), xmlGvData, xmlLGData));
                
                xmlData = this.CallWS(xmlData, "BizObj.GR_006,BizObj", "I");
                
                 if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
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
                //ErrorLog.Insert(ex.Message, "geusrrolemast", "0005");
            }
        }		
		private void doClear()
		{
			try
			{
			masterKey = "0";
			//this.btn_saveas.Enabled = false;
				//this.txt_amount.Focus();
            this.loadControls();
				this.ValueChangedStatus = false;
                this.gv_frm.ClearControl(true);
                this.gv_ldgr.ClearControl(true);
                this.UsrPrvlgDate.Value = DateTime.Now;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0007");
			}
		}		
		private bool isValidData()
		{
			return true;
		}
		private String getSelectArgs( String as_mode,string ai_usr_id)
        {
			 try
			 {
				 String argXml = this.getBlankXml(); 
				 argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode );
                 argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", ai_usr_id);
                return argXml;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0010");
			}
				return string.Empty;
		}
        private string getSaveArgs(string as_mode,string ai_usr_id,string date,string vxml,string lxml)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", ai_usr_id);
                argXml = PLABS.Utils.addNode(argXml, "ad_rpt_date", PLABS.Utils.CnvToStr(date));
                argXml = PLABS.Utils.addNode(argXml, "v_XmlDtl", vxml);
                argXml = PLABS.Utils.addNode(argXml, "ldg_Dtl", lxml);
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "geusrrolemast", "0010");
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
                //BizObj.GR_005 objgeusrrolemast = new BizObj.GR_005();
                //xmlData =  objgeusrrolemast.GetData(Xml, ClassName, Mode);
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0009");
			}
			return xmlData;
		}
        private void ResetGridStatus()
        {
            for (int i = 0; i < (gv_frm.Rows.Count - 1); i++)
            {
                this.gv_frm.Rows[i].Cells["Status"].Value = 0;
            }
 
        }
        private void ddl_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadGrid();
            }
            catch (Exception ex)
            {

               
            }
        }
        #endregion        
    }
}

