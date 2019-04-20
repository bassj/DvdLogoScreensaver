namespace DvdScreenSaver
{
    partial class ScreensaverConfigForm
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
            this.logoSpeedBar = new System.Windows.Forms.TrackBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.monitorCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoSpeedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // logoSpeedBar
            // 
            this.logoSpeedBar.LargeChange = 1;
            this.logoSpeedBar.Location = new System.Drawing.Point(149, 12);
            this.logoSpeedBar.Name = "logoSpeedBar";
            this.logoSpeedBar.Size = new System.Drawing.Size(118, 45);
            this.logoSpeedBar.TabIndex = 0;
            this.logoSpeedBar.Value = 5;
            this.logoSpeedBar.Scroll += new System.EventHandler(this.logoSpeedBar_Scroll);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(12, 12);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(65, 13);
            this.speedLabel.TabIndex = 1;
            this.speedLabel.Text = "Logo Speed";
            this.speedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monitorCheck
            // 
            this.monitorCheck.AutoSize = true;
            this.monitorCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.monitorCheck.Location = new System.Drawing.Point(12, 52);
            this.monitorCheck.Name = "monitorCheck";
            this.monitorCheck.Size = new System.Drawing.Size(152, 17);
            this.monitorCheck.TabIndex = 2;
            this.monitorCheck.Text = "Show logo on all monitors?";
            this.monitorCheck.UseVisualStyleBackColor = true;
            this.monitorCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ScreensaverConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 192);
            this.Controls.Add(this.monitorCheck);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.logoSpeedBar);
            this.Name = "ScreensaverConfigForm";
            this.Text = "Screensaver Config";
            this.Load += new System.EventHandler(this.ScreensaverConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoSpeedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar logoSpeedBar;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.CheckBox monitorCheck;
    }
}