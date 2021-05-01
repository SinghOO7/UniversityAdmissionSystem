using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystemDAL;
using UniversityExceptions;
using UniversityEntity;
using System.Text.RegularExpressions;

namespace UniversityAdmsnBL
{
      public  class ApplicationBL
    {
        // DataAccesLayerObject
        public ApplicationDAL DalObject = new ApplicationDAL();

        
        // Send all application details from Presentation layer to data access layer for inserting
        public Regex Email_Regex = new Regex("^[0-9a-zA-Z]+[.+-_]{0,1}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}$");

        public bool Add( Application ap)
        {
            bool add = false;
            if (ap.FullName.Length > 20) throw new UniversityException("Character length Exceeded in Name");
            if (ap.HighestQualification.Length > 10) throw new UniversityException("Character length Exceeded in Qualification");
            if(ap.Goals.Length>20) throw new UniversityException("Character length Exceeded in Goals");
            if (ap.Email_Id.Length > 20) throw new UniversityException("Character length Exceeded in Email");
            if(ap.Scheduled_ProgramId.Length>20) throw new UniversityException("Character length Exceeded in Scheduled Program Id");
            if(ap.Status.Length>20)  throw new UniversityException("Character length Exceeded in status");
            if (ap.MarksObtained > 100)  throw new UniversityException("Marks can not be more than 100");


            //  DAL object will take program offered
         //   ApplicationDAL app = new ApplicationDAL();
            DalObject.Add(ap.FullName,ap.DOB,ap.HighestQualification,ap.MarksObtained,ap.Goals,ap.Email_Id,ap.Scheduled_ProgramId,ap.Status,ap.DateOFInterview);
            add = true;
            if (add == false) throw new UniversityException("Addition Failed ");

            return add;
        }

        //take input id from PL and send to DAL form deletion of particular row
        public bool Delete(int apid )
        {
            bool dlt= false;
            //ApplicationDAL app = new ApplicationDAL();
            DalObject.Delete(apid);
            dlt = true;
            if (dlt == false) throw new UniversityException("Program Deletion failed");
            return dlt;
        }

        //Update Application(Send all application details from Presentation layer to data access layer for Updation)
        public bool Update(int updateapid, Application ap)
        {
            if (ap.FullName.Length > 20) throw new UniversityException("Character length Exceeded in Name");
            if (ap.HighestQualification.Length > 10) throw new UniversityException("Character length Exceeded in qualification");
            if (ap.Goals.Length > 20) throw new UniversityException("Character length Exceeded in Goals");
            if (ap.Email_Id.Length > 20) throw new UniversityException("Character length Exceeded in Email");
            if (ap.Scheduled_ProgramId.Length > 20) throw new UniversityException("Character length Exceeded in scheduled program id");
            if (ap.Status.Length > 20) if (ap.Scheduled_ProgramId.Length > 20) throw new UniversityException("character length Exceeded in status");
            bool updt = false;
            //  ApplicationDAL app = new ApplicationDAL();
            DalObject.Update(updateapid, ap.FullName, ap.DOB, ap.HighestQualification, ap.MarksObtained, ap.Goals, ap.Email_Id, ap.Scheduled_ProgramId, ap.Status, ap.DateOFInterview);
            updt = true;
            if (updt == false) throw new UniversityException("Updation is Failed");

            return updt;
        }

        //Fetch All Data from Application Table
        public List<Application> GetAll()
        {
            List<Application> apps = new List<Application>();
          //  ApplicationDAL ap = new ApplicationDAL();
           
                apps = DalObject.GetAll();
            

            return apps;
        }

        // Check Application Status by Id for Applicant
        public List<Application> CheckStatusById(int appId)
        {
            Application app = new Application();
            List<Application> list = new List<Application>();
            List<Application> slist = new List<Application>();
            list =GetAll();
            bool match = false;
            foreach(Application a in list)
            {
                if (appId == a.ApplicationId)
                {
                    app.ApplicationId = a.ApplicationId;
                    app.Status = a.Status;
                    app.FullName = a.FullName;
                    match = true;
                    break;
                }
            }
            if (match == true) slist.Add(app);
               
            else throw new Exception("Please fill Correct Id");

            return slist;

        }

        // method to accept application by MAC
        public bool AcceptAppByMac(int appId,DateTime date)
        {
            bool accepted = false;
            bool chkId = false;
            bool chkStatus = false;
            Application app = new Application();
            List<Application> list = new List<Application>();

            if (date < DateTime.Now) throw new UniversityException("Date of Interview Should be more than current date");
                list = GetAll();
                foreach (UniversityEntity.Application en in list)
                {
                    if (appId == en.ApplicationId)
                    {
                    chkId = true;
                    if (en.Status.ToLower() == "applied")
                    {
                        chkStatus = true;
                        app.ApplicationId = en.ApplicationId;
                        app.FullName = en.FullName;
                        app.DOB = en.DOB;
                        app.HighestQualification = en.HighestQualification;
                        app.MarksObtained = en.MarksObtained;
                        app.Goals = en.Goals;
                        app.Email_Id = en.Email_Id;
                        app.Scheduled_ProgramId = en.Scheduled_ProgramId;
                        app.Status = en.Status;
                        app.DateOFInterview = en.DateOFInterview;
                        accepted = true;
                    }

                    }
                }
            if (chkId == false) throw new UniversityException("You Entered Wrong Application Id");
            if (chkStatus == false) throw new UniversityException("You only can Accept Applied Applications");
                if (accepted == false) throw new UniversityException("Not Accepted");
                Application newapp = new Application();
                newapp = app;
                newapp.Status = "accepted";
                newapp.DateOFInterview = Convert.ToDateTime(date);
                Update(appId, app);
            
            return accepted;
        }

        // method to reject application by MAC
        public bool RejectAppByMac(int appId)
        {
            bool rejected = false;
            bool chkId = false;
            bool chkStatus = false;
            Application app = new Application();
            List<Application> list = new List<Application>();
            //try
            //{
                list = GetAll();
                foreach (UniversityEntity.Application en in list)
                {
                    if (appId == en.ApplicationId)
                    {
                      chkId = true;
                    if (en.Status.ToLower() == "applied")
                    {
                        chkStatus = true;
                        app.ApplicationId = en.ApplicationId;
                        app.FullName = en.FullName;
                        app.DOB = en.DOB;
                        app.HighestQualification = en.HighestQualification;
                        app.MarksObtained = en.MarksObtained;
                        app.Goals = en.Goals;
                        app.Email_Id = en.Email_Id;
                        app.Scheduled_ProgramId = en.Scheduled_ProgramId;
                        app.Status = en.Status;
                        app.DateOFInterview = en.DateOFInterview;
                        rejected = true;
                        break;
                    }

                    }
                }
                if (chkId == false) throw new UniversityException("You Entered Wrong Application Id");
                if (chkStatus == false) throw new UniversityException("You only can Reject applied Applications");
                if (rejected == false) throw new UniversityException("Not Rejected");
                Application newapp = new Application();
                newapp = app;
                newapp.Status = "rejected";
                
                Update(appId, app);
          
            return rejected;
        }


        // Method to Reject Application After Interview
        public bool RejectAppByMacAfterInterview(int appId)
        {
            bool rejected = false;
            bool chkId = false;
            bool chkStatus = false;
            Application app = new Application();
            List<Application> list = new List<Application>();
            //try
            //{
            list = GetAll();
            foreach (UniversityEntity.Application en in list)
            {
                if (appId == en.ApplicationId)
                {
                    chkId = true;
                    if (en.Status.ToLower() == "accepted")
                    {
                        chkStatus = true;
                        app.ApplicationId = en.ApplicationId;
                        app.FullName = en.FullName;
                        app.DOB = en.DOB;
                        app.HighestQualification = en.HighestQualification;
                        app.MarksObtained = en.MarksObtained;
                        app.Goals = en.Goals;
                        app.Email_Id = en.Email_Id;
                        app.Scheduled_ProgramId = en.Scheduled_ProgramId;
                        app.Status = en.Status;
                        app.DateOFInterview = en.DateOFInterview;
                        rejected = true;
                        break;
                    }

                }
            }
            if (chkId == false) throw new UniversityException("You Entered Wrong Application Id");
            if (chkStatus == false) throw new UniversityException("You Cannot Reject Confirmed Applications");
            if (rejected == false) throw new UniversityException("Not Rejected");
            Application newapp = new Application();
            newapp = app;
            newapp.Status = "rejected";

            Update(appId, app);

            return rejected;
        }

        // Submit Application By Applicant 
        public bool SubmitUserApplication(string fname,string dob,string hqf,string marks,string goal,string email,string spid)
        {
            bool submited = false;
           
            Application application = new Application();
                        
                application.FullName = fname;
                application.DOB = Convert.ToDateTime(dob);
                application.HighestQualification = hqf;
                application.MarksObtained = Convert.ToInt32(marks);
                application.Goals = goal;
                application.Email_Id = email;
                application.Scheduled_ProgramId = spid;
                application.DateOFInterview = Convert.ToDateTime("01/01/2000").Date;
                application.Status = "applied";
                submited = true;
                if (submited == false) throw new UniversityException("Your Application not submitted succesfully");
            

            Add(application);
            return submited;
        }


        //Method to confirm by Mac
        public bool ConfirmByMacAfterInterview(int appId)
        {
            bool confirmed= false;
            bool chkId = false;
            bool chkStatus = false;
            Application app = new Application();
            Participant participant;
            List<Application> list = new List<Application>();
          
                list = GetAll();
                foreach (Application en in list)
                {
                    if (appId == en.ApplicationId) 
                    {
                    chkId = true;
                        if (en.Status.ToLower() == "accepted")
                        {
                            chkStatus = true;

                            app.ApplicationId = en.ApplicationId;
                            app.FullName = en.FullName;
                            app.DOB = en.DOB;
                            app.HighestQualification = en.HighestQualification;
                            app.MarksObtained = en.MarksObtained;
                            app.Goals = en.Goals;
                            app.Email_Id = en.Email_Id;
                            app.Scheduled_ProgramId = en.Scheduled_ProgramId;
                            app.Status = en.Status;
                            app.DateOFInterview = en.DateOFInterview;
                            confirmed = true;

                        ParticipantBL participantBL = new ParticipantBL();
                        participant = new Participant();
                        participant.ApplicationId = app.ApplicationId;
                        participant.EmailId = en.Email_Id;
                        participant.ScheduledProgramId = en.Scheduled_ProgramId;
                        
                        participantBL.Add(participant);
                            

                        }

                    }
                }
            if (chkId == false) throw new UniversityException("Check your Id");
            if (chkStatus == false) throw new UniversityException("This Application is Already Confirmed");
            
            if (confirmed == false) throw new UniversityException("Not Confirmed");
                Application newapp = new Application();
                newapp = app;
                newapp.Status = "confirmed";

                Update(appId, app);
           
            return confirmed;
        }

        public bool MacDeleteApplication(int appId)
        {

            bool deleted = false;
            bool chkId = false;
            bool checkStatus = false;
            Application app = new Application();
            
            List<Application> list = new List<Application>();

            list = GetAll();
            foreach (Application en in list)
            {
                if (appId == en.ApplicationId) 
                {
                    chkId = true;
                    
                    if (en.Status.ToLower() == "rejected")
                    {
                        checkStatus = true;
                        
                        app.ApplicationId = en.ApplicationId;
                        app.FullName = en.FullName;
                        app.DOB = en.DOB;
                        app.HighestQualification = en.HighestQualification;
                        app.MarksObtained = en.MarksObtained;
                        app.Goals = en.Goals;
                        app.Email_Id = en.Email_Id;
                        app.Scheduled_ProgramId = en.Scheduled_ProgramId;
                        app.Status = en.Status;
                        app.DateOFInterview = en.DateOFInterview;
                        deleted = true;

                        //ParticipantBL participantBL = new ParticipantBL();
                      
                        //participantBL.Delete(appId);
                        Delete(appId);


                    }

                }
            }
            if (chkId == false) throw new UniversityException("This Application Does not Exist");
            if (checkStatus == false) throw new UniversityException("Please Check your Id You only can Delete Rejected Application");           
            if (deleted == false) throw new UniversityException("Not Confirmed");
           // Application newapp = new Application();


            

            return deleted;
            
        }
    }
}
