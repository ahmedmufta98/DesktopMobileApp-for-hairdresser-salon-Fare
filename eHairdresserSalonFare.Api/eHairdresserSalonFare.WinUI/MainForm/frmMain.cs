using eHairdresserSalonFare.WinUI.Forms.Associate;
using eHairdresserSalonFare.WinUI.Forms.Client;
using eHairdresserSalonFare.WinUI.Forms.Hairdresser;
using eHairdresserSalonFare.WinUI.Forms.HairdresserSalon;
using eHairdresserSalonFare.WinUI.Forms.Hairstyle;
using eHairdresserSalonFare.WinUI.Forms.Notification;
using eHairdresserSalonFare.WinUI.Forms.Payment;
using eHairdresserSalonFare.WinUI.Forms.Sponsor;
using eHairdresserSalonFare.WinUI.Reports;
using System;
using System.Windows.Forms;

namespace eHairdresserSalonFare.WinUI.MainForm
{
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void AboutSalonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHairdresserSalonData frm = new frmHairdresserSalonData();
            frm.Show();
        }

        private void ListOfHairdressersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHairdresserData frm = new frmHairdresserData();
            frm.Show();
        }

        private void NewHairdresserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHairdresserAdd frm = new frmHairdresserAdd();
            frm.Show();
        }

        private void ListOfClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientsData frm = new frmClientsData();
            frm.Show();
        }

        private void ListOfPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentData frm = new frmPaymentData();
            frm.Show();
        }

        private void ListOfHairstylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHairstyleData frm = new frmHairstyleData();
            frm.Show();
        }

        private void NewHairstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHairstyleAdd frm = new frmHairstyleAdd();
            frm.Show();
        }

        private void ListOfSponsorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSponsorData frm = new frmSponsorData();
            frm.Show();
        }

        private void ListOfAssociatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssociateData frm = new frmAssociateData();
            frm.Show();
        }

        private void NewNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotificationData frm = new frmNotificationData();
            frm.Show();
        }

        private void NewSponsorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSponsorAdd frm = new frmSponsorAdd();
            frm.Show();
        }

        private void NewAssociateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssociateAdd frm = new frmAssociateAdd();
            frm.Show();
        }

        private void ListOfNotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotificationAdd frm = new frmNotificationAdd();
            frm.Show();
        }

        private void MostSalesHairstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptMostSalesService rpt = new rptMostSalesService();
            rpt.Show();
        }

        private void MostSuccessfulHairdresserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptHairdresserMostEarnedMoney rpt = new rptHairdresserMostEarnedMoney();
            rpt.Show();
        }
    }
}
