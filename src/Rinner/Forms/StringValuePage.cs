using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rinner.Forms
{
    public partial class StringValuePage : UserControl
    {
        public StringValuePage()
        {
            InitializeComponent();
        }

        public string StringFormat
        {
            get { return cbxFormat.SelectedText; }
            set { cbxFormat.SelectedText = value; }
        }

        public string Value
        {
            get { return txtValue.Text.Trim(); }
            set { txtValue.Text = value; }
        }
    }
}
