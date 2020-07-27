using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace RoysGold
{
    public partial class CO_001 : PLABS.MasterForm
	{
        int _shpid;

        public int Shpid
        {
            get { return _shpid; }
            set { _shpid = value; }
        }
        String _grdData = string.Empty;

        public String GrdData
        {
            get { return _grdData; }
            set { _grdData = value; }
        }

	    String masterKey = "0";

		public CO_001()
		{
			InitializeComponent();
		} 

		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.loadControls();
				this.ExitBeforeClick += new EventHandler(trsales_ExitBeforeClick);
				this.DeleteBeforeClick += new EventHandler(trsales_DeleteBeforeClick);
				this.ClearAfterClick  += new EventHandler(trsales_ClearAfterClick);
                this.btn_ok.Click += new EventHandler(btn_ok_Click);
                this.ddl_ordr_no.SelectedIndexChanged += new EventHandler(ddl_ordr_no_SelectedIndexChanged);
				this.ValueChangedStatus = false;
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0001");
			}
			base.OnLoad(e);
		}

        void ddl_ordr_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            string xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG", "", ddl_ordr_no.ControlValue));
            xmlData = this.CallWS(xmlData, "BizObj.CO_001,BizObj", "S");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            this.txt_desc.Text = PLABS.Utils.CnvToStr(dt.Rows[0]["desc"]);
            this.dp_date.ControlValue = PLABS.Utils.CnvToStr(dt.Rows[0]["date"]);
            this.grd_data.DataSource = dt1;
        }

		#region Events

		private void btn_fClear_Click(object sender, EventArgs e)
		{ 
			//this.ddl_shopname_F.ClearControl( true );
		} 

		private void trsales_ExitBeforeClick(object sender, EventArgs e)
		{
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

        void btn_ok_Click(object sender, EventArgs e)
        {
            this.GrdData = this.grd_data.ControlValue;
            this.Close();
            
        }

		#endregion

		#region Methods

		private void loadControls()
		{
			try
			{
				string xmlData = this.getBlankXml();
				 xmlData = PLABS.Utils.addNodes(xmlData,getSelectArgs("LO",Shpid.ToString(), ""));
                 xmlData = this.CallWS(xmlData, "BizObj.CO_001,BizObj", "S");
				DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                if (ds.Tables.Count == 2)
                {
                    this.ddl_ordr_no.LoadData(PLABS.Utils.GetDataTable(ds, 0), "num", "id");

                    this.cmb_itm_id.DataSource = ds.Tables[1];
                    this.cmb_itm_id.DisplayMember = "name";
                    this.cmb_itm_id.ValueMember = "id";
                }
                else
                {
                    PLABS.MessageBoxPL.Show("There Is No Order!");
                    this.Close();
                }

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
                xmlData = this.CallWS(xmlData, "BizObj.CO_001,BizObj", "I");
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
                xmlData = this.CallWS(xmlData, "BizObj.CO_001,BizObj", "D");
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

        private String getSelectArgs(String as_mode,String ai_shop_id, String ai_order_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_shop_id", ai_shop_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_order_id", ai_order_id);
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
                //BizObj.CO_001 objtCO_001 = new BizObj.CO_001();
                //xmlData = objtCO_001.GetData(Xml, ClassName, Mode);
			}
			catch (Exception ex)
			{
				 //ErrorLog.Insert(ex.Message, "trsales", "0009");
			}
			return xmlData;
		}

        private void PopulateStnLess()
        {
            DataTable dt = new DataTable();

            dt.Columns .Add("id");
            dt.Columns.Add("name");

            DataRow dr = dt.NewRow();

            dr["id"] = "Y";
            dr["name"] = "Yes";

            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();

            dr1["id"] = "N";
            dr1["name"] = "No";

            dt.Rows.Add(dr1);

          



        }
       
		#endregion

      


      
      

	}
}

