using RedisConnector;
using Rinner.Helper;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void toolStripConnectBtn_Click(object sender, EventArgs e)
        {
            var frm = new FrmConnector();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var strName = frm.ConnectionName;
                var strConn = frm.ConnectionStr;
                ProcessingBox.Show(new Func<object[], object>(_connect),
                    new object[] { strName, strConn }, _connectCallback);
            }
        }

        private static object _connect(object[] args)
        {
            string name = args[0] as string;
            string str = args[1] as string;
            var connection = DbUtil.Open(str);
            if (connection != null)
            {
                var cluster = new RedisCluster();
                cluster.Connected = true;
                cluster.Connection = connection;
                cluster.Name = name + DateTime.Now.ToString("[HHmmfff]");

                return cluster;
            }
            else
                return null;
        }

        private void _connectCallback(object[] args)
        {
            var cluster = args[0] as RedisCluster;
            //string strName = args[1] as string;    //暂时无用,需要时可以解注释
            //string strConn = args[2] as string;    //暂时无用,需要时可以解注释
            if (cluster != null)
            {
                //添加到连接管理
                ConnectionManager.Connections.Add(cluster.Name, cluster);
                //添加到treeview并展开
                tvConnection.Invoke(() =>
                {
                    TreeNode node = new TreeNode(cluster.Name);
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    tvConnection.Nodes[0].Nodes.Add(node);
                    tvConnection.ExpandAll();
                    tvConnection.SelectedNode = node;
                });
            }
            else
                MessageBox.Show("无法连接到该服务器.");

        }

        private void toolStripManagerBtn_Click(object sender, EventArgs e)
        {
            var frm = new FrmBookmark();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var strName = frm.SelectedConnectionName;
                var strConn = frm.SelectedConnectionStr;
                ProcessingBox.Show(new Func<object[], object>(_connect),
                    new object[] { strName, strConn }, _connectCallback);
            }

        }

        private void tvConnection_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var tv = sender as TreeView;
            if (e.Node != tv.Nodes[0] )
            {
                string key = e.Node.Text;
                var cluster = ConnectionManager.Connections[key];
                if (cluster != null)
                {
                    ProcessingBox.Show(new Func<object[], object>(_readCluster),
                        new object[] { cluster },
                        (arg) => {

                        });
                }
            }
        }

        private static object _readCluster(object[] args)
        {
            var cluster = args[0] as RedisCluster;
            var nodes = cluster.Connection.GetEndPoints();
            foreach (var node in nodes)
            {
                var infos = cluster.Connection.GetServer(node).Info();
                //TODO:根据每个node的Info()返回信息初始化副本集信息
                //infos.ToList().Find(f => f.Key == "Server").ToList().Find(p => p.Key == "run_id").Value;
                //infos.ToList().Find(f => f.Key == "Keyspace").ToList().FindAll(p => p.Key.StartsWith("db"))

            }

            return cluster.Nodes;
        }

        private void toolStripNewQueryBtn_Click(object sender, EventArgs e)
        {
            //TODO:暂时先通过右键菜单关闭, header的处理不太容易
            var menu = new MenuItem("Close", (s, a) => {
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
            });


            //获得当前选中连接
            var key = tvConnection.SelectedNode.Text;

            if (key == "连接管理器")
            {
                return;
            }

            var page = new QueryPage(key);
            page.ContextMenu = new ContextMenu(new MenuItem[] { menu });
            page.Dock = DockStyle.Fill;

            var tab = new TabPage("查询 - " + key);
            tab.Controls.Add(page);

            tabControl.TabPages.Add(tab);
            tab.Select();
        }


    }
}
