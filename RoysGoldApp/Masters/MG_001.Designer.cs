namespace RoysGold
{
    partial class MG_001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MG_001));
            this.line1 = new PLABSc.Line();
            this.groupBox1 = new PLABSc.GroupBoxPL();
            this.lst_search = new PLABSn .ListViewNormalPL();
            this.pLabsListViewColHdr0 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr2 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr1 = new PLABSn.PLabsListViewColHdr();
            this.gob_main = new PLABSc.GroupBoxPL();
            this.btn_delete = new PLABSb.ButtonPL();
            this.btn_close = new PLABSb.ButtonPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.btn_clear = new PLABSb.ButtonPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.ddl_grptyp = new PLABSn.ComboBoxPL();
            this.lbl_groupname = new PLABSn.LabelPL();
            this.txt_groupname = new PLABSn.TextBoxPL();
            this.lbl_code = new PLABSn.LabelPL();
            this.txt_code = new PLABSn.TextBoxPL();
            this.gob_find = new PLABSc.GroupBoxPL();
            this.lbl_groupname_F = new PLABSn.LabelPL();
            this.txt_groupname_F = new PLABSn.TextBoxPL();
            this.lbl_code_F = new PLABSn.LabelPL();
            this.txt_code_F = new PLABSn.TextBoxPL();
            this.btn_find_F = new PLABSb.ButtonPL();
            this.btn_clear_F = new PLABSb.ButtonPL();
            this.gob_main.SuspendLayout();
            this.gob_find.SuspendLayout();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Black;
            this.line1.Font = new System.Drawing.Font("Tahoma", 8F);
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
            // groupBox1
            // 
            this.groupBox1.BorderWidth = 1F;
            this.groupBox1.Caption = "";
            this.groupBox1.CaptionImage = null;
            this.groupBox1.CornersRadius = 2;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.HelpUrl = "";
            this.groupBox1.Location = new System.Drawing.Point(1, 506);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBox1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Size = new System.Drawing.Size(814, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Themes = "Default";
            this.groupBox1.Tooltip = "";
            // 
            // lst_search
            // 
            this.lst_search.AllowCellToolTip = true;
            this.lst_search.CheckedColumnIndex = -1;
            this.lst_search.CheckedValue = "";
            this.lst_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pLabsListViewColHdr0,
            this.pLabsListViewColHdr2,
            this.pLabsListViewColHdr1});
            this.lst_search.DefaultValue = "";
            this.lst_search.EditableColumnIndex = -1;
            this.lst_search.EditableValue = "";
            this.lst_search.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lst_search.ForeColor = System.Drawing.Color.Black;
            this.lst_search.FullRowSelect = true;
            this.lst_search.GridLines = true;
            this.lst_search.IsMandatory = false;
            this.lst_search.Location = new System.Drawing.Point(2, 110);
            this.lst_search.Name = "lst_search";
            this.lst_search.ReqdChkedValueINXml = false;
            this.lst_search.SchemaRequired = false;
            this.lst_search.ShowContextMenu = false;
            this.lst_search.Size = new System.Drawing.Size(376, 405);
            this.lst_search.TabIndex = 3;
            this.lst_search.Tooltip = "";
            this.lst_search.UseCompatibleStateImageBehavior = false;
            this.lst_search.View = System.Windows.Forms.View.Details;
            this.lst_search.XmlOutPut = PLEnums.XmlOutPutType.AllItems;
            // 
            // pLabsListViewColHdr0
            // 
            this.pLabsListViewColHdr0.DataColumnName = "addr_grup_id";
            this.pLabsListViewColHdr0.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr0.FormatString = "";
            this.pLabsListViewColHdr0.ReqdForSave = true;
            this.pLabsListViewColHdr0.Resizable = true;
            this.pLabsListViewColHdr0.Text = "Id";
            this.pLabsListViewColHdr0.Width = 0;
            // 
            // pLabsListViewColHdr2
            // 
            this.pLabsListViewColHdr2.DataColumnName = "addr_grup_code";
            this.pLabsListViewColHdr2.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr2.FormatString = "";
            this.pLabsListViewColHdr2.ReqdForSave = true;
            this.pLabsListViewColHdr2.Resizable = true;
            this.pLabsListViewColHdr2.Text = "Code";
            this.pLabsListViewColHdr2.Width = 150;
            // 
            // pLabsListViewColHdr1
            // 
            this.pLabsListViewColHdr1.DataColumnName = "addr_grup_nam";
            this.pLabsListViewColHdr1.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr1.FormatString = "";
            this.pLabsListViewColHdr1.ReqdForSave = true;
            this.pLabsListViewColHdr1.Resizable = true;
            this.pLabsListViewColHdr1.Text = "Group Name";
            this.pLabsListViewColHdr1.Width = 222;
            // 
            // gob_main
            // 
            this.gob_main.BorderWidth = 1F;
            this.gob_main.Caption = "Create";
            this.gob_main.CaptionImage = null;
            this.gob_main.Controls.Add(this.btn_delete);
            this.gob_main.Controls.Add(this.btn_close);
            this.gob_main.Controls.Add(this.btn_save);
            this.gob_main.Controls.Add(this.btn_clear);
            this.gob_main.Controls.Add(this.labelPL1);
            this.gob_main.Controls.Add(this.ddl_grptyp);
            this.gob_main.Controls.Add(this.lbl_groupname);
            this.gob_main.Controls.Add(this.txt_groupname);
            this.gob_main.Controls.Add(this.lbl_code);
            this.gob_main.Controls.Add(this.txt_code);
            this.gob_main.CornersRadius = 2;
            this.gob_main.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gob_main.ForeColor = System.Drawing.Color.Black;
            this.gob_main.HelpUrl = "";
            this.gob_main.Location = new System.Drawing.Point(380, 1);
            this.gob_main.Name = "gob_main";
            this.gob_main.Padding = new System.Windows.Forms.Padding(20);
            this.gob_main.ShadowColor = System.Drawing.Color.DarkGray;
            this.gob_main.Size = new System.Drawing.Size(435, 565);
            this.gob_main.TabIndex = 0;
            this.gob_main.Themes = "Default";
            this.gob_main.Tooltip = "";
            // 
            // btn_delete
            // 
            this.btn_delete.ButtonType = PLEnums.ButtonTypes.Delete;
            this.btn_delete.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_delete.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_delete.ConfirmationMessage = "Do you want to cancel?";
            this.btn_delete.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.HelpUrl = "";
            this.btn_delete.Location = new System.Drawing.Point(243, 528);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.SucessMessage = "Cancel successfully";
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "&Delete";
            this.btn_delete.Themes = "Default";
            this.btn_delete.Tooltip = "";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_close
            // 
            this.btn_close.ButtonType = PLEnums.ButtonTypes.Exit;
            this.btn_close.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_close.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_close.ConfirmationMessage = "";
            this.btn_close.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_close.ForeColor = System.Drawing.Color.Black;
            this.btn_close.HelpUrl = "";
            this.btn_close.Location = new System.Drawing.Point(320, 528);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.SucessMessage = "";
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Clos&e";
            this.btn_close.Themes = "Default";
            this.btn_close.Tooltip = "";
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.ButtonType = PLEnums.ButtonTypes.Save;
            this.btn_save.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_save.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_save.ConfirmationMessage = "Do you want to save?";
            this.btn_save.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.HelpUrl = "";
            this.btn_save.Location = new System.Drawing.Point(89, 528);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.SucessMessage = "Save successfully";
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "&Save";
            this.btn_save.Themes = "Default";
            this.btn_save.Tooltip = "";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // btn_clear
            // 
            this.btn_clear.ButtonType = PLEnums.ButtonTypes.Clear;
            this.btn_clear.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_clear.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_clear.ConfirmationMessage = "";
            this.btn_clear.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_clear.ForeColor = System.Drawing.Color.Black;
            this.btn_clear.HelpUrl = "";
            this.btn_clear.Location = new System.Drawing.Point(166, 528);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.SucessMessage = "";
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "&Clear";
            this.btn_clear.Themes = "Default";
            this.btn_clear.Tooltip = "";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "Group Type";
            this.labelPL1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelPL1.IsMandatory = true;
            this.labelPL1.Location = new System.Drawing.Point(90, 105);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(63, 13);
            this.labelPL1.SmartTab = false;
            this.labelPL1.SpParameter = "as_addr";
            this.labelPL1.TabIndex = 9;
            this.labelPL1.Text = "Group Type";
            this.labelPL1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPL1.Tooltip = "";
            // 
            // ddl_grptyp
            // 
            this.ddl_grptyp.ControlValue = "";
            this.ddl_grptyp.DefaultValue = "";
            this.ddl_grptyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_grptyp.ErrorMessage = "Please Enter Goup Type";
            this.ddl_grptyp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ddl_grptyp.ForeColor = System.Drawing.Color.Black;
            this.ddl_grptyp.FormattingEnabled = true;
            this.ddl_grptyp.InstructionText = "Select Item";
            this.ddl_grptyp.IsMandatory = true;
            this.ddl_grptyp.Location = new System.Drawing.Point(178, 101);
            this.ddl_grptyp.Name = "ddl_grptyp";
            this.ddl_grptyp.Size = new System.Drawing.Size(145, 21);
            this.ddl_grptyp.SpParameter = "ai_main_grp_id";
            this.ddl_grptyp.TabIndex = 2;
            this.ddl_grptyp.Tooltip = "";
            // 
            // lbl_groupname
            // 
            this.lbl_groupname.AutoSize = true;
            this.lbl_groupname.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_groupname.ClearingRequired = false;
            this.lbl_groupname.ControlValue = "Group Name";
            this.lbl_groupname.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbl_groupname.IsMandatory = true;
            this.lbl_groupname.Location = new System.Drawing.Point(83, 70);
            this.lbl_groupname.Name = "lbl_groupname";
            this.lbl_groupname.SavingRequired = false;
            this.lbl_groupname.Size = new System.Drawing.Size(66, 13);
            this.lbl_groupname.SmartTab = false;
            this.lbl_groupname.SpParameter = "as_addr_grup_nam";
            this.lbl_groupname.TabIndex = 8;
            this.lbl_groupname.Text = "Group Name";
            this.lbl_groupname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_groupname.Tooltip = "";
            // 
            // txt_groupname
            // 
            this.txt_groupname.AfterDecimal = 0;
            this.txt_groupname.BeforeDecimal = 0;
            this.txt_groupname.DataType = PLEnums.TextDataType.General;
            this.txt_groupname.DefaultValue = "";
            this.txt_groupname.ErrorMessage = "Please Enter Group Name";
            this.txt_groupname.ForeColor = System.Drawing.Color.Empty;
            this.txt_groupname.IsMandatory = true;
            this.txt_groupname.Location = new System.Drawing.Point(178, 69);
            this.txt_groupname.MaxLength = 15;
            this.txt_groupname.Name = "txt_groupname";
            this.txt_groupname.Size = new System.Drawing.Size(145, 20);
            this.txt_groupname.SpParameter = "as_addr_grup_nam";
            this.txt_groupname.TabIndex = 1;
            this.txt_groupname.TextCase = PLEnums.TextDataCase.None;
            this.txt_groupname.Tooltip = "";
            this.txt_groupname.Watermark = "";
            this.txt_groupname.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_code.ClearingRequired = false;
            this.lbl_code.ControlValue = "Code";
            this.lbl_code.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbl_code.IsMandatory = true;
            this.lbl_code.Location = new System.Drawing.Point(131, 40);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.SavingRequired = false;
            this.lbl_code.Size = new System.Drawing.Size(32, 13);
            this.lbl_code.SmartTab = false;
            this.lbl_code.SpParameter = "as_addr_grup_code";
            this.lbl_code.TabIndex = 7;
            this.lbl_code.Text = "Code";
            this.lbl_code.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_code.Tooltip = "";
            // 
            // txt_code
            // 
            this.txt_code.AfterDecimal = 0;
            this.txt_code.BeforeDecimal = 0;
            this.txt_code.DataType = PLEnums.TextDataType.General;
            this.txt_code.DefaultValue = "";
            this.txt_code.ErrorMessage = "Please Enter Code";
            this.txt_code.ForeColor = System.Drawing.Color.Empty;
            this.txt_code.IsMandatory = true;
            this.txt_code.Location = new System.Drawing.Point(178, 37);
            this.txt_code.MaxLength = 6;
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(145, 20);
            this.txt_code.SpParameter = "as_addr_grup_code";
            this.txt_code.TabIndex = 0;
            this.txt_code.TextCase = PLEnums.TextDataCase.None;
            this.txt_code.Tooltip = "";
            this.txt_code.Watermark = "";
            this.txt_code.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // gob_find
            // 
            this.gob_find.BorderWidth = 1F;
            this.gob_find.Caption = "Search";
            this.gob_find.CaptionImage = null;
            this.gob_find.Controls.Add(this.lbl_groupname_F);
            this.gob_find.Controls.Add(this.txt_groupname_F);
            this.gob_find.Controls.Add(this.lbl_code_F);
            this.gob_find.Controls.Add(this.txt_code_F);
            this.gob_find.Controls.Add(this.btn_find_F);
            this.gob_find.Controls.Add(this.btn_clear_F);
            this.gob_find.CornersRadius = 2;
            this.gob_find.Font = new System.Drawing.Font("Tahoma", 8F);
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
            // lbl_groupname_F
            // 
            this.lbl_groupname_F.AutoSize = true;
            this.lbl_groupname_F.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_groupname_F.ClearingRequired = false;
            this.lbl_groupname_F.ControlValue = "Group Name";
            this.lbl_groupname_F.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbl_groupname_F.IsMandatory = false;
            this.lbl_groupname_F.Location = new System.Drawing.Point(8, 63);
            this.lbl_groupname_F.Name = "lbl_groupname_F";
            this.lbl_groupname_F.SavingRequired = false;
            this.lbl_groupname_F.Size = new System.Drawing.Size(66, 13);
            this.lbl_groupname_F.SmartTab = false;
            this.lbl_groupname_F.SpParameter = "as_addr_grup_nam";
            this.lbl_groupname_F.TabIndex = 2;
            this.lbl_groupname_F.Text = "Group Name";
            this.lbl_groupname_F.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_groupname_F.Tooltip = "";
            // 
            // txt_groupname_F
            // 
            this.txt_groupname_F.AfterDecimal = 0;
            this.txt_groupname_F.BeforeDecimal = 0;
            this.txt_groupname_F.ClearingRequired = false;
            this.txt_groupname_F.DataType = PLEnums.TextDataType.General;
            this.txt_groupname_F.DefaultValue = "";
            this.txt_groupname_F.ErrorMessage = "Please Enter Group Name";
            this.txt_groupname_F.ForeColor = System.Drawing.Color.Empty;
            this.txt_groupname_F.Location = new System.Drawing.Point(105, 59);
            this.txt_groupname_F.MaxLength = 15;
            this.txt_groupname_F.Name = "txt_groupname_F";
            this.txt_groupname_F.SavingRequired = false;
            this.txt_groupname_F.Size = new System.Drawing.Size(145, 20);
            this.txt_groupname_F.SpParameter = "as_addr_grup_nam";
            this.txt_groupname_F.TabIndex = 1;
            this.txt_groupname_F.TextCase = PLEnums.TextDataCase.None;
            this.txt_groupname_F.Tooltip = "";
            this.txt_groupname_F.Watermark = "";
            this.txt_groupname_F.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // lbl_code_F
            // 
            this.lbl_code_F.AutoSize = true;
            this.lbl_code_F.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_code_F.ClearingRequired = false;
            this.lbl_code_F.ControlValue = "Code";
            this.lbl_code_F.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbl_code_F.IsMandatory = false;
            this.lbl_code_F.Location = new System.Drawing.Point(56, 35);
            this.lbl_code_F.Name = "lbl_code_F";
            this.lbl_code_F.SavingRequired = false;
            this.lbl_code_F.Size = new System.Drawing.Size(32, 13);
            this.lbl_code_F.SmartTab = false;
            this.lbl_code_F.SpParameter = "as_addr_grup_code";
            this.lbl_code_F.TabIndex = 0;
            this.lbl_code_F.Text = "Code";
            this.lbl_code_F.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_code_F.Tooltip = "";
            // 
            // txt_code_F
            // 
            this.txt_code_F.AfterDecimal = 0;
            this.txt_code_F.BeforeDecimal = 0;
            this.txt_code_F.ClearingRequired = false;
            this.txt_code_F.DataType = PLEnums.TextDataType.General;
            this.txt_code_F.DefaultValue = "";
            this.txt_code_F.ErrorMessage = "Please Enter Code";
            this.txt_code_F.ForeColor = System.Drawing.Color.Empty;
            this.txt_code_F.Location = new System.Drawing.Point(105, 31);
            this.txt_code_F.MaxLength = 6;
            this.txt_code_F.Name = "txt_code_F";
            this.txt_code_F.SavingRequired = false;
            this.txt_code_F.Size = new System.Drawing.Size(145, 20);
            this.txt_code_F.SpParameter = "as_addr_grup_code";
            this.txt_code_F.TabIndex = 0;
            this.txt_code_F.TextCase = PLEnums.TextDataCase.None;
            this.txt_code_F.Tooltip = "";
            this.txt_code_F.Watermark = "";
            this.txt_code_F.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // btn_find_F
            // 
            this.btn_find_F.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_find_F.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_find_F.ConfirmationMessage = "";
            this.btn_find_F.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_find_F.ForeColor = System.Drawing.Color.Black;
            this.btn_find_F.HelpUrl = "";
            this.btn_find_F.Location = new System.Drawing.Point(278, 30);
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
            this.btn_clear_F.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_clear_F.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_clear_F.ConfirmationMessage = "";
            this.btn_clear_F.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_clear_F.ForeColor = System.Drawing.Color.Black;
            this.btn_clear_F.HelpUrl = "";
            this.btn_clear_F.Location = new System.Drawing.Point(278, 60);
            this.btn_clear_F.Name = "btn_clear_F";
            this.btn_clear_F.Size = new System.Drawing.Size(75, 23);
            this.btn_clear_F.SucessMessage = "";
            this.btn_clear_F.TabIndex = 3;
            this.btn_clear_F.Text = "Clea&r";
            this.btn_clear_F.Themes = "Default";
            this.btn_clear_F.Tooltip = "";
            this.btn_clear_F.UseVisualStyleBackColor = false;
            // 
            // MG_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(816, 567);
            this.Controls.Add(this.lst_search);
            this.Controls.Add(this.gob_main);
            this.Controls.Add(this.gob_find);
            this.Controls.Add(this.groupBox1);
            this.FindIDParameter = "ai_addr_grup_id";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MG_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "Address Group Master";
            this.gob_main.ResumeLayout(false);
            this.gob_main.PerformLayout();
            this.gob_find.ResumeLayout(false);
            this.gob_find.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private PLABSc.Line line1;
        private PLABSc.GroupBoxPL groupBox1;
        private PLABSn .ListViewNormalPL lst_search;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr0;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr2;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr1;
        private PLABSc.GroupBoxPL gob_main;
        private PLABSn.LabelPL lbl_groupname;
        private PLABSn.TextBoxPL txt_groupname;
        private PLABSn.LabelPL lbl_code;
        private PLABSn.TextBoxPL txt_code;
        private PLABSc.GroupBoxPL gob_find;
        private PLABSn.LabelPL lbl_groupname_F;
        private PLABSn.TextBoxPL txt_groupname_F;
        private PLABSn.LabelPL lbl_code_F;
        private PLABSn.TextBoxPL txt_code_F;
        private PLABSb.ButtonPL btn_find_F;
        private PLABSb.ButtonPL btn_clear_F;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.ComboBoxPL ddl_grptyp;
        private PLABSb.ButtonPL btn_delete;
        private PLABSb.ButtonPL btn_close;
        private PLABSb.ButtonPL btn_save;
        private PLABSb.ButtonPL btn_clear; 
	}
}
