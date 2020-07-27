using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;

namespace RoysGold 
{
    public partial class RPH_003H : PLABS.MasterForm
    {
        public RPH_003H()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.ExitBeforeClick += new EventHandler(RPH_003H_ExitBeforeClick);
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.loadgrid();         
            
        }   

    
        void btn_print_Click(object sender, EventArgs e)
        {
            if (wb_leger_dtail.DocumentText != null)
            {
               /* string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
                {
                    if (key != null)
                    {
                       
                        string old_footer = key.GetValue("footer");
                        //string old_header = key.GetValue("header");
                        key.SetValue("footer", "");
                        key.SetValue("header", "");
                        this.wb_leger_dtail.ShowPrintDialog(); 
                       // Print();
                       // key.SetValue("footer", old_footer);
                        //key.SetValue("header", old_header);
                    }
                } */      

                this.wb_leger_dtail.ShowPageSetupDialog();
                this.wb_leger_dtail.ShowPrintDialog(); 
              
            }
       
        }
        

        void RPH_003H_ExitBeforeClick(object sender, EventArgs e)
        {
           
        }

        #region methods


        private void loadgrid()
        {
            try
            {



                DataSet ds = GetDataSet("");
                ds.Tables[0].TableName = "tbl_1";
                ds.Tables[1].TableName = "tbl_2";
                ds.Tables[4].TableName = "tbl_4";
                ds.Tables[6].TableName = "tble_6";
                ds.Tables[7].TableName = "tble_7";
                ds.Tables[8].TableName = "tble_8";
                DataTable capital = ds.Tables[7];
                DataTable capitalTtl = ds.Tables[8];
                ds.Tables.Remove("tble_7");
                ds.Tables.Remove("tble_8");
                DataTable dt = GetTable(PLABS.Utils.GetDataTable(ds, 1));
                DataTable dt2 = GetTable2(PLABS.Utils.GetDataTable(ds, 0), PLABS.Utils.GetDataTable(ds, 6));
                ds.Tables.Remove("tble_6");
                DataTable dt4 = GetTable4(PLABS.Utils.GetDataTable(ds, 4));
                ds.Tables.Remove("tbl_4");
                dt4.TableName = "detail4";
                ds.Tables.Add(dt4);
                ds.Tables.Remove("tbl_1");
                dt2.TableName = "detail1";
                ds.Tables.Add(dt2);
                ds.Tables.Remove("tbl_2");
                dt.TableName = "detail2";
                ds.Tables.Add(dt);
                string dtm = PLABS.Utils.CnvToStr(ds.Tables[0].Rows[0][0]).ToString();
                string html = "<table style=\"width: 100%; height: 90%;\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                html += "<tr><td style=\"width:75%;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;\">";
                html += reporthdrData("", PLABS.Utils.GetDataTable(ds, 4));
                html += "</td><td style=\"width:25%;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;padding-right:2px;font-size: 10px;text-align:right;font-weight:400;\">" + dtm + "</td></tr>";
                html += "<tr><td style=\"vertical-align:top;width:75%;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;\">";
                html += reportdetailData("", PLABS.Utils.GetDataTable(ds, 5));
                html += reportdetailData2("", PLABS.Utils.GetDataTable(ds, 3));
                if (capital.Rows.Count > 0)
                    html += CapitalReportHtml(capital, capitalTtl);
                else
                {
                    MessageBox.Show("Please day close and view report again.");
                    throw new Exception("");
                }
                html += "</td><td style=\"width:25%;vertical-align:top;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;\">";
                html += reportsideData("", PLABS.Utils.GetDataTable(ds, 1), PLABS.Utils.GetDataTable(ds, 2));

                html += "</td></tr>";
                //html += "<tr><td style=\"width:70%;border-top: solid 1px c0c0c0;;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;\">";
                //html += reportdetailData2("", PLABS.Utils.GetDataTable(ds, 3));
                //html += "</td><td style=\"width:20%;vertical-align:top;border-top: solid 1px c0c0c0;;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;\">";
                //html += "</td></tr>";
                html += "</table>";

                this.wb_leger_dtail.DocumentText = html;
            }
            catch (Exception ex)
            {


            }
        }

        static DataTable GetTable(DataTable dt)
        {
           /* DataRow dr = dt.NewRow();
            dr["addr_nam"] = "Balance";
            dr["wt"] = PLABS.Utils.CnvToDouble(dt.Compute("SUM(wt)",""));
            dr["amt"] = PLABS.Utils.CnvToDouble(dt.Compute("SUM(amt)", ""));
            dt.Rows.Add(dr);*/

            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();

            table.Columns.Add("name", typeof(string));
            table.Columns.Add("wt", typeof(double));
            table.Columns.Add("amt", typeof(double));
            table.Columns.Add("name2", typeof(string));
            table.Columns.Add("wt2", typeof(double));
            table.Columns.Add("amt2", typeof(double));
            table.Columns.Add("name3", typeof(string));
            table.Columns.Add("wt3", typeof(double));
            table.Columns.Add("amt3", typeof(double));
            table.Rows.Add();
            int colcnt = 0;
            int rcnt = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (colcnt == 9)
                {
                    table.Rows.Add();
                    rcnt++;
                    colcnt = 0;
                }

                table.Rows[rcnt][colcnt] = dt.Rows[i]["addr_nam"];
                table.Rows[rcnt][colcnt + 1] = dt.Rows[i]["wt"];
                table.Rows[rcnt][colcnt + 2] = dt.Rows[i]["amt"];
                colcnt += 3;

            }
         
            /*table.Rows[table.Rows.Count-1][6]=  table.Rows[table.Rows.Count-1][0];
            table.Rows[table.Rows.Count-1][7]=  table.Rows[table.Rows.Count-1][1];
            table.Rows[table.Rows.Count - 1][8] = table.Rows[table.Rows.Count - 1][2];
            table.Rows[table.Rows.Count - 1][0] = DBNull.Value ;
            table.Rows[table.Rows.Count - 1][1] = DBNull.Value ;
            table.Rows[table.Rows.Count - 1][2] = DBNull.Value;*/

            //table.Rows.Add(table.NewRow());

            DataRow dr = table.NewRow();
            // table.Rows[table.Rows.Count - 1][6] = "Balance";
            dr[6] = "BLXXXX";
            dr[7] = PLABS.Utils.CnvToDouble(dt.Compute("SUM(wt)", ""));
            dr[8] = PLABS.Utils.CnvToDouble(dt.Compute("SUM(amt)", ""));
            table.Rows.Add(dr);
            // 999711010199106989798117107112100115
            //11510410598117 

            return table;

        }
        static DataTable GetTable4(DataTable dt)
        {


            double sum_amt = 0.000;


            foreach (DataRow dr in dt.Rows)
            {
              
                double pur_amt=(PLABS.Utils.CnvToDouble(dr["amt"]) * PLABS.Utils.CnvToDouble(dr["purty"])) / 100;
                sum_amt = sum_amt + pur_amt;
            }

            DataRow dr1 = dt.NewRow();

            dr1["itm_name"] = "Total";
            dr1["descr"] = "&nbsp";
            dr1["amt"] = sum_amt;

            dt.Rows.Add(dr1);
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();

            table.Columns.Add("name", typeof(string));
            table.Columns.Add("wt", typeof(string));
            table.Columns.Add("amt", typeof(double));
            table.Columns.Add("purty", typeof(double));
            table.Columns.Add("name2", typeof(string));
            table.Columns.Add("wt2", typeof(string));
            table.Columns.Add("amt2", typeof(double));
            table.Columns.Add("purty2", typeof(double));
            //table.Columns.Add("name3", typeof(string));
            //table.Columns.Add("wt3", typeof(string));
            //table.Columns.Add("amt3", typeof(double));
            table.Rows.Add();
            int colcnt = 0;
            int rcnt = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (colcnt == 9)
            //    {
            //        table.Rows.Add();
            //        rcnt++;
            //        colcnt = 0;
            //    }

            //    table.Rows[rcnt][colcnt] = dt.Rows[i]["itm_name"];
            //    table.Rows[rcnt][colcnt + 1] = dt.Rows[i]["descr"];
            //    table.Rows[rcnt][colcnt + 2] = dt.Rows[i]["amt"];
            //    colcnt += 3;

            //}
          
            int ttlRows = dt.Rows.Count; 
            if (ttlRows % 2 == 0)
            {
                ttlRows = ttlRows / 2;
            }
            else
            {
                ttlRows = (ttlRows/2) + 1;
            }
            int x=0,y=0,c=0;

            for (int i = 0; i < 2; i++)
            {
                x=0;   //row index
                for (int j = 0; j < ttlRows; j++)
                {

                    if (dt.Rows.Count != y)
                    {
                        table.Rows[x][c] = dt.Rows[y]["itm_name"];
                        table.Rows[x][c + 1] = dt.Rows[y]["descr"];
                        table.Rows[x][c + 2] = dt.Rows[y]["amt"];
                        table.Rows[x][c + 3] = dt.Rows[y]["purty"];
                        x = x + 1;
                        y = y + 1; //datatable row index
                        if (table.Rows.Count != ttlRows)
                        {
                            table.Rows.Add();
                        }
                    }
                }
                c = c + 4; //coloumn index
               

            }


                return table;
        }

        static DataTable GetTable2(DataTable dt, DataTable dt1)
        {
            //
            // Here we create a DataTable with four columns.
            //
            double capital = 0.00; 
            DataTable table = new DataTable();
            double det =  0.000;
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("wt", typeof(double));
            table.Rows.Add();
            capital = PLABS.Utils.CnvToDouble(dt.Rows[1]["wt"]) + PLABS.Utils.CnvToDouble(dt.Rows[2]["wt"]) - PLABS.Utils.CnvToDouble(dt.Rows[3]["wt"]);
            String str = string.Empty; ;
            if (dt.Rows.Count > 0)
            {

                //det = dt.Rows[0][0].ToString() + " : " + det + dt.Rows[0][1].ToString() + "   "
                //    + dt.Rows[1][0].ToString() + " : " + det + dt.Rows[1][1].ToString() + "   "
                //    + dt.Rows[2][0].ToString() + " : " + det + dt.Rows[2][1].ToString() + "   " ;

              //  str = "Capital:" + capital.ToString("F3") + " Cash Balance: " + dt1.Rows[0][0] + " SL: " + PLABS.Utils.CnvToDouble(dt.Rows[0]["wt"]).ToString("F3");
                str = "CP:" + capital.ToString("F3") + " CB: " + dt1.Rows[0][0] + " SL: " + PLABS.Utils.CnvToDouble(dt.Rows[0]["wt"]).ToString("F3");


            }

            table.Rows[0][0] = str;
            table.Rows[0][1] = 0;
         

            return table;
        }

        private String reporthdrData(String heading, DataTable dt)
        {
            try
            {

                string colour = "#FFFFFF";
                String smallTble = string.Empty;
                
               smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;font-size: 10px;text-align:left; font-family: 'Trebuchet MS';\">";
                //smallTble += "<tr><td colspan=\"5\" style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;font-size: 14px;color: Black;width:700px;text-align: center;font-weight:400;\"></td></tr>";              

                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:200px;text-align:center;font-weight:400;\">CREDIT</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:200px;text-align:center;font-weight:400;\">&nbsp</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >&nbsp</td></tr>";
                
                    string name = PLABS.Utils.CnvToStr(dt.Rows[0]["name"]);                    
                   // string dtm = PLABS.Utils.CnvToDouble(dt2.Rows[0]["dt"]).ToString();

                    if (name == string.Empty)
                    {
                        name = "&nbsp";
                    }

                    smallTble += "<tr><td style=\"border-bottom: solid 1px c0c0c0;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:700px;text-align:left;font-weight:400;\">" + name + "</td></tr>";
                    //<td style=\"border-top: solid 1px c0c0c0;;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-right:2px;font-size: 12px;color: Black;width:900px;text-align:right;font-weight:400;\">" + dtm + "</td>    
                //smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-right:2px;font-size: 12px;color: Black;width:900px;text-align:right;font-weight:400;\"></td><td style=\"border-bottom: solid 1px c0c0c0;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:500px;text-align:left;font-weight:400;\"></td></tr>";

                    if (colour == "#FFFFFF")
                    {
                        colour = "#F6F7F3";
                    }
                    else
                    {
                        colour = "#FFFFFF";
                    }
                

                
                //<td style=\"background-color:" + colour + ";font-size: 10px;color: Black;width:900px;text-align:left;font-weight:400;\">&nbsp</td>
                smallTble += "</table>";
                return smallTble;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        private String reportsideData(String heading, DataTable dt, DataTable dt2)
        {
            try
            {
                double purwt_sum = 0.000; 
               
                foreach (DataRow dr in dt.Rows)
                {
                    double pur_wt = (PLABS.Utils.CnvToDouble(dr["wt"]) * PLABS.Utils.CnvToDouble(dr["purty"])) / 100;
                    //dr["wt"] = PLABS.Utils.CnvToDouble(dr["wt"]).ToString("F3");

                    purwt_sum = purwt_sum + pur_wt;
                }
               
                string colour = "#FFFFFF";
                String smallTble = string.Empty;
                double tot_phy_wt = purwt_sum;
                double tot_sheet = PLABS.Utils.CnvToDouble(dt2.Compute("sum(amt)", ""));
                smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;font-size: 8px;text-align:left; font-family: 'Trebuchet MS';\">";

                //smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\">Physical Weight</td>";
                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\">XXXXX</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\">&nbsp</td><tr>";


    for (int i = 0; i < dt.Rows.Count; i++)
                {
                string name = PLABS.Utils.CnvToStr(dt.Rows[i]["item"]);
                string wt=PLABS.Utils.CnvToStr(dt.Rows[i]["wt"]);               

                if (name == string.Empty)
                {
                    name = "&nbsp";
                    wt = "&nbsp";
                }

                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\">" + name + "</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\">" + wt + "</td><tr>";
                //<td style=\"border-top: solid 1px c0c0c0;;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-right:2px;font-size: 12px;color: Black;width:900px;text-align:right;font-weight:400;\">" + dtm + "</td>    
                //smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-right:2px;font-size: 12px;color: Black;width:900px;text-align:right;font-weight:400;\"></td><td style=\"border-bottom: solid 1px c0c0c0;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:500px;text-align:left;font-weight:400;\"></td></tr>";

                if (colour == "#FFFFFF")
                {
                    colour = "#F6F7F3";
                }
                else
                {
                    colour = "#FFFFFF";
                }
                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\"></td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\"></td><tr>";
}
    smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\">" + "Total" + "</td>";
    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\">" + tot_phy_wt.ToString("F3") + "</td><tr>";
    smallTble += "<tr></tr>";
    smallTble += "</table>";

    smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:99%;font-size: 10px;text-align:left; font-family: 'Trebuchet MS';\">";

    //smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\">Sheet Cash</td>";
    smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\">XXXSC</td>";
    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\">&nbsp</td><tr>"; 
                for (int i = 0; i < dt2.Rows.Count; i++)
    {
        string name = PLABS.Utils.CnvToStr(dt2.Rows[i]["name"]);
        string amt = PLABS.Utils.CnvToStr(dt2.Rows[i]["amt"]);

        if (name == string.Empty)
        {
            name = "&nbsp";
            amt = "&nbsp";
        }

        smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\">" + name + "</td>";
        smallTble += "<td style=\"border-right: solid 1px c0c0c0;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\">" + amt + "</td><tr>";
        //<td style=\"border-top: solid 1px c0c0c0;;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-right:2px;font-size: 12px;color: Black;width:900px;text-align:right;font-weight:400;\">" + dtm + "</td>    
        //smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-right:2px;font-size: 12px;color: Black;width:900px;text-align:right;font-weight:400;\"></td><td style=\"border-bottom: solid 1px c0c0c0;border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:500px;text-align:left;font-weight:400;\"></td></tr>";

        if (colour == "#FFFFFF")
        {
            colour = "#F6F7F3";
        }
        else
        {
            colour = "#FFFFFF";
        }

    }
    smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\"></td>";
    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\"></td><tr>";

    smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 10px;color: Black;width:400px;text-align:left;font-weight:400;\">" + "Total" + "</td>";
    smallTble += "<td style=\"border-right: solid 1px c0c0c0;border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\">" + tot_sheet.ToString("F2") + "</td><tr>";
              
                smallTble += "<tr></tr>";
                //<td style=\"background-color:" + colour + ";font-size: 10px;color: Black;width:900px;text-align:left;font-weight:400;\">&nbsp</td>
                smallTble += "</table>";
                return smallTble;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        private String reportdetailData(String heading, DataTable dt)
        {
            try
            {
             
                string colour = "#FFFFFF";               
                String smallTble = string.Empty;
                string user = string.Empty;
                smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;font-size: 8px;text-align:left; font-family: 'Trebuchet MS';\">";
                //smallTble += "<tr><td colspan=\"5\" style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;font-size: 14px;color: Black;width:700px;text-align: center;font-weight:400;\"></td></tr>";              

                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:200px;text-align:center;font-weight:400;\">CREDIT</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:200px;text-align:center;font-weight:400;\">&nbsp</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >&nbsp</td></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string name = PLABS.Utils.CnvToStr(dt.Rows[i]["name"]);
                    string name2 = PLABS.Utils.CnvToStr(dt.Rows[i]["name2"]);
                    string name3 = PLABS.Utils.CnvToStr(dt.Rows[i]["name3"]);
                    string wt = PLABS.Utils.CnvToDouble(dt.Rows[i]["wt"]).ToString("F3");
                    string wt2 = PLABS.Utils.CnvToDouble(dt.Rows[i]["wt2"]).ToString("F3");
                    string wt3 = PLABS.Utils.CnvToDouble(dt.Rows[i]["wt3"]).ToString("F3");
                    string amt = PLABS.Utils.CnvToDouble(dt.Rows[i]["amt"]).ToString("F2");
                    string amt2 = PLABS.Utils.CnvToDouble(dt.Rows[i]["amt2"]).ToString("F2");
                    string amt3 = PLABS.Utils.CnvToDouble(dt.Rows[i]["amt3"]).ToString("F2");
                    if (name == string.Empty)
                    {
                        name = "&nbsp";
                        wt = "&nbsp";
                        amt = "&nbsp";
                    }
                    if (name2 == string.Empty)
                    {
                        name2 = "&nbsp";
                        wt2 = "&nbsp";
                        amt2 = "&nbsp";
                    }
                    if (name3 == string.Empty)
                    {
                        name3 = "&nbsp";
                        wt3 = "&nbsp";
                        amt3 = "&nbsp";
                    }
                   


                    smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 8px;color: Black;width:400px;text-align:left;font-weight:400;\">" + name + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + wt + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + amt + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 10px;color: Black;width:50px;text-align:right;font-weight:400;\">&nbsp</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 8px;color: Black;width:400px;text-align:left;font-weight:400;\">" + name2 + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + wt2 + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + amt2 + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 10px;color: Black;width:50px;text-align:right;font-weight:400;\">&nbsp</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 8px;color: Black;width:400px;text-align:left;font-weight:400;\">" + name3 + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + wt3 + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-right:1px;font-size: 10px;color: Black;width:200px;text-align:right;font-weight:400;\">" + amt3 + "</td></tr>";

                    if (colour == "#FFFFFF")
                    {
                        colour = "#F6F7F3";
                    }
                    else
                    {
                        colour = "#FFFFFF";
                    }
                }



                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:150px;text-align:left;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:50px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:400px;text-align:left;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:50px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:400px;text-align:left;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td></tr>";        
                smallTble += "</table>";
                return smallTble;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        private String reportdetailData2(String heading, DataTable dt)
        {
            try
            {

                string colour = "#FFFFFF";
                String smallTble = string.Empty;
                string user = string.Empty;
                smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;font-size: 8px;text-align:left; font-family: 'Trebuchet MS';\">";
                //smallTble += "<tr><td colspan=\"5\" style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;font-size: 14px;color: Black;width:700px;text-align: center;font-weight:400;\"></td></tr>";              

                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:200px;text-align:center;font-weight:400;\">CREDIT</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:200px;text-align:center;font-weight:400;\">&nbsp</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >&nbsp</td></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string name = PLABS.Utils.CnvToStr(dt.Rows[i]["name"]);
                    string name2 = PLABS.Utils.CnvToStr(dt.Rows[i]["name2"]);
                   // string name3 = PLABS.Utils.CnvToStr(dt.Rows[i]["name3"]);
                    string wt = PLABS.Utils.CnvToStr(dt.Rows[i]["wt"]);
                    string wt2 = PLABS.Utils.CnvToStr(dt.Rows[i]["wt2"]);
                   // string wt3 = PLABS.Utils.CnvToStr(dt.Rows[i]["wt3"]);
                    string amt = PLABS.Utils.CnvToDouble(dt.Rows[i]["amt"]).ToString("F2");
                    string amt2 = PLABS.Utils.CnvToDouble(dt.Rows[i]["amt2"]).ToString("F2");
                   // string amt3 = PLABS.Utils.CnvToDouble(dt.Rows[i]["amt3"]).ToString("F2");
                    if (name == string.Empty)
                    {
                        name = "&nbsp";
                        wt = "&nbsp";
                        amt = "&nbsp";
                    }
                    if (name2 == string.Empty)
                    {
                        name2 = "&nbsp";
                        wt2 = "&nbsp";
                        amt2 = "&nbsp";
                    }
                    //if (name3 == string.Empty)
                    //{
                    //    name3 = "&nbsp";
                    //    wt3 = "&nbsp";
                    //    amt3 = "&nbsp";
                    //}



                    smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 8px;color: Black;width:200px;text-align:left;font-weight:400;\">" + name + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:400px;text-align:right;font-weight:400;\">" + wt + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + amt + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 8px;color: Black;width:50px;text-align:right;font-weight:400;\">&nbsp</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 8px;color: Black;width:200px;text-align:left;font-weight:400;\">" + name2 + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:400px;text-align:right;font-weight:400;\">" + wt2 + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + amt2 + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0; border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 8px;color: Black;width:50px;text-align:right;font-weight:400;\">&nbsp</td></tr>";
                    //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 8px;color: Black;width:200px;text-align:left;font-weight:400;\">" + name3 + "</td>";
                    //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:400px;text-align:right;font-weight:400;\">" + wt3 + "</td>";
                    //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0; border-right: solid 1px c0c0c0; background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + amt3 + "</td></tr>";

                    if (colour == "#FFFFFF")
                    {
                        colour = "#F6F7F3";
                    }
                    else
                    {
                        colour = "#FFFFFF";
                    }
                }



                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:150px;text-align:left;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:400px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:50px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:left;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:400px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:50px;text-align:right;font-weight:400;\">&nbsp</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:left;font-weight:400;\">&nbsp</td>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:400px;text-align:right;font-weight:400;\">&nbsp</td>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
                smallTble += "</table>";
                return smallTble;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        private String CapitalReportHtml(DataTable dt,DataTable capitalTotl)
        {
            string colour = "#FFFFFF";
            String smallTble = string.Empty;
            double opnamt = PLABS.Utils.CnvToDouble(dt.Rows[0]["opamt"]);
            double ttlbal;
            capitalTotl.Columns.Add("balnce",typeof(double));
            capitalTotl.Rows[0]["balnce"] = PLABS.Utils.CnvToDouble(capitalTotl.Rows[0]["ttlAmt"]) - opnamt;
            for (int i = 1; i < capitalTotl.Rows.Count; i++)
            {
                capitalTotl.Rows[i]["balnce"] = PLABS.Utils.CnvToDouble(capitalTotl.Rows[i]["ttlAmt"]) - PLABS.Utils.CnvToDouble(capitalTotl.Rows[i-1]["ttlAmt"]);
            }
            ttlbal = PLABS.Utils.CnvToDouble(capitalTotl.Compute("sum(balnce)",""));  
            smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;font-size: 8px;text-align:left; font-family: 'Trebuchet MS';\">";

            dt.DefaultView.Sort="dt Asc";
            dt = dt.DefaultView.ToTable();
           
            for(int i=1;i<dt.Rows.Count;i++)
            {
                dt.Rows[i]["opamt"]=  dt.Rows[i-1]["ttlAmt"] ;
            }
            dt.Rows.RemoveAt(0);
            DataRow dr = dt.NewRow();
           // dr["dt"] = "Profit";
            dr["dt"] = "PRXXX";
            dr["ttlAmt"] = ttlbal;
            dr["opamt"] = DBNull.Value;
            dt.Rows.Add(dr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string dte = PLABS.Utils.CnvToStr(dt.Rows[i]["dt"]);
                string ttlAmt = PLABS.Utils.CnvToDouble(dt.Rows[i]["ttlAmt"]).ToString("F2");
                double opamt = PLABS.Utils.CnvToDouble(dt.Rows[i]["opamt"]);
                double bal = PLABS.Utils.CnvToDouble(ttlAmt) - opamt;

                if((dt.Rows.Count-1)==i)
                {
                    ttlAmt = string.Empty;
                }
               
                if (ttlAmt == string.Empty)
                {
                    ttlAmt = "&nbsp";
                 
                }
 

                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-left:2px;font-size: 8px;color: Black;width:200px;text-align:left;font-weight:400;\">" + dte + "</td>";
                if ((dt.Rows.Count - 1) == i)
                {
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + ttlAmt + "</td>";

                }
                else
                {
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + PLABS.Utils.CnvToDouble(ttlAmt).ToString("F0") + "</td>";
                }
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";padding-right:1px;font-size: 8px;color: Black;width:200px;text-align:right;font-weight:400;\">" + bal.ToString("F0") + "</td></tr>";
               // smallTble += "<td style=\"border-top: solid 1px c0c0c0; border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 8px;color: Black;width:50px;text-align:right;font-weight:400;\">&nbsp</td>";
               
                if (colour == "#FFFFFF")
                {
                    colour = "#F6F7F3";
                }
                else
                {
                    colour = "#FFFFFF";
                }
            }

            smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:left;font-weight:400;\">&nbsp</td>";
            smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td>";
            smallTble += "<td style=\"border-top: solid 1px c0c0c0;font-size: 10px;width:200px;text-align:right;font-weight:400;\">&nbsp</td></tr> ";
           // smallTble += "<td style=\"border-top: solid 1px c0c0c0; border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 8px;color: Black;width:50px;text-align:right;font-weight:400;\">&nbsp</td></tr>";
            smallTble += "</table>";
            return smallTble;


        }
        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id", Properties.Settings.Default.id.ToString());
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0010");
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
                //BizObj.RPH_001 objrptiss = new BizObj.RPH_001();
                //xmlData = objrptiss.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0009");
            }
            return xmlData;
        }

        private DataSet GetDataSet(String as_mode)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode));
                xmlData = this.CallWS(xmlData, "BizObj.RPH_003,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }

        #endregion
    }
}
