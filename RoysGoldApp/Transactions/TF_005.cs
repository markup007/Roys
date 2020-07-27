using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
	public partial class TF_005 : PLABS.MasterForm
    {
        #region Global variables
        String masterKey = "0";
        #endregion
        #region Constructor
        public TF_005()
		{
			InitializeComponent();
		} 
		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.loadControls();
				this.ExitBeforeClick += new EventHandler(trsales_ExitBeforeClick);
				this.SaveBeforeClick += new EventHandler(trsales_SaveBeforeClick);
				this.SaveAfterClick += new EventHandler(trsales_SaveAfterClick);
				this.DeleteBeforeClick += new EventHandler(trsales_DeleteBeforeClick);
				this.ClearAfterClick  += new EventHandler(trsales_ClearAfterClick);
                this.txt_desc.KeyDown += new KeyEventHandler(txt_desc_KeyDown);
                //this.ddl_jewelgrp.SelectedValueChanged += new EventHandler(ddl_jewelgrp_SelectedValueChanged);
               
				
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0001");
			}
			base.OnLoad(e);
        }

        void txt_desc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.grd_data.Focus();
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
        #region Events


        private void btn_fClear_Click(object sender, EventArgs e)
		{ 
			//this.ddl_shopname_F.ClearControl( true );
		} 
		private void trsales_ExitBeforeClick(object sender, EventArgs e)
		{
 		}
		private void trsales_SaveBeforeClick(object sender, EventArgs e)
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
				 //ErrorLog.Insert(ex.Message,"trsales", "0011");
			}
		}
		private void trsales_SaveAfterClick(object sender, EventArgs e)
		{
			try
			{
				this.doSave();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"trsales", "0012");
			}
		}
		private void trsales_ClearAfterClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.CancelProcess)
				this.doClear();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"trsales", "0013");
			}
		}
		private void trsales_DeleteBeforeClick(object sender, EventArgs e)
		{
			try
			{
				this.doDelete();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0014");
			}
		}
        //void ddl_jewelgrp_SelectedValueChanged(object sender, EventArgs e)
        //{

        //    this.JewelGroupChanged();
        //}
	
		#endregion
		#region Methods
		private void loadControls()
		{
			try
			{
				string xmlData = this.getBlankXml();
				 xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LO", "", "","" ,""));
                 xmlData = this.CallWS(xmlData, "BizObj.TF_005,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);

                // common cmb
				
                this.txt_odrno.Text = PLABS .Utils.GetDataTable(ds,0).Rows[0][0].ToString();
               
                this.ddl_jewelname.LoadData(PLABS.Utils.GetDataTable(ds, 1), "name", "id");
                
                //gridview cmb


                this.cmb_itm_id.DataSource = PLABS.Utils.GetDataTable(ds, 2);
                this.cmb_itm_id.DisplayMember = "name";
                this.cmb_itm_id.ValueMember = "id";


                
                
				
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0002");
			 }
		}
		private void doSave()
		{
			try
			{
				string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "ad_dt", this.dt_date.Value.ToString("yyyy-MM-dd"));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));

                xmlData = this.CallWS(xmlData, "BizObj.TF_005,BizObj", "I");
				if (xmlData == "-1")
				{
				PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
				if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
				{
				String Key = this.masterKey;
				this.ValueChangedStatus = false;
				this.DoClear(this);
				
				this.CancelProcess = true;
				}
				else
				{
				
				this.ValueChangedStatus = false;
				this.DoClear(this);
				this.CancelProcess = true;
				}
				}
				else if (xmlData.Length < 7)
				{
					//PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
					
					 this.doClear();
                     
                    this.loadControls();
				}
				else
				{
					this.CancelProcess = true;
					PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0005");
			}
		}
		private void doDelete()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNode(xmlData, "ai_sales_mast_id",  this.FindID );
                xmlData = this.CallWS(xmlData, "BizObj.TF_005,BizObj", "D");
				if (xmlData.Length < 7)
				{
					//PLABS.MessageBoxPL.Show("Deleted Successfully", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
					//this.loadGrid();
					this.doClear();
				}
				else
				{
					this.CancelProcess = true;
					PLABS.MessageBoxPL.Show(xmlData, "Alert",PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0006");
			}
		}
		private void doClear()
		{
			try
			{
			masterKey = "0";
			//this.btn_saveas.Enabled = false;
				//this.txt_amount.Focus();
            this.grd_data.ClearControl(true);
				this.ValueChangedStatus = false;
                this.txt_odrno.Focus();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0007");
			}
		}
		private bool isValidData()
		{
			return true;
		}
        private String getSelectArgs(String as_mode, String ai_sales_mast_id, String ai_shop_id, String ai_wt, String ai_jewelgrpid)
{
			 try
			 {
				 String argXml = this.getBlankXml(); 
				 argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode );
				 argXml = PLABS.Utils.addNode(argXml, "ai_sales_mast_id", ai_sales_mast_id );
				 argXml = PLABS.Utils.addNode(argXml, "ai_shop_id", ai_shop_id );
                 argXml = PLABS.Utils.addNode(argXml, "ai_wt", ai_wt);
                 
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
                //BizObj.TF_005 objtrsales = new BizObj.TF_005();
                //xmlData =  objtrsales.GetData(Xml, ClassName, Mode);
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0009");
			}
			return xmlData;
		}
        //private void JewelGroupChanged()
        //{
        //    try
        //    {
        //        string xmlData = this.getBlankXml();
        //        xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LC", "", "", "", this.ddl_jewelgrp.ControlValue));
        //        xmlData = this.CallWS(xmlData, "BizObj.TF_005,BizObj", "S");
        //        DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);

        //        this.ddl_jewelname.LoadData(PLABS.Utils.GetDataTable(ds, 0), "name", "id");
        //    }
        //    catch (Exception ex)
        //    {
 
        //    }
        //}
		#endregion
    }
}

