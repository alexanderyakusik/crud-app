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

            if (Connector.Channels.Count == 0)
            {
                List<Uri> addresses = new List<Uri>();
                addresses.Add(new Uri("http://192.168.25.1:30001/Faculties"));
                addresses.Add(new Uri("http://192.168.25.1:30001/Chairs"));
                addresses.Add(new Uri("http://192.168.25.1:30001/Teachers"));
                addresses.Add(new Uri("http://192.168.25.1:30001/Disciplines"));

                Connector.InitializeChannels(addresses);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (Type entityType in Connector.Channels.Keys)
            {
                TreeNode node = new TreeNode(GetEntityTypeName(entityType));
                node.Tag = entityType;
                node.Nodes.Add("");
                TreeViewMain.Nodes.Add(node);
            }
        }

        private void TreeViewMain_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.Nodes.Clear();
                Type entityType = (Type)e.Node.Tag;
                dynamic channel = Connector.Channels[entityType];
                dynamic entityList = channel.ReadAll();
                foreach (dynamic entity in entityList)
                {
                    TreeNode node = new TreeNode(entity.Name);
                    node.Tag = entity.ID;
                    node.Nodes.Add(new TreeNode(""));
                    e.Node.Nodes.Add(node);
                }
            }
            else
            {
                if (e.Node.Tag.GetType() != typeof(int))
                {
                    return;
                }
                e.Node.Nodes.Clear();
                Type entityType = (Type)e.Node.Parent.Tag;
                int entityID = (int)e.Node.Tag;
                dynamic channel = Connector.Channels[entityType];
                dynamic entity = channel.Read(entityID);

                TreeNode n = new TreeNode("ID = " + entity.GetType().GetProperty("ID").GetValue(entity));
                e.Node.Nodes.Add(n);

                List<PropertyInfo> genericProps = new List<PropertyInfo>();
                foreach (PropertyInfo propInfo in entity.GetType().GetProperties())
                {
                    if (!propInfo.GetGetMethod().IsVirtual && propInfo.Name != "Name" && propInfo.Name != "ID")
                    {
                        TreeNode node;
                        if (propInfo.GetValue(entity) != null)
                        {
                            node = new TreeNode(propInfo.Name + " = " + propInfo.GetValue(entity));
                        }
                        else
                        {
                            node = new TreeNode("No " + propInfo.Name);
                        }
                        e.Node.Nodes.Add(node);
                        continue;
                    }
                    if (propInfo.PropertyType.IsGenericType)
                    {
                        genericProps.Add(propInfo);
                    }
                }

                foreach (PropertyInfo propInfo in genericProps)
                {
                    TreeNode collectionNode = new TreeNode(propInfo.Name);
                    collectionNode.Tag = propInfo.PropertyType.GetGenericArguments()[0];
                    foreach (dynamic collectionItem in propInfo.GetValue(entity))
                    {
                        TreeNode node = new TreeNode(collectionItem.Name);
                        node.Tag = collectionItem.ID;
                        node.Nodes.Add("");
                        collectionNode.Nodes.Add(node);
                    }
                    e.Node.Nodes.Add(collectionNode);
                }
            }
        }

        private string GetEntityTypeName(Type type)
        {
            if (type == typeof(Faculty)) { return "Faculties"; };
            if (type == typeof(Chair)) { return "Chairs"; };
            if (type == typeof(Teacher)) { return "Teachers"; };
            if (type == typeof(Discipline)) { return "Disciplines"; };

            return null;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (TreeViewMain.SelectedNode == null)
            {
                MessageBox.Show("Please select the node to delete.");
                return;
            }
            if (TreeViewMain.SelectedNode.Level != 1)
            {
                MessageBox.Show("Cannot delete entity.");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the node?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Type recordType = (Type)TreeViewMain.SelectedNode.Parent.Tag;
                dynamic channel = Connector.Channels[recordType];
                if (channel.Delete((int)TreeViewMain.SelectedNode.Tag))
                {
                    MessageBox.Show("Successfully deleted record.");
                    TreeViewMain.SelectedNode.Parent.Collapse();
                }
                else
                {
                    MessageBox.Show("An error occured when deleting the record.");
                }
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (TreeViewMain.SelectedNode == null)
            {
                MessageBox.Show("Please select the node to update.");
                return;
            }
            if (TreeViewMain.SelectedNode.Level != 1)
            {
                MessageBox.Show("Cannot update entity.");
                return;
            }
            Type recordType = (Type)TreeViewMain.SelectedNode.Parent.Tag;
            dynamic channel = Connector.Channels[recordType];
            dynamic item = channel.Read((int)TreeViewMain.SelectedNode.Tag);
            ActiveForm.Hide();
            Form newForm = null;
            if (recordType == typeof(Faculty))
            {
                newForm = new FormAddFaculty(item);
            }
            if (recordType == typeof(Chair))
            {
                newForm = new FormAddChair(item);
            }
            if (recordType == typeof(Teacher))
            {
                newForm = new FormAddTeacher(item);
            }
            if (recordType == typeof(Discipline))
            {
                newForm = new FormAddDiscipline(item);
            }
            newForm.Show();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            FormChooseType f = new FormChooseType();
            f.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
