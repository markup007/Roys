namespace RoysGold
{
    partial class report_viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(report_viewer));
            this.btn_print = new PLABSb.ButtonPL();
            this.groupBoxPL1 = new PLABSc.GroupBoxPL();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxPL1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_print
            // 
            this.btn_print.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_print.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_print.ConfirmationMessage = "";
            this.btn_print.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_print.ForeColor = System.Drawing.Color.Black;
            this.btn_print.HelpUrl = "";
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.Location = new System.Drawing.Point(857, 631);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(56, 25);
            this.btn_print.SucessMessage = "";
            this.btn_print.TabIndex = 1;
            this.btn_print.Text = "&Print";
            this.btn_print.Themes = "Default";
            this.btn_print.Tooltip = "";
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // groupBoxPL1
            // 
            this.groupBoxPL1.BorderWidth = 1F;
            this.groupBoxPL1.Caption = "";
            this.groupBoxPL1.CaptionImage = null;
            this.groupBoxPL1.Controls.Add(this.richTextBox1);
            this.groupBoxPL1.Controls.Add(this.btn_print);
            this.groupBoxPL1.CornersRadius = 2;
            this.groupBoxPL1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBoxPL1.ForeColor = System.Drawing.Color.Black;
            this.groupBoxPL1.HelpUrl = "";
            this.groupBoxPL1.Location = new System.Drawing.Point(1, -9);
            this.groupBoxPL1.Name = "groupBoxPL1";
            this.groupBoxPL1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxPL1.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupBoxPL1.Size = new System.Drawing.Size(924, 672);
            this.groupBoxPL1.TabIndex = 2;
            this.groupBoxPL1.Themes = "Default";
            this.groupBoxPL1.Tooltip = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(11, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(900, 600);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // report_viewer
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(926, 664);
            this.Controls.Add(this.groupBoxPL1);
            this.KeyPreview = true;
            this.Name = "report_viewer";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "Report viewer";
            this.groupBoxPL1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PLABSb.ButtonPL btn_print;
        private PLABSc.GroupBoxPL groupBoxPL1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}