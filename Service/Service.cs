using ClassLibraryRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Service : IService
    {
        private IRepo _repository;

        public Service(IRepo repository)
        {
            _repository = repository; 
        }
        public string Write(string message)
        {
            return _repository.SaveMessage(message); 
        }
    }
}
