using Candidate_BussinessObjects;
using Candidate_DAO;
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
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private ICandidateProfileService candidateProfileService;
        
        public CandidateProfileWindow()
        {
            InitializeComponent();
            candidateProfileService = new CandidateProfileService();

        }

        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
            candidateProfileService = new CandidateProfileService();
            RefreshData();
            switch (roleID)
            {
                case 1:
                    break;
                case 2:
                    AddBtn.IsEnabled = false;
                    break;
                case 3:
                    AddBtn.IsEnabled = false;
                    UpdateBtn.IsEnabled = false;
                    RemoveBtn.IsEnabled = false;
                    break;
            }
        }

        private void RefreshData()
        {
            List<CandidateProfile> candidates = candidateProfileService.GetCandidateProfiles();
            dtgCandidateProfile.ItemsSource = MapCandidateToDisplayDTO(candidates);
            PostingIdCbb.ItemsSource = candidateProfileService.GetPostingIds();
        }

        public List<CandidateDisplay> MapCandidateToDisplayDTO(List<CandidateProfile> candidates)
        {
            List<CandidateDisplay> displayCandidates = new List<CandidateDisplay>();

            foreach (var candidateProfile in candidates)
            {
                var posting = JobPostingDAO.Instance.GetJobPosting(candidateProfile.PostingId);
                displayCandidates.Add(new CandidateDisplay
                {
                    CandidateId = candidateProfile.CandidateId,
                    Fullname = candidateProfile.Fullname,
                    Birthday = candidateProfile.Birthday,
                    ProfileShortDescription = candidateProfile.ProfileShortDescription,
                    ProfileUrl = candidateProfile.ProfileUrl,
                    PostingDisplay = posting != null ? $"{posting.PostingId} ({posting.JobPostingTitle})" : "N/A"
                });
            }
            return displayCandidates;
        }

        private void ClearData()
        {
            CandidateIdTxt.Text = string.Empty;
            FullnameTxt.Text = string.Empty;
            PostingIdCbb.Text = string.Empty;
            ImageURLTxt.Text = string.Empty;
            TxtDescription.Text = string.Empty;
            birthDateTxt.Text = string.Empty;
        }

        private CandidateProfile GetDataFromForm()
        {
            CandidateProfile candidate = new CandidateProfile();
            candidate.Posting = new JobPosting();
            candidate.CandidateId = CandidateIdTxt.Text;
            candidate.Fullname = FullnameTxt.Text;
            candidate.Birthday = birthDateTxt.SelectedDate;
            candidate.ProfileShortDescription = TxtDescription.Text;
            candidate.ProfileUrl = ImageURLTxt.Text;
            candidate.PostingId = PostingIdCbb.Text.Split('(')[0].Trim();
            return candidate;
        }

        private String ValidateData(CandidateProfile candidate, String type)
        {
            String result = "";
            if (candidate.CandidateId.Equals(""))
                result = "CandidateID null!!\n";
            else if (!Regex.Match(
                    candidate.CandidateId,
                    @"CANDIDATE[0-9][0-9][0-9][0-9]", RegexOptions.IgnoreCase).Success)
                result = "Wrong ID format!! (CANDIDATExxxx)\n";
            else
            {
                List<CandidateProfile> candidates = candidateProfileService.GetCandidateProfiles();
                for (int i = 0; i < candidates.Count; i++)
                {
                    CandidateProfile candidate1 = candidates[i];
                    if (candidate.CandidateId.Equals(candidate1.CandidateId)
                        && type.Equals("Add"))
                        result = "ID Exist!!\n";
                }
            }
            if ((result.Equals("ID exist!!\n") && type.Equals("Update")) ||
                (result.Equals("ID exist!!\n") && type.Equals("Remove")))
                result = "ID Not Exist!!";
            if (candidate.Fullname.Equals(""))
                result = result + "FullName null!!";
            if (result.Equals("")) result = "Ready to " + type;
            return result;
        }

        //-----------------------------Button----------------------------

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CandidateDisplay selectedDisplay = dtgCandidateProfile.SelectedItem as CandidateDisplay;

            if (selectedDisplay != null)
            {
                CandidateProfile profile = candidateProfileService.GetCandidateProfiles().FirstOrDefault(p => p.CandidateId == selectedDisplay.CandidateId);

                if (profile != null)
                {
                    CandidateIdTxt.Text = profile.CandidateId;
                    FullnameTxt.Text = profile.Fullname;
                    ImageURLTxt.Text = profile.ProfileUrl;
                    TxtDescription.Text = profile.ProfileShortDescription;
                    birthDateTxt.SelectedDate = profile.Birthday;
                    PostingIdCbb.Text = selectedDisplay.PostingDisplay.ToString();
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = GetDataFromForm();
            string message = ValidateData(candidate, "Add");
            if (!message.Equals("Ready to Add"))
            {
                MessageBox.Show(message);
            }

            else if (message.Equals("Ready to Add") || candidateProfileService.AddCandidateProfile(candidate))
            {
                candidateProfileService.AddCandidateProfile(candidate);
                MessageBox.Show("Added !!");
                ClearData();
                RefreshData();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = GetDataFromForm();
            string message = ValidateData(candidate, "Update");
            if (!message.Equals("Ready to Update"))
            {
                MessageBox.Show(message);
            }

            else if (message.Equals("Ready to Update") || candidateProfileService.UpdateCandidateProfile(candidate))
            {
                candidateProfileService.UpdateCandidateProfile(candidate);
                MessageBox.Show("Updated !!");
                ClearData();
                RefreshData();
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = GetDataFromForm();
            string message = ValidateData(candidate, "Remove");
            if (!message.Equals("Ready to Remove"))
            {
                MessageBox.Show(message);
            }

            else if (message.Equals("Ready to Remove") || candidateProfileService.DeleteCandidateProfile(candidate))
            {
                candidateProfileService.DeleteCandidateProfile(candidate);
                MessageBox.Show("Deleted !!");
                ClearData();
                RefreshData();
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            RefreshData();
        }
    }
}
