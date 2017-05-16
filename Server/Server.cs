using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
    static class Server
    {
        public static Dictionary<Type, ServiceHost> Hosts { get; private set; }

        static void Main(string[] args)
        {
            List<Uri> addresses = new List<Uri>();
            addresses.Add(new Uri("http://127.0.0.1:30001/Faculties"));
            addresses.Add(new Uri("http://127.0.0.1:30001/Chairs"));
            addresses.Add(new Uri("http://127.0.0.1:30001/Disciplines"));
            addresses.Add(new Uri("http://127.0.0.1:30001/Teachers"));

            InitializeServiceHosts();
            AddServiceHostWithEndpoint<Faculty>(addresses[0]);
            AddServiceHostWithEndpoint<Chair>(addresses[1]);
            AddServiceHostWithEndpoint<Discipline>(addresses[2]);
            AddServiceHostWithEndpoint<Teacher>(addresses[3]);

            OpenHost<Faculty>();
            OpenHost<Chair>();
            OpenHost<Discipline>();
            OpenHost<Teacher>();

            Console.ReadKey();

            CloseHost<Faculty>();
            CloseHost<Chair>();
            CloseHost<Discipline>();
            CloseHost<Teacher>();
        }

        private static void InitializeServiceHosts()
        {
            Hosts = new Dictionary<Type, ServiceHost>();
        }

        private static void AddServiceHostWithEndpoint<T>(Uri address) where T : BasicEntity, new()
        {
            var binding = new BasicHttpBinding();
            Type contract = typeof(IContract<T>);
            var host = new ServiceHost(typeof(Service<T>));
            host.AddServiceEndpoint(contract, binding, address);

            Hosts.Add(typeof(T), host);
        }

        private static void OpenHost<T>()
        {
            Hosts[typeof(T)].Open();
        }

        private static void CloseHost<T>()
        {
            Hosts[typeof(T)].Close();
        }
    }
}
