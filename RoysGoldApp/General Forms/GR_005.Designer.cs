namespace RoysGold
{
	partial class GR_005
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
				}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GR_005));
            this.gob_main = new PLABSc.GroupBoxPL();
            this.panelPL1 = new PLABSc.PanelPL();
            this.gv_frm = new PLABSn.DataGridViewPL();
            this.ddl_user = new PLABSn.ComboBoxPL();
            this.lbl_user = new PLABSn.LabelPL();
            this.panelPL2 = new PLABSc.PanelPL();
            this.btn_clear = new PLABSb.ButtonPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.btn_close = new PLABSb.ButtonPL();
            this.gob_find = new PLABSc.GroupBoxPL();
            this.ddl_user_F = new PLABSn.ComboBoxPL();
            this.lbl_user_F = new PLABSn.LabelPL();
            this.btn_find_F = new PLABSb.ButtonPL();
            this.btn_clear_F = new PLABSb.ButtonPL();
            this.line1 = new PLABSc.Line();
            this.lst_search = new PLABSn.ListViewNormalPL();
            this.pLabsListViewColHdr0 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr1 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr2 = new PLABSn.PLabsListViewColHdr();
            this.frm_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.frm_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_menu_gv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_ordernum_gv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_keys_gv = new PLABSn.PLComboxBoxColumn();
            this.gob_main.SuspendLayout();
            this.panelPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_frm)).BeginInit();
            this.panelPL2.SuspendLayout();
            this.gob_find.SuspendLayout();
            this.SuspendLayout();
            // 
            // gob_main
            // 
            this.gob_main.BorderWidth = 1F;
            this.gob_main.Caption = "Create";
            this.gob_main.CaptionImage = null;
            this.gob_main.Controls.Add(this.panelPL1);
            this.gob_main.Controls.Add(this.ddl_user);
            this.gob_main.Controls.Add(this.lbl_user);
            this.gob_main.CornersRadius = 2;
            this.gob_main.Font = new System.Drawing.Font("Arial", 11F);
            this.gob_main.ForeColor = System.Drawing.Color.Black;
            this.gob_main.HelpUrl = "";
            this.gob_main.Location = new System.Drawing.Point(380, 1);
            this.gob_main.Name = "gob_main";
            this.gob_main.Padding = new System.Windows.Forms.Padding(20);
            this.gob_main.ShadowColor = System.Drawing.Color.DarkGray;
            this.gob_main.Size = new System.Drawing.Size(752, 528);
            this.gob_main.TabIndex = 0;
            this.gob_main.Themes = "Default";
            this.gob_main.Tooltip = "";
            // 
            // panelPL1
            // 
            this.panelPL1.BackColor = System.Drawing.Color.Transparent;
            this.panelPL1.BorderRequired = true;
            this.panelPL1.Controls.Add(this.gv_frm);
            this.panelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.panelPL1.ForeColor = System.Drawing.Color.Black;
            this.panelPL1.HelpUrl = "";
            this.panelPL1.Location = new System.Drawing.Point(7, 109);
            this.panelPL1.Name = "panelPL1";
            this.panelPL1.Size = new System.Drawing.Size(742, 409);
            this.panelPL1.TabIndex = 9;
            this.panelPL1.Themes = "Default";
            this.panelPL1.Tooltip = "";
            // 
            // gv_frm
            // 
            this.gv_frm.BackgroundColor = System.Drawing.Color.White;
            this.gv_frm.CancelRowDelete = false;
            this.gv_frm.ClearingRequired = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_frm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_frm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_frm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.frm_id,
            this.Status,
            this.frm_desc,
            this.txt_menu_gv,
            this.txt_ordernum_gv,
            this.cmb_keys_gv});
            this.gv_frm.ControlValue = "<ResultDS></ResultDS>";
            this.gv_frm.EnableHeadersVisualStyles = false;
            this.gv_frm.ErrorMessage = "Please Enter At-least One Record";
            this.gv_frm.Font = new System.Drawing.Font("Arial", 11F);
            this.gv_frm.IsMandatory = true;
            this.gv_frm.Location = new System.Drawing.Point(0, 2);
            this.gv_frm.Name = "gv_frm";
            this.gv_frm.ReqdContextMenu = true;
            this.gv_frm.RowHeadersVisible = false;
            this.gv_frm.SavingRequired = false;
            this.gv_frm.Size = new System.Drawing.Size(740, 406);
            this.gv_frm.SpParameter = "v_Xmldata";
            this.gv_frm.TabIndex = 0;
            this.gv_frm.Tooltip = "";
            // 
            // ddl_user
            // 
            this.ddl_user.ControlValue = "";
            this.ddl_user.DefaultValue = "";
            this.ddl_user.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_user.ErrorMessage = "Please Enter User";
            this.ddl_user.Font = new System.Drawing.Font("Arial", 11F);
            this.ddl_user.ForeColor = System.Drawing.Color.Black;
            this.ddl_user.InstructionText = "Select Item";
            this.ddl_user.IsMandatory = true;
            this.ddl_user.Location = new System.Drawing.Point(142, 52);
            this.ddl_user.Name = "ddl_user";
            this.ddl_user.Size = new System.Drawing.Size(160, 25);
            this.ddl_user.SpParameter = "ai_usr_id";
            this.ddl_user.TabIndex = 1;
            this.ddl_user.Tooltip = "";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_user.ClearingRequired = false;
            this.lbl_user.ControlValue = "User";
            this.lbl_user.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_user.IsMandatory = true;
            this.lbl_user.Location = new System.Drawing.Point(99, 56);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.SavingRequired = false;
            this.lbl_user.Size = new System.Drawing.Size(39, 17);
            this.lbl_user.SmartTab = false;
            this.lbl_user.SpParameter = "ai_usr_id";
            this.lbl_user.TabIndex = 2;
            this.lbl_user.Text = "User";
            this.lbl_user.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_user.Tooltip = "";
            // 
            // panelPL2
            // 
            this.panelPL2.BackColor = System.Drawing.Color.Transparent;
            this.panelPL2.BorderRequired = true;
            this.panelPL2.Controls.Add(this.btn_clear);
            this.panelPL2.Controls.Add(this.btn_save);
            this.panelPL2.Controls.Add(this.btn_close);
            this.panelPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.panelPL2.ForeColor = System.Drawing.Color.Black;
            this.panelPL2.HelpUrl = "";
            this.panelPL2.Location = new System.Drawing.Point(2, 532);
            this.panelPL2.Name = "panelPL2";
            this.panelPL2.Size = new System.Drawing.Size(1159, 50);
            this.panelPL2.TabIndex = 1;
            this.panelPL2.Themes = "Default";
            this.panelPL2.Tooltip = "";
            // 
            // btn_clear
            // 
            this.btn_clear.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_clear.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_clear.ButtonType = PLEnums.ButtonTypes.Clear;
            this.btn_clear.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_clear.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_clear.ConfirmationMessage = "";
            this.btn_clear.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_clear.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_clear.ForeColor = System.Drawing.Color.Black;
            this.btn_clear.HelpUrl = "";
            this.btn_clear.Location = new System.Drawing.Point(995, 15);
            this.btn_clear.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_clear.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.SucessMessage = "";
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "&Clear";
            this.btn_clear.Themes = "Default";
            this.btn_clear.Tooltip = "";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_save.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_save.ButtonType = PLEnums.ButtonTypes.Save;
            this.btn_save.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_save.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_save.ConfirmationMessage = "Do you want to save?";
            this.btn_save.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.HelpUrl = "";
            this.btn_save.Location = new System.Drawing.Point(917, 15);
            this.btn_save.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_save.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.SucessMessage = "Save successfully";
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "&Save";
            this.btn_save.Themes = "Default";
            this.btn_save.Tooltip = "";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // btn_close
            // 
            this.btn_close.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_close.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_close.ButtonType = PLEnums.ButtonTypes.Exit;
            this.btn_close.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_close.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_close.ConfirmationMessage = "";
            this.btn_close.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_close.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_close.ForeColor = System.Drawing.Color.Black;
            this.btn_close.HelpUrl = "";
            this.btn_close.Location = new System.Drawing.Point(1073, 15);
            this.btn_close.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_close.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.SucessMessage = "";
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "Clos&e";
            this.btn_close.Themes = "Default";
            this.btn_close.Tooltip = "";
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // gob_find
            // 
            this.gob_find.BorderWidth = 1F;
            this.gob_find.Caption = "Search";
            this.gob_find.CaptionImage = null;
            this.gob_find.Controls.Add(this.ddl_user_F);
            this.gob_find.Controls.Add(this.lbl_user_F);
            this.gob_find.Controls.Add(this.btn_find_F);
            this.gob_find.Controls.Add(this.btn_clear_F);
            this.gob_find.CornersRadius = 2;
            this.gob_find.Font = new System.Drawing.Font("Arial", 11F);
            this.gob_find.ForeColor = System.Drawing.Color.Black;
            this.gob_find.HelpUrl = "";
            this.gob_find.Location = new System.Drawing.Point(2, 1);
            this.gob_find.Name = "gob_find";
            this.gob_find.Padding = new System.Windows.Forms.Padding(20);
            this.gob_find.ShadowColor = System.Drawing.Color.DarkGray;
            this.gob_find.Size = new System.Drawing.Size(376, 108);
            this.gob_find.TabIndex = 2;
            this.gob_find.Themes = "Default";
            this.gob_find.Tooltip = "";
            // 
            // ddl_user_F
            // 
            this.ddl_user_F.ClearingRequired = false;
            this.ddl_user_F.ControlValue = "";
            this.ddl_user_F.DefaultValue = "";
            this.ddl_user_F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_user_F.ErrorMessage = "Please Enter User";
            this.ddl_user_F.Font = new System.Drawing.Font("Arial", 11F);
            this.ddl_user_F.ForeColor = System.Drawing.Color.Black;
            this.ddl_user_F.InstructionText = "Select Item";
            this.ddl_user_F.Location = new System.Drawing.Point(72, 50);
            this.ddl_user_F.Name = "ddl_user_F";
            this.ddl_user_F.SavingRequired = false;
            this.ddl_user_F.Size = new System.Drawing.Size(160, 25);
            this.ddl_user_F.SpParameter = "ai_usr_id";
            this.ddl_user_F.TabIndex = 1;
            this.ddl_user_F.Tooltip = "";
            // 
            // lbl_user_F
            // 
            this.lbl_user_F.AutoSize = true;
            this.lbl_user_F.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_user_F.ClearingRequired = false;
            this.lbl_user_F.ControlValue = "User";
            this.lbl_user_F.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_user_F.IsMandatory = false;
            this.lbl_user_F.Location = new System.Drawing.Point(23, 54);
            this.lbl_user_F.Name = "lbl_user_F";
            this.lbl_user_F.SavingRequired = false;
            this.lbl_user_F.Size = new System.Drawing.Size(39, 17);
            this.lbl_user_F.SmartTab = false;
            this.lbl_user_F.SpParameter = "ai_usr_id";
            this.lbl_user_F.TabIndex = 2;
            this.lbl_user_F.Text = "User";
            this.lbl_user_F.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_user_F.Tooltip = "";
            // 
            // btn_find_F
            // 
            this.btn_find_F.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_find_F.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_find_F.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_find_F.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_find_F.ConfirmationMessage = "";
            this.btn_find_F.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_find_F.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_find_F.ForeColor = System.Drawing.Color.Black;
            this.btn_find_F.HelpUrl = "";
            this.btn_find_F.Location = new System.Drawing.Point(258, 38);
            this.btn_find_F.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_find_F.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_find_F.Name = "btn_find_F";
            this.btn_find_F.Size = new System.Drawing.Size(75, 23);
            this.btn_find_F.SucessMessage = "";
            this.btn_find_F.TabIndex = 2;
            this.btn_find_F.Text = "&Find";
            this.btn_find_F.Themes = "Default";
            this.btn_find_F.Tooltip = "";
            this.btn_find_F.UseVisualStyleBackColor = false;
            // 
            // btn_clear_F
            // 
            this.btn_clear_F.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_clear_F.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_clear_F.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_clear_F.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_clear_F.ConfirmationMessage = "";
            this.btn_clear_F.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_clear_F.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_clear_F.ForeColor = System.Drawing.Color.Black;
            this.btn_clear_F.HelpUrl = "";
            this.btn_clear_F.Location = new System.Drawing.Point(258, 66);
            this.btn_clear_F.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_clear_F.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_clear_F.Name = "btn_clear_F";
            this.btn_clear_F.Size = new System.Drawing.Size(75, 23);
            this.btn_clear_F.SucessMessage = "";
            this.btn_clear_F.TabIndex = 3;
            this.btn_clear_F.Text = "Clea&r";
            this.btn_clear_F.Themes = "Default";
            this.btn_clear_F.Tooltip = "";
            this.btn_clear_F.UseVisualStyleBackColor = false;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Black;
            this.line1.Font = new System.Drawing.Font("Arial", 11F);
            this.line1.ForeColor = System.Drawing.Color.Black;
            this.line1.HelpUrl = "";
            this.line1.Location = new System.Drawing.Point(0, 0);
            this.line1.MaximumSize = new System.Drawing.Size(1000, 5);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(200, 1);
            this.line1.TabIndex = 0;
            this.line1.Themes = "Default";
            this.line1.Tooltip = "";
            // 
            // lst_search
            // 
            this.lst_search.AllowCellToolTip = true;
            this.lst_search.CheckedColumnIndex = -1;
            this.lst_search.CheckedValue = "";
            this.lst_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pLabsListViewColHdr0,
            this.pLabsListViewColHdr1,
            this.pLabsListViewColHdr2});
            this.lst_search.DefaultValue = "";
            this.lst_search.EditableColumnIndex = -1;
            this.lst_search.EditableValue = "";
            this.lst_search.Font = new System.Drawing.Font("Arial", 11F);
            this.lst_search.ForeColor = System.Drawing.Color.Black;
            this.lst_search.FullRowSelect = true;
            this.lst_search.GradiantColor = System.Drawing.Color.White;
            this.lst_search.GradiantColorMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lst_search.GridLines = true;
            this.lst_search.IsMandatory = false;
            this.lst_search.Location = new System.Drawing.Point(2, 110);
            this.lst_search.Name = "lst_search";
            this.lst_search.ReqdChkedValueINXml = false;
            this.lst_search.SchemaRequired = false;
            this.lst_search.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(220)))), ((int)(((byte)(252)))));
            this.lst_search.SelectionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(162)))), ((int)(((byte)(206)))));
            this.lst_search.SelectionGradiantColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.lst_search.ShowContextMenu = false;
            this.lst_search.Size = new System.Drawing.Size(376, 420);
            this.lst_search.TabIndex = 3;
            this.lst_search.Tooltip = "";
            this.lst_search.UseCompatibleStateImageBehavior = false;
            this.lst_search.View = System.Windows.Forms.View.Details;
            this.lst_search.XmlOutPut = PLEnums.XmlOutPutType.AllItems;
            // 
            // pLabsListViewColHdr0
            // 
            this.pLabsListViewColHdr0.DataColumnName = "id";
            this.pLabsListViewColHdr0.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr0.FormatString = "";
            this.pLabsListViewColHdr0.ReqdForSave = true;
            this.pLabsListViewColHdr0.Resizable = true;
            this.pLabsListViewColHdr0.Text = "ID";
            this.pLabsListViewColHdr0.Width = 0;
            // 
            // pLabsListViewColHdr1
            // 
            this.pLabsListViewColHdr1.DataColumnName = "name";
            this.pLabsListViewColHdr1.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr1.FormatString = "";
            this.pLabsListViewColHdr1.ReqdForSave = true;
            this.pLabsListViewColHdr1.Resizable = true;
            this.pLabsListViewColHdr1.Text = "Form";
            this.pLabsListViewColHdr1.Width = 165;
            // 
            // pLabsListViewColHdr2
            // 
            this.pLabsListViewColHdr2.DataColumnName = "usr";
            this.pLabsListViewColHdr2.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr2.FormatString = "";
            this.pLabsListViewColHdr2.ReqdForSave = true;
            this.pLabsListViewColHdr2.Resizable = true;
            this.pLabsListViewColHdr2.Text = "User";
            this.pLabsListViewColHdr2.Width = 207;
            // 
            // frm_id
            // 
            this.frm_id.DataPropertyName = "frm_id";
            this.frm_id.Frozen = true;
            this.frm_id.HeaderText = "id";
            this.frm_id.Name = "frm_id";
            this.frm_id.ReadOnly = true;
            this.frm_id.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "chk_stat";
            this.Status.FalseValue = "0";
            this.Status.Frozen = true;
            this.Status.HeaderText = "Status";
            this.Status.IndeterminateValue = "0";
            this.Status.Name = "Status";
            this.Status.TrueValue = "1";
            this.Status.Width = 60;
            // 
            // frm_desc
            // 
            this.frm_desc.DataPropertyName = "frm_desc";
            this.frm_desc.Frozen = true;
            this.frm_desc.HeaderText = "Form Name";
            this.frm_desc.Name = "frm_desc";
            this.frm_desc.Width = 290;
            // 
            // txt_menu_gv
            // 
            this.txt_menu_gv.DataPropertyName = "mnu_nam";
            this.txt_menu_gv.HeaderText = "Menu";
            this.txt_menu_gv.Name = "txt_menu_gv";
            this.txt_menu_gv.Width = 200;
            // 
            // txt_ordernum_gv
            // 
            this.txt_ordernum_gv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_ordernum_gv.DataPropertyName = "order_no";
            this.txt_ordernum_gv.HeaderText = "Order Number";
            this.txt_ordernum_gv.Name = "txt_ordernum_gv";
            // 
            // cmb_keys_gv
            // 
            this.cmb_keys_gv.DataPropertyName = "key";
            this.cmb_keys_gv.ErrorMessage = "Please Enter A Value";
            this.cmb_keys_gv.HeaderText = "Keys";
            this.cmb_keys_gv.Name = "cmb_keys_gv";
            this.cmb_keys_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmb_keys_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cmb_keys_gv.Width = 60;
            // 
            // GR_005
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(1133, 584);
            this.Controls.Add(this.lst_search);
            this.Controls.Add(this.panelPL2);
            this.Controls.Add(this.gob_main);
            this.Controls.Add(this.gob_find);
            this.FindIDParameter = "ai_usr_rol_det_id";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "GR_005";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "User Role Master";
            this.gob_main.ResumeLayout(false);
            this.gob_main.PerformLayout();
            this.panelPL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_frm)).EndInit();
            this.panelPL2.ResumeLayout(false);
            this.gob_find.ResumeLayout(false);
            this.gob_find.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		private PLABSc.GroupBoxPL gob_main;
        private PLABSc.GroupBoxPL gob_find; 
																																private PLABSb.ButtonPL btn_find_F; 
		private PLABSb.ButtonPL btn_clear_F;
        private PLABSc.Line line1; 
		private PLABSn.ComboBoxPL ddl_user;
		private PLABSn.LabelPL lbl_user; 
		private PLABSn.ComboBoxPL ddl_user_F;
		private PLABSn.LabelPL lbl_user_F; 
		private PLABSn .ListViewNormalPL lst_search;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr0;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr1;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr2;
        private PLABSc.PanelPL panelPL1;
        private PLABSc.PanelPL panelPL2;
        private PLABSn.DataGridViewPL gv_frm;
        private PLABSb.ButtonPL btn_clear;
        private PLABSb.ButtonPL btn_save;
        private PLABSb.ButtonPL btn_close;
        private System.Windows.Forms.DataGridViewTextBoxColumn frm_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn frm_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_menu_gv;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_ordernum_gv;
        private PLABSn.PLComboxBoxColumn cmb_keys_gv; 
	}
}
