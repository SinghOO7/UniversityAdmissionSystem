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
    /// Interaction logic for MacApplicationsList.xaml
    /// </summary>
    public partial class MacApplicationsList : Window
    {
        public MacApplicationsList()
        {
            InitializeComponent();
            try
            {
                UniversityEntity.Application app;
                ApplicationBL blObj = new ApplicationBL();
                List<UniversityEntity.Application> list = new List<UniversityEntity.Application>();
                list = blObj.GetAll();
                foreach (UniversityEntity.Application en in list)
                {
                    app = new UniversityEntity.Application()
                    {
                        ApplicationId = en.ApplicationId,
                        FullName = en.FullName,
                        DOB = en.DOB,
                        HighestQualification = en.HighestQualification,
                        MarksObtained = en.MarksObtained,
                        Goals = en.Goals,
                        Email_Id = en.Email_Id,
                        Scheduled_ProgramId = en.Scheduled_ProgramId,
                        Status = en.Status,
                        DateOFInterview = en.DateOFInterview.Date


                    };

                }

                lst_Of_Apps.ItemsSource= list;

            }
            catch (UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void show_click(object sender, RoutedEventArgs e)
        {
            try
            {
                UniversityEntity.Application app;
                ApplicationBL blObj = new ApplicationBL();
                List<UniversityEntity.Application> list = new List<UniversityEntity.Application>();
                list = blObj.GetAll();
                foreach (UniversityEntity.Application en in list)
                {
                    app = new UniversityEntity.Application()
                    {
                        ApplicationId = en.ApplicationId,
                        FullName = en.FullName,
                        DOB=en.DOB,
                        HighestQualification=en.HighestQualification,
                        MarksObtained=en.MarksObtained,
                        Goals=en.Goals,
                        Email_Id=en.Email_Id,
                        Scheduled_ProgramId=en.Scheduled_ProgramId,
                        Status=en.Status,
                        DateOFInterview=en.DateOFInterview.Date


                    };

                }

                lst_Of_Apps.ItemsSource = list;

            }
            catch (UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                ApplicationBL blObj = new ApplicationBL();
                if (id_txt.Text.Count() == 0) throw new UniversityException("Id Field is Empty");
                if(doi_DP.Text.Count()==0) throw new UniversityException("Interview Date Field is Empty");
                
                int appId =Convert.ToInt32( id_txt.Text);
                DateTime date= Convert.ToDateTime(doi_DP.Text);
               bool accepted= blObj.AcceptAppByMac(appId,date);

                if (accepted == true) MessageBox.Show("Accepted Succesfully");
                else throw new UniversityException("Fill all Fields caefully");
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

         private void reject_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                ApplicationBL blObj = new ApplicationBL();
                if (id_txt.Text.Count() == 0) throw new UniversityException("id field is empty");
                

                int appId = Convert.ToInt32(id_txt.Text);
                
                bool rejected = blObj.RejectAppByMac(appId);

                if (rejected == true) MessageBox.Show("rejected Succesfully");
                else throw new UniversityException("fill all fields caefully");
                
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

        private void int_click(object sender, RoutedEventArgs e)
        {
            MacAfterInterview mac = new MacAfterInterview();
            mac.Show();
            this.Close();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ApplicationBL bL = new ApplicationBL();
                if (id_txt.Text.Count() == 0) throw new UniversityException("ID Field is Empty");
                int id = Convert.ToInt32(id_txt.Text);
                bool deleted = bL.MacDeleteApplication(id);
                //ApplicationBL bL = new ApplicationBL();
                //if (id_txt.Text.Count() == 0) throw new UniversityException("ID Field is Empty");
                //int id = Convert.ToInt32(id_txt.Text);
                //bool deleted = bL.Delete(id);

                if (deleted) MessageBox.Show("Deleted Succesfully");
                else throw new UniversityException("not Deleted Succesfully");
            }
            catch(UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
    

