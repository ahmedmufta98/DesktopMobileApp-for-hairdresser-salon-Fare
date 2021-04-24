using eHairdresserSalonFare.Model.Requests.Payment;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Payment
{
    public partial class frmPaymentData : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("payments");
        private UserAPIService _clientApiService = new UserAPIService("users");
        private int? userId = null;

        public frmPaymentData()
        {
            InitializeComponent();
        }

        private async Task LoadClients()
        {
            List<Model.User> clients = await _clientApiService.GetAll<List<Model.User>>(null);
            clients.Insert(0, new Model.User());
            cmbClient.DataSource = clients;
            cmbClient.DisplayMember = "Fullname";
            cmbClient.ValueMember = "Id";
        }

        private async void FrmPaymentData_Load(object sender, EventArgs e)
        {
            await LoadClients();
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.DataSource = await _apiService.GetAll<List<Model.Payment>>(null);
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            var objId = cmbClient.SelectedValue;
            if (int.TryParse(objId.ToString(), out int id))
            {
                userId = id;
            }

            PaymentSearchRequest request = new PaymentSearchRequest
            {
                UserId = userId
            };

            dgvPayments.DataSource = await _apiService.GetAll<List<Model.Payment>>(request);
        }
    }
}
