using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TopshelfWebApi.Config
{
    public class WebApiConfig
    {
        public static HttpConfiguration Register(HttpConfiguration config)
        {
            //var config = new HttpConfiguration();




            config.Routes.MapHttpRoute("DefaultApi",
            "api/{controller}/{id}",
            new { id = RouteParameter.Optional });
            return config;

        }
    }
}
