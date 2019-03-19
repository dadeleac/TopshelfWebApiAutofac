using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TopshelfWebApi
{
    public class HelloWorldApiController : ApiController
    {
        private IService _service;

        public HelloWorldApiController(IService service)
        {
            _service = service; 
        }

        [HttpGet]
        public string Get()
        {
            return _service.Write("Hola mundo"); 
        }
    }
}
