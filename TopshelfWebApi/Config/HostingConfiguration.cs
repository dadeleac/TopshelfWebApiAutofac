using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopshelfWebApi.Config
{
    public class HostingConfiguration : ServiceControl
    {
        private IDisposable _webApplication;


        public bool Start(HostControl hostControl)
        {
            _webApplication = WebApp.Start<OwinConfiguration>("http://localhost:8089");
            return true; 
        }

        public bool Stop(HostControl hostControl)
        {
            _webApplication.Dispose();
            return true;
        }
    }
}
