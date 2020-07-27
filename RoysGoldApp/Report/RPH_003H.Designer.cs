namespace RoysGold
{
    partial class RPH_003H
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPH_003H));
            this.wb_leger_dtail = new System.Windows.Forms.WebBrowser();
            this.grp_print = new PLABSc.GroupBoxPL();
            this.btn_print = new PLABSb.ButtonPL();
            this.grp_print.SuspendLayout();
            this.SuspendLayout();
            // 
            // wb_leger_dtail
            // 
            this.wb_leger_dtail.IsWebBrowserContextMenuEnabled = false;
            this.wb_leger_dtail.Location = new System.Drawing.Point(0, 35);
            this.wb_leger_dtail.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_leger_dtail.Name = "wb_leger_dtail";
            this.wb_leger_dtail.Size = new System.Drawing.Size(600, 548);
            this.wb_leger_dtail.TabIndex = 1;
            // 
            // grp_print
            // 
            this.grp_print.BorderWidth = 1F;
            this.grp_print.Caption = "";
            this.grp_print.CaptionImage = null;
            this.grp_print.Controls.Add(this.btn_print);
            this.grp_print.CornersRadius = 2;
            this.grp_print.Font = new System.Drawing.Font("Arial", 11F);
            this.grp_print.ForeColor = System.Drawing.Color.Black;
            this.grp_print.HelpUrl = "";
            this.grp_print.Location = new System.Drawing.Point(1, -10);
            this.grp_print.Name = "grp_print";
            this.grp_print.Padding = new System.Windows.Forms.Padding(20);
            this.grp_print.ShadowColor = System.Drawing.Color.DarkGray;
            this.grp_print.Size = new System.Drawing.Size(957, 45);
            this.grp_print.TabIndex = 2;
            this.grp_print.Themes = "Default";
            this.grp_print.Tooltip = "";
            // 
            // btn_print
            // 
            this.btn_print.ButtonFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.btn_print.ButtonFocusGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(138)))));
            this.btn_print.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btn_print.ClickGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.btn_print.ConfirmationMessage = "";
            this.btn_print.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_print.Font = new System.Drawing.Font("Arial", 11F);
            this.btn_print.ForeColor = System.Drawing.Color.Black;
            this.btn_print.HelpUrl = "";
            this.btn_print.Location = new System.Drawing.Point(870, 16);
            this.btn_print.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_print.MouseOverGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.SucessMessage = "";
            this.btn_print.TabIndex = 0;
            this.btn_print.Text = "Print";
            this.btn_print.Themes = "Default";
            this.btn_print.Tooltip = "";
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // RPH_003H
            // 
            this.AllCntrlCllctn = ((System.Collections.Hashtable)(resources.GetObject("$this.AllCntrlCllctn")));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClearCntrlClctn = ((System.Collections.ArrayList)(resources.GetObject("$this.ClearCntrlClctn")));
            this.ClientSize = new System.Drawing.Size(959, 584);
            this.Controls.Add(this.wb_leger_dtail);
            this.Controls.Add(this.grp_print);
            this.KeyPreview = true;
            this.Name = "RPH_003H";
            this.SaveCntrlCllctn = ((System.Collections.ArrayList)(resources.GetObject("$this.SaveCntrlCllctn")));
            this.Text = "RPH_003H";
            this.grp_print.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb_leger_dtail;
        private PLABSc.GroupBoxPL grp_print;
        private PLABSb.ButtonPL btn_print;
    }
}