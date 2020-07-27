using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RoysGold
{
    public partial class CO_002 : PLABS.MasterForm
    {
        #region global variable
        String[] _parameters = new String[5];
        String _xml = String.Empty;
        #endregion
        #region properties

        public String[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public String Xml
        {
            get { return _xml; }
            set { _xml = value; }
        }

        #endregion
        #region constructor
        public CO_002()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.loadControls();
            this.btn_ok.Click += new EventHandler(btn_ok_Click);
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            this.grd_data.CellDoubleClick += new DataGridViewCellEventHandler(grd_data_CellDoubleClick);
            this.grd_data.KeyDown += new KeyEventHandler(grd_data_KeyDown);
            this.grd_data.DataError += new DataGridViewDataErrorEventHandler(grd_data_DataError);
            this.grd_data.CellClick += new DataGridViewCellEventHandler(grd_data_CellClick);

            base.OnLoad(e);
        }

        
       
        #endregion
        #region events

        void grd_data_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GotoWeightLedger(this.grd_data.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {

            }
        }

        void grd_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.GotoWeightLedger(e.RowIndex);
            }
            catch
            {
            }
        }
        void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btn_ok_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = (DataTable)this.grd_data.DataSource;
                dt.DefaultView.RowFilter = "chkd='1'";
                dt = dt.DefaultView.ToTable();
                dt = dt.DefaultView.ToTable(true, new string[] { "ID", "DETID", "VID","DESCRIPTION" });
                if (dt.Rows.Count != 0)
                {
                    Xml = this.DatatableToXml(dt);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                this.Close();
            }
        }
        void grd_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               string colName= this.grd_data.Columns[e.ColumnIndex].Name;
               if (colName == "btn_edit_gv")
               {
                   this.GridCellClick(e.RowIndex);
               }
            }
            catch (Exception ex)
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
                
               
                //string xmlData = this.getBlankXml();
                DataSet ds = this.GetDataSet(Parameters[0], Parameters[1], Parameters[2]);
                if (ds.Tables.Count != 0)
                {
                    DataTable dt = ds.Tables[0];
                    this.grd_data.DataSource = dt;
                    switch (PLABS.Utils.CnvToInt(dt.Rows[0]["VID"]))
                    {
                        case 1:
                            this.Text = "SMITH ISSUE";
                            break;
                        case 2:
                            this.Text = "SMITH RECEIPT";
                            break;
                        case 3:
                            this.Text = "RAW PURCHASE";
                            break;
                        case 4:
                            this.Text = "SALE";
                            break ;
                    }
                }




                this.grd_data.Columns["NAME"].ReadOnly = true;
                this.grd_data.Columns["itm_name"].ReadOnly = true;
                this.grd_data.Columns["weight"].ReadOnly = true;
                this.grd_data.Columns["mc"].ReadOnly = true;
                this.grd_data.Columns["mcrate"].ReadOnly = true;

                this.grd_data.Columns["ID"].Visible = false;
                this.grd_data.Columns["DETID"].Visible = false;
                this.grd_data.Columns["VID"].Visible = false;
                if (Properties.Settings.Default.id != 4)
                {
                    this.grd_data.Columns["btn_edit_gv"].Visible = false;
                }
               

                for (int i = 0; i < this.grd_data.Columns.Count; i++)
                {
                    this.grd_data.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                this.grd_data.Columns["chk_select_gv"].Width = 50;
                this.grd_data.Columns["btn_edit_gv"].Width = 100;
                if(Parameters[4]=="S")
                {
                    for (int j = 0; j < this.grd_data.Rows.Count; j++)
                    {
                        this.grd_data.Rows[j].Cells["chk_select_gv"].Value = 0;
                    }
                }

                if (Parameters[3] != string.Empty)
                {
                    
                    string xml = Parameters[3];
                    DataTable source = (DataTable)grd_data.DataSource;

                    XmlDocument Xml = new XmlDocument();
                    Xml.LoadXml(xml); // suppose that myXmlString contains "<Names>...</Names>"

                    XmlNodeList xnList = Xml.SelectNodes("/ResultDS/Rslt");
                    foreach (XmlNode xn in xnList)
                    {
                        string detId = xn["DETID"].InnerText;
                        DataRow[] dr = source.Select("DETID='" + detId + "'");
                        DataRow row = dr[0];
                         row["chkd"] = "1";
                         row["DESCRIPTION"] = xn["DESCRIPTION"].InnerText;
                        //row["Sid"]=
                        
                    }

                    //DataTable tableId = PLABS.Utils.CnvXmlToDataTable(xml);
                    //DataTable source = (DataTable)grd_data.DataSource;
                    //for (int i = 0; i < tableId.Rows.Count; i++)
                    //{
                    //    string id = PLABS.Utils.CnvToStr(tableId.Rows[i]["DETID"]);
                    //    DataRow[] dr = source.Select("DETID='" + id + "'");
                    //    DataRow row = dr[i];
                    //    row["chk"] = "1";


                    //}
                   
                }

            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0002");
            }
        }

        private void loadGrid()
        {
            try
            {
                string xmlData = this.getBlankXml();
                //xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs("LG", txt_code_F.ControlValue, ddl_group_F.ControlValue, "", txt_name_F.ControlValue));
                xmlData = this.CallWS(xmlData, "BizObj.CO_002,BizObj", "S");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                // lst_search.LoadData(PLABS.Utils.GetDataTable(ds, 0));
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0003");
            }
        }

        private void doFind(String PrimaryKeyID)
        {
            try
            {
                //this.btn_saveas.Enabled = true;
                this.FindID = PrimaryKeyID;
                this.CancelProcess = false;
                if (this.ValueChangedStatus)
                {
                    if (PLABS.MessageBoxPL.Show("Values are changed Do You Want To Save?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Question) == PLABS.MessageBoxPL.PLDialogResults.Yes)
                        this.DoSave(this);
                    else
                    {
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                    }
                }
                if (!this.CancelProcess)
                {

                    DataSet ds = this.GetDataSet("", "", "");
                    DataTable dt = ds.Tables[0];
                    //this.grd_data.DataSource = ds.Tables[1];

                    //ddl_fa_status.SelectedIndex = PLABS.Utils.CnvToInt(dt.Rows[0]["fa_status"]);

                    this.ValueChangedStatus = false;
                    //this.txt_code.Focus();
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message,"maaddrmast", "0004");
            }
        }

        private void doSave()
        {
            try
            {
                string xmlData = this.ProcessXml;
                xmlData = this.CallWS(xmlData, "BizObj.CO_002,BizObj", "I");
                if (xmlData == "-1")
                {
                    PLABS.MessageBoxPL.PLDialogResults obj = PLABS.MessageBoxPL.Show("Your loaded Values are Changed, Do You really Want to reload it?", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.YesNo, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                    if (obj == PLABS.MessageBoxPL.PLDialogResults.Yes)
                    {
                        //String Key = this.masterKey;
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                        //doFind(Key);
                        this.loadGrid();
                        this.CancelProcess = true;
                    }
                    else
                    {
                        this.loadGrid();
                        this.ValueChangedStatus = false;
                        this.DoClear(this);
                        this.CancelProcess = true;
                    }
                }
                else if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Successfully Saved", "Alert",PLABS. MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.loadGrid();
                    this.doClear();
                    //this.txt_code.Focus();
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0005");
            }
        }

        private void doDelete()
        {
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNode(xmlData, "ai_addr_id", this.FindID);
                xmlData = this.CallWS(xmlData, "BizObj.CO_002,BizObj", "D");
                if (xmlData.Length < 7)
                {
                    //PLABS.MessageBoxPL.Show("Deleted Successfully", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Information);
                    this.loadGrid();
                    this.doClear();
                }
                else
                {
                    this.CancelProcess = true;
                    PLABS.MessageBoxPL.Show(xmlData, "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0006");
            }
        }

        private void doClear()
        {
            try
            {

                //this.btn_saveas.Enabled = false;
                //this.txt_amount.Focus();
                this.ValueChangedStatus = false;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0007");
            }
        }

        private void doFClear()
        {
        }

        private bool isValidData()
        {
            return true;
        }

        private String getSelectArgs(String as_mode, String ad_date, String ai_grp)
        {
            try
            {
                String argXml = this.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ad_date", ad_date);
                argXml = PLABS.Utils.addNode(argXml, "ai_grp", ai_grp);


                return argXml;
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0010");
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
                //BizObj.CO_002 objmaaddrmast = new BizObj.CO_002();
                //xmlData = objmaaddrmast.GetData(Xml, ClassName, Mode);
            }
            catch (Exception ex)
            {
                //ErrorLog.Insert(ex.Message, "maaddrmast", "0009");
            }
            return xmlData;
        }



        public DataSet GetDataSet(String as_mode, String ad_date, String ai_grp)
        {
            DataSet ds = new DataSet();
            try
            {
                string xmlData = this.getBlankXml();
                xmlData = PLABS.Utils.addNodes(xmlData, getSelectArgs(as_mode, ad_date, ai_grp));
                xmlData = this.CallWS(xmlData, "BizObj.CO_002,BizObj", "S");
                ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                return ds;
            }
            catch (Exception ex)
            {
            }
            return ds;
        }



        private string DatatableToXml(DataTable dt)
        {
           
            
            
            dt.TableName = "Rslt";
            DataSet ds = new DataSet("ResultDS");
           
            ds.Tables.Add(dt);
            string s = PLABS.Utils.CnvDataTableToXml(dt,false);
           
            
            ds.Tables.Remove(dt);
            return s;
            
        }


        private void GotoWeightLedger(int rowNum)
        {
            try
            {
               
                String id = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["txt_ssid_gv"].Value);
                String dtId = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["DETID"].Value);
                FL_002 obj = new FL_002();
                obj.IdFromFL_003 = id;
                obj.DtId = dtId;
                obj.Lege_Date =Parameters[1];
                obj.ShowDialog();


            } 
            catch (Exception ex)
            {

            }
        }
        private void GridCellClick(int rowNum)
        {
            try
            {
                string vouId = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["vid"].Value);
                string findId = PLABS.Utils.CnvToStr(this.grd_data.Rows[rowNum].Cells["id"].Value);
                
                if(vouId=="1" ||vouId =="12")
                {
                  TS_001 obj = new TS_001();
                  obj.FindID = findId;
                  obj.ShowDialog();
                }
                if (vouId == "2" || vouId == "11")
                {
                    TR_004 obj = new TR_004();
                    obj.FindID = findId;
                    obj.ShowDialog();
                }
                if (vouId == "3" || vouId == "8" || vouId == "10" || vouId == "13")
                {
                    TP_003 obj = new TP_003();
                    obj.FindID = findId;
                    obj.ShowDialog();
                }
                if (vouId == "4" || vouId == "9")
                {
                    TS_002 obj = new TS_002();
                    obj.FindID = findId;
                    obj.ShowDialog();
                }
                
                
               
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
    }
}
