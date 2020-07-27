namespace RoysGold
{
    partial class RP_014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RP_014));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.lbl_name = new PLABSn.LabelPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.grd_lev_dtls = new PLABSn.DataGridViewPL();
            this.txt_dte_gv = new PLABSn.PLTextBoxColumn();
            this.txt_type_gv = new PLABSn.PLTextBoxColumn();
            this.txt_desc_gv = new PLABSn.PLTextBoxColumn();
            this.groupBoxPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_lev_dtls)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.lbl_name);
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(550, 84);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // lbl_name
            // 
            this.lbl_name.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_name.ClearingRequired = false;
            this.lbl_name.ControlValue = "";
            this.lbl_name.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_name.IsMandatory = false;
            this.lbl_name.Location = new System.Drawing.Point(80, 34);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.SavingRequired = false;
            this.lbl_name.Size = new System.Drawing.Size(180, 23);
            this.lbl_name.SmartTab = false;
            this.lbl_name.TabIndex = 6;
            this.lbl_name.Text = "";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_name.Tooltip = "";
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = " Name";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(23, 37);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(51, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 0;
            this.labelPL1.Text = " Name";
            this.labelPL1.Tooltip = "";
            // 
            // grd_lev_dtls
            // 
            this.grd_lev_dtls.BackgroundColor = System.Drawing.Color.White;
            this.grd_lev_dtls.CancelRowDelete = false;
            this.grd_lev_dtls.ClearingRequired = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_lev_dtls.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_lev_dtls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_lev_dtls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_dte_gv,
            this.txt_type_gv,
            this.txt_desc_gv});
            this.grd_lev_dtls.ControlValue = "<ResultDS></ResultDS>";
            this.grd_lev_dtls.EnableHeadersVisualStyles = false;
            this.grd_lev_dtls.ErrorMessage = "Please Enter At-least One Record";
            this.grd_lev_dtls.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_lev_dtls.IsMandatory = true;
            this.grd_lev_dtls.Location = new System.Drawing.Point(1, 76);
            this.grd_lev_dtls.Name = "grd_lev_dtls";
            this.grd_lev_dtls.ReqdContextMenu = true;
            this.grd_lev_dtls.RowHeadersVisible = false;
            this.grd_lev_dtls.SavingRequired = false;
            this.grd_lev_dtls.Size = new System.Drawing.Size(550, 225);
            this.grd_lev_dtls.TabIndex = 1;
            this.grd_lev_dtls.Tooltip = "";
            // 
            // txt_dte_gv
            // 
            this.txt_dte_gv.AfterDecimal = 0;
            this.txt_dte_gv.BeforeDecimal = 0;
            this.txt_dte_gv.DataPropertyName = "cr_date";
            this.txt_dte_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.txt_dte_gv.DefaultCellStyle = dataGridViewCellStyle2;
            this.txt_dte_gv.ErrorMessage = "Please Enter A Value";
            this.txt_dte_gv.HeaderText = "DATE";
            this.txt_dte_gv.Name = "txt_dte_gv";
            this.txt_dte_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_dte_gv.TrimRequired = true;
            // 
            // txt_type_gv
            // 
            this.txt_type_gv.AfterDecimal = 0;
            this.txt_type_gv.BeforeDecimal = 0;
            this.txt_type_gv.DataPropertyName = "atyp";
            this.txt_type_gv.DataType = PLEnums.TextDataType.General;
            this.txt_type_gv.ErrorMessage = "Please Enter A Value";
            this.txt_type_gv.HeaderText = "TYPE";
            this.txt_type_gv.Name = "txt_type_gv";
            this.txt_type_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_type_gv.TrimRequired = true;
            this.txt_type_gv.Width = 115;
            // 
            // txt_desc_gv
            // 
            this.txt_desc_gv.AfterDecimal = 0;
            this.txt_desc_gv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_desc_gv.BeforeDecimal = 0;
            this.txt_desc_gv.DataPropertyName = "dsc";
            this.txt_desc_gv.DataType = PLEnums.TextDataType.General;
            this.txt_desc_gv.ErrorMessage = "Please Enter A Value";
            this.txt_desc_gv.HeaderText = "DESCRIPTION";
            this.txt_desc_gv.Name = "txt_desc_gv";
            this.txt_desc_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_desc_gv.TrimRequired = true;
            // 
            // RP_014
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(551, 302);
            this.Controls.Add(this.grd_lev_dtls);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "RP_014";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "Leave Details";
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_lev_dtls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.LabelPL lbl_name;
        private PLABSn.DataGridViewPL grd_lev_dtls;
        private PLABSn.PLTextBoxColumn txt_dte_gv;
        private PLABSn.PLTextBoxColumn txt_type_gv;
        private PLABSn.PLTextBoxColumn txt_desc_gv;
    }
}