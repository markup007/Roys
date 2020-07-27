using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
	public partial class GU_004 : PLABS.MasterForm
    {
        #region Global Varaibles
        String masterKey = "0";
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public GU_004()
		{
			InitializeComponent();
		}
		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.loadControls();
				this.ExitBeforeClick += new EventHandler(geusrmast_ExitBeforeClick);
				this.SaveBeforeClick += new EventHandler(geusrmast_SaveBeforeClick);
				this.SaveAfterClick += new EventHandler(geusrmast_SaveAfterClick);
				this.DeleteBeforeClick += new EventHandler(geusrmast_DeleteBeforeClick);
				this.ClearAfterClick  += new EventHandler(geusrmast_ClearAfterClick);
				this.btn_find_F.Click += new EventHandler(btn_find_Click);
				this.lst_search.DoubleClick += new EventHandler(lst_Search_DoubleClick);
				this.lst_search.KeyDown += new KeyEventHandler(lst_Search_KeyDown);
                this.btn_clear_F.Click += new EventHandler(btn_fClear_Click);
                this.txt_password.KeyDown += new KeyEventHandler(txt_password_KeyDown);
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0001");
			}
			base.OnLoad(e);
        }

        void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    this.btn_clear.Focus();
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
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0010");
			}
		}

		private void btn_fClear_Click(object sender, EventArgs e)
		{ 
			this.ddl_address_F.ClearControl( true );
			this.txt_username_F.ClearControl( true );
            this.loadGrid();
		} 
		private void geusrmast_ExitBeforeClick(object sender, EventArgs e)
		{
 		}

		private void geusrmast_SaveBeforeClick(object sender, EventArgs e)
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
				 //ErrorLog.Insert(ex.Message,"geusrmast", "0011");
			}
		}

		private void geusrmast_SaveAfterClick(object sender, EventArgs e)
		{
			try
			{
				this.doSave();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"geusrmast", "0012");
			}
		}

		private void geusrmast_ClearAfterClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.CancelProcess)
				this.doClear();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"geusrmast", "0013");
			}
		}

		private void geusrmast_DeleteBeforeClick(object sender, EventArgs e)
		{
			try
			{
				this.doDelete();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0014");
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
				 //ErrorLog.Insert(ex.Message,"geusrmast", "0015");
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
				  //ErrorLog.Insert(ex.Message, "geusrmast", "0016");
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
                 xmlData = this.CallWS(xmlData, "BizObj.GU_004,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
				this.ddl_address.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_nam", "addr_id");
				this.ddl_address_F.LoadData(PLABS.Utils.GetDataTable(ds, 0).Copy(), "addr_nam", "addr_id");
				this.loadGrid();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0002");
			 }
		}

		private void loadGrid()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LG", ddl_address_F.ControlValue, "", txt_username_F.ControlValue ));
                xmlData = this.CallWS(xmlData, "BizObj.GU_004,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
				lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0003");
			}
		}

		private void doFind(String PrimaryKeyID  )
		{
			 try
			{
				//this.btn_saveas.Enabled = true;
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
						xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("SE", "", PrimaryKeyID , "" ));
                        xmlData = this.CallWS(xmlData, "BizObj.GU_004,BizObj", "S");
						this.DataSource = xmlData;
						this.ValueChangedStatus = false;
						//this.txt_code.Focus();
					}
				}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"geusrmast", "0004");
			}
		}

		private void doSave()
		{
			try
			{
				string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "as_pswrd", this.Encoding());
                xmlData = this.CallWS(xmlData, "BizObj.GU_004,BizObj", "I");
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
				}
				else
				{
					this.CancelProcess = true;
					PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0005");
			}
		}

		private void doDelete()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id",  this.FindID );
                xmlData = this.CallWS(xmlData, "BizObj.GU_004,BizObj", "D");
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
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0006");
			}
		}

		private void doClear()
		{
			try
			{
			masterKey = "0";
			//this.btn_saveas.Enabled = false;
				//this.txt_amount.Focus();
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0007");
			}
		}

		private void doFClear()
		{
		}
		private bool isValidData()
		{
            if (this.txt_password.Text == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
		}

		private String getSelectArgs( String as_mode ,String ai_addr_id,String ai_usr_id,String as_usr_nam)
{
			 try
			 {
				 String argXml = this.getBlankXml(); 
				 argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode );
				 argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id );
				 argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", ai_usr_id );
				 argXml = PLABS.Utils.addNode(argXml, "as_usr_nam", as_usr_nam );
				return argXml;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0010");
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
                //BizObj.GU_004 objgeusrmast = new BizObj.GU_004();
                //xmlData =  objgeusrmast.GetData(Xml, ClassName, Mode);
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrmast", "0009");
			}
			return xmlData;
		}
        private String Encoding()
        {

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(this.txt_password.Text.Trim());

            string passwd = string.Empty;
            string oldpw = string.Empty;
            for (int i = 0; i < bytes.GetLength(0); i++)
            {
                passwd += bytes[i].ToString();

            }
            return passwd;
        }

		#endregion
	}
}

