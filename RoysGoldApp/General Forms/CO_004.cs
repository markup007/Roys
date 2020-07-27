using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoysGold
{
    public partial class CO_004 : PLABS.MasterForm
    {
        #region global variable

        String[] _parameters = new String[3];
        DataTable _rpt = new DataTable();
        double _wt = 0;
        double _tch = 0;
        string _rptType = string.Empty;
        Font _printFont;
        string _printData = string.Empty;
        #endregion

        #region properties

        public String[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        #endregion

        #region Contructor

        public CO_004()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.loadControls();
            if (Parameters[0] == "S")
            {
                txt_touch_gv.HeaderText = "Stone Wt";
                grd_data.Refresh();
            }
            this.btn_exit.Click+=new EventHandler(btn_exit_Click);
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.grd_data.KeyDown += new KeyEventHandler(grd_data_KeyDown);
            this.grd_data.CellDoubleClick += new DataGridViewCellEventHandler(grd_data_CellDoubleClick);
            this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
           

        }

       
        #endregion

        #region events

        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      void btn_print_Click(object sender,EventArgs e)
        {
            print();

        }
        void grd_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.GotoWeightLedger(e.RowIndex);
            }
            catch (Exception ex)
            {
 
            }
        }
        void grd_data_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GotoWeightLedger(this.grd_data.CurrentRow.Index);
                }
            }
            catch
            {

            }

        }
        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Methods

        private void loadControls()
        {
            try
            {
                 double ttlnw=0.000;
                 double ttldft=0.000;
                DataSet ds = this.GetDataSet(Parameters[0], Parameters[1], Parameters[2]);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                this.grd_data.DataSource = dt;
                this._rpt = dt;
                this._rptType = Parameters[0];
                if (dt.Columns["nw"].DataType.Name == "Double")
                {
                    ttlnw = PLABS.Utils.CnvToDouble(dt.Compute("SUM(nw)", ""));
                }
                if (dt.Columns["dft"].DataType.Name == "Double")
                {
                    ttldft = PLABS.Utils.CnvToDouble(dt.Compute("SUM(dft)", ""));
                }

                DataRow dr = dt.NewRow();
                dr["itm"] = "TOTAL";
                dr["nw"] = ttlnw;
                dr["dft"] = ttldft;
                _wt = ttlnw;
                _tch = ttldft;
                dt.Rows.Add(dr);

                this.grd_data.Rows[dt.Rows.Count - 1].DefaultCellStyle.BackColor = Color.AliceBlue;
                this.grd_data.Rows[dt.Rows.Count - 1].DefaultCellStyle.Font = new Font("Ariel", 10, FontStyle.Bold);
            
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private DataSet GetDataSet(String as_mode, String ai_frm, String ai_to)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ai_frm, ai_to));
                xmlData = this.CallWS(xmlData, "BizObj.CO_004,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private String getSelectArgs(String as_mode, String ai_frm, String ai_to)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_frm", ai_frm);
                argXml = PLABS.Utils.addNode(argXml, "ai_to", ai_to);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id","");
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
                //BizObj.CO_004 obj = new BizObj.CO_004();
                //xmlData = obj.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return xmlData;
        }
        private void GotoWeightLedger(int rowNum)
        {
            try
            {
                if (Parameters[0] == "3" || Parameters[0] == "4" || Parameters[0] == "M" ||Parameters[0]=="S"|| Parameters[0] == "D" || Parameters[0] == "CM")
                {
                    FL_002 obj = new FL_002();
                    obj.IdFromFL_003 = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_id_gv"].Value);
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        public void print()
        {

            int len = 90;

            RptControl.RptTextCntrl objRptTextCntr = new RptControl.RptTextCntrl();


            objRptTextCntr.GF_AddNewLine(1);
            string Report =string.Empty;
            if (_rptType == "4")
                Report = "SALES";
            if (_rptType == "3")
                Report = "PURCHASE";
            objRptTextCntr.Gf_DrawText(Report, RptControl.TextAlign.Center, len, false);

            objRptTextCntr.GF_AddNewLine(1);
            objRptTextCntr.GF_DrawLine(len);



            objRptTextCntr.Gf_AddSeperator();
            objRptTextCntr.Gf_DrawText("DATE", RptControl.TextAlign.Center, 9, true);
            objRptTextCntr.Gf_DrawText("NAME", RptControl.TextAlign.Center, 14, true);
            objRptTextCntr.Gf_DrawText("ITEM", RptControl.TextAlign.Center, 15, true);
            objRptTextCntr.Gf_DrawText("WEIGHT", RptControl.TextAlign.Center, 9, true);
            objRptTextCntr.Gf_DrawText("TOUCH", RptControl.TextAlign.Center, 9, true);
            objRptTextCntr.Gf_DrawText("DESCRIPTION", RptControl.TextAlign.Center, 34, true);
            objRptTextCntr.GF_AddNewLine(1);
            objRptTextCntr.GF_DrawLine(len);

            for (int i = 0; i < _rpt.Rows.Count-1; i++)
            {

                
                objRptTextCntr.Gf_AddSeperator();
                objRptTextCntr.Gf_DrawText(_rpt.Rows[i]["dt"], RptControl.TextAlign.Left, 9, true);
                objRptTextCntr.Gf_DrawText(_rpt.Rows[i]["nam"], RptControl.TextAlign.Left, 14, true);
                objRptTextCntr.Gf_DrawText(_rpt.Rows[i]["itm"], RptControl.TextAlign.Left, 15, true);
                objRptTextCntr.Gf_DrawText(_rpt.Rows[i]["nw"], RptControl.TextAlign.Right, 9, true, "F3");
                objRptTextCntr.Gf_DrawText(_rpt.Rows[i]["dft"], RptControl.TextAlign.Right, 9, true, "F3");
                objRptTextCntr.Gf_DrawText(_rpt.Rows[i]["dsc"], RptControl.TextAlign.Left, 34, true);
                objRptTextCntr.GF_AddNewLine(1);

            }
            objRptTextCntr.GF_DrawLine(len);
            objRptTextCntr.Gf_AddSeperator();
            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Center, 9, true);
            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 14, true);
            objRptTextCntr.Gf_DrawText("TOTAL", RptControl.TextAlign.Right, 15, true);
            objRptTextCntr.Gf_DrawText(_wt, RptControl.TextAlign.Right, 9, true, "F3");
            objRptTextCntr.Gf_DrawText(_tch, RptControl.TextAlign.Right, 9, true, "F3");
            objRptTextCntr.Gf_DrawText("", RptControl.TextAlign.Left, 34, true);
            objRptTextCntr.GF_AddNewLine(1);
            objRptTextCntr.GF_DrawLine(len);


             _printData = objRptTextCntr.GF_GetPrintString();
             this.GetPrinters();
           

        }
        private void GetPrinters()
        {

            _printFont = new Font("lucida console", 10);
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
            pd.Print();
        }
        void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(_printData, _printFont, Brushes.Black, 1, 10);
        }

        #endregion
    }
}
