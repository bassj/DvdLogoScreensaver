using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvdScreenSaver
{
    class MultiScreenContext : ApplicationContext
    {
        private int numForms;

        public MultiScreenContext(ScreenSaverForm[] forms)
        {
            numForms = forms.Length;

            foreach (ScreenSaverForm form in forms)
            {
                form.FormClosed += (sender, args) =>
                {
                    if (Interlocked.Decrement(ref numForms) == 0)
                        ExitThread();
                };

                form.Show();
            }
        }
    }
}
