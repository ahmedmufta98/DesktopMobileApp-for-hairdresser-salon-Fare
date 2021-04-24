using eHairdresserSalonFare.Model.Requests.Hairdresser;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Hairdresser
{
    public partial class frmHairdresserData : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("hairdressers");

        public frmHairdresserData()
        {
            InitializeComponent();
        }

        private async void FrmHairdresserData_Load(object sender, EventArgs e)
        {
            dgvHairdressers.AutoGenerateColumns = false;
            dgvHairdressers.DataSource = await _apiService.GetAll<List<Model.Hairdresser>>(null); ;
        }

        private void DgvHairdressers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvHairdressers.SelectedRows[0].Cells[0].Value;
            frmHairdresserAdd frm = new frmHairdresserAdd(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            HairdresserSearchRequest searchRequest = new HairdresserSearchRequest
            {
                FirstName=txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtMobile.Text,
                Email = txtEmail.Text
            };

            List<Model.Hairdresser> hairdressers = await _apiService.GetAll<List<Model.Hairdresser>>(searchRequest);

            if (hairdressers.Count == 0)
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dgvHairdressers.AutoGenerateColumns = false;
                dgvHairdressers.DataSource = hairdressers;
            }
        }
    }
}
