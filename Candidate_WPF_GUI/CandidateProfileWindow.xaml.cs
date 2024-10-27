using Candidate_BusinessObject;
using Candidate_Service;
using System.Windows;
using System.Windows.Controls;

namespace Candidate_WPF_GUI
{
	/// <summary>
	/// Interaction logic for CandidateProfile.xaml
	/// </summary>
	public partial class CandidateProfileWindow : Window
	{
		private readonly ICandidateProfileService candidateProfileService;
		private IJobPostingService jobPostingService;
		private int? roleID = 0;
		public CandidateProfileWindow()
		{
			InitializeComponent();
			candidateProfileService = new CandidateProfileService();
			jobPostingService = new JobPostingService();
		}

		public CandidateProfileWindow(int? roleID)
		{
			InitializeComponent();
			candidateProfileService = new CandidateProfileService();
			jobPostingService = new JobPostingService();
			this.roleID = roleID;
			switch (roleID)
			{
				case 1:
					break;
				case 2:
					btnAdd.IsEnabled = false;
					btnDelete.IsEnabled = false;
					btnUpdate.IsEnabled = false;
					break;
				default:
					break;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.loadData();
		}

		private void loadData()
		{
			this.dtgCandidateProfile.ItemsSource = null;
			this.dtgCandidateProfile.ItemsSource = candidateProfileService.GetCandidateProfiles().Select(c => new
			{
				c.CandidateId,
				c.Fullname,
				c.Birthday,
				c.ProfileShortDescription,
				c.ProfileUrl,
				c.PostingId,
				c.Posting.JobPostingTitle
			});
			this.cbxJobPosting.ItemsSource = jobPostingService.GetJobPostings();
			this.cbxJobPosting.DisplayMemberPath = "JobPostingTitle";
			this.cbxJobPosting.SelectedValuePath = "PostingId";
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			CandidateProfile candidateProfile = new CandidateProfile()
			{
				CandidateId = txtCandidateID.Text,
				Fullname = txtFullname.Text,
				Birthday = dtpBirthday.SelectedDate,
				ProfileShortDescription = txtDescription.Text,
				ProfileUrl = txtImageUrl.Text,
				PostingId = cbxJobPosting.SelectedValue.ToString()
			};

			if (candidateProfileService.AddCandidateProfile(candidateProfile))
			{
				this.loadData();
				this.ResetForm();
				MessageBox.Show("Add Successfully");
			}
			else
			{
				MessageBox.Show("Add failed");
			}
		}

		private void dtgCandidateProfile_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			DataGrid dg = sender as DataGrid;
			DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
			if (row != null)
			{
				DataGridCell RowColumn = dg.Columns[0].GetCellContent(row).Parent as DataGridCell;
				string id = ((TextBlock)RowColumn.Content).Text;
				CandidateProfile candidateProfile = candidateProfileService.GetCandidateProfile(id);
				if (candidateProfile != null)
				{
					txtCandidateID.Text = candidateProfile.CandidateId;
					txtFullname.Text = candidateProfile.Fullname;
					dtpBirthday.SelectedDate = candidateProfile.Birthday;
					txtDescription.Text = candidateProfile.ProfileShortDescription;
					txtImageUrl.Text = candidateProfile.ProfileUrl;
					cbxJobPosting.SelectedValue = candidateProfile.PostingId;
				}
			}
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			CandidateProfile candidateProfile = new CandidateProfile()
			{
				CandidateId = txtCandidateID.Text,
				Fullname = txtFullname.Text,
				Birthday = dtpBirthday.SelectedDate,
				ProfileShortDescription = txtDescription.Text,
				ProfileUrl = txtImageUrl.Text,
				PostingId = cbxJobPosting.SelectedValue.ToString()
			};
			if (candidateProfileService.UpdateCandidateProfile(candidateProfile))
			{
				this.loadData();
				this.ResetForm();
				MessageBox.Show("Update Successfully");
			}
			else
			{
				MessageBox.Show("Update failed");
			}
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			CandidateProfile candidateProfile = new CandidateProfile()
			{
				CandidateId = txtCandidateID.Text,
				Fullname = txtFullname.Text,
				Birthday = dtpBirthday.SelectedDate,
				ProfileShortDescription = txtDescription.Text,
				ProfileUrl = txtImageUrl.Text,
				PostingId = cbxJobPosting.SelectedValue.ToString()
			};
			if (candidateProfileService.DeleteCandidateProfile(candidateProfile))
			{
				this.loadData();
				this.ResetForm();
				MessageBox.Show("Delete Successfully");
			}
			else
			{
				MessageBox.Show("Delete failed");
			}
		}

		private void ResetForm()
		{
			txtCandidateID.Text = string.Empty;
			txtFullname.Text = string.Empty;
			dtpBirthday.SelectedDate = null;
			txtDescription.Text = string.Empty;
			txtImageUrl.Text = string.Empty;
			cbxJobPosting.SelectedIndex = 0;
		}

		private void btnReset_Click(object sender, RoutedEventArgs e)
		{
			this.ResetForm();
		}
	}
}
