using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeChannels();
        }

        private void InitializeChannels()
        {
            List<Uri> addresses = new List<Uri>();
            addresses.Add(new Uri("http://192.168.25.1:30001/Faculties"));
            addresses.Add(new Uri("http://192.168.25.1:30001/Chairs"));
            addresses.Add(new Uri("http://192.168.25.1:30001/Teachers"));
            addresses.Add(new Uri("http://192.168.25.1:30001/Disciplines"));

            Connector.Channels.Add(typeof(Faculty), Connector.CreateChannel<IContract<Faculty>>(addresses[0]));
            Connector.Channels.Add(typeof(Chair), Connector.CreateChannel<IContract<Chair>>(addresses[1]));
            Connector.Channels.Add(typeof(Teacher), Connector.CreateChannel<IContract<Teacher>>(addresses[2]));
            Connector.Channels.Add(typeof(Discipline), Connector.CreateChannel<IContract<Discipline>>(addresses[3]));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (Type entityType in Connector.Channels.Keys)
            {
                TreeNode node = new TreeNode(entityType.ToString());
                node.Tag = entityType;
                node.Nodes.Add("");
                TreeViewMain.Nodes.Add(node);
            }
        }

        private void TreeViewMain_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            Type entityType = (Type)e.Node.Tag;
            dynamic channel = Connector.Channels[entityType];
            dynamic list = channel.ReadAll();
            foreach (var item in list)
            {
                TreeNode node = new TreeNode(item.ID.ToString());

                e.Node.Nodes.Add(node);
            }
        }
    }
}
