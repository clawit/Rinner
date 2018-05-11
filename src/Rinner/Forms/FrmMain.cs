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
                    new object[] { strName, strConn }, 
                    (arg) => {
                        var cluster = arg as RedisCluster;
                        if (cluster != null)
                        {
                            //添加到连接管理
                            ConnectionManager.Connections.Add(strName, cluster);
                            //添加到treeview并展开
                            tvConnection.Invoke(() =>
                            {
                                tvConnection.Nodes[0].Nodes.Add(strName);
                                tvConnection.ExpandAll();
                            });
                        }
                        else
                            MessageBox.Show("无法连接到该服务器.");
                    });
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
                cluster.Name = name;

                return cluster;
            }
            else
                return null;
        }

        private void toolStripManagerBtn_Click(object sender, EventArgs e)
        {
            
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

            var page = new QueryPage(key);
            page.ContextMenu = new ContextMenu(new MenuItem[] { menu });

            var tab = new TabPage("Query");
            tab.Controls.Add(page);

            tabControl.TabPages.Add(tab);
            tab.Select();
        }


    }
}
