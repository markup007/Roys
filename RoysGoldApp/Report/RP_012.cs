using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace RoysGold
{
    public partial class RP_012 :PLABS .MasterForm
    {
        #region Global Variable
        string _mode = "FRESH";
        //Font verdana10Font;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public RP_012()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.fnd_smth.AfterFind += new EventHandler(fnd_smth_AfterFind);
            this.btn_prt.Click += new EventHandler(btn_prt_Click);
            this.txt_pgno.KeyDown += new KeyEventHandler(txt_pgno_KeyDown);
            base.OnLoad(e);
        }

      
        #endregion
        #region Events
        void txt_pgno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this._mode = "DUPLICATE";
                    this.LoadReport();
                }
            }
            catch (Exception ex)
            {

            }
        }

        void btn_prt_Click(object sender, EventArgs e)
        {
            try
            {
                //this._mode = "DUPLICATE";
                this.Print();
            }
            catch (Exception ex)
            {

            }
        }

        void fnd_smth_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this._mode = "FRESH";
                this.LoadReport();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region Method
        private void LoadControls()
        {
            try
            {
                DataSet ds = this.GetDataSet("LO", "");
                this.fnd_smth.LoadData(PLABS.Utils.GetDataTable(ds, 0), "nam", "nam", "id");
            }
            catch (Exception ex)
            {
 
            }
        }
        private String getSelectArgs(string as_mode,string ai_pgno)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_pgno", ai_pgno);
                argXml = PLABS.Utils.addNode(argXml, "ai_smth_id",this.fnd_smth.ControlValue);
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
                //BizObj.RP_001 objrptiss = new BizObj.RP_001();
                //xmlData = objrptiss.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsmthissrecmast", "0009");
            }
            return xmlData;
        }
        private DataSet GetDataSet(String as_mode, String ai_pgno)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode,ai_pgno));
                xmlData = this.CallWS(xmlData, "BizObj.RP_012,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private void LoadReport()
        {
            try
            {

                rtxt_rpt.Text="";
               
                DataSet ds = this.GetDataSet("LG", this.txt_pgno.Text);
               

                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                DataTable dt1 = PLABS.Utils.GetDataTable(ds, 1);

                if (dt.Rows.Count > 1)
                {
                    if (_mode == "FRESH")
                    {
                        this.txt_pgno.Text = PLABS.Utils.CnvToStr(dt1.Rows[0]["pgno"]);
                    }
                    int len = 45;
                    double ttlWt = 0.000;
                    double ttlcsh = 0.00;

                    string no = txt_pgno.ControlValue;


                    RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    objRptTextCntr.Gf_DrawText(this.fnd_smth.SelectedCode, RptControl.TextAlign.Center,45, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    objRptTextCntr.Gf_DrawText(string.Format("{0}", DateTime.Now.ToString("dd-MMM-yy")), RptControl.TextAlign.Center, 16, false);
                    objRptTextCntr.Gf_DrawText(_mode, RptControl.TextAlign.Center, 15, false);
                    objRptTextCntr.Gf_DrawText("No:" + no, RptControl.TextAlign.Center, 8, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    
                    objRptTextCntr.Gf_DrawText("___________________________________________", RptControl.TextAlign.Center, len, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    

                    objRptTextCntr.Gf_DrawText("Date", RptControl.TextAlign.Center, 6, true);
                    objRptTextCntr.Gf_DrawText("Itm", RptControl.TextAlign.Center, 3, true);
                    objRptTextCntr.Gf_DrawText("net", RptControl.TextAlign.Center, 8, true);
                    objRptTextCntr.Gf_DrawText("Narration", RptControl.TextAlign.Center, 11, true);
                    //objRptTextCntr.Gf_DrawText("Pur", RptControl.TextAlign.Center, 5, true);
                    objRptTextCntr.Gf_DrawText("Weight", RptControl.TextAlign.Center, 8, true);
                    objRptTextCntr.Gf_DrawText("Cash", RptControl.TextAlign.Center, 8, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);

                   
                    objRptTextCntr.Gf_DrawText("___________________________________________", RptControl.TextAlign.Center, len, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                   


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string[] rsltDesc=new string[1];

                        string desc = PLABS.Utils.CnvToStr(dt.Rows[i]["dsc"]);

                        if (desc.Length > 10)
                        {
                            int cnt = desc.Length / 10;
                            rsltDesc = new string[cnt];

                            for (int j = 0; cnt > j; j++)
                            {
                                if ((10 * j) + 10 < desc.Length)
                                {
                                    rsltDesc[j] = desc.Substring(10 * j, 10);
                                }
                                else
                                {
                                    rsltDesc[j] = desc.Substring(10 * j, ((10 * j) + 10) - desc.Length);
                                }
                            }
                        }
                        else
                        {
                            rsltDesc[0] = desc;
                        }
                        for (int strcnt = 0; rsltDesc.Length > strcnt; strcnt++)
                        {
                            if (strcnt == 0)
                            {
                                objRptTextCntr.Gf_DrawText(PLABS.Utils.CnvToDate(dt.Rows[i]["date"]).ToString("dd-MM"), RptControl.TextAlign.Center, 6, false);
                                objRptTextCntr.Gf_DrawText(dt.Rows[i]["Itm"], RptControl.TextAlign.Right, 3, false);
                                objRptTextCntr.Gf_DrawText(dt.Rows[i]["net"], RptControl.TextAlign.Right, 8, false,"F2");
                                objRptTextCntr.Gf_DrawText(rsltDesc[strcnt]/*dt.Rows[i]["dsc"]*/, RptControl.TextAlign.Center, 11, false);
                                //objRptTextCntr.Gf_DrawText(dt.Rows[i]["prty"], RptControl.TextAlign.Left,5, false);
                                if (PLABS.Utils.CnvToDouble(dt.Rows[i]["wt"]) != 0)
                                {
                                    objRptTextCntr.Gf_DrawText(dt.Rows[i]["wt"], RptControl.TextAlign.Right, 8, false, "F2");
                                }
                                else
                                {
                                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 8, false);
                                }



                                if (PLABS.Utils.CnvToDouble(dt.Rows[i]["amt"]) != 0)
                                {
                                    objRptTextCntr.Gf_DrawText(dt.Rows[i]["amt"], RptControl.TextAlign.Right, 10, false, "N0");
                                }
                                else
                                {
                                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 10, false);
                                }


                                objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);

                                ttlWt += PLABS.Utils.CnvToDouble(dt.Rows[i]["wt"]);
                                ttlcsh += PLABS.Utils.CnvToDouble(dt.Rows[i]["amt"]);
                            }
                            else
                            {
                                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 10, false);
                                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 6, false);
                                objRptTextCntr.Gf_DrawText(rsltDesc[strcnt]/*dt.Rows[i]["dsc"]*/, RptControl.TextAlign.Left, 11, false);
                                //objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 5, false);
                                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 7, false);
                                objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 8, false);
                                objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);

                            }
                        }
                       
                    }
                    objRptTextCntr.Gf_DrawText("___________________________________________", RptControl.TextAlign.Center, len, false);
                    
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    
                    objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 10, false);
                    objRptTextCntr.Gf_DrawText("TOTAL", RptControl.TextAlign.Left, 11, false);
                    objRptTextCntr.Gf_DrawText(ttlWt, RptControl.TextAlign.Center, 11, false, "F3");
                    objRptTextCntr.Gf_DrawText(ttlcsh, RptControl.TextAlign.Center, 13, false, "N2");
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    
                    objRptTextCntr.Gf_DrawText("___________________________________________", RptControl.TextAlign.Center, len, false);
                   
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);
                    objRptTextCntr.Gf_DrawText(Environment.NewLine, RptControl.TextAlign.Center, 0, false);

                    objRptTextCntr.Gf_DrawText("m", RptControl.TextAlign.Left,10, false);

                    
                    this.rtxt_rpt.Text = objRptTextCntr.GF_GetPrintString();




                }
                else
                {
                    PLABS.MessageBoxPL.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                PLABS.MessageBoxPL.Show(ex.Message);
            }
        }
        private void Print()
        {
            try
            {  
                    string xmlData = this.getBlankXml();
                    xmlData = PLABS.Utils.addNode(xmlData, "as_mode", "I");
                    xmlData = PLABS.Utils.addNode(xmlData, "ai_smthId", this.fnd_smth.ControlValue);
                    xmlData = PLABS.Utils.addNode(xmlData, "ai_pgno", this.txt_pgno.ControlValue);
                    xmlData = this.CallWS(xmlData, "BizObj.RP_012,BizObj", "I");

                    if (xmlData.Length < 7)
                    {
                     //File.WriteAllText(@"D:\sanu.txt", this.rtxt_rpt.Text);
                    //  Process prcs=new Process ();
                    //  prcs.StartInfo.Verb = "Print";
                    //  prcs.StartInfo.FileName = @"D:\sanu.txt";
                    //  prcs.Start();
                        //prcs .Start("Print",@"D:\sanu.txt");
                            //prcs.Close();


                     File.WriteAllText(@"D:\sanu.txt", this.rtxt_rpt.Text);
                       // pr
                     Process.Start("Print", @"D:\sanu.txt");



                        //verdana10Font = new Font("Courier New", 10);
                        ////Create a PrintDocument object
                       
                        //System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                        //pd.PrintPage+=new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
                        ////Call Print Method
                        //pd.Print();
                       
                        
                    }

            }
            catch (Exception ex)
            {
 
            }
        }

        //void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    try
        //    {
        //        //Get the Graphics object
        //        Graphics g = e.Graphics;
        //        float linesPerPage = 0;
        //        float yPos = 0;
        //        int count = 0;
        //        //Read margins from PrintPageEventArgs
        //        float leftMargin = e.MarginBounds.Left;
        //        float topMargin = e.MarginBounds.Top;
        //        string line = null;
        //        //Calculate the lines per page on the basis of the height of the page and the height of the font
        //        linesPerPage = e.MarginBounds.Height /
        //        verdana10Font.GetHeight(g);
        //        StringReader reader = new StringReader(this.rtxt_rpt.Text);
              
        //        //Now read lines one by one, using StreamReader
        //        while (count < linesPerPage && ((line = reader.ReadLine()) != null))
        //        {
        //            //Calculate the starting position
        //            yPos = topMargin + (count *
        //            verdana10Font.GetHeight(g));
        //            //Draw text
        //            g.DrawString(line, verdana10Font, Brushes.Black,
        //            leftMargin, yPos, new StringFormat());
        //            //Move to next line
        //            count++;
        //        }
        //        //If PrintPageEventArgs has more pages to print
        //        if (line != null)
        //        {
        //            e.HasMorePages = true;
        //        }
        //        else
        //        {
        //            e.HasMorePages = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
 
        //    }
        //}
       

        #endregion
    }
}
