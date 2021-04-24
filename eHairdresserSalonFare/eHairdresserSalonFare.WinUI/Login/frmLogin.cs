using eHairdresserSalonFare.Model.Requests.User;
using eHairdresserSalonFare.WinUI.APIServices;
using eHairdresserSalonFare.WinUI.MainForm;
using System;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.Login
{
    public partial class frmLogin : Form
    {
        private UserAPIService _apiService = new UserAPIService("users");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BaseAPIService.Username = txtUsername.Text;
                BaseAPIService.Password = txtPassword.Text;

                UserLoginRequest request = new UserLoginRequest()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text

                };

                Model.User loggedUser=await _apiService.Login(request);

                if (loggedUser != null)
                {
                    frmMain frm = new frmMain();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User not found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
