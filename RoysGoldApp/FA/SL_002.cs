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
    public partial class SL_002 : PLABS.MasterForm
    {
        #region Global Variable
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public SL_002()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.loadControls();
            this.fnd_grp.AfterFind += new EventHandler(fnd_grp_AfterFind);
            this.chk_selectAll.CheckedChanged += new EventHandler(chk_selectAll_CheckedChanged);
            this.dgv_data.DataError += new DataGridViewDataErrorEventHandler(dgv_data_DataError);
            this.dgv_data.CellValueChanged += new DataGridViewCellEventHandler(dgv_data_CellValueChanged);
            this.chk_selectAll.KeyDown += new KeyEventHandler(chk_selectAll_KeyDown);
            this.txt_amt.KeyDown += new KeyEventHandler(txt_amt_KeyDown);
            this.SaveAfterClick += new EventHandler(FA_001_SaveAfterClick);
            base.OnLoad(e);
        }

        void FA_001_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {
 
            }
        }

        void chk_selectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.dgv_data.Focus();
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        
       
        void dgv_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dgv_data.BeginEdit(true);
                this.TotalAmountCalculation();
                dgv_data.EndEdit();
            }
            catch (Exception ex)
            {
 
            }
        }

       

      
        #endregion 
        #region Events
        void fnd_grp_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
            }
            catch
            {
            }
        }
        void btn_save_Click(object sender, EventArgs e)
        {

            this.doSave();
        }
        void chk_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                foreach (DataGridViewRow dr in dgv_data .Rows)
                {
                    dr.Cells["chk_chk_grd"].Value=this.chk_selectAll.Checked;
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        void dgv_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        void txt_amt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.TotalAmountCalculation();
                    //this.chk_selectAll.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
        #region Methodes
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

        private String getSelectArgs(String as_mode,String ai_adgrp_id,String as_amount)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_adgrp_id", ai_adgrp_id);
                argXml = PLABS.Utils.addNode(argXml, "as_amount", as_amount);
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
                //BizObj.SL_002 objmaitemgrpmast = new BizObj.SL_002();
                //xmlData = objmaitemgrpmast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
            }
            return xmlData;
        }
        private void loadControls()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LO","",""));
                xmlData = this.CallWS(xmlData, "BizObj.SL_002,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                // common cmb  
                this.fnd_grp.LoadData(PLABS.Utils.GetDataTable(ds, 0),"name","name", "id");

                this.LoadLocalCombo();
            }
            catch (Exception ex)
            {                
            }
        }
        private void LoadGrid()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG",fnd_grp.ControlValue,""));
                xmlData = this.CallWS(xmlData, "BizObj.SL_002,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                // common grd  
                this.dgv_data.DataSource = ds.Tables[0];
                this.txt_amt.Focus();
            }
            catch (Exception ex)
            {
            }
        }
        //private void BindGrid()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("amt");
        //    dt.Columns.Add("id");
        //    dt.Columns.Add("name");
        //    dt.Columns.Add("chk");
        //    this.dgv_data.DataSource = dt;
        //}

        //private void addGrid()
        //{
        //    int temp = 0;
        //    try
        //    {
        //        for (int y = 0; y <= dgv_data.Rows.Count - 1; y++)
        //        {
        //            //    if (ddl_wl_nam.ControlValue == PLABS.Utils.CnvToStr(grd_stkout.Rows[y].Cells["txt_id"].Value))
        //            //    {
        //            //        this.grd_stkout.Rows[y].Cells["txt_qt"].Value = PLABS.Utils.CnvToStr(PLABS.Utils.CnvToInt(this.grd_stkout.Rows[y].Cells["txt_qt"].Value) + PLABS.Utils.CnvToInt(txt_qty.ControlValue));
        //            //        this.grd_stkout.Rows[y].Cells["txt_wt"].Value = PLABS.Utils.CnvToStr(PLABS.Utils.CnvToInt(this.grd_stkout.Rows[y].Cells["txt_wt"].Value) + PLABS.Utils.CnvToInt(txt_wgt.ControlValue));
        //            //        temp++;
        //            //    }
        //            //}
        //            if (temp == 0)
        //            {
        //                DataTable dt = new DataTable();
        //                dt.Columns.Add("amt");
        //                dt.Columns.Add("id");
        //                dt.Columns.Add("name");
        //                dt.Columns.Add("chk");
        //                dt = (DataTable)dgv_data.DataSource;
        //                DataRow dr = dt.NewRow();
        //                dr["amt"] = PLABS.Utils.CnvToStr(this.txt_amt.ControlValue);
        //                dr["id"] = PLABS.Utils.CnvToStr(dgv_data.Rows[y].Cells["txt_id_grd"].Value);
        //                dr["name"] = PLABS.Utils.CnvToStr(dgv_data.Rows[y].Cells["txt_grup_grd"].Value);
        //                dr["chk"] = PLABS.Utils.CnvToStr(dgv_data.Rows[y].Cells["chk_chk_grd"].Value);
        //                dt.Rows.Add(dr);

        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //    }
        //}
        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;
                DataSet ds = new DataSet("ResultDS");
                DataTable dt = (DataTable)dgv_data.DataSource;
                DataTable newTable = new DataTable();
                dt.TableName = "Rslt";
                newTable = dt.Copy();
                ds.Tables.Add(newTable);
                newTable.DefaultView.RowFilter = "chk=1";
                xmlData = PLABS.Utils.addNode(xmlData, "v_Xmldata", PLABS.CreateXml.FormatString(PLABS.Utils.CnvDataTableToXml(newTable.DefaultView.ToTable(true, new string[] { "ID" }), false)));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_amount", this.txt_amt.ControlValue);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                xmlData = this.CallWS(xmlData, "BizObj.SL_002,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        //String Key = this.masterKey;
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
                    PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
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
            }
        }
        private void TotalAmountCalculation()
        {
            try
            {
                DataTable dt = (DataTable)this.dgv_data.DataSource;
                dt.AcceptChanges();

                DataRow[] dr = dt.Select("chk=1");

                double ttlAmt = dr.Length * PLABS.Utils.CnvToDouble(this.txt_amt.Text);

                this.txt_totamt.Text = ttlAmt.ToString("F2");

            }
            catch (Exception ex)
            {
 
            }
        }
        private void doClear()
        {
            try
            {
                this.fnd_grp.ClearControl(true);
                this.txt_amt.ClearControl(true);
                this.txt_totamt.ClearControl(true);
                this.dgv_data.ClearControl(true);
            }
            catch (Exception ex)
            {
 
            }
        }
        private void LoadLocalCombo()
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("id");
                dt.Columns.Add("name");

                dt.Rows.Add(1, "CASH");
                dt.Rows.Add(2, "JOURNEL");

                this.ddl_type.LoadData(dt, "name", "id");
                
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
    }
}
