using Candidate_BussinessObjects;
using Candidate_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Candidate_WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHRAccountService accountService;
        public MainWindow()
        {
            InitializeComponent();
            accountService = new HRAccountService();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = accountService.GetHraccountByEmail(TxtEmail.Text);
            if ((hraccount != null)
                && TxtEmail.Text.Equals(hraccount.Email)
                && TxtPassword.Password.Equals(hraccount.Password))
            {
                MessageBox.Show("Welcome " + hraccount.FullName);
                SelectionWindow choseWindow = new SelectionWindow(hraccount.MemberRole);
                choseWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Invalid Login!!!");
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}