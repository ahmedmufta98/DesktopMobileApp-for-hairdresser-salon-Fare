using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Reports
{
    public partial class rptMostSalesService : Form
    {
        public rptMostSalesService()
        {
            InitializeComponent();
        }

        private void RptMostSalesService_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;

            string query = $@"SELECT H.HairstyleName AS Hairstyle, COUNT(B.HairstyleId) AS NumberOfSalesHairstyles, SUM(H.Price) AS Price 
                              FROM DBO.Bookings AS B
                              JOIN DBO.Hairstyles AS H ON B.HairstyleId = H.Id
                              GROUP BY H.HairstyleName
                              ORDER BY 2 ASC";

            SqlConnection conn = new SqlConnection("Server =.; Database = eHairdresserSalonFare; Trusted_Connection = true;");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgvData.ReadOnly = true;
            dgvData.DataSource = dataSet.Tables[0];
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                using(SaveFileDialog saveFileDialog=new SaveFileDialog() { Filter="Excel Workbook|*.xlsx" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using(XLWorkbook workbook=new XLWorkbook())
                            {
                                string query = $@"SELECT H.HairstyleName AS Hairstyle, COUNT(B.HairstyleId) AS NumberOfSalesHairstyles, SUM(H.Price) AS Price 
                                                  FROM DBO.Bookings AS B
                                                  JOIN DBO.Hairstyles AS H ON B.HairstyleId = H.Id
                                                  GROUP BY H.HairstyleName
                                                  ORDER BY 2 ASC";

                                SqlConnection conn = new SqlConnection("Server =.; Database = eHairdresserSalonFare; Trusted_Connection = true;");
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                                DataSet ds = new DataSet();
                                dataAdapter.Fill(ds);
                                workbook.Worksheets.Add(ds.Tables[0]);
                                workbook.SaveAs(saveFileDialog.FileName);

                                MessageBox.Show("You have successfuly exported your data to excel file!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
