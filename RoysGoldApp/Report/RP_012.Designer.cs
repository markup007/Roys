namespace RoysGold
{
    partial class RP_012
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
            PLABSn.PLabsColumnProp pLabsColumnProp1 = new PLABSn.PLabsColumnProp();
            PLABSn.PLabsColumnProp pLabsColumnProp2 = new PLABSn.PLabsColumnProp();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RP_012));
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.btn_prt = new PLABSb.ButtonPL();
            this.txt_pgno = new PLABSn.TextBoxPL();
            this.labelPL2 = new PLABSn.LabelPL();
            this.labelPL1 = new PLABSn.LabelPL();
            this.fnd_smth = new PLABSn.FindControlPL();
            this.rtxt_rpt = new System.Windows.Forms.RichTextBox();
            this.groupBoxPL1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.btn_prt);
            this.groupBoxPL1.Controls.Add(this.txt_pgno);
            this.groupBoxPL1.Controls.Add(this.labelPL2);
            this.groupBoxPL1.Controls.Add(this.labelPL1);
            this.groupBoxPL1.Controls.Add(this.fnd_smth);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(481, 60);
            this.groupBoxPL1.TabIndex = 0;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // btn_prt
            // 
            this.btn_prt.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_prt.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_prt.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_prt.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_prt.ConfirmationMessage = "";
            this.btn_prt.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_prt.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_prt.ForeColor = System.Drawing.Color.Black;
            this.btn_prt.HelpUrl = "";
            this.btn_prt.Location = new System.Drawing.Point(400, 20);
            this.btn_prt.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_prt.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_prt.Name = "btn_prt";
            this.btn_prt.Size = new System.Drawing.Size(75, 23);
            this.btn_prt.SucessMessage = "";
            this.btn_prt.TabIndex = 1;
            this.btn_prt.Text = "&Print";
            this.btn_prt.Themes = "Default";
            this.btn_prt.Tooltip = "";
            this.btn_prt.UseVisualStyleBackColor = false;
            // 
            // txt_pgno
            // 
            this.txt_pgno.AfterDecimal = 2;
            this.txt_pgno.BeforeDecimal = 0;
            this.txt_pgno.DataType = PLEnums.TextDataType.General;
            this.txt_pgno.DefaultValue = "";
            this.txt_pgno.ErrorMessage = "Please Enter A Value";
            this.txt_pgno.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.txt_pgno.ForeColor = System.Drawing.Color.Empty;
            this.txt_pgno.Location = new System.Drawing.Point(327, 20);
            this.txt_pgno.Name = "txt_pgno";
            this.txt_pgno.SavingRequired = false;
            this.txt_pgno.Size = new System.Drawing.Size(52, 24);
            this.txt_pgno.TabIndex = 2;
            this.txt_pgno.TextCase = PLEnums.TextDataCase.None;
            this.txt_pgno.Tooltip = "";
            this.txt_pgno.Watermark = "";
            this.txt_pgno.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // labelPL2
            // 
            this.labelPL2.AutoSize = true;
            this.labelPL2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL2.ClearingRequired = false;
            this.labelPL2.ControlValue = "Print No";
            this.labelPL2.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL2.IsMandatory = false;
            this.labelPL2.Location = new System.Drawing.Point(261, 23);
            this.labelPL2.Name = "labelPL2";
            this.labelPL2.SavingRequired = false;
            this.labelPL2.Size = new System.Drawing.Size(60, 17);
            this.labelPL2.SmartTab = false;
            this.labelPL2.TabIndex = 4;
            this.labelPL2.Text = "Print No";
            this.labelPL2.Tooltip = "";
            // 
            // labelPL1
            // 
            this.labelPL1.AutoSize = true;
            this.labelPL1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.labelPL1.ClearingRequired = false;
            this.labelPL1.ControlValue = "Smith";
            this.labelPL1.Font = new System.Drawing.Font("Arial", 11F);
            this.labelPL1.IsMandatory = false;
            this.labelPL1.Location = new System.Drawing.Point(5, 23);
            this.labelPL1.Name = "labelPL1";
            this.labelPL1.SavingRequired = false;
            this.labelPL1.Size = new System.Drawing.Size(46, 17);
            this.labelPL1.SmartTab = false;
            this.labelPL1.TabIndex = 3;
            this.labelPL1.Text = "Smith";
            this.labelPL1.Tooltip = "";
            // 
            // fnd_smth
            // 
            this.fnd_smth.BackColor = System.Drawing.Color.White;
            this.fnd_smth.BorderColor = System.Drawing.Color.Green;
            this.fnd_smth.ButtonBackColor = System.Drawing.Color.Transparent;
            this.fnd_smth.ButtonBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fnd_smth.CodeColumnName = "";
            this.fnd_smth.CodeTxtWidth = 40;
            pLabsColumnProp1.ColumnCaption = "ID";
            pLabsColumnProp1.DataPropertyName = "id";
            pLabsColumnProp1.DataType = PLEnums.ListViewDataTypes.String;
            pLabsColumnProp1.FormatString = "";
            pLabsColumnProp1.ReqdForSave = true;
            pLabsColumnProp1.Resizable = true;
            pLabsColumnProp1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            pLabsColumnProp1.Width = 0;
            pLabsColumnProp2.ColumnCaption = "Smith";
            pLabsColumnProp2.DataPropertyName = "nam";
            pLabsColumnProp2.DataType = PLEnums.ListViewDataTypes.String;
            pLabsColumnProp2.FormatString = "";
            pLabsColumnProp2.ReqdForSave = true;
            pLabsColumnProp2.Resizable = true;
            pLabsColumnProp2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            pLabsColumnProp2.Width = 250;
            this.fnd_smth.Columns.Add(pLabsColumnProp1);
            this.fnd_smth.Columns.Add(pLabsColumnProp2);
            this.fnd_smth.ControlValue = "";
            this.fnd_smth.DefaultValue = "";
            this.fnd_smth.DescriptionColumnName = "";
            this.fnd_smth.DescriptionRequired = false;
            this.fnd_smth.ErrorMessage = "Please Select At-Least One Item";
            this.fnd_smth.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.fnd_smth.Font = new System.Drawing.Font("Arial", 11F);
            this.fnd_smth.ForeColor = System.Drawing.Color.Black;
            this.fnd_smth.GridHeight = 300;
            this.fnd_smth.GridWidth = 250;
            this.fnd_smth.ImageType = PLEnums.ControlSearchType.Search;
            this.fnd_smth.ListViewName = "";
            this.fnd_smth.Location = new System.Drawing.Point(57, 21);
            this.fnd_smth.Name = "fnd_smth";
            this.fnd_smth.ParentCell = null;
            this.fnd_smth.SavingRequired = false;
            this.fnd_smth.SelectedCode = "";
            this.fnd_smth.SelectedColumnColor = System.Drawing.Color.LightGray;
            this.fnd_smth.SelectedDescription = "";
            this.fnd_smth.SelectedValue = "";
            this.fnd_smth.Size = new System.Drawing.Size(185, 23);
            this.fnd_smth.TabIndex = 0;
            this.fnd_smth.Tooltip = "";
            this.fnd_smth.ValueColumnName = "";
            // 
            // rtxt_rpt
            // 
            this.rtxt_rpt.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_rpt.Location = new System.Drawing.Point(1, 52);
            this.rtxt_rpt.Name = "rtxt_rpt";
            this.rtxt_rpt.Size = new System.Drawing.Size(481, 339);
            this.rtxt_rpt.TabIndex = 1;
            this.rtxt_rpt.Text = "";
            // 
            // RP_012
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(483, 392);
            this.Controls.Add(this.rtxt_rpt);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "RP_012";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "RP_012";
            this.groupBoxPL1.ResumeLayout(false);
            this.groupBoxPL1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSc.GroupBoxPL groupBoxPL1;
        private PLABSn.FindControlPL fnd_smth;
        private PLABSb.ButtonPL btn_prt;
        private PLABSn.TextBoxPL txt_pgno;
        private PLABSn.LabelPL labelPL2;
        private PLABSn.LabelPL labelPL1;
        private System.Windows.Forms.RichTextBox rtxt_rpt;
    }
}