namespace RoysGold
{
    partial class AF_001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AF_001));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.dtp_curdate = new PLABSn.DatePickerPL();
            this.btn_clear = new PLABSb.ButtonPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.txt_id_gv = new PLABSn.PLTextBoxColumn();
            this.txt_name_gv = new PLABSn.PLTextBoxColumn();
            this.ddl_type_gv = new PLABSn.PLComboxBoxColumn();
            this.txt_dsc_gv = new PLABSn.PLTextBoxColumn();
            this.btn_prev = new PLABSb.ButtonPL();
            this.btn_next = new PLABSb.ButtonPL();
            this.groupBoxPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.btn_next);
            this.groupBoxPL1.Controls.Add(this.btn_prev);
            this.groupBoxPL1.Controls.Add(this.dtp_curdate);
            this.groupBoxPL1.Controls.Add(this.btn_clear);
            this.groupBoxPL1.Controls.Add(this.btn_save);
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.Controls.Add(this.grd_data);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(661, 462);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // dtp_curdate
            // 
            this.dtp_curdate.AutoSize = true;
            this.dtp_curdate.BackColor = System.Drawing.Color.White;
            this.dtp_curdate.BorderRequired = false;
            this.dtp_curdate.ClearingRequired = false;
            this.dtp_curdate.ControlValue = "23-Feb-2012";
            this.dtp_curdate.DefaultValue = "";
            this.dtp_curdate.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.dtp_curdate.Font = new System.Drawing.Font("Arial", 11F);
            this.dtp_curdate.ForeColor = System.Drawing.Color.Black;
            this.dtp_curdate.Location = new System.Drawing.Point(246, 29);
            this.dtp_curdate.MaximumSize = new System.Drawing.Size(105, 22);
            this.dtp_curdate.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtp_curdate.Name = "dtp_curdate";
            this.dtp_curdate.Size = new System.Drawing.Size(105, 22);
            this.dtp_curdate.SpParameter = "ad_date";
            this.dtp_curdate.TabIndex = 1;
            this.dtp_curdate.Tooltip = "";
            this.dtp_curdate.Value = new System.DateTime(2012, 2, 23, 0, 0, 0, 0);
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
            this.btn_clear.Location = new System.Drawing.Point(581, 29);
            this.btn_clear.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_clear.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.SucessMessage = "";
            this.btn_clear.TabIndex = 4;
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
            this.btn_save.ConfirmationMessage = "";
            this.btn_save.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.HelpUrl = "";
            this.btn_save.Location = new System.Drawing.Point(503, 29);
            this.btn_save.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_save.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.SucessMessage = "";
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "&Save";
            this.btn_save.Themes = "Default";
            this.btn_save.Tooltip = "";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "Date";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(201, 32);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(39, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 2;
            this.labelPL1.Text = "Date";
            this.labelPL1.Tooltip = "";
            // 
            // grd_data
            // 
            this.grd_data.AllowUserToAddRows = false;
            this.grd_data.BackgroundColor = System.Drawing.Color.White;
            this.grd_data.CancelRowDelete = false;
            this.grd_data.ClearingRequired = false;
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
            this.txt_name_gv,
            this.ddl_type_gv,
            this.txt_dsc_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(3, 68);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.SavingRequired = false;
            this.grd_data.Size = new System.Drawing.Size(656, 389);
            this.grd_data.SpParameter = "v_xmlData";
            this.grd_data.TabIndex = 0;
            this.grd_data.Tooltip = "";
            // 
            // txt_id_gv
            // 
            this.txt_id_gv.AfterDecimal = 0;
            this.txt_id_gv.BeforeDecimal = 0;
            this.txt_id_gv.DataPropertyName = "id";
            this.txt_id_gv.DataType = PLEnums.TextDataType.General;
            this.txt_id_gv.ErrorMessage = "Please Enter A Value";
            this.txt_id_gv.HeaderText = "id";
            this.txt_id_gv.Name = "txt_id_gv";
            this.txt_id_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_id_gv.TrimRequired = true;
            this.txt_id_gv.Visible = false;
            // 
            // txt_name_gv
            // 
            this.txt_name_gv.AfterDecimal = 0;
            this.txt_name_gv.BeforeDecimal = 0;
            this.txt_name_gv.DataPropertyName = "nam";
            this.txt_name_gv.DataType = PLEnums.TextDataType.General;
            this.txt_name_gv.ErrorMessage = "Please Enter A Value";
            this.txt_name_gv.HeaderText = "NAME";
            this.txt_name_gv.Name = "txt_name_gv";
            this.txt_name_gv.ReadOnly = true;
            this.txt_name_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_name_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_name_gv.TrimRequired = true;
            this.txt_name_gv.Width = 200;
            // 
            // ddl_type_gv
            // 
            this.ddl_type_gv.DataPropertyName = "typ";
            this.ddl_type_gv.ErrorMessage = "Please Enter A Value";
            this.ddl_type_gv.HeaderText = "TYPE";
            this.ddl_type_gv.Name = "ddl_type_gv";
            this.ddl_type_gv.Width = 125;
            // 
            // txt_dsc_gv
            // 
            this.txt_dsc_gv.AfterDecimal = 0;
            this.txt_dsc_gv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_dsc_gv.BeforeDecimal = 0;
            this.txt_dsc_gv.DataPropertyName = "dsc";
            this.txt_dsc_gv.DataType = PLEnums.TextDataType.General;
            this.txt_dsc_gv.ErrorMessage = "Please Enter A Value";
            this.txt_dsc_gv.HeaderText = "DESCRIPTION";
            this.txt_dsc_gv.Name = "txt_dsc_gv";
            this.txt_dsc_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_dsc_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_dsc_gv.TrimRequired = true;
            // 
            // btn_prev
            // 
            this.btn_prev.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_prev.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_prev.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_prev.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_prev.ConfirmationMessage = "";
            this.btn_prev.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_prev.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_prev.ForeColor = System.Drawing.Color.Black;
            this.btn_prev.HelpUrl = "";
            this.btn_prev.Location = new System.Drawing.Point(100, 29);
            this.btn_prev.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_prev.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(75, 23);
            this.btn_prev.SucessMessage = "";
            this.btn_prev.TabIndex = 5;
            this.btn_prev.Text = "Prev";
            this.btn_prev.Themes = "Default";
            this.btn_prev.Tooltip = "";
            this.btn_prev.UseVisualStyleBackColor = false;
            // 
            // btn_next
            // 
            this.btn_next.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_next.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_next.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_next.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_next.ConfirmationMessage = "";
            this.btn_next.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_next.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_next.ForeColor = System.Drawing.Color.Black;
            this.btn_next.HelpUrl = "";
            this.btn_next.Location = new System.Drawing.Point(9, 30);
            this.btn_next.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_next.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.SucessMessage = "";
            this.btn_next.TabIndex = 6;
            this.btn_next.Text = "Next";
            this.btn_next.Themes = "Default";
            this.btn_next.Tooltip = "";
            this.btn_next.UseVisualStyleBackColor = false;
            // 
            // AF_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(663, 454);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "AF_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "AF_001";
            this.ValueChangedStatus = true;
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.DatePickerPL dtp_curdate;
        private PLABSn.DataGridViewPL grd_data;
        private PLABSb.ButtonPL btn_save;
        private PLABSn.LabelPL labelPL1;
        private PLABSb.ButtonPL btn_clear;
        private PLABSn.PLTextBoxColumn txt_id_gv;
        private PLABSn.PLTextBoxColumn txt_name_gv;
        private PLABSn.PLComboxBoxColumn ddl_type_gv;
        private PLABSn.PLTextBoxColumn txt_dsc_gv;
        private PLABSb.ButtonPL btn_next;
        private PLABSb.ButtonPL btn_prev;
    }
}