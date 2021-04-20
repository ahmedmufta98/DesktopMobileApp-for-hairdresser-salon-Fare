using eHairdresserSalonFare.Model.Requests.Hairdresser;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Hairdresser
{
    public partial class frmHairdresserAdd : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("hairdressers");
        private BaseAPIService _hairstyleApiService = new BaseAPIService("hairstyles");
        private HairdresserHairstyleAPIService _hairdresserHairstyleApiService = new HairdresserHairstyleAPIService();
        private int? _id = null;
        private HairdresserUpsertRequest request = new HairdresserUpsertRequest();


        public frmHairdresserAdd(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.FirstName = txtFirstName.Text;
                request.LastName = txtLastName.Text;
                request.Email = txtEmail.Text;
                request.Phone = txtPhone.Text;
                request.Salary = int.Parse(txtSalary.Text);
                request.BirthDate = dtPicBirthDate.Value;
                request.PersonalIdentificationNumber = txtJMBG.Text;
                request.Available = chBoxAvailable.Checked;
                request.HairdresserSalonId = 1;

                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Hairdresser>(_id, request);
                    MessageBox.Show("Hairdresser successfully updated!");
                    this.Hide();
                }
                else
                {
                    Model.Hairdresser newHairdresser = await _apiService.Insert<Model.Hairdresser>(request);
                    List<int> hairstyleIds = new List<int>();

                    if (checkedListBoxHairstyles.CheckedItems.Count > 0)
                    {
                        foreach(var hairstyle in checkedListBoxHairstyles.CheckedItems)
                        {
                            Model.Hairstyle selectedHairstyle = hairstyle as Model.Hairstyle;
                            hairstyleIds.Add(selectedHairstyle.Id);
                        }
                        await _hairdresserHairstyleApiService.Insert(newHairdresser.Id, hairstyleIds);
                        MessageBox.Show("New hairdresser successfully added!");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You must to pick hairstyles for hairdresser!");
                    }
                }
            }
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                byte[] file = File.ReadAllBytes(fileName);
                request.Image = file;
                txtImgPath.Text = fileName;

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

        private async Task LoadHairstyles()
        {
            List<Model.Hairstyle> hairstyles = await _hairstyleApiService.GetAll<List<Model.Hairstyle>>(null);
            checkedListBoxHairstyles.DataSource = hairstyles;
            checkedListBoxHairstyles.DisplayMember = "HairstyleName";
            checkedListBoxHairstyles.ValueMember = "Id";
        }

        private async void FrmHairdresserAdd_Load(object sender, EventArgs e)
        {
            await LoadHairstyles();

            if (_id.HasValue)
            {
                Model.Hairdresser request = await _apiService.GetById<Model.Hairdresser>(_id);

                txtFirstName.Text = request.FirstName;
                txtLastName.Text = request.LastName;
                txtEmail.Text = request.Email;
                txtPhone.Text = request.Phone;
                txtJMBG.Text = request.PersonalIdentificationNumber;
                txtSalary.Text = request.Salary.ToString();
                dtPicBirthDate.Value = request.BirthDate;
                chBoxAvailable.Checked = request.Available;

                if (request.Image.Count() > 0)
                {
                    picBox.Image = ByteToImage(request.Image);
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    request.Image = File.ReadAllBytes("C:\\Users\\ZZO5\\Desktop\\Seminarski rad\\proba\\eHairdresserSalonFare.Api\\eHairdresserSalonFare.WinUI\\Images\\default-pic.png");
                    Image image = Image.FromFile("C:\\Users\\ZZO5\\Desktop\\Seminarski rad\\proba\\eHairdresserSalonFare.Api\\eHairdresserSalonFare.WinUI\\Images\\default-pic.png");
                    picBox.Image = image;
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                request.Image = File.ReadAllBytes("C:\\Users\\ZZO5\\Desktop\\Seminarski rad\\proba\\eHairdresserSalonFare.Api\\eHairdresserSalonFare.WinUI\\Images\\default-pic.png");
                Image image = Image.FromFile("C:\\Users\\ZZO5\\Desktop\\Seminarski rad\\proba\\eHairdresserSalonFare.Api\\eHairdresserSalonFare.WinUI\\Images\\default-pic.png");
                picBox.Image = image;
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
            }
        }

        private void dtPicBirthDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dtPicBirthDate.Value==null)
            {
                errorProvider.SetError(dtPicBirthDate, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtPicBirthDate, null);
            }
        }

        private void txtJMBG_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                errorProvider.SetError(txtJMBG, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtJMBG, null);
            }
        }
    }
}
