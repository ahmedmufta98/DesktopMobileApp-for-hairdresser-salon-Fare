using eHairdresserSalonFare.Model.Requests.Associate;
using eHairdresserSalonFare.WinUI.APIServices;
using System;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Forms.Associate
{
    public partial class frmAssociateAdd : Form
    {
        private BaseAPIService _apiService = new BaseAPIService("associates");
        private int? _id = null;
        private AssociateUpsertRequest request = new AssociateUpsertRequest();

        public frmAssociateAdd(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.AssociateName = txtName.Text;
                request.Phone = txtPhone.Text;
                request.Email = txtEmail.Text;
                request.HairdresserSalonId = 1;

                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Associate>(_id, request);
                    MessageBox.Show("Associate successfully updated!");
                    this.Hide();
                }
                else
                {
                    await _apiService.Insert<Model.Associate>(request);
                    MessageBox.Show("New associate successfully added!");
                    this.Hide();
                }
            }
        }

        private async void FrmAssociateAdd_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                Model.Associate request = await _apiService.GetById<Model.Associate>(_id);

                txtName.Text = request.AssociateName;
                txtPhone.Text = request.Phone;
                txtEmail.Text = request.Email;
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
    }
}
