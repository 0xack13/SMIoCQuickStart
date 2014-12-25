using StructureMap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetterInjectSM
{
    public class Injected
    {
        public string Name { get; set; }   
        public Injected()
        {
            Name = "me!"; // Guid.NewGuid().ToString("N");
        }
    }

    public class Product
    {
        string test = "test";
        public Injected Inject { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            ObjectFactory.Configure(cfg =>
            {
                cfg.Policies.SetAllProperties(x => x.OfType<Injected>());
            });

            var bad = ObjectFactory.Container.GetNestedContainer().GetInstance<Product>();

            Debug.Assert(bad.Inject != null);
            Console.WriteLine("Bad passed!");
            */
            /*
            ObjectFactory.Configure(cfg =>
            {
                cfg.Policies.SetAllProperties(x => x.OfType<Injected>());
            });
             * */
            
            //var good = ObjectFactory.GetInstance<Product>();
            var bad = ObjectFactory.Container.GetNestedContainer().GetInstance<Product>();

            
            //Debug.Assert(good.Inject != null);
            //Console.WriteLine("Good passed!" + good.Inject.Name + " " + good.GetType().Name);
            //Debug.Assert(bad.Inject != null);
            //Console.WriteLine("Bad passed!" + bad.Inject.Name);

            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
