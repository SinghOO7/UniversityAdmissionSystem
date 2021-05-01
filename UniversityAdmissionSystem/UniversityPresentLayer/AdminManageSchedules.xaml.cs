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
    /// Interaction logic for AdminManageSchedules.xaml
    /// </summary>
    public partial class AdminManageSchedules : Window
    {
        public AdminManageSchedules()
        {
            InitializeComponent();
        }

        private void home_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgramScheduled program = new ProgramScheduled();
                ProgramsScheduledBL bL = new ProgramsScheduledBL();
                if (string.IsNullOrWhiteSpace(txt_schId.Text))throw new UniversityException("Program Id field can not be Empty");
                if (string.IsNullOrWhiteSpace(txt_pname.Text)) throw new UniversityException("Program Name field can not be Empty");
                if (string.IsNullOrWhiteSpace(txt_loc.Text)) throw new UniversityException("Location field can not be Empty");
                if (string.IsNullOrWhiteSpace(DP_sdate.Text)) throw new UniversityException("StartDate field can not be Empty");
                if (string.IsNullOrWhiteSpace(DP_edate.Text)) throw new UniversityException("EndDate field can not be Empty");
                if (string.IsNullOrWhiteSpace(txt_session.Text)) throw new UniversityException("Session field can not be Empty");


                program.ScheduledProgramID = txt_schId.Text;
                program.ProgramName = txt_pname.Text;
                program.Location = txt_loc.Text;
                program.StartDate = Convert.ToDateTime(DP_sdate.Text);
                program.EndDate = Convert.ToDateTime(DP_edate.Text);
                program.SessionsPerWeek = Convert.ToInt32(txt_session.Text);
               bool added= bL.Add(program);
                if (added) MessageBox.Show("Added Succesfully");
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

        private void delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgramsScheduledBL bL = new ProgramsScheduledBL();

                bool deleted = bL.Delete(txt_schId.Text);
                if (deleted) MessageBox.Show("Deleted Succesfully");
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

        private void update_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgramScheduled program = new ProgramScheduled();
                ProgramsScheduledBL bL = new ProgramsScheduledBL();
                program.ScheduledProgramID = txt_schId.Text;
                program.ProgramName = txt_pname.Text;
                program.Location = txt_loc.Text;
                program.StartDate = Convert.ToDateTime(DP_sdate.Text);
                program.EndDate = Convert.ToDateTime(DP_edate.Text);
                program.SessionsPerWeek = Convert.ToInt32(txt_session.Text);
                bool updated = bL.Update(program.ScheduledProgramID,program);
                if (updated) MessageBox.Show("Updated Succesfully");
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
            AdminProgramOffered admin = new AdminProgramOffered();
            admin.Show();
            this.Close();
        }
    }
}
