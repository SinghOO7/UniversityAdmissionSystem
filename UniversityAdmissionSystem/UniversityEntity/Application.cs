using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEntity
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string HighestQualification { get; set; }
        public int MarksObtained { get; set; }
        public string Goals { get; set; }
        public string Email_Id { get; set; }
        public string Scheduled_ProgramId { get; set; }
        public string Status { get; set; }
        public DateTime DateOFInterview { get; set; }

        public Application() { }
        public Application(int id,string name,DateTime dob,string hq,int marks,string goals,string email,string programid,string status,DateTime doi) 
        {
            this.ApplicationId = id;
            this.FullName = name;
            this.DOB = dob;
            this.HighestQualification = hq;
            this.MarksObtained = marks;
            this.Goals = goals;
            this.Email_Id = email;
            this.Status = status;
            this.Scheduled_ProgramId = programid;
            this.DateOFInterview = doi;
        }


    }
}
