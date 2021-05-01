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
   public class UserDAL
    {
        public bool Add(string logId, string pass,  string role)
        {
            bool added = false;

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdInsert = new SqlCommand("insert into Users (Login_id,password,role) values (@logid,@pass,@role)", con))
                {
                    cmdInsert.CommandType = CommandType.Text;
                    
                    cmdInsert.Parameters.AddWithValue("@logid", logId);
                    cmdInsert.Parameters.AddWithValue("@pass", pass);
                    cmdInsert.Parameters.AddWithValue("@role", role);
                  
                    cmdInsert.ExecuteNonQuery();
                    added = true;
                    if (added == false) throw new UniversityException("Insertion Failed");


                }

            }

            return added;

        }


        public bool Update(string updtlogId, string pass, string role,string curlogid)
        {
            bool updated = false;
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdUpdate = new SqlCommand("Update  Users set Login_id=@updtlogid,password=@pass,role=@role where Login_id=@curlogid", con))
                {
                    cmdUpdate.CommandType = CommandType.Text;

                    cmdUpdate.Parameters.AddWithValue("@curlogid", curlogid);
                    cmdUpdate.Parameters.AddWithValue("@updtlogid", updtlogId);
                    cmdUpdate.Parameters.AddWithValue("@pass", pass);
                    cmdUpdate.Parameters.AddWithValue("@role", role);
                   

                    cmdUpdate.ExecuteNonQuery();
                    updated = true;

                }
            }

            if (updated == false) throw new UniversityException("program Updation failed");
            return updated;
        }

        public bool Delete(string logid)
        {
            bool deleted = false;

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdDelete = new SqlCommand("DELETE From Users where Login_id=@logid", con))
                {
                    cmdDelete.CommandType = CommandType.Text;
                    cmdDelete.Parameters.AddWithValue("@logid", logid);

                    cmdDelete.ExecuteNonQuery();

                    deleted = true;


                }
            }

            if (deleted == false) throw new UniversityException("Deletion Failed");
            return deleted;
        }

        public List<Users> GetAll()
        {


            List<Users> l = new List<Users>();

            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdSelect = new SqlCommand("select * from Users", con))
                {
                    SqlDataReader dr = cmdSelect.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            l.Add(new Users
                            {
                                LoginId = (string)dr["Login_id"],
                                Password = (string)dr["password"],
                                Role = (string)dr["role"],
                                
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
