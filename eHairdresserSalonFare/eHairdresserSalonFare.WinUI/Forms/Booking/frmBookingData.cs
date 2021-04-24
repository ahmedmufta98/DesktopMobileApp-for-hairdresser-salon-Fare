using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Booking
{
    public partial class frmBookingData : Form
    {
        private BaseAPIService _hairdresserApiService = new BaseAPIService("hairdressers");
        private int? hairdresserId = null;
        public frmBookingData()
        {
            InitializeComponent();
        }

        private async Task LoadHairdressers()
        {
            List<Model.Hairdresser> hairdressers = await _hairdresserApiService.GetAll<List<Model.Hairdresser>>(null);
            hairdressers.Insert(0, new Model.Hairdresser());
            cmbHairdresser.DataSource = hairdressers;
            cmbHairdresser.DisplayMember = "Fullname";
            cmbHairdresser.ValueMember = "Id";
        }

        private async void FrmBookingData_Load(object sender, EventArgs e)
        {
            await LoadHairdressers();

            string query = $@" SELECT U.FirstName+' '+U.LastName AS Client, H.FirstName+' '+H.LastName AS Hairdresser, HS.HairstyleName AS Hairstyle,
                               CAST(B.StartDate AS date) AS BookingDate
                               FROM Bookings AS B
                               JOIN Hairdressers AS H ON B.HairdresserId=H.Id
                               JOIN Hairstyles AS HS ON B.HairstyleId=HS.Id
                               JOIN Users AS U ON B.UserId=U.Id
                               ORDER BY 1";

            SqlConnection conn = new SqlConnection("Server =localhost,1401; Database = eHairdresserSalonFareDb;User=sa;Password=QWElkj132!;");
            conn.Open();

            SqlCommand sqlCmd = new SqlCommand(query, conn);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgvData.ReadOnly = true;
            dgvData.DataSource = dataSet.Tables[0];

            conn.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var objId = cmbHairdresser.SelectedValue;
            if (int.TryParse(objId.ToString(), out int id))
            {
                hairdresserId = id;
            }

            if (hairdresserId != null && hairdresserId != 0)
            {
                string query = @"SELECT U.FirstName+' '+U.LastName AS Client, H.FirstName+' '+H.LastName AS Hairdresser, HS.HairstyleName AS Hairstyle,
                               CAST(B.StartDate AS date) AS BookingDate
                               FROM Bookings AS B
                               JOIN Hairdressers AS H ON B.HairdresserId=H.Id
                               JOIN Hairstyles AS HS ON B.HairstyleId=HS.Id
                               JOIN Users AS U ON B.UserId=U.Id
                               WHERE B.HairdresserId=@hairdresserId
                               ORDER BY 1";

                SqlConnection conn = new SqlConnection("Server =localhost,1401; Database = eHairdresserSalonFareDb;User=sa;Password=QWElkj132!;");
                conn.Open();

                SqlCommand sqlCmd = new SqlCommand(query, conn);
                sqlCmd.Parameters.AddWithValue("@HairdresserId", hairdresserId);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dgvData.ReadOnly = true;
                dgvData.DataSource = dataSet.Tables[0];

                conn.Close();
            }
            else
            {
                string query = @"SELECT U.FirstName+' '+U.LastName AS Client, H.FirstName+' '+H.LastName AS Hairdresser, HS.HairstyleName AS Hairstyle,
                               CAST(B.StartDate AS date) AS BookingDate
                               FROM Bookings AS B
                               JOIN Hairdressers AS H ON B.HairdresserId=H.Id
                               JOIN Hairstyles AS HS ON B.HairstyleId=HS.Id
                               JOIN Users AS U ON B.UserId=U.Id
                               ORDER BY 1";

                SqlConnection conn = new SqlConnection("Server=localhost,1401; Database = eHairdresserSalonFareDb;User=sa;Password=QWElkj132!;");
                conn.Open();

                SqlCommand sqlCmd = new SqlCommand(query, conn);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dgvData.ReadOnly = true;
                dgvData.DataSource = dataSet.Tables[0];

                conn.Close();
            }
        }
    }
}
