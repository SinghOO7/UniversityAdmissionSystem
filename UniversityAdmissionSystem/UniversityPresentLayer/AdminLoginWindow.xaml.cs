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
    /// Interaction logic for AdminLoginWindow.xaml
    /// </summary>
    public partial class AdminLoginWindow : Window
    {
        public AdminLoginWindow()
        {
            InitializeComponent();
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                bool match = false;
                UsersBL p = new UsersBL();
                string login_txt = LoginId_txt.Text;
                string pass_txt = txt_Password.Password;
                match = p.AdminLogin(login_txt, pass_txt);
                if (match)
                {
                    MessageBox.Show("Login Succesfull");
                    AdminProgramOffered admin = new AdminProgramOffered();
                    admin.Show();
                    this.Close();

                }
                else throw new UniversityException("Wrong Credentials");
            }
            catch (UniversityException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Home_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }




    }
    
}
