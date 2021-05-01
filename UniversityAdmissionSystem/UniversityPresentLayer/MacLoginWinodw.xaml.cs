using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UniversityAdmsnBL;
using UniversityEntity;
using UniversityExceptions;

namespace UniversityAdmissionPL
{
    /// <summary>
    /// Interaction logic for MacLoginWinodw.xaml
    /// </summary>
    public partial class MacLoginWinodw : Window
    {
        public MacLoginWinodw()
        {
            InitializeComponent();
        }

        private void Click_Submit(object sender, RoutedEventArgs e)
        {
            try
            {


                bool match = false;
                UsersBL p = new UsersBL();
                string login_txt = LoginId_txt.Text;
                string pass_txt = txt_Password.Password;
                match = p.MacLogin(login_txt, pass_txt);
                if (match)
                {
                    //MessageBox.Show("Login Succesfull");
                    MacApplicationsList mac = new MacApplicationsList();
                          mac.Show();
                          this.Close();
                }
                else throw new UniversityException("Wrong Credentials");
            }
            catch(UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }

            
           
            //try
            //{
            //    List<Users> list = new List<Users>();
            //    UsersBL p = new UsersBL();
            //    list = p.GetAll();
            //    foreach(Users user in list )
            //    {

            //        if(user.Role=="mac")
            //        {
            //            if (LoginId_txt.Text == user.LoginId && txt_Password.Password == user.Password)
            //            {
            //                match = true;
            //            }
            //            //else MessageBox.Show("Wrong Credentials");
            //        }


            //    }

            //    if (match == true)
            //    {
            //        MessageBox.Show("Login Succesfull");
            //        MacApplicationsList mac = new MacApplicationsList();
            //        mac.Show();
            //        this.Close();
            //    }
            //    else throw new UniversityException("Wrong Credentials");
            //}
            //catch (UniversityException ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            
        }

        private void Home_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        
    }
}
