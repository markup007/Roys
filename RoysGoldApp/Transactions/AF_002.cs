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
    public partial class AF_002 : PLABS.MasterForm
    {
        #region Global Varibales
        int _isPost;
        string stat;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public AF_002()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();
            this.ddl_mnth.SelectedIndexChanged += new EventHandler(ddl_mnth_SelectedIndexChanged);
            this.txt_grms.TextChanged += new EventHandler(txt_grms_TextChanged);
            this.txt_insv.TextChanged += new EventHandler(txt_insv_TextChanged);
            this.SaveBeforeClick += new EventHandler(AF_002_SaveBeforeClick);
            this.SaveAfterClick += new EventHandler(AF_002_SaveAfterClick);
            this.ClearBeforeClick += new EventHandler(AF_002_ClearBeforeClick);
            this.ClearAfterClick += new EventHandler(AF_002_ClearAfterClick);
            //this.grd_data.CellClick += new DataGridViewCellEventHandler(grd_data_CellClick);
            this.grd_data.KeyDown += new KeyEventHandler(grd_data_KeyDown);
            base.OnLoad(e);
        }

       
        #endregion
        #region Events
        void ddl_mnth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int curMnth = DateTime.Now.Month;


                if (DateTime.Now.Month == 1)
                {
                    this.MnthChanged();
                }
                else if(DateTime.Now.Month > PLABS.Utils.CnvToInt(ddl_mnth.ControlValue))
                {
                    this.MnthChanged();
                }
                else
                {
                    PLABS.MessageBoxPL.Show("Current Month And Coming Months Cannot be Calculate");
                    this.grd_data.ClearControl(true);
                    this.lbl_ttlpay.ClearControl(true);
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        void txt_insv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.InsvCalculation();
            }
            catch (Exception ex)
            {

            }
        }
        void txt_grms_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.InsvCalculation();
            }
            catch (Exception ex)
            {

            }
        }
        void AF_002_SaveAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.DoSave();
            }
            catch (Exception ex)
            {

            }
        }
        void AF_002_SaveBeforeClick(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidData())
                {
                    this.CancelProcess = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
        void AF_002_ClearAfterClick(object sender, EventArgs e)
        {
            try
            {
                this.DoClear();
            }
            catch (Exception ex)
            {

            }
        }
        void AF_002_ClearBeforeClick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //void grd_data_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
        //        {
        //            int valu = PLABS.Utils.CnvToInt(this.grd_data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        //            if (valu != 0)
        //            {
        //                int addrid = PLABS.Utils.CnvToInt(this.grd_data.Rows[e.RowIndex].Cells["txt_addr_id"].Value);
        //                this.FindLeaveDtls(addrid);
        //            }
        //        }
        //    }
        //}
        #endregion
        #region Method
        private void LoadControls()
        {
            try
            {
                string currentMonth = "";


                currentMonth = PLABS.Utils.CnvToStr(DateTime.Now.Month);

                if (PLABS.Utils.CnvToInt(currentMonth) == 1)
                {
                    this.txt_year.Text = PLABS.Utils.CnvToStr(DateTime.Now.Year - 1);
                }
                else
                {
                    this.txt_year.Text = PLABS.Utils.CnvToStr(DateTime.Now.Year);
                }
                this.LoadCombo();
               
            }
            catch (Exception ex)
            {
 
            }
        }
        private void LoadCombo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");


                dt.Rows.Add(1, "January");
                dt.Rows.Add(2, "February");
                dt.Rows.Add(3, "March");
                dt.Rows.Add(4, "April");
                dt.Rows.Add(5, "May");
                dt.Rows.Add(6, "June");
                dt.Rows.Add(7, "July");
                dt.Rows.Add(8, "August");
                dt.Rows.Add(9, "September");
                dt.Rows.Add(10, "October");
                dt.Rows.Add(11, "November");
                dt.Rows.Add(12, "December");

                this.ddl_mnth.LoadData(dt, "name", "id");
            }
            catch (Exception ex)
            {

            }
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
                //BizObj.MA_002 objmaaddrmast = new BizObj.MA_002();
                //xmlData =  objmaaddrmast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0009");
            }
            return xmlData;
        }
        private String getSelectArgs(String as_mode)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_mnth",this.ddl_mnth .ControlValue);
                argXml = PLABS.Utils.addNode(argXml, "ai_year", this.txt_year.Text);

                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0010");
            }
            return string.Empty;
        }
        private void MnthChanged()
        {
            try
            {
                double gTtlsal=0;
                double gTtlRet=0;
                this.grd_data.ClearControl(true);
                double ttlworkdays = 0;
                string xmlData = this.getSelectArgs("LG");
                xmlData = this.CallWS(xmlData, "BizObj.AF_002,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                ttlworkdays = PLABS.Utils.CnvToDouble(PLABS.Utils.GetDataTable(ds, 2).Rows[0]["cnt"]);
                this.LoadGrid(dt, ttlworkdays);
                this.stat = PLABS.Utils.GetDataTable(ds, 4).Rows[0]["stat"].ToString();
               // this.txt_grms.Text = PLABS.Utils.CnvToDouble(PLABS.Utils.GetDataTable(ds, 1).Rows[0]["gm"]).ToString("F3");
                DataTable dt1 = PLABS.Utils.GetDataTable(ds, 1);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (PLABS.Utils.CnvToDouble(dt1.Rows[i]["pw"]) > 0)
                    {
                        gTtlsal += PLABS.Utils.CnvToDouble(dt1.Rows[i]["pw"]);
                    }

                    if (PLABS.Utils.CnvToDouble(dt1.Rows[i]["pw"]) < 0)
                    {
                        gTtlRet += (PLABS.Utils.CnvToDouble(dt1.Rows[i]["pw"])) * -1;
                    }
                    
                }
                this.lbl_wrkdays.ClearControl(true);
                this.lbl_wrkdays.Text = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 2).Rows[0]["cnt"]);
                this.txt_grms.ControlValue =( gTtlsal - gTtlRet).ToString("F3");
              
                _isPost = PLABS.Utils.CnvToInt(PLABS.Utils.GetDataTable(ds, 3).Rows[0]["post"]);
               
                
            }
            catch (Exception ex)
            {
 
            }
        }
        private void BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id",typeof(string));
            dt.Columns.Add("nam", typeof(string));
            dt.Columns.Add("slrprdy", typeof(double));
            dt.Columns.Add("lev", typeof(int));
            dt.Columns.Add("hlf", typeof(int));
            dt.Columns.Add("ot", typeof(int));
            dt.Columns.Add("alwlev", typeof(double));
            dt.Columns.Add("bp", typeof(double));
            dt.Columns.Add("bi", typeof(int));
            dt.Columns.Add("amt", typeof(double));
            dt.Columns.Add("ttl", typeof(double));
            dt.Columns.Add("dsc", typeof(double));
            dt.Columns.Add("ins", typeof(double));
            dt.Columns.Add("cut", typeof(double));
            dt.Columns.Add("join_dt", typeof(DateTime));
            dt.Columns.Add("pres", typeof(double));
            //dt.Columns.Add("advc", typeof(double));
            //dt.Columns.Add("ttlpay", typeof(double));

            this.grd_data.DataSource = dt;
        }
        private void LoadGrid(DataTable dt, double ttlworkdays)
        {
            try
            {
                double ins = 0.000;
                this.BindGrid();
                DataTable source = (DataTable)this.grd_data.DataSource;
                Double cut;
                Double ttlins;
                DataRow[]insRow=dt.Select("bi=1");
                DateTime join_dt;
                int ttlIns=insRow.Length ;
                foreach (DataRow dr in dt.Rows)
                {
                    //double advc = PLABS.Utils.CnvToDouble(dr["advc"]);
                    //double amt = PLABS.Utils.CnvToDouble(dr["amt"]);

                    DataRow newRow = source.NewRow();

                    newRow["id"] = dr["id"];
                    newRow["nam"] = dr["nam"];
                    newRow["slrprdy"] = PLABS.Utils.CnvToDouble(dr["slrprdy"]);
                    newRow["lev"] = PLABS.Utils.CnvToInt(dr["lev"]);
                    newRow["hlf"] = PLABS.Utils.CnvToInt(dr["hlf"]);
                    newRow["ot"] = PLABS.Utils.CnvToInt(dr["ot"]);
                    newRow["alwlev"] = PLABS.Utils.CnvToInt(dr["alwlev"]);
                    newRow["bp"] = PLABS.Utils.CnvToDouble(dr["bp"]);
                    newRow["bi"] = PLABS.Utils.CnvToInt(dr["bi"]);
                    newRow["amt"] = PLABS.Utils.CnvToDouble(dr["amt"]);
                    newRow["join_dt"] = PLABS.Utils.CnvToDate(dr["join_dt"]);
                    newRow["pres"] = PLABS.Utils.CnvToDouble(dr["pres"]);
                    join_dt= PLABS.Utils.CnvToDate(dr["join_dt"]);
                    if (PLABS.Utils.CnvToInt(newRow["bi"]) > 0)
                    {
                        ins = PLABS.Utils.CnvToDouble(PLABS.Utils.CnvToDouble(this.txt_insv.Text));
                    }
                    else
                    {
                        ins = 0;
                    }
                    if (ttlIns != 0)
                    {
                        newRow["dsc"] = (PLABS.Utils.CnvToDouble(this.txt_grms.Text) * ins) / ttlIns;
                    }
                    else
                    {
                        ttlIns = 1;
                        newRow["dsc"] = (PLABS.Utils.CnvToDouble(this.txt_grms.Text) * ins) / ttlIns;

                    }

                    
                    double totOt = PLABS.Utils.CnvToDouble(dr["ot"]);
                    double ttllev = PLABS.Utils.CnvToDouble(dr["lev"]) + (PLABS.Utils.CnvToDouble(dr["hlf"]) / 2);


                    if (ttllev > PLABS.Utils.CnvToDouble(dr["alwlev"]))
                    {
                        if (ttlworkdays != ttllev)
                        {
                            ttllev = ttllev - PLABS.Utils.CnvToDouble(dr["alwlev"]);

                        }
                    }
                    else
                    {
                         
                      ttllev = -(PLABS.Utils.CnvToDouble(dr["alwlev"]) - ttllev);
                       
                        
                    }
                   
                    if (ttlIns != 0)
                    {

                        if (join_dt.Month == PLABS.Utils.CnvToInt(ddl_mnth.ControlValue) && join_dt.Year == PLABS.Utils.CnvToInt(txt_year.ControlValue))
                        {
                            if (PLABS.Utils.CnvToDouble(dr["pres"]) == ttlworkdays)
                            {
                                newRow["ttl"] = PLABS.Utils.CnvToDouble(dr["bp"])
                                          - (PLABS.Utils.CnvToDouble(dr["slrprdy"]) * ttllev)
                                          + (PLABS.Utils.CnvToDouble(this.txt_grms.Text) * ins) / ttlIns
                                          + (PLABS.Utils.CnvToDouble(dr["slrprdy"]) * totOt);
                                //newRow["ttlpay"] = PLABS.Utils.CnvToDouble(newRow["ttl"]) - PLABS.Utils.CnvToDouble(newRow["advc"]);

                                ttlins = (PLABS.Utils.CnvToDouble(this.txt_grms.Text) * ins) / ttlIns;
                                newRow["ins"] = ttlins;
                            }
                            else
                            {
                               
                                //newRow["ttl"] = PLABS.Utils.CnvToDouble(dr["pres"]) * PLABS.Utils.CnvToDouble(dr["slrprdy"])  -(PLABS.Utils.CnvToDouble(dr["slrprdy"]) * ttllev);

                                newRow["ttl"] = PLABS.Utils.CnvToDouble(dr["bp"])-(((join_dt.Day-1)+ttllev)*PLABS.Utils.CnvToDouble(dr["slrprdy"]));

                            }
                        }
                        else
                        {
                             
                                newRow["ttl"] = PLABS.Utils.CnvToDouble(dr["bp"])
                                              - (PLABS.Utils.CnvToDouble(dr["slrprdy"]) * ttllev)
                                              + (PLABS.Utils.CnvToDouble(this.txt_grms.Text) * ins) / ttlIns
                                              + (PLABS.Utils.CnvToDouble(dr["slrprdy"]) * totOt);
                                //newRow["ttlpay"] = PLABS.Utils.CnvToDouble(newRow["ttl"]) - PLABS.Utils.CnvToDouble(newRow["advc"]);

                                ttlins = (PLABS.Utils.CnvToDouble(this.txt_grms.Text) * ins) / ttlIns;
                                newRow["ins"] = ttlins;
                            
                        }
                    }
                    else
                    {
                        ttlIns = 1;
                        
                            newRow["ttl"] = PLABS.Utils.CnvToDouble(dr["bp"])
                                                                - (PLABS.Utils.CnvToDouble(dr["slrprdy"]) * ttllev)
                                                                + (PLABS.Utils.CnvToDouble(this.txt_grms.Text) * ins) / ttlIns
                                                                + (PLABS.Utils.CnvToDouble(dr["slrprdy"]) * totOt);
                            //newRow["ttlpay"] = PLABS.Utils.CnvToDouble(newRow["ttl"]) - PLABS.Utils.CnvToDouble(newRow["advc"]);

                            ttlins = (PLABS.Utils.CnvToDouble(this.txt_grms.Text) * ins) / ttlIns;
                            newRow["ins"] = ttlins;
                       
                    }


                    cut = -(PLABS.Utils.CnvToDouble(dr["slrprdy"]) * ttllev) + (PLABS.Utils.CnvToDouble(dr["slrprdy"]) * totOt);                 
                    newRow["cut"] = cut;

                  
                    
                    source.Rows.Add(newRow);
                }


                this.lbl_ttlpay.Text = PLABS.Utils.CnvToDouble(source.Compute("SUM(ttl)", "")).ToString("N0");

                if (insRow.Length > 0)
                {
                    foreach (DataRow dr in insRow)
                    {
                       
                        this.grd_data.Rows[dt.Rows.IndexOf(dr)].DefaultCellStyle.BackColor = Color.AliceBlue;
                    }
                }
               
            }
            catch (Exception ex)
            {
 
            }
        }     
        private void InsvCalculation()
        {
            try
            {
                DataTable dt = (DataTable)this.grd_data.DataSource;
                this.LoadGrid(dt, PLABS.Utils.CnvToDouble(lbl_wrkdays.ControlValue));
               
            }
            catch (Exception ex)
            {
 
            }
        }
        //private void FindLeaveDtls(int addrid)
        //{
        //    String xmlData = this.getBlankXml();
        //    xmlData = PLABS.Utils.addNodes(xmlData,this.getSelectArgs("LD"));
        //    xmlData = PLABS.Utils.addNode(xmlData, "ai_addr_id", PLABS.Utils.CnvToStr(addrid));
        //    xmlData = this.CallWS(xmlData, "BizObj.AF_002,BizObj", "L");
        //    DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
        //    RP_014 obj = new RP_014();
        //    obj.Dtlev_dtls = PLABS.Utils.GetDataTable(ds, 1);
        //    obj.getName = PLABS.Utils.GetDataTable(ds, 0).Rows[0][0].ToString();
        //    obj.ShowDialog();
        //}
        private bool IsValidData()
        {
            try
            {
                if (grd_data.Rows.Count == 0)
                {
                    PLABS.MessageBoxPL.Show("Invalid Data");
                    this.ddl_mnth.Focus();
                    return false;
                }
                else if (_isPost == 1)
                {
                    PLABS.MessageBoxPL.Show("Already Done");
                    this.ddl_mnth.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void DoSave()
        {
            try
            {
                if (this.stat == "yes")
                {
                    string xmlData = this.ProcessXml;
                    DateTime dt = new DateTime(PLABS.Utils.CnvToInt(this.txt_year.Text), PLABS.Utils.CnvToInt(this.ddl_mnth.ControlValue), 01);
                    dt = dt.AddMonths(1).AddDays(-1);
                    xmlData = PLABS.Utils.addNode(xmlData, "ad_dt", dt.ToString("yyyy-MM-dd"));

                    xmlData = this.CallWS(xmlData, "BizObj.AF_002,BizObj", "I");
                    if (xmlData.Length < 7)
                    {
                        PLABS.MessageBoxPL.Show("Saved Successfully");
                        this.grd_data.ClearControl(true);
                    }
                    else
                    {
                        PLABS.MessageBoxPL.Show(xmlData);
                    }
                }
                else
                    PLABS.MessageBoxPL.Show("Already Saved Data");
            }
            catch (Exception ex)
            {
 
            }
        }
        private void DoClear()
        {
            try
            {
                this.lbl_wrkdays.ClearControl(true);
                this.lbl_ttlpay.ClearControl(true);
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
    }
}
