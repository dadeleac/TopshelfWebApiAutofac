using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryRepo
{
    public interface IRepo
    {
        string SaveMessage(string message); 
    }
}
