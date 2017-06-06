using System;
using System.Windows.Forms;

namespace Client
{
    public partial class FormChooseType : Form
    {
        public FormChooseType()
        {
            InitializeComponent();
        }

        private void FormChooseType_Load(object sender, EventArgs e)
        {
            foreach (Type entityType in Connector.Channels.Keys)
            {
                ComboBoxMain.Items.Add(entityType);
            }
            ComboBoxMain.SelectedIndex = 0;
        }

        private void FormChooseType_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm f = new MainForm();
            f.Show();
        }

        private void ButtonChoose_Click(object sender, EventArgs e)
        {
            if ((Type)ComboBoxMain.SelectedItem == typeof(Faculty))
            {
                ActiveForm.Hide();
                FormAddFaculty f = new FormAddFaculty(null);
                f.Show();
            }
            if ((Type)ComboBoxMain.SelectedItem == typeof(Chair))
            {
                ActiveForm.Hide();
                FormAddChair f = new FormAddChair(null);
                f.Show();
            }
            if ((Type)ComboBoxMain.SelectedItem == typeof(Teacher))
            {
                ActiveForm.Hide();
                FormAddTeacher f = new FormAddTeacher(null);
                f.Show();
            }
            if ((Type)ComboBoxMain.SelectedItem == typeof(Discipline))
            {
                ActiveForm.Hide();
                FormAddDiscipline f = new FormAddDiscipline(null);
                f.Show();
            }
        }
    }
}
