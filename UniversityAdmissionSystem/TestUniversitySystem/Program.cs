using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityEntity;
using UniversityAdmsnBL;
using UniversityExceptions;

namespace TestUniversitySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            #region program offered function
            //AddProg();
            // DeletProg();
            //UpdateProg();
            //GetAllProg();
            #endregion

            #region Application Functions
            //AddApp();
            // GetAllapp();
            //UpdateApp();
            //DeleteApp();
            #endregion

            #region Participant Functions
            //AddPart();
            //GetAllpart();
            // UpdatePart();
            // DeletePart();
            #endregion

            #region Users Functions
            //AddUser();
            // GetAllUsers();
            // UpdateUser();
            //DeleteUser();
            #endregion

            #region Scheduled Program function
           //Addsp();
             //GetAllSp();
           // UpdateSp();
            DeleteSp();
            #endregion

        }






        #region Scheduled Program Table operations

        private static void DeleteSp()
        {
            try
            {
                ProgramScheduled e = new ProgramScheduled();
                ProgramsScheduledBL bl = new ProgramsScheduledBL();

                bool dltd = bl.Delete(e, "A123");
                if (dltd) Console.WriteLine("Deleted Succesfully");
                else Console.WriteLine("not succesfully deleted");
            }
            catch (UniversityException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateSp()
        {
            try
            {
                ProgramScheduled e = new ProgramScheduled() { ScheduledProgramID = "A123", ProgramName = "BCA", Location = "Bangalore", StartDate = Convert.ToDateTime("12-April-2021"), EndDate = Convert.ToDateTime("17,April,2021"), SessionsPerWeek = 4 };
                ProgramsScheduledBL bl = new ProgramsScheduledBL();
                bool updtd = bl.Update("A123", e);

                if (updtd) Console.WriteLine("updated succesfully");

            }
            catch (UniversityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void Addsp()
        {
            try
            {
                ProgramScheduled e = new ProgramScheduled() {ScheduledProgramID="A123",ProgramName="BCA",Location="Delhi",StartDate=Convert.ToDateTime("12-April-2021"),EndDate= Convert.ToDateTime("17,April,2021"),SessionsPerWeek=4 };
                ProgramScheduled e1 = new ProgramScheduled() { ScheduledProgramID = "B123", ProgramName = "Bsc", Location = "Dehradun", StartDate = Convert.ToDateTime("12 /April/ 2021"), EndDate = Convert.ToDateTime("17 /April / 2021"), SessionsPerWeek = 4 };

                ProgramsScheduledBL bl = new ProgramsScheduledBL();
                bool aded = bl.Add(e);
                aded = bl.Add(e1);
                if (aded) Console.WriteLine("added succesfully");

            }
            catch (UniversityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GetAllSp()
        {
            ProgramsScheduledBL bl = new ProgramsScheduledBL();
            List<ProgramScheduled> l = new List<ProgramScheduled>();
            try
            {
                l = bl.GetAll();
                foreach (ProgramScheduled e in l)
                {
                    Console.WriteLine($"{e.ScheduledProgramID},{e.ProgramName},{e.Location},{e.StartDate},{e.EndDate},{e.SessionsPerWeek}");
                }
                if (l.Count > 0) Console.WriteLine("Succes");
                else Console.WriteLine("Not success");
            }
            catch (UniversityException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        #endregion

        #region  users table operations
        private static void GetAllUsers()
        {
             UsersBL bl = new UsersBL();
            List<Users> l = new List<Users>();
            try
            {
                l = bl.GetAll();
                foreach (Users e in l)
                {
                    Console.WriteLine($"{e.LoginId},{e.Password},{e.Role}");
                }
                if (l.Count > 0) Console.WriteLine("Succes");
                else Console.WriteLine("Not success");
            }
            catch (UniversityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddUser()
        {
            try
            {
                Users e = new Users() { LoginId="Am12",Password="admin@123",Role="admin" };
                Users e1 = new Users() { LoginId = "Ra12", Password = "rn@123", Role = "mac" };

                UsersBL bl = new UsersBL();
                bool aded = bl.Add(e);
                aded = bl.Add(e1);
                if (aded) Console.WriteLine("added succesfully");

            }
            catch (UniversityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdateUser()
        {
            try
            {
                Users e = new Users() { LoginId = "Am13", Password = "admn@123", Role = "admin" };
                UsersBL bl = new UsersBL();
                bool updtd = bl.Update("Am12", e);

                if (updtd) Console.WriteLine("updated succesfully");

            }
            catch (UniversityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeleteUser()
        {
            try
            {
                Users e = new Users();
                UsersBL bl = new UsersBL();

                bool dltd = bl.Delete(e, "Ra12");
                if (dltd) Console.WriteLine("Deleted Succesfully");
                else Console.WriteLine("not succesfully deleted");
            }
            catch (UniversityException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion







        #region  Participant Table operations
        private static void DeletePart()
        {
            try
            {
                Participant e = new Participant();
                ParticipantBL bl = new ParticipantBL();

                bool dltd = bl.Delete(e, "B123");
                if (dltd) Console.WriteLine("Deleted Succesfully");
                else Console.WriteLine("not succesfully deleted");
            }
            catch (UniversityException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
      
        private static void UpdatePart()
        {
            try
            {
                Participant e = new Participant() { RollNo = "A125", EmailId = "A@.com", ApplicationId = 8, ScheduledProgramId = "S4" };
                ParticipantBL bl = new ParticipantBL();
                bool updtd = bl.Update("A123",e);

                if (updtd) Console.WriteLine("updated succesfully");

            }
            catch (UniversityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddPart()
        {
            try
            {
                Participant e = new Participant() {RollNo="A123",EmailId="A@.com",ApplicationId=8,ScheduledProgramId="s2" };
                Participant e1 = new Participant() { RollNo = "B123", EmailId = "B@.com", ApplicationId = 8, ScheduledProgramId = "s2" };

                ParticipantBL bl = new ParticipantBL();
                bool aded = bl.Add(e);
                aded = bl.Add(e1);
                if (aded) Console.WriteLine("added succesfully");

            }
            catch (UniversityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GetAllpart()
        {
             ParticipantBL bl= new ParticipantBL();
            List<Participant> l = new List<Participant>();
            try
            {
                l = bl.GetAll();
                foreach (Participant e in l)
                {
                    Console.WriteLine($"{e.RollNo},{e.EmailId},{e.ApplicationId},{e.ScheduledProgramId}");
                }
                if (l.Count > 0) Console.WriteLine("Succes");
                else Console.WriteLine("Not success");
            }
            catch (UniversityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion


        #region Application Table operation

        private static void DeleteApp()
        {
            try
            {
                Application e = new Application();
                ApplicationBL bl = new ApplicationBL();

                bool dltd = bl.Delete(e,7);
                if (dltd) Console.WriteLine("Deleted Succesfully");
                else Console.WriteLine("not succesfully deleted");
            }
            catch (UniversityException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateApp()
        {
            try
            {
                Application e = new Application() { FullName = "Rahul", DOB = new DateTime(2000, 2, 2), HighestQualification = "12th Pass", MarksObtained = 90, Goals = "Teacher", Email_Id = "Rahul@.com", Scheduled_ProgramId = "EAB1", Status = "confirmed", DateOFInterview = new DateTime(2021, 1, 1) };
                ApplicationBL bl = new ApplicationBL();
                bool updtd = bl.Update(3,e);
                
                if (updtd) Console.WriteLine("updated succesfully");

            }
            catch (UniversityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private static void GetAllapp()
        {
            ApplicationBL bl = new ApplicationBL();
            List<Application> l = new List<Application>();
            try
            {
                l = bl.GetAll();
                foreach (Application e in l)
                {
                    Console.WriteLine($"{e.ApplicationId},{e.FullName},{e.DOB},{e.HighestQualification},{e.MarksObtained},{e.Goals},{e.Email_Id},{e.Scheduled_ProgramId},{e.Status},{e.DateOFInterview}");
                }
                if (l.Count > 0) Console.WriteLine("Succes");
                else Console.WriteLine("Not success");
            }
            catch (UniversityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddApp()
        {
            try
            {
                Application e = new Application() {  FullName = "Rahul", DOB = new DateTime(2000, 2, 2), HighestQualification = "12th Pass", MarksObtained = 90, Goals = "player", Email_Id = "@.com", Scheduled_ProgramId = "EAB1", Status = "confirmed", DateOFInterview = new DateTime(2021, 1, 1) };
                Application e1 = new Application() { FullName = "Shubam", DOB = new DateTime(2000, 2, 2), HighestQualification = "12th Pass", MarksObtained = 80, Goals = "player", Email_Id = "@.com", Scheduled_ProgramId = "EAB2", Status = "rejected", DateOFInterview = new DateTime(2021, 1, 1) };
                ApplicationBL bl = new ApplicationBL();
                bool aded = bl.Add(e);
                aded = bl.Add(e1);
                if (aded) Console.WriteLine("added succesfully");
               
            }
            catch(UniversityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region Program Offered Table Operations
        private static void GetAllProg()
        {
            ProgramsOfferedBL prog = new ProgramsOfferedBL();
            List<ProgramOffered> p = new List<ProgramOffered>();
            try
            {
                p = prog.GetAll();
                foreach (ProgramOffered ps in p)
                {
                    Console.WriteLine($"{ps.ProgramName},{ps.Description},{ps.ApllicationEligibility},{ps.Duration},{ps.DegreeCertificationOffered}");
                }
                if (p.Count > 0) Console.WriteLine("Succes");
                else Console.WriteLine("Not success");
            }
            catch (UniversityException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            

        }

        private static void UpdateProg()
        {
            try
            {


                ProgramOffered program = new ProgramOffered() { ProgramName = "Btech Cs", Description = "computer study", ApllicationEligibility = "10th Pass", Duration = 3, DegreeCertificationOffered = "BCA Pass" };
                ProgramsOfferedBL programBl = new ProgramsOfferedBL();
                bool progadded = programBl.Update("BCA", program);
                if (progadded) Console.WriteLine("Updated succesfully");
                else Console.WriteLine("not Updated succesfully");
            }
            catch(UniversityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
  
        private static void DeletProg()
        {
            ProgramOffered program = new ProgramOffered();
            ProgramsOfferedBL programBl = new ProgramsOfferedBL();

            bool progdeleted = programBl.Delete(program, "Btech Cs");
            if (progdeleted) Console.WriteLine("Deleted Succesfully");
            else Console.WriteLine("not succesfully deleted");
        }

        static void AddProg()
        {
            ProgramOffered program = new ProgramOffered() { ProgramName = "Btech Cs", Description = "computer study", ApllicationEligibility = "12th Pass", Duration = 3, DegreeCertificationOffered = "BCA Pass" };
            
            ProgramsOfferedBL programBl = new ProgramsOfferedBL();
            bool progadded = programBl.Add(program);
            if (progadded) Console.WriteLine("added succesfully");
            else Console.WriteLine("not added succesfully");
        }




        #endregion


    }


}
