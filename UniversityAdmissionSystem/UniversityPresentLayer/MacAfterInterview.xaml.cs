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
    /// Interaction logic for MacAfterInterview.xaml
    /// </summary>
    public partial class MacAfterInterview : Window
    {
        public MacAfterInterview()
        {
            InitializeComponent();
        }
        // BUssiness Layer Object
        public ApplicationBL BlObject = new ApplicationBL();

        private void confirm_click(object sender, RoutedEventArgs e)
        {
           
            try
            {

               // ApplicationBL blObj = new ApplicationBL();
                if (id_txt.Text.Count() == 0) throw new UniversityException("Id field is empty");


                int appId = Convert.ToInt32(id_txt.Text);

                bool confirmed = BlObject.ConfirmByMacAfterInterview(appId);

                if (confirmed == true) MessageBox.Show("Confirmed Succesfully");
                else throw new UniversityException("Check Id may be wrong");
                

            }
            catch (UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void show_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                UniversityEntity.Application app = new UniversityEntity.Application();
               // UniversityEntity.Application app1 = new UniversityEntity.Application();
               // ApplicationBL blObj = new ApplicationBL();
                List<UniversityEntity.Application> list = new List<UniversityEntity.Application>();
                List<UniversityEntity.Application> list1 = new List<UniversityEntity.Application>();
                list = BlObject.GetAll();
               
                foreach (UniversityEntity.Application en in list)
                {
                    app = new UniversityEntity.Application();
                    if (en.Status.ToLower() == "accepted" || en.Status.ToLower()=="confirmed")
                    {
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
                        
                        list1.Add(app);

                       


                    };
                   
                }
                lst_Of_Apps.ItemsSource = list1;
            }
            catch (UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reject_click(object sender, RoutedEventArgs e)
        {

            try
            {
               // ApplicationBL blObj = new ApplicationBL();
                if (id_txt.Text.Count() == 0) throw new UniversityException("Id field is empty");


                int appId = Convert.ToInt32(id_txt.Text);

                bool rejected = BlObject.RejectAppByMacAfterInterview(appId);

                if (rejected == true) MessageBox.Show("Rejected Succesfully");
                else throw new UniversityException("Fill all fields caefully");

            }
            catch (UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_click(object sender, RoutedEventArgs e)
        {
            MacApplicationsList main = new MacApplicationsList();
            main.Show();
            this.Close();
        }

        private void home_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
 