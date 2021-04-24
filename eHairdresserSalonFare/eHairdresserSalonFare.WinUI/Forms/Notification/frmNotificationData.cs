using eHairdresserSalonFare.Model.Requests.Notification;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Notification
{
    public partial class frmNotificationData : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("notifications");

        public frmNotificationData()
        {
            InitializeComponent();
        }

        private async void FrmNotificationData_Load(object sender, EventArgs e)
        {
            dgvNotifications.AutoGenerateColumns = false;
            dgvNotifications.DataSource = await _apiService.GetAll<List<Model.Notification>>(null);
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            NotificationSearchRequest searchRequest = new NotificationSearchRequest()
            {
                Title = txtTitle.Text
            };
            
            List<Model.Notification> notifications = await _apiService.GetAll<List<Model.Notification>>(searchRequest);

            if (notifications.Count == 0)
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dgvNotifications.AutoGenerateColumns = false;
                dgvNotifications.DataSource = notifications;
            }
        }
    }
}
