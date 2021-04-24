namespace eHairdresserSalonFare.WinUI.Reports
{
    partial class rptMostSalesService
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
            this.HairstyleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfSalesHairstyles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HairstyleName,
            this.NumberOfSalesHairstyles,
            this.Price});
            this.dgvData.Location = new System.Drawing.Point(13, 97);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(775, 341);
            this.dgvData.TabIndex = 0;
            // 
            // HairstyleName
            // 
            this.HairstyleName.DataPropertyName = "Hairstyle";
            this.HairstyleName.HeaderText = "Hairstyle";
            this.HairstyleName.Name = "HairstyleName";
            // 
            // NumberOfSalesHairstyles
            // 
            this.NumberOfSalesHairstyles.DataPropertyName = "NumberOfSalesHairstyles";
            this.NumberOfSalesHairstyles.HeaderText = "Number of sales hairstyles";
            this.NumberOfSalesHairstyles.Name = "NumberOfSalesHairstyles";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(603, 36);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(185, 38);
            this.btnExportExcel.TabIndex = 1;
            this.btnExportExcel.Text = "Export excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // rptMostSalesService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.dgvData);
            this.Name = "rptMostSalesService";
            this.Text = "Most sales service";
            this.Load += new System.EventHandler(this.RptMostSalesService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn HairstyleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfSalesHairstyles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Button btnExportExcel;
    }
}