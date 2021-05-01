using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityEntity;
using UniversitySystemDAL;
using UniversityExceptions;

namespace UniversityAdmsnBL
{
    public class ProgramsScheduledBL
    {
        public bool Add(ProgramScheduled e)
        {
            bool add = false;

            if (e.ScheduledProgramID.Length > 6) throw new UniversityException("Characters are Exceeded in ID Field");
            if (e.ProgramName.Length > 20) throw new UniversityException("Characters are Exceeded in Program Name Field");
            if (e.ProgramName.Length > 20) throw new UniversityException("Characters are Exceeded in Location Field");
            if (e.SessionsPerWeek > 6) throw new UniversityException("Sessions Per Week Cannot be more than 6");
            //  DAL object will take programoffered
            ProgramsScheduledDAL dal = new ProgramsScheduledDAL();
            dal.Add(e.ScheduledProgramID, e.ProgramName, e.Location,e.StartDate,e.EndDate,e.SessionsPerWeek);
            add = true;
            if (add == false) throw new UniversityException("addtion Failed ");

            return add;
        }

        public bool Delete(string spid)
        {
            bool dlt = false;
            ProgramsScheduledDAL dal = new ProgramsScheduledDAL();
            dal.Delete(spid);
            dlt = true;
            if (dlt == false) throw new UniversityException("Program Deletion failed");
            return dlt;
        }

        public bool Update(string cuspid, ProgramScheduled e)
        {
            if (e.ScheduledProgramID.Length > 6) throw new UniversityException("Characters are Exceeded in ID Field");
            if (e.ProgramName.Length > 20) throw new UniversityException("Characters are Exceeded in Program Name Field");
            if (e.ProgramName.Length > 20) throw new UniversityException("Characters are Exceeded in Location Field");
            if (e.SessionsPerWeek > 6) throw new UniversityException("Sessions Per Week Cannot be more than 6");
            bool updt = false;
            ProgramsScheduledDAL dal = new ProgramsScheduledDAL();
            dal.Update(e.ScheduledProgramID,e.ProgramName,e.Location,e.StartDate,e.EndDate,e.SessionsPerWeek, cuspid);
            updt = true;
            if (updt == false) throw new UniversityException("Updation Failed");

            return updt;
        }

        public List<ProgramScheduled> GetAll()
        {
            List<ProgramScheduled> l = new List<ProgramScheduled>();
            ProgramsScheduledDAL dal = new ProgramsScheduledDAL();
            if (dal.GetAll().Count > 0)
            {
                l = dal.GetAll();
            }

            else throw new UniversityException("Table is Empty");

            return l;
        }

     
    }
}
