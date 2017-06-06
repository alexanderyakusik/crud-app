using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class FormAddFaculty : Form
    {
        private dynamic record;

        public FormAddFaculty(dynamic record)
        {
            InitializeComponent();
            this.record = record;
        }

        private void FormAddFaculty_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActiveForm.Hide();
            MainForm f = new MainForm();
            f.Show();
        }

        private void FormAddFaculty_Load(object sender, EventArgs e)
        {
            List<int> idsChosen = new List<int>();
            if (record != null)
            {
                TextBoxName.Text = record.Name;
                foreach (var chair in record.Chairs)
                {
                    ListViewItem item = new ListViewItem(chair.Name);
                    item.Tag = chair;
                    idsChosen.Add(chair.ID);
                    ListViewChosen.Items.Add(item);
                }
            }     

            dynamic channel = Connector.Channels[typeof(Chair)];
            dynamic chairList = channel.ReadAll();
            foreach (dynamic chair in chairList)
            {
                ListViewItem item = new ListViewItem(chair.Name);
                item.Tag = chair;
                ListViewAll.Items.Add(item);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ListViewAll.SelectedItems.Count == 0)
            {
                return;
            }

            bool containsElement = false;
            foreach (ListViewItem item in ListViewChosen.Items)
            {
                if (ListViewAll.SelectedItems[0].Text == item.Text)
                {
                    containsElement = true;
                    break;
                }
            }

            if (!containsElement)
            {
                ListViewItem item = new ListViewItem(ListViewAll.SelectedItems[0].Text);
                item.Tag = ListViewAll.SelectedItems[0].Tag;
                ListViewChosen.Items.Add(item);
                ListViewChosen.Update();
                ListViewAll.SelectedItems.Clear();
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (ListViewChosen.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewChosen.Items.Remove(ListViewChosen.SelectedItems[0]);
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Faculty newFaculty = new Faculty();
                newFaculty.Name = TextBoxName.Text;
                List<Chair> list = new List<Chair>();
                foreach (ListViewItem item in ListViewChosen.Items)
                {
                    list.Add((Chair)item.Tag);
                }
                newFaculty.Chairs = list;
                if (list.Count == 0)
                {
                    MessageBox.Show("You must choose chairs to create a faculty.");
                    return;
                }

                IContract<Faculty> facultyChannel = (IContract<Faculty>)Connector.Channels[typeof(Faculty)];
                if (record == null)
                {
                    if (facultyChannel.Create(newFaculty))
                    {
                        MessageBox.Show("Faculty was successfully created.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error creating faculty.");
                    }
                }
                else
                {
                    if (facultyChannel.Update(record.ID, newFaculty))
                    {
                        MessageBox.Show("Faculty was successfully updated.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error updating faculty.");
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Invalid input. Please try again.");
            }
        }
    }
}
