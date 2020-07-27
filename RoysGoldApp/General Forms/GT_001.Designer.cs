namespace RoysGold
{
    partial class GT_001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GT_001));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.txt_secs = new PLABSn.TextBoxPL();
            this.txt_mins = new PLABSn.TextBoxPL();
            this.txt_hrs = new PLABSn.TextBoxPL();
            this.labelPL3 = new PLABSn.LabelPL();
            this.labelPL2 = new PLABSn.LabelPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.btn_save = new PLABSb.ButtonPL();
            this.btn_exit = new PLABSb.ButtonPL();
            this.groupBoxPL1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.btn_exit);
            this.groupBoxPL1.Controls.Add(this.btn_save);
            this.groupBoxPL1.Controls.Add(this.txt_secs);
            this.groupBoxPL1.Controls.Add(this.txt_mins);
            this.groupBoxPL1.Controls.Add(this.txt_hrs);
            this.groupBoxPL1.Controls.Add(this.labelPL3);
            this.groupBoxPL1.Controls.Add(this.labelPL2);
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(290, 274);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // txt_secs
            // 
            this.txt_secs.AfterDecimal = 2;
            this.txt_secs.BeforeDecimal = 2;
            this.txt_secs.DataType = PLEnums.TextDataType.Integer;
            this.txt_secs.DefaultValue = "";
            this.txt_secs.ErrorMessage = "Please Enter A Value";
            this.txt_secs.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.txt_secs.ForeColor = System.Drawing.Color.Empty;
            this.txt_secs.Location = new System.Drawing.Point(127, 110);
            this.txt_secs.Name = "txt_secs";
            this.txt_secs.SavingRequired = false;
            this.txt_secs.Size = new System.Drawing.Size(64, 24);
            this.txt_secs.TabIndex = 5;
            this.txt_secs.TextCase = PLEnums.TextDataCase.None;
            this.txt_secs.Tooltip = "";
            this.txt_secs.Watermark = "";
            this.txt_secs.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // txt_mins
            // 
            this.txt_mins.AfterDecimal = 2;
            this.txt_mins.BeforeDecimal = 2;
            this.txt_mins.DataType = PLEnums.TextDataType.Integer;
            this.txt_mins.DefaultValue = "";
            this.txt_mins.ErrorMessage = "Please Enter A Value";
            this.txt_mins.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.txt_mins.ForeColor = System.Drawing.Color.Empty;
            this.txt_mins.Location = new System.Drawing.Point(127, 76);
            this.txt_mins.Name = "txt_mins";
            this.txt_mins.SavingRequired = false;
            this.txt_mins.Size = new System.Drawing.Size(64, 24);
            this.txt_mins.TabIndex = 4;
            this.txt_mins.TextCase = PLEnums.TextDataCase.None;
            this.txt_mins.Tooltip = "";
            this.txt_mins.Watermark = "";
            this.txt_mins.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // txt_hrs
            // 
            this.txt_hrs.AfterDecimal = 2;
            this.txt_hrs.BeforeDecimal = 2;
            this.txt_hrs.DataType = PLEnums.TextDataType.Integer;
            this.txt_hrs.DefaultValue = "";
            this.txt_hrs.ErrorMessage = "Please Enter A Value";
            this.txt_hrs.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.txt_hrs.ForeColor = System.Drawing.Color.Empty;
            this.txt_hrs.Location = new System.Drawing.Point(127, 42);
            this.txt_hrs.Name = "txt_hrs";
            this.txt_hrs.SavingRequired = false;
            this.txt_hrs.Size = new System.Drawing.Size(64, 24);
            this.txt_hrs.TabIndex = 3;
            this.txt_hrs.TextCase = PLEnums.TextDataCase.None;
            this.txt_hrs.Tooltip = "";
            this.txt_hrs.Watermark = "";
            this.txt_hrs.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // labelPL3
            // 
            this.labelPL3.AutoSize = true;
            this.labelPL3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL3.ClearingRequired = false;
            this.labelPL3.ControlValue = "Seconds";
            this.labelPL3.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL3.IsMandatory = false;
            this.labelPL3.Location = new System.Drawing.Point(57, 114);
            this.labelPL3.Name = "labelPL3";
            this.labelPL3.SavingRequired = false;
            this.labelPL3.Size = new System.Drawing.Size(66, 17);
            this.labelPL3.SmartTab = false;
            this.labelPL3.TabIndex = 2;
            this.labelPL3.Text = "Seconds";
            this.labelPL3.Tooltip = "";
            // 
            // labelPL2
            // 
            this.labelPL2.AutoSize = true;
            this.labelPL2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL2.ClearingRequired = false;
            this.labelPL2.ControlValue = "Minutes";
            this.labelPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL2.IsMandatory = false;
            this.labelPL2.Location = new System.Drawing.Point(65, 80);
            this.labelPL2.Name = "labelPL2";
            this.labelPL2.SavingRequired = false;
            this.labelPL2.Size = new System.Drawing.Size(58, 17);
            this.labelPL2.SmartTab = false;
            this.labelPL2.TabIndex = 1;
            this.labelPL2.Text = "Minutes";
            this.labelPL2.Tooltip = "";
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "Hours";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(76, 46);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(47, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 0;
            this.labelPL1.Text = "Hours";
            this.labelPL1.Tooltip = "";
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
            this.btn_save.Location = new System.Drawing.Point(136, 209);
            this.btn_save.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_save.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.SucessMessage = "";
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "&Save";
            this.btn_save.Themes = "Default";
            this.btn_save.Tooltip = "";
            this.btn_save.UseVisualStyleBackColor = true;
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
            this.btn_exit.Location = new System.Drawing.Point(212, 209);
            this.btn_exit.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_exit.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.SucessMessage = "";
            this.btn_exit.TabIndex = 7;
            this.btn_exit.Text = "&Exit";
            this.btn_exit.Themes = "Default";
            this.btn_exit.Tooltip = "";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // GT_001
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "GT_001";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "GT_001";
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.LabelPL labelPL1;
        private PLABSn.LabelPL labelPL3;
        private PLABSn.LabelPL labelPL2;
        private PLABSn.TextBoxPL txt_secs;
        private PLABSn.TextBoxPL txt_mins;
        private PLABSn.TextBoxPL txt_hrs;
        private PLABSb.ButtonPL btn_exit;
        private PLABSb.ButtonPL btn_save;
    }
}