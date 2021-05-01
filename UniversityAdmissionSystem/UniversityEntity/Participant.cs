using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEntity
{
    public class Participant
    {
        public string RollNo { get; set; }
        public string EmailId { get; set; }
        public int ApplicationId { get; set; }
        public string ScheduledProgramId { get; set; }

        public Participant() { }
        public Participant(string rollno,string email,int appid,string spid)
        {
            this.RollNo = rollno;
            this.EmailId = email;
            this.ApplicationId = appid;
            this.ScheduledProgramId = spid;
        }
    }
}
