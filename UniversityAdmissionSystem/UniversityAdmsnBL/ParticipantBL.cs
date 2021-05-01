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
    public class ParticipantBL
    {
        // send  Participant details to the Participant DAL 
        public bool Add(Participant e)
        {
            bool add = false;
            //  DAL object will take programoffered
            ParticipantDAL dal = new ParticipantDAL();
            dal.Add(e.EmailId,e.ApplicationId,e.ScheduledProgramId);
            add = true;
            if (add == false) throw new UniversityException("addtion Failed ");

            return add;
        }

        // call the Delete function from Participant Dal 
        public bool Delete(int apId)
        {
            bool dlt = false;
            ParticipantDAL dal = new ParticipantDAL();
            dal.Delete(apId);
            dlt = true;
            if (dlt == false) throw new UniversityException("Program Deletion failed");
            return dlt;
        }

        // Update Participant to the Participant Table
        public bool Update(string rollno, Participant e)
        {
            bool updt = false;
            ParticipantDAL dal = new ParticipantDAL();
            dal.Update(e.RollNo, e.EmailId, e.ApplicationId, e.ScheduledProgramId,rollno);
            updt = true;
            if (updt == false) throw new UniversityException("Updation Failed");

            return updt;
        }

        // Fetch all Participant Details  from the Participant Table
        public List<Participant> GetAll()
        {
            List<Participant> l = new List<Participant>();
            ParticipantDAL dal = new ParticipantDAL();
            if (dal.GetAll().Count > 0)
            {
                l = dal.GetAll();
            }

            else throw new UniversityException("Table is Empty");

            return l;
        }

    }
}
