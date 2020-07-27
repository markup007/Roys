using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace RoysGold
{
    public partial class RP_009 : PLABS.MasterForm
    {            
        #region Global Variables

        Double _pur = 0.00, _sal = 0.00;
        Double _purSave = 0.00, _salSave = 0.00, _balForSave = 0.00, _rateForSave = 0.00;
        DataTable _dtLoadGrid = new DataTable();
        DataTable _idtbl = new DataTable();
        String _purChek, _salChek ,_bdRate;
        int _temp = 0;
        #endregion

        #region Constructors

        public RP_009()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
           
            this.grd_data_save.CellLeave += new DataGridViewCellEventHandler(grd_data_save_CellLeave);
            this.grd_data_save.CellClick += new DataGridViewCellEventHandler(grd_data_save_CellClick);
            this.SaveBeforeClick += new EventHandler(RP_009_SaveBeforeClick);
            this.SaveAfterClick += new EventHandler(RP_009_SaveAfterClick);
            this.txt_name.TextChanged += new EventHandler(txt_name_TextChanged);
            this.DeleteAfterClick += new EventHandler(RP_009_DeleteAfterClick);
            this.DeleteBeforeClick += new EventHandler(RP_009_DeleteBeforeClick);
            base.OnLoad(e);
        }

       

       
      
        #endregion

        #region Events

        void RP_009_DeleteBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (grd_data_save.Rows.Count - 1 > 0)
                {
                    _idtbl.DefaultView.RowFilter = "avg_name='" + txt_name.ControlValue + "'";
                    this.FindID = PLABS.Utils.CnvToStr(_idtbl.Rows[0]["avg_mast_id"]);
                }
                else
                {
                    PLABS.MessageBoxPL.Show("No Rows Found");
                }
                 
            }
            catch(Exception ex)
            {

            }
        }

        void RP_009_DeleteAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.doDelete(this.FindID);
            }
            catch (Exception ex)
            {
                
            }
        }

        void txt_name_TextChanged(object sender, EventArgs e)
        {
            _dtLoadGrid.DefaultView.RowFilter = "avg_name='" + txt_name.ControlValue + "'";
            DataTable dt = _dtLoadGrid.DefaultView.ToTable();
            dt.Columns.Remove("avg_name");
           
            //if (dt.Rows.Count > 0)
            //{
               
            //  //  dt= this.CalculateTotal(dt);
            //}
           dt.Columns[0].DefaultValue = DateTime.Now.ToString("dd-MMM-yyyy");
          this.grd_data_save.DataSource = dt;
            _temp = 0;
        }
       
        void RP_009_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                
                    this.doSave();
                
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrgrup", "0012");
            }
        }

        void RP_009_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                 
                if (!this.isValidData())
                    this.CancelProcess = true;

                
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrgrup", "0011");
            }
        }
        void grd_data_save_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grd_data_save.CurrentCell.IsInEditMode)
                {
                    grd_data_save.EndEdit();

                }
                _bdRate = PLABS.Utils.CnvToStr(this.grd_data_save.Rows[e.RowIndex].Cells["txt_bord_rate_save_gv"].EditedFormattedValue);
                _purChek = PLABS.Utils.CnvToStr(this.grd_data_save.Rows[e.RowIndex].Cells["txt_mc_save_gv"].EditedFormattedValue);
                _salChek = PLABS.Utils.CnvToStr(this.grd_data_save.Rows[e.RowIndex].Cells["txt_recwgt_save_gv"].EditedFormattedValue);
            }
        }
        void grd_data_save_CellLeave(object sender, DataGridViewCellEventArgs e)
            {

            string date=string.Empty;



            if (txt_name.ControlValue != string.Empty )
            {
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
                {
                    if (grd_data_save.CurrentCell.IsInEditMode)
                    {
                        grd_data_save.EndEdit();





                        string xml = grd_data_save.ControlValue;
                        DataSet ds = PLABS.Utils.CnvXMLToDataSet(xml);
                        DataTable dtGrdDataSource = ds.Tables[0];

                        int rowindx = e.RowIndex;
                        int colindx = e.ColumnIndex;
                        //if (e.ColumnIndex == 2)
                        //{
                        double balTotal = 0;
                        double rateTotal = 0;
                        double purAvg = 0;
                        for (int i = 0; i < dtGrdDataSource.Rows.Count; i++)
                        {
                            double bdrate = PLABS.Utils.CnvToDouble(dtGrdDataSource.Rows[i]["bord"]);
                            double purchase = PLABS.Utils.CnvToDouble(dtGrdDataSource.Rows[i]["purc"]);
                            double sales = PLABS.Utils.CnvToDouble(dtGrdDataSource.Rows[i]["sales"]);
                           
                            if (bdrate > 0 && purchase > 0)
                            {
                                double total = 0;
                                balTotal -= purchase;
                               
                                this.grd_data_save.Rows[i].Cells["txt_recwgt_save_gv"].Value = "0";
                                total = bdrate * purchase;
                                rateTotal -= total;
                                if (rateTotal != 0)
                                {
                                    if (balTotal != 0)
                                    {
                                        purAvg = rateTotal / balTotal;
                                    }
                                    else
                                    {
                                        purAvg = rateTotal / 1;
                                    }
                                }
                                else
                                {
                                    purAvg = 0;
                                }

                                this.grd_data_save.Rows[i].Cells["txt_mcrt_save_gv"].Value = purAvg.ToString("F2");
                                this.grd_data_save.Rows[i].Cells["txt_balwt_data_gv"].Value = balTotal.ToString("F3");
                                if (i == 0)
                                {
                                    
                                    this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value = PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_bord_rate_save_gv"].Value) * PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_mc_save_gv"].Value);
                                    this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value = PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value) * -1;
                                }
                                else
                                {
                                    this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value = PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_bord_rate_save_gv"].Value) * PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_mc_save_gv"].Value);
                                    this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value = PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i - 1].Cells["txt_totl_gv"].Value) - PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value);

                                }
                                
                            }
                            else if (bdrate > 0 && sales > 0)
                            {
                                double total = 0;
                                balTotal += sales;
                                
                                this.grd_data_save.Rows[i].Cells["txt_mc_save_gv"].Value = "0";
                                total = bdrate * sales;
                                rateTotal += total;
                                if (rateTotal != 0)
                                {
                                    if (balTotal != 0)
                                    {
                                        purAvg = rateTotal / balTotal;
                                    }
                                    else
                                    {
                                        purAvg = rateTotal / 1;
                                    }
                                }
                                else
                                {
                                    purAvg = 0;
                                }
                                this.grd_data_save.Rows[i].Cells["txt_mcrt_save_gv"].Value = purAvg.ToString("F2");
                                this.grd_data_save.Rows[i].Cells["txt_balwt_data_gv"].Value = balTotal.ToString("F3");

                                if (i == 0)
                                {
                                    this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value = PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_bord_rate_save_gv"].Value) * PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_recwgt_save_gv"].Value);
                                }
                                else
                                {
                                    this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value = PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_bord_rate_save_gv"].Value) * PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_recwgt_save_gv"].Value);

                                    this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value = PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i - 1].Cells["txt_totl_gv"].Value) + PLABS.Utils.CnvToDouble(this.grd_data_save.Rows[i].Cells["txt_totl_gv"].Value);

                                }
                                
                            }

                        }
                    }
                }

                
                
            }
            else
            {
                PLABS.MessageBoxPL.Show("Please Enter Name", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                //txt_name.Focus();
            }
             
        }

        void dtp_to_Leave(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }
         
        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }   

        #endregion

        #region Methods
 
        private void LoadControls()
        {
            try
            {
                //this.txt_name.Text = " ";
                
                this.loadSavData();
                this.BindSaveGrid();
                this.LoadGrid();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void loadSavData()
        {
            AutoCompleteStringCollection _objSrcNam = new AutoCompleteStringCollection();
            Hashtable htName = new Hashtable();
            DataTable dt = PLABS.Utils.GetDataTable(this.GetDataSet("LN"), 0);
            _idtbl = dt;
            _dtLoadGrid = PLABS.Utils.GetDataTable(this.GetDataSet("LN"), 1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String name =" "+ PLABS.Utils.CnvToStr(dt.Rows[i]["avg_name"]);


                if (!htName.ContainsKey(name))
                {
                    htName.Add(name, PLABS.Utils.CnvToStr(dt.Rows[i]["avg_mast_id"]));
                }
            }
            foreach (object keys in htName.Keys)
            {
                _objSrcNam.Add(PLABS.Utils.CnvToStr(keys));

            }
            txt_name.AutoCompleteCustomSource = _objSrcNam;
        }
        public void LoadGrid()
        {
            try
            {
                this.PopulateGrid();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private DataSet GetDataSet(String as_mode)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode));
                xmlData = this.CallWS(xmlData, "BizObj.RP_009,BizObj", "S");
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
                //BizObj.RP_009 obj = new BizObj.RP_009();
                //xmlData = obj.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return xmlData;
        }
        private void BindGrid( )
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns[0].DefaultValue = DateTime.Now.ToString("dd-MMM-yyyy");
            dt.Columns.Add("bord", typeof(string));



            dt.Columns.Add("purc", typeof(string));
            dt.Columns.Add("sales", typeof(string));
            dt.Columns.Add("bal", typeof(string));
                dt.Columns.Add("avgra", typeof(string));
        

            grd_data.DataSource = dt;
            
        }
        private void BindSaveGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("bord" );

            

                dt.Columns.Add("purc" );
                dt.Columns.Add("sales" );
                dt.Columns.Add("bal" );
                dt.Columns.Add("avgra");
             

            grd_data_save.DataSource = dt;

        }
        private void PopulateGrid()
        {
            try
            {
                int vou_id = 0;
                Double avgrate = 0.00, bal = 0.00, rate = 0.00;
                _sal = 0.00; _pur = 0.00;
                this.BindGrid();
                DataSet ds = this.GetDataSet("LG");
                DataTable dt = (DataTable)this.grd_data.DataSource;
                DataTable master = PLABS.Utils.GetDataTable(ds, 0);

                foreach (DataRow dr in master.Rows)
                {     
                    DataRow newRow = dt.NewRow();
                    newRow["bord"] = PLABS.Utils.CnvToDouble(dr["brd_rt"]);
                    newRow["date"] = PLABS.Utils.CnvToStr(dr["date"]);
                    vou_id = PLABS.Utils.CnvToInt(dr["vou_typ_id"]);
                    if (vou_id == 3)
                    {
                        double purchase = PLABS.Utils.CnvToDouble(dr["wt"]);
                        newRow["purc"] = PLABS.Utils.CnvToDouble(purchase.ToString("N3"));
                        newRow["sales"] = "0";
                        bal -= PLABS.Utils.CnvToDouble(dr["wt"]);
                        
                        rate -= PLABS.Utils.CnvToDouble(dr["wt"]) * PLABS.Utils.CnvToDouble(dr["brd_rt"]);
                        _pur += PLABS.Utils.CnvToDouble(dr["wt"]) * PLABS.Utils.CnvToDouble(dr["brd_rt"]);
                        avgrate = rate / bal;
                        newRow["avgra"] = avgrate.ToString("N2");
                    }
                    else
                    {
                        double sales = PLABS.Utils.CnvToDouble(dr["wt"]);
                        newRow["sales"] = PLABS.Utils.CnvToDouble(sales.ToString("N3"));
                        newRow["purc"] = "0";
                        bal += PLABS.Utils.CnvToDouble(dr["wt"]);
                        rate += PLABS.Utils.CnvToDouble(dr["wt"]) * PLABS.Utils.CnvToDouble(dr["brd_rt"]);
                        
                        _sal += PLABS.Utils.CnvToDouble(dr["wt"]) * PLABS.Utils.CnvToDouble(dr["brd_rt"]);
                        avgrate = rate / bal;
                        newRow["avgra"] = avgrate.ToString("N2");
                    }
                    newRow["bal"] = bal.ToString("N3");
                    dt.Rows.Add(newRow);
                }

                this.RemovalOfZeros(grd_data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void RemovalOfZeros(PLABSn.DataGridViewPL grd)
        {
            try
            {
                DataTable dt = (DataTable)(grd.DataSource);
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                       string colName= dt.Columns[j].ColumnName;

                       if (colName == "sales" || colName == "purc" || colName == "bal" || colName == "avgra" || colName == "bord")
                       {
                           if (PLABS.Utils.CnvToDouble(dt.Rows[i][j]) == 0)
                           {
                               dt.Rows[i][j] = DBNull.Value;
                           }
                       }
                    }
                }
            }
            catch 
            {

            }
        }
        private DataTable CalculateTotal(DataTable dt)
        {
            string mode = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (PLABS.Utils.CnvToDouble(dt.Rows[i]["purc"]) != 0)
                    {
                        mode = "p";
                        dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["bord"]) * PLABS.Utils.CnvToDouble(dt.Rows[i]["purc"]);
                    }
                    else
                    {
                        mode = "s";
                        dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["bord"]) * PLABS.Utils.CnvToDouble(dt.Rows[i]["sales"]);

                    }
                }
                else
                {
                    if (PLABS.Utils.CnvToDouble(dt.Rows[i]["purc"]) != 0)
                    {
                        dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["bord"]) * PLABS.Utils.CnvToDouble(dt.Rows[i]["purc"]);
                        if (mode == "p")
                        {
                            dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["ttl"]) * -1;
                            dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["ttl"]) + (PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["ttl"]));
                        }
                        else
                        {
                           
                            dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i-1]["ttl"]) - PLABS.Utils.CnvToDouble(dt.Rows[i ]["ttl"]);
                            mode = "p";
                        }

                    }
                    else
                    {
                        dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["bord"]) * PLABS.Utils.CnvToDouble(dt.Rows[i]["sales"]);
                        if (mode == "s")
                        {
                            dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["ttl"]) + PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["ttl"]);

                        }
                        else
                        {
                            dt.Rows[i]["ttl"] = PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["ttl"]) + PLABS.Utils.CnvToDouble(dt.Rows[i]["ttl"]);
                            mode = "s";
                        }

                    }
                }
               
            }
            return dt;
        }
        private void setData(DataTable dt)
        {
            this.grd_data_save.DataSource = dt;
        }
        private void doSave()
        {
            try
            {
                 
               
                string xmlData = this.ProcessXml;
                xmlData = PLABS.Utils.addNode(xmlData, "as_xml_avg",PLABS.Utils.CnvToStr(PLABS.CreateProcessXml.FormatString(grd_data_save.ControlValue)));
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                xmlData = this.CallWS(xmlData, "BizObj.RP_009,BizObj", "");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    
                }
                else if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.btn_save.Enabled = true;
                    this.loadSavData();
                    this.txt_name.Focus();
                     
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //ErrorLo8g.Insert(ex.Message, "maaddrgrup", "0005");
            }
        }
        private bool isValidData()
        {
            DataTable dt=(DataTable)grd_data_save.DataSource;
            if (dt.Rows.Count == 0)
            {
                
                PLABS.MessageBoxPL.Show("Please Enter Transaction Details", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                grd_data_save.Focus();
                return false ;
               
            }
            return true ;
        }
        private void doDelete(String addr_id)
        {
            if (grd_data_save.Rows.Count > 0)
            {
                String xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "D");
                xmlData = PLABS.Utils.addNode(xmlData, "ai_avg_mast_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.RP_009,BizObj", "D");
                if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Deleted Successfully");

                }
                else
                {
                    this.CancelProcess = true;
                }
            }
            else
            {
                PLABS.MessageBoxPL.Show("No Rows Found");
            }
        }
        #endregion

        
    }
}
