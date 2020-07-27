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
    public partial class RP_005 : PLABS.MasterForm
    {
        #region Global variables
        //int temp;
        //double iss_wt1 = 0;
       // double pur_wt1 = 0;
        //double issrecwt1 = 0;
        //int b;
        //string[] arr = new string[100];
        //int len = 79;
       // double iss_wt = 0;
       // double pur_wt = 0;
        //double blnce_wt = 0;
        //int i;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public RP_005()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            
            this.loadControls();
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.btn_load.Click += new EventHandler(btn_load_Click);
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.fnd_gold_id.AfterFind += new EventHandler(fnd_gold_id_AfterFind);
            base.OnLoad(e);
        }

    
        #endregion
        #region Events

        void btn_print_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btn_load_Click(object sender, EventArgs e)
         {
             DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")), this.fnd_gold_id.ControlValue);
             this.Print(ds);
            //if (ds.Tables.Count == 3)
           // {
                //this.print(ds);
                //this.rcpt(ds);
            //}
            //else
            //{
                //PLABS.MessageBoxPL.Show("No Record Found");
            //}
        }

        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void fnd_gold_id_AfterFind(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")), this.fnd_gold_id.ControlValue);
                this.Print(ds); this.fnd_gold_id.Focus();
            }
            catch
            {

            }
        }
        #endregion
        #region Methods


        private void loadControls()
        {
            try
            {
                this.rtxt_purchase.Focus();

                dp_frm.ControlValue = "04-" + "01-" + "2010";// DateTime.Now.ToString("MMM-yyyy");
                DateTime dt = DateTime.Now.AddMonths(1);
                dt = new DateTime(dt.Year, dt.Month, 1);
                dt = dt.AddDays(-1);
                dp_to.ControlValue = dt.ToString("dd-MMM-yyyy");

               
                DataSet ds = this.GetDataSet("LG", (dp_frm.Value.ToString("yyyy_MM_dd")), (dp_to.Value.ToString("yyyy_MM_dd")),this.fnd_gold_id .ControlValue);

                this.fnd_gold_id.LoadData(ds.Tables[0], "grp", "grp", "id");

                this.Print(ds);
                //this.ddl_smth_nam.LoadData(PLABS.Utils.GetDataTable(ds, 0), "addr_nam", "addr_id");
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0002");
            }
        }
        //public void print(DataSet ds)
        //{
        //    try
        //    {


        //        string SmithIssue =Convert.ToString(Convert.ToInt32(Enums.VoucherType.SmithIssue));
        //        string Purchase = Convert.ToString(Convert.ToInt32(Enums.VoucherType.RawPurchase));
        //        string SmithReciept = Convert.ToString(Convert.ToInt32(Enums.VoucherType.SmithReciept));
        //        string Sales = Convert.ToString(Convert.ToInt32(Enums.VoucherType.Sales));
        //        rep(ds,0, 1, "Purchaser Name", "Purchase Gold", "Issue Gold", "purchase", "Issue WT",SmithIssue,Purchase, "issue");
        //        rep(ds,4, 2, "Seller Name", "Seller Item", "Gold Name", "Reciept WT", "Sale WT",SmithReciept, Sales, "sales");
                                 
        //        }
       
          
        //    catch
        //    {
        //        PLABS.MessageBoxPL.Show("No Records", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
        //    }
        //    }
        private String getSelectArgs(String as_mode, String as_frm_date, String as_to_date, String ai_itm_id)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "as_frm_date", as_frm_date);
                argXml = PLABS.Utils.addNode(argXml, "as_to_date", as_to_date);
                    argXml = PLABS.Utils.addNode(argXml, "ai_itm_id", ai_itm_id);
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
                //BizObj.RP_005 objrptiss_recpt = new BizObj.RP_005();
                //xmlData = objrptiss_recpt.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trrawpurch", "0009");
            }
            return xmlData;
        }
        private void Print(DataSet ds)
        {
            try
            {
                
                this.rtxt_purchase .Text =this.GetFirstPrintString(ds.Tables[0], ds.Tables[1]);
            }
            catch (Exception ex)
            {

            }
        }
        private DataSet GetDataSet(String as_mode, String as_frm_date, String as_to_date,String ai_itm_id)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, as_frm_date, as_to_date, ai_itm_id));
                xmlData = this.CallWS(xmlData, "BizObj.RP_005,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            }
            
            catch (Exception ex)
            {
 
            }
            return ds;
        }
        private String GetFirstPrintString(DataTable master, DataTable detail)
        {
            try
            {
                int len = 92;
                RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();

                for (int i = 0; i < master.Rows.Count; i++)
                {
                    string itemId = PLABS.Utils.CnvToStr(master.Rows[i]["id"]);
                    string itemName = PLABS.Utils.CnvToStr(master.Rows[i]["grp"]);
                    DataRow[] sortDetailWithMaster = detail.Select("id= '" + itemId + "'");
                    if (sortDetailWithMaster.Length != 0)
                    {
                        double bal = 0.00;
                        for (int j = 0; j < sortDetailWithMaster.Length; j++)
                        {
                            DataRow row = sortDetailWithMaster[j];
                            if (j == 0)
                            {
                                objRptTextCntr.Gf_DrawText(itemName, RptControl.TextAlign.Center, len, false);
                                objRptTextCntr.GF_AddNewLine(0);
                                objRptTextCntr.GF_DrawLine(len);

                                objRptTextCntr.Gf_AddSeperator();
                                objRptTextCntr.Gf_DrawText("Date", RptControl.TextAlign.Center, 13, true);
                                objRptTextCntr.Gf_DrawText("Buyer", RptControl.TextAlign.Center, 12, true);
                                objRptTextCntr.Gf_DrawText("Purchase gold", RptControl.TextAlign.Center, 12, true);
                                objRptTextCntr.Gf_DrawText("Issue gold", RptControl.TextAlign.Center, 12, true);
                                objRptTextCntr.Gf_DrawText("Purchase WT", RptControl.TextAlign.Center, 13, true);
                                objRptTextCntr.Gf_DrawText("Issue WT", RptControl.TextAlign.Center, 12, true);
                                objRptTextCntr.Gf_DrawText("Balance", RptControl.TextAlign.Center, 12, true);
                                objRptTextCntr.GF_AddNewLine(0);
                                objRptTextCntr.GF_DrawLine(len);
                            }
                              string dat = "";
                             dat = PLABS.Utils.CnvToDate(row["dt"]).ToString("dd-MMM-yyyy");
                             objRptTextCntr.Gf_AddSeperator();
                             objRptTextCntr.Gf_DrawText(dat, RptControl.TextAlign.Left, 13, true);
                             objRptTextCntr.Gf_DrawText(PLABS .Utils .CnvToStr(row["nam"]), RptControl.TextAlign.Left, 12, true);
                             if (PLABS.Utils.CnvToDouble(row["gw"]) >0)
                             {
                                 objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                                 objRptTextCntr.Gf_DrawText(PLABS .Utils .CnvToStr(row["gld"]), RptControl.TextAlign.Left, 12, true);
                                 objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 13, true);
                                 objRptTextCntr.Gf_DrawText(PLABS .Utils .CnvToDouble(row["gw"]).ToString("N3"), RptControl.TextAlign.Right, 12, true);
                                 bal += PLABS.Utils.CnvToDouble(row["gw"]);
                             }
                             else if (PLABS.Utils.CnvToDouble(row["gw"]) < 0)
                             {
                                 objRptTextCntr.Gf_DrawText(PLABS .Utils .CnvToStr (row["gld"]), RptControl.TextAlign.Left, 12, true);
                                 objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                                 objRptTextCntr.Gf_DrawText((-1 * PLABS.Utils.CnvToDouble(row["gw"])).ToString("F3"), RptControl.TextAlign.Right, 13, true);
                                 objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                                 bal += PLABS.Utils.CnvToDouble(row["gw"]);
                             }
                            
                             objRptTextCntr.Gf_DrawText(bal.ToString ("N3"), RptControl.TextAlign.Right, 12, true);
                             objRptTextCntr.GF_AddNewLine(0);
                             if (j == sortDetailWithMaster.Length - 1)
                             {

                                 int n = 0;
                                 while (n < 3)
                                 {
                                     objRptTextCntr.Gf_AddSeperator();
                                     objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 13, true);
                                     objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                                     objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                                     objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                                     objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 13, true);
                                     objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                                     objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 12, true);
                                     objRptTextCntr.GF_AddNewLine(0);
                                     n++;

                                 }

                                 objRptTextCntr.GF_DrawLine(len);
                                 objRptTextCntr.Gf_AddSeperator();
                                 objRptTextCntr.Gf_DrawText("Total", RptControl.TextAlign.Right, 26, true);
                                 objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 12, true, "F3");
                                 objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 12, true, "F3");
                                 objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 13, true);
                                 objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Right, 12, true);
                                 objRptTextCntr.Gf_DrawText(bal.ToString("N3"), RptControl.TextAlign.Right, 12, true);
                                 objRptTextCntr.GF_AddNewLine(0);
                                 objRptTextCntr.GF_DrawLine(len);
                                 objRptTextCntr.GF_AddNewLine(2);

                             }

                        }
                    }
                }
                return objRptTextCntr.GF_GetPrintString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
        #endregion
    }
}
