using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            IDisplayMessage idm = new DisplayMessage();//creating instance of class A
            ContainerBootstrapper.BootstrapStructureMap();
            
            var adm = StructureMap.ObjectFactory.GetInstance<AnotherDisplayMessage>();

            //assign the instance to the classB property of class A 
            idm = adm;

            //Call the method
            Console.WriteLine(adm.message());
            Console.Read();
        }
    }
}
