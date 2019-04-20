using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvdScreenSaver
{
    public partial class ScreensaverConfigForm : Form
    {
        /// <summary>
        /// Initializes the form.
        /// </summary>
        public ScreensaverConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the appropriate values to the fields of the form on load.
        /// </summary>
        /// <param name="sender">The sender of the load event.</param>
        /// <param name="e">The arguments of the load event.</param>
        private void ScreensaverConfigForm_Load(object sender, EventArgs e)
        {
            monitorCheck.Checked = Properties.Settings.Default.ShowLogoOnAllScreens;
            logoSpeedBar.Value = (int)((Properties.Settings.Default.LogoSpeed - 200) / 20);
        }

        /// <summary>
        /// Changes the ShowLogoOnAllScreens setting when the box is checked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowLogoOnAllScreens = monitorCheck.Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Changes the LogoSpeed setting when the trackbar is moved.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void logoSpeedBar_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.LogoSpeed = logoSpeedBar.Value * 20 + 200;
            Properties.Settings.Default.Save();
        }
    }
}
