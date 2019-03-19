using Autofac;
using Autofac.Integration.WebApi;
using ClassLibrary1;
using ClassLibraryRepo;
using TopshelfWebApi.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using Topshelf;
using Topshelf.Autofac;

namespace TopshelfWebApi
{
    class Program
    {
        private static ILifetimeScope _scope;

        static void Main(string[] args)
        {


            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());                 // Register the Web API controllers.
            
            builder.RegisterType<Service>().As<IService>().InstancePerRequest();
            builder.RegisterType<Repo>().As<IRepo>().InstancePerRequest();

            //builder.RegisterType<SampleDependency>().As<ISampleDependency>();
            builder.RegisterType<HostingConfiguration>();
            var container = builder.Build();



            //Register the API controllers and other types as you normally would

            //var resolver = new AutofacWebApiDependencyResolver(container);
            //var config = new HttpSelfHostConfiguration(@"http://localhost:9099");
            //config.DependencyResolver = resolver;
            //var server = new HttpSelfHostServer(config);


            HostFactory.Run(c =>
            {
                // Pass it to Topshelf
                c.UseAutofacContainer(container);

                c.Service<HostingConfiguration>();
                c.RunAsLocalSystem();
                c.SetDescription("Owin + Webapi as Windows service");
                c.SetDisplayName("owin.webapi.test");
                c.SetServiceName("owin.webapi.test");
                //c.Service<HelloWorldApiController>(s =>
                //{

                //    // Let Topshelf use it
                //    s.ConstructUsingAutofacContainer();
                //    s.WhenStarted((service, control) => service.Start());
                //    s.WhenStopped((service, control) => service.Stop());
                //});
            });


            //Start(); 
        }
        public static int Start()
        {


            var exitCode = HostFactory.Run(x =>
            {
                x.Service<HostingConfiguration>();
                x.RunAsLocalSystem();
                x.SetDescription("Owin + Webapi as Windows service");
                x.SetDisplayName("owin.webapi.test");
                x.SetServiceName("owin.webapi.test");
            });
            return (int)exitCode;
        }


    }
}
