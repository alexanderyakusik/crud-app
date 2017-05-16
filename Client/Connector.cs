using System;
using System.ServiceModel;

namespace Client
{
    public static class Connector
    {
        public static T GetChannel<T>(Uri address)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(address);
            var factory = new ChannelFactory<T>(binding, endpoint);

            return factory.CreateChannel();
        }
    }
}
