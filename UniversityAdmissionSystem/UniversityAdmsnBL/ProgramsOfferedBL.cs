using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystemDAL;
using UniversityEntity;
using UniversityExceptions;
namespace UniversityAdmsnBL
{
    public class ProgramsOfferedBL
    {
        ProgramOfferedDAL pr = new ProgramOfferedDAL();

        public bool Add(ProgramOffered programOffered)
        {
            if (programOffered.ProgramName.Length > 20) throw new UniversityException("Character length in program name is more than excepted");
            if (programOffered.Description.Length > 20) throw new UniversityException("Character length in program Description is more than excepted");
            if (programOffered.ApllicationEligibility.Length > 20) throw new UniversityException("Character length in program Eligibility is more than excepted");
            if (programOffered.DegreeCertificationOffered.Length > 20) throw new UniversityException("Character length in program Degree Certificate is more than excepted");
            if (programOffered.Duration> 5) throw new UniversityException("Duration Can not b be More than 5");
            bool addprogram = false; 
            //  DAL object will take programoffered
            ProgramOfferedDAL program = new ProgramOfferedDAL();
            program.Add(programOffered.ProgramName, programOffered.Description, programOffered.ApllicationEligibility, programOffered.Duration, programOffered.DegreeCertificationOffered);
            addprogram = true;
            if (addprogram == false) throw new UniversityException("addtion Failed ");

            return addprogram;

        }

        public bool Delete(string progName)
        {
            bool dltprog = false;
            ProgramOfferedDAL prog = new ProgramOfferedDAL();
            prog.Delete(progName);
            dltprog = true;
            if (dltprog == false) throw new UniversityException("Program Deletion failed");
            return dltprog;
        }


        public bool Update(string updateProgName, ProgramOffered program)
        {
            bool updtprog = false;
            ProgramOfferedDAL prog = new ProgramOfferedDAL();
            prog.Update(updateProgName, program.Description, program.ApllicationEligibility, program.Duration, program.DegreeCertificationOffered);
                updtprog = true;
            if (updtprog == false) throw new UniversityException("Updation Failed");

            return updtprog;
        }


        public List<ProgramOffered> GetAll()
        {
            List<ProgramOffered> progs = new List<ProgramOffered>();
            ProgramOfferedDAL prog = new ProgramOfferedDAL();
           
                progs = prog.GetAll();
          
            
            return progs;   
        }
    }
}
