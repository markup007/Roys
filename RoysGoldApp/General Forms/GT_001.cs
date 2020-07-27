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
    public partial class GT_001 : PLABS.MasterForm
    {
        #region Global Varables
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public GT_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.btn_save.Click += new EventHandler(btn_save_Click);
            this.btn_exit.Click += new EventHandler(btn_exit_Click);
            base.OnLoad(e);
        }

       
        #endregion
        #region Events
        void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dosave();
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region Method
        private void Dosave()
        {
            try
            {
                string path=Application.StartupPath+@"\Idle.xml";

                int hr = PLABS.Utils.CnvToInt(this.txt_hrs.Text);
                int min = PLABS.Utils.CnvToInt(this.txt_mins.Text);
                int sec = PLABS.Utils.CnvToInt(this.txt_mins.Text);

                string xmlData="<Root>";
                xmlData +="<Hours>"+PLABS .Utils.CnvToStr(hr)+"</Hours>";
                xmlData+="<Minutes>"+PLABS .Utils.CnvToStr(min)+"</Minutes>";
                xmlData +="<Second>"+PLABS .Utils.CnvToStr(sec)+"</Second>";
                xmlData += "</Root>";

                System.IO.File.WriteAllText(path, xmlData);



            }
            catch (Exception ex)
            {
                PLABS.MessageBoxPL.Show(ex.Message);
            }
        }
        #endregion
    }
}
