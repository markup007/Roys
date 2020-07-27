using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace RoysGold
{
    public partial class GL_006 : PLABS.MasterForm
    {
        #region Global Variables
        string _nam = string.Empty;
        #endregion
        #region Properties
        public  string Nam
        {
            set { _nam = value; }
            get { return _nam; }
        }
        #endregion
        #region Constructors
        public GL_006()
        {
            InitializeComponent();
            

        }
        protected override void OnLoad(EventArgs e)
        {
            this.Opacity = .60;
            this.btn_login.Click += new EventHandler(btn_login_Click);
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            base.OnLoad(e);
        }
        #endregion
        #region Events
        void btn_exit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.id = 0;
            ActiveForm.Close();
        }
        void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                this.Login();
            }
            catch (Exception ex)
            {
 
            }
        }
        #endregion
        #region Methods
        private void Login()
        {
            try
            {   
                string xmlData = this.getBlankXml();
                String File_C_Drive = File.ReadAllText("C:\\Windows\\wsxtyru");
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(this.txt_paswd.Text.Trim());
                
                string PassWord = string.Empty;

                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    PassWord += bytes[i].ToString();
                }

                xmlData = PLABS.Utils.addNode(xmlData, "as_usr_nam", this.txt_usrnam.Text.Trim());
                xmlData = PLABS.Utils.addNode(xmlData, "as_pswd", PassWord);
                xmlData = PLABS.Utils.addNode(xmlData, "as_mac", this.GetMacAddress());
                xmlData = PLABS.Utils.addNode(xmlData, "as_pcnam", Environment.MachineName);
                xmlData = PLABS.Utils.addNode(xmlData, "as_login_chk", File_C_Drive);
                xmlData = this.CallWS(xmlData, "BizObj.GL_006,BizObj", "");
                DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
                DataTable dt = PLABS.Utils.GetDataTable(ds, 0);
                if (dt.Rows.Count==1)
                {
                    if (PLABS.Utils.CnvToStr(dt.Rows[0]["usr_id"]) == "-100")
                    {
                        PLABS.MessageBoxPL.Show("Day Closed");
                        Application.Exit();
                    }
                    else if (PLABS.Utils.CnvToStr(dt.Rows[0]["usr_id"]) == "-101")
                    {
                        PLABS.MessageBoxPL.Show("Previous Day Did Not Close properly");
                        Application.Exit();
                    }
                    else
                    {
                        Properties.Settings.Default.id = PLABS.Utils.CnvToInt(ds.Tables[0].Rows[0]["usr_id"].ToString());
                        Nam = PLABS.Utils.CnvToStr(ds.Tables[0].Rows[0]["nam"]);
                    }
                    
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show( PLABS.Utils.CnvToStr(ex),"");
                this.Close();             

            }
        }
        private String CallWS(String Xml, String ClassName, String mode)
        {
            string xmlData = string.Empty;
            try
            {
                // For Using Webservice
                UtilsApp.CallBO objServ = new UtilsApp.CallBO();
                xmlData = objServ.CallWS(Xml, ClassName, "A");

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

        private string GetMacAddress()
        {
            string processorId = string.Empty;
            ManagementClass processorManagement = new ManagementClass("Win32_baseboard");

      
            

            foreach (var processor in processorManagement.GetInstances())
            {
                try
                {
                  //  processorId = processor["SerialNumber"].ToString();
                    //      MessageBox.Show(processorId, "Processor Id",
                    //   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error occured in getting processor Id",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return processorId;
        }
        #endregion
    }
}
