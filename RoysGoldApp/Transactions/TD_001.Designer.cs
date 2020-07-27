namespace RoysGold
{
    partial class TD_001
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TD_001));
            this.tb_main = new PLABSc.TabControlPL();
            this.tp_sheetitem = new System.Windows.Forms.TabPage();
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.txt_id_gv = new PLABSn.PLTextBoxColumn();
            this.chk_delete_gv = new PLABSn.PLCheckBoxColumn();
            this.txt_date_gv = new PLABSn.PLTextBoxColumn();
            this.cmb_item_gv = new PLABSn.PLComboxBoxColumn();
            this.txt_description_gv = new PLABSn.PLTextBoxColumn();
            this.txt_drwt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_crwt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_sqldate_gv = new PLABSn.PLTextBoxColumn();
            this.txt_status_gv = new PLABSn.PLTextBoxColumn();
            this.groupBoxPL2 = new PLABSc.GroupBoxPL();
            this.lbl_balance = new System.Windows.Forms.Label();
            this.btn_exit = new PLABSb.ButtonPL();
            this.btn_delete = new PLABSb.ButtonPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.tp_sheetcash = new System.Windows.Forms.TabPage();
            this.grd_datacash = new PLABSn.DataGridViewPL();
            this.txt_data_gvcash = new PLABSn.PLTextBoxColumn();
            this.txt_name_gvcash = new PLABSn.PLTextBoxColumn();
            this.txt_payment_gvcash = new PLABSn.PLTextBoxColumn();
            this.txt_reciept = new PLABSn.PLTextBoxColumn();
            this.btn_refrsh = new PLABSb.ButtonPL();
            this.tb_main.SuspendLayout();
            this.tp_sheetitem.SuspendLayout();
            this.groupBoxPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.groupBoxPL2.SuspendLayout();
            this.tp_sheetcash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_datacash)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_main
            // 
            this.tb_main.Controls.Add(this.tp_sheetitem);
            this.tb_main.Controls.Add(this.tp_sheetcash);
            this.tb_main.Location = new System.Drawing.Point(1, 4);
            this.tb_main.Margin = new System.Windows.Forms.Padding(4);
            this.tb_main.Name = "tb_main";
            this.tb_main.SelectedIndex = 0;
            this.tb_main.Size = new System.Drawing.Size(1292, 638);
            this.tb_main.TabIndex = 3;
            // 
            // tp_sheetitem
            // 
            this.tp_sheetitem.Controls.Add(this.groupBoxPL1);
            this.tp_sheetitem.Controls.Add(this.groupBoxPL2);
            this.tp_sheetitem.Location = new System.Drawing.Point(4, 25);
            this.tp_sheetitem.Margin = new System.Windows.Forms.Padding(4);
            this.tp_sheetitem.Name = "tp_sheetitem";
            this.tp_sheetitem.Padding = new System.Windows.Forms.Padding(4);
            this.tp_sheetitem.Size = new System.Drawing.Size(1284, 609);
            this.tp_sheetitem.TabIndex = 0;
            this.tp_sheetitem.Text = "SHEET ITEM";
            this.tp_sheetitem.UseVisualStyleBackColor = true;
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.grd_data);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(4, -9);
            this.groupBoxPL1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(1275, 553);
            this.groupBoxPL1.TabIndex = 6;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // grd_data
            // 
            this.grd_data.AllowUserToDeleteRows = false;
            this.grd_data.BackgroundColor = System.Drawing.Color.White;
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
            this.txt_id_gv,
            this.chk_delete_gv,
            this.txt_date_gv,
            this.cmb_item_gv,
            this.txt_description_gv,
            this.txt_drwt_gv,
            this.txt_crwt_gv,
            this.txt_sqldate_gv,
            this.txt_status_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(3, 16);
            this.grd_data.Margin = new System.Windows.Forms.Padding(4);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grd_data.Size = new System.Drawing.Size(1271, 537);
            this.grd_data.SpParameter = "v_Xmldata";
            this.grd_data.TabIndex = 5;
            this.grd_data.Tooltip = "";
            // 
            // txt_id_gv
            // 
            this.txt_id_gv.AfterDecimal = 0;
            this.txt_id_gv.BeforeDecimal = 0;
            this.txt_id_gv.DataPropertyName = "id";
            this.txt_id_gv.DataType = PLEnums.TextDataType.General;
            this.txt_id_gv.ErrorMessage = "Please Enter A Value";
            this.txt_id_gv.HeaderText = "Id";
            this.txt_id_gv.Name = "txt_id_gv";
            this.txt_id_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_id_gv.TrimRequired = true;
            this.txt_id_gv.Visible = false;
            // 
            // chk_delete_gv
            // 
            this.chk_delete_gv.DataPropertyName = "chk";
            this.chk_delete_gv.ErrorMessage = "Please Enter A Value";
            this.chk_delete_gv.FalseValue = "0";
            this.chk_delete_gv.HeaderText = "Select";
            this.chk_delete_gv.Name = "chk_delete_gv";
            this.chk_delete_gv.TrueValue = "1";
            this.chk_delete_gv.Width = 50;
            // 
            // txt_date_gv
            // 
            this.txt_date_gv.AfterDecimal = 0;
            this.txt_date_gv.BeforeDecimal = 0;
            this.txt_date_gv.DataPropertyName = "dt";
            this.txt_date_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.txt_date_gv.DefaultCellStyle = dataGridViewCellStyle2;
            this.txt_date_gv.ErrorMessage = "Please Enter A Value";
            this.txt_date_gv.HeaderText = "Date";
            this.txt_date_gv.Name = "txt_date_gv";
            this.txt_date_gv.ReadOnly = true;
            this.txt_date_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_date_gv.TrimRequired = true;
            // 
            // cmb_item_gv
            // 
            this.cmb_item_gv.DataPropertyName = "itm_id";
            this.cmb_item_gv.ErrorMessage = "Please Enter A Value";
            this.cmb_item_gv.HeaderText = "Item";
            this.cmb_item_gv.Name = "cmb_item_gv";
            this.cmb_item_gv.Width = 200;
            // 
            // txt_description_gv
            // 
            this.txt_description_gv.AfterDecimal = 0;
            this.txt_description_gv.BeforeDecimal = 0;
            this.txt_description_gv.DataPropertyName = "Descr";
            this.txt_description_gv.DataType = PLEnums.TextDataType.General;
            this.txt_description_gv.ErrorMessage = "Please Enter A Value";
            this.txt_description_gv.HeaderText = "Description";
            this.txt_description_gv.Name = "txt_description_gv";
            this.txt_description_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_description_gv.TrimRequired = true;
            this.txt_description_gv.Width = 300;
            // 
            // txt_drwt_gv
            // 
            this.txt_drwt_gv.AfterDecimal = 0;
            this.txt_drwt_gv.BeforeDecimal = 0;
            this.txt_drwt_gv.DataPropertyName = "Dr";
            this.txt_drwt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "N3";
            this.txt_drwt_gv.DefaultCellStyle = dataGridViewCellStyle3;
            this.txt_drwt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_drwt_gv.HeaderText = "Payment(+)";
            this.txt_drwt_gv.Name = "txt_drwt_gv";
            this.txt_drwt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_drwt_gv.TrimRequired = true;
            this.txt_drwt_gv.Width = 150;
            // 
            // txt_crwt_gv
            // 
            this.txt_crwt_gv.AfterDecimal = 0;
            this.txt_crwt_gv.BeforeDecimal = 0;
            this.txt_crwt_gv.DataPropertyName = "Cr";
            this.txt_crwt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N3";
            this.txt_crwt_gv.DefaultCellStyle = dataGridViewCellStyle4;
            this.txt_crwt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_crwt_gv.HeaderText = "Receipt(-)";
            this.txt_crwt_gv.Name = "txt_crwt_gv";
            this.txt_crwt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_crwt_gv.TrimRequired = true;
            this.txt_crwt_gv.Width = 150;
            // 
            // txt_sqldate_gv
            // 
            this.txt_sqldate_gv.AfterDecimal = 0;
            this.txt_sqldate_gv.BeforeDecimal = 0;
            this.txt_sqldate_gv.DataPropertyName = "sqldate";
            this.txt_sqldate_gv.DataType = PLEnums.TextDataType.General;
            this.txt_sqldate_gv.ErrorMessage = "Please Enter A Value";
            this.txt_sqldate_gv.HeaderText = "SqlDate";
            this.txt_sqldate_gv.Name = "txt_sqldate_gv";
            this.txt_sqldate_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_sqldate_gv.TrimRequired = true;
            this.txt_sqldate_gv.Visible = false;
            // 
            // txt_status_gv
            // 
            this.txt_status_gv.AfterDecimal = 0;
            this.txt_status_gv.BeforeDecimal = 0;
            this.txt_status_gv.DataPropertyName = "stas";
            this.txt_status_gv.DataType = PLEnums.TextDataType.General;
            this.txt_status_gv.ErrorMessage = "Please Enter A Value";
            this.txt_status_gv.HeaderText = "Status";
            this.txt_status_gv.Name = "txt_status_gv";
            this.txt_status_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_status_gv.TrimRequired = true;
            this.txt_status_gv.Visible = false;
            // 
            // groupBoxPL2
            // 
            this.groupBoxPL2.BorderWidth = 1F;
            this.groupBoxPL2.Caption = "";
            this.groupBoxPL2.CaptionImage = null;
            this.groupBoxPL2.Controls.Add(this.lbl_balance);
            this.groupBoxPL2.Controls.Add(this.btn_exit);
            this.groupBoxPL2.Controls.Add(this.btn_delete);
            this.groupBoxPL2.Controls.Add(this.btn_save);
            this.groupBoxPL2.CornersRadius = 2;
            this.groupBoxPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL2.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL2.HelpUrl = "";
            this.groupBoxPL2.Location = new System.Drawing.Point(3, 533);
            this.groupBoxPL2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxPL2.Name = "groupBoxPL2";
            this.groupBoxPL2.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.groupBoxPL2.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL2.Size = new System.Drawing.Size(1275, 71);
            this.groupBoxPL2.TabIndex = 7;
            this.groupBoxPL2.Themes = "Default";
            this.groupBoxPL2.Tooltip = "";
            // 
            // lbl_balance
            // 
            this.lbl_balance.AutoSize = true;
            this.lbl_balance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_balance.Location = new System.Drawing.Point(546, 34);
            this.lbl_balance.Name = "lbl_balance";
            this.lbl_balance.Size = new System.Drawing.Size(0, 26);
            this.lbl_balance.TabIndex = 3;
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
            this.btn_exit.Location = new System.Drawing.Point(1165, 28);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(100, 28);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "&Exit";
            this.btn_exit.Themes = "Default";
            this.btn_exit.Tooltip = "";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            this.btn_delete.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_delete.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_delete.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_delete.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_delete.ConfirmationMessage = "";
            this.btn_delete.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_delete.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.HelpUrl = "";
            this.btn_delete.Location = new System.Drawing.Point(1061, 28);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4);
            this.btn_delete.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_delete.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(100, 28);
            this.btn_delete.SucessMessage = "";
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "&Delete";
            this.btn_delete.Themes = "Default";
            this.btn_delete.Tooltip = "";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_save.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_save.ButtonType = PLEnums.ButtonTypes.Save;
            this.btn_save.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_save.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_save.ConfirmationMessage = "";
            this.btn_save.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.HelpUrl = "";
            this.btn_save.Location = new System.Drawing.Point(957, 28);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_save.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(100, 28);
            this.btn_save.SucessMessage = "";
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "&Save";
            this.btn_save.Themes = "Default";
            this.btn_save.Tooltip = "";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // tp_sheetcash
            // 
            this.tp_sheetcash.Controls.Add(this.grd_datacash);
            this.tp_sheetcash.Location = new System.Drawing.Point(4, 25);
            this.tp_sheetcash.Margin = new System.Windows.Forms.Padding(4);
            this.tp_sheetcash.Name = "tp_sheetcash";
            this.tp_sheetcash.Padding = new System.Windows.Forms.Padding(4);
            this.tp_sheetcash.Size = new System.Drawing.Size(1284, 609);
            this.tp_sheetcash.TabIndex = 1;
            this.tp_sheetcash.Text = "SHEET CASH";
            this.tp_sheetcash.UseVisualStyleBackColor = true;
            // 
            // grd_datacash
            // 
            this.grd_datacash.AllowUserToAddRows = false;
            this.grd_datacash.AllowUserToDeleteRows = false;
            this.grd_datacash.BackgroundColor = System.Drawing.Color.White;
            this.grd_datacash.CancelRowDelete = false;
            this.grd_datacash.ClearingRequired = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_datacash.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grd_datacash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_datacash.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_data_gvcash,
            this.txt_name_gvcash,
            this.txt_payment_gvcash,
            this.txt_reciept});
            this.grd_datacash.ControlValue = "<ResultDS></ResultDS>";
            this.grd_datacash.EnableHeadersVisualStyles = false;
            this.grd_datacash.ErrorMessage = "Please Enter At-least One Record";
            this.grd_datacash.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_datacash.IsMandatory = true;
            this.grd_datacash.Location = new System.Drawing.Point(192, 7);
            this.grd_datacash.Margin = new System.Windows.Forms.Padding(4);
            this.grd_datacash.Name = "grd_datacash";
            this.grd_datacash.ReqdContextMenu = true;
            this.grd_datacash.RowHeadersVisible = false;
            this.grd_datacash.SavingRequired = false;
            this.grd_datacash.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_datacash.Size = new System.Drawing.Size(833, 592);
            this.grd_datacash.SpParameter = "as";
            this.grd_datacash.TabIndex = 0;
            this.grd_datacash.Tooltip = "";
            // 
            // txt_data_gvcash
            // 
            this.txt_data_gvcash.AfterDecimal = 0;
            this.txt_data_gvcash.BeforeDecimal = 0;
            this.txt_data_gvcash.DataPropertyName = "date";
            this.txt_data_gvcash.DataType = PLEnums.TextDataType.General;
            this.txt_data_gvcash.ErrorMessage = "Please Enter A Value";
            this.txt_data_gvcash.HeaderText = "Date";
            this.txt_data_gvcash.Name = "txt_data_gvcash";
            this.txt_data_gvcash.ReadOnly = true;
            this.txt_data_gvcash.TextCase = PLEnums.TextDataCase.None;
            this.txt_data_gvcash.TrimRequired = true;
            // 
            // txt_name_gvcash
            // 
            this.txt_name_gvcash.AfterDecimal = 0;
            this.txt_name_gvcash.BeforeDecimal = 0;
            this.txt_name_gvcash.DataPropertyName = "name";
            this.txt_name_gvcash.DataType = PLEnums.TextDataType.General;
            this.txt_name_gvcash.ErrorMessage = "Please Enter A Value";
            this.txt_name_gvcash.HeaderText = "Name";
            this.txt_name_gvcash.Name = "txt_name_gvcash";
            this.txt_name_gvcash.ReadOnly = true;
            this.txt_name_gvcash.TextCase = PLEnums.TextDataCase.None;
            this.txt_name_gvcash.TrimRequired = true;
            this.txt_name_gvcash.Width = 200;
            // 
            // txt_payment_gvcash
            // 
            this.txt_payment_gvcash.AfterDecimal = 0;
            this.txt_payment_gvcash.BeforeDecimal = 0;
            this.txt_payment_gvcash.DataPropertyName = "dr";
            this.txt_payment_gvcash.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.txt_payment_gvcash.DefaultCellStyle = dataGridViewCellStyle6;
            this.txt_payment_gvcash.ErrorMessage = "Please Enter A Value";
            this.txt_payment_gvcash.HeaderText = "Payment";
            this.txt_payment_gvcash.Name = "txt_payment_gvcash";
            this.txt_payment_gvcash.ReadOnly = true;
            this.txt_payment_gvcash.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_payment_gvcash.TextCase = PLEnums.TextDataCase.None;
            this.txt_payment_gvcash.TrimRequired = true;
            this.txt_payment_gvcash.Width = 150;
            // 
            // txt_reciept
            // 
            this.txt_reciept.AfterDecimal = 0;
            this.txt_reciept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_reciept.BeforeDecimal = 0;
            this.txt_reciept.DataPropertyName = "cr";
            this.txt_reciept.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.txt_reciept.DefaultCellStyle = dataGridViewCellStyle7;
            this.txt_reciept.ErrorMessage = "Please Enter A Value";
            this.txt_reciept.HeaderText = "Reciept";
            this.txt_reciept.Name = "txt_reciept";
            this.txt_reciept.ReadOnly = true;
            this.txt_reciept.TextCase = PLEnums.TextDataCase.None;
            this.txt_reciept.TrimRequired = true;
            // 
            // btn_refrsh
            // 
            this.btn_refrsh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_refrsh.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_refrsh.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_refrsh.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_refrsh.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_refrsh.ConfirmationMessage = "";
            this.btn_refrsh.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_refrsh.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_refrsh.ForeColor = System.Drawing.Color.Black;
            this.btn_refrsh.HelpUrl = "";
            this.btn_refrsh.Image = global::RoysGold.Properties.Resources.refresh1;
            this.btn_refrsh.Location = new System.Drawing.Point(1253, 0);
            this.btn_refrsh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_refrsh.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_refrsh.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_refrsh.Name = "btn_refrsh";
            this.btn_refrsh.Size = new System.Drawing.Size(31, 28);
            this.btn_refrsh.SucessMessage = "";
            this.btn_refrsh.TabIndex = 18;
            this.btn_refrsh.Text = "";
            this.btn_refrsh.Themes = "Default";
            this.btn_refrsh.Tooltip = "";
            this.btn_refrsh.UseVisualStyleBackColor = false;
            // 
            // TD_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(1291, 641);
            this.Controls.Add(this.btn_refrsh);
            this.Controls.Add(this.tb_main);
            this.FindIDParameter = "ai_display_id";
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "TD_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "Display";
            this.tb_main.ResumeLayout(false);
            this.tp_sheetitem.ResumeLayout(false);
            this.groupBoxPL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.groupBoxPL2.ResumeLayout(false);
            this.groupBoxPL2.PerformLayout();
            this.tp_sheetcash.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_datacash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.TabControlPL tb_main;
        private System.Windows.Forms.TabPage tp_sheetitem;
        private System.Windows.Forms.TabPage tp_sheetcash;
        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.DataGridViewPL grd_data;
        private PLABSn.DataGridViewPL grd_datacash;
        private PLABSc.GroupBoxPL groupBoxPL2;
        private PLABSb.ButtonPL btn_exit;
        private PLABSb.ButtonPL btn_delete;
        private PLABSb.ButtonPL btn_save;
        private PLABSn.PLTextBoxColumn txt_data_gvcash;
        private PLABSn.PLTextBoxColumn txt_name_gvcash;
        private PLABSn.PLTextBoxColumn txt_payment_gvcash;
        private PLABSn.PLTextBoxColumn txt_reciept;
        private PLABSb.ButtonPL btn_refrsh;
        private PLABSn.PLTextBoxColumn txt_id_gv;
        private PLABSn.PLCheckBoxColumn chk_delete_gv;
        private PLABSn.PLTextBoxColumn txt_date_gv;
        private PLABSn.PLComboxBoxColumn cmb_item_gv;
        private PLABSn.PLTextBoxColumn txt_description_gv;
        private PLABSn.PLTextBoxColumn txt_drwt_gv;
        private PLABSn.PLTextBoxColumn txt_crwt_gv;
        private PLABSn.PLTextBoxColumn txt_sqldate_gv;
        private PLABSn.PLTextBoxColumn txt_status_gv;
        private System.Windows.Forms.Label lbl_balance;
    }
}