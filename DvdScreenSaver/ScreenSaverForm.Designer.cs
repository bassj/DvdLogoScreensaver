namespace DvdScreenSaver
{
    partial class ScreenSaverForm
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
            this.dvdLogo = new System.Windows.Forms.PictureBox();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dvdLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dvdLogo
            // 
            this.dvdLogo.Image = global::DvdScreenSaver.Properties.Resources.dvdvideo2;
            this.dvdLogo.Location = new System.Drawing.Point(0, 0);
            this.dvdLogo.Name = "dvdLogo";
            this.dvdLogo.Size = new System.Drawing.Size(196, 112);
            this.dvdLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dvdLogo.TabIndex = 0;
            this.dvdLogo.TabStop = false;
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dvdLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvdLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox dvdLogo;
        private System.Windows.Forms.Timer animationTimer;
    }
}

