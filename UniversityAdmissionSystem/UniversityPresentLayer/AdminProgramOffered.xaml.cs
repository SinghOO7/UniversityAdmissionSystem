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
    /// Interaction logic for AdminProgramOffered.xaml
    /// </summary>
    public partial class AdminProgramOffered : Window
    {
        public AdminProgramOffered()
        {
            InitializeComponent();
        }

        private void program_click(object sender, RoutedEventArgs e1)
        {
            try
            {
                ProgramScheduled program;
                ProgramsScheduledBL blObj = new ProgramsScheduledBL();
                List<ProgramScheduled> list = new List<ProgramScheduled>();
                list = blObj.GetAll();
                foreach (ProgramScheduled e in list)
                {
                    program = new ProgramScheduled()
                    {
                        ScheduledProgramID = e.ScheduledProgramID,
                        ProgramName = e.ProgramName,
                        Location = e.Location,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        SessionsPerWeek = e.SessionsPerWeek
                    };

                }

                lst_Of_Courses.ItemsSource = list;

            }
            catch (UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

   
        private void manage_click(object sender, RoutedEventArgs e)
        {
            AdminManageSchedules admin = new AdminManageSchedules();
            admin.Show();
            this.Close();
        }

        private void app_click(object sender, RoutedEventArgs e)
        {
            AdminApplicationList admin = new AdminApplicationList();
            admin.Show();
            this.Close();
        }

        private void prog_click(object sender, RoutedEventArgs e)
        {
            ManageProgramOffered manage = new ManageProgramOffered();
            manage.Show();
            this.Close();
        }

        private void back_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
