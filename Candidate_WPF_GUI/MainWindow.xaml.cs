using Candidate_BusinessObject;
using Candidate_Service;
using System.Windows;

namespace Candidate_WPF_GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IHrAccountService _hrAccountService;
		public MainWindow()
		{
			InitializeComponent();
			_hrAccountService = new HrAccountService();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			Hraccount? hraccount = _hrAccountService.GetAccountByEmail(txtEmail.Text);
			if (hraccount != null && txtPassword.Password.Equals(hraccount.Password))
			{
				this.Hide();
				CandidateProfileWindow candidateProfileWindow = new CandidateProfileWindow(hraccount.MemberRole);
				candidateProfileWindow.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Wrong email");
			}

		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}