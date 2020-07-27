using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
	public partial class MA_002 :PLABS .MasterForm 
    {
        #region Global variables
        String masterKey = "0";
        String _as_resign_stat = "N";
        #endregion
        #region Constructor
        public MA_002()
		{
			InitializeComponent();
            
		}
		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.loadControls();
				this.ExitBeforeClick += new EventHandler(maaddrmast_ExitBeforeClick);
				this.SaveBeforeClick += new EventHandler(maaddrmast_SaveBeforeClick);
				this.SaveAfterClick += new EventHandler(maaddrmast_SaveAfterClick);
				this.DeleteBeforeClick += new EventHandler(maaddrmast_DeleteBeforeClick);
				this.ClearAfterClick  += new EventHandler(maaddrmast_ClearAfterClick);
				this.btn_find_F.Click += new EventHandler(btn_find_Click);
				this.lst_search.DoubleClick += new EventHandler(lst_Search_DoubleClick);
				this.lst_search.KeyDown += new KeyEventHandler(lst_Search_KeyDown);
                this.btn_clear_F.Click += new EventHandler(btn_fClear_Click);
                this.ddl_group.SelectedIndexChanged += new EventHandler(ddl_group_SelectedIndexChanged);
                this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
                this.btn_resign.Click += new EventHandler(btn_resign_Click);
                this.txt_resign.Enabled = false;
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "maaddrmast", "0001");
			}
			base.OnLoad(e);
        }

      

        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          
        }

        void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadGroupGrid();
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
				 //ErrorLog.Insert(ex.Message, "maaddrmast", "0010");
			}
		}

		private void btn_fClear_Click(object sender, EventArgs e)
		{ 
			this.txt_name_F.ClearControl( true );
			this.txt_code_F.ClearControl( true );
			this.ddl_group_F.ClearControl( true );
            this.loadGrid();
		} 
		private void maaddrmast_ExitBeforeClick(object sender, EventArgs e)
		{
 		}

		private void maaddrmast_SaveBeforeClick(object sender, EventArgs e)
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
				 //ErrorLog.Insert(ex.Message,"maaddrmast", "0011");
			}
		}

		private void maaddrmast_SaveAfterClick(object sender, EventArgs e)
		{
			try
			{
				this.doSave();
               
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"maaddrmast", "0012");
			}
		}

		private void maaddrmast_ClearAfterClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.CancelProcess)
				this.doClear();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"maaddrmast", "0013");
			}
		}

		private void maaddrmast_DeleteBeforeClick(object sender, EventArgs e)
		{
			try
			{
				this.doDelete();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "maaddrmast", "0014");
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
				 //ErrorLog.Insert(ex.Message,"maaddrmast", "0015");
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
				  //ErrorLog.Insert(ex.Message, "maaddrmast", "0016");
			}
		}

        void btn_resign_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_resign.Enabled = true;
                _as_resign_stat = "Y";

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
                 xmlData = this.CallWS(xmlData, "BizObj.MA_002,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
				this.ddl_group.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_grup_nam", "addr_grup_id");
				this.ddl_group_F.LoadData(PLABS.Utils.GetDataTable(ds, 0).Copy(), "addr_grup_nam", "addr_grup_id");
                this.ddl_fa_status.AddRow("Yes", 1);
                this.ddl_fa_status.AddRow("No", 2);
                this.ddl_fa_status.SelectedValue = 1;
                this.ddl_amttype.AddRow("Dr [+]", 1);
                this.ddl_amttype.AddRow("Cr [-]", 2);
                this.ddl_amttype.SelectedValue = 1;
                this.ddl_wttype.AddRow("Dr [+]", 1);
                this.ddl_wttype.AddRow("Cr [-]", 2);
                this.ddl_wttype.SelectedValue = 1;

				this.loadGrid();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "maaddrmast", "0002");
			 }
		}

		private void loadGrid()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LG", txt_code_F.ControlValue, ddl_group_F.ControlValue, "", txt_name_F.ControlValue ));
                xmlData = this.CallWS(xmlData, "BizObj.MA_002,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
				lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "maaddrmast", "0003");
			}
		}

		private void doFind(String PrimaryKeyID  )
		{
			 try
			{
				//this.btn_saveas.Enabled = true;
                this.FindID = PrimaryKeyID;
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
						xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("SE", "", "", PrimaryKeyID , "" ));
                        xmlData = this.CallWS(xmlData, "BizObj.MA_002,BizObj", "S");
						this.DataSource = xmlData;
                        DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                        DataTable dt= ds.Tables[0];
                        this.grd_data.DataSource = ds.Tables[1];
                        if (ds.Tables.Count > 2)
                        {
                            if (PLABS.Utils.CnvToInt(ds.Tables[2].Rows[0]["opnamt"]) < 0)
                            {
                                this.txt_opnamt.Text = (-PLABS.Utils.CnvToDouble(ds.Tables[2].Rows[0]["opnamt"])).ToString();
                                this.ddl_amttype.SelectedValue = 1;
                            }
                            else
                            {
                                this.txt_opnamt.Text = PLABS.Utils.CnvToDouble(ds.Tables[2].Rows[0]["opnamt"]).ToString();
                                this.ddl_amttype.SelectedValue = 2;
                            }
                            if (PLABS.Utils.CnvToDouble(ds.Tables[2].Rows[0]["opnwt"]) < 0)
                            {
                                this.txt_opnwt.Text = (-PLABS.Utils.CnvToDouble(ds.Tables[2].Rows[0]["opnwt"])).ToString();
                                this.ddl_wttype.SelectedValue = 1;
                            }
                            else
                            {
                                this.txt_opnwt.Text = PLABS.Utils.CnvToDouble(ds.Tables[2].Rows[0]["opnwt"]).ToString();
                                this.ddl_wttype.SelectedValue = 2;
                            }
                        }
                        else
                        {
                            this.txt_opnamt.ClearControl(true);
                            this.txt_opnwt.ClearControl(true);
                            this.ddl_amttype.SelectedValue = 1;
                            this.ddl_wttype.SelectedValue = 1;
                        }
                        ddl_fa_status.SelectedIndex = PLABS.Utils.CnvToInt(dt.Rows[0]["fa_status"]);
                       
                            this.ValueChangedStatus = false;
						//this.txt_code.Focus();
					}
				}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"maaddrmast", "0004");
			}
		}

		private void doSave()
		{
			try
			{
				string xmlData = this.ProcessXml;
                xmlData =PLABS .Utils .addNode(xmlData ,"ai_type",this.InsertMode ());
                xmlData = PLABS.Utils.addNode(xmlData, "as_resign_stat", _as_resign_stat);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));

                xmlData = this.CallWS(xmlData, "BizObj.MA_002,BizObj", "I");
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
                _as_resign_stat = "N";
                this.txt_resign.Enabled = false;
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
                     this.txt_resign.Enabled = false;
                     this.txt_code.Focus();
                     _as_resign_stat = "N";
				}
				else
				{
					this.CancelProcess = true;
					PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "maaddrmast", "0005");
			}
		}

		private void doDelete()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNode(xmlData, "ai_addr_id",  this.FindID );
                xmlData = this.CallWS(xmlData, "BizObj.MA_002,BizObj", "D");
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
				 //ErrorLog.Insert(ex.Message, "maaddrmast", "0006");
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
            //this.ddl_amttype.SelectedValue = 1;
            //this.ddl_wttype.SelectedValue = 1;
		     this.ValueChangedStatus = false;
             this.txt_resign.ClearControl(true);
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "maaddrmast", "0007");
			}
		}

		private void doFClear()
		{
		}

		private bool isValidData()
		{
			return true;
		}

        private String getSelectArgs(String as_mode, String as_addr_code, String ai_addr_grup_id, String ai_addr_id, String as_addr_nam)
{
			 try
			 {
				 String argXml = this.getBlankXml(); 
				 argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode );
				 argXml = PLABS.Utils.addNode(argXml, "as_addr_code", as_addr_code );
				 argXml = PLABS.Utils.addNode(argXml, "ai_addr_grup_id", ai_addr_grup_id );
				 argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id );
				 argXml = PLABS.Utils.addNode(argXml, "as_addr_nam", as_addr_nam );
             

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

        private void LoadGroupGrid()
        {
            try
            {

                string name = PLABS .Utils .CnvToStr(this.ddl_group.GetSelectedRow.ItemArray[1]);
                //string name = PLABS.Utils.CnvToStr(((DataRowView)(((ComboBox)(this.ddl_group)).SelectedItem)).Row.ItemArray[1].ToString());
                if(name!="Select Item")
                {
                DataTable dt = new DataTable();
                if (grd_data.Rows.Count == 0)
                {
                    dt.Columns.Add("id");
                    dt.Columns.Add("name");
                }

                else
                {
                    dt = (DataTable)(grd_data.DataSource);
                }

                DataRow[] repeatRow = dt.Select("id='" + this.ddl_group.ControlValue + "'");
                if (repeatRow.Length == 0)
                {
                    DataRow dr = dt.NewRow();

                    dr["id"] = this.ddl_group.ControlValue;
                    dr["name"] = name;

                    dt.Rows.Add(dr);

                    grd_data.DataSource = dt;
                }
                else
                {
                    PLABS.MessageBoxPL.Show("The Item Already Selected");
                }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private String InsertMode()
        {  
            try
            {
                if (ddl_amttype.ControlValue == "1" && ddl_wttype.ControlValue == "1")
                    return "1";
                else if (ddl_amttype.ControlValue == "1" && ddl_wttype.ControlValue == "2")
                    return "2";
                else if (ddl_amttype.ControlValue == "2" && ddl_wttype.ControlValue == "1")
                    return "3";
                else if (ddl_amttype.ControlValue == "2" && ddl_wttype.ControlValue == "2")
                    return "4";
            }
            catch (Exception ex)
            {
 
            }
            return "";
        }

       

		#endregion
	}
}

