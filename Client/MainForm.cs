using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Test();
        }

        private void Test()
        {
            List<Uri> addresses = new List<Uri>();
            addresses.Add(new Uri("http://192.168.25.1:30001/Faculties"));
            addresses.Add(new Uri("http://192.168.25.1:30001/Chairs"));
            addresses.Add(new Uri("http://192.168.25.1:30001/Disciplines"));
            addresses.Add(new Uri("http://192.168.25.1:30001/Teachers"));

            IContract<Faculty> facultyChannel = Connector.GetChannel<IContract<Faculty>>(addresses[0]);
            IContract<Chair> chairChannel = Connector.GetChannel<IContract<Chair>>(addresses[1]);
            IContract<Discipline> disciplineChannel = Connector.GetChannel<IContract<Discipline>>(addresses[2]);
            IContract<Teacher> teacherChannel = Connector.GetChannel<IContract<Teacher>>(addresses[3]);

            var list = teacherChannel.Read(1);
            //List<Chair> list = chairChannel.ReadAll();
            //facultyChannel.ReadCollectionByParentID(list[0].GetType(), list[0].ID);
        }
    }
}
