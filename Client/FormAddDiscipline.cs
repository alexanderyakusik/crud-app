using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class FormAddDiscipline : Form
    {
        private dynamic record;

        public FormAddDiscipline(dynamic record)
        {
            InitializeComponent();
            this.record = record;
        }

        private void FormAddDiscipline_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActiveForm.Hide();
            MainForm f = new MainForm();
            f.Show();
        }

        private void FormAddDiscipline_Load(object sender, EventArgs e)
        {
            List<int> idsChosen = new List<int>();
            if (record != null)
            {
                TextBoxName.Text = record.Name;
                
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
                Discipline newDiscipline = new Discipline();
                newDiscipline.Name = TextBoxName.Text;
                List<Teacher> list = new List<Teacher>();
                IContract<Teacher> teacherChannel = (IContract<Teacher>)Connector.Channels[typeof(Teacher)];
                foreach (ListViewItem item in ListViewChosen.Items)
                {
                    list.Add((Teacher)item.Tag);
                }
                newDiscipline.Teachers = list;

                IContract<Discipline> disciplineChannel = (IContract<Discipline>)Connector.Channels[typeof(Discipline)];
                if (record == null)
                {
                    if (disciplineChannel.Create(newDiscipline))
                    {
                        MessageBox.Show("Discipline was successfully created.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error creating discipline.");
                    }
                }
                else
                {
                    if (disciplineChannel.Update(record.ID, newDiscipline))
                    {
                        MessageBox.Show("Discipline was successfully updated.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error updating discipline.");
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
