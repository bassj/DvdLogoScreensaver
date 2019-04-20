using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvdScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //TODO: Process screen saver parameters.
            if (args.Length > 0)
            {
                string arg1 = args[0].ToLower().Trim();
                string param = null;

                if (arg1.Length > 2)
                {
                    param = arg1.Substring(3).Trim();
                    arg1 = arg1.Substring(0, 2);
                } else if (args.Length > 1)
                {
                    param = args[1];
                }

                if (arg1.Equals("/c"))
                    ShowConfigDialog(null);

                if (arg1.Equals("/s"))
                    ShowScreenSaver(param);

                if (arg1.Equals("/p"))
                    ShowScreenSaver(param);


                Console.WriteLine("Invalid Parameters.");
                Application.Exit();

            } else
            {
                ShowConfigDialog(null);
            }
        }

        /// <summary>
        /// Displays a configuration form.
        /// </summary>
        /// <param name="param">
        ///     command line parameter passed to this function.
        /// </param>
        static void ShowConfigDialog(string param)
        {
            Application.Run(new ScreensaverConfigForm());
        }


        /// <summary>
        /// Instantiates the screen saver for each monitor.
        /// </summary>
        /// <param name="param">
        ///     command line parameter passed to this function.
        ///     The only possiblity is a pointer to the parent to create the screensaver under.
        /// </param>
        static void ShowScreenSaver(string param)
        {
            if (param == null)
            {
                ScreenSaverForm[] forms = new ScreenSaverForm[Screen.AllScreens.Length];


                for (int index = 0; index < Screen.AllScreens.Length; index++)
                {
                    ScreenSaverForm saver = new ScreenSaverForm(Screen.AllScreens[index].Bounds);

                    saver.SetLogoEnabled(Screen.AllScreens[index].Primary | Properties.Settings.Default.ShowLogoOnAllScreens);

                    forms[index] = saver;
                }

                Application.Run(new MultiScreenContext(forms));
            } else
            { 
                IntPtr windowHandle = new IntPtr(long.Parse(param));

                Application.Run(new ScreenSaverForm(windowHandle));
            }
        }
    }
}
