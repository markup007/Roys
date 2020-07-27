using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
	public partial class GR_005 : PLABS.MasterForm
    {
        #region Global variable
        String masterKey = "0";
        #endregion
        #region Properties
        #endregion
        public GR_005()
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
				this.DeleteBeforeClick += new EventHandler(geusrrolemast_DeleteBeforeClick);
				this.ClearAfterClick  += new EventHandler(geusrrolemast_ClearAfterClick);
				this.btn_find_F.Click += new EventHandler(btn_find_Click);
				this.lst_search.DoubleClick += new EventHandler(lst_Search_DoubleClick);
				this.lst_search.KeyDown += new KeyEventHandler(lst_Search_KeyDown);
                this.btn_clear_F.Click += new EventHandler(btn_fClear_Click);
                this.gv_frm.DataError += new DataGridViewDataErrorEventHandler(gv_frm_DataError);
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0001");
			}
			base.OnLoad(e);
		}

       
		

		#region Events
		private void btn_find_Click(object sender, EventArgs e)
		{
			try
			{
				this.loadGrid();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0010");
			}
		}

		private void btn_fClear_Click(object sender, EventArgs e)
		{ 
			//this.ddl_form_F.ClearControl( true );
			this.ddl_user_F.ClearControl( true );
            this.loadGrid();
           
		} 
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

		private void geusrrolemast_DeleteBeforeClick(object sender, EventArgs e)
		{
			try
			{
				this.doDelete();
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0014");
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
				 //ErrorLog.Insert(ex.Message,"geusrrolemast", "0015");
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
				  //ErrorLog.Insert(ex.Message, "geusrrolemast", "0016");
			}
		}
        void gv_frm_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
		#endregion

		#region Methods
		private void loadControls()
		{
			try
			{
				string xmlData = this.getBlankXml();
				 xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LO", "", "", "" ));
                 xmlData = this.CallWS(xmlData, "BizObj.GR_005,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                this.gv_frm.DataSource = PLABS.Utils.GetDataTable(ds, 0);
               // this.ddl_form.LoadData(PLABS.Utils.GetDataTable(ds, 0), "frm_nam", "frm_id");
				//this.ddl_form_F.LoadData(PLABS.Utils.GetDataTable(ds, 0), "frm_desc", "frm_id");
				this.ddl_user.LoadData(PLABS.Utils.GetDataTable(ds, 1), "usr_nam", "usr_id");
				this.ddl_user_F.LoadData(PLABS.Utils.GetDataTable(ds, 1).Copy(), "usr_nam", "usr_id");
                this.PopulateKeys();
				this.loadGrid();
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
				xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LG","", ddl_user_F.ControlValue, "" ));
                xmlData = this.CallWS(xmlData, "BizObj.GR_005,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
				lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0003");
			}
		}

		private void doFind(String PrimaryKeyID  )
		{
			 try
			{
			//	this.btn_saveas.Enabled = true;
                this.FindID = masterKey;
				this.CancelProcess = false;
                if (this.ValueChangedStatus)
                {
                    if (PLABS.MessageBoxPL.Show("Values are changed Do You Want To Save?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Question) == PLABS.MessageBoxPL.PLDialogResults.Yes)
                        this.DoSave(this);
                    else
                    {
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                    }
                }
				if (!this.CancelProcess   )
					{
						string xmlData = this.getBlankXml();
						xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("SE", "",PrimaryKeyID, ""  ));
                        xmlData = this.CallWS(xmlData, "BizObj.GR_005,BizObj", "S");
						//this.DataSource = xmlData;
                        DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                        this.ddl_user.LoadData(PLABS.Utils.GetDataTable(ds, 0), "name", "id");
                        this.ddl_user.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
                        this.ResetGridStatus();
                        this.GridAsSearch (PLABS .Utils .GetDataTable (ds,1));
						this.ValueChangedStatus = false;
						//this.txt_code.Focus();
					}
				}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message,"geusrrolemast", "0004");
			}
		}

        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;

                string xmlGvData = "<root>";

                for (int i = 0; gv_frm.Rows.Count > i; i++)
                {
                    if (PLABS.Utils.CnvToInt(gv_frm.Rows[i].Cells[0].Value) == 1)
                    { 
                        xmlGvData += "<row>";
                        xmlGvData += "<frmid>" + PLABS.Utils.CnvToStr(gv_frm.Rows[i].Cells["frm_id"].Value + "</frmid>");
                        xmlGvData += "<odrnum>" + PLABS.Utils.CnvToStr(gv_frm.Rows[i].Cells["txt_ordernum_gv"].EditedFormattedValue + "</odrnum>");
                        xmlGvData += "<key>" + PLABS.Utils.CnvToStr(gv_frm.Rows[i].Cells["cmb_keys_gv"].EditedFormattedValue + "</key>");

                        xmlGvData += "</row>";
                    }
                }
                xmlGvData += "</root>";
              




                xmlGvData = PLABS.CreateXml.FormatString(xmlGvData);
                xmlData = PLABS.Utils.addNode(xmlData, "v_XmlDtl", xmlGvData);
                xmlData = this.CallWS(xmlData, "BizObj.GR_005,BizObj", "I");
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
                //ErrorLog.Insert(ex.Message, "geusrrolemast", "0005");
            }
        }

		private void doDelete()
		{
			try
			{
				string xmlData = this.getBlankXml();
				xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_rol_det_id",  this.FindID );
                xmlData = this.CallWS(xmlData, "BizObj.GR_005,BizObj", "D");
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
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0006");
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
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "geusrrolemast", "0007");
			}
		}

		private void doFClear()
		{
		}
		private bool isValidData()
		{
			return true;
		}

		private String getSelectArgs( String as_mode ,String ai_frm_id,String ai_usr_id,String ai_usr_rol_det_id)
{
			 try
			 {
				 String argXml = this.getBlankXml(); 
				 argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode );
				 argXml = PLABS.Utils.addNode(argXml, "ai_frm_id", ai_frm_id );
				 argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", ai_usr_id );
				 argXml = PLABS.Utils.addNode(argXml, "ai_usr_rol_det_id", ai_usr_rol_det_id );
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
        private void GridAsSearch(DataTable dt)
        {
            for (int j = 0; j < dt.Rows.Count;j++ )
            {
                for (int i = 0; i < (gv_frm.Rows.Count - 1); i++)
                {
                   
                    string grdId = gv_frm.Rows[i].Cells["frm_id"].Value.ToString();
                    string dtId=dt.Rows[j]["frm_id"].ToString ();
                    if (grdId == dtId)
                    {
                        this.gv_frm.Rows[i].Cells["Status"].Value = 1;
                        if (!string.IsNullOrEmpty(PLABS.Utils.CnvToStr ( dt.Rows[j]["order_no"])))
                       {
                           this.gv_frm.Rows[i].Cells["cmb_keys_gv"].Value = PLABS.Utils.CnvToStr(dt.Rows[j]["key"]);
                       }
                        this.gv_frm.Rows[i].Cells["txt_ordernum_gv"].Value = PLABS.Utils.CnvToStr(dt.Rows[j]["order_no"]);
                        //break;
                    }
                   
                }
            }
 
        }
        private void PopulateKeys()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("keys");

            dt.Rows.Add("F1");
            dt.Rows.Add("F2");
            dt.Rows.Add("F3");
            dt.Rows.Add("F4");
            dt.Rows.Add("F5");
            dt.Rows.Add("F6");
            dt.Rows.Add("F7");
            dt.Rows.Add("F8");
            dt.Rows.Add("F9");
            dt.Rows.Add("F10");
            dt.Rows.Add("F11");

            this.cmb_keys_gv.DataSource = dt;
            this.cmb_keys_gv.ValueMember = "keys";
            this.cmb_keys_gv.DisplayMember = "keys";
        }

		#endregion

	}
}

