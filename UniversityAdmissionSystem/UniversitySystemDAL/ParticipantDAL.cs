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
    public class ParticipantDAL
    {
        public bool Add(string email,int apid,string spid)
        {
            bool added = false;

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdInsert = new SqlCommand("insert into Participant (email_id,Application_id,Scheduled_program_id) values (@email,@apid,@spid)", con))
                {
                    cmdInsert.CommandType = CommandType.Text;
                    //cmdInsert.Parameters.AddWithValue("@appid", appId);
                   // cmdInsert.Parameters.AddWithValue("@rolno", rollno);
                    cmdInsert.Parameters.AddWithValue("@email", email);
                    cmdInsert.Parameters.AddWithValue("@apid", apid);
                    cmdInsert.Parameters.AddWithValue("@spid", spid);
                    
                    cmdInsert.ExecuteNonQuery();
                    added = true;
                    if (added == false) throw new UniversityException("Insertion Failed");


                }

            }

            return added;

        }

        public bool Update(string updtrollno, string email, int apid, string spid,string curroll)
        {
            bool updated = false;
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdUpdate = new SqlCommand("Update  Participant set Roll_no=@rolno,email_id=@email,Application_id=@apid,Scheduled_program_id=@spid where Roll_no=@curolno", con))
                {
                    cmdUpdate.CommandType = CommandType.Text;

                    cmdUpdate.Parameters.AddWithValue("@curolno", curroll);
                    cmdUpdate.Parameters.AddWithValue("@rolno", updtrollno);
                    cmdUpdate.Parameters.AddWithValue("@email", email);
                    cmdUpdate.Parameters.AddWithValue("@apid", apid);
                    cmdUpdate.Parameters.AddWithValue("@spid", spid);                  

                    cmdUpdate.ExecuteNonQuery();
                    updated = true;

                }
            }

            if (updated == false) throw new UniversityException("program Updation failed");
            return updated;
        }

        public bool Delete(int appId)
        {
            bool deleted = false;

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdDelete = new SqlCommand("DELETE From Participant where Application_id=@appId", con))
                {
                    cmdDelete.CommandType = CommandType.Text;
                    cmdDelete.Parameters.AddWithValue("@appId", appId);

                    cmdDelete.ExecuteNonQuery();

                    deleted = true;


                }
            }

            if (deleted == false) throw new UniversityException("Deletion Failed");
            return deleted;
        }

        public List<Participant> GetAll()
        {


            List<Participant> l = new List<Participant>();

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdSelect = new SqlCommand("select * from Participant", con))
                {
                    SqlDataReader dr = cmdSelect.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            l.Add(new Participant
                            {
                                RollNo = (string)dr["Roll_no"],
                                EmailId = (string)dr["email_id"],                               
                                ScheduledProgramId = (string)dr["Scheduled_program_id"],                     ApplicationId = (int)dr["Application_id"]
                            });

                        }

                        dr.Close();

                    }
                    else throw new UniversityException("Table is Empty");
                }
            }

          

            return l;
        }
    }
}
