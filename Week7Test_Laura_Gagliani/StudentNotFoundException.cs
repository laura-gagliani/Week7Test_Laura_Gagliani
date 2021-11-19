using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Test_Laura_Gagliani
{
    class StudentNotFoundException :Exception
    {
        public StudentNotFoundException()
        {

        }
        public StudentNotFoundException(string message) : base(message)
        {

        }
    }
}
