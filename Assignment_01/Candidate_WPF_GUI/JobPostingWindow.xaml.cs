using Candidate_BussinessObjects;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Candidate_WPF_GUI
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private IJobPostingService service;

        public JobPostingWindow(int? roleId)
        {
            InitializeComponent();
            service = new JobPostingService();
            RefreshData();
            switch (roleId)
            {
                case 1:
                    break;
                case 2:
                    AddBtn.IsEnabled = false;
                    break;
                default:
                    AddBtn.IsEnabled = false;
                    UpdateBtn.IsEnabled = false;
                    RemoveBtn.IsEnabled = false;
                    break;
            }
        }
        public JobPostingWindow()
        {
            InitializeComponent();
            service = new JobPostingService();
        }

        private void RefreshData()
        {
            List<JobPosting> jobPostings = service.GetJobPostings();
            dtgJobPosting.ItemsSource = jobPostings;
            foreach (var column in dtgJobPosting.Columns)
            {
                if (column.Header.ToString() == "CandidateProfiles")
                {
                    column.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ClearData()
        {
            TxtJobId.Text = string.Empty;
            TxtTitle.Text = string.Empty;
            TxtDescription.Text = string.Empty;
            postDateTxt.Text = string.Empty;
        }

        private JobPosting GetDataFromForm()
        {
            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = TxtJobId.Text;
            jobPosting.JobPostingTitle = TxtTitle.Text;
            jobPosting.Description = TxtDescription.Text;
            jobPosting.PostedDate = DateTime.Now;
            return jobPosting;
        }

        private String ValidateData(JobPosting jobPosting, String type)
        {
            String result = "";
            if (jobPosting.PostingId.Equals(""))
                result = "PostingID null!!\n";
            else if (!Regex.Match(
                    jobPosting.PostingId,
                    @"P[0-9][0-9][0-9][0-9]", RegexOptions.IgnoreCase).Success)
                result = "Wrong ID format!! (Pxxxx)\n";
            else
            {
                List<JobPosting> jobPostings = service.GetJobPostings();
                for (int i = 0; i < jobPostings.Count; i++)
                {
                    JobPosting jobPosting1 = jobPostings[i];
                    if (jobPosting.PostingId.Equals(jobPosting1.PostingId)
                        && type.Equals("Add"))
                        result = "ID Exist!!\n";
                }
            }
            if ((result.Equals("ID exist!!\n") && type.Equals("Update")) ||
            (result.Equals("ID exist!!\n") && type.Equals("Remove")))
                result = "ID Not Exist!!";
            if (jobPosting.JobPostingTitle.Equals(""))
                result = result + "JobPostingTitle null!!";
            if (result.Equals("")) result = "Ready to " + type;
            return result;
        }

        //----------------------------Button----------------------------

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = GetDataFromForm();
            string message = ValidateData(jobPosting, "Add");
            if (!message.Equals("Ready to Add"))
            {
                MessageBox.Show(message);
            }
            else if (message.Equals("Ready to Add"))
            {
                MessageBox.Show("Added !!");
                service.AddJobPosting(jobPosting);
                ClearData();
                RefreshData();
            }
        }

        private void dtgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            JobPosting job = dtgJobPosting.SelectedItem as JobPosting;
            if (job != null)
            {
                TxtJobId.Text = job.PostingId;
                TxtTitle.Text = job.JobPostingTitle;
                TxtDescription.Text = job.Description;
                postDateTxt.Text = job.PostedDate.ToString();
            }
        }
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            RefreshData();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = GetDataFromForm();
            string message = ValidateData(jobPosting, "Remove");
            if (!message.Equals("Ready to Remove"))
            {
                MessageBox.Show(message);
            }
            else if (message.Equals("Ready to Remove"))
            {
                MessageBox.Show("Deleted !!");
                service.DeleteJobPosting(jobPosting);
                ClearData();
                RefreshData();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = GetDataFromForm();
            string message = ValidateData(jobPosting, "Update");
            if (!message.Equals("Ready to Update"))
            {
                MessageBox.Show(message);
            }
            else if (message.Equals("Ready to Update"))
            {
                MessageBox.Show("Updated !!");
                service.UpdateJobPosting(jobPosting);
                ClearData();
                RefreshData();
            }
        }
    }
}
