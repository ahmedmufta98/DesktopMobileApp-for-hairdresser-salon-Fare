using eHairdresserSalonFare.Model.Requests.HairdresserSalon;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.HairdresserSalon
{
    public partial class frmHairdresserSalonDetails : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("hairdressersalons");
        private int _id;
        private HairdresserSalonUpdateRequest request = new HairdresserSalonUpdateRequest();
        public frmHairdresserSalonDetails(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            request.Salon = txtName.Text;
            request.Phone = txtPhone.Text;
            request.Email = txtEmail.Text;
            request.Address = txtAddress.Text;

            Model.HairdresserSalon updatedData = await _apiService.Update<Model.HairdresserSalon>(_id, request);
            if (updatedData != null)
            {
                MessageBox.Show("Hairdresser salon data successfully updated!");
            }
        }

        private void BtnAddLogo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                byte[] file = File.ReadAllBytes(fileName);
                request.Logo = file;
                txtLogo.Text = fileName;

                Image image = Image.FromFile(fileName);
                picBox.Image = image;
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private async void FrmHairdresserSalonDetails_Load(object sender, EventArgs e)
        {
            Model.HairdresserSalon request = await _apiService.GetById<Model.HairdresserSalon>(_id);

            txtName.Text = request.Salon;
            txtEmail.Text = request.Email;
            txtPhone.Text = request.Phone;
            txtAddress.Text = request.Address;
           
            if (request.Logo.Count() > 0)
            {
                picBox.Image = ByteToImage(request.Logo);
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }  
}
