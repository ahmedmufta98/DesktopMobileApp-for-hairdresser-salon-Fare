using ClosedXML.Excel;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Reports
{
    public partial class rptHairdresserMostEarnedMoney : Form
    {
        private BaseAPIService _hairdresserApiService = new BaseAPIService("hairdressers");
        private int? hairdresserId = null;

        public rptHairdresserMostEarnedMoney()
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

        private async void RptHairdresserMostEarnedMoney_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            await LoadHairdressers();

            string query = @"SELECT HR.FirstName + ' ' + HR.LastName AS Hairdresser, COUNT(B.HairstyleId) AS NumberOfServices, SUM(HS.Price) AS EarnedMoney
                             FROM dbo.Bookings AS B
                             JOIN dbo.Hairdressers AS HR ON B.HairdresserId=HR.Id
                             JOIN dbo.Hairstyles AS HS ON B.HairstyleId=HS.Id
                             GROUP BY HR.FirstName + ' ' + HR.LastName
                             ORDER BY 3 DESC";

            SqlConnection conn = new SqlConnection("Server =.; Database = eHairdresserSalonFare; Trusted_Connection = true;");
            conn.Open();

            SqlCommand sqlCmd = new SqlCommand(query, conn);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgvData.ReadOnly = true;
            dgvData.DataSource = dataSet.Tables[0];
 
            conn.Close();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                if (hairdresserId == null || hairdresserId==0)
                                {
                                    string query = @"SELECT HR.FirstName + ' ' + HR.LastName AS Hairdresser, COUNT(B.HairstyleId) AS NumberOfServices, SUM(HS.Price) AS EarnedMoney
                                                 FROM dbo.Bookings AS B
                                                 JOIN dbo.Hairdressers AS HR ON B.HairdresserId=HR.Id
                                                 JOIN dbo.Hairstyles AS HS ON B.HairstyleId=HS.Id
                                                 GROUP BY HR.FirstName + ' ' + HR.LastName
                                                 ORDER BY 3 DESC";

                                    SqlConnection conn = new SqlConnection("Server =.; Database = eHairdresserSalonFare; Trusted_Connection = true;");
                                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                                    DataSet dataSet = new DataSet();
                                    dataAdapter.Fill(dataSet);
                                    workbook.Worksheets.Add(dataSet.Tables[0]);
                                    workbook.SaveAs(saveFileDialog.FileName);

                                    MessageBox.Show("You have successfuly exported your data to excel file!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    string query = @"SELECT HR.FirstName + ' ' + HR.LastName AS Hairdresser, COUNT(B.HairstyleId) AS NumberOfServices, SUM(HS.Price) AS EarnedMoney
                                                     FROM dbo.Bookings AS B
                                                     JOIN dbo.Hairdressers AS HR ON B.HairdresserId=HR.Id
                                                     JOIN dbo.Hairstyles AS HS ON B.HairstyleId=HS.Id
                                                     WHERE B.HairdresserId=@hairdresserId
                                                     GROUP BY HR.FirstName + ' ' + HR.LastName
                                                     ORDER BY 1 ASC";

                                    SqlConnection conn = new SqlConnection("Server =.; Database = eHairdresserSalonFare; Trusted_Connection = true;");
                                    conn.Open();

                                    SqlCommand sqlCmd = new SqlCommand(query, conn);
                                    sqlCmd.Parameters.AddWithValue("@HairdresserId", hairdresserId);

                                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                                    DataSet dataSet = new DataSet();
                                    dataAdapter.Fill(dataSet);
                                    workbook.Worksheets.Add(dataSet.Tables[0]);
                                    workbook.SaveAs(saveFileDialog.FileName);

                                    MessageBox.Show("You have successfuly exported your data to excel file!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                } 
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            var objId = cmbHairdresser.SelectedValue;
            if (int.TryParse(objId.ToString(), out int id))
            {
                hairdresserId = id;
            }

            if(hairdresserId!=null && hairdresserId != 0)
            {
                string query = @"SELECT HR.FirstName + ' ' + HR.LastName AS Hairdresser, COUNT(B.HairstyleId) AS NumberOfServices, SUM(HS.Price) AS EarnedMoney
                             FROM dbo.Bookings AS B
                             JOIN dbo.Hairdressers AS HR ON B.HairdresserId=HR.Id
                             JOIN dbo.Hairstyles AS HS ON B.HairstyleId=HS.Id
                             WHERE B.HairdresserId=@hairdresserId
                             GROUP BY HR.FirstName + ' ' + HR.LastName
                             ORDER BY 1 ASC";

                SqlConnection conn = new SqlConnection("Server =.; Database = eHairdresserSalonFare; Trusted_Connection = true;");
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
                string query = @"SELECT HR.FirstName + ' ' + HR.LastName AS Hairdresser, COUNT(B.HairstyleId) AS NumberOfServices, SUM(HS.Price) AS EarnedMoney
                             FROM dbo.Bookings AS B
                             JOIN dbo.Hairdressers AS HR ON B.HairdresserId=HR.Id
                             JOIN dbo.Hairstyles AS HS ON B.HairstyleId=HS.Id
                             GROUP BY HR.FirstName + ' ' + HR.LastName
                             ORDER BY 1 ASC";

                SqlConnection conn = new SqlConnection("Server =.; Database = eHairdresserSalonFare; Trusted_Connection = true;");
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
