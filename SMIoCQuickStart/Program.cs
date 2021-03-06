﻿using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMIoCQuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = ConfigureDependencies();
            
            IAppEngine appEngine = container.GetInstance<IAppEngine>();
            appEngine.Run();
            var co = container.TryGetInstance<IGreeter>("appEngine1").GetGreeting();

            string msg = co.Equals(null) ? "Nope!" : "Yup!";
            Console.WriteLine("Here you go: " + msg + "and :" + co.ToString());

            
        }
 
        private static IContainer ConfigureDependencies() {
            return new Container(x => {
                x.For<IAppEngine>().Use<AppEngine>();
                //Could be changed to "EnglishGreeter"
                x.For<IGreeter>().Use<ArabicGreeter>().Named("appEngine1");
                
                //var ig = ObjectFactory.GetNamedInstance<ArabicGreeter>("appEngine1");
                //ig.GetGreeting();
                x.For<IOutputDisplay>().Use<ConsoleOutputDisplay>();
            });
        }
    }

    public class AppEngine : IAppEngine
    {
        private readonly IGreeter greeter;
        private readonly IOutputDisplay outputDisplay;

        public AppEngine(IGreeter greeter, IOutputDisplay outputDisplay)
        {
            this.greeter = greeter;
            this.outputDisplay = outputDisplay;
        }

        public void Run()
        {
            outputDisplay.Show(greeter.GetGreeting());
        }
    }

    public interface IAppEngine
    {
        void Run();
    }

    public interface IGreeter
    {
        string GetGreeting();
    }

    public class EnglishGreeter : IGreeter
    {
        public string GetGreeting()
        {
            return "Hello";
        }
    }

    public class ArabicGreeter : IGreeter
    {
        public string GetGreeting()
        {
            return "سلام";
        }
    }

    public class FrenchGreeter : IGreeter
    {
        public string GetGreeting()
        {
            return "Bonjour";
        }
    }

    public interface IOutputDisplay
    {
        void Show(string message);
    }

    public class ConsoleOutputDisplay : IOutputDisplay
    {
        public void Show(string message)
        {
            Console.WriteLine(message);
        }
    }
}
