using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UniversityExceptions;
using UniversityEntity;

namespace UniversitySystemDAL
{
    public class ProgramOfferedDAL
    {
        SqlConnection con;


        public bool Add(string progname, string descrp, string elgblty, int duration, string degree)
        {
            bool programadded = false;


            con = new SqlConnection();
            con.ConnectionString = " Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite";


            con.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = con;

            cmdInsert.CommandText = @"insert into Programs_Offered (ProgramName,description,applicant_eligibility,duration,degree_certificate_offered) values (@pname,@pdesc,@eligiblity,@duration,@degree)";  // Adding program
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.Parameters.AddWithValue("@pname", progname);
            cmdInsert.Parameters.AddWithValue("@pdesc", descrp);
            cmdInsert.Parameters.AddWithValue("@eligiblity", elgblty);
            cmdInsert.Parameters.AddWithValue("@duration", duration);
            cmdInsert.Parameters.AddWithValue("@degree", degree);


            cmdInsert.ExecuteNonQuery();
            programadded = true;



           // Console.WriteLine("Values inserted Successfully");

            con.Close();
           // Console.ReadKey();
            if (programadded == false) throw new UniversityException("Program insertion Failed");

            return programadded;

        }


        public bool Delete(string progname)
        {
            bool progdeleted = false;

            
            progname = progname.ToLower();
            con = new SqlConnection();
            con.ConnectionString = " Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite";


            con.Open();

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = con;

            cmdDelete.CommandText = @"DELETE From Programs_Offered WHERE ProgramName =@pname ";  // Adding program
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.Parameters.AddWithValue("@pname", progname);


            cmdDelete.ExecuteNonQuery();
            con.Close();
            progdeleted = true;
            if (progdeleted == false) throw new UniversityException("deletion is failed");
            return progdeleted;
        }

        public bool Update(string progNameForUpdate, string descrp, string elgblty, int duration, string degree)
        {
            bool progupdated = false;
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
            {
                con.Open();
                using (SqlCommand cmdUpdate = new SqlCommand("Update  Programs_Offered set ProgramName = @pname,description=@pdesc,applicant_eligibility=@eligiblity,duration=@duration,degree_certificate_offered=@degree where ProgramName = @pname", con))
                {
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Parameters.AddWithValue("@pname", progNameForUpdate);
                    cmdUpdate.Parameters.AddWithValue("@pdesc", descrp);
                    cmdUpdate.Parameters.AddWithValue("@eligiblity", elgblty);
                    cmdUpdate.Parameters.AddWithValue("@duration", duration);
                    cmdUpdate.Parameters.AddWithValue("@degree", degree);

                    cmdUpdate.ExecuteNonQuery();
                    progupdated = true;

                }
            }
            if (progupdated == false) throw new UniversityException("Updation Failed");           
            return progupdated;
        }
        public List<ProgramOffered> GetAll()
        {
            
            ProgramOffered prog = new ProgramOffered();
            List<ProgramOffered> progs = new List<ProgramOffered>();
            
                using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-1VJDA3L; Initial Catalog =University Management System(dm); User ID = sa; Password = admin123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite"))
                {
                    con.Open();
                    using (SqlCommand cmdSelect = new SqlCommand("select * from Programs_Offered", con))
                    {
                        SqlDataReader dr = cmdSelect.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                progs.Add(new ProgramOffered
                                {
                                    ProgramName = (string)dr["ProgramName"],
                                    Description = (string)dr["description"],
                                    ApllicationEligibility = (string)dr["applicant_eligibility"],
                                    Duration = (int)dr["duration"],
                                    DegreeCertificationOffered = (string)dr["degree_certificate_offered"]
                                });

                            }
                          
                            dr.Close();

                        }
                    else throw new UniversityException("Table is Empty");
                }
                }

            if (progs.Count > 0)
            {

            }
            else throw new UniversityException("Data retriving not succeded");

            return progs;   
        }
   }
       
 }
       
    

