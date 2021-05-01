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
    /// Interaction logic for ManageProgramOffered.xaml
    /// </summary>
    public partial class ManageProgramOffered : Window
    {
        public ManageProgramOffered()
        {
            InitializeComponent();
        }
        // it will redirect to the home page
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
                ProgramOffered program = new ProgramOffered();
                ProgramsOfferedBL bL = new ProgramsOfferedBL();

               // if(string.IsNullOrWhiteSpace(pname_txt.Text))

                if (pname_txt.Text.Length == 0) throw new UniversityException("Program Name Field Can not be Empty");
                if (Desc_txt.Text.Length == 0) throw new UniversityException("Description Field Can not be Empty");
                if (elg_txt.Text.Length == 0) throw new UniversityException("Application Eligibility Field Can not be Empty");
                if (dur_txt.Text.Length == 0) throw new UniversityException("Duration Field Can not be Empty");
                if (deg_txt.Text.Length == 0) throw new UniversityException("Degree Certificate Field Can not be Empty");
                program.ProgramName = pname_txt.Text;
                program.Description = Desc_txt.Text;
                program.ApllicationEligibility = elg_txt.Text;
                program.Duration = Convert.ToInt32(dur_txt.Text);
                program.DegreeCertificationOffered = deg_txt.Text;
                
                bool added = bL.Add(program);
                if (added) MessageBox.Show("Added Succesfully");
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

        private void delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgramsOfferedBL bL = new ProgramsOfferedBL();

                bool deleted = bL.Delete(pname_txt.Text);
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
                ProgramOffered program = new ProgramOffered();
                ProgramsOfferedBL bL = new ProgramsOfferedBL();
                if (pname_txt.Text.Length == 0) throw new UniversityException("Program Name Field Can not be Empty");
                if (Desc_txt.Text.Length == 0) throw new UniversityException("Description Field Can not be Empty");
                if (elg_txt.Text.Length == 0) throw new UniversityException("Application Eligibility Field Can not be Empty");
                if (dur_txt.Text.Length == 0) throw new UniversityException("Duration Field Can not be Empty");
                if (deg_txt.Text.Length == 0) throw new UniversityException("Degree Certificate Field Can not be Empty");
                program.ProgramName = pname_txt.Text;
                program.Description = Desc_txt.Text;
                program.ApllicationEligibility = elg_txt.Text;
                program.Duration = Convert.ToInt32(dur_txt.Text);
                program.DegreeCertificationOffered = deg_txt.Text;
                bool updated = bL.Update(program.ProgramName, program);
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

