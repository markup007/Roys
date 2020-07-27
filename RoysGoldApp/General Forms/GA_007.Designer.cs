namespace RoysGold
{
    partial class GA_007
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GA_007));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.grd_grpdata = new PLABSn.DataGridViewPL();
            this.txt_id_gvgrp = new PLABSn.PLTextBoxColumn();
            this.chk_sel_gvgrp = new PLABSn.PLCheckBoxColumn();
            this.txt_head_gvgrp = new PLABSn.PLTextBoxColumn();
            this.chk_all = new PLABSn.CheckBoxPL();
            this.groupBoxPL2 = new PLABSc.GroupBoxPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.btn_exit = new PLABSb.ButtonPL();
            this.btn_clear = new PLABSb.ButtonPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.ddl_addr_id = new PLABSn.ComboBoxPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.txt_id_gv = new PLABSn.PLTextBoxColumn();
            this.chk_select_gv = new PLABSn.PLCheckBoxColumn();
            this.txt_head_gv = new PLABSn.PLTextBoxColumn();
            this.txt_grpid_gv = new PLABSn.PLTextBoxColumn();
            this.groupBoxPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_grpdata)).BeginInit();
            this.groupBoxPL2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.grd_grpdata);
            this.groupBoxPL1.Controls.Add(this.chk_all);
            this.groupBoxPL1.Controls.Add(this.groupBoxPL2);
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.Controls.Add(this.ddl_addr_id);
            this.groupBoxPL1.Controls.Add(this.grd_data);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(671, 485);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // grd_grpdata
            // 
            this.grd_grpdata.AllowUserToAddRows = false;
            this.grd_grpdata.BackgroundColor = System.Drawing.Color.White;
            this.grd_grpdata.CancelRowDelete = false;
            this.grd_grpdata.ClearingRequired = true;
            this.grd_grpdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_grpdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_id_gvgrp,
            this.chk_sel_gvgrp,
            this.txt_head_gvgrp});
            this.grd_grpdata.ControlValue = "<ResultDS></ResultDS>";
            this.grd_grpdata.EnableHeadersVisualStyles = false;
            this.grd_grpdata.ErrorMessage = "Please Enter At-least One Record";
            this.grd_grpdata.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_grpdata.IsMandatory = true;
            this.grd_grpdata.Location = new System.Drawing.Point(339, 55);
            this.grd_grpdata.Name = "grd_grpdata";
            this.grd_grpdata.ReqdContextMenu = true;
            this.grd_grpdata.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_grpdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_grpdata.RowHeadersVisible = false;
            this.grd_grpdata.SavingRequired = false;
            this.grd_grpdata.Size = new System.Drawing.Size(322, 378);
            this.grd_grpdata.SpParameter = "v_Xmldata";
            this.grd_grpdata.TabIndex = 9;
            this.grd_grpdata.Tooltip = "";
            // 
            // txt_id_gvgrp
            // 
            this.txt_id_gvgrp.AfterDecimal = 0;
            this.txt_id_gvgrp.BeforeDecimal = 0;
            this.txt_id_gvgrp.DataPropertyName = "id";
            this.txt_id_gvgrp.DataType = PLEnums.TextDataType.General;
            this.txt_id_gvgrp.ErrorMessage = "Please Enter A Value";
            this.txt_id_gvgrp.HeaderText = "Id";
            this.txt_id_gvgrp.Name = "txt_id_gvgrp";
            this.txt_id_gvgrp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_id_gvgrp.TextCase = PLEnums.TextDataCase.None;
            this.txt_id_gvgrp.TrimRequired = true;
            this.txt_id_gvgrp.Visible = false;
            // 
            // chk_sel_gvgrp
            // 
            this.chk_sel_gvgrp.DataPropertyName = "chk";
            this.chk_sel_gvgrp.ErrorMessage = "Please Enter A Value";
            this.chk_sel_gvgrp.FalseValue = "0";
            this.chk_sel_gvgrp.HeaderText = "Select";
            this.chk_sel_gvgrp.Name = "chk_sel_gvgrp";
            this.chk_sel_gvgrp.TrueValue = "1";
            this.chk_sel_gvgrp.Width = 50;
            // 
            // txt_head_gvgrp
            // 
            this.txt_head_gvgrp.AfterDecimal = 0;
            this.txt_head_gvgrp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_head_gvgrp.BeforeDecimal = 0;
            this.txt_head_gvgrp.DataPropertyName = "nam";
            this.txt_head_gvgrp.DataType = PLEnums.TextDataType.General;
            this.txt_head_gvgrp.ErrorMessage = "Please Enter A Value";
            this.txt_head_gvgrp.HeaderText = "Head";
            this.txt_head_gvgrp.Name = "txt_head_gvgrp";
            this.txt_head_gvgrp.TextCase = PLEnums.TextDataCase.None;
            this.txt_head_gvgrp.TrimRequired = true;
            // 
            // chk_all
            // 
            this.chk_all.AutoSize = true;
            this.chk_all.ControlValue = "1";
            this.chk_all.FalseValue = "1";
            this.chk_all.Font = new System.Drawing.Font("Arial", 11F);
            this.chk_all.ForeColor = System.Drawing.Color.Black;
            this.chk_all.Location = new System.Drawing.Point(220, 25);
            this.chk_all.Name = "chk_all";
            this.chk_all.SavingRequired = false;
            this.chk_all.Size = new System.Drawing.Size(87, 21);
            this.chk_all.SpParameter = "ai_chk";
            this.chk_all.TabIndex = 8;
            this.chk_all.Text = "Select All";
            this.chk_all.Tooltip = "";
            this.chk_all.TrueValue = "0";
            this.chk_all.UseVisualStyleBackColor = true;
            // 
            // groupBoxPL2
            // 
            this.groupBoxPL2.BorderWidth = 1F;
            this.groupBoxPL2.Caption = "";
            this.groupBoxPL2.CaptionImage = null;
            this.groupBoxPL2.Controls.Add(this.btn_save);
            this.groupBoxPL2.Controls.Add(this.btn_exit);
            this.groupBoxPL2.Controls.Add(this.btn_clear);
            this.groupBoxPL2.CornersRadius = 2;
            this.groupBoxPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL2.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL2.HelpUrl = "";
            this.groupBoxPL2.Location = new System.Drawing.Point(339, 430);
            this.groupBoxPL2.Name = "groupBoxPL2";
            this.groupBoxPL2.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL2.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL2.Size = new System.Drawing.Size(322, 51);
            this.groupBoxPL2.TabIndex = 7;
            this.groupBoxPL2.Themes = "Default";
            this.groupBoxPL2.Tooltip = "";
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
            this.btn_save.Location = new System.Drawing.Point(78, 20);
            this.btn_save.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_save.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.SucessMessage = "";
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "&Save";
            this.btn_save.Themes = "Default";
            this.btn_save.Tooltip = "";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // btn_exit
            // 
            this.btn_exit.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_exit.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_exit.ButtonType = PLEnums.ButtonTypes.Save;
            this.btn_exit.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_exit.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_exit.ConfirmationMessage = "";
            this.btn_exit.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.HelpUrl = "";
            this.btn_exit.Location = new System.Drawing.Point(240, 20);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "&Exit";
            this.btn_exit.Themes = "Default";
            this.btn_exit.Tooltip = "";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // btn_clear
            // 
            this.btn_clear.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_clear.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_clear.ButtonType = PLEnums.ButtonTypes.Delete;
            this.btn_clear.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_clear.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_clear.ConfirmationMessage = "";
            this.btn_clear.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_clear.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_clear.ForeColor = System.Drawing.Color.Black;
            this.btn_clear.HelpUrl = "";
            this.btn_clear.Location = new System.Drawing.Point(159, 20);
            this.btn_clear.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_clear.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.SucessMessage = "";
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "&Clear";
            this.btn_clear.Themes = "Default";
            this.btn_clear.Tooltip = "";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "User";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(13, 26);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(39, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 4;
            this.labelPL1.Text = "User";
            this.labelPL1.Tooltip = "";
            // 
            // ddl_addr_id
            // 
            this.ddl_addr_id.ControlValue = "";
            this.ddl_addr_id.DefaultValue = "";
            this.ddl_addr_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_addr_id.Font = new System.Drawing.Font("Arial", 11F);
            this.ddl_addr_id.ForeColor = System.Drawing.Color.Black;
            this.ddl_addr_id.FormattingEnabled = true;
            this.ddl_addr_id.InstructionText = "Select Item";
            this.ddl_addr_id.IsMandatory = true;
            this.ddl_addr_id.Location = new System.Drawing.Point(58, 22);
            this.ddl_addr_id.Name = "ddl_addr_id";
            this.ddl_addr_id.Size = new System.Drawing.Size(156, 25);
            this.ddl_addr_id.SpParameter = "ai_usr_id";
            this.ddl_addr_id.TabIndex = 3;
            this.ddl_addr_id.Tooltip = "";
            // 
            // grd_data
            // 
            this.grd_data.AllowUserToAddRows = false;
            this.grd_data.BackgroundColor = System.Drawing.Color.White;
            this.grd_data.CancelRowDelete = false;
            this.grd_data.ClearingRequired = true;
            this.grd_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_id_gv,
            this.chk_select_gv,
            this.txt_head_gv,
            this.txt_grpid_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.EnableHeadersVisualStyles = false;
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(11, 55);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            this.grd_data.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
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
            this.grd_data.Size = new System.Drawing.Size(322, 426);
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
            this.txt_id_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_id_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_id_gv.TrimRequired = true;
            this.txt_id_gv.Visible = false;
            // 
            // chk_select_gv
            // 
            this.chk_select_gv.DataPropertyName = "chk";
            this.chk_select_gv.ErrorMessage = "Please Enter A Value";
            this.chk_select_gv.FalseValue = "0";
            this.chk_select_gv.HeaderText = "Select";
            this.chk_select_gv.Name = "chk_select_gv";
            this.chk_select_gv.TrueValue = "1";
            this.chk_select_gv.Width = 50;
            // 
            // txt_head_gv
            // 
            this.txt_head_gv.AfterDecimal = 0;
            this.txt_head_gv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_head_gv.BeforeDecimal = 0;
            this.txt_head_gv.DataPropertyName = "nam";
            this.txt_head_gv.DataType = PLEnums.TextDataType.General;
            this.txt_head_gv.ErrorMessage = "Please Enter A Value";
            this.txt_head_gv.HeaderText = "Head";
            this.txt_head_gv.Name = "txt_head_gv";
            this.txt_head_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_head_gv.TrimRequired = true;
            // 
            // txt_grpid_gv
            // 
            this.txt_grpid_gv.AfterDecimal = 0;
            this.txt_grpid_gv.BeforeDecimal = 0;
            this.txt_grpid_gv.DataPropertyName = "grp";
            this.txt_grpid_gv.DataType = PLEnums.TextDataType.General;
            this.txt_grpid_gv.ErrorMessage = "Please Enter A Value";
            this.txt_grpid_gv.HeaderText = "Group Id";
            this.txt_grpid_gv.Name = "txt_grpid_gv";
            this.txt_grpid_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_grpid_gv.TrimRequired = true;
            this.txt_grpid_gv.Visible = false;
            // 
            // GA_007
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(673, 477);
            this.Controls.Add(this.groupBoxPL1);
            this.FindIDRequiredInXML = false;
            this.KeyPreview = true;
            this.Name = "GA_007";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "GA_007";
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_grpdata)).EndInit();
            this.groupBoxPL2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSb.ButtonPL btn_save;
        private PLABSn.DataGridViewPL grd_data;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.ComboBoxPL ddl_addr_id;
        private PLABSc.GroupBoxPL groupBoxPL2;
        private PLABSb.ButtonPL btn_exit;
        private PLABSb.ButtonPL btn_clear;
        private PLABSn.CheckBoxPL chk_all;
        private PLABSn.DataGridViewPL grd_grpdata;
        private PLABSn.PLTextBoxColumn txt_id_gvgrp;
        private PLABSn.PLCheckBoxColumn chk_sel_gvgrp;
        private PLABSn.PLTextBoxColumn txt_head_gvgrp;
        private PLABSn.PLTextBoxColumn txt_id_gv;
        private PLABSn.PLCheckBoxColumn chk_select_gv;
        private PLABSn.PLTextBoxColumn txt_head_gv;
        private PLABSn.PLTextBoxColumn txt_grpid_gv;
    }
}