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
    public partial class RP_016 : PLABS.MasterForm
    {
        #region Global variable

        String _Type = "C";
        bool _isLoad = true;
        double _tropn=0.000;
        double _tropnAmt = 0.00;
        int _mnth = DateTime.Now.Month;
        double _trsaleopn = 0.000;
                    
        #endregion
        #region Properties

        #endregion
        #region Contructor

        public RP_016()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            this.loadControls();
            this.grd_gldrgtr.CellDoubleClick += new DataGridViewCellEventHandler(grd_gldrgtr_CellDoubleClick);
            this.grd_gldrgtr.KeyDown += new KeyEventHandler(grd_gldrgtr_KeyDown);
            this.txt_brdrt.TextChanged += new EventHandler(txt_brdrt_TextChanged);
            //this.grd_cptl.GotFocus += new EventHandler(grd_cptl_GotFocus);
            //this.grd_cptl.LostFocus += new EventHandler(grd_cptl_LostFocus);
            //this.grd_cptl.CellEnter += new DataGridViewCellEventHandler(grd_cptl_CellEnter);
            this.btn_curmnth.Click += new EventHandler(btn_curmnth_Click);
            this.grd_gldrgtr.DataError += new DataGridViewDataErrorEventHandler(grd_gldrgtr_DataError);
            //this.grd_cptl.DataError += new DataGridViewDataErrorEventHandler(grd_cptl_DataError);
            //this.txt_opnAmt.TextChanged += new EventHandler(txt_opnAmt_TextChanged);
            //this.txt_opnwt.TextChanged += new EventHandler(txt_opnwt_TextChanged);
            this.txt_brdrt.TextChanged+=new EventHandler(txt_brdrt_TextChanged);
            //btn_redonly.Click += new EventHandler(btn_redonly_Click);
            //this.btn_save.Click += Btn_save_Click;
            this.btn_clear.Click += Btn_clear_Click;
            txt_brdrt.Focus();
        }

        private void loadYearMonth()
        {

            //int year = 2020;
            //for (int i = DateTime.Now.Year; i >= year; i--)
            //    this.ddl_year.AddRow(PLABS.Utils.CnvToStr(i), i);

            //this.ddl_year.ControlValue = DateTime.Now.Year.ToString();

            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("January"), 1);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("February"), 2);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("March"), 3);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("April"), 4);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("May"), 5);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("June"), 6);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("July"), 7);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("August"), 8);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("September"), 9);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("October"), 10);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("November"), 11);
            //this.ddl_month.AddRow(PLABS.Utils.CnvToStr("December"), 12);

            //this.ddl_month.ControlValue = PLABS.Utils.CnvToStr(1);
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            doClear();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_Type == "C")
            {
                DataSet ds = this.GetDataSet("I");
            }
            base.OnClosed(e);
        }
        #endregion  
        #region Event
        //void btn_redonly_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string state = PLABS.Utils.CnvToStr(this.txt_opnwt.ReadOnly);
        //        if (state == "True")
        //        {
        //            this.txt_opnwt.ReadOnly = false;
        //            this.txt_opnAmt.ReadOnly = false;
        //            this.txt_brdrt.ReadOnly = false;
        //            this.grd_gldrgtr.Focus();
                    
        //        }
        //        else
        //        {
        //            this.txt_opnwt.ReadOnly = true;
        //            this.txt_opnAmt.ReadOnly = true;
        //            this.txt_brdrt.ReadOnly = true;
        //            this.txt_opnwt.Focus();
                   
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        private void btn_month_Click(object sender, EventArgs e)
        {
            try
            {
                //this.MonthVize();
                this._Type = "M";
               
                //this.loadCapital();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void btn_date_Click(object sender, EventArgs e)
        {
            try
            {
                ///this.DateVize();
                this._Type = "D";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        void txt_brdrt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this.ConvertWeightIntoCash("C");
                //this.WeightToCash();
            }
            catch (Exception ex)
            {
 
            }
        }
        private void grd_gldrgtr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string colName = this.grd_gldrgtr.Columns[e.ColumnIndex].HeaderText;
                //if (colName == "WEIGHT")
                //if(this._Type=="C")
                    //this.GridDoubleClick(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        void grd_gldrgtr_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                this.GridDoubleClick(this.grd_gldrgtr.CurrentRow.Index, this.grd_gldrgtr.CurrentCell.ColumnIndex);
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_curmnth_Click(object sender, EventArgs e)
        {
            try
            {
                this._Type = "C";
                this._mnth = DateTime.Now.Month;

                if (dp_frm.ControlValue == string.Empty)
                {
                    PLABS.MessageBoxPL.Show("Please select from date", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);


                    dp_frm.Focus();
                }
                else if (dp_to.ControlValue == string.Empty)
                {
                    PLABS.MessageBoxPL.Show("Please select to date", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    dp_to.Focus();
                }
                else if (dp_frm.Value > dp_to.Value)
                {
                    PLABS.MessageBoxPL.Show("From date is greater than to date", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    dp_frm.Focus();
                }
                else
                {
                    this.loadGrid();
                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_cptl_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!_isLoad)
                {
                    this._Type = "M";
                    //this.loadData(this.BindVtype());
                    _tropnAmt = 0.00;
                    this.MontlyReport(e.RowIndex);
                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_cptl_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_isLoad)
                {
                    //this.loadData(this.BindVtype());
                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_cptl_LostFocus(object sender, EventArgs e)
        {
            try
            {
                _isLoad = true;
            }
            catch (Exception ex)
            {

            }
        }
        void grd_cptl_GotFocus(object sender, EventArgs e)
        {
            try
            {
                _isLoad = false;


            }
            catch (Exception ex)
            {

            }
        }
        void grd_cptl_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        void grd_gldrgtr_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        void txt_opnAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this.ConvertWeightIntoCash("CO");
                this.WeightToCash();
            }
            catch (Exception ex)
            {
 
            }
        }

        void txt_opnwt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.OpeningWeightBinding();
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
        #region Method
        private void loadControls()
        {
            try
            {

                //this.loadMonth();


                //loadYearMonth();
                //this.BindGrid();

                DataSet ds = this.GetDataSet("LO");

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.dp_frm.ControlValue = PLABS.Utils.CnvToStr(ds.Tables[0].Rows[0]["cur_date"]);
                    this.dp_to.ControlValue = PLABS.Utils.CnvToStr(ds.Tables[0].Rows[0]["cur_date"]);
                }

                //DataSet ds = this.GetDataSet("LG", "", "");
                //if (ds.Tables.Count != 0)
                //{

                //    DataTable dt = PLABS.Utils.GetDataTable(ds, 0);

                //    this.loadData(dt);
                //    //this.grd_cptl.DataSource = PLABS.Utils.GetDataTable(ds, 1);
                //}

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void loadGrid()
        {


            DataSet ds = this.GetDataSet("LG");
            if (ds.Tables.Count != 0)
            {

                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                DataTable dt1 = PLABS.Utils.GetDataTable(ds, 1);

                BindGrid();

                DataTable dtData = (DataTable)this.grd_gldrgtr.DataSource;

                dtData.Rows.Clear();
                txt_brdrt.ClearControl(true);
                txt_amt.ClearControl(true);
                double boardRate = 0;
                double fixAmt = 0;
                if (dt.Rows.Count > 0)
                {
                    boardRate = PLABS.Utils.CnvToDouble(dt.Rows[0]["board_rate"]);
                    fixAmt = PLABS.Utils.CnvToDouble(dt.Rows[0]["fix_amt"]);

                    txt_brdrt.ControlValue = boardRate.ToString();
                    txt_amt.ControlValue = fixAmt.ToString();

                    DataRow drOp = dtData.NewRow();
                    drOp["name"] = "Opening";
                    drOp["bala"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["opening"]);
                    dtData.Rows.Add(drOp);
                }

                if (dt1.Rows.Count > 0)
                {
                    double mcwt = PLABS.Utils.CnvToDouble(dt1.Rows[0]["mc"]);
                    double difftouch = PLABS.Utils.CnvToDouble(dt1.Rows[0]["diff_tuch"]);
                    double surplus = PLABS.Utils.CnvToDouble(dt1.Rows[0]["surplus"]);
                    double shrt = PLABS.Utils.CnvToDouble(dt1.Rows[0]["short"]);
                    double stone = PLABS.Utils.CnvToDouble(dt1.Rows[0]["stone"]);
                    double balWt = mcwt + difftouch + surplus + shrt + stone;
                    string openingDate = PLABS.Utils.CnvToDate(dt1.Rows[0]["openingdate"]).ToString("dd-MMM-yyyy");
                    string closingDate = PLABS.Utils.CnvToDate(dt1.Rows[0]["closingdate"]).ToString("dd-MMM-yyyy");
                    double opening = PLABS.Utils.CnvToDouble(dt1.Rows[0]["opening"]);
                    double closing = PLABS.Utils.CnvToDouble(dt1.Rows[0]["closing"]);

                    int summary = 1;
                    summary = (stone != 0 ? 5 : (shrt != 0 ? 4 : (surplus != 0 ? 3 : (difftouch != 0 ? 2 : (mcwt != 0 ? 1 : 1)))));


                    if (mcwt != 0)
                    {
                        DataRow drMc = dtData.NewRow();
                        drMc["name"] = "MC WT";
                        drMc["wt"] = mcwt;
                        if(summary==1)
                            drMc["bala"] = PLABS.Utils.CnvToDouble((balWt * boardRate).ToString("F2"));
                        dtData.Rows.Add(drMc);
                    }

                    
                    if (difftouch != 0)
                    {
                        DataRow drDiffTouch = dtData.NewRow();
                        drDiffTouch["name"] = "DIFF TOUCH";
                        drDiffTouch["wt"] = difftouch;
                        if (summary == 2)
                            drDiffTouch["bala"] = PLABS.Utils.CnvToDouble((balWt * boardRate).ToString("F2"));
                        dtData.Rows.Add(drDiffTouch);
                    }

                    
                    if (surplus != 0)
                    {
                        DataRow drSurplus = dtData.NewRow();
                        drSurplus["name"] = "SURPLUS";
                        drSurplus["wt"] = surplus;
                        if (summary == 3)
                            drSurplus["bala"] = PLABS.Utils.CnvToDouble((balWt * boardRate).ToString("F2"));
                        dtData.Rows.Add(drSurplus);
                    }


                    
                    if (shrt != 0)
                    {
                        DataRow drShort = dtData.NewRow();
                        drShort["name"] = "SHORT";
                        drShort["wt"] = shrt;
                        if (summary == 4)
                            drShort["bala"] = PLABS.Utils.CnvToDouble((balWt * boardRate).ToString("F2"));
                        dtData.Rows.Add(drShort);
                    }

                    
                    if (stone != 0)
                    {
                        DataRow drStone = dtData.NewRow();
                        drStone["name"] = "STONE WT";
                        drStone["wt"] = stone;
                        if (summary == 4)
                            drStone["bala"] = PLABS.Utils.CnvToDouble((balWt * boardRate).ToString("F2"));
                        dtData.Rows.Add(drStone);
                    }

                    double mc_cash = PLABS.Utils.CnvToDouble(dt1.Rows[0]["mc_cash"]);
                    if (mc_cash != 0)
                    {
                        DataRow drMcCash = dtData.NewRow();
                        drMcCash["name"] = "MC CASH";
                        drMcCash["bala"] = mc_cash;
                        dtData.Rows.Add(drMcCash);
                    }

                    double stone_cash = PLABS.Utils.CnvToDouble(dt1.Rows[0]["stone_cash"]);
                    if (stone_cash != 0)
                    {
                        DataRow drStoneCash = dtData.NewRow();
                        drStoneCash["name"] = "STONE CASH";
                        drStoneCash["bala"] = stone_cash;
                        dtData.Rows.Add(drStoneCash);
                    }


                    double expnse = PLABS.Utils.CnvToDouble(dt1.Rows[0]["expnse"]);
                    if (expnse != 0)
                    {
                        DataRow drExp = dtData.NewRow();
                        drExp["name"] = "EXPENSE";
                        drExp["bala"] = expnse;
                        dtData.Rows.Add(drExp);
                    }

                    DataRow drTotal = dtData.NewRow();
                    drTotal["name"] = "TOTAL";

                    drTotal["bala"] = Math.Round((balWt * boardRate) + mc_cash + stone_cash + expnse, 2);
                    dtData.Rows.Add(drTotal);


                    DataRow drBlank = dtData.NewRow();
                    dtData.Rows.Add(drBlank);
                    drBlank = dtData.NewRow();
                    dtData.Rows.Add(drBlank);

                    DataRow drO = dtData.NewRow();
                    drO["name"] = openingDate+" CLOSING";

                    drO["bala"] = opening;
                    dtData.Rows.Add(drO);

                    DataRow drC = dtData.NewRow();
                    drC["name"] = closingDate + " CLOSING";

                    drC["bala"] = closing;
                    dtData.Rows.Add(drC);

                    DataRow drT = dtData.NewRow();
                    drT["name"] =  "CALCULATED BALANCE";
                    drT["bala"] = closing - opening;
                    dtData.Rows.Add(drT);


                }


            }

        }




        //private void loadMonth()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Id");
        //    dt.Columns.Add("month");

        //    DataRow dr = dt.NewRow();
        //    dr["Id"] = 1;
        //    dr["month"] = "January";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 2;
        //    dr["month"] = "February";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 3;
        //    dr["month"] = "March";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 4;
        //    dr["month"] = "April";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 5;
        //    dr["month"] = "May";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 6;
        //    dr["month"] = "June";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 7;
        //    dr["month"] = "July";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 8;
        //    dr["month"] = "August";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 9;
        //    dr["month"] = "September";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 10;
        //    dr["month"] = "October";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 11;
        //    dr["month"] = "November";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Id"] = 12;
        //    dr["month"] = "December";
        //    dt.Rows.Add(dr);

        //    //this.ddl_month.LoadData(dt, "month", "Id");

        //}
        //private void DateVize()
        //{
        //    //DataSet ds = this.GetDataSet("LG",, this.dp_to.Value.ToString("yyyy-MM-dd"));
        //    //this.loadData(PLABS .Utils.GetDataTable(ds,0));
        //    //this.grd_cptl.DataSource = PLABS.Utils.GetDataTable(ds, 1);
        //}
        //private void MonthVize()
        //{
        //    DateTime frmDate = new DateTime();//= PLABS.Utils.CnvToDate(string.Format("{0}-01-{1}", this.ddl_month.ControlValue, this.txt_year.ControlValue));
        //    DateTime todate =(frmDate .AddMonths(1)).AddDays(-1);
        //    DataSet ds = this.GetDataSet("LG", frmDate.ToString("yyyy-MM-dd"), todate.ToString("yyyy-MM-dd"));
        //    this.loadData(PLABS .Utils .GetDataTable (ds,0));
        //    this.grd_cptl.DataSource =PLABS .Utils .GetDataTable(ds,1);
        //}
        private void loadData(DataTable data,DataTable dt1,DataTable dt2)
        {
            //if (data.Rows.Count > 0)
            //{
            //    DataRow[] purSalRows = data.Select("vtyp IN('3','4')");
            //    double wt = 0.000;
            //    if (purSalRows.Length > 0)
            //    {
            //        foreach (DataRow purSalRow in purSalRows)
            //        {
            //            wt += PLABS.Utils.CnvToDouble(purSalRow["wt"]);
            //        }
            //    }

            //    //data.Rows.Add("SALES", -(wt * PLABS.Utils.CnvToDouble(this.txt_brdrt.Text)), "CP");

            //    DataRow[] dr1 = data.Select("vtyp='CO' AND name='OPENING AMOUNT'");
            //    if (dr1.Length != 0)
            //    {
            //        _tropnAmt = PLABS.Utils.CnvToDouble(dr1[0]["wt"]);
            //    }
            //}
            
            this.BindGrid();
            
            DataTable dt = (DataTable)this.grd_gldrgtr.DataSource;
           
            Double bal = 0.000;
            double balCash = 0.00;
            int i = 0;
            if (_Type != "C")
            {
                DataRow[] opnRow = data.Select("vtyp='O' AND name='OPENING'");
                if (opnRow.Length != 0)
                {
                    _tropn = PLABS.Utils.CnvToDouble(opnRow[0]["wt"]);
                }
            }
            foreach (DataRow dr in data.Rows)
            {
                DataRow newRow = dt.NewRow();

               
                newRow["name"] = dr["name"];
                //if (i == 0)
                //{
                //    //newRow["wt"] = _tropn + PLABS.Utils.CnvToDouble(this.txt_opnwt.Text);
                //}
                //else 
                //{
                newRow["wt"] = dr["wt"];
                //}
              
                if (PLABS.Utils.CnvToStr(dr["vtyp"]).StartsWith("C"))
                {
                    balCash += PLABS.Utils.CnvToDouble(newRow["wt"]);
                    newRow["bala"] = balCash;
                }
                else if (PLABS.Utils.CnvToStr(dr["vtyp"]) == "WS")
                {
                    bal = bal-PLABS.Utils.CnvToDouble(newRow["wt"]);
                    newRow["bala"] = bal;
                }
                else
                {
                    bal += PLABS.Utils.CnvToDouble(newRow["wt"]);
                    newRow["bala"] = bal;
                }
                
                newRow["vtyp"] = dr["vtyp"];
                i += 1;
                dt.Rows.Add(newRow);

            }
            double boardRate = PLABS.Utils.CnvToDouble(txt_brdrt.ControlValue);

            double fixedAmount = PLABS.Utils.CnvToDouble(txt_amt.ControlValue);
            double openingAmount = 0,pur = 0,sales=0,cbaln=0;

            DataRow dar = dt.AsEnumerable()
               .SingleOrDefault(row => row.Field<string>("name") == "OPENING AMOUNT");

            if (dar == null)
            {
                openingAmount= Math.Round((bal * boardRate), 2);
                DataRow r = dt.NewRow();
                r["name"] = "OPENING AMOUNT";
                r["wt"] = openingAmount;
                r["bala"] = Math.Round((bal * boardRate));
                r["vtyp"] = "C";
                dt.Rows.Add(r);

                cbaln = openingAmount;
            }
            else
            {
                dar["wt"] = Math.Round(bal * boardRate, 2);
                dar["bala"] = Math.Round(bal * boardRate);

                cbaln = openingAmount;
            }

            DataRow drCashBalance = null;

            foreach (DataRow dr1 in dt1.Rows)
            {
               


                if (PLABS.Utils.CnvToStr(dr1["name"]) == "OUTSTANDING CASH")
                {
                    DataRow newRow = dt.NewRow();
                    cbaln += PLABS.Utils.CnvToDouble(dr1["wt"]);

                    newRow["name"] = dr1["name"];

                    newRow["wt"] = dr1["wt"];
                    newRow["bala"] = cbaln;
                    newRow["vtyp"] = dr1["vtyp"];
                    dt.Rows.Add(newRow);
                }
                else
                {
                    drCashBalance = dt.NewRow();
                    drCashBalance["name"] = dr1["name"];

                    drCashBalance["wt"] = dr1["wt"];
                    drCashBalance["vtyp"] = dr1["vtyp"];
                    
                }

                

            }


            if (fixedAmount != 0)
            {
                cbaln += fixedAmount;
                cbaln = Math.Round(cbaln, 2);
                DataRow newRow = dt.NewRow();
                newRow["name"] = "FIXED AMOUNT";
                newRow["wt"] = fixedAmount;
                newRow["bala"] = cbaln;
                newRow["vtyp"] = "F";
                dt.Rows.Add(newRow);
            }

            if (drCashBalance != null)
            {
                cbaln += PLABS.Utils.CnvToDouble(drCashBalance["wt"]);
                drCashBalance["bala"] = cbaln;
                dt.Rows.Add(drCashBalance);
            }

            


            var result1 = dt2
                        .AsEnumerable()
                        .Where(myRow => myRow.Field<long>("vou_typ_id") == 4);

            DataRow salesRow = dt.NewRow();

            if (result1 != null)
            {
                foreach (DataRow drSal in result1)
                {
                    double s = Math.Round(PLABS.Utils.CnvToDouble(drSal["wt"]) * (PLABS.Utils.CnvToDouble(txt_brdrt.ControlValue) - PLABS.Utils.CnvToDouble(drSal["brd_rt"])), 2);
                    sales += s;
                }
                cbaln += sales;
                cbaln = Math.Round(cbaln, 2);
                salesRow["name"] = "SALES";
                salesRow["wt"] = sales;
                salesRow["bala"] = cbaln;
                salesRow["vtyp"] = "S";
                dt.Rows.Add(salesRow);

            }

            var result2 = dt2
                       .AsEnumerable()
                       .Where(myRow => myRow.Field<long>("vou_typ_id") == 3);

            DataRow purchaseRow = dt.NewRow();

            if (result2 != null)
            {

                foreach (DataRow drPur in result2)
                {
                    double p = Math.Round(PLABS.Utils.CnvToDouble(drPur["wt"]) * (PLABS.Utils.CnvToDouble(txt_brdrt.ControlValue) - PLABS.Utils.CnvToDouble(drPur["brd_rt"])), 2);
                    pur += p;
                }
                cbaln -= pur;
                cbaln = Math.Round(cbaln, 2);
                purchaseRow["name"] = "PURCHASE";
                purchaseRow["wt"] = pur;
                purchaseRow["bala"] = cbaln;
                purchaseRow["vtyp"] = "P";
                dt.Rows.Add(purchaseRow);

            }


            //this.ConvertWeightIntoCash("C");
            //this.WeightToCash();
            //this.WeightRowColour();
            //this.GetTotalWeight();
            //this.loadCapital();
        } 
        private void BindGrid()
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("wt", typeof(double));
            dt.Columns.Add("bala", typeof(double));
            dt.Columns.Add("vtyp", typeof(string));

            this.grd_gldrgtr.DataSource = dt;
        }
        private void GridDoubleClick(int rowNum, int colNum)
        {
            DateTime dtFrom = new DateTime(DateTime.Now.Year,_mnth, 1);
            String dtTo = PLABS.Utils.CnvToDate(dtFrom.AddMonths(1).AddDays(-1)).ToString("yyyy-MM-dd");
            String[] parameters = new String[3];
            parameters[0] = PLABS.Utils.CnvToStr(this.grd_gldrgtr.Rows[rowNum].Cells["txt_vtyp_gv"].Value);
                parameters[1] = dtFrom.ToString("yyyy-MM-dd");
                parameters[2] = dtTo;
           
            //else
            //{
            //    parameters[1] = PLABS.Utils.CnvToStr(this.dp_frm.Value.ToString("yyyy-MM-dd"));
            //    parameters[2] = PLABS.Utils.CnvToStr(this.dp_to.Value.ToString("yyyy-MM-dd"));
            //}

                if (parameters[0] != "O"&& parameters[0] != "CO")
                {
                    if (parameters[0] == "CI")
                    {
                        CO_005 objpopup = new CO_005();
                        objpopup.Parameters = parameters;
                        objpopup.Text = PLABS.Utils.CnvToStr(this.grd_gldrgtr.CurrentRow.Cells["txt_stkitm_gv"].Value);
                        objpopup.ShowDialog();
                    }
                    else if (parameters[0] == "WO" || parameters[0] == "CT")
                    {
                        FL_003 objpopup = new FL_003();
                        objpopup.Text = PLABS.Utils.CnvToStr(this.grd_gldrgtr.CurrentRow.Cells["txt_stkitm_gv"].Value);
                        objpopup.ShowDialog();
                    }
                    else if (parameters[0] == "WP")
                    {
                        RP_006 objpopup = new RP_006();
                        objpopup.Text = PLABS.Utils.CnvToStr(this.grd_gldrgtr.CurrentRow.Cells["txt_stkitm_gv"].Value);
                        objpopup.ShowDialog();
                    }
                    else if (parameters[0] == "WS")
                    {
                        TD_001 objpopup = new TD_001();
                        objpopup.Text = PLABS.Utils.CnvToStr(this.grd_gldrgtr.CurrentRow.Cells["txt_stkitm_gv"].Value);
                        objpopup.ShowDialog();
                    }
                    else
                    {
                        CO_004 objpopup = new CO_004();
                        objpopup.Parameters = parameters;
                        objpopup.Text = PLABS.Utils.CnvToStr(this.grd_gldrgtr.CurrentRow.Cells["txt_stkitm_gv"].Value);
                        objpopup.ShowDialog();
                    }
                }
            
        }
        //private void EnterCapital()
        //{

        //    if (_Type == "M")
        //    {
        //        DateTime dt = DateTime.Now;
        //        DateTime frmDate = new DateTime(dt.Year, PLABS.Utils.CnvToInt(this.ddl_month.SelectedValue), 1);
        //        DateTime todate = new DateTime(dt.Year, PLABS.Utils.CnvToInt(this.ddl_month.SelectedValue), 30);
        //        this.loadData("LG",frmDate.ToString("yyyy-MM-dd"), todate.ToString("yyyy-MM-dd"));
        //    }
        //    else if (_Type == "D")
        //    {
        //        this.loadData("LG",this.dp_frm.Value.ToString("yyyy-MM-dd"), this.dp_to.Value.ToString("yyyy-MM-dd"));
        //    }   
        //}
        private DataSet GetDataSet(String as_mode)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode));
                xmlData = this.CallWS(xmlData, "BizObj.RP_016,BizObj", "S");
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
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", Properties.Settings.Default.id.ToString());
                argXml = PLABS.Utils.addNode(argXml, "ad_from_date", dp_frm.ControlValue!=string.Empty ? PLABS.Utils.CnvToDate(dp_frm.ControlValue).ToString("yyyy-MM-dd"): "");
                argXml = PLABS.Utils.addNode(argXml, "ad_to_date", dp_to.ControlValue != string.Empty ? PLABS.Utils.CnvToDate(dp_to.ControlValue).ToString("yyyy-MM-dd") : "");


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
        //private void loadCapital()
        //{
        //    try
        //    {
        //        string xmlData = this.getBlankXml();
        //        xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("","",""));
        //        xmlData = this.CallWS(xmlData, "BizObj.RP_016,BizObj", "S");
        //        DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
        //        this.grd_cptl.DataSource = ds.Tables[1];
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}        
        private void addGrid()
        {
            int temp = 0;
            try
            {
       
                    if (temp == 0)
                    {
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();
                        dt.Columns.Add("name");
                        dt.Columns.Add("wt");
                        dt.Columns.Add("bala");
                        dt.Columns.Add("vtyp");   
                        //dt = (DataTable)grd_gldrgtr.DataSource;
                        //dt1 = (DataTable)grd_cptl.DataSource;
                        DataRow dr = dt.NewRow();            
                                                  
                        dt.Rows.Add(dr);                        

                    }
                }           

            catch (Exception ex)
            {
            }
        }
        private void ConvertWeightIntoCash(String vtyp)
        {
            try
            {
                double bal = 0.00;
                DataTable dt = (DataTable)this.grd_gldrgtr.DataSource;

                
                    DataRow[] dr = dt.Select(string.Format("vtyp='{0}'", vtyp));
               

                if (dr.Length > 0)
                {
                    int i=dr[0].Table.Rows.IndexOf(dr[0]);
                    double balanceWt = PLABS .Utils .CnvToDouble(dt.Rows[i - 1]["bala"]);
                    if (vtyp == "C")
                    {
                        dr[0]["wt"] = balanceWt * PLABS.Utils.CnvToDouble(this.txt_brdrt.Text);
                        dr[0]["bala"] = balanceWt * PLABS.Utils.CnvToDouble(this.txt_brdrt.Text);
                    }
                    else if (vtyp == "CO")
                    {
                        //dr[0]["wt"] = PLABS.Utils.CnvToDouble(this.txt_opnAmt.Text);
                        //dr[0]["bala"] = balanceWt + PLABS.Utils.CnvToDouble(this.txt_opnAmt.Text);
                        i--;
                    }
                        for (int j = i; j < (this.grd_gldrgtr.Rows.Count); j++)
                        {
                            bal += PLABS.Utils.CnvToDouble(this.grd_gldrgtr.Rows[j].Cells["txt_wt_gv"].Value);
                            this.grd_gldrgtr.Rows[j].Cells["txt_bala_gv"].Value = bal;
                            this.grd_gldrgtr.Rows[j].DefaultCellStyle.BackColor = Color.LightGray;
                        }
                    
                   
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private DataTable BindVtype()
        {
            DataTable dt = new DataTable();
            try
            {
                //this.txt_opnAmt.ClearControl(true);
                this.txt_brdrt.ClearControl(true);

                //this.txt_opnAmt.Text = PLABS.Utils.CnvToDouble(this.grd_cptl.CurrentRow.Cells["txt_opnAmt_gv"].Value).ToString("F2");
                //this.txt_brdrt.Text = PLABS.Utils.CnvToDouble(this.grd_cptl.CurrentRow.Cells["txt_brdrt_gv"].Value).ToString("F2");
                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                ht.Add("OPENING", "1,O");
                ht.Add("PURCHASE", "2,3");
                ht.Add("SALE", "3,4");
                ht.Add("MC", "4,M");
                ht.Add("DIFF TUCH", "5,D");
                ht.Add("SURPLUS", "6,+");
                ht.Add("SHORT", "7,-");
                ht.Add("STONE", "8,S");
                ht.Add("CASH", "9,C");
                ht.Add("OPENING AMOUNT", "10,CO");
                ht.Add("MC CASH", "11,CM");
                ht.Add("INDIRECT INCOME AND EXPENSE", "12,CI");
                ht.Add("SALE", "13,CP");



                dt.Columns.Add("name");
                dt.Columns.Add("wt");
                dt.Columns.Add("vtyp");
                dt.Columns.Add("Order", typeof(int));

                //for (int i = 0; i < this.grd_cptl.Columns.Count; i++)
                //{
                //    string colName = this.grd_cptl.Columns[i].Name;
                //    string header = this.grd_cptl.Columns[i].HeaderText;
                //    if (colName == "txt_sale_gv" || colName == "txt_purch_gv" || colName == "txt_mc_gv" || colName == "txt_diftch_gv" || colName == "txt_srpls_gv" || colName == "txt_shrt_gv" || colName == "txt_opnwt_gv" || colName == "txt_stn_gv" || colName == "txt_cash_gv" || colName == "txt_mccash_gv" || colName == "txt_indexpandincm_gv" || colName == "txt_opnAmt_gv" || colName == "txt_bala_gv")
                //    {
                //        DataRow dr = dt.NewRow();
                //        dr["name"] = header;
                //        dr["wt"] = PLABS.Utils.CnvToDouble(this.grd_cptl.CurrentRow.Cells[colName].Value);
                //        string[] x = ((string)ht[header].ToString()).Split(',');
                //        dr["Order"] = x[0];
                //        dr["vtyp"] = x[1];
                //        dt.Rows.Add(dr);
                //    }
                //}

                DateTime date = new DateTime();
                //date = PLABS.Utils.CnvToDate(string.Format("1-{0}-1", PLABS.Utils.CnvToStr(this.grd_cptl.CurrentRow.Cells["txt_mnth_gv"].Value)));
                //this.ddl_month.ControlValue=(date.Month).ToString();
                dt.DefaultView.Sort = "Order ASC";
                dt = dt.DefaultView.ToTable();
                dt.Columns.Remove(dt.Columns["Order"]);

                return dt;
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        private void OpeningWeightBinding()
        {
            DataTable dt =(DataTable) this.grd_gldrgtr.DataSource;

            //this.loadData(dt);
        }
        private void MontlyReport(int rowNum)
        {
            try
            {
                
                //string date = PLABS .Utils .CnvToDate(this.grd_cptl.Rows[rowNum].Cells["txt_dt_gv"].Value).ToString("yyyy-MM-dd");
                //_mnth = PLABS.Utils.CnvToDate(date).Month;
                //DataSet ds = this.GetDataSet("M","",date);
                //if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
                //{
                //    System.Collections.Hashtable ht = new System.Collections.Hashtable();
                //    ht.Add("tr_opnwt", "OPENING,O");
                //    ht.Add("purch","PURCHASE,3");
                //    ht.Add("sale","SALE,4");
                //    ht.Add("mc","MC,M");
                //    ht.Add("dif_tuch","DIFF TUCH,D");
                //    ht.Add("sur","SURPLUS,+");
                //    ht.Add("srt","SHORT,-");
                //    ht.Add("stn","STONE,S");
                //    //ht.Add("cash","CASH,C");
                //    ht.Add("tr_opnAmt","OPENING AMOUNT,CO");
                //    ht.Add("mc_cash","MC CASH,CM");
                //    ht.Add("ice","INDIRECT INCOME AND EXPENSE,CI");
                //    ht.Add ("outwt","OUTSTANDING WEIGHT,WO");
                //    ht.Add ("outcsh","OUTSTANDING CASH,CO");
                //    ht.Add("stncsh", "STONE CASH,CS");
                //    ht.Add ("phywt","PHYSICAL WEIGHT,WP");
                //    ht.Add("shetwt", "SHEET WEIGHT,WS");
                //    ht.Add("salry", "SALARY,CA");

		  
                //    DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                //    DataTable source = new DataTable();
                //    source.Columns.Add("name", typeof(string));
                //    source.Columns.Add("wt", typeof(double));
                //    source.Columns.Add("vtyp", typeof(string));

                //    this.txt_brdrt.Text = PLABS.Utils.CnvToStr(dt.Rows[0]["brd_rt"]);
                //    //this.txt_opnAmt.Text = PLABS.Utils.CnvToStr(dt.Rows[0]["opnAmt"]);
                //    //this.txt_opnwt.Text = PLABS.Utils.CnvToStr(dt.Rows[0]["opnWt"]);
                //    //this.grd_cptl .Rows[rowNum].Cells["txt_ttl_gv"].Value = PLABS.Utils.CnvToStr(dt.Rows[0]["ttlwt"]);
                //   //((string)ht["tr_opnwt"].ToString()).Split(',');
                   
                //    foreach (DataColumn clmn in dt.Columns )
                //    {
                //        string colName = clmn.ColumnName;
                //        if (colName == "tr_opnwt" || colName == "purch" || colName == "sale" || colName == "mc" || colName == "dif_tuch" || colName == "sur" || colName == "srt" || colName == "stn" || colName == "cash" || colName == "tr_opnAmt" || colName == "mc_cash" || colName == "ice" || colName == "outwt" || colName == "outcsh" || colName == "stncsh" || colName == "phywt" || colName == "shetwt" || colName == "salry")  
                //        {
                //            DataRow dr = source.NewRow();

                //            string[] voucher = ((string)ht[colName]).Split(',');
                            
                //            dr["name"] = voucher[0];
                //            dr["wt"] = dt.Rows[0][colName];
                //            dr["vtyp"] = voucher[1];

                //            source.Rows.Add(dr);
                //        }
                //    }
                //    if (PLABS.Utils.GetDataTable(ds, 1).Rows.Count!=0)
                //    {
                //        _trsaleopn = PLABS.Utils.CnvToDouble(PLABS.Utils.GetDataTable(ds, 1).Rows[0]["salopn"]);
                //    }
                //    else
                //    {
                //        _trsaleopn =0.000;
                //    }
                //    this.loadData(source);
                //}
            }
            catch (Exception ex)
            {

            }
        }
        private void WeightRowColour()
        {
            try
            {
                DataTable dt =(DataTable)this.grd_gldrgtr.DataSource;

                DataRow[] sortRow = dt.Select(string.Format("vtyp IN ('{0}','{1}','{2}')", "WP", "WO", "WS"));

                if (sortRow.Length > 0)
                {
                    for (int i = 0; i < sortRow.Length; i++)
                    {
                        int index = dt.Rows.IndexOf(sortRow[i]);
                        this.grd_gldrgtr.Rows[index].DefaultCellStyle.BackColor = Color.FromArgb(226, 239, 255);
                    }
                }

                DataRow[] cshRow = dt.Select(string.Format("vtyp IN ('{0}','{1}','{2}','{3}','{4}')", "CO", "CM", "CS","CI","CT","CP","CC"));

                if (cshRow.Length > 0)
                {
                    for (int j = 0; j < cshRow.Length; j++)
                    {
                        int indx = dt.Rows.IndexOf(cshRow[j]);
                        this.grd_gldrgtr.Rows[indx].DefaultCellStyle.BackColor = Color.Beige;
                    }
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void WeightToCash()
        {
            try
            {
                double wtcsh = 0.000;
                int opnRowindex;
                DataTable dt = (DataTable)this.grd_gldrgtr.DataSource;

                DataRow[] sortRow = dt.Select("vtyp='S'");

                if (sortRow.Length == 1)
                {
                    wtcsh = PLABS.Utils.CnvToDouble(sortRow[0]["bala"])*PLABS .Utils .CnvToDouble(this.txt_brdrt.Text);
                }

                DataRow[] opnRow = dt.Select("vtyp='CO'");
                
                if (opnRow.Length == 1)
                {
                    opnRowindex = dt.Rows.IndexOf(opnRow[0]);
                    //opnRow[0]["wt"] =_tropnAmt+wtcsh+ PLABS.Utils.CnvToDouble(this.txt_opnAmt.Text);// PLABS.Utils.CnvToDouble(opnRow[0]["wt"])
                    opnRow[0]["bala"] = opnRow[0]["wt"];
                    for (int i = opnRowindex + 1; i < dt.Rows.Count; i++)
                    {
                        //if (PLABS.Utils.CnvToStr(dt.Rows[i]["vtyp"]) == "CI")
                        //{
                        //    dt.Rows[i]["bala"] = PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["bala"]) - PLABS.Utils.CnvToDouble(dt.Rows[i]["wt"]);
                        //}
                        //else
                        //{
                            dt.Rows[i]["bala"] = PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["bala"]) + PLABS.Utils.CnvToDouble(dt.Rows[i]["wt"]);
                        //}
                    }
                   
                }

              

            }
            catch (Exception ex)
            {
 
            }
        }
        private void GetTotalWeight()
        {
            try
            {
                DataTable dt=(DataTable)this.grd_gldrgtr.DataSource ;
                double ttlCsh = 0.00;
                double ActlWt = 0.000;
                double ttlWt = 0.000;
                DataRow[] sortRow=dt.Select("vtyp='CP'");

                if (sortRow.Length > 0)
                {
                    for (int i = 0; i < sortRow.Length; i++)
                    {
                        ttlCsh += PLABS.Utils.CnvToDouble(sortRow[i]["wt"]);
                    }
                }
                DataRow[] wtRow = dt.Select("vtyp ='S'");
                if (wtRow.Length > 0)
                {
                    ActlWt = PLABS.Utils.CnvToDouble(wtRow[0]["bala"]);
                }
                ttlCsh = ttlCsh +_trsaleopn+ (ActlWt * PLABS.Utils.CnvToDouble(this.txt_brdrt.Text));
                ttlWt = (ttlCsh / PLABS.Utils.CnvToDouble(this.txt_brdrt.Text));
                //this.lbl_ttlwt.Text = ttlWt.ToString("N3");

            }
            catch (Exception ex)
            {
 
            }
        }
        private void doClear()
        {
            this.txt_brdrt.ClearControl(true);
            this.grd_gldrgtr.ClearControl(true);
            this.txt_amt.ClearControl(true);
            this.txt_brdrt.Focus();

            loadControls();
        }
        private string GetGridXml()
        {
            string xml = "<ResultDS>";
            DataTable dt = (DataTable)this.grd_gldrgtr.DataSource;

            foreach (DataRow dr in dt.Rows)
            {
                xml += "<Rslt>";
                xml += "<wt>"+PLABS.Utils.CnvToStr(dr["wt"])+"</wt>";
                xml += "<bala>"+ PLABS.Utils.CnvToStr(dr["bala"]) + "</bala>";
                xml += "<name>"+ PLABS.Utils.CnvToStr(dr["name"]) + "</name>";
                xml += "</Rslt>";
            }

            xml += "</ResultDS>";
            return xml;
        }
        private void doSave()
        {
            try
            {

                //String xmlData = this.ProcessXml;
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_brdrt", this.txt_brdrt.ControlValue);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_fix_amt", this.txt_amt.ControlValue);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", PLABS.Utils.CnvToStr(Properties.Settings.Default.id));
                xmlData = PLABS.Utils.addNode(xmlData, "v_xml", PLABS.CreateXml.FormatString(this.GetGridXml()));
                xmlData = this.CallWS(xmlData, "BizObj.RP_016,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        this.ValueChangedStatus = true;
                        this.DoClear(this);
                        this.CancelProcess = true;
                    }
                    else
                    {
                        this.ValueChangedStatus = true;
                        this.DoClear(this);
                        this.CancelProcess = true;
                    }

                }
                else if (xmlData.Length < 7)
                {
                    PLABS.MessageBoxPL.Show("Successfully Saved", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    doClear();
                    //this.loadGrid();
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0005");
                throw (ex);
            }
        }
        #endregion       
    }
}
