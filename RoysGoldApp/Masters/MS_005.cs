using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
	public partial class MS_005 : PLABS.MasterForm
    {
        #region Global Variables
        String masterKey = "0";
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public MS_005()
		{
			InitializeComponent();
		}
		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.loadControls();
				this.ExitBeforeClick += new EventHandler(masmthmc_ExitBeforeClick);
				this.SaveBeforeClick += new EventHandler(masmthmc_SaveBeforeClick);
				this.SaveAfterClick += new EventHandler(masmthmc_SaveAfterClick);
				this.DeleteBeforeClick += new EventHandler(masmthmc_DeleteBeforeClick);
				this.ClearAfterClick  += new EventHandler(masmthmc_ClearAfterClick);
				this.btn_find_F.Click += new EventHandler(btn_find_Click);
				this.lst_search.DoubleClick += new EventHandler(lst_Search_DoubleClick);
				this.lst_search.KeyDown += new KeyEventHandler(lst_Search_KeyDown);
                this.btn_clear_F.Click += new EventHandler(btn_fClear_Click);
                this.chk_edt_stat.KeyDown += new KeyEventHandler(chk_edt_stat_KeyDown);
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0001");
			}
			base.OnLoad(e);
        }

       
        #endregion
        #region Events
        private void btn_find_Click(object sender, EventArgs e)
		{
			try
			{
				this.loadGrid();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0010");
			}
		}

		private void btn_fClear_Click(object sender, EventArgs e)
		{ 
			this.fnd_addr_id_F.ClearControl( true );
            this.fnd_itm_id_F.ClearControl(true);
			this.txt_makingcharge_F.ClearControl( true );
            this.loadGrid();
		} 

		private void masmthmc_ExitBeforeClick(object sender, EventArgs e)
		{
 		}

		private void masmthmc_SaveBeforeClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.isValidData())
				this.CancelProcess = true;
				else
				{
                    this.btn_save.Enabled = false;
				if (this.FindID != "")
				this.FindID = this.masterKey;
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"masmthmc", "0011");
			}
		}

		private void masmthmc_SaveAfterClick(object sender, EventArgs e)
		{
			try
			{
				this.doSave();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"masmthmc", "0012");
			}
		}

		private void masmthmc_ClearAfterClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.CancelProcess)
				this.doClear();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"masmthmc", "0013");
			}
		}

		private void masmthmc_DeleteBeforeClick(object sender, EventArgs e)
		{
			try
			{
				this.doDelete();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0014");
			}
		}

		private void lst_Search_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					String Key = ((PLABSn .ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
					if (Key != string.Empty)
					{
						 this.masterKey = Key;
						this.doFind( Key);
					}
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"masmthmc", "0015");
			}
		}

		private void lst_Search_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				String Key = ((PLABSn .ListViewNormalPL)(sender)).SelectedItems[0].SubItems[0].Text;
					if (Key != string.Empty)
					{
						this.masterKey = Key;
						this.doFind( Key);
					}
			}
			catch (Exception ex)
			{
				  //ErrorLog.Insert(ex.Message, "masmthmc", "0016");
			}
		}
        void chk_edt_stat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                this.btn_save.Focus();
            }
            catch (Exception ex)
            {

            }
        }

		#endregion
		#region Methods
		private void loadControls()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LO", "", "", "", "" ));
                xmlData = this.CallWS(xmlData, "BizObj.MS_005,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
				this.fnd_addr_id.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd","nam","id");
                this.fnd_addr_id_F.LoadData(PLABS.Utils.GetDataTable(ds, 0), "cd", "nam", "id");
				this.fnd_itm_id.LoadData(PLABS.Utils.GetDataTable(ds, 1), "itm","cd","id");
                this.fnd_itm_id_F.LoadData(PLABS.Utils.GetDataTable(ds, 1), "itm", "cd", "id");
                this.ddl_mc_ratio.LoadData(PLABS.Utils.GetDataTable(ds, 2), "Ratio", "Ratio_id");
               
               	this.loadGrid();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0002");
			 }
		}

		private void loadGrid()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LG", fnd_addr_id_F.ControlValue, fnd_itm_id_F.ControlValue, txt_makingcharge_F.ControlValue, "" ));
                xmlData = this.CallWS(xmlData, "BizObj.MS_005,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
				lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
               
                  
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0003");
			}
		}

		private void doFind(String PrimaryKeyID  )
		{
			 try
			{
				
				this.CancelProcess = false;
				if (this.ValueChangedStatus)
				{
					if (PLABS.MessageBoxPL.Show("Values are changed Do You Want To Save?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Question) == PLABS.MessageBoxPL.PLDialogResults.Yes)
						this.DoSave(this);
					else
					{
						this.ValueChangedStatus = false;
						this.DoClear( this );
					 }
				}
				if (!this.CancelProcess   )
					{
						string xmlData = this.getBlankXml();
						xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("SE", "", "", "", PrimaryKeyID  ));
                        xmlData = this.CallWS(xmlData, "BizObj.MS_005,BizObj", "S");
						this.DataSource = xmlData;
                        DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                        DataTable dt = ds.Tables[0];
                        int chk = PLABS.Utils.CnvToInt(dt.Rows[0]["edit_status"]);
                        if (chk == 0)
                        {
                            chk_edt_stat.Checked = true;
                            this.txt_makingcharge.ReadOnly = true;
                        }
                        else if (chk == 1)
                        {
                            chk_edt_stat.Checked = false;
                            this.txt_makingcharge.ReadOnly = false;
                            
                        }
						this.ValueChangedStatus = false;
						//this.txt_code.Focus();
					}
				}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"masmthmc", "0004");
			}
		}

		private void doSave()
		{
			try
			{
				string xmlData = this.ProcessXml;
                xmlData = this.CallWS(xmlData, "BizObj.MS_005,BizObj", "I");
				if (xmlData == "-1")
				{
				PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
				if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
				{
				String Key = this.masterKey;
				this.ValueChangedStatus = false;
				this.DoClear(this);
				doFind(Key);
				this.loadGrid();
				this.CancelProcess = true;
				}
				else
				{
				this.loadGrid();
				this.ValueChangedStatus = false;
				this.DoClear(this);
				this.CancelProcess = true;
				}
				}
				else if (xmlData.Length < 7)
				{
					//PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.btn_save.Enabled = true;
                    this.loadGrid();
					 this.doClear();
                     this.fnd_addr_id.Focus();
				}
				else
				{
					this.CancelProcess = true;
					PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0005");
			}
		}

		private void doDelete()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNode(xmlData, "ai_smth_mc_id",  this.FindID );
                xmlData = this.CallWS(xmlData, "BizObj.MS_005,BizObj", "D");
				if (xmlData.Length < 7)
				{
					//PLABS.MessageBoxPL.Show("Deleted Successfully", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
					this.loadGrid();
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
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0006");
			}
		}

		private void doClear()
		{
			try
			{
			masterKey = "0";
            this.btn_save.Enabled = true;
			//this.btn_saveas.Enabled = false;
				//this.txt_amount.Focus();
            this.txt_makingcharge.ReadOnly = false;
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0007");
			}
		}

		private void doFClear()
		{
		}
		private bool isValidData()
		{
			return true;
		}

		private String getSelectArgs( String as_mode ,String ai_addr_id,String ai_itm_id,String an_mc,String ai_smth_mc_id)
{
			 try
			 {
				 String argXml = this.getBlankXml(); 
				 argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode );
				 argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id );
				 argXml = PLABS.Utils.addNode(argXml, "ai_itm_id", ai_itm_id );
				 argXml = PLABS.Utils.addNode(argXml, "an_mc", an_mc );
				 argXml = PLABS.Utils.addNode(argXml, "ai_smth_mc_id", ai_smth_mc_id );
				return argXml;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0010");
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
                //BizObj.MS_005 objmasmthmc = new BizObj.MS_005();
                //xmlData =  objmasmthmc.GetData(Xml, ClassName, Mode);
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "masmthmc", "0009");
			}
			return xmlData;
		}

		#endregion
	}
}

