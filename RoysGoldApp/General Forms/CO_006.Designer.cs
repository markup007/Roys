namespace RoysGold
{
    partial class CO_006
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CO_006));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.btn_exit = new PLABSb.ButtonPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.txt_dat_gv = new PLABSn.PLTextBoxColumn();
            this.txt_id_gv = new PLABSn.PLTextBoxColumn();
            this.txt_stkitm_gv = new PLABSn.PLTextBoxColumn();
            this.txt_payment_gv = new PLABSn.PLTextBoxColumn();
            this.txt_receipt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_dec_gv = new PLABSn.PLTextBoxColumn();
            this.btn_prvmth = new PLABSb.ButtonPL();
            this.groupBoxPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.btn_prvmth);
            this.groupBoxPL1.Controls.Add(this.btn_exit);
            this.groupBoxPL1.Controls.Add(this.grd_data);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(809, 498);
            this.groupBoxPL1.TabIndex = 1;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // btn_exit
            // 
            this.btn_exit.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_exit.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_exit.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_exit.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_exit.ConfirmationMessage = "";
            this.btn_exit.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.HelpUrl = "";
            this.btn_exit.Location = new System.Drawing.Point(731, 470);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(73, 23);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 11;
            this.btn_exit.Text = "Exit";
            this.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_exit.Themes = "Default";
            this.btn_exit.Tooltip = "";
            this.btn_exit.UseVisualStyleBackColor = false;
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
            this.txt_dat_gv,
            this.txt_id_gv,
            this.txt_stkitm_gv,
            this.txt_payment_gv,
            this.txt_receipt_gv,
            this.txt_dec_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(5, 15);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_data.Size = new System.Drawing.Size(799, 452);
            this.grd_data.SpParameter = "v_Xmlgldrgstr";
            this.grd_data.TabIndex = 10;
            this.grd_data.Tooltip = "";
            // 
            // txt_dat_gv
            // 
            this.txt_dat_gv.AfterDecimal = 0;
            this.txt_dat_gv.BeforeDecimal = 0;
            this.txt_dat_gv.DataPropertyName = "dat";
            this.txt_dat_gv.DataType = PLEnums.TextDataType.General;
            this.txt_dat_gv.ErrorMessage = "Please Enter A Value";
            this.txt_dat_gv.HeaderText = "DATE";
            this.txt_dat_gv.Name = "txt_dat_gv";
            this.txt_dat_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_dat_gv.TrimRequired = true;
            this.txt_dat_gv.Width = 125;
            // 
            // txt_id_gv
            // 
            this.txt_id_gv.AfterDecimal = 0;
            this.txt_id_gv.BeforeDecimal = 0;
            this.txt_id_gv.DataPropertyName = "id";
            this.txt_id_gv.DataType = PLEnums.TextDataType.General;
            this.txt_id_gv.ErrorMessage = "Please Enter A Value";
            this.txt_id_gv.HeaderText = "ID";
            this.txt_id_gv.Name = "txt_id_gv";
            this.txt_id_gv.ReadOnly = true;
            this.txt_id_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_id_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_id_gv.TrimRequired = true;
            this.txt_id_gv.Visible = false;
            // 
            // txt_stkitm_gv
            // 
            this.txt_stkitm_gv.AfterDecimal = 0;
            this.txt_stkitm_gv.BeforeDecimal = 0;
            this.txt_stkitm_gv.DataPropertyName = "nam";
            this.txt_stkitm_gv.DataType = PLEnums.TextDataType.General;
            this.txt_stkitm_gv.ErrorMessage = "Please Enter A Value";
            this.txt_stkitm_gv.HeaderText = "NAME";
            this.txt_stkitm_gv.Name = "txt_stkitm_gv";
            this.txt_stkitm_gv.ReadOnly = true;
            this.txt_stkitm_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_stkitm_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_stkitm_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_stkitm_gv.TrimRequired = true;
            this.txt_stkitm_gv.Width = 150;
            // 
            // txt_payment_gv
            // 
            this.txt_payment_gv.AfterDecimal = 2;
            this.txt_payment_gv.BeforeDecimal = 15;
            this.txt_payment_gv.DataPropertyName = "dr";
            this.txt_payment_gv.DataType = PLEnums.TextDataType.Double;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.txt_payment_gv.DefaultCellStyle = dataGridViewCellStyle2;
            this.txt_payment_gv.ErrorMessage = "Please Enter A Value";
            this.txt_payment_gv.HeaderText = "PAYMENT";
            this.txt_payment_gv.Name = "txt_payment_gv";
            this.txt_payment_gv.ReadOnly = true;
            this.txt_payment_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_payment_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_payment_gv.TrimRequired = true;
            this.txt_payment_gv.Width = 185;
            // 
            // txt_receipt_gv
            // 
            this.txt_receipt_gv.AfterDecimal = 2;
            this.txt_receipt_gv.BeforeDecimal = 15;
            this.txt_receipt_gv.DataPropertyName = "cr";
            this.txt_receipt_gv.DataType = PLEnums.TextDataType.Double;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.txt_receipt_gv.DefaultCellStyle = dataGridViewCellStyle3;
            this.txt_receipt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_receipt_gv.HeaderText = "RECEIPT";
            this.txt_receipt_gv.Name = "txt_receipt_gv";
            this.txt_receipt_gv.ReadOnly = true;
            this.txt_receipt_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_receipt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_receipt_gv.TrimRequired = true;
            this.txt_receipt_gv.Width = 185;
            // 
            // txt_dec_gv
            // 
            this.txt_dec_gv.AfterDecimal = 0;
            this.txt_dec_gv.BeforeDecimal = 0;
            this.txt_dec_gv.DataPropertyName = "des";
            this.txt_dec_gv.DataType = PLEnums.TextDataType.General;
            this.txt_dec_gv.ErrorMessage = "Please Enter A Value";
            this.txt_dec_gv.HeaderText = "DESCRIPTION";
            this.txt_dec_gv.Name = "txt_dec_gv";
            this.txt_dec_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_dec_gv.TrimRequired = true;
            this.txt_dec_gv.Width = 150;
            // 
            // btn_prvmth
            // 
            this.btn_prvmth.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_prvmth.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_prvmth.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_prvmth.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_prvmth.ConfirmationMessage = "";
            this.btn_prvmth.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_prvmth.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_prvmth.ForeColor = System.Drawing.Color.Black;
            this.btn_prvmth.HelpUrl = "";
            this.btn_prvmth.Location = new System.Drawing.Point(611, 470);
            this.btn_prvmth.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_prvmth.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_prvmth.Name = "btn_prvmth";
            this.btn_prvmth.Size = new System.Drawing.Size(117, 23);
            this.btn_prvmth.SucessMessage = "";
            this.btn_prvmth.TabIndex = 12;
            this.btn_prvmth.Text = "Previous Month";
            this.btn_prvmth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_prvmth.Themes = "Default";
            this.btn_prvmth.Tooltip = "";
            this.btn_prvmth.UseVisualStyleBackColor = false;
            // 
            // CO_006
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(811, 490);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "CO_006";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "INDIRECT INCOME AND EXPENSE ";
            this.groupBoxPL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.DataGridViewPL grd_data;
        private PLABSb.ButtonPL btn_exit;
        private PLABSn.PLTextBoxColumn txt_dat_gv;
        private PLABSn.PLTextBoxColumn txt_id_gv;
        private PLABSn.PLTextBoxColumn txt_stkitm_gv;
        private PLABSn.PLTextBoxColumn txt_payment_gv;
        private PLABSn.PLTextBoxColumn txt_receipt_gv;
        private PLABSn.PLTextBoxColumn txt_dec_gv;
        private PLABSb.ButtonPL btn_prvmth;
    }
}