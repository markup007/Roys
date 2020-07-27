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
    public partial class RP_014 : PLABS.MasterForm
    {
        #region Variables
        DataTable _dtlev_dtls=new DataTable();
        String _name;

       
        #endregion
        #region Constructor
        public RP_014()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.loadControls();
            }
            catch (Exception ex)
            {

            }
            base.OnLoad(e);
        }
        #endregion
        #region Properties
        public DataTable Dtlev_dtls
        {          
            set { _dtlev_dtls = value; }
        }
        public String getName
        {
           
            set { _name = value; }
        }
        #endregion
        #region Events
        #endregion
        #region Methods
        private void loadControls()
        {
            this.lbl_name.ControlValue = _name;
            this.grd_lev_dtls.DataSource = _dtlev_dtls;

        }
        #endregion

    }
}
