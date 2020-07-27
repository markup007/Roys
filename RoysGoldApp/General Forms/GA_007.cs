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
    public partial class GA_007 : PLABS .MasterForm
    {
        #region GlobalVariables
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public GA_007()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();


            this.SaveBeforeClick += new EventHandler(GA_007_SaveBeforeClick);
            this.SaveAfterClick += new EventHandler(GA_007_SaveAfterClick);
            this.ddl_addr_id.SelectedIndexChanged += new EventHandler(ddl_addr_id_SelectedIndexChanged);

            this.chk_all.CheckedChanged += new EventHandler(chk_all_CheckedChanged);
            this.grd_grpdata.CellEndEdit += new DataGridViewCellEventHandler(grd_grpdata_CellEndEdit);
            
          
            base.OnLoad(e);
        }

        void grd_grpdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
      
            try
            {
                if (this.grd_grpdata.Columns[e.ColumnIndex].Name == "chk_sel_gvgrp")
                {

                    this.GrpSelect(e.RowIndex, PLABS.Utils.CnvToInt(this.grd_grpdata.Rows[e.RowIndex].Cells["chk_sel_gvgrp"].EditedFormattedValue ));
                }
            }
            catch (Exception ex)
            {
 
            }
        }

      
     
        void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //lst_search .CheckedItems
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
        #region Events
        void GA_007_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {

            }
        }

        void GA_007_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (!isValidData())
                    this.CancelProcess = true;
            }
            catch (Exception ex)
            {

            }
        }

        void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectAll();
            }
            catch (Exception ex)
            {

            }
        }

        void ddl_addr_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.UsrNamChanged();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
        #region Methods
        private void LoadControls()
        {
            try
            {
                DataSet ds = this.GetDataSet("LO");
                this.ddl_addr_id.LoadData(PLABS.Utils.GetDataTable(ds, 0), "nam", "id");
            }
            catch (Exception ex)
            {

            }
        }

        private DataSet GetDataSet(String as_mode)
        {
            try
            {
                
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode));
                xmlData = this.CallWS(xmlData, "BizObj.GA_007,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id",this.ddl_addr_id.ControlValue);
               
                return argXml;
            }
            catch (Exception ex)
            {
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
                //BizObj.CO_004 obj = new BizObj.CO_004();
                //xmlData = obj.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return xmlData;
        }

        private void UsrNamChanged()
        {
            try
            {
                DataSet ds = this.GetDataSet("LG");
                this.grd_data.DataSource=PLABS .Utils.GetDataTable (ds,0);
                this.grd_grpdata.DataSource = PLABS.Utils.GetDataTable(ds, 1);
            }
            catch (Exception ex)
            {
 
            }
        }

        private void SelectAll()
        {
            try
            {
                DataTable dt=(DataTable)this.grd_data .DataSource ;
                if (chk_all.Checked)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["chk"] = 1;
                    }
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["chk"] = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GrpSelect(int rowNum,int status)
        {
            try
            {
                string grpId=PLABS .Utils .CnvToStr(this.grd_grpdata.Rows[rowNum].Cells["txt_id_gvgrp"].Value);


                foreach (DataGridViewRow dr in grd_data.Rows)
                {
                    string[] ids = PLABS.Utils.CnvToStr(dr.Cells["txt_grpid_gv"].Value).Split(',');
                    if (ids.Length != 0)
                    {
                        for (int i = 0; i < ids.Length ; i++)
                        {
                            if (grpId == ids[i])
                            {
                                dr.Cells["chk_select_gv"].Value = status;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        private void doSave()
        {
            try
            {
                
                DataTable dt = new DataTable("Rslt");

              

                dt = (DataTable)this.grd_data.DataSource;
                dt.DefaultView.RowFilter = "chk=1";
                dt = dt.DefaultView.ToTable(true, new string[] { "id" });

                string xml="<ResultDS>";
                foreach (DataRow dr in dt.Rows)
                {
                    xml += "<Rslt><id>"+PLABS .Utils.CnvToStr(dr["id"])+"</id></Rslt>";
                }
                xml += "</ResultDS>";

                DataTable dtGrp = (DataTable)this.grd_grpdata.DataSource;

                dtGrp.DefaultView.RowFilter = "chk=1";
                dtGrp = dtGrp.DefaultView.ToTable(true, new string[] { "id" });
                string xmlgrp = "<ResultDS>";
                foreach (DataRow dr1 in dtGrp.Rows)
                {
                    xmlgrp += "<Rslt><id>" + PLABS.Utils.CnvToStr(dr1["id"]) + "</id></Rslt>";
                }
                xmlgrp += "</ResultDS>";

                string xmlData = this.ProcessXml;
                xmlData =PLABS .Utils.addNode(xmlData,"v_Xmldata",PLABS.CreateXml.FormatString(xml));
                xmlData = PLABS.Utils.addNode(xmlData, "v_XmlGrp", PLABS.CreateXml.FormatString(xmlgrp));
                xmlData = this.CallWS(xmlData, "BizObj.GA_007,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                       
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
                    PLABS.MessageBoxPL.Show("Successfully Saved", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                   
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0005");
            }
        }
        private bool isValidData()
        {
            if (Properties.Settings.Default.id == -1)
            {
                PLABS.MessageBoxPL.Show("Day Closed");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
