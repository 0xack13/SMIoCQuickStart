using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;



namespace MessagingIoC
{
    public static class ContainerBootstrapper
    {
        public static void BootstrapStructureMap()
        {
            // Initialize the static ObjectFactory container 
            ObjectFactory.Initialize(x =>
            {
                // New terse, “jQuery-esque” syntax for the Registry DSL.  Let’s just write off “ForRequestedType<IFoo>().TheDefault.Is.OfConcreteType<Foo>()” as a well meant experiment, shall we?  It’s still in the codebase, but it’s marked as [Obsolete].  Nobody liked it and I thought it was annoying in real life usage.  Now, just do:  For<IFoo>().Use<Foo>();  My whole goal was to reduce friction. 
                //x.For<IDisplayMessage>().Use<DisplayMessage>();

                x.PullConfigurationFromAppConfig = true;

            });
        }
    }
}
