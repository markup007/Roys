namespace RoysGold
{
    partial class FL_001
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            PLABSn.PLabsColumnProp pLabsColumnProp1 = new PLABSn.PLabsColumnProp();
            PLABSn.PLabsColumnProp pLabsColumnProp2 = new PLABSn.PLabsColumnProp();
            PLABSn.PLabsColumnProp pLabsColumnProp3 = new PLABSn.PLabsColumnProp();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FL_001));
            this.grd_data = new PLABSn.DataGridViewPL();
            this.txt_date_gv = new PLABSn.PLTextBoxColumn();
            this.txt_headname_gv = new PLABSn.PLTextBoxColumn();
            this.text_desc_gv = new PLABSn.PLTextBoxColumn();
            this.txt_dramt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_cramt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_drwt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_crwt_gv = new PLABSn.PLTextBoxColumn();
            this.fnd_addr = new PLABSn.FindControlPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.labelPL2 = new PLABSn.LabelPL();
            this.labelPL3 = new PLABSn.LabelPL();
            this.btn_load = new PLABSb.ButtonPL();
            this.btn_exit = new PLABSb.ButtonPL();
            this.dtp_to = new PLABSn.DatePickerPL();
            this.dtp_from = new PLABSn.DatePickerPL();
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.groupBoxPL1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grd_data
            // 
            this.grd_data.AllowUserToAddRows = false;
            this.grd_data.AllowUserToDeleteRows = false;
            this.grd_data.BackgroundColor = System.Drawing.Color.White;
            this.grd_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grd_data.CancelRowDelete = false;
            this.grd_data.ClearingRequired = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_date_gv,
            this.txt_headname_gv,
            this.text_desc_gv,
            this.txt_dramt_gv,
            this.txt_cramt_gv,
            this.txt_drwt_gv,
            this.txt_crwt_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(2, 64);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = false;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_data.Size = new System.Drawing.Size(1160, 522);
            this.grd_data.SpParameter = "v_Xmldata";
            this.grd_data.TabIndex = 1;
            this.grd_data.Tooltip = "";
            // 
            // txt_date_gv
            // 
            this.txt_date_gv.AfterDecimal = 0;
            this.txt_date_gv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_date_gv.BeforeDecimal = 0;
            this.txt_date_gv.DataPropertyName = "date";
            this.txt_date_gv.DataType = PLEnums.TextDataType.General;
            this.txt_date_gv.ErrorMessage = "Please Enter A Value";
            this.txt_date_gv.HeaderText = "Date";
            this.txt_date_gv.Name = "txt_date_gv";
            this.txt_date_gv.ReadOnly = true;
            this.txt_date_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_date_gv.TrimRequired = true;
            // 
            // txt_headname_gv
            // 
            this.txt_headname_gv.AfterDecimal = 0;
            this.txt_headname_gv.BeforeDecimal = 0;
            this.txt_headname_gv.DataPropertyName = "name";
            this.txt_headname_gv.DataType = PLEnums.TextDataType.General;
            this.txt_headname_gv.ErrorMessage = "Please Enter A Value";
            this.txt_headname_gv.FillWeight = 125F;
            this.txt_headname_gv.HeaderText = "Head Name";
            this.txt_headname_gv.Name = "txt_headname_gv";
            this.txt_headname_gv.ReadOnly = true;
            this.txt_headname_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_headname_gv.TrimRequired = true;
            this.txt_headname_gv.Width = 200;
            // 
            // text_desc_gv
            // 
            this.text_desc_gv.AfterDecimal = 0;
            this.text_desc_gv.BeforeDecimal = 0;
            this.text_desc_gv.DataPropertyName = "Descr";
            this.text_desc_gv.DataType = PLEnums.TextDataType.General;
            this.text_desc_gv.ErrorMessage = "Please Enter A Value";
            this.text_desc_gv.FillWeight = 150F;
            this.text_desc_gv.HeaderText = "Description";
            this.text_desc_gv.Name = "text_desc_gv";
            this.text_desc_gv.ReadOnly = true;
            this.text_desc_gv.TextCase = PLEnums.TextDataCase.None;
            this.text_desc_gv.TrimRequired = true;
            this.text_desc_gv.Width = 250;
            // 
            // txt_dramt_gv
            // 
            this.txt_dramt_gv.AfterDecimal = 0;
            this.txt_dramt_gv.BeforeDecimal = 0;
            this.txt_dramt_gv.DataPropertyName = "Dramt";
            this.txt_dramt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.txt_dramt_gv.DefaultCellStyle = dataGridViewCellStyle2;
            this.txt_dramt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_dramt_gv.HeaderText = "Dr Amt";
            this.txt_dramt_gv.Name = "txt_dramt_gv";
            this.txt_dramt_gv.ReadOnly = true;
            this.txt_dramt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_dramt_gv.TrimRequired = true;
            this.txt_dramt_gv.Width = 150;
            // 
            // txt_cramt_gv
            // 
            this.txt_cramt_gv.AfterDecimal = 0;
            this.txt_cramt_gv.BeforeDecimal = 0;
            this.txt_cramt_gv.DataPropertyName = "cramt";
            this.txt_cramt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.txt_cramt_gv.DefaultCellStyle = dataGridViewCellStyle3;
            this.txt_cramt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_cramt_gv.HeaderText = "Cr Amt";
            this.txt_cramt_gv.Name = "txt_cramt_gv";
            this.txt_cramt_gv.ReadOnly = true;
            this.txt_cramt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_cramt_gv.TrimRequired = true;
            this.txt_cramt_gv.Width = 150;
            // 
            // txt_drwt_gv
            // 
            this.txt_drwt_gv.AfterDecimal = 0;
            this.txt_drwt_gv.BeforeDecimal = 0;
            this.txt_drwt_gv.DataPropertyName = "drwt";
            this.txt_drwt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.txt_drwt_gv.DefaultCellStyle = dataGridViewCellStyle4;
            this.txt_drwt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_drwt_gv.HeaderText = "Dr Wt";
            this.txt_drwt_gv.Name = "txt_drwt_gv";
            this.txt_drwt_gv.ReadOnly = true;
            this.txt_drwt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_drwt_gv.TrimRequired = true;
            this.txt_drwt_gv.Width = 150;
            // 
            // txt_crwt_gv
            // 
            this.txt_crwt_gv.AfterDecimal = 0;
            this.txt_crwt_gv.BeforeDecimal = 0;
            this.txt_crwt_gv.DataPropertyName = "crwt";
            this.txt_crwt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.txt_crwt_gv.DefaultCellStyle = dataGridViewCellStyle5;
            this.txt_crwt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_crwt_gv.HeaderText = "Cr Wt";
            this.txt_crwt_gv.Name = "txt_crwt_gv";
            this.txt_crwt_gv.ReadOnly = true;
            this.txt_crwt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_crwt_gv.TrimRequired = true;
            this.txt_crwt_gv.Width = 150;
            // 
            // fnd_addr
            // 
            this.fnd_addr.BackColor = System.Drawing.Color.White;
            this.fnd_addr.BorderColor = System.Drawing.Color.Green;
            this.fnd_addr.ButtonBackColor = System.Drawing.Color.Transparent;
            this.fnd_addr.ButtonBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fnd_addr.CodeColumnName = "";
            this.fnd_addr.CodeTxtWidth = 40;
            pLabsColumnProp1.ColumnCaption = "Id";
            pLabsColumnProp1.DataPropertyName = "addr_id";
            pLabsColumnProp1.DataType = PLEnums.ListViewDataTypes.String;
            pLabsColumnProp1.FormatString = "";
            pLabsColumnProp1.ReqdForSave = true;
            pLabsColumnProp1.Resizable = true;
            pLabsColumnProp1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            pLabsColumnProp1.Width = 0;
            pLabsColumnProp2.ColumnCaption = "Smith";
            pLabsColumnProp2.DataPropertyName = "addr_nam";
            pLabsColumnProp2.DataType = PLEnums.ListViewDataTypes.String;
            pLabsColumnProp2.FormatString = "";
            pLabsColumnProp2.ReqdForSave = true;
            pLabsColumnProp2.Resizable = true;
            pLabsColumnProp2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            pLabsColumnProp2.Width = 150;
            pLabsColumnProp3.ColumnCaption = "code";
            pLabsColumnProp3.DataPropertyName = "addr_code";
            pLabsColumnProp3.DataType = PLEnums.ListViewDataTypes.String;
            pLabsColumnProp3.FormatString = "";
            pLabsColumnProp3.ReqdForSave = true;
            pLabsColumnProp3.Resizable = true;
            pLabsColumnProp3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            pLabsColumnProp3.Width = 78;
            this.fnd_addr.Columns.Add(pLabsColumnProp1);
            this.fnd_addr.Columns.Add(pLabsColumnProp2);
            this.fnd_addr.Columns.Add(pLabsColumnProp3);
            this.fnd_addr.ControlValue = "";
            this.fnd_addr.DefaultValue = "";
            this.fnd_addr.DescriptionColumnName = "";
            this.fnd_addr.DescriptionRequired = false;
            this.fnd_addr.ErrorMessage = "Please Select At-Least One Item";
            this.fnd_addr.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.fnd_addr.Font = new System.Drawing.Font("Arial", 11F);
            this.fnd_addr.ForeColor = System.Drawing.Color.Black;
            this.fnd_addr.GridHeight = 300;
            this.fnd_addr.GridWidth = 250;
            this.fnd_addr.ImageType = PLEnums.ControlSearchType.Search;
            this.fnd_addr.ListViewName = "";
            this.fnd_addr.Location = new System.Drawing.Point(147, 17);
            this.fnd_addr.Name = "fnd_addr";
            this.fnd_addr.ParentCell = null;
            this.fnd_addr.SelectedCode = "";
            this.fnd_addr.SelectedColumnColor = System.Drawing.Color.LightGray;
            this.fnd_addr.SelectedDescription = "";
            this.fnd_addr.SelectedValue = "";
            this.fnd_addr.Size = new System.Drawing.Size(160, 23);
            this.fnd_addr.SpParameter = "ai_smth_id";
            this.fnd_addr.TabIndex = 1;
            this.fnd_addr.Tooltip = "";
            this.fnd_addr.ValueColumnName = "";
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "Head Name";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(56, 20);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(85, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 2;
            this.labelPL1.Text = "Head Name";
            this.labelPL1.Tooltip = "";
            // 
            // labelPL2
            // 
            this.labelPL2.AutoSize = true;
            this.labelPL2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL2.ClearingRequired = false;
            this.labelPL2.ControlValue = "From";
            this.labelPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL2.IsMandatory = false;
            this.labelPL2.Location = new System.Drawing.Point(440, 20);
            this.labelPL2.Name = "labelPL2";
            this.labelPL2.SavingRequired = false;
            this.labelPL2.Size = new System.Drawing.Size(43, 17);
            this.labelPL2.SmartTab = false;
            this.labelPL2.TabIndex = 5;
            this.labelPL2.Text = "From";
            this.labelPL2.Tooltip = "";
            // 
            // labelPL3
            // 
            this.labelPL3.AutoSize = true;
            this.labelPL3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL3.ClearingRequired = false;
            this.labelPL3.ControlValue = "To";
            this.labelPL3.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL3.IsMandatory = false;
            this.labelPL3.Location = new System.Drawing.Point(458, 49);
            this.labelPL3.Name = "labelPL3";
            this.labelPL3.SavingRequired = false;
            this.labelPL3.Size = new System.Drawing.Size(23, 17);
            this.labelPL3.SmartTab = false;
            this.labelPL3.TabIndex = 6;
            this.labelPL3.Text = "To";
            this.labelPL3.Tooltip = "";
            // 
            // btn_load
            // 
            this.btn_load.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_load.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_load.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_load.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_load.ConfirmationMessage = "";
            this.btn_load.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_load.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_load.ForeColor = System.Drawing.Color.Black;
            this.btn_load.HelpUrl = "";
            this.btn_load.Location = new System.Drawing.Point(1062, 13);
            this.btn_load.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_load.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.SucessMessage = "";
            this.btn_load.TabIndex = 7;
            this.btn_load.Text = "&Load";
            this.btn_load.Themes = "Default";
            this.btn_load.Tooltip = "";
            this.btn_load.UseVisualStyleBackColor = false;
            // 
            // btn_exit
            // 
            this.btn_exit.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_exit.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_exit.ButtonType = PLEnums.ButtonTypes.Exit;
            this.btn_exit.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_exit.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_exit.ConfirmationMessage = "";
            this.btn_exit.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.HelpUrl = "";
            this.btn_exit.Location = new System.Drawing.Point(1062, 38);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 8;
            this.btn_exit.Text = "&Exit";
            this.btn_exit.Themes = "Default";
            this.btn_exit.Tooltip = "";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // dtp_to
            // 
            this.dtp_to.BackColor = System.Drawing.Color.White;
            this.dtp_to.BorderRequired = false;
            this.dtp_to.ControlValue = "15-Sep-2011";
            this.dtp_to.DefaultValue = "";
            this.dtp_to.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.dtp_to.Font = new System.Drawing.Font("Arial", 11F);
            this.dtp_to.ForeColor = System.Drawing.Color.Black;
            this.dtp_to.Location = new System.Drawing.Point(486, 42);
            this.dtp_to.MaximumSize = new System.Drawing.Size(150, 22);
            this.dtp_to.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(150, 22);
            this.dtp_to.SpParameter = "ad_to";
            this.dtp_to.TabIndex = 4;
            this.dtp_to.Tooltip = "";
            this.dtp_to.Value = new System.DateTime(2011, 9, 15, 0, 0, 0, 0);
            // 
            // dtp_from
            // 
            this.dtp_from.BackColor = System.Drawing.Color.White;
            this.dtp_from.BorderRequired = false;
            this.dtp_from.ControlValue = "15-Sep-2011";
            this.dtp_from.DefaultValue = "";
            this.dtp_from.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.dtp_from.Font = new System.Drawing.Font("Arial", 11F);
            this.dtp_from.ForeColor = System.Drawing.Color.Black;
            this.dtp_from.Location = new System.Drawing.Point(486, 17);
            this.dtp_from.MaximumSize = new System.Drawing.Size(150, 22);
            this.dtp_from.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(150, 22);
            this.dtp_from.SpParameter = "ad_from";
            this.dtp_from.TabIndex = 3;
            this.dtp_from.Tooltip = "";
            this.dtp_from.Value = new System.DateTime(2011, 9, 15, 0, 0, 0, 0);
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.dtp_to);
            this.groupBoxPL1.Controls.Add(this.dtp_from);
            this.groupBoxPL1.Controls.Add(this.btn_exit);
            this.groupBoxPL1.Controls.Add(this.btn_load);
            this.groupBoxPL1.Controls.Add(this.labelPL3);
            this.groupBoxPL1.Controls.Add(this.labelPL2);
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.Controls.Add(this.fnd_addr);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(2, -8);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(1160, 69);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // FL_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(1165, 589);
            this.Controls.Add(this.grd_data);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FL_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "Ledger";
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSn.DataGridViewPL grd_data;
        private PLABSn.PLTextBoxColumn txt_date_gv;
        private PLABSn.PLTextBoxColumn txt_headname_gv;
        private PLABSn.PLTextBoxColumn text_desc_gv;
        private PLABSn.PLTextBoxColumn txt_dramt_gv;
        private PLABSn.PLTextBoxColumn txt_cramt_gv;
        private PLABSn.PLTextBoxColumn txt_drwt_gv;
        private PLABSn.PLTextBoxColumn txt_crwt_gv;
        private PLABSn.FindControlPL fnd_addr;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.LabelPL labelPL2;
        private PLABSn.LabelPL labelPL3;
        private PLABSb.ButtonPL btn_load;
        private PLABSb.ButtonPL btn_exit;
        private PLABSn.DatePickerPL dtp_to;
        private PLABSn.DatePickerPL dtp_from;
        private PLABSc.GroupBoxPL groupBoxPL1;
    }
}