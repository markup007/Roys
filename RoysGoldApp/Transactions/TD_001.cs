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
    public partial class TD_001 : PLABS.MasterForm
    {
        #region Global Variables
        #endregion
        #region Properties
        #endregion
        #region Constructors
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.ValueChangedStatus = true;
            this.SaveBeforeClick += new EventHandler(TD_001_SaveBeforeClick);
            this.SaveAfterClick += new EventHandler(TD_001_SaveAfterClick);
            this.btn_delete.Click += new EventHandler(btn_delete_Click);
            this.grd_datacash.DoubleClick += new EventHandler(grd_datacash_DoubleClick);
            this.grd_datacash.KeyDown += new KeyEventHandler(grd_datacash_KeyDown);
            this.btn_refrsh.Click += new EventHandler(btn_refrsh_Click);
            this.tb_main.SelectedIndexChanged += new EventHandler(tb_main_SelectedIndexChanged);
            this.grd_data.CellEndEdit += new DataGridViewCellEventHandler(grd_data_CellEndEdit);
        
            base.OnLoad(e);
        }

        
        public TD_001()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        void TD_001_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doSave();
            }
            catch (Exception ex)
            {

            }
        }
        void TD_001_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (!isValidData())
                {
                    this.CancelProcess = true;
                    this.btn_save.Enabled = false;
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        void grd_datacash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.CashGridEnter(this.grd_datacash.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_datacash_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.CashGridEnter(this.grd_datacash.CurrentRow.Index);
            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            string colName = this.grd_data.Columns[e.ColumnIndex].HeaderText;
            if (colName == "Item" || colName == "Description" || colName == "Payment(+)" || colName == "Receipt(-)")
            {
               
                string date = PLABS.Utils.CnvToStr(this.grd_data.Rows[e.RowIndex].Cells["txt_date_gv"].Value);
                if (date == "")
                {
                    string sysDate = DateTime.Now.ToString("dd/MMM/yyyy");
                    this.grd_data.Rows[e.RowIndex].Cells["txt_date_gv"].Value = sysDate;
                    this.grd_data.Rows[e.RowIndex].Cells["txt_sqldate_gv"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    this.grd_data.Rows[e.RowIndex].Cells["txt_status_gv"].Value = "F";
                }
                else
                {
                    this.grd_data.Rows[e.RowIndex].Cells["txt_status_gv"].Value = "U";
                }
                this.grd_data.Rows[e.RowIndex].Cells["txt_sqldate_gv"].Value = DateTime.Now.ToString("yyyy-MM-dd");

            }
        }
        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                this.doDelete();
            }
            catch
            {

            }
        }
        void btn_refrsh_Click(object sender, EventArgs e)
        {
            try
            {
                this.RefreshClick();
            }
            catch (Exception ex)
            {

            }
        }
        void tb_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.TabChanged();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region Methods
        public void LoadControls()
        {
            string xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LO"));
            xmlData = this.CallWS(xmlData, "BizObj.TD_001,BizObj", "S");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);

            this.cmb_item_gv.DataSource = PLABS.Utils.GetDataTable(ds, 0);
            this.cmb_item_gv.DisplayMember = "name";
            this.cmb_item_gv.ValueMember = "itm_id";
            this.BindGrid(PLABS.Utils.GetDataTable(ds, 1));

            this.PopulateCashGrid(PLABS.Utils.GetDataTable(ds, 2));

         
        
        }
        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);

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
                //BizObj.TD_001 objmaaddrmast = new BizObj.TD_001();
                //xmlData = objmaaddrmast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0009");
            }
            return xmlData;
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
        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));

                xmlData = this.CallWS(xmlData, "BizObj.TD_001,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        //String Key = this.masterKey;
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                        //doFind(Key);
                        this.LoadControls();
                        this.CancelProcess = true;
                    }
                    else
                    {
                        this.LoadControls();
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                        this.CancelProcess = true;
                    }
                }
                else if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.btn_save.Enabled = true;
                    //this.LoadControls();
                    //this.doClear();
                    //this.txt_code.Focus();
                    this.LoadControls();

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
                DataTable dt = (DataTable)grd_data.DataSource;
                dt.TableName = "Rslt";
                dt.DefaultView.RowFilter = "chk=1";

                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                xmlData = PLABS.Utils.addNode(xmlData, "v_Xmldata", PLABS.CreateXml.FormatString(PLABS.Utils.CnvDataTableToXml(dt.DefaultView.ToTable(true, new string[] { "id" }), false)));
                
                xmlData = this.CallWS(xmlData, "BizObj.TD_001,BizObj", "D");
                if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Deleted Successfully", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.LoadControls();

                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0006");
            }
        }
        private void BindGrid(DataTable dt)
        {
            try
            {
                lbl_balance.Text = string.Empty;
                dt.Columns.Add ("sqldate");
                foreach (DataRow dr in dt.Rows)
                {
                    dr["sqldate"]=(PLABS.Utils.CnvToDate(dr["dt"]).ToString("yyyy-MM-dd"));
                }
                double payment = PLABS.Utils.CnvToDouble(dt.Compute("SUM(dr)", ""));
                double reciept = PLABS.Utils.CnvToDouble(dt.Compute("SUM(cr)", ""));

                if (dt.Columns.Contains("drpurwt"))
                    payment = PLABS.Utils.CnvToDouble(dt.Compute("SUM(drpurwt)", ""));
                if (dt.Columns.Contains("crpurwt"))
                    reciept = PLABS.Utils.CnvToDouble(dt.Compute("SUM(crpurwt)", ""));


                if (dt.Columns.Contains("drpurwt"))
                    dt.Columns.Remove("drpurwt");

                if (dt.Columns.Contains("crpurwt"))
                    dt.Columns.Remove("crpurwt");

                if (dt.Columns.Contains("purty"))
                    dt.Columns.Remove("purty");

                this.grd_data.DataSource = dt;


                double balance = payment - reciept;
                if (balance != 0)
                    lbl_balance.Text = "Balance : " + balance.ToString("F3");
                this.RemoveZeros();
            }
            catch (Exception ex)
            {
 
            }
        }
        private void RemoveZeros()
        {
            try
            {
                DataTable dt = (DataTable)grd_data.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string colName = dt.Columns[j].ColumnName;
                        if (colName =="dr"||colName=="cr")
                        {
                            if (PLABS.Utils.CnvToDouble(dt.Rows[i][j]) == 0)
                            {
                                dt.Rows[i][j] = DBNull.Value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void PopulateCashGrid(DataTable dt)
        {
            try
            {
                
                this.BindCashGrid();
                DataTable source = (DataTable)this.grd_datacash.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow newRow = source.NewRow();
                    newRow["date"] = (PLABS.Utils.CnvToDate(dr["date"])).ToString("dd-MMM-yyyy");
                    newRow["name"] = dr["name"];
                    if (PLABS.Utils.CnvToDouble(dr["amt"]) > 0)
                    {
                        newRow["dr"] =dr["amt"];
                    }
                    else if (PLABS.Utils.CnvToDouble(dr["amt"]) < 0)
                    {
                        newRow["cr"] = -1 * PLABS.Utils.CnvToDouble(dr["amt"]);
                    }
                    source.Rows.Add(newRow);
                }

                double payment = PLABS .Utils .CnvToDouble ( source.Compute("SUM(dr)", ""));
                double reciept = PLABS.Utils.CnvToDouble(source.Compute("SUM(cr)", ""));

                double balance = payment - reciept;

                DataRow clsRow = source.NewRow();
                clsRow["name"] = "CLOSING";

                clsRow["cr"] = (payment - reciept);

                source.Rows.Add(clsRow);
                

                this.RemoveBlakRows();
            }
            catch (Exception ex) 
            {

            }
 
        }
        private void BindCashGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("date", typeof(string));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("dr", typeof(double));
                dt.Columns.Add("cr", typeof(double));

                this.grd_datacash.DataSource = dt;
            }
            catch (Exception ex)
            {
 
            }
        }
        private void CashGridEnter(int rowNumber)
        {
            try
            {
                string headDesc = PLABS.Utils.CnvToStr(this.grd_datacash.Rows[rowNumber].Cells["txt_name_gvcash"].Value);
                if (headDesc != string.Empty || headDesc != "CLOSING")
                {
                    CB_002 obj = new CB_002();
                    obj.HeadDescMaster = headDesc.Trim();

                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void RemoveBlakRows()
        {
            try
            {
                DataTable dt = (DataTable)this.grd_datacash.DataSource;

                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    if (PLABS.Utils.CnvToDouble(dt.Rows[i]["dr"]) == 0 && PLABS.Utils.CnvToDouble(dt.Rows[i]["cr"]) == 0)
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        private void TabChanged()
        {
            try
            {
                string tabPage = this.tb_main.SelectedTab.Name;

                switch (tabPage)
                {
                    case "tp_sheetitem":
                        this.grd_data.Focus();
                        break;
                    case "tp_sheetcash":
                        this.grd_datacash.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void RefreshClick()
        {
            try
            {
                this.btn_save.Enabled = true;
                this.LoadControls();
               
            }
            catch (Exception ex)
            {
 
            }
        }


        #endregion
    }
}
