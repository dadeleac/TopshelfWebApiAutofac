using Autofac;
using Autofac.Integration.WebApi;
using ClassLibrary1;
using ClassLibraryRepo;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TopshelfWebApi.Config
{
    public class OwinConfiguration
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();



            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Service>().As<IService>().InstancePerRequest();
            builder.RegisterType<Repo>().As<IRepo>().InstancePerRequest();

            var container = builder.Build();

            
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Routes.MapHttpRoute("DefaultApi",
            "api/{controller}/{id}",
            new { id = RouteParameter.Optional });

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            app.UseWebApi(config);

        }
    }
}
