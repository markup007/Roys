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
    public partial class DD_001 : PLABS .MasterForm 
    {
        public DD_001()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.btn_drop.Focus();
           
            this.btn_drop.Click += new EventHandler(btn_drop_Click);
            base.OnLoad(e);
        }

      
        void btn_drop_Click(object sender, EventArgs e)
        {
            PLABS.DAL objdal = new PLABS.DAL();
            objdal.insertSP("dropdb", this.getBlankXml(), PLABS.DataBase.MySql);
        }
    }
}
