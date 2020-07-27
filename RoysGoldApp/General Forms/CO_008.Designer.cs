﻿namespace RoysGold
{
    partial class CO_008
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CO_008));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.btn_exit = new PLABSb.ButtonPL();
            this.grd_data = new PLABSn.DataGridViewPL();
            this.txt_id_gv = new PLABSn.PLTextBoxColumn();
            this.txt_crdt_gv = new PLABSn.PLTextBoxColumn();
            this.txt_title_gv = new PLABSn.PLTextBoxColumn();
            this.txt_dsc_gv = new PLABSn.PLTextBoxColumn();
            this.ddl_typ_gv = new PLABSn.PLComboxBoxColumn();
            this.btn_delete_gv = new PLABSn.PLButtonColumn();
            this.groupBoxPL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
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
            this.groupBoxPL1.Size = new System.Drawing.Size(676, 400);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
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
            this.btn_exit.Location = new System.Drawing.Point(590, 371);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 8;
            this.btn_exit.Text = "&Exit";
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
            this.grd_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_id_gv,
            this.txt_crdt_gv,
            this.txt_title_gv,
            this.txt_dsc_gv,
            this.ddl_typ_gv,
            this.btn_delete_gv});
            this.grd_data.ControlValue = "<ResultDS></ResultDS>";
            this.grd_data.ErrorMessage = "Please Enter At-least One Record";
            this.grd_data.Font = new System.Drawing.Font("Arial", 11F);
            this.grd_data.IsMandatory = true;
            this.grd_data.Location = new System.Drawing.Point(3, 13);
            this.grd_data.Name = "grd_data";
            this.grd_data.ReqdContextMenu = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_data.RowHeadersVisible = false;
            this.grd_data.Size = new System.Drawing.Size(671, 352);
            this.grd_data.SpParameter = "v_Xmldata";
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
            this.txt_id_gv.ReadOnly = true;
            this.txt_id_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_id_gv.TrimRequired = true;
            this.txt_id_gv.Visible = false;
            // 
            // txt_crdt_gv
            // 
            this.txt_crdt_gv.AfterDecimal = 0;
            this.txt_crdt_gv.BeforeDecimal = 0;
            this.txt_crdt_gv.DataPropertyName = "cr_dt";
            this.txt_crdt_gv.DataType = PLEnums.TextDataType.General;
            this.txt_crdt_gv.ErrorMessage = "Please Enter A Value";
            this.txt_crdt_gv.HeaderText = "CREATED ON";
            this.txt_crdt_gv.Name = "txt_crdt_gv";
            this.txt_crdt_gv.ReadOnly = true;
            this.txt_crdt_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_crdt_gv.TrimRequired = true;
            this.txt_crdt_gv.Width = 130;
            // 
            // txt_title_gv
            // 
            this.txt_title_gv.AfterDecimal = 0;
            this.txt_title_gv.BeforeDecimal = 0;
            this.txt_title_gv.DataPropertyName = "title";
            this.txt_title_gv.DataType = PLEnums.TextDataType.General;
            this.txt_title_gv.ErrorMessage = "Please Enter A Value";
            this.txt_title_gv.HeaderText = "TITLE";
            this.txt_title_gv.Name = "txt_title_gv";
            this.txt_title_gv.ReadOnly = true;
            this.txt_title_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_title_gv.TrimRequired = true;
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
            this.txt_dsc_gv.ReadOnly = true;
            this.txt_dsc_gv.TextCase = PLEnums.TextDataCase.None;
            this.txt_dsc_gv.TrimRequired = true;
            // 
            // ddl_typ_gv
            // 
            this.ddl_typ_gv.DataPropertyName = "typ";
            this.ddl_typ_gv.ErrorMessage = "Please Enter A Value";
            this.ddl_typ_gv.HeaderText = "REPEAT";
            this.ddl_typ_gv.Name = "ddl_typ_gv";
            this.ddl_typ_gv.ReadOnly = true;
            this.ddl_typ_gv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ddl_typ_gv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btn_delete_gv
            // 
            this.btn_delete_gv.DataPropertyName = "del";
            this.btn_delete_gv.ErrorMessage = "Please Enter A Value";
            this.btn_delete_gv.HeaderText = "";
            this.btn_delete_gv.Name = "btn_delete_gv";
            // 
            // CO_008
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(678, 392);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "CO_008";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "REMINDER";
            this.groupBoxPL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.DataGridViewPL grd_data;
        private PLABSb.ButtonPL btn_exit;
        private PLABSn.PLTextBoxColumn txt_id_gv;
        private PLABSn.PLTextBoxColumn txt_crdt_gv;
        private PLABSn.PLTextBoxColumn txt_title_gv;
        private PLABSn.PLTextBoxColumn txt_dsc_gv;
        private PLABSn.PLComboxBoxColumn ddl_typ_gv;
        private PLABSn.PLButtonColumn btn_delete_gv;
    }
}