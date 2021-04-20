using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.HairdresserSalon
{
    public partial class frmHairdresserSalonData : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("hairdressersalons");

        public frmHairdresserSalonData()
        {
            InitializeComponent();
        }

        private async void FrmHairdresserSalonData_Load(object sender, EventArgs e)
        {
            dgvHairdresserSalon.AutoGenerateColumns = false;
            dgvHairdresserSalon.DataSource = await _apiService.GetAll<List<Model.HairdresserSalon>>(null);
        }

        private void DgvHairdresserSalon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvHairdresserSalon.SelectedRows[0].Cells[0].Value;
            frmHairdresserSalonDetails frm = new frmHairdresserSalonDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
