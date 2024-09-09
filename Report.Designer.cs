namespace AlvioScheduler
{
    partial class Report
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
            this.ReportTypeLabel = new System.Windows.Forms.Label();
            this.ReportMonthLabel = new System.Windows.Forms.Label();
            this.CreateReportBtn = new System.Windows.Forms.Button();
            this.CancelReportBtn = new System.Windows.Forms.Button();
            this.ReportToolLabel = new System.Windows.Forms.Label();
            this.ReportMonthComboBox = new System.Windows.Forms.ComboBox();
            this.ReportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ReportUserComboBox = new System.Windows.Forms.ComboBox();
            this.ReportUserLabel = new System.Windows.Forms.Label();
            this.ReportCustomerComboBox = new System.Windows.Forms.ComboBox();
            this.ReportCustomerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReportTypeLabel
            // 
            this.ReportTypeLabel.AutoSize = true;
            this.ReportTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportTypeLabel.Location = new System.Drawing.Point(141, 135);
            this.ReportTypeLabel.Name = "ReportTypeLabel";
            this.ReportTypeLabel.Size = new System.Drawing.Size(125, 25);
            this.ReportTypeLabel.TabIndex = 2;
            this.ReportTypeLabel.Text = "Report Type:";
            // 
            // ReportMonthLabel
            // 
            this.ReportMonthLabel.AutoSize = true;
            this.ReportMonthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportMonthLabel.Location = new System.Drawing.Point(141, 214);
            this.ReportMonthLabel.Name = "ReportMonthLabel";
            this.ReportMonthLabel.Size = new System.Drawing.Size(73, 25);
            this.ReportMonthLabel.TabIndex = 3;
            this.ReportMonthLabel.Text = "Month:";
            // 
            // CreateReportBtn
            // 
            this.CreateReportBtn.Location = new System.Drawing.Point(163, 459);
            this.CreateReportBtn.Name = "CreateReportBtn";
            this.CreateReportBtn.Size = new System.Drawing.Size(189, 43);
            this.CreateReportBtn.TabIndex = 4;
            this.CreateReportBtn.Text = "Generate";
            this.CreateReportBtn.UseVisualStyleBackColor = true;
            this.CreateReportBtn.Click += new System.EventHandler(this.CreateReportBtn_Click);
            // 
            // CancelReportBtn
            // 
            this.CancelReportBtn.Location = new System.Drawing.Point(375, 459);
            this.CancelReportBtn.Name = "CancelReportBtn";
            this.CancelReportBtn.Size = new System.Drawing.Size(189, 43);
            this.CancelReportBtn.TabIndex = 5;
            this.CancelReportBtn.Text = "Cancel";
            this.CancelReportBtn.UseVisualStyleBackColor = true;
            this.CancelReportBtn.Click += new System.EventHandler(this.CancelReportBtn_Click);
            // 
            // ReportToolLabel
            // 
            this.ReportToolLabel.AutoSize = true;
            this.ReportToolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportToolLabel.Location = new System.Drawing.Point(264, 42);
            this.ReportToolLabel.Name = "ReportToolLabel";
            this.ReportToolLabel.Size = new System.Drawing.Size(187, 38);
            this.ReportToolLabel.TabIndex = 6;
            this.ReportToolLabel.Text = "Report Tool";
            // 
            // ReportMonthComboBox
            // 
            this.ReportMonthComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportMonthComboBox.FormattingEnabled = true;
            this.ReportMonthComboBox.Location = new System.Drawing.Point(314, 209);
            this.ReportMonthComboBox.Name = "ReportMonthComboBox";
            this.ReportMonthComboBox.Size = new System.Drawing.Size(275, 33);
            this.ReportMonthComboBox.TabIndex = 9;
            // 
            // ReportTypeComboBox
            // 
            this.ReportTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportTypeComboBox.FormattingEnabled = true;
            this.ReportTypeComboBox.Location = new System.Drawing.Point(314, 130);
            this.ReportTypeComboBox.Name = "ReportTypeComboBox";
            this.ReportTypeComboBox.Size = new System.Drawing.Size(275, 33);
            this.ReportTypeComboBox.TabIndex = 10;
            this.ReportTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ReportTypeComboBox_SelectedIndexChanged);
            // 
            // ReportUserComboBox
            // 
            this.ReportUserComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportUserComboBox.FormattingEnabled = true;
            this.ReportUserComboBox.Location = new System.Drawing.Point(314, 286);
            this.ReportUserComboBox.Name = "ReportUserComboBox";
            this.ReportUserComboBox.Size = new System.Drawing.Size(275, 33);
            this.ReportUserComboBox.TabIndex = 12;
            // 
            // ReportUserLabel
            // 
            this.ReportUserLabel.AutoSize = true;
            this.ReportUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportUserLabel.Location = new System.Drawing.Point(141, 291);
            this.ReportUserLabel.Name = "ReportUserLabel";
            this.ReportUserLabel.Size = new System.Drawing.Size(112, 25);
            this.ReportUserLabel.TabIndex = 11;
            this.ReportUserLabel.Text = "Consultant:";
            // 
            // ReportCustomerComboBox
            // 
            this.ReportCustomerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportCustomerComboBox.FormattingEnabled = true;
            this.ReportCustomerComboBox.Location = new System.Drawing.Point(314, 366);
            this.ReportCustomerComboBox.Name = "ReportCustomerComboBox";
            this.ReportCustomerComboBox.Size = new System.Drawing.Size(275, 33);
            this.ReportCustomerComboBox.TabIndex = 14;
            // 
            // ReportCustomerLabel
            // 
            this.ReportCustomerLabel.AutoSize = true;
            this.ReportCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportCustomerLabel.Location = new System.Drawing.Point(141, 371);
            this.ReportCustomerLabel.Name = "ReportCustomerLabel";
            this.ReportCustomerLabel.Size = new System.Drawing.Size(103, 25);
            this.ReportCustomerLabel.TabIndex = 13;
            this.ReportCustomerLabel.Text = "Customer:";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 541);
            this.Controls.Add(this.ReportCustomerComboBox);
            this.Controls.Add(this.ReportCustomerLabel);
            this.Controls.Add(this.ReportUserComboBox);
            this.Controls.Add(this.ReportUserLabel);
            this.Controls.Add(this.ReportTypeComboBox);
            this.Controls.Add(this.ReportMonthComboBox);
            this.Controls.Add(this.ReportToolLabel);
            this.Controls.Add(this.CancelReportBtn);
            this.Controls.Add(this.CreateReportBtn);
            this.Controls.Add(this.ReportMonthLabel);
            this.Controls.Add(this.ReportTypeLabel);
            this.Name = "Report";
            this.Text = "`";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ReportTypeLabel;
        private System.Windows.Forms.Label ReportMonthLabel;
        private System.Windows.Forms.Button CreateReportBtn;
        private System.Windows.Forms.Button CancelReportBtn;
        private System.Windows.Forms.Label ReportToolLabel;
        private System.Windows.Forms.ComboBox ReportMonthComboBox;
        private System.Windows.Forms.ComboBox ReportTypeComboBox;
        private System.Windows.Forms.ComboBox ReportUserComboBox;
        private System.Windows.Forms.Label ReportUserLabel;
        private System.Windows.Forms.ComboBox ReportCustomerComboBox;
        private System.Windows.Forms.Label ReportCustomerLabel;
    }
}