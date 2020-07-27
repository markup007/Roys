namespace RoysGold
{
	partial class CO_001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CO_001));
            this.line1 = new PLABSc.Line();
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.btn_clear = new PLABSb.ButtonPL();
            this.btn_close = new PLABSb.ButtonPL();
            this.btn_ok = new PLABSb.ButtonPL();
            this.gob_main = new PLABSc.GroupBoxPL();
            this.dp_date = new PLABSn.DatePickerPL();
            this.ddl_ordr_no = new PLABSn.ComboBoxPL();
            this.labelPL3 = new PLABSn.LabelPL();
            this.labelPL2 = new PLABSn.LabelPL();
            this.txt_desc = new PLABSn.TextBoxPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.cmb_itm_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.det_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_qty_gv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_wt_gv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_length_gv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxPL1.SuspendLayout();
            this.gob_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
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
            this.groupBoxPL1.Controls.Add(this.btn_clear);
            this.groupBoxPL1.Controls.Add(this.btn_close);
            this.groupBoxPL1.Controls.Add(this.btn_ok);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(2, 423);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(743, 76);
            this.groupBoxPL1.TabIndex = 23;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
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
            this.btn_clear.Location = new System.Drawing.Point(573, 34);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.SucessMessage = "";
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "&Clear";
            this.btn_clear.Themes = "Default";
            this.btn_clear.Tooltip = "";
            this.btn_clear.UseVisualStyleBackColor = false;
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
            this.btn_close.Location = new System.Drawing.Point(650, 34);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.SucessMessage = "";
            this.btn_close.TabIndex = 13;
            this.btn_close.Text = "Clos&e";
            this.btn_close.Themes = "Default";
            this.btn_close.Tooltip = "";
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // btn_ok
            // 
            this.btn_ok.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_ok.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_ok.ConfirmationMessage = "Do you want to save?";
            this.btn_ok.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_ok.ForeColor = System.Drawing.Color.Black;
            this.btn_ok.HelpUrl = "";
            this.btn_ok.Location = new System.Drawing.Point(496, 34);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.SucessMessage = "Save successfully";
            this.btn_ok.TabIndex = 9;
            this.btn_ok.Text = "&Ok";
            this.btn_ok.Themes = "Default";
            this.btn_ok.Tooltip = "";
            this.btn_ok.UseVisualStyleBackColor = false;
            // 
            // gob_main
            // 
            this.gob_main.BorderWidth = 1F;
            this.gob_main.Caption = "";
            this.gob_main.CaptionImage = null;
            this.gob_main.Controls.Add(this.dp_date);
            this.gob_main.Controls.Add(this.ddl_ordr_no);
            this.gob_main.Controls.Add(this.labelPL3);
            this.gob_main.Controls.Add(this.labelPL2);
            this.gob_main.Controls.Add(this.txt_desc);
            this.gob_main.Controls.Add(this.labelPL1);
            this.gob_main.Controls.Add(this.grd_data);
            this.gob_main.CornersRadius = 2;
            this.gob_main.Font = new System.Drawing.Font("Arial", 11F);
            this.gob_main.ForeColor = System.Drawing.Color.Black;
            this.gob_main.HelpUrl = "";
            this.gob_main.Location = new System.Drawing.Point(2, -9);
            this.gob_main.Name = "gob_main";
            this.gob_main.Padding = new System.Windows.Forms.Padding(20);
            this.gob_main.ShadowColor = System.Drawing.Color.DarkGray;
            this.gob_main.Size = new System.Drawing.Size(743, 441);
            this.gob_main.TabIndex = 24;
            this.gob_main.Themes = "Default";
            this.gob_main.Tooltip = "";
            // 
            // dp_date
            // 
            this.dp_date.BackColor = System.Drawing.Color.White;
            this.dp_date.BorderRequired = false;
            this.dp_date.ControlValue = "15-Jul-2010";
            this.dp_date.DefaultValue = "";
            this.dp_date.Font = new System.Drawing.Font("Arial", 11F);
            this.dp_date.ForeColor = System.Drawing.Color.Black;
            this.dp_date.Location = new System.Drawing.Point(124, 66);
            this.dp_date.MaximumSize = new System.Drawing.Size(160, 25);
            this.dp_date.MinimumSize = new System.Drawing.Size(100, 22);
            this.dp_date.Name = "dp_date";
            this.dp_date.Size = new System.Drawing.Size(160, 25);
            this.dp_date.SpParameter = "ad_dt";
            this.dp_date.TabIndex = 18;
            this.dp_date.Tooltip = "";
            this.dp_date.Value = new System.DateTime(2010, 7, 15, 0, 0, 0, 0);
            // 
            // ddl_ordr_no
            // 
            this.ddl_ordr_no.ControlValue = "";
            this.ddl_ordr_no.DefaultValue = "";
            this.ddl_ordr_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_ordr_no.ErrorMessage = "Please Enter Shop Name";
            this.ddl_ordr_no.Font = new System.Drawing.Font("Arial", 11F);
            this.ddl_ordr_no.ForeColor = System.Drawing.Color.Black;
            this.ddl_ordr_no.InstructionText = "Select Item";
            this.ddl_ordr_no.IsMandatory = true;
            this.ddl_ordr_no.Location = new System.Drawing.Point(124, 33);
            this.ddl_ordr_no.Name = "ddl_ordr_no";
            this.ddl_ordr_no.Size = new System.Drawing.Size(160, 25);
            this.ddl_ordr_no.SpParameter = "ai_jewelgrpid";
            this.ddl_ordr_no.TabIndex = 22;
            this.ddl_ordr_no.Tooltip = "";
            // 
            // labelPL3
            // 
            this.labelPL3.AutoSize = true;
            this.labelPL3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL3.ClearingRequired = false;
            this.labelPL3.ControlValue = "Description";
            this.labelPL3.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL3.IsMandatory = true;
            this.labelPL3.Location = new System.Drawing.Point(297, 36);
            this.labelPL3.Name = "labelPL3";
            this.labelPL3.SavingRequired = false;
            this.labelPL3.Size = new System.Drawing.Size(82, 17);
            this.labelPL3.SmartTab = false;
            this.labelPL3.SpParameter = "as_sales_mode";
            this.labelPL3.TabIndex = 21;
            this.labelPL3.Text = "Description";
            this.labelPL3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPL3.Tooltip = "";
            // 
            // labelPL2
            // 
            this.labelPL2.AutoSize = true;
            this.labelPL2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL2.ClearingRequired = false;
            this.labelPL2.ControlValue = "Date";
            this.labelPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL2.IsMandatory = true;
            this.labelPL2.Location = new System.Drawing.Point(82, 70);
            this.labelPL2.Name = "labelPL2";
            this.labelPL2.SavingRequired = false;
            this.labelPL2.Size = new System.Drawing.Size(39, 17);
            this.labelPL2.SmartTab = false;
            this.labelPL2.SpParameter = "ai_shop_id";
            this.labelPL2.TabIndex = 20;
            this.labelPL2.Text = "Date";
            this.labelPL2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPL2.Tooltip = "";
            // 
            // txt_desc
            // 
            this.txt_desc.AfterDecimal = 2;
            this.txt_desc.BeforeDecimal = 0;
            this.txt_desc.DataType = PLEnums.TextDataType.General;
            this.txt_desc.DefaultValue = "";
            this.txt_desc.ErrorMessage = "Please Enter A Value";
            this.txt_desc.ForeColor = System.Drawing.Color.Empty;
            this.txt_desc.Location = new System.Drawing.Point(382, 34);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(282, 50);
            this.txt_desc.SpParameter = "as_desc";
            this.txt_desc.TabIndex = 19;
            this.txt_desc.TextCase = PLEnums.TextDataCase.None;
            this.txt_desc.Tooltip = "";
            this.txt_desc.Watermark = "";
            this.txt_desc.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "Order No";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = true;
            this.labelPL1.Location = new System.Drawing.Point(53, 37);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(68, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.SpParameter = "ai_shop_id";
            this.labelPL1.TabIndex = 17;
            this.labelPL1.Text = "Order No";
            this.labelPL1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPL1.Tooltip = "";
            // 
            // grd_data
            // 
            this.grd_data.BackgroundColor = System.Drawing.Color.White;
            this.grd_data.CancelRowDelete = false;
            this.grd_data.ClearingRequired = false;
            this.grd_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmb_itm_id,
            this.det_id,
            this.txt_qty_gv,
            this.txt_wt_gv,
            this.txt_length_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(4, 133);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.Size = new System.Drawing.Size(733, 296);
            this.grd_data.SpParameter = "v_Xmldata";
            this.grd_data.TabIndex = 15;
            this.grd_data.Tooltip = "";
            // 
            // cmb_itm_id
            // 
            this.cmb_itm_id.DataPropertyName = "itm";
            this.cmb_itm_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.cmb_itm_id.HeaderText = "Item";
            this.cmb_itm_id.Name = "cmb_itm_id";
            this.cmb_itm_id.Width = 200;
            // 
            // det_id
            // 
            this.det_id.DataPropertyName = "det_id";
            this.det_id.HeaderText = "Id";
            this.det_id.Name = "det_id";
            this.det_id.Visible = false;
            // 
            // txt_qty_gv
            // 
            this.txt_qty_gv.DataPropertyName = "qty";
            this.txt_qty_gv.HeaderText = "Quantity";
            this.txt_qty_gv.Name = "txt_qty_gv";
            this.txt_qty_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_qty_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_qty_gv.Width = 175;
            // 
            // txt_wt_gv
            // 
            this.txt_wt_gv.DataPropertyName = "wgt";
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = "0.000";
            this.txt_wt_gv.DefaultCellStyle = dataGridViewCellStyle1;
            this.txt_wt_gv.HeaderText = "Weight";
            this.txt_wt_gv.Name = "txt_wt_gv";
            this.txt_wt_gv.Width = 175;
            // 
            // txt_length_gv
            // 
            this.txt_length_gv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_length_gv.DataPropertyName = "Length";
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.txt_length_gv.DefaultCellStyle = dataGridViewCellStyle2;
            this.txt_length_gv.HeaderText = "Length";
            this.txt_length_gv.Name = "txt_length_gv";
            // 
            // CO_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(746, 500);
            this.Controls.Add(this.gob_main);
            this.Controls.Add(this.groupBoxPL1);
            this.FindIDParameter = "ai_sales_mast_id";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CO_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "Order Form";
            this.ValueChangedStatus = true;
            this.groupBoxPL1.ResumeLayout(false);
            this.gob_main.ResumeLayout(false);
            this.gob_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private PLABSc.Line line1;
        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSb.ButtonPL btn_clear;
        private PLABSb.ButtonPL btn_close;
        private PLABSb.ButtonPL btn_ok;
        private PLABSc.GroupBoxPL gob_main;
        private PLABSn.DatePickerPL dp_date;
        private PLABSn.ComboBoxPL ddl_ordr_no;
        private PLABSn.LabelPL labelPL3;
        private PLABSn.LabelPL labelPL2;
        private PLABSn.TextBoxPL txt_desc;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.DataGridViewPL grd_data;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmb_itm_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn det_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_qty_gv;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_wt_gv;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_length_gv; 
	}
}
