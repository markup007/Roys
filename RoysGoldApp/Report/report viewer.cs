using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RoysGold
{
    public partial class report_viewer :PLABS.MasterForm
    {
        public report_viewer()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.btn_print.Click += new EventHandler(btn_print_Click);
            this.richTextBox1.Text = _print.ToString();
            base.OnLoad(e);

           
        }

        void btn_print_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"D:\print.txt", Print);
            

            System .Diagnostics .Process .Start("C:\\print\\print.bat");
        }
        string _print = string.Empty;
      
    

public String Print
{
  get { return _print; }
  set { _print = value; }
}
       
    }
}
