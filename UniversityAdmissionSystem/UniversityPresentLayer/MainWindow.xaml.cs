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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UniversityAdmsnBL;
using UniversityEntity;
using UniversityExceptions;

namespace UniversityAdmissionPL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {          
            InitializeComponent();
            //All the programs schedule will be initialized  with the opening
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




        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            ApplyWindow apply = new ApplyWindow();
            apply.Show();
            this.Close();
        }

        private void MAC_Click(object sender, RoutedEventArgs e)
        {
            MacLoginWinodw macLogin = new MacLoginWinodw();
            macLogin.Show();
            this.Close();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginWindow adminLogin = new AdminLoginWindow();
            adminLogin.Show();
            this.Close();
        }

        private void Show_Click(object sender, RoutedEventArgs e1)
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
                        ProgramName=e.ProgramName,
                        Location=e.Location,
                        StartDate=e.StartDate,
                        EndDate=e.EndDate,
                        SessionsPerWeek=e.SessionsPerWeek
                    };

                }

                lst_Of_Courses.ItemsSource = list;

            }
            catch (UniversityException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh_click(object sender, RoutedEventArgs e)
        {

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
