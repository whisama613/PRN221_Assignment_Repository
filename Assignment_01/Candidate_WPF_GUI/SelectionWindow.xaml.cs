using System.Windows;

namespace Candidate_WPF_GUI
{
    /// <summary>
    /// Interaction logic for SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {
        int? roleId;
        public SelectionWindow(int? roleID)
        {
            InitializeComponent();

            this.roleId = roleID;
        }

        private void btnCandidateProfile_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfileWindow candidateProfileWindow = new CandidateProfileWindow(roleId);
            candidateProfileWindow.Show();
        }

        private void btnJobPosting_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow(roleId);
            jobPostingWindow.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
