using eHairdresserSalonFare.Model.Requests.Notification;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Notification
{
    public partial class frmNotificationAdd : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("notifications");
        private int? _id = null;
        private NotificationUpsertRequest request = new NotificationUpsertRequest();

        public frmNotificationAdd(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void FrmNotificationAdd_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                Model.Notification request = await _apiService.GetById<Model.Notification>(_id);

                txtText.Text = request.Text;
                txtTitle.Text = request.Title;
                dtPic.Value = request.NotificationDate;
            }
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            request.Text = txtText.Text;
            request.Title = txtTitle.Text;
            request.NotificationDate = dtPic.Value;
            request.HairdresserSalonId = 1;

            if (_id.HasValue)
            {
                await _apiService.Update<Model.Notification>(_id, request);
                MessageBox.Show("Notification successfully updated!");
                this.Hide();
            }
            else
            {
                await _apiService.Insert<Model.Notification>(request);
                MessageBox.Show("New notification successfully added!");
                this.Hide();
            }
        }

        private void txtText_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtText.Text))
            {
                errorProvider.SetError(txtText, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtText, null);
            }
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTitle, null);
            }
        }

        private void dtPic_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dtPic.Value==null)
            {
                errorProvider.SetError(dtPic, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtPic, null);
            }
        }
    }
}
