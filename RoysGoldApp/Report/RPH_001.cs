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
    public partial class RPH_001 : PLABS.MasterForm
    {
        #region Global variables

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public RPH_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.btn_ledger.Click += new EventHandler(btn_ledger_Click);
            this.btn_sheetw.Click += new EventHandler(btn_sheetw_Click);
            this.btn_petty.Click += new EventHandler(btn_petty_Click);
            this.btn_itm.Click += new EventHandler(btn_itm_Click);
            this.btn_stk.Click += new EventHandler(btn_stk_Click);
            this.btn_all.Click += new EventHandler(btn_all_Click);
            this.btn_confirmation.Click += new EventHandler(btn_confirmation_Click);
            base.OnLoad(e);

        }
        #endregion

        #region Events
        void btn_confirmation_Click(object sender, EventArgs e)
        {
            this.ConfirmGrid();
        }
        void btn_print_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(@"D:\print.txt", Print);
            //System.Diagnostics.Process.Start("C:\\print\\print.bat");

            this.webBrowser1.Print();
        }   
        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btn_ledger_Click(object sender, EventArgs e)
        {
            try
            {
                this.LedgerClick("LR");
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_sheetw_Click(object sender, EventArgs e)
        {
            try
            {
                this.SheetWeightClick();
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_petty_Click(object sender, EventArgs e)
        {
            try
            {
                this.PettyCashClick();
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_jrnl_Click(object sender, EventArgs e)
        {
            try
            {
                this.JournelClick();
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_itm_Click(object sender, EventArgs e)
        {
            try
            {
                this.LedgerClick1("IM");
                
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_stk_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = this.GetDataSet("ST", "");
                this.webBrowser1.DocumentText = this.StockTable(PLABS .Utils.GetDataTable(ds,0));
            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_all_Click(object sender, EventArgs e)
        {
            try
            {
                this.AllClick();
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
                //DataSet ds = this.GetDataSet("LO", "");
                //dp_frm.Value = PLABS.Utils.CnvToDate(PLABS.Utils.GetDataTable(ds, 0).Rows[0]["dt"]);
                //dp_to.ControlValue = dp_frm.ControlValue;
                dp_frm.Value = DateTime.Now;
                dp_to.Value = DateTime.Now;
                if (Properties.Settings.Default.id == 4)
                {
                    this.dp_frm.Enabled = true;
                    this.dp_to.Enabled = true;
                    this.btn_confirmation.Enabled = true;
                }
                else
                {
                    this.dp_frm.Enabled = false;
                    this.dp_to.Enabled = false;
                    this.btn_confirmation.Enabled = false;
                }
            }
            catch (Exception ex)
            {
 
            }
            
        }
        //private void LoadClick()
        //{
        //    try
        //    {
        //        DataSet ds = this.GetDataSet("", "");
        //        this.LoadReport(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //private void LoadReport(DataSet ds)
        //{
        //    try
        //    {
        //        //string x = SmallTable();
        //        DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
        //        string x = SmallTable("SHEET WEIGHT",dt);
        //        StringBuilder objstr = new StringBuilder();
        //        int i = 0, k = 0, id = 0;
        //        Double amt = 0.00, wt = 0.00;
        //        while (i < dt.Rows.Count)
        //        {
        //            String colour = "#f7f6f3";
        //            objstr.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title></head>");
        //            objstr.Append("<body>");
        //            objstr.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:900px;font-size: 12px;text-align:left; font-family: 'Trebuchet MS';\">");
        //            if (i != 0)
        //            {
        //                objstr.Append("<tr><td>");
        //                objstr.Append(this.Space(0));
        //            }

        //            objstr.Append("<tr><td>");
        //            objstr.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size: 12px;text-align:left; font-family: 'Trebuchet MS';\"><tr>");
        //            objstr.Append("<td style=\"background-color:#CCCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;\">SMITH NAME :-  </td>");
        //            objstr.Append("<td style=\"width: 150px; background-color:#CCCCFF;font-size: 14px;color: Black;text-align:left;font-weight:400;\">" + dt.Rows[i]["SmNam"] + "</td>");
        //            objstr.Append("<td style=\"width: 80px;background-color:#CCCCFF;font-size: 14px;color: Black;text-align:right;font-weight:400;\">Opening</td>");
        //            objstr.Append("<td style=\"width: 180px;background-color:#CCCCFF;font-size: 14px;color: Black;text-align: left;font-weight:400; padding-left:10px;\">Weight :  " + dt.Rows[i]["opWt"] + "</td>");
        //            objstr.Append("<td style=\"width: 180px;background-color:#CCCCFF;font-size: 14px;color: Black;text-align: left;font-weight:400;\">Amount :  " + dt.Rows[i]["opAmt"] + "</td>");
        //            objstr.Append("</tr></table>");

        //            objstr.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:900px;font-size: 12px;text-align:left; font-family: 'Trebuchet MS';\"><tr>");
        //            objstr.Append("<td style=\"width: 75px;background-color:#FFCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;border-right: solid 1 c0c0c0; border-bottom: solid 1px #c0c0c0; border-top: solid 1 c0c0c0;\">Date</td>");
        //            objstr.Append("<td style=\"width: 100px;background-color:#FFCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;border-right: solid 1 c0c0c0; border-bottom: solid 1px #c0c0c0; border-top: solid 1 c0c0c0;\">Item Name</td>");
        //            objstr.Append("<td style=\"width: 100px;background-color:#FFCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;border-right: solid 1 c0c0c0; border-bottom: solid 1px #c0c0c0; border-top: solid 1 c0c0c0;\">Gross Wt</td>");
        //            objstr.Append("<td style=\"width: 100px;background-color:#FFCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;border-right: solid 1 c0c0c0; border-bottom: solid 1px #c0c0c0; border-top: solid 1 c0c0c0;\">Pure Wt</td>");
        //            objstr.Append("<td style=\"width: 100px;background-color:#FFCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;border-right: solid 1 c0c0c0; border-bottom: solid 1px #c0c0c0; border-top: solid 1 c0c0c0;\">MC</td>");
        //            objstr.Append("<td style=\"width: 100px;background-color:#FFCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;border-right: solid 1 c0c0c0; border-bottom: solid 1px #c0c0c0; border-top: solid 1 c0c0c0;\">Mc Rate</td>");
        //            objstr.Append("<td style=\"width: 100px;background-color:#FFCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;border-right: solid 1 c0c0c0; border-bottom: solid 1px #c0c0c0; border-top: solid 1 c0c0c0;\">Weight</td>");
        //            objstr.Append("<td style=\"width: 100px;background-color:#FFCCFF;font-size: 14px;color: Black;text-align: center;font-weight:400;border-right: solid 1 c0c0c0; border-bottom: solid 1px #c0c0c0; border-top: solid 1 c0c0c0;\">Amount</td>");
        //            objstr.Append("</tr>");


        //            id = PLABS.Utils.CnvToInt(dt.Rows[i]["addr_id"].ToString());
        //            DataRow[] data = dt.Select("addr_id=" + id);
        //            k = 0;

        //            if (data.Length > 1)
        //            {
        //                while (k < data.Length)
        //                {
        //                    //if (colour == "#CC99FF")
        //                    //{
        //                    colour = "white";
        //                    //}
        //                    //else
        //                    //    colour = "#CC99FF";

        //                    DataRow dr = data[k];
        //                    objstr.Append("<tr>");
        //                    objstr.Append("<td style=\"width: 075px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + dr["date"] + " </td>");
        //                    objstr.Append("<td style=\"width: 100px;background-color: " + colour + ";text-align: left;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + dr["name"] + " </td>");
        //                    objstr.Append("<td style=\"width: 100px;background-color: " + colour + ";text-align: right;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + dr["grs_wgt"] + " </td>");
        //                    objstr.Append("<td style=\"width: 100px;background-color: " + colour + ";text-align: right;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + dr["prwt"] + " </td>");
        //                    objstr.Append("<td style=\"width: 100px;background-color: " + colour + ";text-align: right;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + dr["mc"] + " </td>");
        //                    objstr.Append("<td style=\"width: 100px;background-color: " + colour + ";text-align: right;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + dr["mc_rate"] + " </td>");
        //                    objstr.Append("<td style=\"width: 100px;background-color: " + colour + ";text-align: right;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + dr["opWt"] + " </td>");
        //                    objstr.Append("<td style=\"width: 100px;background-color: " + colour + ";text-align: right;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + dr["opAmt"] + " </td>");
        //                    objstr.Append("</tr>");
        //                    amt += PLABS.Utils.CnvToDouble(dr["opAmt"]);
        //                    wt += PLABS.Utils.CnvToDouble(dr["opWt"]);
        //                    i++;
        //                    k++;
        //                }
        //                objstr.Append(ClosingLine(wt, amt, colour));
        //            }
        //            else
        //            {
        //                objstr.Append(ClosingLine(PLABS.Utils.CnvToDouble(dt.Rows[i]["opWt"]), PLABS.Utils.CnvToDouble(dt.Rows[i]["opAmt"]), colour));
        //                i++;
        //            }
        //            objstr.Append("</table>");
        //            objstr.Append("</body>");
        //            objstr.Append("</html>");
        //        }
        //        String str = objstr.ToString();

        //        this.webBrowser1.DocumentText = str.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        private String getSelectArgs(String as_mode, String as_to_date)
        {
            try
            {
                String argXml = this.getBlankXml();
               
                argXml = PLABS.Utils.addNode(argXml, "ad_frm",(this.dp_frm.Value).ToString("yyyy-MM-dd"));
                argXml = PLABS.Utils.addNode(argXml, "ad_to", (this.dp_to.Value).ToString("yyyy-MM-dd"));
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
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
        private DataSet GetDataSet(String as_mode, String as_to_date)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, as_to_date));
                xmlData = this.CallWS(xmlData, "BizObj.RPH_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private String ClosingLine(Double wt, Double amt, String colour)
        {
            String closing = string.Empty;
            //if (colour == "#CC99FF")
            colour = "white";
            //else
            //    colour = "#CC99FF";  USER

            closing += "<tr>";
            closing += "<td style=\"width: 75px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">&nbsp</td>";
            closing += "<td style=\"width: 75px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">Closeing</td>";
            closing += "<td style=\"width: 75px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">&nbsp</td>";
            closing += "<td style=\"width: 75px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">&nbsp</td>";
            closing += "<td style=\"width: 75px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">&nbsp</td>";
            closing += "<td style=\"width: 75px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">&nbsp</td>";
            closing += "<td style=\"width: 75px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + wt + " </td>";
            closing += "<td style=\"width: 75px;background-color: " + colour + ";text-align: center;font-size: 12px;border-right: solid 1 c0c0c0;border-left: solid 1 c0c0c0;border-bottom:solid 1 c0c0c0;\">" + amt + " </td>";        
            closing += "</tr>";

            return closing;
        }
        private String Space(int NO)
        {
            String spac = string.Empty;
            spac += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:900px;font-size: 12px;\"><tr>";
            spac += "<td style=\"height: 25px;background-color:white;font-size: 14px;\">&nbsp;</td>";
            spac += "</tr></table>";
            return spac;
        }
        private String LargeTable(String name,DataTable dt,String mode)
        {
            try
            {
                double dwt = 0.00;
                double dTtlAmt = 0.00;
                string date = PLABS.Utils.CnvToStr(dt.Rows[0]["dt"]);
                String colour="#FFFFFF";

                String ledgerTble=string .Empty;
                ledgerTble  =  "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:650px;font-size: 12px;text-align:left; font-family: 'Trebuchet MS';\">";
                if (mode == "IM")
                {
                    ledgerTble += "<tr><td colspan=\"9\"style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFFFFF;font-size: 14px;color: Black;width:650px;text-align: left;font-weight:400;\" >" + name + "</td></tr> ";
                }
                else
                {
                    ledgerTble += "<tr><td colspan=\"9\"style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFFFFF;font-size: 14px;color: Black;width:650px;text-align: left;font-weight:400;\" >" + name + "</td></tr> ";
                }
                ledgerTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:75px;text-align:center;font-weight:400;\">DATE</td> ";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:125px;text-align:center;font-weight:400;\">ITEM NAME</td> ";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:75px;text-align:center;font-weight:400;\">GRS WT</td> ";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:75px;text-align:center;font-weight:400;\">PURE WT</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:50px;text-align:center;font-weight:400;\">MC</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:75px;text-align:center;font-weight:400;\">MC RATE</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:75px;text-align:center;font-weight:400;\" >WEIGHT</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:75px;text-align:center;font-weight:400;\" >AMOUNT</td>";
               // if (mode == "IM")
               // {
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >USER</td></tr>";
              //  }
                for(int i=0;i<dt.Rows .Count;i++)
                {
                    date = PLABS.Utils.CnvToStr(dt.Rows[i]["dt"]);
                    string item = PLABS.Utils.CnvToStr(dt.Rows[i]["itm"]);
                    double gwt = PLABS.Utils.CnvToDouble(dt.Rows[i]["gw"]);
                    string gw = string.Empty;
                    string pw = string.Empty;
                    string mc = string.Empty;
                    string mcrt = string.Empty;
                    string wt=string.Empty ;
                    string amt = string.Empty;
                    string usr="&nbsp";
                    //if (mode == "IM")
                   // {
                         if(!string.IsNullOrEmpty(PLABS.Utils.CnvToStr(dt.Rows[i]["usr_nam"])))
                         {
                             usr=PLABS.Utils.CnvToStr(dt.Rows[i]["usr_nam"]);
                         }
                   // }
                    if (item == string.Empty)
                    {
                        item = "&nbsp";
                    }
                    if (gwt == 0)
                    {
                        gw = "&nbsp";
                    }
                    else 
                    {
                        gw = gwt.ToString("N3");
                    }
                    double pwt = PLABS.Utils.CnvToDouble(dt.Rows[i]["pw"]);

                    if (pwt == 0)
                    {
                        pw = "&nbsp";
                    }
                    else 
                    {
                        pw = pwt.ToString("N3");
                    }
                    double dMc = PLABS.Utils.CnvToDouble(dt.Rows[i]["mc"]);
                    if (dMc == 0)
                    {
                        mc = "&nbsp";
                    }
                    else
                    {
                        mc = dMc.ToString("N3");
                    }
                    double dMcRt = PLABS.Utils.CnvToDouble(dt.Rows[i]["mcrt"]);

                    if (dMcRt == 0)
                    {
                        mcrt = "&nbsp";
                    }
                    else 
                    {
                        mcrt = dMcRt.ToString("N2");
                    }
                    dwt += pwt;
                    if(dwt==0)
                    {
                        wt="&nbsp";
                    }
                    else
                    {
                         wt=dwt.ToString("N3");
                    }
                    double dAmt = PLABS.Utils.CnvToDouble(dt.Rows[i]["amt"]);

                    if (dAmt == 0)
                    {
                        amt = "&nbsp";
                    }
                    else 
                    {
                        amt = dAmt.ToString("N2");
                    }                      
                    dTtlAmt += dAmt;
                    ledgerTble += " <tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:center;font-weight:400;\" >"+date+"</td>";
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:125px;text-align:left;font-weight:400;\" >"+item+"</td>";
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >"+gw+"</td>";
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >"+pw+"</td>";
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:50px;text-align:right;font-weight:400;\" >"+mc+"</td>";
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >"+mcrt+"</td>";
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >"+wt+"</td>";
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >" + amt + "</td>";
                  //  if (mode == "IM")
                   // {
                        ledgerTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:100px;text-align:left;font-weight:400;\" >" + usr + "</td></tr>";
                   // }

                    if (colour == "#FFFFFF")
                    {
                        colour ="#F7F6F3";
                    }
                    else
                    {
                        colour = "#FFFFFF";
                    }
                }

                ledgerTble += " <tr><td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:center;font-weight:400;\" >" + date + "</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:125px;text-align:right;font-weight:400;\" >CLOSING</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >&nbsp</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >&nbsp</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:50px;text-align:right;font-weight:400;\" >&nbsp</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >&nbsp</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >" + dwt.ToString("N3") + "</td>";
                ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:75px;text-align:right;font-weight:400;\" >" + dTtlAmt.ToString("N2") + "</td>";
                //ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:100px;text-align:right;font-weight:400;\" >" + dTtlAmt.ToString("N2") + "</td></tr>";
               // if (mode == "IM")
               // {
                    ledgerTble += "<td style=\"border-top: solid 1px c0c0c0; border-bottom: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:100px;text-align:right;font-weight:400;\">&nbsp</td></tr>";
               // }
                int n=0;
                while (n < 1)
                {
                    ledgerTble += "<tr>";
                    ledgerTble += "<td colspan=\"9\"style=\"font-size: 14px;color: Black;width:450px;text-align: center;font-weight:400;\">&nbsp</td></tr>";
                    n++;
                }

                ledgerTble += "</table>";
                return ledgerTble;
            }
            catch (Exception ex)
            {
 
            }
            return "";
        }
        private void LedgerClick1(String mode)
        {
            try
            {
              
                DataSet ds = GetDataSet(mode,"");
                DataTable data = PLABS.Utils.GetDataTable(ds, 0);                       
                DataTable id = data.DefaultView.ToTable(true, new string[] { "addr_id" });
                id.DefaultView.Sort = "addr_id asc";
                id = id.DefaultView.ToTable();
                 string html = string.Empty;
                 if (data.Rows.Count > 0)
                 {
                     for (int i = 0; i < id.Rows.Count; i++)
                     {
                         string addrId = PLABS.Utils.CnvToStr(id.Rows[i]["addr_id"]);
                         data.DefaultView.RowFilter = string.Format("addr_id='{0}'", addrId);
                         DataTable ledger = data.DefaultView.ToTable();
                         DataRow[] dr = ledger.Select("tran='tr'", "");
                         if(dr.Length>0)
                         {
                             string name = "SMITH :-" + PLABS.Utils.CnvToStr(ledger.Rows[0]["nam"]);
                             if (ledger.Rows.Count > 1)
                             {
                                 html += this.LargeTable(name, ledger, mode);
                             }
                         }
                         
                     }
                 }

                if (mode == "IM")
                {
                    html += this.SmallTable("SHEET WEIGHT", PLABS.Utils.GetDataTable(ds, 1));
                }
                this.webBrowser1.DocumentText = html;
               
            }
            catch (Exception ex)
            {
 
            }
        }
        private void LedgerClick(String mode)
        {
            try
            {

                DataSet ds = GetDataSet(mode, "");
                DataTable data = PLABS.Utils.GetDataTable(ds, 0);
                DataTable id = data.DefaultView.ToTable(true, new string[] { "addr_id" });
                id.DefaultView.Sort = "addr_id asc";
                id = id.DefaultView.ToTable();
                string html = string.Empty;
                for (int i = 0; i < id.Rows.Count; i++)
                {
                    string addrId = PLABS.Utils.CnvToStr(id.Rows[i]["addr_id"]);
                    data.DefaultView.RowFilter = string.Format("addr_id='{0}'", addrId);
                    DataTable ledger = data.DefaultView.ToTable();

                    string name = "SMITH :-" + PLABS.Utils.CnvToStr(ledger.Rows[0]["nam"]);
                    if (ledger.Rows.Count > 1)
                     {
                        html += this.LargeTable(name, ledger, mode);
                   }
                }

                if (mode == "IM")
                {
                    html += this.SmallTable("SHEET WEIGHT", PLABS.Utils.GetDataTable(ds, 1));
                }
                this.webBrowser1.DocumentText = html;

            }
            catch (Exception ex)
            {

            }
        }
        private String ConfirmTable(String heading, DataTable dt)
        {
            try
            {

                string sttlcr = string.Empty;
                string sttldr = string.Empty;
                string colour = "#FFFFFF";
                //string date = string.Empty;
                String smallTble = string.Empty;
                string user = string.Empty;
                smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:815px;font-size: 12px;text-align:left;font-family: 'Trebuchet MS';\"><tr>";
                smallTble += "<td colspan=\"10\" style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;font-size: 14px;color: Black;width:815px;text-align: center;font-weight:400;\">" + heading + "</td></tr>";
                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:70px;text-align:center;font-weight:400;\">DATE</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">SMITH</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:130px;text-align:center;font-weight:400;\">ITEM</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:105px;text-align:center;font-weight:400;\">DESC</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:60px;text-align:center;font-weight:400;\">WEIGHT</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:60px;text-align:center;font-weight:400;\">MC</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:60px;text-align:center;font-weight:400;\">AMC</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:60px;text-align:center;font-weight:400;\">MC RATE</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:60px;text-align:center;font-weight:400;\">AMC RATE</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:60px;text-align:center;font-weight:400;\">USER</td></tr>";

                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">CREDIT</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">&nbsp</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >&nbsp</td></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string date = PLABS.Utils.CnvToStr(dt.Rows[i]["dt"]);
                    string smith = PLABS.Utils.CnvToStr(dt.Rows[i]["smith"]);
                    string item = PLABS.Utils.CnvToStr(dt.Rows[i]["item"]);
                    string desc = PLABS.Utils.CnvToStr(dt.Rows[i]["descr"]);
                    string wt = PLABS.Utils.CnvToStr(dt.Rows[i]["Wt"]);
                    string mc = PLABS.Utils.CnvToStr(dt.Rows[i]["mc"]);
                    string aMc = PLABS.Utils.CnvToStr(dt.Rows[i]["mc_A"]);
                    string mcRate = PLABS.Utils.CnvToStr(dt.Rows[i]["mc_rate"]);
                    string aMcRate = PLABS.Utils.CnvToStr(dt.Rows[i]["mcrate_A"]);
                    string usr_nam = PLABS.Utils.CnvToStr(dt.Rows[i]["usr_nam"]);
                    if (usr_nam == string.Empty)
                    {
                        usr_nam = "&nbsp";
                    }
                    if (mc == string.Empty)
                    {
                        mc = "&nbsp";
                    }
                    if (aMc == string.Empty)
                    {
                        aMc = "&nbsp";
                    }
                    if (mcRate == string.Empty && aMcRate == string.Empty)
                    {
                        mcRate = "0";
                        aMcRate = "0";
                       

                    }
                    if (desc == string.Empty)
                    {
                        desc = "&nbsp";
                    }
                    smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:70px;text-align:center;font-weight:400;\">" + date + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:left;font-weight:400;\">" + smith + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0; border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:130px;text-align:left;font-weight:400;\">" + item + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0; border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:105px;text-align:left;font-weight:400;\">" + desc + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0; border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:60px;text-align:left;font-weight:400;\">" + wt + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0; border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:60px;text-align:right;font-weight:400;\">" + mc + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0; border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:60px;text-align:right;font-weight:400;\">" + aMc + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0; border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:60px;text-align:right;font-weight:400;\">" + mcRate + "</td> ";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0; border-left: solid 1px c0c0c0;;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:60px;text-align:right;font-weight:400;\">" + aMcRate + "</td> ";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0; border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:60px;text-align:left;font-weight:400;\">" + usr_nam + "</td></tr> ";

                    if (colour == "#FFFFFF")
                    {
                        colour = "#F6F7F3";
                    }
                    else
                    {
                        colour = "#FFFFFF";
                    }
                }

                int n = 0;
                while (n < 1)
                {
                    smallTble += "<tr>";
                    smallTble += "<td colspan=\"10\"style=\"font-size: 14px;color: Black;width:815px;text-align: center;font-weight:400;\">&nbsp</td></tr>";
                    n++;
                }
                smallTble += "</table>";


               
              
                return smallTble;
            }
            catch (Exception ex)
            {

            }
            return "";
        }
        private String SmallTable(String heading,DataTable dt)
        {
            try
            {
                double ttldr = 0.00;
                double ttlcr = 0.00;
                string sttlcr=string.Empty ;
                string sttldr=string.Empty ;
                string colour = "#FFFFFF";
                string date = PLABS .Utils .CnvToStr(dt.Rows[0]["dt"]);
                String smallTble=string.Empty ;
                string user = string.Empty;
                smallTble+="<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:700px;font-size: 12px;text-align:left; font-family: 'Trebuchet MS';\"><tr>";
                smallTble += "<td colspan=\"5\" style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;font-size: 14px;color: Black;width:700px;text-align: center;font-weight:400;\">" + heading + "</td></tr>";
                smallTble+="<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\">DATE</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:200px;text-align:center;font-weight:400;\">ITEM NAME</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">DESC</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:125px;text-align:center;font-weight:400;\">PAYMENT</td>"; // DEBIT
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:125px;text-align:center;font-weight:400;\">RECEIPT</td>"; //CREDIT

                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">CREDIT</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">&nbsp</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >&nbsp</td></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                   string dr = string.Empty;
                   string cr = string.Empty;
                   date = PLABS.Utils.CnvToStr(dt.Rows[i]["dt"]);
                   string item = PLABS.Utils.CnvToStr(dt.Rows[i]["itm"]);
                   double ddr = PLABS.Utils.CnvToDouble(dt.Rows[i]["dr"]);
                   string desc=PLABS.Utils.CnvToStr(dt.Rows[i]["descr"]);
                   if (ddr == 0)
                   {
                       dr = "&nbsp";
                   }
                   else 
                   {
                       dr = ddr.ToString("F3");
                   }

                   double dcr = PLABS.Utils.CnvToDouble(dt.Rows[i]["cr"]);
                   if (dcr == 0)
                   {
                       cr = "&nbsp";
                   }
                   else
                   {
                       cr = dcr.ToString("F3");
                   }
                   ttldr += ddr;
                   ttlcr += dcr;

                   smallTble+="<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:"+colour+";font-size: 12px;color: Black;width:100px;text-align:center;font-weight:400;\">"+date+"</td>";
                   smallTble+="<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:"+colour+";font-size: 12px;color: Black;width:200px;text-align:left;font-weight:400;\">"+item+"</td>";
                   smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:left;font-weight:400;\">" + desc + "</td>";

                   smallTble+="<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:"+colour+";font-size: 12px;color: Black;width:125px;text-align:right;font-weight:400;\">"+dr+"</td>";
                   smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:125px;text-align:right;font-weight:400;\">" + cr + "</td></tr> ";

                   if (colour == "#FFFFFF")
                   {
                       colour = "#F6F7F3";
                   }
                   else 
                   {
                       colour = "#FFFFFF";
                   }
                }
                string ttlcls = (ttldr - ttlcr).ToString("N3");
                if (heading == "SHEET WEIGHT")
                {
                    date = "&nbsp";
                    sttlcr="&nbsp";
                    sttldr="&nbsp";
                    ttlcls = "&nbsp";
                    user = "&nbsp";                 

                }
                
               
                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:"+colour+";font-size: 12px;color: Black;width:100px;text-align:center;font-weight:400;\">"+date+"</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:"+colour+";font-size: 12px;color: Black;width:200px;text-align:center;font-weight:400;\">CLOSING</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:"+colour+";font-size: 12px;color: Black;width:150px;text-align:center;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:125px;text-align:center;font-weight:400;\">" + ttlcls + "</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:125px;text-align:center;font-weight:400;\">&nbsp</td>";

                ////smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 14px;color: Black;width:150px;text-align:right;font-weight:400;\">" + ttlcls + "</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:center;font-weight:400;\">&nbsp</td>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >&nbsp</td></tr>";

                int n = 0;
                while (n < 3)
                {
                    smallTble += "<tr>";
                    smallTble += "<td colspan=\"4\"style=\"font-size: 14px;color: Black;width:700px;text-align: center;font-weight:400;\">&nbsp</td></tr>";
                    n++;
                }
                smallTble += "</table>";
                return smallTble;
            }
            catch (Exception ex)
            {
 
            }
            return "";
        }
        private void ConfirmGrid()
        {
            try
            {
                string xmlData = this.getBlankXml();
                String strrpt = string.Empty;
                //dtp_curdt.Value.ToString("yyyy-MM-dd")
                xmlData = PLABS.Utils.addNodes(xmlData,this.getSelectArgs("CR",""));
                //xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "");
                //xmlData = PLABS.Utils.addNode(xmlData, "ad_dt", "");
                xmlData = this.CallWS(xmlData, "BizObj.RPH_001,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                strrpt += this.ConfirmTable("CONFIRMATION", PLABS.Utils.GetDataTable(ds, 0));
                strrpt += this.ConfirmTable("CAPITAL PENDING", PLABS.Utils.GetDataTable(ds, 1));
                this.webBrowser1.DocumentText = strrpt;
            }
            catch (Exception ex)
            {

            }
        }
        private void SheetWeightClick()
        {
            try
            {
                DataSet ds = this.GetDataSet("SW", "");
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                this.webBrowser1.DocumentText = this.SmallTable("SHEET WEIGHT", dt);
            }
            catch (Exception ex)
            {
 
            }
        }
        private void PettyCashClick()
        {
            try
            {
                DataSet ds = this.GetDataSet("PC", "");
                DataTable pettyCash = PLABS.Utils.GetDataTable(ds, 0);
                DataTable sheetCash = PLABS.Utils.GetDataTable(ds, 1);
                DataTable journel = PLABS.Utils.GetDataTable(ds, 2);
                DataTable sheetFull = PLABS.Utils.GetDataTable(ds, 3);
                this.webBrowser1.DocumentText = this.SmallTableC("CASH BOOK", pettyCash) + this.SmallTableC("SHEET CASH", sheetCash) + this.SmallTableC("JOURNEL", journel)+this.SmallTableC("ALL SHEET CASH",sheetFull);
            }
            catch (Exception ex)
            {
                 
            }
        }
        private void JournelClick()
        {
            try
            {
                DataSet ds = this.GetDataSet("JR", "");
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                this.webBrowser1.DocumentText = this.SmallTable("JOURNEL", dt);
            }
            catch (Exception ex)
            {
 
            }
        }
        private String StockTable(DataTable dt)
        {
            try
            {
                string colour = "#FFFFFF";
                String smallTble = string.Empty;
                smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:650px;font-size: 12px;text-align:left; font-family: 'Trebuchet MS';\"><tr>";
                smallTble += "<td colspan=\"6\" style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;font-size: 14px;color: Black;width:650px;text-align: center;font-weight:400;\">STOCK REGISTER</td></tr>";
                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:175px;text-align:center;font-weight:400;\">ITEM NAME</td>";
                
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:175px;text-align:center;font-weight:400;\">WT</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\">SPLX</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\">SHRT</td>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\">GAIN</td></tr>";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string itm = "&nbsp";
                   
                    string wt = "&nbsp";
                    string splx = "&nbsp";
                    string shrt = "&nbsp";
                    //string gain = "&nbsp";
                    itm = PLABS .Utils .CnvToStr(dt.Rows[i]["itm"]);
                    if (PLABS.Utils.CnvToDouble(dt.Rows[i]["wt"]) != 0)
                    {
                        wt = PLABS.Utils.CnvToDouble(dt.Rows[i]["wt"]).ToString("N3");
                    }
                    if (PLABS.Utils.CnvToDouble(dt.Rows[i]["srx"]) != 0)
                    {
                        splx = PLABS.Utils.CnvToDouble(dt.Rows[i]["srx"]).ToString("N3");
                    }
                    if (PLABS.Utils.CnvToDouble(dt.Rows[i]["srt"]) != 0)
                    {
                        shrt = PLABS.Utils.CnvToDouble(dt.Rows[i]["srt"]).ToString("N3");
                    }
                    //if (PLABS.Utils.CnvToDouble(dt.Rows[i]["gain"]) != 0)
                    //{

                    //    gain = PLABS.Utils.CnvToDouble(dt.Rows[i]["gain"]).ToString("N3");
                    //}
                    smallTble += "<tr><td style=\"border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:175px;text-align:center;font-weight:400;\">" + itm + "</td>";
                    
                    smallTble += "<td style=\"border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:175px;text-align:right;font-weight:400;\">" + wt + "</td>";
                    smallTble += "<td style=\"border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:100px;text-align:right;font-weight:400;\">" + splx + "</td>";
                    smallTble += "<td style=\"border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:right;font-weight:400;\">" + shrt + "</td>";
                    //smallTble += "<td style=\"border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:right;font-weight:400;\">" + gain + "</td></tr>";
                    if (colour == "#FFFFFF")
                    {
                        colour = "#CCCCFF";
                    }
                    else
                    {
                        colour = "#FFFFFF";
                    }
                }

                    smallTble += "</table>";

                return smallTble;
            }
            catch (Exception ex)
            {
 
            }
            return "";
        }
        private void AllClick()
        {
            try
            {
                string html = string.Empty;
                string mode="LR" ;
                DataSet ds = GetDataSet("", "");
                for (int j=0; j < 2; j++)
                {
                    if (j == 1)
                    {
                        mode = "IR";
                    }
                   
                    DataTable data = PLABS.Utils.GetDataTable(ds,j);
                    DataTable id = data.DefaultView.ToTable(true, new string[] { "addr_id" });
                    id.DefaultView.Sort = "addr_id asc";
                    id = id.DefaultView.ToTable();

                    for (int i = 0; i < id.Rows.Count; i++)
                    {
                        if (j == 1)
                        {
                            string addrId = PLABS.Utils.CnvToStr(id.Rows[i]["addr_id"]);
                            data.DefaultView.RowFilter = string.Format("addr_id='{0}'", addrId);
                            DataTable ledger = data.DefaultView.ToTable();
                            DataRow[] dr = ledger.Select("tran='tr'", "");
                            if (dr.Length > 0)
                            {
                                string name = "SMITH :-" + PLABS.Utils.CnvToStr(ledger.Rows[0]["nam"]);
                                if (ledger.Rows.Count > 1)
                                {
                                    html += this.LargeTable(name, ledger, mode);
                                }
                            }
                        }
                        else
                        {
                            string addrId = PLABS.Utils.CnvToStr(id.Rows[i]["addr_id"]);
                            data.DefaultView.RowFilter = string.Format("addr_id='{0}'", addrId);
                            DataTable ledger = data.DefaultView.ToTable();

                            string name = "SMITH :-" + PLABS.Utils.CnvToStr(ledger.Rows[0]["nam"]);
                            if (ledger.Rows.Count > 1)
                            {
                                html += this.LargeTable(name, ledger, mode);
                            }
                        }
                    }
                }
                html +=this.SmallTable ("SHEET WEIGHT",PLABS .Utils .GetDataTable(ds,2));
                html += this.SmallTableC("PETTY CASH", PLABS.Utils.GetDataTable(ds, 3));
                html += this.SmallTableC("SHEET CASH", PLABS.Utils.GetDataTable(ds, 4));
                html += this.SmallTableC("JOURNEL", PLABS.Utils.GetDataTable(ds, 5));
                html += this.SmallTableC("ALL SHEET CASH", PLABS.Utils.GetDataTable(ds, 6));
                html += this.StockTable(PLABS.Utils.GetDataTable(ds, 7));
                this.webBrowser1.DocumentText = html;
            }
            catch (Exception ex)
            {
 
            }
        }
        private String SmallTableC(String heading, DataTable dt)
        {
            try
            {
                double ttldr = 0.00;
                double ttlcr = 0.00;
                string sttlcr = string.Empty;
                string sttldr = string.Empty;
                string colour = "#FFFFFF";
                string date = PLABS.Utils.CnvToStr(dt.Rows[0]["dt"]);
                String smallTble = string.Empty;
                string user = string.Empty;
                smallTble += "<table border=\"0\"cellpadding=\"0\" cellspacing=\"0\" style=\"width:700px;font-size: 12px;text-align:left; font-family: 'Trebuchet MS';\"><tr>";
                smallTble += "<td colspan=\"5\" style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;font-size: 14px;color: Black;width:700px;text-align: center;font-weight:400;\">" + heading + "</td></tr>";
                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\">DATE</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:250px;text-align:center;font-weight:400;\">ITEM NAME</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">PAYMENT</td>"; //DEBIT
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">RECEIPT</td>"; //CREDIT
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#CCCCFF;font-size: 14px;color: Black;width:50px;text-align:center;font-weight:400;\">USER</td>";

                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">CREDIT</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-right: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:150px;text-align:center;font-weight:400;\">&nbsp</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >&nbsp</td></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string dr = string.Empty;
                    string cr = string.Empty;
                    date = PLABS.Utils.CnvToStr(dt.Rows[i]["dt"]);
                    string item = PLABS.Utils.CnvToStr(dt.Rows[i]["itm"]);
                    double ddr = PLABS.Utils.CnvToDouble(dt.Rows[i]["dr"]);
                    string usr_nam = PLABS.Utils.CnvToStr(dt.Rows[i]["usr_nam"]);
                    if (usr_nam == string.Empty)
                    {
                        usr_nam = "&nbsp";
                    }
                    if (ddr == 0)
                    {
                        dr = "&nbsp";
                    }
                    else
                    {
                        dr = ddr.ToString("F3");
                    }

                    double dcr = PLABS.Utils.CnvToDouble(dt.Rows[i]["cr"]);
                    if (dcr == 0)
                    {
                        cr = "&nbsp";
                    }
                    else
                    {
                        cr = dcr.ToString("F3");
                    }
                    ttldr += ddr;
                    ttlcr += dcr;

                    smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:100px;text-align:center;font-weight:400;\">" + date + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:250px;text-align:left;font-weight:400;\">" + item + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:right;font-weight:400;\">" + dr + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:right;font-weight:400;\">" + cr + "</td>";
                    smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:50px;text-align:left;font-weight:50;\">" + usr_nam + "</td></tr>";

                    if (colour == "#FFFFFF")
                    {
                        colour = "#F6F7F3";
                    }
                    else
                    {
                        colour = "#FFFFFF";
                    }
                }
                string ttlcls = (ttldr - ttlcr).ToString("N3");
                if (heading == "SHEET WEIGHT")
                {
                    date = "&nbsp";
                    sttlcr = "&nbsp";
                    sttldr = "&nbsp";
                    ttlcls = "&nbsp";
                    user = "&nbsp";

                }


                smallTble += "<tr><td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:100px;text-align:center;font-weight:400;\">" + date + "</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:250px;text-align:center;font-weight:400;\">CLOSING</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:center;font-weight:400;\">&nbsp</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:center;font-weight:400;\">" + ttlcls + "</td>";
                smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:50px;text-align:left;font-weight:400;\">&nbsp</td>";

                ////smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:" + colour + ";font-size: 14px;color: Black;width:150px;text-align:right;font-weight:400;\">" + ttlcls + "</td></tr>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-bottom: solid 1px c0c0c0;border-left: solid 1px c0c0c0;background-color:" + colour + ";font-size: 12px;color: Black;width:150px;text-align:center;font-weight:400;\">&nbsp</td>";
                //smallTble += "<td style=\"border-top: solid 1px c0c0c0;border-left: solid 1px c0c0c0;border-right: solid 1px c0c0c0;background-color:#FFCCFF;font-size: 14px;color: Black;width:100px;text-align:center;font-weight:400;\" >&nbsp</td></tr>";

                int n = 0;
                while (n < 3)
                {
                    smallTble += "<tr>";
                    smallTble += "<td colspan=\"5\"style=\"font-size: 14px;color: Black;width:700px;text-align: center;font-weight:400;\">&nbsp</td></tr>";
                    n++;
                }
                smallTble += "</table>";
                return smallTble;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        #endregion 
    }
}
