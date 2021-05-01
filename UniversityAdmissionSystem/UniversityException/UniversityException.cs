using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityExceptions
{
    public class UniversityException : ApplicationException
    {
        public UniversityException() : base() { }
        public UniversityException(string msg) : base(msg) { }

        //public void GetAllProgramException()
        //{
        //    Console.WriteLine("Table is Empty");
        //}
        //   public UniversityException(string message, Exception innerException)
        //: base(message, innerException) { }
    }
}
