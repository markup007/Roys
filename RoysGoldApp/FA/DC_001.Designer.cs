namespace RoysGold
{
    partial class DC_001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DC_001));
            this.panelPL1 = new PLABSc.PanelPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.btn_exit = new PLABSb.ButtonPL();
            this.textBoxPL1 = new PLABSn.TextBoxPL();
            this.panelPL2 = new PLABSc.PanelPL();
            this.txt_id_gv = new PLABSn.PLTextBoxColumn();
            this.stck_itm = new PLABSn.PLTextBoxColumn();
            this.txt_wt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_sheetwt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_shrt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_srplx_gv = new PLABSn.PLTextBoxColumn();
            this.txt_cls_gv = new PLABSn.PLTextBoxColumn();
            this.txt_desc_gv = new PLABSn.PLTextBoxColumn();
            this.txt_item_gv = new PLABSn.PLTextBoxColumn();
            this.panelPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.panelPL2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPL1
            // 
            this.panelPL1.BackColor = System.Drawing.Color.Transparent;
            this.panelPL1.BorderRequired = true;
            this.panelPL1.Controls.Add(this.grd_data);
            this.panelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.panelPL1.ForeColor = System.Drawing.Color.Black;
            this.panelPL1.HelpUrl = "";
            this.panelPL1.Location = new System.Drawing.Point(2, 3);
            this.panelPL1.Name = "panelPL1";
            this.panelPL1.Size = new System.Drawing.Size(1131, 485);
            this.panelPL1.TabIndex = 6;
            this.panelPL1.Themes = "Default";
            this.panelPL1.Tooltip = "";
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
            this.stck_itm,
            this.txt_wt_gv,
            this.txt_sheetwt_gv,
            this.txt_shrt_gv,
            this.txt_srplx_gv,
            this.txt_cls_gv,
            this.txt_desc_gv,
            this.txt_item_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(4, 8);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.Size = new System.Drawing.Size(1122, 474);
            this.grd_data.SpParameter = "v_Xmldata";
            this.grd_data.TabIndex = 7;
            this.grd_data.Tooltip = "";
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
            this.btn_save.Location = new System.Drawing.Point(968, 19);
            this.btn_save.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_save.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.SucessMessage = "";
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Save";
            this.btn_save.Themes = "Default";
            this.btn_save.Tooltip = "";
            this.btn_save.UseVisualStyleBackColor = false;
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
            this.btn_exit.Location = new System.Drawing.Point(1046, 19);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 9;
            this.btn_exit.Text = "&Exit";
            this.btn_exit.Themes = "Default";
            this.btn_exit.Tooltip = "";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // textBoxPL1
            // 
            this.textBoxPL1.AfterDecimal = 2;
            this.textBoxPL1.BeforeDecimal = 0;
            this.textBoxPL1.DataType = PLEnums.TextDataType.General;
            this.textBoxPL1.DefaultValue = "";
            this.textBoxPL1.ErrorMessage = "Please Enter A Value";
            this.textBoxPL1.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPL1.ForeColor = System.Drawing.Color.Empty;
            this.textBoxPL1.Location = new System.Drawing.Point(889, 19);
            this.textBoxPL1.Name = "textBoxPL1";
            this.textBoxPL1.Size = new System.Drawing.Size(75, 24);
            this.textBoxPL1.SpParameter = "as_rough";
            this.textBoxPL1.TabIndex = 10;
            this.textBoxPL1.TextCase = PLEnums.TextDataCase.None;
            this.textBoxPL1.Tooltip = "";
            this.textBoxPL1.Watermark = "";
            this.textBoxPL1.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // panelPL2
            // 
            this.panelPL2.BackColor = System.Drawing.Color.White;
            this.panelPL2.BorderRequired = true;
            this.panelPL2.Controls.Add(this.textBoxPL1);
            this.panelPL2.Controls.Add(this.btn_save);
            this.panelPL2.Controls.Add(this.btn_exit);
            this.panelPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.panelPL2.ForeColor = System.Drawing.Color.Black;
            this.panelPL2.HelpUrl = "";
            this.panelPL2.Location = new System.Drawing.Point(2, 490);
            this.panelPL2.Name = "panelPL2";
            this.panelPL2.Size = new System.Drawing.Size(1131, 57);
            this.panelPL2.TabIndex = 7;
            this.panelPL2.Themes = "Default";
            this.panelPL2.Tooltip = "";
            // 
            // txt_id_gv
            // 
            this.txt_id_gv.AfterDecimal = 0;
            this.txt_id_gv.BeforeDecimal = 0;
            this.txt_id_gv.DataPropertyName = "itmid";
            this.txt_id_gv.DataType = PLEnums.TextDataType.General;
            this.txt_id_gv.ErrorMessage = "Please Enter A Value";
            this.txt_id_gv.HeaderText = "Id";
            this.txt_id_gv.Name = "txt_id_gv";
            this.txt_id_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_id_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_id_gv.TrimRequired = true;
            this.txt_id_gv.Visible = false;
            // 
            // stck_itm
            // 
            this.stck_itm.AfterDecimal = 0;
            this.stck_itm.BeforeDecimal = 0;
            this.stck_itm.DataPropertyName = "item";
            this.stck_itm.DataType = PLEnums.TextDataType.General;
            this.stck_itm.ErrorMessage = "Please Enter A Value";
            this.stck_itm.HeaderText = "STOCK ITEM";
            this.stck_itm.Name = "stck_itm";
            this.stck_itm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stck_itm.TextCase = PLEnums.TextDataCase.None;
            this.stck_itm.TrimRequired = true;
            this.stck_itm.Width = 250;
            // 
            // txt_wt_gv
            // 
            this.txt_wt_gv.AfterDecimal = 0;
            this.txt_wt_gv.BeforeDecimal = 0;
            this.txt_wt_gv.DataPropertyName = "wt";
            this.txt_wt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.txt_wt_gv.DefaultCellStyle = dataGridViewCellStyle2;
            this.txt_wt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_wt_gv.HeaderText = "STOCK WT";
            this.txt_wt_gv.Name = "txt_wt_gv";
            this.txt_wt_gv.ReadOnly = true;
            this.txt_wt_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_wt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_wt_gv.TrimRequired = true;
            this.txt_wt_gv.Width = 140;
            // 
            // txt_sheetwt_gv
            // 
            this.txt_sheetwt_gv.AfterDecimal = 0;
            this.txt_sheetwt_gv.BeforeDecimal = 0;
            this.txt_sheetwt_gv.DataPropertyName = "shtwt";
            this.txt_sheetwt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.txt_sheetwt_gv.DefaultCellStyle = dataGridViewCellStyle3;
            this.txt_sheetwt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_sheetwt_gv.HeaderText = "SHT WT";
            this.txt_sheetwt_gv.Name = "txt_sheetwt_gv";
            this.txt_sheetwt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_sheetwt_gv.TrimRequired = true;
            // 
            // txt_shrt_gv
            // 
            this.txt_shrt_gv.AfterDecimal = 0;
            this.txt_shrt_gv.BeforeDecimal = 0;
            this.txt_shrt_gv.DataPropertyName = "shrt";
            this.txt_shrt_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N3";
            this.txt_shrt_gv.DefaultCellStyle = dataGridViewCellStyle4;
            this.txt_shrt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_shrt_gv.HeaderText = "SHORT";
            this.txt_shrt_gv.Name = "txt_shrt_gv";
            this.txt_shrt_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_shrt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_shrt_gv.TrimRequired = true;
            this.txt_shrt_gv.Width = 140;
            // 
            // txt_srplx_gv
            // 
            this.txt_srplx_gv.AfterDecimal = 0;
            this.txt_srplx_gv.BeforeDecimal = 0;
            this.txt_srplx_gv.DataPropertyName = "srplx";
            this.txt_srplx_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N3";
            this.txt_srplx_gv.DefaultCellStyle = dataGridViewCellStyle5;
            this.txt_srplx_gv.ErrorMessage = "Please Enter A Value";
            this.txt_srplx_gv.HeaderText = "SURPLUS";
            this.txt_srplx_gv.Name = "txt_srplx_gv";
            this.txt_srplx_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_srplx_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_srplx_gv.TrimRequired = true;
            this.txt_srplx_gv.Width = 140;
            // 
            // txt_cls_gv
            // 
            this.txt_cls_gv.AfterDecimal = 0;
            this.txt_cls_gv.BeforeDecimal = 0;
            this.txt_cls_gv.DataPropertyName = "cls";
            this.txt_cls_gv.DataType = PLEnums.TextDataType.General;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle6.Format = "N3";
            this.txt_cls_gv.DefaultCellStyle = dataGridViewCellStyle6;
            this.txt_cls_gv.ErrorMessage = "Please Enter A Value";
            this.txt_cls_gv.HeaderText = "CLOSING";
            this.txt_cls_gv.Name = "txt_cls_gv";
            this.txt_cls_gv.ReadOnly = true;
            this.txt_cls_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_cls_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_cls_gv.TrimRequired = true;
            this.txt_cls_gv.Width = 150;
            // 
            // txt_desc_gv
            // 
            this.txt_desc_gv.AfterDecimal = 0;
            this.txt_desc_gv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_desc_gv.BeforeDecimal = 0;
            this.txt_desc_gv.DataPropertyName = "descriptn";
            this.txt_desc_gv.DataType = PLEnums.TextDataType.General;
            this.txt_desc_gv.ErrorMessage = "Please Enter A Value";
            this.txt_desc_gv.HeaderText = "Description";
            this.txt_desc_gv.Name = "txt_desc_gv";
            this.txt_desc_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_desc_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_desc_gv.TrimRequired = true;
            // 
            // txt_item_gv
            // 
            this.txt_item_gv.AfterDecimal = 0;
            this.txt_item_gv.BeforeDecimal = 0;
            this.txt_item_gv.DataPropertyName = "item_id";
            this.txt_item_gv.DataType = PLEnums.TextDataType.General;
            this.txt_item_gv.ErrorMessage = "Please Enter A Value";
            this.txt_item_gv.HeaderText = "ItemId";
            this.txt_item_gv.Name = "txt_item_gv";
            this.txt_item_gv.ReadOnly = true;
            this.txt_item_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txt_item_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_item_gv.TrimRequired = true;
            this.txt_item_gv.Visible = false;
            // 
            // DC_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(1134, 548);
            this.Controls.Add(this.panelPL2);
            this.Controls.Add(this.panelPL1);
            this.FindIDParameter = "day_clsng_id";
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "DC_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "DayClosing";
            this.panelPL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.panelPL2.ResumeLayout(false);
            this.panelPL2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.PanelPL panelPL1;
        private PLABSn.DataGridViewPL grd_data;
        private PLABSn.TextBoxPL textBoxPL1;
        private PLABSb.ButtonPL btn_exit;
        private PLABSb.ButtonPL btn_save;
        private PLABSc.PanelPL panelPL2;
        private PLABSn.PLTextBoxColumn txt_id_gv;
        private PLABSn.PLTextBoxColumn stck_itm;
        private PLABSn.PLTextBoxColumn txt_wt_gv;
        private PLABSn.PLTextBoxColumn txt_sheetwt_gv;
        private PLABSn.PLTextBoxColumn txt_shrt_gv;
        private PLABSn.PLTextBoxColumn txt_srplx_gv;
        private PLABSn.PLTextBoxColumn txt_cls_gv;
        private PLABSn.PLTextBoxColumn txt_desc_gv;
        private PLABSn.PLTextBoxColumn txt_item_gv;
    }
}