namespace eHairdresserSalonFare.WinUI.Reports
{
    partial class rptHairdresserMostEarnedMoney
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Hairdresser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfServices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EarnedMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.cmbHairdresser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hairdresser,
            this.NumberOfServices,
            this.EarnedMoney});
            this.dgvData.Location = new System.Drawing.Point(12, 101);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(776, 337);
            this.dgvData.TabIndex = 0;
            // 
            // Hairdresser
            // 
            this.Hairdresser.DataPropertyName = "Hairdresser";
            this.Hairdresser.HeaderText = "Hairdresser";
            this.Hairdresser.Name = "Hairdresser";
            // 
            // NumberOfServices
            // 
            this.NumberOfServices.DataPropertyName = "NumberOfServices";
            this.NumberOfServices.HeaderText = "Number of completed services";
            this.NumberOfServices.Name = "NumberOfServices";
            // 
            // EarnedMoney
            // 
            this.EarnedMoney.DataPropertyName = "EarnedMoney";
            this.EarnedMoney.HeaderText = "Earned money";
            this.EarnedMoney.Name = "EarnedMoney";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(563, 36);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(104, 38);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(688, 36);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(100, 38);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // cmbHairdresser
            // 
            this.cmbHairdresser.FormattingEnabled = true;
            this.cmbHairdresser.Location = new System.Drawing.Point(12, 50);
            this.cmbHairdresser.Name = "cmbHairdresser";
            this.cmbHairdresser.Size = new System.Drawing.Size(137, 24);
            this.cmbHairdresser.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hairdresser";
            // 
            // rptHairdresserMostEarnedMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbHairdresser);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dgvData);
            this.Name = "rptHairdresserMostEarnedMoney";
            this.Text = "Hairdressers earned money";
            this.Load += new System.EventHandler(this.RptHairdresserMostEarnedMoney_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.ComboBox cmbHairdresser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hairdresser;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfServices;
        private System.Windows.Forms.DataGridViewTextBoxColumn EarnedMoney;
    }
}