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
    public partial class MnuFrm : Form
    {
        #region Variables
        DataTable dt = new DataTable();
        TimeSpan t2 = new TimeSpan(0, 1, 0);
        int _id = 0;
        DateTime _idleTime = DateTime.Now;



        #endregion

        #region Properties

        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        #endregion

        #region Constructor
        public MnuFrm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {

            try
            {
                String baseUrl = "ftp://passionlabs.in/Raa/";
                String uName = "passionlabs";
                String passWD = "ron#29#TTk";

                //    Utils.getUpdates(baseUrl, uName, passWD, "Raa");

            }
            catch { }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.KeyPreview = true;
            MdiClient objMdiClient = null;
            foreach (Control cntrl in this.Controls)
            {
                if (cntrl is MdiClient)
                {
                    objMdiClient = ((MdiClient)cntrl);
                    objMdiClient.BackColor = Color.White;
                    objMdiClient.Paint += new PaintEventHandler(objMdiClient_Paint);

                }
            }
            GL_006 obj = new GL_006();
            obj.StartPosition = FormStartPosition.CenterParent;
            obj.ShowDialog();
            int i = Properties.Settings.Default.id;
            this.Text = obj.Nam;
            if (i != 0)
            {
                this.LoadMenu(i);
                Application.Idle += new EventHandler(Application_Idle);
            }
            this.KeyDown += new KeyEventHandler(MnuFrm_KeyDown);
            this.SetIdleTime();

            base.OnLoad(e);
        }
        #endregion

        #region Events
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.id = 0;
            this.mun_mainMenu.Items.Clear();
            this.dt.Clear();
            GL_006 obj = new GL_006();
            obj.StartPosition = FormStartPosition.CenterParent;
            obj.ShowDialog();
            this.Text = obj.Nam;
            int i = Properties.Settings.Default.id;
            if (i != 0)
            {
                this.LoadMenu(i);
            }
            else
            {
                mun_mainMenu.Items.Clear();
            }
            this.SetIdleTime();
        }
        void sub_Click(object sender, EventArgs e)
        {
            _idleTime = DateTime.Now;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "CB_002" && ((System.Windows.Forms.ToolStripDropDownItem)(sender)).Tag.ToString() == "CB_002")
                {
                    PLABS.MessageBoxPL.Show("Multiple Instances Cannot Be Allowed For This Window");
                    goto last;
                }
            }
            //throw new NotImplementedException();
            String FormId = "RoysGold." + ((System.Windows.Forms.ToolStripDropDownItem)(sender)).Tag.ToString();
            String FormCaption = ((System.Windows.Forms.ToolStripDropDownItem)(sender)).Text;
            PLABS.MasterForm frm = new PLABS.MasterForm();

            Type tp = Type.GetType(FormId);

            if (tp != null)
            {
                frm = ((PLABS.MasterForm)Activator.CreateInstance(tp));
                frm.MdiParent = this;
                frm.Text = FormCaption;
                frm.Location = new Point(1, 1);
                frm.StartPosition = FormStartPosition.Manual;

                frm.Show();
                frm.BringToFront();
            }
        last:
            int i = 0;

        }
        void objMdiClient_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int left = 0;
            int top = 0;
            int Width = 0;
            //int lessHeight = mun_mainMenu.Height + tl_ShortCut.Height + 2;

            Pen linePen = new Pen(Color.FromArgb(153, 170, 189), 1);
            Rectangle rec = new Rectangle(left, top, Width, this.Height - ((top * 2) + 10 + 34));
            g.FillRectangle(Brushes.White, rec);
            g.DrawRectangle(linePen, rec);

            rec = new Rectangle((left * 2) + Width, top, this.Width - ((left * 3) + Width + 10), this.Height - ((top * 2) + 10 + 34));
            g.FillRectangle(Brushes.WhiteSmoke, rec);
            g.DrawRectangle(linePen, rec);
            //g.DrawString("Roys Gold", new Font("Galba MN", 50, FontStyle.Regular), new SolidBrush(Color.LightGray), 500, 250);
            if (dt.Rows.Count != 0)
            {
                int y = 0;

                foreach (DataRow dr in dt.Rows)
                {

                    string shrtKey = string.Format("{0} = {1}", PLABS.Utils.CnvToStr(dr["key"]), PLABS.Utils.CnvToStr(dr["frm_desc"]));
                    g.DrawString(shrtKey, new Font("Galba MN", 12, FontStyle.Regular), new SolidBrush(Color.Black), 0, y);
                    y = y + 25;
                }
            }
            //this.Paint();
            int calendarLeft = (left * 2) + Width;
        }
        void Application_Idle(object sender, EventArgs e)
        {
            TimeSpan t1 = DateTime.Now.Subtract(_idleTime);
            if (t1 > t2)
            {
                Application.Exit();

            }
        }
        void MnuFrm_KeyDown(object sender, KeyEventArgs e)
        {

            _idleTime = DateTime.Now;
            if (e.KeyCode == Keys.F12)
            {
                //DD_001 objdd001 = new DD_001();
                //objdd001.ShowDialog();
                //objdd001.Close();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.T)
            {
                GT_001 obj = new GT_001();
                obj.ShowDialog();
            }
            else
            {
                DataRow[] dr = dt.Select(string.Format("Key='{0}'", e.KeyCode.ToString()), "");
                if (dr.Length != 0)
                {
                    String FormId = "RoysGold." + dr[0]["frm_nam"].ToString();
                    String FormCaption = dr[0]["frm_desc"].ToString();
                    PLABS.MasterForm frm = new PLABS.MasterForm();

                    Type tp = Type.GetType(FormId);
                    if (tp != null)
                    {
                        frm = ((PLABS.MasterForm)Activator.CreateInstance(tp));
                        frm.MdiParent = this;
                        frm.Text = FormCaption;
                        frm.Location = new Point(1, 1);
                        frm.StartPosition = FormStartPosition.Manual;

                        frm.Show();
                        frm.BringToFront();
                    }

                }
            }


        }
        #endregion

        #region Methods

        private void LoadMenu(int id)
        {

            if (Application.OpenForms.Count > 1)
            {
                this.ActiveMdiChild.Close();
            }
            mun_mainMenu.Items.Clear();

            string xmlData = "<root></root>";
            xmlData = PLABS.Utils.addNode(xmlData, "ai_usr_id", id.ToString());

            xmlData = this.CallWS(xmlData, "BizObj.MnuFrm,BizObj", "");
            DataSet ds = PLABS.Utils.CnvXMLToDataSet(xmlData);
            DataTable menu = ds.Tables[0].DefaultView.ToTable(true, new string[] { "mnu_id", "mnu_nam" });
            menu.DefaultView.Sort = "mnu_id asc";
            menu = menu.DefaultView.ToTable();

            for (int i = 0; i < menu.Rows.Count; i++)
            {
                string menuName = menu.Rows[i]["mnu_nam"].ToString();
                ToolStripMenuItem tl = new System.Windows.Forms.ToolStripMenuItem();
                tl.Text = menuName;
                tl.Name = menuName;
                mun_mainMenu.Items.Add(tl);

            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string menuName = ds.Tables[0].Rows[i]["mnu_nam"].ToString();
                string subMenu = ds.Tables[0].Rows[i]["frm_desc"].ToString();
                string form = ds.Tables[0].Rows[i]["frm_nam"].ToString();
                ToolStripItem sub = ((ToolStripMenuItem)this.mun_mainMenu.Items[menuName]).DropDownItems.Add(subMenu);
                sub.Tag = form;
                sub.Click += new EventHandler(sub_Click);
            }
            DataTable keytable = ds.Tables[0].DefaultView.ToTable(true, new string[] { "frm_nam", "frm_desc", "Key" });
            keytable.DefaultView.RowFilter = "key<>''";
            dt = keytable.DefaultView.ToTable();
            dt.DefaultView.Sort = "key asc";
            dt = dt.DefaultView.ToTable();
            this.Refresh();

            if (PLABS.Utils.CnvToInt(PLABS.Utils.GetDataTable(ds, 1).Rows[0]["cnt"]) > 0)
            {
                Properties.Settings.Default.id = -1;
            }
            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count != 0)
            {
                CO_008 obj = new CO_008();
                obj.Dt = PLABS.Utils.GetDataTable(ds, 2);
                obj.ShowDialog();
            }


        }

        private String CallWS(String Xml, String ClassName, String mode)
        {
            string xmlData = string.Empty;
            try
            {
                // For Using Webservice
                UtilsApp.CallBO objServ = new UtilsApp.CallBO();
                xmlData = objServ.CallWS(Xml, ClassName, "");

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

        private void SetIdleTime()
        {
            _idleTime = DateTime.Now;
            string path = Application.StartupPath + @"\Idle.xml";
            System.Xml.XmlDataDocument xmldoc = new System.Xml.XmlDataDocument();
            System.Xml.XmlNodeList xmlnode;
            int i = 0;

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Root");
            if (xmldoc.ChildNodes.Count > 0)
            {
                string name = PLABS.Utils.CnvToStr(xmlnode[i].ChildNodes.Item(0).InnerText);
                int h = PLABS.Utils.CnvToInt(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                int m = PLABS.Utils.CnvToInt(xmlnode[i].ChildNodes.Item(1).InnerText.Trim());
                int s = PLABS.Utils.CnvToInt(xmlnode[i].ChildNodes.Item(2).InnerText.Trim());
                t2 = new TimeSpan(h, m, s);
            }
        }

        #endregion

    }
}
