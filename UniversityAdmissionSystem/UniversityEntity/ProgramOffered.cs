using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEntity
{
    public class ProgramOffered
    {

        public string ProgramName { get; set; }
        public string Description { get; set; }
        public string ApllicationEligibility { get; set; }
        public int Duration { get; set; }
        public string DegreeCertificationOffered { get; set; }

        public ProgramOffered() { }
        public ProgramOffered(string pname,string description,string eligibility,int duration,string certificate)
        {
            this.ProgramName = pname;
            this.Description = description;
            this.ApllicationEligibility = eligibility;
            this.Duration = duration;
            this.DegreeCertificationOffered = certificate;
        }


    }
}
