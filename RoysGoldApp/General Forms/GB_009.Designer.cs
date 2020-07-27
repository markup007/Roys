namespace RoysGold
{
    partial class GB_009
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GB_009));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.btn_delete = new PLABSb.ButtonPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.txt_fileName = new PLABSn.TextBoxPL();
            this.btn_bckups = new PLABSb.ButtonPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.txt_id_gv = new PLABSn.PLTextBoxColumn();
            this.txt_date_gv = new PLABSn.PLTextBoxColumn();
            this.txt_name_gv = new PLABSn.PLTextBoxColumn();
            this.btn_restore_gv = new PLABSn.PLButtonColumn();
            this.groupBoxPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.btn_delete);
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.Controls.Add(this.txt_fileName);
            this.groupBoxPL1.Controls.Add(this.btn_bckups);
            this.groupBoxPL1.Controls.Add(this.grd_data);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(542, 343);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // btn_delete
            // 
            this.btn_delete.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_delete.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_delete.ButtonType = PLEnums.ButtonTypes.Delete;
            this.btn_delete.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_delete.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_delete.ConfirmationMessage = "";
            this.btn_delete.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_delete.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.HelpUrl = "";
            this.btn_delete.Location = new System.Drawing.Point(462, 309);
            this.btn_delete.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_delete.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.SucessMessage = "";
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "Delete";
            this.btn_delete.Themes = "Default";
            this.btn_delete.Tooltip = "";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "File Name";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(163, 313);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(74, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 4;
            this.labelPL1.Text = "File Name";
            this.labelPL1.Tooltip = "";
            // 
            // txt_fileName
            // 
            this.txt_fileName.AfterDecimal = 2;
            this.txt_fileName.BeforeDecimal = 0;
            this.txt_fileName.DataType = PLEnums.TextDataType.General;
            this.txt_fileName.DefaultValue = "";
            this.txt_fileName.ErrorMessage = "Please Enter A Value";
            this.txt_fileName.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.txt_fileName.ForeColor = System.Drawing.Color.Empty;
            this.txt_fileName.Location = new System.Drawing.Point(239, 309);
            this.txt_fileName.MaxLength = 10;
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(139, 24);
            this.txt_fileName.SpParameter = "ai_filenam";
            this.txt_fileName.TabIndex = 0;
            this.txt_fileName.TextCase = PLEnums.TextDataCase.None;
            this.txt_fileName.Tooltip = "";
            this.txt_fileName.Watermark = "";
            this.txt_fileName.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // btn_bckups
            // 
            this.btn_bckups.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_bckups.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_bckups.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_bckups.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_bckups.ConfirmationMessage = "";
            this.btn_bckups.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_bckups.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_bckups.ForeColor = System.Drawing.Color.Black;
            this.btn_bckups.HelpUrl = "";
            this.btn_bckups.Location = new System.Drawing.Point(384, 309);
            this.btn_bckups.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_bckups.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_bckups.Name = "btn_bckups";
            this.btn_bckups.Size = new System.Drawing.Size(75, 23);
            this.btn_bckups.SucessMessage = "";
            this.btn_bckups.TabIndex = 1;
            this.btn_bckups.Text = "Back Up";
            this.btn_bckups.Themes = "Default";
            this.btn_bckups.Tooltip = "";
            this.btn_bckups.UseVisualStyleBackColor = false;
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
            this.txt_date_gv,
            this.txt_name_gv,
            this.btn_restore_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(8, 16);
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
            this.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_data.Size = new System.Drawing.Size(529, 278);
            this.grd_data.SpParameter = "v_Xmldata";
            this.grd_data.TabIndex = 2;
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
            this.txt_id_gv.ReadOnly = true;
            this.txt_id_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_id_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_id_gv.TrimRequired = true;
            this.txt_id_gv.Visible = false;
            // 
            // txt_date_gv
            // 
            this.txt_date_gv.AfterDecimal = 0;
            this.txt_date_gv.BeforeDecimal = 0;
            this.txt_date_gv.DataPropertyName = "dt";
            this.txt_date_gv.DataType = PLEnums.TextDataType.General;
            this.txt_date_gv.ErrorMessage = "Please Enter A Value";
            this.txt_date_gv.HeaderText = "DATE";
            this.txt_date_gv.Name = "txt_date_gv";
            this.txt_date_gv.ReadOnly = true;
            this.txt_date_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_date_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_date_gv.TrimRequired = true;
            this.txt_date_gv.Width = 175;
            // 
            // txt_name_gv
            // 
            this.txt_name_gv.AfterDecimal = 0;
            this.txt_name_gv.BeforeDecimal = 0;
            this.txt_name_gv.DataPropertyName = "nam";
            this.txt_name_gv.DataType = PLEnums.TextDataType.General;
            this.txt_name_gv.ErrorMessage = "Please Enter A Value";
            this.txt_name_gv.HeaderText = "FILE";
            this.txt_name_gv.Name = "txt_name_gv";
            this.txt_name_gv.ReadOnly = true;
            this.txt_name_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_name_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_name_gv.TrimRequired = true;
            this.txt_name_gv.Width = 250;
            // 
            // btn_restore_gv
            // 
            this.btn_restore_gv.DataPropertyName = "rstr";
            this.btn_restore_gv.ErrorMessage = "Please Enter A Value";
            this.btn_restore_gv.HeaderText = "";
            this.btn_restore_gv.Name = "btn_restore_gv";
            // 
            // GB_009
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(544, 335);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "GB_009";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "BACK UPS AND RESTORE";
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.DataGridViewPL grd_data;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.TextBoxPL txt_fileName;
        private PLABSb.ButtonPL btn_bckups;
        private PLABSn.PLTextBoxColumn txt_id_gv;
        private PLABSn.PLTextBoxColumn txt_date_gv;
        private PLABSn.PLTextBoxColumn txt_name_gv;
        private PLABSn.PLButtonColumn btn_restore_gv;
        private PLABSb.ButtonPL btn_delete;
    }
}