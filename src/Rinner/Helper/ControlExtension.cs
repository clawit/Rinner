using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rinner.Helper
{
    public static class ControlExtension
    {
        public static void Invoke(this Control control, MethodInvoker action)
        {
            control.Invoke(action);
        }
    }
}
