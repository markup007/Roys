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
    public partial class RP_013 :  PLABS.MasterForm
    {
        #region Constructor
        public RP_013()
        {
            InitializeComponent();
             
            
            
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.ddl_mnth.SelectedIndexChanged += new EventHandler(ddl_mnth_SelectedIndexChanged);
                this.dgv_attdtls.CellDoubleClick += new DataGridViewCellEventHandler(dgv_attdtls_CellDoubleClick);
                this.dgv_attdtls.CellClick += new DataGridViewCellEventHandler(dgv_attdtls_CellClick);
                
            }
            catch(Exception ex)
            {
            }
            this.LoadControls();
            base.OnLoad(e);
        }

        

      

        
        

        
        
                 
        #endregion
        #region Events
        void ddl_mnth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (PLABS.Utils.CnvToInt(ddl_mnth.ControlValue) <= PLABS.Utils.CnvToInt(DateTime.Now.Month))
                //{
                    this.LoadGrid();
                //}
                //else
                //{
                //    PLABS.MessageBoxPL.Show("Please Select Current Or Previous Month");
                //}

            }
            catch (Exception ex)
            {
               
            }
        }
        void dgv_attdtls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    int valu = PLABS.Utils.CnvToInt(this.dgv_attdtls.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (valu != 0)
                    {
                        int addrid = PLABS.Utils.CnvToInt(this.dgv_attdtls.Rows[e.RowIndex].Cells["txt_addr_id"].Value);
                        this.FindLeaveDtls(addrid);
                    }
                }
            }
        }
        void dgv_attdtls_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                this.dgv_attdtls.Rows[e.RowIndex].Selected = true; 
            }
            catch(Exception ex)
            {
            }
        }
        #endregion 
        #region Methods
        private void LoadControls()
        {
            try
            {
                this.LoadCombo();
                this.txt_year.Text = PLABS.Utils.CnvToStr(DateTime.Now.Year);
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
        private void LoadGrid()
        {
           
            String xmlData = this.getBlankXml();
            Double totsalcut = 0;
            Double totSalIncr = 0;
            Double totsal = 0;
            DateTime join_dt;
            xmlData = PLABS.Utils.addNodes(xmlData,this.getSelectArgs("SE",this.ddl_mnth.ControlValue,this.txt_year.ControlValue));
            xmlData = this.CallWS(xmlData,"BizObj.RP_013,BizObj","S");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
          //  this.lbl_wrkdays.ClearControl(true);
            DataTable dt=PLABS.Utils.GetDataTable(ds,0);
            if (PLABS.Utils.CnvToInt(this.ddl_mnth.ControlValue) == PLABS.Utils.CnvToInt(DateTime.Now.Month))
            {

                Double cut;
                this.BindGrid();
                DataTable source = (DataTable)this.dgv_attdtls.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    double totOt = PLABS.Utils.CnvToDouble(dr["ot"]);
                    double ttllev = PLABS.Utils.CnvToDouble(dr["lev"]) + (PLABS.Utils.CnvToDouble(dr["hlf"]) / 2);
                    if (ttllev > PLABS.Utils.CnvToDouble(dr["alwlev"]))
                    {
                        ttllev = ttllev - PLABS.Utils.CnvToDouble(dr["alwlev"]);
                    }
                    else
                    {
                        ttllev = -(PLABS.Utils.CnvToDouble(dr["alwlev"]) - ttllev);
                    }
                    cut = (-(PLABS.Utils.CnvToDouble(dr["slrprdy"]) * ttllev) + (PLABS.Utils.CnvToDouble(dr["slrprdy"]) * totOt));

                    DataRow newRow = source.NewRow();
                    newRow["addr_id"] = dr["addr_id"];
                    newRow["nam"] = dr["nam"];
                    newRow["pres"] = dr["pres"];
                    newRow["lev"] = dr["lev"];
                    newRow["hlf"] = dr["hlf"];
                    newRow["ot"] = dr["ot"];
                    newRow["alwlev"] = dr["alwlev"];
                    newRow["bp"] = dr["bp"];
                    newRow["ins"] = dr["ins"];
                    newRow["cut"] = (cut) * -1;
                    if (PLABS.Utils.CnvToDouble(newRow["cut"]) > 0)
                    {
                        totsalcut = totsalcut + PLABS.Utils.CnvToDouble(newRow["cut"]);
                    }
                    else
                    {
                        totSalIncr = totSalIncr + PLABS.Utils.CnvToDouble(newRow["cut"]);
                    }
                    newRow["slrprdy"] = dr["slrprdy"];
                    newRow["adv"] = dr["adv"];
                    join_dt = PLABS.Utils.CnvToDate(dr["join_dt"]);
                    if (join_dt.Month == PLABS.Utils.CnvToInt(ddl_mnth.ControlValue) && join_dt.Year == PLABS.Utils.CnvToInt(txt_year.ControlValue))
                    {
                      // newRow["totsal"] = PLABS.Utils.CnvToDouble(dr["slrprdy"]) * PLABS.Utils.CnvToDouble(dr["pres"]) + cut + PLABS.Utils.CnvToDouble(dr["ins"]);
                        newRow["totsal"] = PLABS.Utils.CnvToDouble(dr["bp"]) + cut + PLABS.Utils.CnvToDouble(dr["ins"]);
                    }
                    else
                    {
                        newRow["totsal"] = PLABS.Utils.CnvToDouble(dr["bp"]) + cut + PLABS.Utils.CnvToDouble(dr["ins"]);
                    }
                    
                    totsal = totsal + PLABS.Utils.CnvToDouble(newRow["totsal"]);
                    newRow["join_dt"] = dr["join_dt"];
                    source.Rows.Add(newRow);
                }
                this.dgv_attdtls.DataSource = source;

            }
            else
            {
                int i = 0;
                dt.Columns.Add("alwlev");
                foreach (DataRow dr in dt.Rows)
                {
                    dr["cut"] = PLABS.Utils.CnvToDouble(dr["cut"]) * -1;
                    dt.Rows[i]["cut"] = dr["cut"];
                    totsal = totsal + PLABS.Utils.CnvToDouble(dr["totsal"]);
                    if (PLABS.Utils.CnvToDouble(dr["cut"]) > 0)
                    {
                        totsalcut = totsalcut + PLABS.Utils.CnvToDouble(dr["cut"]);
                    }
                    else
                    {
                        totSalIncr = totSalIncr + PLABS.Utils.CnvToDouble(dr["cut"]);
                    }
                    i++;
                }
               
                this.dgv_attdtls.DataSource = dt;
            }
            this.lbl_totsal_paid.ControlValue = (totsal).ToString("F2");
            this.lbl_totsalcut.ControlValue = totsalcut.ToString("F2");
            this.lbl_ttlIncr.ControlValue = totSalIncr.ToString("F2");
            //if (PLABS.Utils.GetDataTable(ds, 1).Rows.Count>0)
            //    {
            //   // this.lbl_wrkdays.ControlValue = PLABS.Utils.CnvToStr(PLABS.Utils.GetDataTable(ds, 1).Rows[0]["cnt"]);
            //    }
            
           

        }
        private void BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("addr_id",typeof(int));
            dt.Columns.Add("nam", typeof(string));
            dt.Columns.Add("pres", typeof(double));
            dt.Columns.Add("lev", typeof(int));
            dt.Columns.Add("hlf", typeof(int));
            dt.Columns.Add("ot", typeof(int));
            dt.Columns.Add("alwlev", typeof(double));
            dt.Columns.Add("bp", typeof(double));
            dt.Columns.Add("ins", typeof(double));
            dt.Columns.Add("cut", typeof(double));
            dt.Columns.Add("slrprdy", typeof(double));
            dt.Columns.Add("adv", typeof(double));
            dt.Columns.Add("totsal", typeof(double));
            dt.Columns.Add("join_dt", typeof(DateTime));
           this.dgv_attdtls.DataSource = dt;
        }
        private void FindLeaveDtls(int addrid)
        {
            String xmlData = this.getBlankXml();
            xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LD",this.ddl_mnth.ControlValue,this.txt_year.ControlValue));
            xmlData = PLABS.Utils.addNode(xmlData, "ai_addr_id", PLABS.Utils.CnvToStr(addrid));
            xmlData = this.CallWS(xmlData, "BizObj.AF_002,BizObj", "L");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            RP_014 obj = new RP_014();
            obj.Dtlev_dtls = PLABS.Utils.GetDataTable(ds, 1);
            obj.getName = PLABS.Utils.GetDataTable(ds, 0).Rows[0][0].ToString();
            obj.ShowDialog();
        }
        private String getSelectArgs(String as_mode, String ai_mnth, String ai_year)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_mnth", ai_mnth );
                argXml = PLABS.Utils.addNode(argXml, "ai_year", ai_year);
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
      
        #endregion
    }
}
