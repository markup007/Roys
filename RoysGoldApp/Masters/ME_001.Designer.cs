namespace RoysGold
{
	partial class ME_001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ME_001));
            this.line1 = new PLABSc.Line();
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.btn_saveas = new PLABSb.ButtonPL();
            this.btn_close = new PLABSb.ButtonPL();
            this.btn_delete = new PLABSb.ButtonPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.btn_clear = new PLABSb.ButtonPL();
            this.lst_search = new PLABSn .ListViewNormalPL();
            this.pLabsListViewColHdr0 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr3 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr1 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr2 = new PLABSn.PLabsListViewColHdr();
            this.gob_main = new PLABSc.GroupBoxPL();
            this.ddl_employeename = new PLABSn.ComboBoxPL();
            this.lbl_employeename = new PLABSn.LabelPL();
            this.lbl_salary = new PLABSn.LabelPL();
            this.txt_salary = new PLABSn.TextBoxPL();
            this.lbl_inscentive = new PLABSn.LabelPL();
            this.txt_inscentive = new PLABSn.TextBoxPL();
            this.gob_find = new PLABSc.GroupBoxPL();
            this.ddl_employeename_F = new PLABSn.ComboBoxPL();
            this.lbl_employeename_F = new PLABSn.LabelPL();
            this.lbl_salary_F = new PLABSn.LabelPL();
            this.txt_salary_F = new PLABSn.TextBoxPL();
            this.btn_find_F = new PLABSb.ButtonPL();
            this.btn_clear_F = new PLABSb.ButtonPL();
            this.groupBoxPL1.SuspendLayout();
            this.gob_main.SuspendLayout();
            this.gob_find.SuspendLayout();
            this.SuspendLayout();
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
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.btn_saveas);
            this.groupBoxPL1.Controls.Add(this.btn_close);
            this.groupBoxPL1.Controls.Add(this.btn_delete);
            this.groupBoxPL1.Controls.Add(this.btn_save);
            this.groupBoxPL1.Controls.Add(this.btn_clear);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(2, 510);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(790, 60);
            this.groupBoxPL1.TabIndex = 1;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // btn_saveas
            // 
            this.btn_saveas.ButtonType = PLEnums.ButtonTypes.SaveAs;
            this.btn_saveas.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_saveas.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_saveas.ConfirmationMessage = "Do you want to save?";
            this.btn_saveas.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_saveas.ForeColor = System.Drawing.Color.Black;
            this.btn_saveas.HelpUrl = "";
            this.btn_saveas.Location = new System.Drawing.Point(548, 24);
            this.btn_saveas.Name = "btn_saveas";
            this.btn_saveas.Size = new System.Drawing.Size(75, 23);
            this.btn_saveas.SucessMessage = "Save successfully";
            this.btn_saveas.TabIndex = 2;
            this.btn_saveas.Text = "Save &As";
            this.btn_saveas.Themes = "Default";
            this.btn_saveas.Tooltip = "";
            this.btn_saveas.UseVisualStyleBackColor = false;
            // 
            // btn_close
            // 
            this.btn_close.ButtonType = PLEnums.ButtonTypes.Exit;
            this.btn_close.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_close.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_close.ConfirmationMessage = "";
            this.btn_close.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_close.ForeColor = System.Drawing.Color.Black;
            this.btn_close.HelpUrl = "";
            this.btn_close.Location = new System.Drawing.Point(705, 24);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.SucessMessage = "";
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "Clos&e";
            this.btn_close.Themes = "Default";
            this.btn_close.Tooltip = "";
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            this.btn_delete.ButtonType = PLEnums.ButtonTypes.Delete;
            this.btn_delete.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_delete.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_delete.ConfirmationMessage = "Do you want to cancel?";
            this.btn_delete.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.HelpUrl = "";
            this.btn_delete.Location = new System.Drawing.Point(626, 24);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.SucessMessage = "Cancel successfully";
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "&Delete";
            this.btn_delete.Themes = "Default";
            this.btn_delete.Tooltip = "";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.ButtonType = PLEnums.ButtonTypes.Save;
            this.btn_save.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_save.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_save.ConfirmationMessage = "Do you want to save?";
            this.btn_save.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.HelpUrl = "";
            this.btn_save.Location = new System.Drawing.Point(470, 24);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.SucessMessage = "Save successfully";
            this.btn_save.TabIndex = 1;
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
            this.btn_clear.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_clear.ForeColor = System.Drawing.Color.Black;
            this.btn_clear.HelpUrl = "";
            this.btn_clear.Location = new System.Drawing.Point(392, 24);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.SucessMessage = "";
            this.btn_clear.TabIndex = 0;
            this.btn_clear.Text = "&Clear";
            this.btn_clear.Themes = "Default";
            this.btn_clear.Tooltip = "";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // lst_search
            // 
            this.lst_search.AllowCellToolTip = true;
            this.lst_search.CheckedColumnIndex = -1;
            this.lst_search.CheckedValue = "";
            this.lst_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pLabsListViewColHdr0,
            this.pLabsListViewColHdr3,
            this.pLabsListViewColHdr1,
            this.pLabsListViewColHdr2});
            this.lst_search.DefaultValue = "";
            this.lst_search.EditableColumnIndex = -1;
            this.lst_search.EditableValue = "";
            this.lst_search.Font = new System.Drawing.Font("Arial", 11F);
            this.lst_search.ForeColor = System.Drawing.Color.Black;
            this.lst_search.FullRowSelect = true;
            this.lst_search.GridLines = true;
            this.lst_search.IsMandatory = false;
            this.lst_search.Location = new System.Drawing.Point(2, 118);
            this.lst_search.Name = "lst_search";
            this.lst_search.ReqdChkedValueINXml = false;
            this.lst_search.SchemaRequired = false;
            this.lst_search.ShowContextMenu = false;
            this.lst_search.Size = new System.Drawing.Size(400, 401);
            this.lst_search.TabIndex = 3;
            this.lst_search.Tooltip = "";
            this.lst_search.UseCompatibleStateImageBehavior = false;
            this.lst_search.View = System.Windows.Forms.View.Details;
            this.lst_search.XmlOutPut = PLEnums.XmlOutPutType.AllItems;
            // 
            // pLabsListViewColHdr0
            // 
            this.pLabsListViewColHdr0.DataColumnName = "Salary_id";
            this.pLabsListViewColHdr0.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr0.FormatString = "";
            this.pLabsListViewColHdr0.ReqdForSave = true;
            this.pLabsListViewColHdr0.Resizable = true;
            this.pLabsListViewColHdr0.Text = "ID";
            this.pLabsListViewColHdr0.Width = 0;
            // 
            // pLabsListViewColHdr3
            // 
            this.pLabsListViewColHdr3.DataColumnName = "addr_nam";
            this.pLabsListViewColHdr3.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr3.FormatString = "";
            this.pLabsListViewColHdr3.ReqdForSave = true;
            this.pLabsListViewColHdr3.Resizable = true;
            this.pLabsListViewColHdr3.Text = "Employee Name";
            this.pLabsListViewColHdr3.Width = 150;
            // 
            // pLabsListViewColHdr1
            // 
            this.pLabsListViewColHdr1.DataColumnName = "salary";
            this.pLabsListViewColHdr1.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr1.FormatString = "";
            this.pLabsListViewColHdr1.ReqdForSave = true;
            this.pLabsListViewColHdr1.Resizable = true;
            this.pLabsListViewColHdr1.Text = "Salary";
            this.pLabsListViewColHdr1.Width = 125;
            // 
            // pLabsListViewColHdr2
            // 
            this.pLabsListViewColHdr2.DataColumnName = "inscentive";
            this.pLabsListViewColHdr2.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr2.FormatString = "";
            this.pLabsListViewColHdr2.ReqdForSave = true;
            this.pLabsListViewColHdr2.Resizable = true;
            this.pLabsListViewColHdr2.Text = "Incentive";
            this.pLabsListViewColHdr2.Width = 120;
            // 
            // gob_main
            // 
            this.gob_main.BorderWidth = 1F;
            this.gob_main.Caption = "Create";
            this.gob_main.CaptionImage = null;
            this.gob_main.Controls.Add(this.ddl_employeename);
            this.gob_main.Controls.Add(this.lbl_employeename);
            this.gob_main.Controls.Add(this.lbl_salary);
            this.gob_main.Controls.Add(this.txt_salary);
            this.gob_main.Controls.Add(this.lbl_inscentive);
            this.gob_main.Controls.Add(this.txt_inscentive);
            this.gob_main.CornersRadius = 2;
            this.gob_main.Font = new System.Drawing.Font("Arial", 11F);
            this.gob_main.ForeColor = System.Drawing.Color.Black;
            this.gob_main.HelpUrl = "";
            this.gob_main.Location = new System.Drawing.Point(404, 1);
            this.gob_main.Name = "gob_main";
            this.gob_main.Padding = new System.Windows.Forms.Padding(20);
            this.gob_main.ShadowColor = System.Drawing.Color.DarkGray;
            this.gob_main.Size = new System.Drawing.Size(388, 518);
            this.gob_main.TabIndex = 0;
            this.gob_main.Themes = "Default";
            this.gob_main.Tooltip = "";
            // 
            // ddl_employeename
            // 
            this.ddl_employeename.ControlValue = "";
            this.ddl_employeename.DefaultValue = "";
            this.ddl_employeename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_employeename.ErrorMessage = "Please Enter Employee Name";
            this.ddl_employeename.Font = new System.Drawing.Font("Arial", 11F);
            this.ddl_employeename.ForeColor = System.Drawing.Color.Black;
            this.ddl_employeename.InstructionText = "Select Item";
            this.ddl_employeename.Location = new System.Drawing.Point(142, 27);
            this.ddl_employeename.Name = "ddl_employeename";
            this.ddl_employeename.Size = new System.Drawing.Size(160, 25);
            this.ddl_employeename.SpParameter = "ai_addr_id";
            this.ddl_employeename.TabIndex = 0;
            this.ddl_employeename.Tooltip = "";
            // 
            // lbl_employeename
            // 
            this.lbl_employeename.AutoSize = true;
            this.lbl_employeename.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_employeename.ClearingRequired = false;
            this.lbl_employeename.ControlValue = "Employee Name";
            this.lbl_employeename.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_employeename.IsMandatory = false;
            this.lbl_employeename.Location = new System.Drawing.Point(23, 31);
            this.lbl_employeename.Name = "lbl_employeename";
            this.lbl_employeename.SavingRequired = false;
            this.lbl_employeename.Size = new System.Drawing.Size(116, 17);
            this.lbl_employeename.SmartTab = false;
            this.lbl_employeename.SpParameter = "ai_addr_id";
            this.lbl_employeename.TabIndex = 1;
            this.lbl_employeename.Text = "Employee Name";
            this.lbl_employeename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_employeename.Tooltip = "";
            // 
            // lbl_salary
            // 
            this.lbl_salary.AutoSize = true;
            this.lbl_salary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_salary.ClearingRequired = false;
            this.lbl_salary.ControlValue = "Salary";
            this.lbl_salary.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_salary.IsMandatory = false;
            this.lbl_salary.Location = new System.Drawing.Point(90, 64);
            this.lbl_salary.Name = "lbl_salary";
            this.lbl_salary.SavingRequired = false;
            this.lbl_salary.Size = new System.Drawing.Size(49, 17);
            this.lbl_salary.SmartTab = false;
            this.lbl_salary.SpParameter = "an_salary";
            this.lbl_salary.TabIndex = 2;
            this.lbl_salary.Text = "Salary";
            this.lbl_salary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_salary.Tooltip = "";
            // 
            // txt_salary
            // 
            this.txt_salary.AfterDecimal = 0;
            this.txt_salary.BeforeDecimal = 22;
            this.txt_salary.DataType = PLEnums.TextDataType.General;
            this.txt_salary.DefaultValue = "";
            this.txt_salary.ErrorMessage = "Please Enter Salary";
            this.txt_salary.ForeColor = System.Drawing.Color.Empty;
            this.txt_salary.Location = new System.Drawing.Point(142, 60);
            this.txt_salary.MaxLength = 22;
            this.txt_salary.Name = "txt_salary";
            this.txt_salary.Size = new System.Drawing.Size(160, 24);
            this.txt_salary.SpParameter = "an_salary";
            this.txt_salary.TabIndex = 1;
            this.txt_salary.TextCase = PLEnums.TextDataCase.None;
            this.txt_salary.Tooltip = "";
            this.txt_salary.Watermark = "";
            this.txt_salary.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // lbl_inscentive
            // 
            this.lbl_inscentive.AutoSize = true;
            this.lbl_inscentive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_inscentive.ClearingRequired = false;
            this.lbl_inscentive.ControlValue = "Incentive";
            this.lbl_inscentive.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_inscentive.IsMandatory = false;
            this.lbl_inscentive.Location = new System.Drawing.Point(74, 96);
            this.lbl_inscentive.Name = "lbl_inscentive";
            this.lbl_inscentive.SavingRequired = false;
            this.lbl_inscentive.Size = new System.Drawing.Size(65, 17);
            this.lbl_inscentive.SmartTab = false;
            this.lbl_inscentive.SpParameter = "an_inscentive";
            this.lbl_inscentive.TabIndex = 4;
            this.lbl_inscentive.Text = "Incentive";
            this.lbl_inscentive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_inscentive.Tooltip = "";
            // 
            // txt_inscentive
            // 
            this.txt_inscentive.AfterDecimal = 0;
            this.txt_inscentive.BeforeDecimal = 22;
            this.txt_inscentive.DataType = PLEnums.TextDataType.General;
            this.txt_inscentive.DefaultValue = "";
            this.txt_inscentive.ErrorMessage = "Please Enter Inscentive";
            this.txt_inscentive.ForeColor = System.Drawing.Color.Empty;
            this.txt_inscentive.Location = new System.Drawing.Point(142, 92);
            this.txt_inscentive.MaxLength = 22;
            this.txt_inscentive.Name = "txt_inscentive";
            this.txt_inscentive.Size = new System.Drawing.Size(160, 24);
            this.txt_inscentive.SpParameter = "an_inscentive";
            this.txt_inscentive.TabIndex = 2;
            this.txt_inscentive.TextCase = PLEnums.TextDataCase.None;
            this.txt_inscentive.Tooltip = "";
            this.txt_inscentive.Watermark = "";
            this.txt_inscentive.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // gob_find
            // 
            this.gob_find.BorderWidth = 1F;
            this.gob_find.Caption = "Search";
            this.gob_find.CaptionImage = null;
            this.gob_find.Controls.Add(this.ddl_employeename_F);
            this.gob_find.Controls.Add(this.lbl_employeename_F);
            this.gob_find.Controls.Add(this.lbl_salary_F);
            this.gob_find.Controls.Add(this.txt_salary_F);
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
            this.gob_find.Size = new System.Drawing.Size(400, 115);
            this.gob_find.TabIndex = 2;
            this.gob_find.Themes = "Default";
            this.gob_find.Tooltip = "";
            // 
            // ddl_employeename_F
            // 
            this.ddl_employeename_F.ClearingRequired = false;
            this.ddl_employeename_F.ControlValue = "";
            this.ddl_employeename_F.DefaultValue = "";
            this.ddl_employeename_F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_employeename_F.ErrorMessage = "Please Enter Employee Name";
            this.ddl_employeename_F.Font = new System.Drawing.Font("Arial", 11F);
            this.ddl_employeename_F.ForeColor = System.Drawing.Color.Black;
            this.ddl_employeename_F.InstructionText = "Select Item";
            this.ddl_employeename_F.Location = new System.Drawing.Point(135, 37);
            this.ddl_employeename_F.Name = "ddl_employeename_F";
            this.ddl_employeename_F.SavingRequired = false;
            this.ddl_employeename_F.Size = new System.Drawing.Size(160, 25);
            this.ddl_employeename_F.SpParameter = "ai_addr_id";
            this.ddl_employeename_F.TabIndex = 0;
            this.ddl_employeename_F.Tooltip = "";
            // 
            // lbl_employeename_F
            // 
            this.lbl_employeename_F.AutoSize = true;
            this.lbl_employeename_F.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_employeename_F.ClearingRequired = false;
            this.lbl_employeename_F.ControlValue = "Employee Name";
            this.lbl_employeename_F.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_employeename_F.IsMandatory = false;
            this.lbl_employeename_F.Location = new System.Drawing.Point(16, 41);
            this.lbl_employeename_F.Name = "lbl_employeename_F";
            this.lbl_employeename_F.SavingRequired = false;
            this.lbl_employeename_F.Size = new System.Drawing.Size(116, 17);
            this.lbl_employeename_F.SmartTab = false;
            this.lbl_employeename_F.SpParameter = "ai_addr_id";
            this.lbl_employeename_F.TabIndex = 1;
            this.lbl_employeename_F.Text = "Employee Name";
            this.lbl_employeename_F.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_employeename_F.Tooltip = "";
            // 
            // lbl_salary_F
            // 
            this.lbl_salary_F.AutoSize = true;
            this.lbl_salary_F.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_salary_F.ClearingRequired = false;
            this.lbl_salary_F.ControlValue = "Salary";
            this.lbl_salary_F.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_salary_F.IsMandatory = false;
            this.lbl_salary_F.Location = new System.Drawing.Point(83, 74);
            this.lbl_salary_F.Name = "lbl_salary_F";
            this.lbl_salary_F.SavingRequired = false;
            this.lbl_salary_F.Size = new System.Drawing.Size(49, 17);
            this.lbl_salary_F.SmartTab = false;
            this.lbl_salary_F.SpParameter = "an_salary";
            this.lbl_salary_F.TabIndex = 2;
            this.lbl_salary_F.Text = "Salary";
            this.lbl_salary_F.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_salary_F.Tooltip = "";
            // 
            // txt_salary_F
            // 
            this.txt_salary_F.AfterDecimal = 0;
            this.txt_salary_F.BeforeDecimal = 22;
            this.txt_salary_F.ClearingRequired = false;
            this.txt_salary_F.DataType = PLEnums.TextDataType.General;
            this.txt_salary_F.DefaultValue = "";
            this.txt_salary_F.ErrorMessage = "Please Enter Salary";
            this.txt_salary_F.ForeColor = System.Drawing.Color.Empty;
            this.txt_salary_F.Location = new System.Drawing.Point(135, 70);
            this.txt_salary_F.MaxLength = 22;
            this.txt_salary_F.Name = "txt_salary_F";
            this.txt_salary_F.SavingRequired = false;
            this.txt_salary_F.Size = new System.Drawing.Size(160, 24);
            this.txt_salary_F.SpParameter = "an_salary";
            this.txt_salary_F.TabIndex = 1;
            this.txt_salary_F.TextCase = PLEnums.TextDataCase.None;
            this.txt_salary_F.Tooltip = "";
            this.txt_salary_F.Watermark = "";
            this.txt_salary_F.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // btn_find_F
            // 
            this.btn_find_F.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_find_F.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_find_F.ConfirmationMessage = "";
            this.btn_find_F.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_find_F.ForeColor = System.Drawing.Color.Black;
            this.btn_find_F.HelpUrl = "";
            this.btn_find_F.Location = new System.Drawing.Point(314, 38);
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
            this.btn_clear_F.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_clear_F.ForeColor = System.Drawing.Color.Black;
            this.btn_clear_F.HelpUrl = "";
            this.btn_clear_F.Location = new System.Drawing.Point(314, 65);
            this.btn_clear_F.Name = "btn_clear_F";
            this.btn_clear_F.Size = new System.Drawing.Size(75, 23);
            this.btn_clear_F.SucessMessage = "";
            this.btn_clear_F.TabIndex = 3;
            this.btn_clear_F.Text = "Clea&r";
            this.btn_clear_F.Themes = "Default";
            this.btn_clear_F.Tooltip = "";
            this.btn_clear_F.UseVisualStyleBackColor = false;
            // 
            // ME_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(793, 572);
            this.Controls.Add(this.lst_search);
            this.Controls.Add(this.gob_main);
            this.Controls.Add(this.gob_find);
            this.Controls.Add(this.groupBoxPL1);
            this.FindIDParameter = "ai_salary_id";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ME_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "Salary Master";
            this.groupBoxPL1.ResumeLayout(false);
            this.gob_main.ResumeLayout(false);
            this.gob_main.PerformLayout();
            this.gob_find.ResumeLayout(false);
            this.gob_find.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private PLABSc.Line line1;
        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSb.ButtonPL btn_saveas;
        private PLABSb.ButtonPL btn_close;
        private PLABSb.ButtonPL btn_delete;
        private PLABSb.ButtonPL btn_save;
        private PLABSb.ButtonPL btn_clear;
        private PLABSn .ListViewNormalPL lst_search;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr0;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr1;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr2;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr3;
        private PLABSc.GroupBoxPL gob_main;
        private PLABSn.ComboBoxPL ddl_employeename;
        private PLABSn.LabelPL lbl_employeename;
        private PLABSn.LabelPL lbl_salary;
        private PLABSn.TextBoxPL txt_salary;
        private PLABSn.LabelPL lbl_inscentive;
        private PLABSn.TextBoxPL txt_inscentive;
        private PLABSc.GroupBoxPL gob_find;
        private PLABSn.ComboBoxPL ddl_employeename_F;
        private PLABSn.LabelPL lbl_employeename_F;
        private PLABSn.LabelPL lbl_salary_F;
        private PLABSn.TextBoxPL txt_salary_F;
        private PLABSb.ButtonPL btn_find_F;
        private PLABSb.ButtonPL btn_clear_F; 
	}
}
