using eHairdresserSalonFare.Model.Requests.User;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Client
{
    public partial class frmClientsData : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("users");

        public frmClientsData()
        {
            InitializeComponent();
        }

        private async void FrmClientsData_Load(object sender, EventArgs e)
        {
            dgvClients.AutoGenerateColumns = false;
            dgvClients.DataSource = await _apiService.GetAll<List<Model.User>>(null);
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            UserSearchRequest searchRequest = new UserSearchRequest
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtMobile.Text
            };

            List<Model.User> clients = await _apiService.GetAll<List<Model.User>>(searchRequest);

            if (clients.Count == 0)
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dgvClients.AutoGenerateColumns = false;
                dgvClients.DataSource = clients;
            }
        }
    }
}
