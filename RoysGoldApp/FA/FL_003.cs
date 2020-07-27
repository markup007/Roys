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
    public partial class FL_003 : PLABS.MasterForm
    {
        #region Global Variables
        #endregion
        #region Properties
        #endregion
        #region Constructors
        public FL_003()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.LoadControls();

            this.fnd_addr_grp.AfterFind += new EventHandler(fnd_address_AfterFind);
            this.fnd_addr_id.AfterFind += new EventHandler(fnd_addr_id_AfterFind);
            this.grd_data.CellDoubleClick += new DataGridViewCellEventHandler(grd_data_CellDoubleClick);
            this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
            this.grd_data.KeyDown += new KeyEventHandler(grd_data_KeyDown);
            this.btn_refresh.Click += new EventHandler(btn_refresh_Click);
            this.grd_data.CellEnter += new DataGridViewCellEventHandler(grd_data_CellEnter);
            base.OnLoad(e);
        }

       
        #endregion
        #region Events
        void  fnd_address_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
                //this.grd_data.Focus();
            }
            catch (Exception ex)
            {

            }
        }
        void fnd_addr_id_AfterFind(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrid();
                this.grd_data.Focus();
            }
            catch (Exception ex)
            {

            }
        }
        void btn_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Refresh();
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

                    this.CellEnterForPopUp(grd_data.CurrentRow.Index);

                }
            }
            catch (Exception ex)
            {

            }
        }
        void grd_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        void grd_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.CellEnterForPopUp(e.RowIndex);
            }
            catch
            {

            }
        }
        void grd_data_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.CellEnter();
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
                //this.dtp_to.ControlValue = DateTime.Now.ToString("MMM-dd-yyyy");
                DataSet ds = this.GetDataSet("LO", "","");

                this.fnd_addr_grp.LoadData(PLABS.Utils.GetDataTable(ds,0), "cd", "nam", "id");
                this.fnd_addr_id.LoadData(PLABS.Utils.GetDataTable(ds,1), "cd", "nam", "id");
                this.PopulateGrid();
                //this.LoadGrid();

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0002");
            }
        }
        public void LoadGrid()
        {
            try
            {

                this.PopulateGrid();

            }
            catch (Exception ex)
            {

            }
        }
        private DataSet GetDataSet(String as_mode, String ai_grp_id,String ai_addr_id)
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS .Utils .addNode(xmlData,"as_mode",as_mode);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_grp_id", ai_grp_id);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_addr_id", ai_addr_id);
                xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id",Properties .Settings .Default .id.ToString ());
                xmlData = this.CallWS(xmlData, "BizObj.FL_003,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {

            }
            DataSet ret = new DataSet();
            return ret;
        }
        private String getSelectArgs(String as_mode, String ai_addr_id,String ad_to)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                argXml = PLABS.Utils.addNode(argXml, "ad_to", ad_to);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id",Properties .Settings.Default.id.ToString());
                // argXml = PLABS.Utils.addNode(argXml, "ad_from", ad_from);
                //argXml = PLABS.Utils.addNode(argXml, "ad_to", ad_to);
                //argXml = PLABS.Utils.addNode(argXml, "ai_shop_id", ai_shop_id);
                //argXml = PLABS.Utils.addNode(argXml, "ai_wt", ai_wt);
                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0010");
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
                //BizObj.FL_003 obj = new BizObj.FL_003();
                //xmlData = obj.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "trsales", "0009");
            }
            return xmlData;
        }
        private void BindGrid()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("wt", typeof(double));
            dt.Columns.Add("isswt", typeof(double));
            dt.Columns.Add("recwt", typeof(double));
            //dt.Columns.Add("bal", typeof(double));
            //dt.Columns.Add("mc", typeof(double));
            //dt.Columns.Add("mcrt", typeof(double));
            dt.Columns.Add("dr", typeof(double));
            dt.Columns.Add("cr", typeof(double));
            dt.Columns.Add("desc", typeof(string));


            this.grd_data.DataSource = dt;
        }
        private void PopulateGrid()
        {
            try
            {
              
                this.BindGrid();
                DataSet ds = this.GetDataSet("",this.fnd_addr_grp .ControlValue,this.fnd_addr_id .ControlValue);
                DataTable mast=PLABS.Utils .GetDataTable (ds,0);
                DataTable dt = (DataTable)this.grd_data.DataSource;
                foreach (DataRow dr in mast.Rows)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["id"] = dr["id"];
                    newRow["name"] = dr["nam"];
                    if(PLABS.Utils.CnvToDouble(dr["wgt"]) > 0)
                    {
                        newRow["isswt"] = PLABS.Utils.CnvToDouble(dr["wgt"]);
                    }
                    else if (PLABS.Utils.CnvToDouble(dr["wgt"]) < 0)
                    {
                        newRow["recwt"] = -1*PLABS.Utils.CnvToDouble(dr["wgt"]);
                    }
                    if (PLABS.Utils.CnvToDouble(dr["amt"]) > 0)
                    {
                        newRow["dr"] = PLABS.Utils.CnvToDouble(dr["amt"]);
                    }
                    else if (PLABS.Utils.CnvToDouble(dr["amt"]) < 0)
                    {
                        newRow["cr"] = -1*PLABS.Utils.CnvToDouble(dr["amt"]);
                    }
                        dt.Rows.Add(newRow);
                }
                this.RemoveZeros();
                this.GridTotal();
                int rowCount=this.grd_data.Rows.Count ;
                this.grd_data.Rows[rowCount-1].DefaultCellStyle.BackColor = Color.AliceBlue;
                this.grd_data.Rows[rowCount-1].DefaultCellStyle.Font = new Font("Ariel", 12, FontStyle.Bold);
       
            }
            catch (Exception ex)
            {
            }
        }
        private void CellEnterForPopUp(int rowNum)
        {
            try
            {
                String id = PLABS .Utils .CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_id_gv"].Value);
                FL_002 obj = new FL_002();
                obj.IdFromFL_003 = id;
                obj.ShowDialog();

            }
            catch
            {
 
            }
        }
        private void RemoveZeros()
        {
            try
            {
                DataTable dt = (DataTable)grd_data.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string colName = dt.Columns[j].ColumnName;
                        if (colName == "wt" || colName == "isswt" || colName == "recwt" || colName == "dr" || colName == "cr")
                        {
                            if (PLABS.Utils.CnvToDouble(dt.Rows[i][j]) == 0)
                            {
                                dt.Rows[i][j] = DBNull.Value;
                            }
                        }
                    }
                }
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
                double isswt = PLABS.Utils.CnvToDouble(dt.Compute("SUM(isswt)", ""));
                double recwt = PLABS.Utils.CnvToDouble(dt.Compute("SUM(recwt)", ""));
                double reciept = PLABS.Utils.CnvToDouble(dt.Compute("SUM(cr)", ""));
                double payment  = PLABS.Utils.CnvToDouble(dt.Compute("SUM(dr)", ""));
                DataRow d = dt.NewRow();
                dt.Rows.Add(d);
                DataRow dr = dt.NewRow();
                DataRow dr1 = dt.NewRow();

                dr["name"] = "TOTAL";
                if (isswt > 0)
                {
                    dr["isswt"] = isswt;
                }
                if (recwt > 0)
                {
                    dr["recwt"] = recwt;
                }
                if (payment > 0)
                {
                    dr["dr"] = payment;
                }
                if (reciept > 0)
                {
                    dr["cr"] = reciept;
                }

                dt.Rows.Add(dr);


                dr1["name"] = "BALANCE";


                dr1["recwt"] = isswt - recwt;

                dr1["cr"] = payment - reciept;
              
                dt.Rows.Add(dr1);

            }
            catch (Exception ex)
            {
 
            }
        }
        private void Refresh()
        {
            try
            {
                this.fnd_addr_grp.ClearControl(true);
                this.fnd_addr_id.ClearControl(true);
                this.LoadGrid();
            }
            catch (Exception ex)
            {
 
            }
        }
        private void CellEnter()
        {
            try
            {
                double payment = PLABS.Utils.CnvToDouble(this.grd_data.CurrentRow.Cells["txt_cramt"].Value);
                double receipt = PLABS.Utils.CnvToDouble(this.grd_data.CurrentRow.Cells["txt_dramt_gv"].Value);

                CnvToCurncy obj = new CnvToCurncy();

                this.lbl_amtwrd.Text=obj.get (Math.Abs(payment-receipt));
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
    }
}
