using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
	public partial class SL_001 :PLABS .MasterForm
    {
        #region GlobalVariable
        String masterKey = "0";
        #endregion
        #region Propreties
        #endregion
        #region Constructor
        public SL_001()
		{
			InitializeComponent();
		}
		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.loadControls();
				this.ExitBeforeClick += new EventHandler(empsalary_ExitBeforeClick);
				this.SaveBeforeClick += new EventHandler(empsalary_SaveBeforeClick);
				this.SaveAfterClick += new EventHandler(empsalary_SaveAfterClick);
				this.DeleteBeforeClick += new EventHandler(empsalary_DeleteBeforeClick);
				this.ClearAfterClick  += new EventHandler(empsalary_ClearAfterClick);
				this.btn_find_F.Click += new EventHandler(btn_find_Click);
				this.lst_search.DoubleClick += new EventHandler(lst_Search_DoubleClick);
				this.lst_search.KeyDown += new KeyEventHandler(lst_Search_KeyDown);
                this.btn_clear_F.Click += new EventHandler(btn_fClear_Click);
                this.txt_salary.KeyDown += new KeyEventHandler(txt_salary_KeyDown);
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "empsalary", "0001");
			}
			base.OnLoad(e);
        }

        void txt_salary_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.txt_advnc.Text = this.txt_salary.Text;
                }
            }
            catch (Exception ex)
            {
 
            }
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
				 //ErrorLog.Insert(ex.Message, "empsalary", "0010");
			}
		}

		private void btn_fClear_Click(object sender, EventArgs e)
		{ 
			this.fnd_employ_F.ClearControl( true );
			this.txt_salary_F.ClearControl( true );
		} 

		private void empsalary_ExitBeforeClick(object sender, EventArgs e)
		{
 		}

		private void empsalary_SaveBeforeClick(object sender, EventArgs e)
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
				 //ErrorLog.Insert(ex.Message,"empsalary", "0011");
			}
		}

		private void empsalary_SaveAfterClick(object sender, EventArgs e)
		{
			try
			{
				this.doSave();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"empsalary", "0012");
			}
		}

		private void empsalary_ClearAfterClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.CancelProcess)
				this.doClear();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"empsalary", "0013");
			}
		}

		private void empsalary_DeleteBeforeClick(object sender, EventArgs e)
		{
			try
			{
				this.doDelete();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "empsalary", "0014");
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
                        this.ValueChangedStatus = true;
					}
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"empsalary", "0015");
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
                        this.ValueChangedStatus = true;
					}
			}
			catch (Exception ex)
			{
				  //ErrorLog.Insert(ex.Message, "empsalary", "0016");
			}
		}

		#endregion
		#region Methods
		private void loadControls()
		{
			try
			{
				string xmlData = this.getBlankXml();
				 xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LO", "", "", "" ));
                 xmlData = this.CallWS(xmlData, "BizObj.SL_001,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                this.fnd_employ.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
                this.fnd_employ_F.LoadData(PLABS.Utils.GetDataTable(ds, 0).Copy(), "addr_code", "addr_nam", "addr_id");
                //this.fnd_address.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_code", "addr_nam", "addr_id");
				this.loadGrid();
                this.dtp_join_dt.Value = PLABS.Utils.CnvToDate("01-" + DateTime.Now.Month + "-" + DateTime.Now.Year);
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "empsalary", "0002");
			 }
		}

		private void loadGrid()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LG",fnd_employ_F.ControlValue, txt_salary_F.ControlValue, "" ));
                xmlData = this.CallWS(xmlData, "BizObj.SL_001,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
				lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "empsalary", "0003");
			}
		}

		private void doFind(String PrimaryKeyID  )
		{
			 try
			{
				this.btn_saveas.Enabled = true;
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
						xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("SE", "", "", PrimaryKeyID  ));
                        xmlData = this.CallWS(xmlData, "BizObj.SL_001,BizObj", "S");
						this.DataSource = xmlData;
                        DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["join_dt"].ToString()))
                        {
                            dtp_join_dt.Value = PLABS.Utils.CnvToDate(ds.Tables[0].Rows[0]["join_dt"]);
                        }
                        else
                        {
                            dtp_join_dt.ClearControl(true);
                        }
						this.ValueChangedStatus = false;
						//this.txt_code.Focus();
					}
				}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"empsalary", "0004");
			}
		}

		private void doSave()
		{
			try
			{
				string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                if (!string.IsNullOrEmpty(dtp_join_dt.ControlValue))
                {
                    xmlData = PLABS.Utils.addNode(xmlData, "ad_joind_dt", dtp_join_dt.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    xmlData = PLABS.Utils.addNode(xmlData, "ad_joind_dt", dtp_join_dt.ControlValue);

                }

                xmlData = this.CallWS(xmlData, "BizObj.SL_001,BizObj", "I");
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
					this.loadGrid();
					 this.doClear();
                     this.dtp_join_dt.Value = PLABS.Utils.CnvToDate("01-" + DateTime.Now.Month + "-" + DateTime.Now.Year);
				}
				else
				{
					this.CancelProcess = true;
					PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "empsalary", "0005");
			}
		}

		private void doDelete()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNode(xmlData, "ai_salary_id",  this.FindID );
                xmlData = this.CallWS(xmlData, "BizObj.SL_001,BizObj", "D");
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
				 //ErrorLog.Insert(ex.Message, "empsalary", "0006");
			}
		}

		private void doClear()
		{
			try
			{
			masterKey = "0";
			this.btn_saveas.Enabled = false;
				//this.txt_amount.Focus();
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "empsalary", "0007");
			}
		}

		private void doFClear()
		{
		}
		private bool isValidData()
		{
			return true;
		}

		private String getSelectArgs( String as_mode ,String ai_addr_id,String an_salary,String ai_salary_id)
{
			 try
			 {
				 String argXml = this.getBlankXml(); 
				 argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode );
				 argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id );
				 argXml = PLABS.Utils.addNode(argXml, "an_salary", an_salary );
				 argXml = PLABS.Utils.addNode(argXml, "ai_salary_id", ai_salary_id );
				return argXml;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "empsalary", "0010");
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
                //BizObj.ME_001 objempsalary = new BizObj.ME_001();
                //xmlData =  objempsalary.GetData(Xml, ClassName, Mode);
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "empsalary", "0009");
			}
			return xmlData;
		}

		#endregion

        
	}
}

