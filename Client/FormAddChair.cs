using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class FormAddChair : Form
    {
        private dynamic record;

        public FormAddChair(dynamic record)
        {
            InitializeComponent();
            this.record = record;
        }

        private void FormAddChair_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActiveForm.Hide();
            MainForm f = new MainForm();
            f.Show();
        }

        private void FormAddChair_Load(object sender, EventArgs e)
        {
            List<int> idsChosen = new List<int>();
            if (record != null)
            {
                TextBoxName.Text = record.Name;
                if (record.FacultyID != null)
                {
                    TextBoxFacultyID.Text = record.FacultyID.ToString();
                }
                foreach (var teacher in record.Teachers)
                {
                    ListViewItem item = new ListViewItem(teacher.Name);
                    item.Tag = teacher;
                    idsChosen.Add(teacher.ID);
                    ListViewChosen.Items.Add(item);
                }
            }
            
            dynamic channel = Connector.Channels[typeof(Teacher)];
            dynamic teacherList = channel.ReadAll();
            foreach (dynamic teacher in teacherList)
            {
                ListViewItem item = new ListViewItem(teacher.Name);
                item.Tag = teacher;
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
                Chair newChair = new Chair();
                int newFacultyID = -1;
                if (TextBoxFacultyID.Text == "")
                {
                    newChair.FacultyID = null;
                }
                else
                {
                    newFacultyID = Convert.ToInt32(TextBoxFacultyID.Text);
                }
                newChair.Name = TextBoxName.Text;
                List<Teacher> list = new List<Teacher>();
                foreach (ListViewItem item in ListViewChosen.Items)
                {
                    list.Add((Teacher)item.Tag);
                }
                newChair.Teachers = list;
                if (list.Count == 0)
                {
                    MessageBox.Show("You must choose teachers to create a chair.");
                    return;
                }

                IContract<Chair> chairChannel = (IContract<Chair>)Connector.Channels[typeof(Chair)];
                IContract<Faculty> facultyChannel = (IContract<Faculty>)Connector.Channels[typeof(Faculty)];
                if (!(newChair.FacultyID == null) && (facultyChannel.Read(newFacultyID) == null))
                {
                    MessageBox.Show("There is no faculty with such ID.");
                    return;
                }
                if (newFacultyID != -1)
                {
                    newChair.FacultyID = newFacultyID;
                }
                if (record == null)
                {
                    if (chairChannel.Create(newChair))
                    {
                        MessageBox.Show("Chair was successfully created.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error creating chair.");
                    }
                }
                else
                {
                    if (chairChannel.Update(record.ID, newChair))
                    {
                        MessageBox.Show("Chair was successfully updated.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error updating chair.");
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
