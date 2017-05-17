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
    }
}
