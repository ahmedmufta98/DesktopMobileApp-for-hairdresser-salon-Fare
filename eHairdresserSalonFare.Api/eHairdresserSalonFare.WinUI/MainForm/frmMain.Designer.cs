namespace eHairdresserSalonFare.WinUI.MainForm
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.hairdresserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSalonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sponsorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSponsorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfSponsorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.associatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAssociateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfAssociatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hairdressersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfHairdressersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newHairdresserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hairstylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfHairstylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newHairstyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfNotificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostSalesHairstyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mostSuccessfulHairdresserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hairdresserToolStripMenuItem,
            this.hairdressersToolStripMenuItem,
            this.hairstylesToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.bookingsToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.notificationsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(843, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // hairdresserToolStripMenuItem
            // 
            this.hairdresserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSalonToolStripMenuItem,
            this.sponsorsToolStripMenuItem,
            this.associatesToolStripMenuItem});
            this.hairdresserToolStripMenuItem.Name = "hairdresserToolStripMenuItem";
            this.hairdresserToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.hairdresserToolStripMenuItem.Text = "Hairdressing salon";
            // 
            // aboutSalonToolStripMenuItem
            // 
            this.aboutSalonToolStripMenuItem.Name = "aboutSalonToolStripMenuItem";
            this.aboutSalonToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.aboutSalonToolStripMenuItem.Text = "About salon";
            this.aboutSalonToolStripMenuItem.Click += new System.EventHandler(this.AboutSalonToolStripMenuItem_Click);
            // 
            // sponsorsToolStripMenuItem
            // 
            this.sponsorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSponsorToolStripMenuItem,
            this.listOfSponsorsToolStripMenuItem});
            this.sponsorsToolStripMenuItem.Name = "sponsorsToolStripMenuItem";
            this.sponsorsToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.sponsorsToolStripMenuItem.Text = "Sponsors";
            // 
            // newSponsorToolStripMenuItem
            // 
            this.newSponsorToolStripMenuItem.Name = "newSponsorToolStripMenuItem";
            this.newSponsorToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.newSponsorToolStripMenuItem.Text = "New sponsor";
            this.newSponsorToolStripMenuItem.Click += new System.EventHandler(this.NewSponsorToolStripMenuItem_Click);
            // 
            // listOfSponsorsToolStripMenuItem
            // 
            this.listOfSponsorsToolStripMenuItem.Name = "listOfSponsorsToolStripMenuItem";
            this.listOfSponsorsToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.listOfSponsorsToolStripMenuItem.Text = "List of sponsors";
            this.listOfSponsorsToolStripMenuItem.Click += new System.EventHandler(this.ListOfSponsorsToolStripMenuItem_Click);
            // 
            // associatesToolStripMenuItem
            // 
            this.associatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAssociateToolStripMenuItem,
            this.listOfAssociatesToolStripMenuItem});
            this.associatesToolStripMenuItem.Name = "associatesToolStripMenuItem";
            this.associatesToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.associatesToolStripMenuItem.Text = "Associates";
            // 
            // newAssociateToolStripMenuItem
            // 
            this.newAssociateToolStripMenuItem.Name = "newAssociateToolStripMenuItem";
            this.newAssociateToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.newAssociateToolStripMenuItem.Text = "New associate";
            this.newAssociateToolStripMenuItem.Click += new System.EventHandler(this.NewAssociateToolStripMenuItem_Click);
            // 
            // listOfAssociatesToolStripMenuItem
            // 
            this.listOfAssociatesToolStripMenuItem.Name = "listOfAssociatesToolStripMenuItem";
            this.listOfAssociatesToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.listOfAssociatesToolStripMenuItem.Text = "List of associates";
            this.listOfAssociatesToolStripMenuItem.Click += new System.EventHandler(this.ListOfAssociatesToolStripMenuItem_Click);
            // 
            // hairdressersToolStripMenuItem
            // 
            this.hairdressersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfHairdressersToolStripMenuItem,
            this.newHairdresserToolStripMenuItem});
            this.hairdressersToolStripMenuItem.Name = "hairdressersToolStripMenuItem";
            this.hairdressersToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.hairdressersToolStripMenuItem.Text = "Hairdressers";
            // 
            // listOfHairdressersToolStripMenuItem
            // 
            this.listOfHairdressersToolStripMenuItem.Name = "listOfHairdressersToolStripMenuItem";
            this.listOfHairdressersToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.listOfHairdressersToolStripMenuItem.Text = "List of hairdressers";
            this.listOfHairdressersToolStripMenuItem.Click += new System.EventHandler(this.ListOfHairdressersToolStripMenuItem_Click);
            // 
            // newHairdresserToolStripMenuItem
            // 
            this.newHairdresserToolStripMenuItem.Name = "newHairdresserToolStripMenuItem";
            this.newHairdresserToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.newHairdresserToolStripMenuItem.Text = "New hairdresser";
            this.newHairdresserToolStripMenuItem.Click += new System.EventHandler(this.NewHairdresserToolStripMenuItem_Click);
            // 
            // hairstylesToolStripMenuItem
            // 
            this.hairstylesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfHairstylesToolStripMenuItem,
            this.newHairstyleToolStripMenuItem});
            this.hairstylesToolStripMenuItem.Name = "hairstylesToolStripMenuItem";
            this.hairstylesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hairstylesToolStripMenuItem.Text = "Hairstyles";
            // 
            // listOfHairstylesToolStripMenuItem
            // 
            this.listOfHairstylesToolStripMenuItem.Name = "listOfHairstylesToolStripMenuItem";
            this.listOfHairstylesToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.listOfHairstylesToolStripMenuItem.Text = "List of hairstyles";
            this.listOfHairstylesToolStripMenuItem.Click += new System.EventHandler(this.ListOfHairstylesToolStripMenuItem_Click);
            // 
            // newHairstyleToolStripMenuItem
            // 
            this.newHairstyleToolStripMenuItem.Name = "newHairstyleToolStripMenuItem";
            this.newHairstyleToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.newHairstyleToolStripMenuItem.Text = "New hairstyle";
            this.newHairstyleToolStripMenuItem.Click += new System.EventHandler(this.NewHairstyleToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfClientsToolStripMenuItem});
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.clientsToolStripMenuItem.Text = "Clients";
            // 
            // listOfClientsToolStripMenuItem
            // 
            this.listOfClientsToolStripMenuItem.Name = "listOfClientsToolStripMenuItem";
            this.listOfClientsToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.listOfClientsToolStripMenuItem.Text = "List of clients";
            this.listOfClientsToolStripMenuItem.Click += new System.EventHandler(this.ListOfClientsToolStripMenuItem_Click);
            // 
            // bookingsToolStripMenuItem
            // 
            this.bookingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfBookingsToolStripMenuItem});
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.bookingsToolStripMenuItem.Text = "Bookings";
            // 
            // listOfBookingsToolStripMenuItem
            // 
            this.listOfBookingsToolStripMenuItem.Name = "listOfBookingsToolStripMenuItem";
            this.listOfBookingsToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.listOfBookingsToolStripMenuItem.Text = "List of bookings";
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfPaymentsToolStripMenuItem});
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.paymentsToolStripMenuItem.Text = "Payments";
            // 
            // listOfPaymentsToolStripMenuItem
            // 
            this.listOfPaymentsToolStripMenuItem.Name = "listOfPaymentsToolStripMenuItem";
            this.listOfPaymentsToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.listOfPaymentsToolStripMenuItem.Text = "List of payments";
            this.listOfPaymentsToolStripMenuItem.Click += new System.EventHandler(this.ListOfPaymentsToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newNotificationToolStripMenuItem,
            this.listOfNotificationsToolStripMenuItem});
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            // 
            // newNotificationToolStripMenuItem
            // 
            this.newNotificationToolStripMenuItem.Name = "newNotificationToolStripMenuItem";
            this.newNotificationToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.newNotificationToolStripMenuItem.Text = "List of notifications";
            this.newNotificationToolStripMenuItem.Click += new System.EventHandler(this.NewNotificationToolStripMenuItem_Click);
            // 
            // listOfNotificationsToolStripMenuItem
            // 
            this.listOfNotificationsToolStripMenuItem.Name = "listOfNotificationsToolStripMenuItem";
            this.listOfNotificationsToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.listOfNotificationsToolStripMenuItem.Text = "New notification";
            this.listOfNotificationsToolStripMenuItem.Click += new System.EventHandler(this.ListOfNotificationsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostSalesHairstyleToolStripMenuItem,
            this.mostSuccessfulHairdresserToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // mostSalesHairstyleToolStripMenuItem
            // 
            this.mostSalesHairstyleToolStripMenuItem.Name = "mostSalesHairstyleToolStripMenuItem";
            this.mostSalesHairstyleToolStripMenuItem.Size = new System.Drawing.Size(262, 26);
            this.mostSalesHairstyleToolStripMenuItem.Text = "Most sales hairstyle";
            this.mostSalesHairstyleToolStripMenuItem.Click += new System.EventHandler(this.MostSalesHairstyleToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 533);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // mostSuccessfulHairdresserToolStripMenuItem
            // 
            this.mostSuccessfulHairdresserToolStripMenuItem.Name = "mostSuccessfulHairdresserToolStripMenuItem";
            this.mostSuccessfulHairdresserToolStripMenuItem.Size = new System.Drawing.Size(262, 26);
            this.mostSuccessfulHairdresserToolStripMenuItem.Text = "Most successful hairdresser";
            this.mostSuccessfulHairdresserToolStripMenuItem.Click += new System.EventHandler(this.MostSuccessfulHairdresserToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 558);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Dashboard";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem hairdresserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSalonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sponsorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSponsorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem associatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAssociateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hairdressersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hairstylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfHairdressersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newHairdresserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfHairstylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newHairstyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfSponsorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfAssociatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newNotificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfNotificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostSalesHairstyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostSuccessfulHairdresserToolStripMenuItem;
    }
}



