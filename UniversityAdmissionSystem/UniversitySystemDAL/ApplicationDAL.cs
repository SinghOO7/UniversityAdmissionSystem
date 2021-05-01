using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UniversityEntity;
using UniversityExceptions;

namespace UniversitySystemDAL
{
    public class ApplicationDAL
    {
      string ConString = @"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite";

        SqlConnection con; //new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite");

        public bool Add( string fullName, DateTime dob, string highQlfy, int marks, string goals, string email, string scheduleProgId, string status, DateTime doInterview)
        {
            bool added = false;

            using (con = new SqlConnection(ConString))
            {
                con.Open();
                // remove this
                SqlCommand cmdInsert = new SqlCommand("insert into Application (full_name,date_of_birth,highest_qualification,marks_obtained,goals,Email_id,Scheduled_program_id,status,Date_Of_Interview) values (@fname,@dob,@hqf,@marks,@goals,@email,@spid,@status,@doi)", con);
                
                    cmdInsert.CommandType = CommandType.Text;
                    //cmdInsert.Parameters.AddWithValue("@appid", appId);
                    cmdInsert.Parameters.AddWithValue("@fname", fullName);
                    cmdInsert.Parameters.AddWithValue("@dob", dob);
                    cmdInsert.Parameters.AddWithValue("@hqf", highQlfy);
                    cmdInsert.Parameters.AddWithValue("@marks", marks);
                    cmdInsert.Parameters.AddWithValue("@goals", goals);
                    cmdInsert.Parameters.AddWithValue("@email", email);
                    cmdInsert.Parameters.AddWithValue("@spid", scheduleProgId);
                    cmdInsert.Parameters.AddWithValue("@status", status);
                    cmdInsert.Parameters.AddWithValue("@doi", doInterview);
                    int result=cmdInsert.ExecuteNonQuery();
                     if (result == 0) throw new UniversityException("Insertion Failed");
                    added = true;
                    


                

            }

            return added;

        }

        public bool Update(int appId, string fullName, DateTime dob, string highQlfy, int marks, string goals, string email, string scheduleProgId, string status, DateTime doInterview)
        {
            bool updated = false;
            using (con =new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmdUpdate = new SqlCommand("Update  Application set full_name=@fname,date_of_birth=@dob ,highest_qualification=@hqf,marks_obtained=@marks,goals=@goals,Email_id=@email,Scheduled_program_id=@spid,status=@status,Date_Of_Interview=@doi where Application_id=@appid", con);
                
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Parameters.AddWithValue("@appid", appId);
                    cmdUpdate.Parameters.AddWithValue("@fname", fullName);
                    cmdUpdate.Parameters.AddWithValue("@dob", dob);
                    cmdUpdate.Parameters.AddWithValue("@hqf", highQlfy);
                    cmdUpdate.Parameters.AddWithValue("@marks", marks);
                    cmdUpdate.Parameters.AddWithValue("@goals", goals);
                    cmdUpdate.Parameters.AddWithValue("@email", email);
                    cmdUpdate.Parameters.AddWithValue("@spid", scheduleProgId);
                    cmdUpdate.Parameters.AddWithValue("@status", status);
                    cmdUpdate.Parameters.AddWithValue("@doi", doInterview);
                    int result=cmdUpdate.ExecuteNonQuery();
                if (result == 0) throw new UniversityException("Updation Failed");
                    updated = true;

                
            }

            if (updated == false) throw new UniversityException("program Updation failed");
            return updated;
        }


        public bool Delete(int appid)
        {
            bool deleted = false;

            using (con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmdDelete = new SqlCommand("DELETE From Application where Application_id=@appid", con);
                
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.Parameters.AddWithValue("@appid", appid);
                int result=cmdDelete.ExecuteNonQuery();

                if (result == 0) throw new UniversityException("Deletion Failed");
                    deleted = true;


                
            }

            
            return deleted;
        }

        public List<Application> GetAll()
        {

            
            List<Application> apps = new List<Application>();

            using (con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmdSelect = new SqlCommand("select * from Application", con);
                
                    SqlDataReader dr = cmdSelect.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            apps.Add(new Application
                            {
                                ApplicationId=(int) dr["Application_id"],
                                FullName = (string)dr["full_name"],
                                DOB=Convert.ToDateTime( dr["date_of_birth"]),
                                HighestQualification = (string)dr["highest_qualification"],
                                Goals = (string)dr["goals"],
                                Email_Id = (string)dr["Email_id"],
                                Scheduled_ProgramId = (string)dr["Scheduled_program_id"],
                                Status = (string)dr["status"],
                                DateOFInterview = Convert.ToDateTime (dr["Date_Of_Interview"]),
                                MarksObtained = (int)dr["marks_obtained"]
                            });

                        }

                        dr.Close();

                    }
                    else throw new UniversityException("Table is Empty");
                
            }

            
            return apps;
        }
    }
}

