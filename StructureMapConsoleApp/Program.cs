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
        }
    }

    public class cash : IPayMethod
    {
        public string Pay()
        {
            return "Paying in Cash!";
        }

        public int PaymentAmount
        {
            get { return 0; }
        }
    }

    public class 
}
