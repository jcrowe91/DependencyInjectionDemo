using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            //a container is a place to store the definitions-
            //of all the different classes we want to instantiate
            var builder = new ContainerBuilder();

            //when looking for an IApplication interface-
            //return an instance of Application
            builder.RegisterType<Application>().As<IApplication>();

            //when looking for an IBusinessLogic interface-
            //return an instance of BusinessLogic
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();

            //give all classes in Utilities folder
            //link them to the matching IInterface
            //where the name equals "I" plus the name of the class
            //ex: if you find a DataAccess class, look for IDataAccess interface
            //automated version of the above code, but for every class in Utilities folder
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
                

            return builder.Build();
        }
    }
}
