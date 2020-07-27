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
    public partial class RP_011 : PLABS.MasterForm
    {
        #region Globalvariables
        Hashtable ht = new Hashtable();

        #endregion
        #region Properties
        #endregion
        #region Constructors
       
        public RP_011()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.ddl_month.SelectedValueChanged += new EventHandler(ddl_month_SelectedValueChanged);
            this.grd_data.CellDoubleClick += new DataGridViewCellEventHandler(grd_data_CellDoubleClick);
            base.OnLoad(e);
        }

        void grd_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.CellDoubleClick(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception ex)
            {
 
            }
        }

       
        #endregion
        #region Envets
        void ddl_month_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.MonthChanged();
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
                this.LoadMonth();
                this.LoadHash();
                this.txt_year.Text = PLABS.Utils.CnvToStr(DateTime.Now.Year);
                this.ddl_month.ControlValue = PLABS.Utils.CnvToStr(DateTime.Now.Month);
                this.MonthChanged();
            }
            catch (Exception ex)
            {
 
            }
        }
        private void LoadMonth()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("month");

            DataRow dr = dt.NewRow();
            dr["Id"] = 1;
            dr["month"] = "January";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["month"] = "February";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["month"] = "March";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["month"] = "April";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["month"] = "May";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["month"] = "June";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["month"] = "July";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["month"] = "August";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["month"] = "September";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["month"] = "October";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["month"] = "November";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["month"] = "December";
            dt.Rows.Add(dr);

            this.ddl_month.LoadData(dt, "month", "Id");

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
        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_mnth",this.ddl_month.ControlValue);
                argXml = PLABS.Utils.addNode(argXml, "ai_year",this.txt_year .ControlValue);
                return argXml;
            }
            catch (Exception ex)
            {
            }
            return string.Empty;
        }
        private DataSet GetDataSet(String as_mode)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode));
                xmlData = this.CallWS(xmlData, "BizObj.RP_011,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private void MonthChanged()
        {
            try
            {
                this.lbl_opncsh.ClearControl(true);
               this.grd_data.ClearControl(true);
               DataSet ds=this.GetDataSet("S");
               DataTable dt=PLABS.Utils.GetDataTable(ds, 0);
               DataTable dt1 = PLABS.Utils.GetDataTable(ds, 1);
               this.lbl_opn.ClearControl(true);
               this.lbl_salry.ClearControl(true);
               this.lbl_opn.Text = PLABS.Utils.CnvToDouble(dt.Rows[0]["tropwt"]).ToString("N3");
               this.lbl_salry.Text = PLABS.Utils.CnvToDouble(dt.Rows[0]["salry"]).ToString("N3");
               if (dt1.Rows.Count > 0)
               {
                   this.lbl_opncsh.Text = PLABS.Utils.CnvToDouble(dt1.Rows[0]["ttlAmt"]).ToString("N2");
               }
               
               dt.Columns.Add("bal",typeof(double));
               dt.Columns.Add("cshbal", typeof(double));
               dt.Columns.Add("purbal", typeof(double));
               dt.Columns.Add("salbal", typeof(double));
               dt.Columns.Add("mcbal", typeof(double));
               dt.Columns.Add("diftch", typeof(double));
               dt.Columns.Add("surbal", typeof(double));
               dt.Columns.Add("swbal", typeof(double));
               dt.Columns.Add("mcshbal", typeof(double));
               dt.Columns.Add("stncshbal", typeof(double));
               dt.Columns.Add("icebal", typeof(double));
               dt.Columns.Add("pursalcsh", typeof(double));

               dt.Columns["bal"].SetOrdinal(9);
               dt.Columns["stncshbal"].SetOrdinal(14);
               dt.Columns["ttlamt"].SetOrdinal(17);

               dt.Rows[0]["purbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["pur"]);
               dt.Rows[0]["salbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["sal"]);
               dt.Rows[0]["mcbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["mc"]);
               dt.Rows[0]["diftch"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["dftch"]);
               dt.Rows[0]["surbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["sur"]);
               dt.Rows[0]["swbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["sw"]);
               dt.Rows[0]["mcshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["mcsh"]);
               dt.Rows[0]["stncshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["stncsh"]);
               dt.Rows[0]["icebal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["ice"]);
               dt.Rows[0]["pursalcsh"] = (Math.Abs(PLABS.Utils.CnvToDouble(dt.Rows[0]["salbal"]))-Math.Abs(PLABS.Utils.CnvToDouble(dt.Rows[0]["purbal"])))
                                         *PLABS .Utils.CnvToDouble(dt.Rows[0]["brd_rt"]);
               dt.Rows[0]["bal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["ttlWt"]) - PLABS.Utils.CnvToDouble(this.lbl_opn.Text);

               //dt.Rows[0]["cshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["ttlAmt"]) - PLABS.Utils.CnvToDouble(this.lbl_opncsh.Text);
               dt.Rows[0]["cshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["ttlAmt"]) - PLABS.Utils.CnvToDouble(dt.Rows[0]["opamt"]);
               for (int i=1; i < dt.Rows.Count; i++)
               {
                   
                   dt.Rows[i]["icebal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["ice"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["ice"]);
                   dt.Rows[i]["stncshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["stncsh"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["stncsh"]);
                   dt.Rows[i]["mcshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["mcsh"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["mcsh"]);
                  
                   dt.Rows[i]["swbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["sw"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["sw"]);
                   dt.Rows[i]["surbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["sur"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["sur"]);
                   dt.Rows[i]["diftch"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["dftch"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["dftch"]);
                   dt.Rows[i]["mcbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["mc"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["mc"]);
                   dt.Rows[i]["salbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["sal"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["sal"]);
                   dt.Rows[i]["purbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["pur"]) - PLABS.Utils.CnvToDouble(dt.Rows[i-1]["pur"]);
                   dt.Rows[i]["bal"] = PLABS.Utils .CnvToDouble(dt.Rows[i]["ttlwt"]) -PLABS .Utils .CnvToDouble(dt.Rows[i-1]["ttlwt"]);
                  // dt.Rows[i]["cshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["ttlAmt"]) - PLABS.Utils.CnvToDouble(dt.Rows[i - 1]["ttlAmt"]);
                   dt.Rows[i]["pursalcsh"] = (Math.Abs(PLABS.Utils.CnvToDouble(dt.Rows[i]["salbal"])) - Math.Abs(PLABS.Utils.CnvToDouble(dt.Rows[i]["purbal"])))
                                         * PLABS.Utils.CnvToDouble(dt.Rows[i]["brd_rt"]);
                   dt.Rows[i]["opamt"] = dt.Rows[i - 1]["ttlamt"];
                   dt.Rows[i]["cshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[i]["ttlAmt"]) - PLABS.Utils.CnvToDouble(dt.Rows[i]["opamt"]);
               }
               //dt.Rows[0]["cshbal"] = PLABS.Utils.CnvToDouble(dt.Rows[0]["ttlAmt"]) - PLABS.Utils.CnvToDouble(this.lbl_opncsh.Text);
               this.grd_data.DataSource = dt;
               this.grd_data.Columns["txt_ttlwt_gv"].DefaultCellStyle.BackColor = Color.Aqua;
               this.grd_data.Columns["txt_ttlamt_gv"].DefaultCellStyle.BackColor = Color.Aqua;

               dt.Columns.Remove("pur");
               dt.Columns.Remove("sal");
               dt.Columns.Remove("mc");
               dt.Columns.Remove("dftch");
               dt.Columns.Remove("sur");
               dt.Columns.Remove("sw");
               dt.Columns.Remove("mcsh");

               
               dt.Columns.Remove("stncsh");
              
               dt.Columns.Remove("ice");
               dt.Columns.Remove("pursal");
               dt.Columns.Remove("brd_rt");


               this.GridTotal();
               //dt.Columns.Remove("pur");
               

            }
            catch (Exception ex)
            {
 
            }
        }
        private void GridTotal()
        {
            try
            {
                DataTable dt = (DataTable)this.grd_data.DataSource;

                double ttlPur = PLABS.Utils.CnvToDouble(dt.Compute("SUM(purbal)", ""));
                double ttlSal = PLABS.Utils.CnvToDouble(dt.Compute("SUM(salbal)", ""));
                double ttlMc = PLABS.Utils.CnvToDouble(dt.Compute("SUM(mcbal)", ""));
                double ttlDif = PLABS.Utils.CnvToDouble(dt.Compute("SUM(diftch)", ""));
                double ttlSur = PLABS.Utils.CnvToDouble(dt.Compute("SUM(surbal)", ""));
                double ttlStn = PLABS.Utils.CnvToDouble(dt.Compute("SUM(swbal)", ""));
                double ttlMcsh = PLABS.Utils.CnvToDouble(dt.Compute("SUM(mcshbal)", ""));
                double ttlStncsh = PLABS.Utils.CnvToDouble(dt.Compute("SUM(stncshbal)", ""));
                double ttlIce = PLABS.Utils.CnvToDouble(dt.Compute("SUM(icebal)", ""));
                double ttlPurSalCsh = PLABS.Utils.CnvToDouble(dt.Compute("SUM(pursalcsh)", ""));
                double ttlcshbal = PLABS.Utils.CnvToDouble(dt.Compute("SUM(cshbal)", ""));
                double ttlbal = PLABS.Utils.CnvToDouble(dt.Compute("SUM(bal)", ""));
                DataRow dr = dt.NewRow();

                dr["purbal"] = ttlPur;
                dr["salbal"] = ttlSal;
                dr["mcbal"] = ttlMc;
                dr["diftch"] = ttlDif;
                dr["surbal"] = ttlSur;
                dr["swbal"]=ttlStn;
                dr["mcshbal"] = ttlMcsh;
                dr["stncshbal"] = ttlStncsh;
                dr["icebal"] = ttlIce;
                dr["pursalcsh"] = ttlPurSalCsh;
                dr["cshbal"] = ttlcshbal;
                dr["bal"] = ttlbal;
                dt.Rows.Add(dr);

                this.grd_data.Rows[dt.Rows.Count - 1].DefaultCellStyle.BackColor = Color.AliceBlue;
                this.grd_data.Rows[dt.Rows.Count - 1].DefaultCellStyle.Font = new Font("Ariel", 10, FontStyle.Bold);

            }
            catch (Exception ex)
            {
 
            }
        }
        private void CellDoubleClick(int rowNum,int colNum)
        {
            try
            {
                string[] parameters = new string[3];
                string colName = this.grd_data.Columns[colNum].Name;
                string date = PLABS.Utils.CnvToDate(this.grd_data.Rows[rowNum].Cells["txt_date_gv"].Value).ToString("yyyy-MM-dd");
                string[] modeAndText = PLABS.Utils.CnvToStr(ht[colName]).Split(',');
                

                if (modeAndText.Length > 0)
                {
                    string mode = modeAndText[0];
                    string text = modeAndText[1];
                    parameters[0] = mode;
                    parameters[1] = date;
                    parameters[2] = date;
                    if (mode == "CI")
                    {
                        CO_005 objpopup = new CO_005();
                        objpopup.Parameters = parameters;
                        objpopup.Text = text;
                        objpopup.ShowDialog();
                    }
                    else
                    {
                        CO_004 objpopup = new CO_004();
                        objpopup.Parameters = parameters;
                        objpopup.Text = text;
                        objpopup.ShowDialog();
                    }
                }
                

            }
            catch (Exception ex)
            {
 
            }
        }
        private void LoadHash()
        {
            try
            {
                ht.Add("txt_purch_gv","3,PURCHASE");
                ht.Add("txt_sale_gv", "4,SALES");
                ht.Add("txt_mc_gv", "M,MC");
                ht.Add("txt_ditch_gv", "D,TOUCH DIFFERENCE");
                ht.Add("txt_stnwt", "S,STONE WEIGHT");
                ht.Add("txt_mccsh_gv", "CM,MC CASH");
                ht.Add("txt_ice_gv", "CI,INDIRECT INCOME AND EXPANSE");
                ht.Add("txt_stncsh", "CS,STONE CASH");
                //ht.Add("txt_pursal_gv")
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
    }
}
