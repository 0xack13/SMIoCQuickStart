using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingIoC
{
    public static class ContainerBootstrapper
    {
        public static void BootstrapStructureMap()
        {
            // Initialize the static ObjectFactory container 
            ObjectFactory.Initialize(x =>
            {
                x.For<IDisplayMessage>().Use<DisplayMessage>();
            });
        }
    }
}
