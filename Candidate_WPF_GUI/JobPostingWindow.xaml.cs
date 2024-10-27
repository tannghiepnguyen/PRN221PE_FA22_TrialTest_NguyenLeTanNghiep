using Candidate_BusinessObject;
using Candidate_Service;
using System.Windows;
using System.Windows.Controls;

namespace Candidate_WPF_GUI
{
	/// <summary>
	/// Interaction logic for JobPostingWindow.xaml
	/// </summary>
	public partial class JobPostingWindow : Window
	{
		private IJobPostingService _jobPostingService;
		public JobPostingWindow()
		{
			InitializeComponent();
			_jobPostingService = new JobPostingService();
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void jobPostWindow_Loaded(object sender, RoutedEventArgs e)
		{
			dtgJobPosting.ItemsSource = _jobPostingService.GetJobPostings();
		}

		private void loadData()
		{
			dtgJobPosting.ItemsSource = null;
			dtgJobPosting.ItemsSource = _jobPostingService.GetJobPostings().Select(c => new
			{
				c.PostingId,
				c.JobPostingTitle,
				c.Description,
				c.PostedDate
			});
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			JobPosting job = new JobPosting()
			{
				PostingId = txtPostID.Text,
				JobPostingTitle = txtTitle.Text,
				Description = txtDescription.Text,
				PostedDate = dtpPostDate.SelectedDate
			};
			if (_jobPostingService.AddJobPosting(job))
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

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			JobPosting job = new JobPosting()
			{
				PostingId = txtPostID.Text,
				JobPostingTitle = txtTitle.Text,
				Description = txtDescription.Text,
				PostedDate = dtpPostDate.SelectedDate
			};
			if (_jobPostingService.UpdateJobPostings(job))
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
			JobPosting job = new JobPosting()
			{
				PostingId = txtPostID.Text,
				JobPostingTitle = txtTitle.Text,
				Description = txtDescription.Text,
				PostedDate = dtpPostDate.SelectedDate
			};
			if (_jobPostingService.DeleteJobPosting(job))
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

		private void dtgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DataGrid dg = sender as DataGrid;
			DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
			if (row != null)
			{
				DataGridCell RowColumn = dg.Columns[0].GetCellContent(row).Parent as DataGridCell;
				string id = ((TextBlock)RowColumn.Content).Text;
				JobPosting job = _jobPostingService.GetJobPosting(id);
				if (job != null)
				{
					txtPostID.Text = job.PostingId;
					txtTitle.Text = job.JobPostingTitle;
					txtDescription.Text = job.Description;
					dtpPostDate.Text = job.PostedDate.ToString();
				}
			}
		}

		private void ResetForm()
		{
			txtPostID.Text = string.Empty;
			txtTitle.Text = string.Empty;
			txtDescription.Text = string.Empty;
			dtpPostDate.SelectedDate = null;
		}

		private void btnReset_Click(object sender, RoutedEventArgs e)
		{
			this.ResetForm();
		}
	}
}
