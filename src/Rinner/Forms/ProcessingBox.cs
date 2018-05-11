using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rinner.Forms
{
    public partial class ProcessingBox : Form
    {
        private ProcessingBox()
        {
            InitializeComponent();
        }

        private static ProcessingBox _frm = null;
        public static void Show(Func<object[], object> function, object[] args, Action<object> callback)
        {
            if (_frm == null)
                _frm = new ProcessingBox();

            object result = null;
            Task.Factory.StartNew(() => {
                result = function(args);
            }).ContinueWith((t) => {
                Hide();
                callback(result);
            });
            _frm.ShowDialog();
        }

        private new static void Hide()
        {
            if (_frm != null)
                _frm.Close();
        }
    }
}
