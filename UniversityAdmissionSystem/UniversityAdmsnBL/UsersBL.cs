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
    public class UsersBL
    {

        public bool Add(Users e)
        {
            bool add = false;
            //  DAL object will take programoffered
            UserDAL dal = new UserDAL();
            dal.Add(e.LoginId, e.Password, e.Role);
            add = true;
            if (add == false) throw new UniversityException("addtion Failed ");

            return add;
        }

        public bool Delete(Users e, string logid)
        {
            bool dlt = false;
            UserDAL dal = new UserDAL();
            dal.Delete(logid);
            dlt = true;
            if (dlt == false) throw new UniversityException("Program Deletion failed");
            return dlt;
        }

        public bool Update(string culogid, Users e)
        {
            bool updt = false;
            UserDAL dal = new UserDAL();
            dal.Update(e.LoginId, e.Password, e.Role,culogid);
            updt = true;
            if (updt == false) throw new UniversityException("Updation Failed");

            return updt;
        }

        public List<Users> GetAll()
        {
            List<Users> l = new List<Users>();
            UserDAL dal = new UserDAL();
            
                l = dal.GetAll();


            if (l.Count == 0) throw new UniversityException("Table is Empty");

            return l;
        }

        public bool MacLogin(string logId,string password)
        {
            bool loginSucces = false;
            try
            {
                List<Users> list = new List<Users>();
                list = GetAll();
                foreach (Users user in list)
                {

                    if (user.Role.ToLower() == "mac")
                    {
                        if (logId == user.LoginId && password == user.Password)
                        {
                            loginSucces = true;
                        }
                        //else MessageBox.Show("Wrong Credentials");
                    }


                }
                if (loginSucces == false) throw new UniversityException("WRONG CREDENTIALS");
            }
            catch (UniversityException ex)
            {

                throw new UniversityException(ex.Message);
            }
            return loginSucces;
        }

        public bool AdminLogin(string logId, string password)
        {
            bool loginSucces = false;
            try
            {
                List<Users> list = new List<Users>();
                list = GetAll();
                foreach (Users user in list)
                {

                    if (user.Role.ToLower() == "admin")
                    {
                        if (logId == user.LoginId && password == user.Password)
                        {
                            loginSucces = true;
                        }
                        //else MessageBox.Show("Wrong Credentials");
                    }


                }
                if (loginSucces == false) throw new UniversityException("WRONG CREDENTIALS");
            }
            catch (UniversityException ex)
            {

                throw new UniversityException(ex.Message);
            }
            return loginSucces;
        }
    }
}
