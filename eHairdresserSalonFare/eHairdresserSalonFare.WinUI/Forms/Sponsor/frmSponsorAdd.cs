using eHairdresserSalonFare.Model.Requests.Sponsor;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Sponsor
{
    public partial class frmSponsorAdd : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("sponsors");
        private int? _id = null;
        private SponsorUpsertRequest request = new SponsorUpsertRequest();

        public frmSponsorAdd(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }

        private void BtnAddLogo_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Logo = file;
                txtLogo.Text = fileName;

                Image image = Image.FromFile(fileName);
                picBoxLogo.Image = image;
            }
        }

        private async void FrmSponsorAdd_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                Model.Sponsor request = await _apiService.GetById<Model.Sponsor>(_id);

                txtName.Text = request.SponsorName;
                txtPhone.Text = request.Phone;
                txtEmail.Text = request.Email;
                txtAbout.Text = request.About;
            }
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.SponsorName = txtName.Text;
                request.Phone = txtPhone.Text;
                request.Email = txtEmail.Text;
                request.About = txtAbout.Text;
                request.HairdresserSalonId = 1;

                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Sponsor>(_id, request);
                    MessageBox.Show("Sponsor successfully updated!");
                    this.Hide();
                }
                else
                {
                    await _apiService.Insert<Model.Sponsor>(request);
                    MessageBox.Show("New sponsor successfully added!");
                    this.Hide();
                }
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

        private void txtAbout_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAbout.Text))
            {
                errorProvider.SetError(txtAbout, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAbout, null);
            }
        }
    }
}
