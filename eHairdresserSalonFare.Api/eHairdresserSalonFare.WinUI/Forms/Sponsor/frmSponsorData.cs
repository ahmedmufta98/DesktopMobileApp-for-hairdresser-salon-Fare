using eHairdresserSalonFare.Model.Requests.Sponsor;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Sponsor
{
    public partial class frmSponsorData : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("sponsors");

        public frmSponsorData()
        {
            InitializeComponent();
        }

        private async void FrmSponsorData_Load(object sender, EventArgs e)
        {
            dgvSponsors.AutoGenerateColumns = false;
            dgvSponsors.DataSource = await _apiService.GetAll<List<Model.Sponsor>>(null);
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            SponsorSearchRequest searchRequest = new SponsorSearchRequest
            {
                SponsorName = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            List<Model.Sponsor> sponsors = await _apiService.GetAll<List<Model.Sponsor>>(searchRequest);

            if (sponsors.Count == 0)
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dgvSponsors.AutoGenerateColumns = false;
                dgvSponsors.DataSource = sponsors;
            }
        }
    }
}
