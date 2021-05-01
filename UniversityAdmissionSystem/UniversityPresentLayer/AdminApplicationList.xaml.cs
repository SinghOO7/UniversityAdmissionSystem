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
    /// Interaction logic for AdminApplicationList.xaml
    /// </summary>
    public partial class AdminApplicationList : Window
    {
        public AdminApplicationList()
        {
            InitializeComponent();
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
                        DOB = en.DOB,
                        HighestQualification = en.HighestQualification,
                        MarksObtained = en.MarksObtained,
                        Goals = en.Goals,
                        Email_Id = en.Email_Id,
                        Scheduled_ProgramId = en.Scheduled_ProgramId,
                        Status = en.Status,
                        DateOFInterview = en.DateOFInterview


                    };

                }

                lst_Of_Apps.ItemsSource = list;

            }
            catch (UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            AdminProgramOffered admin = new AdminProgramOffered();
            admin.Show();
            this.Close();
        }
    }
}
