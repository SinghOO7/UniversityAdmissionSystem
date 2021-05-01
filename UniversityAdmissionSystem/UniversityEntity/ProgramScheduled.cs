using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEntity
{
     public class ProgramScheduled
    {
        public string ScheduledProgramID { get; set; }
        public string ProgramName { get; set; }
        public string  Location{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SessionsPerWeek { get; set; }


        public ProgramScheduled() { }
        public ProgramScheduled(string pid, string pname, string loc,DateTime sdate,DateTime edate,int session)
        {
            this.ScheduledProgramID = pid;
            this.ProgramName = pname;
            this.Location = loc;
            this.StartDate = sdate;
            this.EndDate = edate;
            this.SessionsPerWeek = session;
        }
    }
}
