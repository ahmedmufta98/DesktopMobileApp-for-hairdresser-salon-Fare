using eHairdresserSalonFare.Model.Requests.Associate;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Associate
{
    public partial class frmAssociateData : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("associates");

        public frmAssociateData()
        {
            InitializeComponent();
        }

        private async void FrmAssociateData_Load(object sender, EventArgs e)
        {
            dgvAssociates.AutoGenerateColumns = false;
            dgvAssociates.DataSource = await _apiService.GetAll<List<Model.Associate>>(null);
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            AssociateSearchRequest searchRequest = new AssociateSearchRequest
            {
                AssociateName = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            List<Model.Associate> associates = await _apiService.GetAll<List<Model.Associate>>(searchRequest);

            if (associates.Count == 0)
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dgvAssociates.AutoGenerateColumns = false;
                dgvAssociates.DataSource = associates;
            }
        }
    }
}
