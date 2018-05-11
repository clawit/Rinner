using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedisConnector;

namespace Rinner.Forms
{
    public partial class QueryPage : UserControl
    {
        private string _key { get; set; }

        private RedisCluster _cluster = null;

        public QueryPage(string key)
        {
            InitializeComponent();

            var cluster = ConnectionManager.Connections[key];
            if (cluster != null)
            {
                _cluster = cluster;
                _key = key;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //检查输入
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("请先输入查询的键和类型");
                return;
            }

            var input = txtKey.Text.Trim();

            ProcessingBox.Show(new Func<object[], object>(_readKeyTTL),
                    new object[] { _cluster, input, dvKeys },
                    (arg) => {
                        var dt = arg as DataTable;
                        dvKeys.DataSource = dt;
                        dvKeys.CellDoubleClick += DvKeys_CellDoubleClick;
                    });
        }

        private void DvKeys_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dr = dvKeys.Rows[e.RowIndex];
            string key = dr.Cells[0].Value.ToString();
            var value = _cluster.Connection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                var page = new StringValuePage();
                page.StringFormat = "Text";
                page.Value = value;
                splitContainer.Panel2.Controls.Add(page);
            }


        }

        private static object _readKeyTTL(object[] args)
        {
            var cluster = args[0] as RedisCluster;
            var key = args[1] as string;
            var dvKeys = args[2] as DataGridView;
            var ttl = cluster.Connection.GetDatabase().KeyTimeToLive(key).GetValueOrDefault();
            if (ttl != null)
            {
                var seconds = ttl.TotalSeconds;
                var dt = new DataTable();
                dt.Columns.Add("键");
                dt.Columns.Add("存活时间");
                dt.Columns.Add("类型");
                dt.Columns.Add("数据位置");
                dt.Rows.Add(new string[] { key, seconds.ToString(), "String", cluster.Name });
                return dt;
            }
            else
                return null;
        }
    }
}
