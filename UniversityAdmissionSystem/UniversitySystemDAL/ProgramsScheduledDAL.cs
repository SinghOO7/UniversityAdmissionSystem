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
    public class ProgramsScheduledDAL
    {
        public bool Add(string spid, string pname, string loc,DateTime sdate,DateTime edate,int spweek)
        {
            bool added = false;

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdInsert = new SqlCommand("insert into Programs_Scheduled (Scheduled_program_id,ProgramName,Location,start_date,end_date,sessions_per_week) values (@spid,@pname,@loc,@sdate,@edate,@spweek)", con))
                {
                    cmdInsert.CommandType = CommandType.Text;

                    cmdInsert.Parameters.AddWithValue("@spid", spid);
                    cmdInsert.Parameters.AddWithValue("@pname", pname);
                    cmdInsert.Parameters.AddWithValue("@loc", loc);
                    cmdInsert.Parameters.AddWithValue("@sdate", sdate);
                    cmdInsert.Parameters.AddWithValue("@edate", edate);
                    cmdInsert.Parameters.AddWithValue("@spweek", spweek);

                    cmdInsert.ExecuteNonQuery();
                    added = true;
                    if (added == false) throw new UniversityException("Insertion Failed");


                }

            }

            return added;

        }

        public bool Update(string updtspid, string pname, string loc, DateTime sdate, DateTime edate, int spweek ,string curspid)
        {
            bool updated = false;
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdUpdate = new SqlCommand("Update  Programs_Scheduled set Scheduled_program_id=@spid,ProgramName=@pname,Location=@loc,start_date=@sdate,end_date=@edate,sessions_per_week=@spweek where Scheduled_program_id=@curspid", con))
                {
                    cmdUpdate.CommandType = CommandType.Text;

                    cmdUpdate.Parameters.AddWithValue("@spid", updtspid);
                    cmdUpdate.Parameters.AddWithValue("@pname", pname);
                    cmdUpdate.Parameters.AddWithValue("@loc", loc);
                    cmdUpdate.Parameters.AddWithValue("@sdate", sdate);
                    cmdUpdate.Parameters.AddWithValue("@edate", edate);
                    cmdUpdate.Parameters.AddWithValue("@spweek", spweek);
                    cmdUpdate.Parameters.AddWithValue("@curspid", curspid);


                    cmdUpdate.ExecuteNonQuery();
                    updated = true;

                }
            }

            if (updated == false) throw new UniversityException("program Updation failed");
            return updated;
        }

        public bool Delete(string spid)
        {
            bool deleted = false;

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdDelete = new SqlCommand("DELETE From Programs_Scheduled where Scheduled_program_id=@spid", con))
                {
                    cmdDelete.CommandType = CommandType.Text;
                    cmdDelete.Parameters.AddWithValue("@spid", spid);

                    cmdDelete.ExecuteNonQuery();

                    deleted = true;


                }
            }

            if (deleted == false) throw new UniversityException("Deletion Failed");
            return deleted;
        }

        public List<ProgramScheduled> GetAll()
        {


            List<ProgramScheduled> l = new List<ProgramScheduled>();

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdSelect = new SqlCommand("select * from Programs_Scheduled", con))
                {
                    SqlDataReader dr = cmdSelect.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            l.Add(new ProgramScheduled
                            {
                                ScheduledProgramID = (string)dr["Scheduled_program_id"],
                                ProgramName = (string)dr["ProgramName"],
                                Location = (string)dr["Location"],
                                StartDate = (DateTime)dr["start_date"],
                                EndDate = (DateTime)dr["end_date"],
                                SessionsPerWeek = (int)dr["sessions_per_week"],

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
