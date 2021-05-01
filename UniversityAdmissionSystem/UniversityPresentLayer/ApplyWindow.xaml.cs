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
using UniversityExceptions;
using UniversityEntity;
using UniversityAdmsnBL;


namespace UniversityAdmissionPL

{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ApplyWindow : Window
    {
        public ApplyWindow()
        {
            InitializeComponent();
            
        }
        ApplicationBL BlObject = new ApplicationBL();
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_fname.Text)) throw new UniversityException("Name Field Cannot be Empty");
                if (string.IsNullOrWhiteSpace(DP_dob.Text)) throw new UniversityException("DOB Field Cannot be Empty");
                if (string.IsNullOrWhiteSpace(txt_Email.Text)) throw new UniversityException("Email Field Cannot be Empty");
                if (string.IsNullOrWhiteSpace(txt_hqf.Text)) throw new UniversityException("Qualifications Field Cannot be Empty");
                if (string.IsNullOrWhiteSpace(txt_Marks.Text)) throw new UniversityException("Marks Field Cannot be Empty");
                if (string.IsNullOrWhiteSpace(txt_Goals.Text)) throw new UniversityException("Goals Field Cannot be Empty");
                if (string.IsNullOrWhiteSpace(txt_Scheduled.Text)) throw new UniversityException("Scheduled ID Field Cannot be Empty");

                if (BlObject.Email_Regex.IsMatch(txt_Email.Text)==false)
                {
                    throw new UniversityException("Entered Email Id is in wrong format");
                }
               
                
                bool submited = BlObject.SubmitUserApplication(txt_fname.Text, DP_dob.Text, txt_hqf.Text, txt_Marks.Text, txt_Goals.Text, txt_Email.Text, txt_Scheduled.Text);
                if (submited) MessageBox.Show("Your Application Submitted Successfully");
                else throw new UniversityException("not submitted Successfully");

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

        private void home_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Check_click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                //ApplicationBL blObj = new ApplicationBL();
                if (string.IsNullOrWhiteSpace(id_txt.Text)) throw new UniversityException("Id Field is Empty");
                int a = Convert.ToInt32(id_txt.Text);

                List<UniversityEntity.Application> list = new List<UniversityEntity.Application>();
                list = BlObject.CheckStatusById(a);
                foreach (UniversityEntity.Application ap in list)
                {
                    MessageBox.Show($"Name :- {ap.FullName}\nId :- {ap.ApplicationId}\nApplication Status :-{ap.Status}");
                }


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

        private bool IsNumber(string txt)
        {
            bool isnum = false;
            int output;
            isnum = int.TryParse(txt, out output);
            return isnum;
        }

        private void PreviewTextName(object sender, TextCompositionEventArgs e)
        {

            if (IsNumber(e.Text))
            {
                e.Handled = true;
            }
        }

        private void PreviewTextMarks(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text)==false)
            {
                e.Handled = true;
            }
        }

        
    }
}