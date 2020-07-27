namespace RoysGold
{
    partial class CO_003
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CO_003));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.txt_name = new PLABSn.TextBoxPL();
            this.lst_search = new PLABSn.ListViewNormalPL();
            this.pLabsListViewColHdr1 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr4 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr2 = new PLABSn.PLabsListViewColHdr();
            this.pLabsListViewColHdr3 = new PLABSn.PLabsListViewColHdr();
            this.groupBoxPL2 = new PLABSc.GroupBoxPL();
            this.labelPL2 = new PLABSn.LabelPL();
            this.lbl_clsng = new PLABSn.LabelPL();
            this.btn_exit = new PLABSb.ButtonPL();
            this.btn_ok = new PLABSb.ButtonPL();
            this.groupBoxPL1.SuspendLayout();
            this.groupBoxPL2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.Controls.Add(this.txt_name);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(474, 68);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "Name";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(5, 29);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(47, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 1;
            this.labelPL1.Text = "Name";
            this.labelPL1.Tooltip = "";
            // 
            // txt_name
            // 
            this.txt_name.AfterDecimal = 2;
            this.txt_name.BeforeDecimal = 0;
            this.txt_name.DataType = PLEnums.TextDataType.General;
            this.txt_name.DefaultValue = "";
            this.txt_name.ErrorMessage = "Please Enter A Value";
            this.txt_name.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.txt_name.ForeColor = System.Drawing.Color.Empty;
            this.txt_name.Location = new System.Drawing.Point(56, 25);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(157, 24);
            this.txt_name.SmartTab = false;
            this.txt_name.SpParameter = "as_name";
            this.txt_name.TabIndex = 0;
            this.txt_name.TextCase = PLEnums.TextDataCase.None;
            this.txt_name.Tooltip = "";
            this.txt_name.Watermark = "";
            this.txt_name.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // lst_search
            // 
            this.lst_search.AllowCellToolTip = true;
            this.lst_search.CheckedColumnIndex = -1;
            this.lst_search.CheckedValue = "";
            this.lst_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pLabsListViewColHdr1,
            this.pLabsListViewColHdr4,
            this.pLabsListViewColHdr2,
            this.pLabsListViewColHdr3});
            this.lst_search.DefaultValue = "";
            this.lst_search.EditableColumnIndex = -1;
            this.lst_search.EditableValue = "";
            this.lst_search.Font = new System.Drawing.Font("Arial", 11F);
            this.lst_search.ForeColor = System.Drawing.Color.Black;
            this.lst_search.FullRowSelect = true;
            this.lst_search.GradiantColor = System.Drawing.Color.White;
            this.lst_search.GradiantColorMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lst_search.GridLines = true;
            this.lst_search.IsMandatory = false;
            this.lst_search.Location = new System.Drawing.Point(1, 60);
            this.lst_search.Name = "lst_search";
            this.lst_search.ReqdChkedValueINXml = false;
            this.lst_search.SchemaRequired = false;
            this.lst_search.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(220)))), ((int)(((byte)(252)))));
            this.lst_search.SelectionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(162)))), ((int)(((byte)(206)))));
            this.lst_search.SelectionGradiantColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.lst_search.ShowContextMenu = false;
            this.lst_search.Size = new System.Drawing.Size(474, 257);
            this.lst_search.SpParameter = "ai_dtlXml";
            this.lst_search.TabIndex = 4;
            this.lst_search.Tooltip = "";
            this.lst_search.UseCompatibleStateImageBehavior = false;
            this.lst_search.View = System.Windows.Forms.View.Details;
            this.lst_search.XmlOutPut = PLEnums.XmlOutPutType.AllItems;
            // 
            // pLabsListViewColHdr1
            // 
            this.pLabsListViewColHdr1.DataColumnName = "date";
            this.pLabsListViewColHdr1.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr1.FormatString = "";
            this.pLabsListViewColHdr1.ReqdForSave = true;
            this.pLabsListViewColHdr1.Resizable = true;
            this.pLabsListViewColHdr1.Text = "Date";
            this.pLabsListViewColHdr1.Width = 80;
            // 
            // pLabsListViewColHdr4
            // 
            this.pLabsListViewColHdr4.DataColumnName = "nar";
            this.pLabsListViewColHdr4.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr4.FormatString = "";
            this.pLabsListViewColHdr4.ReqdForSave = true;
            this.pLabsListViewColHdr4.Resizable = true;
            this.pLabsListViewColHdr4.Text = "Narration";
            this.pLabsListViewColHdr4.Width = 190;
            // 
            // pLabsListViewColHdr2
            // 
            this.pLabsListViewColHdr2.DataColumnName = "dr_amount";
            this.pLabsListViewColHdr2.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr2.FormatString = "";
            this.pLabsListViewColHdr2.ReqdForSave = true;
            this.pLabsListViewColHdr2.Resizable = true;
            this.pLabsListViewColHdr2.Text = "Payment";
            this.pLabsListViewColHdr2.Width = 100;
            // 
            // pLabsListViewColHdr3
            // 
            this.pLabsListViewColHdr3.DataColumnName = "cr_amount";
            this.pLabsListViewColHdr3.DataType = PLEnums.ListViewDataTypes.String;
            this.pLabsListViewColHdr3.FormatString = "";
            this.pLabsListViewColHdr3.ReqdForSave = true;
            this.pLabsListViewColHdr3.Resizable = true;
            this.pLabsListViewColHdr3.Text = "Reciept";
            this.pLabsListViewColHdr3.Width = 100;
            // 
            // groupBoxPL2
            // 
            this.groupBoxPL2.BorderWidth = 1F;
            this.groupBoxPL2.Caption = "";
            this.groupBoxPL2.CaptionImage = null;
            this.groupBoxPL2.Controls.Add(this.labelPL2);
            this.groupBoxPL2.Controls.Add(this.lbl_clsng);
            this.groupBoxPL2.Controls.Add(this.btn_exit);
            this.groupBoxPL2.Controls.Add(this.btn_ok);
            this.groupBoxPL2.CornersRadius = 2;
            this.groupBoxPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL2.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL2.HelpUrl = "";
            this.groupBoxPL2.Location = new System.Drawing.Point(1, 308);
            this.groupBoxPL2.Name = "groupBoxPL2";
            this.groupBoxPL2.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL2.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL2.Size = new System.Drawing.Size(474, 46);
            this.groupBoxPL2.TabIndex = 5;
            this.groupBoxPL2.Themes = "Default";
            this.groupBoxPL2.Tooltip = "";
            // 
            // labelPL2
            // 
            this.labelPL2.AutoSize = true;
            this.labelPL2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL2.ClearingRequired = false;
            this.labelPL2.ControlValue = "Total";
            this.labelPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL2.IsMandatory = false;
            this.labelPL2.Location = new System.Drawing.Point(252, 18);
            this.labelPL2.Name = "labelPL2";
            this.labelPL2.SavingRequired = false;
            this.labelPL2.Size = new System.Drawing.Size(38, 17);
            this.labelPL2.SmartTab = false;
            this.labelPL2.TabIndex = 7;
            this.labelPL2.Text = "Total";
            this.labelPL2.Tooltip = "";
            // 
            // lbl_clsng
            // 
            this.lbl_clsng.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.lbl_clsng.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_clsng.ClearingRequired = false;
            this.lbl_clsng.ControlValue = "";
            this.lbl_clsng.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_clsng.IsMandatory = false;
            this.lbl_clsng.Location = new System.Drawing.Point(305, 17);
            this.lbl_clsng.Name = "lbl_clsng";
            this.lbl_clsng.SavingRequired = false;
            this.lbl_clsng.Size = new System.Drawing.Size(163, 20);
            this.lbl_clsng.SmartTab = false;
            this.lbl_clsng.TabIndex = 6;
            this.lbl_clsng.Text = "";
            this.lbl_clsng.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_clsng.Tooltip = "";
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
            this.btn_exit.Location = new System.Drawing.Point(91, 15);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "&Exit";
            this.btn_exit.Themes = "Default";
            this.btn_exit.Tooltip = "";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Visible = false;
            // 
            // btn_ok
            // 
            this.btn_ok.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_ok.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_ok.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_ok.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_ok.ConfirmationMessage = "";
            this.btn_ok.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_ok.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_ok.ForeColor = System.Drawing.Color.Black;
            this.btn_ok.HelpUrl = "";
            this.btn_ok.Location = new System.Drawing.Point(13, 15);
            this.btn_ok.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_ok.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.SucessMessage = "";
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "&Ok";
            this.btn_ok.Themes = "Default";
            this.btn_ok.Tooltip = "";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Visible = false;
            // 
            // CO_003
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(476, 355);
            this.Controls.Add(this.lst_search);
            this.Controls.Add(this.groupBoxPL2);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "CO_003";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "Sheet";
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            this.groupBoxPL2.ResumeLayout(false);
            this.groupBoxPL2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.TextBoxPL txt_name;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.ListViewNormalPL lst_search;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr1;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr4;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr2;
        private PLABSn.PLabsListViewColHdr pLabsListViewColHdr3;
        private PLABSc.GroupBoxPL groupBoxPL2;
        private PLABSb.ButtonPL btn_exit;
        private PLABSb.ButtonPL btn_ok;
        private PLABSn.LabelPL lbl_clsng;
        private PLABSn.LabelPL labelPL2;
    }
}