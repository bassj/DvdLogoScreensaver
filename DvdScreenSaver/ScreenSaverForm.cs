using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DvdScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        /// <summary>
        /// The duration of each frame in the animation of the logo.
        /// </summary>
        private const double FRAME_DURATION = 1000 / 60;

        /// <summary>
        /// 
        /// </summary>
        private const int BOUNCE_THRESHOLD = 2;


        /// <summary>
        /// The last position of the mouse, used to determine if the mouse was intentionally moved or just bumped.
        /// </summary>
        private Point LastMousePosition;

        /// <summary>
        /// The Offset of the window, overwrites the Location of the window when loaded.
        /// </summary>
        private Point Offset;

        /// <summary>
        /// The velocity of the logo in the x direction.
        /// </summary>
        private int LogoVelocityX;

        /// <summary>
        /// The velocity of the logo in the y direction.
        /// </summary>
        private int LogoVelocityY;

        /// <summary>
        /// Private variable representing whether the dvdlogo is enabled on this screen or not.
        /// </summary>
        private bool DvdLogoEnabled = true;


        /// <summary>
        /// Was this screen saver started as a demo.
        /// </summary>
        private bool DemoMode = false;

        public ScreenSaverForm()
        {
            InitializeComponent();

            this.MouseMove += ScreenSaverForm_MouseMove;
            this.MouseClick += ScreenSaverForm_MouseClick;
            this.KeyPress += ScreenSaverForm_KeyPress;
        }

        /// <summary>
        /// Initializes the ScreenSaverForm. 
        /// </summary>
        /// <param name="Bounds">The boundaries (size and location) of the window.</param>
        public ScreenSaverForm(Rectangle Bounds) : this()
        {
            this.Bounds = Bounds;
            this.Offset = Bounds.Location; 
        }

        /// <summary>
        /// Initialize the screen saver to a parent window.
        /// </summary>
        /// <param name="Parent">The parent window to initialize to.</param>
        public ScreenSaverForm(IntPtr Parent) : this()
        {
            //A load of black magic that parents this screensaver to another window.
            SetParent(this.Handle, Parent);
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(Parent, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            DemoMode = true;
        }

        /// <summary>
        /// Sets whether the logo should show on this form.
        /// </summary>
        /// <param name="enabled">True if logo enabled, false if logo disabled.</param>
        public void SetLogoEnabled(bool enabled)
        {
            DvdLogoEnabled = enabled;
        }

        /// <summary>
        /// Hides the cursor and make the window fullscreen.
        /// </summary>
        /// <param name="sender">The sender of the load event.</param>
        /// <param name="e">The arguments to the load event.</param>
        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            this.Location = this.Offset;
            this.WindowState = FormWindowState.Maximized;
            TopMost = true;

            if (DemoMode)
            {
                dvdLogo.Width = dvdLogo.Width / 10;
                dvdLogo.Height = dvdLogo.Height / 10;
                dvdLogo.Refresh();
            }
            else
            {
                Cursor.Hide();
            }

            if (DvdLogoEnabled)
            {
                //places the dvd logo in a random location on the screen.
                Random r = new Random();

                //dvdLogo.Location = new Point(r.Next(LogoBounds.Right), r.Next(LogoBounds.Bottom));
                dvdLogo.Location = new Point(0, 900);

                //sets the velocity of the logo in a random direction.
                this.LogoVelocityX = (int)(((r.NextDouble() / 2) + 0.5) * Properties.Settings.Default.LogoSpeed / ((DemoMode)? 10 : 1));
                this.LogoVelocityY = (int)(((r.NextDouble() / 2) + 0.5) * Properties.Settings.Default.LogoSpeed / ((DemoMode) ? 10 : 1));

                //Create a timer that updates 60 times a second, and assigning it the function that moves the logo.
                animationTimer.Interval = (int)FRAME_DURATION;
                animationTimer.Tick += LogoAnimator;
                animationTimer.Start();
            } else
            {
                this.dvdLogo.Hide();
            }
        }

        /// <summary>
        /// Moves the logo.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void LogoAnimator(object sender, EventArgs e)
        {
            //Make the logo bounce off the walls.
            if (Math.Abs(dvdLogo.Top - Bounds.Top) < BOUNCE_THRESHOLD && LogoVelocityY < 0)
            {
                this.LogoVelocityY = -this.LogoVelocityY;
            } else if (Math.Abs(dvdLogo.Bottom - Bounds.Bottom) < BOUNCE_THRESHOLD && LogoVelocityY > 0)
            {
                this.LogoVelocityY = -this.LogoVelocityY;
            }

            if (Math.Abs(dvdLogo.Left - Bounds.Left) < BOUNCE_THRESHOLD && LogoVelocityX < 0)
            {
                this.LogoVelocityX = -this.LogoVelocityX;
            } else if (Math.Abs(dvdLogo.Right - Bounds.Right) < BOUNCE_THRESHOLD && LogoVelocityX > 0)
            {
                this.LogoVelocityX = -this.LogoVelocityX;
            }

            //Move the logo.
            //the frame duration in seconds, not milliseconds.
            double duration = FRAME_DURATION / 1000;

            double movementX = duration * this.LogoVelocityX;
            double movementY = duration * this.LogoVelocityY;

            Point updatedPosition = new Point();
            updatedPosition.X = Math.Max(Math.Min((int)(dvdLogo.Left + movementX), Bounds.Right - dvdLogo.Width), Bounds.Left);
            updatedPosition.Y = Math.Max(Math.Min((int)(dvdLogo.Top + movementY), Bounds.Bottom - dvdLogo.Height), Bounds.Top);

            dvdLogo.Location = updatedPosition;
        }

        /// <summary>
        /// Closes window when the mouse moves more than the set wakeup distance.
        /// </summary>
        /// <param name="sender">The sender of the mousemove event.</param>
        /// <param name="e">The arguments to the mousemove event.</param>
        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DemoMode)
            {
                if (LastMousePosition.IsEmpty)
                {
                    LastMousePosition = e.Location;
                    return;
                }

                //distance formula
                int a = LastMousePosition.X - e.X;
                int b = LastMousePosition.Y - e.Y;

                if (Math.Sqrt(a * a + b * b) >= Properties.Settings.Default.MouseMoveDistance)
                {
                    Application.Exit();
                }

                LastMousePosition = e.Location;
            }
        }

        /// <summary>
        /// Closes the window when the mouse is clicked.
        /// </summary>
        /// <param name="sender">The sender of the mouseclick event.</param>
        /// <param name="e">The arguments to the mouseclick event.</param>
        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!DemoMode)
                Application.Exit();
        }

        /// <summary>
        /// Closes the window when a key is pressed.
        /// </summary>
        /// <param name="sender">The sender of the keypress event.</param>
        /// <param name="e">The arguments to the keypress event.</param>
        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!DemoMode)
                Application.Exit();
        }
    }
}
