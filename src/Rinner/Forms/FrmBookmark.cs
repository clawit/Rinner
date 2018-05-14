using Rinner.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rinner.Forms
{
    public partial class FrmBookmark : Form
    {
        public FrmBookmark()
        {
            InitializeComponent();

            _data.Columns.Add("名称");
            _data.Columns.Add("连接字符串");
        }

        private string _file = "bookmark.json";
        private DataTable _data = new DataTable();

        public string SelectedConnectionName { get; set; }
        public string SelectedConnectionStr { get; set; }

        private void dvBookmark_DoubleClick(object sender, EventArgs e)
        {
            _finishChoose();
        }

        private void _finishChoose()
        {
            var index = dvBookmark.CurrentRow.Index;
            var dr = dvBookmark.Rows[index];
            string name = dr.Cells[0].Value.ToString();
            string str = dr.Cells[1].Value.ToString();
            SelectedConnectionName = name;
            SelectedConnectionStr = str;
            DialogResult = DialogResult.OK;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new FrmConnector();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var strName = frm.ConnectionName;
                var strConn = frm.ConnectionStr;

                _data.Rows.Add(new string[] { strName, strConn });
                dvBookmark.DataSource = _data;

                _writeJson();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (dvBookmark.CurrentRow != null && dvBookmark.CurrentRow.Index >= 0)
            {
                _finishChoose();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void _readJson()
        {
            if (File.Exists(_file))
            {
                string json = File.ReadAllText(_file);
                if (!string.IsNullOrEmpty(json))
                {
                    //先清除所有行
                    foreach (DataRow row in _data.Rows)
                    {
                        _data.Rows.Remove(row);
                    }

                    //逐行读取
                    dynamic links = DynamicJson.Parse(json);
                    foreach (var link in links)
                    {
                        string key = link.Name;
                        string value = link.Value;
                        _data.Rows.Add(new string[] { key, value });
                    }

                    //绑定数据
                    dvBookmark.DataSource = _data;
                }


            }
        }

        private void _writeJson()
        {
            string json = string.Empty;

            List<Link> parts = new List<Link>();
            foreach (DataRow row in _data.Rows)
            {
                string name = row[0].ToString();
                string value = row[1].ToString();

                parts.Add(new Link() { Name = name, Value = value });
            }

            json = DynamicJson.Serialize(parts.ToArray());

            
            File.WriteAllText(_file, json);
        }

        private void FrmBookmark_Load(object sender, EventArgs e)
        {
            _readJson();
        }
    }

    public class Link
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
