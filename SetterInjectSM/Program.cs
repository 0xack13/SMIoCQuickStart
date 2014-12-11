using StructureMap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetterInjectSM
{
    public class Product
    {
        public Injected Inject { get; set; }
    }

    public class Injected
    {
        public Injected()
        {
            Name = Guid.NewGuid().ToString("N");
        }

        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory.Configure(cfg =>
            {
                cfg.Policies.SetAllProperties(x => x.OfType<Injected>());
            });

            var bad = ObjectFactory.Container.GetNestedContainer().GetInstance<Product>();

            Debug.Assert(bad.Inject != null);
            Console.WriteLine("Bad passed!");

            Console.ReadLine();
        }
    }
}
