using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryRepo
{
    public class Repo : IRepo
    {
        public string SaveMessage(string message)
        {
            return  $"{message} saved";
        }
    }
}
