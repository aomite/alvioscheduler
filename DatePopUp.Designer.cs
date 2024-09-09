namespace AlvioScheduler
{
    partial class DatePopUp
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
            this.DatePopUpSelection = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DatePopUpConfirmBtn = new System.Windows.Forms.Button();
            this.DatePopUpCancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DatePopUpSelection
            // 
            this.DatePopUpSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatePopUpSelection.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePopUpSelection.Location = new System.Drawing.Point(88, 158);
            this.DatePopUpSelection.Name = "DatePopUpSelection";
            this.DatePopUpSelection.Size = new System.Drawing.Size(305, 30);
            this.DatePopUpSelection.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select A Date";
            // 
            // DatePopUpConfirmBtn
            // 
            this.DatePopUpConfirmBtn.Location = new System.Drawing.Point(88, 279);
            this.DatePopUpConfirmBtn.Name = "DatePopUpConfirmBtn";
            this.DatePopUpConfirmBtn.Size = new System.Drawing.Size(135, 47);
            this.DatePopUpConfirmBtn.TabIndex = 2;
            this.DatePopUpConfirmBtn.Text = "Confirm";
            this.DatePopUpConfirmBtn.UseVisualStyleBackColor = true;
            this.DatePopUpConfirmBtn.Click += new System.EventHandler(this.DatePopUpConfirmBtn_Click);
            // 
            // DatePopUpCancelBtn
            // 
            this.DatePopUpCancelBtn.Location = new System.Drawing.Point(249, 279);
            this.DatePopUpCancelBtn.Name = "DatePopUpCancelBtn";
            this.DatePopUpCancelBtn.Size = new System.Drawing.Size(134, 46);
            this.DatePopUpCancelBtn.TabIndex = 3;
            this.DatePopUpCancelBtn.Text = "Cancel";
            this.DatePopUpCancelBtn.UseVisualStyleBackColor = true;
            this.DatePopUpCancelBtn.Click += new System.EventHandler(this.DatePopUpCancelBtn_Click);
            // 
            // DatePopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 385);
            this.Controls.Add(this.DatePopUpCancelBtn);
            this.Controls.Add(this.DatePopUpConfirmBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DatePopUpSelection);
            this.Name = "DatePopUp";
            this.Text = "DatePopUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DatePopUpConfirmBtn;
        private System.Windows.Forms.Button DatePopUpCancelBtn;
        internal System.Windows.Forms.DateTimePicker DatePopUpSelection;
    }
}