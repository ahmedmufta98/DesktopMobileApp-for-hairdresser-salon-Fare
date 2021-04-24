using eHairdresserSalonFare.Model.Requests.Hairstyle;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Hairstyle
{
    public partial class frmHairstyleData : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("hairstyles");
        public frmHairstyleData()
        {
            InitializeComponent();
        }


        private async void FrmHairstyleData_Load(object sender, EventArgs e)
        {
            dgvHairstyles.AutoGenerateColumns = false;
            dgvHairstyles.DataSource = await _apiService.GetAll<List<Model.Hairstyle>>(null);
        }

        private void DgvHairstyles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvHairstyles.SelectedRows[0].Cells[0].Value;
            frmHairstyleAdd frm = new frmHairstyleAdd(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            HairstyleSearchRequest searchRequest = new HairstyleSearchRequest
            {
                HairstyleName=txtName.Text
            };

            List<Model.Hairstyle> hairstyles = await _apiService.GetAll<List<Model.Hairstyle>>(searchRequest);

            if (hairstyles.Count == 0)
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dgvHairstyles.AutoGenerateColumns = false;
                dgvHairstyles.DataSource = hairstyles;
            }
        }
    }
}
