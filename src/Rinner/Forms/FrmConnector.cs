using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rinner.Forms
{
    public partial class FrmConnector : Form
    {
        public FrmConnector()
        {
            InitializeComponent();
        }

        private void FrmConnector_Load(object sender, EventArgs e)
        {
            txtStr.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)
                || string.IsNullOrWhiteSpace(txtStr.Text))
            {
                MessageBox.Show("请输入连接名及连接字符串");
                return;
            }
            else
            {
                ConnectionName = txtName.Text.Trim();
                ConnectionStr = txtStr.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        public string ConnectionName { get; set; }
        public string ConnectionStr { get; set; }
    }
}
