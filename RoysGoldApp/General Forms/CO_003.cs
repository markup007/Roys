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
    public partial class CO_003 : PLABS .MasterForm
    {
        #region Global Variables
        string _headDesc = "";
        #endregion
        #region Properties
        public string HeadDesc
        {
            set { _headDesc = value; }
            get { return _headDesc; }
        }
        #endregion
        #region Constructor
        public CO_003()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.loadControls();
            this.btn_ok.Click += new EventHandler(btn_ok_Click);
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.txt_name.KeyDown += new KeyEventHandler(txt_name_KeyDown);
            this.lst_search.KeyDown += new KeyEventHandler(lst_search_KeyDown);
            base.OnLoad(e);
        }

        void lst_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        protected override void OnClosing(CancelEventArgs e)
            {
            try
            {
                HeadDesc = this.txt_name.Text.Trim();
                //this.Close();
            }
            catch (Exception ex)
            {

            }
            base.OnClosing(e);
        }
        #endregion
        #region Events
        void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
 
            }
        }
        void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                HeadDesc = this.txt_name.Text.Trim();
                this.Close();
            }
            catch (Exception ex)
            {
 
            }
        }
        void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.loadGrid();
                    this.lst_search.Focus();
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
        #region Methods
        private void loadControls()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, this.getSelectArgs("LO",""));
                xmlData = this.CallWS(xmlData, "BizObj.CO_003,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                Utils.GetAutoCompleteSource(ds.Tables[0], txt_name);
                if (HeadDesc != string.Empty)
                {
                    this.txt_name.Text = HeadDesc;
                    this.lst_search.Focus();
                    this.loadGrid();
                }
                
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0002");
            }
        }
        private void loadGrid()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG", this.txt_name.Text));
                xmlData = CallWS(xmlData, "BizObj.CO_003,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                DataTable source = this.FormatTable (PLABS.Utils.GetDataTable(ds, 0));
                double ttlAmt = 0.00;
              
                foreach (DataRow dr in source.Rows)
                {
                    if (PLABS .Utils .CnvToDouble(dr["dr_amount"]) <= 0)
                    {
                        dr["dr_amount"] = DBNull.Value;
                    }
                    if (PLABS.Utils.CnvToDouble(dr["cr_amount"]) <= 0)
                    {
                        dr["cr_amount"] = DBNull.Value;
                    }
                }
                this.lst_search.LoadData(source);
                if (source.Rows.Count != 0)
                {
                    double ttlDr = PLABS.Utils.CnvToDouble(source.Compute("SUM(dr_amount)", ""));
                    double ttlCr = PLABS.Utils.CnvToDouble(source.Compute("SUM(cr_amount)", ""));
                    ttlAmt = ttlDr - ttlCr;
                    this.lbl_clsng.Text = ttlAmt.ToString("N2");
                    if (ttlAmt == 0)
                    {
                        if (PLABS.MessageBoxPL.Show("Closing Is Zero Do You Want To Delete", "Information", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Information) == PLABS.MessageBoxPL.PLDialogResults.Yes)
                        {
                            string xml = this.getBlankXml();
                            xml = PLABS.Utils.addNode(xml, "as_head_desc", this.txt_name.Text.Trim());
                            xml = this.CallWS(xml, "BizObj.CO_003,BizObj", "D");
                            this.lst_search.Items.Clear();
                            this.loadControls();
                        }
                    }
                }
                //DataRow dr1 = source.NewRow();
                //DataRow nullRow = source.NewRow();
                //dr1["nar"] = "TOTAL";
                //if (ttlAmt > 0)
                //{
                //    dr1["dr_amount"] = ttlAmt.ToString("N3");
                //}
                //else if (ttlAmt<0)
                //{
                //    dr1["cr_amount"] = (-1*ttlAmt).ToString("N3");
                //}
                //source.Rows.Add(nullRow);
                //source.Rows.Add(dr1);
                

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0003");
            }
        }
        private String getSelectArgs(String as_mode, String as_head_desc)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "as_head_desc", as_head_desc);
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0010");
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
                //BizObj.CO_003 objmaitemgrpmast = new BizObj.CO_003();
                //xmlData = objmaitemgrpmast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrgrup", "0009");
            }
            return xmlData;
        }
        private DataTable FormatTable(DataTable dt)
        {
            DataTable newTable = new DataTable();
            try 
            {
                DataTable source = new DataTable();
                source.Columns.Add("date", typeof(string));
                source.Columns.Add("nar", typeof(string));
                source.Columns.Add("dr_amount", typeof(double));
                source.Columns.Add("cr_amount", typeof(double));

                foreach (DataRow dr in dt.Rows)
                {
                    DataRow newRow = source.NewRow();
                    newRow["date"] = dr["date"];
                    newRow["nar"] = dr["nar"];
                    newRow["dr_amount"] = dr["dr_amount"];
                    newRow["cr_amount"] = dr["cr_amount"];
                    source.Rows.Add(newRow);
                    
                }
                return source;
            }
            catch (Exception ex)
            {
 
            }
            return newTable;
        }
        #endregion
    }
}
