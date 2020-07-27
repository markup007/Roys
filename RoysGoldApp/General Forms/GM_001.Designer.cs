namespace RoysGold
{
    partial class GM_001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GM_001));
            this.grd_data = new PLABSn.DataGridViewPL();
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.btn_exit = new PLABSb.ButtonPL();
            this.txt_id_gv = new PLABSn.PLTextBoxColumn();
            this.txt_mac_gv = new PLABSn.PLTextBoxColumn();
            this.txt_pcnam_gv = new PLABSn.PLTextBoxColumn();
            this.ddl_grnt_gv = new PLABSn.PLComboxBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.groupBoxPL1.SuspendLayout();
            this.SuspendLayout();
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
            this.txt_id_gv,
            this.txt_mac_gv,
            this.txt_pcnam_gv,
            this.ddl_grnt_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(1, 1);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.SavingRequired = false;
            this.grd_data.Size = new System.Drawing.Size(420, 298);
            this.grd_data.TabIndex = 0;
            this.grd_data.Tooltip = "";
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.btn_exit);
            this.groupBoxPL1.Controls.Add(this.btn_save);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, 290);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(420, 49);
            this.groupBoxPL1.TabIndex = 1;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // btn_save
            // 
            this.btn_save.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_save.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_save.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_save.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_save.ConfirmationMessage = "";
            this.btn_save.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.HelpUrl = "";
            this.btn_save.Location = new System.Drawing.Point(261, 18);
            this.btn_save.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_save.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.SucessMessage = "";
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "&Save";
            this.btn_save.Themes = "Default";
            this.btn_save.Tooltip = "";
            this.btn_save.UseVisualStyleBackColor = true;
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
            this.btn_exit.Location = new System.Drawing.Point(339, 18);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "&Exit";
            this.btn_exit.Themes = "Default";
            this.btn_exit.Tooltip = "";
            this.btn_exit.UseVisualStyleBackColor = false;
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
            // txt_mac_gv
            // 
            this.txt_mac_gv.AfterDecimal = 0;
            this.txt_mac_gv.BeforeDecimal = 0;
            this.txt_mac_gv.DataPropertyName = "mac";
            this.txt_mac_gv.DataType = PLEnums.TextDataType.General;
            this.txt_mac_gv.ErrorMessage = "Please Enter A Value";
            this.txt_mac_gv.HeaderText = "MAC";
            this.txt_mac_gv.Name = "txt_mac_gv";
            this.txt_mac_gv.ReadOnly = true;
            this.txt_mac_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_mac_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_mac_gv.TrimRequired = true;
            this.txt_mac_gv.Width = 129;
            // 
            // txt_pcnam_gv
            // 
            this.txt_pcnam_gv.AfterDecimal = 0;
            this.txt_pcnam_gv.BeforeDecimal = 0;
            this.txt_pcnam_gv.DataPropertyName = "pc";
            this.txt_pcnam_gv.DataType = PLEnums.TextDataType.General;
            this.txt_pcnam_gv.ErrorMessage = "Please Enter A Value";
            this.txt_pcnam_gv.HeaderText = "COMPUTER NAME";
            this.txt_pcnam_gv.Name = "txt_pcnam_gv";
            this.txt_pcnam_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_pcnam_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_pcnam_gv.TrimRequired = true;
            this.txt_pcnam_gv.Width = 188;
            // 
            // ddl_grnt_gv
            // 
            this.ddl_grnt_gv.DataPropertyName = "grnt";
            this.ddl_grnt_gv.ErrorMessage = "Please Enter A Value";
            this.ddl_grnt_gv.HeaderText = "GRANT";
            this.ddl_grnt_gv.Name = "ddl_grnt_gv";
            // 
            // GM_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(422, 340);
            this.Controls.Add(this.grd_data);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "GM_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "GM_001";
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.groupBoxPL1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSn.DataGridViewPL grd_data;
        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSb.ButtonPL btn_exit;
        private PLABSb.ButtonPL btn_save;
        private PLABSn.PLTextBoxColumn txt_id_gv;
        private PLABSn.PLTextBoxColumn txt_mac_gv;
        private PLABSn.PLTextBoxColumn txt_pcnam_gv;
        private PLABSn.PLComboxBoxColumn ddl_grnt_gv;
    }
}