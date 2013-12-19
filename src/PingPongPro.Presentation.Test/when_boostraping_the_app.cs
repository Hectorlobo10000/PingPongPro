using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Machine.Specifications;
using PinPongPro.Presentation.Controllers;
using PinPongPro.Presentation.Infrastructure;

namespace PingPongPro.Presentation.Test
{
    public class when_boostraping_the_app
    {
        static IContainer _container;

        Because of =
            () => _container = new Bootstrapper(new ContainerBuilder()).Run();

        It should_instantiate_all_controllers =
            () =>
                {
                    var errors = new List<string>();
                    IEnumerable<Type> controllers =
                        GetAllTypesOfAssembleOf<TournamentController>()
                            .Where(type => type.Namespace.Equals(typeof (HomeController).Namespace));


                    Console.WriteLine("Resolving...");
                    foreach (Type controller in controllers)
                    {
                        Console.WriteLine(controller.Name);
                        
                        _container.Resolve(controller);
                    }

                  
                  
                };

        static IEnumerable<Type> GetAllTypesOfAssembleOf<T>()
        {
            return typeof (T).Assembly.GetTypes();
        }
    }
}