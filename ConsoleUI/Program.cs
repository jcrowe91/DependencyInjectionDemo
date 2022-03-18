using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        //added Autofac nuget package
        static void Main(string[] args)
        {
            //don't need this code anymore
            //BusinessLogic businessLogic = new BusinessLogic();
            //businessLogic.ProcessData();

            //configures container that holds all the instantiation setup
            var container = ContainerConfig.Configure();

            //sets up new scope for instance being passed out
            using (var scope = container.BeginLifetimeScope())
            {
                //uses interface through container to
                //give an instance of Application, called app
                //app now containes Run method
                //Run() calls (an interface) _businessLogic.ProcessData
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Console.ReadLine();
        }
    }
}
