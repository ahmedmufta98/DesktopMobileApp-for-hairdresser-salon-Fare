using eHairdresserSalonFare.Model.Requests.Hairstyle;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Hairstyle
{
    public partial class frmHairstyleAdd : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("hairstyles");
        private int? _id = null;
        private HairstyleUpsertRequest request = new HairstyleUpsertRequest();

        public frmHairstyleAdd(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.HairstyleName = txtName.Text;
                request.Price = float.Parse(txtPrice.Text);
                request.DurationOfProduction = int.Parse(txtDuration.Text);
                request.Description = txtDescription.Text;

                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Hairstyle>(_id, request);
                    MessageBox.Show("Hairstyle successfully updated!");
                    this.Hide();
                }
                else
                {
                    await _apiService.Insert<Model.Hairstyle>(request);
                    MessageBox.Show("New hairstyle successfully added!");
                    this.Hide();
                }
            }
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Image = file;
                txtImagePath.Text = fileName;

                Image image = Image.FromFile(fileName);
                picBoxImg.Image = image;
                picBoxImg.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private async void FrmHairstyleAdd_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                Model.Hairstyle request = await _apiService.GetById<Model.Hairstyle>(_id);

                txtName.Text = request.HairstyleName;
                txtPrice.Text = request.Price.ToString();
                txtDescription.Text = request.Description;
                txtDuration.Text = request.DurationOfProduction.ToString();

                if (request.Image.Count() > 0)
                {
                    picBoxImg.Image = ByteToImage(request.Image);
                    picBoxImg.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    request.Image = File.ReadAllBytes("C:\\Users\\ZZO5\\Desktop\\Seminarski rad\\proba\\eHairdresserSalonFare.Api\\eHairdresserSalonFare.WinUI\\Images\\default-hairstyle.jpg");
                    Image image = Image.FromFile("C:\\Users\\ZZO5\\Desktop\\Seminarski rad\\proba\\eHairdresserSalonFare.Api\\eHairdresserSalonFare.WinUI\\Images\\default-hairstyle.jpg");
                    picBoxImg.Image = image;
                    picBoxImg.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                request.Image = File.ReadAllBytes("C:\\Users\\ZZO5\\Desktop\\Seminarski rad\\proba\\eHairdresserSalonFare.Api\\eHairdresserSalonFare.WinUI\\Images\\default-hairstyle.jpg");
                Image image = Image.FromFile("C:\\Users\\ZZO5\\Desktop\\Seminarski rad\\proba\\eHairdresserSalonFare.Api\\eHairdresserSalonFare.WinUI\\Images\\default-hairstyle.jpg");
                picBoxImg.Image = image;
                picBoxImg.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }
        }

        private void txtPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                errorProvider.SetError(txtPrice, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrice, null);
            }
        }
    }
}
