namespace RoysGold
{
    partial class FL_004
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FL_004));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.txt_brdrt = new PLABSn.TextBoxPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.txt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_name_gv = new PLABSn.PLTextBoxColumn();
            this.txt_pdate_gv = new PLABSn.PLTextBoxColumn();
            this.txt_payment_gv = new PLABSn.PLTextBoxColumn();
            this.txt_incrmnt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_curval_gv = new PLABSn.PLTextBoxColumn();
            this.txt_netrt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_gldrt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_grval_gv = new PLABSn.PLTextBoxColumn();
            this.txt_details_gv = new PLABSn.PLTextBoxColumn();
            this.btn_cal = new PLABSn.PLButtonColumn();
            this.txt_cent_gv = new PLABSn.PLTextBoxColumn();
            this.groupBoxPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.txt_brdrt);
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.Controls.Add(this.grd_data);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(2, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(1029, 542);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // txt_brdrt
            // 
            this.txt_brdrt.AfterDecimal = 2;
            this.txt_brdrt.BeforeDecimal = 10;
            this.txt_brdrt.DataType = PLEnums.TextDataType.Double;
            this.txt_brdrt.DefaultValue = "";
            this.txt_brdrt.ErrorMessage = "Please Enter A Value";
            this.txt_brdrt.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.txt_brdrt.ForeColor = System.Drawing.Color.Empty;
            this.txt_brdrt.Location = new System.Drawing.Point(142, 20);
            this.txt_brdrt.Name = "txt_brdrt";
            this.txt_brdrt.SavingRequired = false;
            this.txt_brdrt.Size = new System.Drawing.Size(104, 24);
            this.txt_brdrt.SpParameter = "ai_brdrt";
            this.txt_brdrt.TabIndex = 0;
            this.txt_brdrt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_brdrt.TextCase = PLEnums.TextDataCase.None;
            this.txt_brdrt.Tooltip = "";
            this.txt_brdrt.Watermark = "";
            this.txt_brdrt.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "Current Gold Rate";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(10, 23);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(126, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 2;
            this.labelPL1.Text = "Current Gold Rate";
            this.labelPL1.Tooltip = "";
            // 
            // grd_data
            // 
            this.grd_data.AllowUserToAddRows = false;
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
            this.txt_id,
            this.txt_name_gv,
            this.txt_pdate_gv,
            this.txt_payment_gv,
            this.txt_incrmnt_gv,
            this.txt_curval_gv,
            this.txt_netrt_gv,
            this.txt_gldrt_gv,
            this.txt_grval_gv,
            this.txt_details_gv,
            this.btn_cal,
            this.txt_cent_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_data.DefaultCellStyle = dataGridViewCellStyle7;
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(4, 54);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_data.Size = new System.Drawing.Size(1022, 484);
            this.grd_data.SpParameter = "v_Xmldata";
            this.grd_data.TabIndex = 1;
            this.grd_data.Tooltip = "";
            // 
            // txt_id
            // 
            this.txt_id.DataPropertyName = "addr_id";
            this.txt_id.HeaderText = "id";
            this.txt_id.Name = "txt_id";
            this.txt_id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.txt_id.Visible = false;
            this.txt_id.Width = 5;
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
            this.txt_name_gv.Width = 175;
            // 
            // txt_pdate_gv
            // 
            this.txt_pdate_gv.AfterDecimal = 0;
            this.txt_pdate_gv.BeforeDecimal = 0;
            this.txt_pdate_gv.DataPropertyName = "pdt";
            this.txt_pdate_gv.DataType = PLEnums.TextDataType.General;
            this.txt_pdate_gv.ErrorMessage = "Please Enter A Value";
            this.txt_pdate_gv.HeaderText = "P DATE";
            this.txt_pdate_gv.Name = "txt_pdate_gv";
            this.txt_pdate_gv.ReadOnly = true;
            this.txt_pdate_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_pdate_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_pdate_gv.TrimRequired = true;
            this.txt_pdate_gv.Width = 80;
            // 
            // txt_payment_gv
            // 
            this.txt_payment_gv.AfterDecimal = 0;
            this.txt_payment_gv.BeforeDecimal = 0;
            this.txt_payment_gv.DataPropertyName = "pmnt";
            this.txt_payment_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.txt_payment_gv.DefaultCellStyle = dataGridViewCellStyle2;
            this.txt_payment_gv.ErrorMessage = "Please Enter A Value";
            this.txt_payment_gv.HeaderText = "PAYMENT";
            this.txt_payment_gv.Name = "txt_payment_gv";
            this.txt_payment_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_payment_gv.TrimRequired = true;
            // 
            // txt_incrmnt_gv
            // 
            this.txt_incrmnt_gv.AfterDecimal = 0;
            this.txt_incrmnt_gv.BeforeDecimal = 0;
            this.txt_incrmnt_gv.DataPropertyName = "incrper";
            this.txt_incrmnt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.txt_incrmnt_gv.DefaultCellStyle = dataGridViewCellStyle3;
            this.txt_incrmnt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_incrmnt_gv.HeaderText = "IN PER";
            this.txt_incrmnt_gv.Name = "txt_incrmnt_gv";
            this.txt_incrmnt_gv.ReadOnly = true;
            this.txt_incrmnt_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_incrmnt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_incrmnt_gv.TrimRequired = true;
            // 
            // txt_curval_gv
            // 
            this.txt_curval_gv.AfterDecimal = 0;
            this.txt_curval_gv.BeforeDecimal = 0;
            this.txt_curval_gv.DataPropertyName = "crval";
            this.txt_curval_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.txt_curval_gv.DefaultCellStyle = dataGridViewCellStyle4;
            this.txt_curval_gv.ErrorMessage = "Please Enter A Value";
            this.txt_curval_gv.HeaderText = "CUR VAL";
            this.txt_curval_gv.Name = "txt_curval_gv";
            this.txt_curval_gv.ReadOnly = true;
            this.txt_curval_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_curval_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_curval_gv.TrimRequired = true;
            // 
            // txt_netrt_gv
            // 
            this.txt_netrt_gv.AfterDecimal = 0;
            this.txt_netrt_gv.BeforeDecimal = 0;
            this.txt_netrt_gv.DataPropertyName = "net_rt";
            this.txt_netrt_gv.DataType = PLEnums.TextDataType.General;
            this.txt_netrt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_netrt_gv.HeaderText = "Net Rate";
            this.txt_netrt_gv.Name = "txt_netrt_gv";
            this.txt_netrt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_netrt_gv.TrimRequired = true;
            this.txt_netrt_gv.Width = 105;
            // 
            // txt_gldrt_gv
            // 
            this.txt_gldrt_gv.AfterDecimal = 0;
            this.txt_gldrt_gv.BeforeDecimal = 0;
            this.txt_gldrt_gv.DataPropertyName = "grt";
            this.txt_gldrt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.txt_gldrt_gv.DefaultCellStyle = dataGridViewCellStyle5;
            this.txt_gldrt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_gldrt_gv.HeaderText = "P G RATE";
            this.txt_gldrt_gv.Name = "txt_gldrt_gv";
            this.txt_gldrt_gv.ReadOnly = true;
            this.txt_gldrt_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_gldrt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_gldrt_gv.TrimRequired = true;
            // 
            // txt_grval_gv
            // 
            this.txt_grval_gv.AfterDecimal = 0;
            this.txt_grval_gv.BeforeDecimal = 0;
            this.txt_grval_gv.DataPropertyName = "grval";
            this.txt_grval_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.txt_grval_gv.DefaultCellStyle = dataGridViewCellStyle6;
            this.txt_grval_gv.ErrorMessage = "Please Enter A Value";
            this.txt_grval_gv.HeaderText = "GR VAL";
            this.txt_grval_gv.Name = "txt_grval_gv";
            this.txt_grval_gv.ReadOnly = true;
            this.txt_grval_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_grval_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_grval_gv.TrimRequired = true;
            // 
            // txt_details_gv
            // 
            this.txt_details_gv.AfterDecimal = 0;
            this.txt_details_gv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_details_gv.BeforeDecimal = 0;
            this.txt_details_gv.DataPropertyName = "dsc";
            this.txt_details_gv.DataType = PLEnums.TextDataType.General;
            this.txt_details_gv.ErrorMessage = "Please Enter A Value";
            this.txt_details_gv.HeaderText = "DETAILS";
            this.txt_details_gv.Name = "txt_details_gv";
            this.txt_details_gv.ReadOnly = true;
            this.txt_details_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_details_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_details_gv.TrimRequired = true;
            // 
            // btn_cal
            // 
            this.btn_cal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.btn_cal.ErrorMessage = "Please Enter A Value";
            this.btn_cal.HeaderText = "CAL";
            this.btn_cal.Name = "btn_cal";
            this.btn_cal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btn_cal.Width = 42;
            // 
            // txt_cent_gv
            // 
            this.txt_cent_gv.AfterDecimal = 0;
            this.txt_cent_gv.BeforeDecimal = 0;
            this.txt_cent_gv.DataPropertyName = "cent";
            this.txt_cent_gv.DataType = PLEnums.TextDataType.General;
            this.txt_cent_gv.ErrorMessage = "Please Enter A Value";
            this.txt_cent_gv.HeaderText = "cent";
            this.txt_cent_gv.Name = "txt_cent_gv";
            this.txt_cent_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_cent_gv.TrimRequired = true;
            this.txt_cent_gv.Visible = false;
            // 
            // FL_004
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(1032, 534);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "FL_004";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "FL_004";
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.TextBoxPL txt_brdrt;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.DataGridViewPL grd_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_id;
        private PLABSn.PLTextBoxColumn txt_name_gv;
        private PLABSn.PLTextBoxColumn txt_pdate_gv;
        private PLABSn.PLTextBoxColumn txt_payment_gv;
        private PLABSn.PLTextBoxColumn txt_incrmnt_gv;
        private PLABSn.PLTextBoxColumn txt_curval_gv;
        private PLABSn.PLTextBoxColumn txt_netrt_gv;
        private PLABSn.PLTextBoxColumn txt_gldrt_gv;
        private PLABSn.PLTextBoxColumn txt_grval_gv;
        private PLABSn.PLTextBoxColumn txt_details_gv;
        private PLABSn.PLButtonColumn btn_cal;
        private PLABSn.PLTextBoxColumn txt_cent_gv;

    }
}