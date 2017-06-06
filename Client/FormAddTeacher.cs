using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class FormAddTeacher : Form
    {
        private dynamic record;

        public FormAddTeacher(dynamic record)
        {
            InitializeComponent();
            this.record = record;
        }

        private void FormAddTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActiveForm.Hide();
            MainForm f = new MainForm();
            f.Show();
        }

        private void FormAddTeacher_Load(object sender, EventArgs e)
        {
            List<int> idsChosen = new List<int>();
            if (record != null)
            {
                TextBoxName.Text = record.Name;
                if (record.ChairID != null)
                {
                    TextBoxChairID.Text = record.ChairID.ToString();
                }
                foreach (var discipline in record.Disciplines)
                {
                    ListViewItem item = new ListViewItem(discipline.Name);
                    item.Tag = discipline;
                    idsChosen.Add(discipline.ID);
                    ListViewChosen.Items.Add(item);
                }
            }

            dynamic channel = Connector.Channels[typeof(Discipline)];
            dynamic disciplineList = channel.ReadAll();
            foreach (dynamic discipline in disciplineList)
            {
                ListViewItem item = new ListViewItem(discipline.Name);
                item.Tag = discipline;
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
                Teacher newTeacher = new Teacher();
                newTeacher.Name = TextBoxName.Text;
                int newChairID = -1;
                if (TextBoxChairID.Text == "")
                {
                    newTeacher.ChairID = null;
                }
                else
                {
                    newChairID = Convert.ToInt32(TextBoxChairID.Text);
                }
                List<Discipline> list = new List<Discipline>();
                foreach (ListViewItem item in ListViewChosen.Items)
                {
                    list.Add((Discipline)item.Tag);
                }
                newTeacher.Disciplines = list;
                if (list.Count == 0)
                {
                    MessageBox.Show("You must choose disciplines to create a teacher.");
                    return;
                }

                IContract<Teacher> teacherChannel = (IContract<Teacher>)Connector.Channels[typeof(Teacher)];
                IContract<Chair> chairChannel = (IContract<Chair>)Connector.Channels[typeof(Chair)];
                if (!(newTeacher.ChairID == null) && (chairChannel.Read(newChairID) == null))
                {
                    MessageBox.Show("There is no chair with such ID.");
                    return;
                }
                if (newChairID != -1)
                { 
                    newTeacher.ChairID = newChairID;
                }
                if (record == null)
                {
                    if (teacherChannel.Create(newTeacher))
                    {
                        MessageBox.Show("Teacher was successfully created.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error creating teacher.");
                    }
                }
                else
                {
                    if (teacherChannel.Update(record.ID, newTeacher))
                    {
                        MessageBox.Show("Teacher was successfully updated.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error updating teacher.");
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
