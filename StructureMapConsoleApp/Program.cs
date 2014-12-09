using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ObjectFactory is the old way 
            var container = new Container();
            container.Configure(x =>
                x.For<IPayMethod>().Use<cash>());
            container.Configure(x =>
                x.For<IPayMethod>().Use<credit>().Named("CC"));

            var payee = container.GetInstance<Payee>();
            payee.pay();
            Console.ReadLine();
        }
    }

    public class cash : IPayMethod
    {
        public string pay()
        {
            return "Paying in Cash!";
        }

        public int PaymentAmount
        {
            get { return 0; }
        }
    }

    public class credit : IPayMethod
    {
        public string pay()
        {
            return "Paying in Credit Card!";
        }

        public int PaymentAmount
        {
            get { return 0; }
        }
    }

    public interface IPayMethod
    {
        string pay();
        int PaymentAmount { get; }
    }

    public class Payee
    {
        private readonly IPayMethod payMethod;

        public Payee(IPayMethod payMethod)
        {
            this.payMethod = payMethod;
        }

        public int currentPayment
        {
            get { return payMethod.PaymentAmount;  }
        }

        public void pay()
        {
            Console.WriteLine(payMethod.pay());
        }
    }
}
