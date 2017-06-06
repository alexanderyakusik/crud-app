using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Client
{
    public static class Connector
    {
        public static Dictionary<Type, Object> Channels { get; set; } = new Dictionary<Type, object>();

        public static T CreateChannel<T>(Uri address)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(address);
            var factory = new ChannelFactory<T>(binding, endpoint);

            return factory.CreateChannel();
        }
        
        public static void InitializeChannels(List<Uri> addresses)
        {
            Channels.Add(typeof(Faculty), CreateChannel<IContract<Faculty>>(addresses[0]));
            Channels.Add(typeof(Chair), CreateChannel<IContract<Chair>>(addresses[1]));
            Channels.Add(typeof(Teacher), CreateChannel<IContract<Teacher>>(addresses[2]));
            Channels.Add(typeof(Discipline), CreateChannel<IContract<Discipline>>(addresses[3]));
        }
    }
}
