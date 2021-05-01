using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmsnBL
{
    public class ExceptionBL : ApplicationException
    {
        public ExceptionBL() : base() { }
        public ExceptionBL(string msg) : base(msg) { }
        public ExceptionBL(string message, Exception innerException)
           : base(message, innerException) { }
    }
}
