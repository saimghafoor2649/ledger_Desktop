namespace Ahmad_Saleem_and_Company.App
{
    partial class Payable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payable));
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.GenerateTodayPayableReportbtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.PayableDateToPicker = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Payablereportgeneratebtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.PayableDateFromPicker = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.siticonePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // siticonePanel1
            // 
            resources.ApplyResources(this.siticonePanel1, "siticonePanel1");
            this.siticonePanel1.BackColor = System.Drawing.Color.DarkGray;
            this.siticonePanel1.Controls.Add(this.GenerateTodayPayableReportbtn);
            this.siticonePanel1.Controls.Add(this.PayableDateToPicker);
            this.siticonePanel1.Controls.Add(this.label3);
            this.siticonePanel1.Controls.Add(this.Payablereportgeneratebtn);
            this.siticonePanel1.Controls.Add(this.PayableDateFromPicker);
            this.siticonePanel1.Controls.Add(this.label2);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.siticonePanel1_Paint);
            // 
            // GenerateTodayPayableReportbtn
            // 
            resources.ApplyResources(this.GenerateTodayPayableReportbtn, "GenerateTodayPayableReportbtn");
            this.GenerateTodayPayableReportbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GenerateTodayPayableReportbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GenerateTodayPayableReportbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GenerateTodayPayableReportbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GenerateTodayPayableReportbtn.ForeColor = System.Drawing.Color.White;
            this.GenerateTodayPayableReportbtn.Name = "GenerateTodayPayableReportbtn";
            this.GenerateTodayPayableReportbtn.Click += new System.EventHandler(this.GenerateTodayPayableReportbtn_Click);
            // 
            // PayableDateToPicker
            // 
            resources.ApplyResources(this.PayableDateToPicker, "PayableDateToPicker");
            this.PayableDateToPicker.Checked = true;
            this.PayableDateToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.PayableDateToPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.PayableDateToPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.PayableDateToPicker.Name = "PayableDateToPicker";
            this.PayableDateToPicker.Value = new System.DateTime(2024, 9, 12, 17, 40, 53, 269);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Payablereportgeneratebtn
            // 
            resources.ApplyResources(this.Payablereportgeneratebtn, "Payablereportgeneratebtn");
            this.Payablereportgeneratebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Payablereportgeneratebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Payablereportgeneratebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Payablereportgeneratebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Payablereportgeneratebtn.ForeColor = System.Drawing.Color.White;
            this.Payablereportgeneratebtn.Name = "Payablereportgeneratebtn";
            this.Payablereportgeneratebtn.Click += new System.EventHandler(this.Payablereportgeneratebtn_Click);
            // 
            // PayableDateFromPicker
            // 
            resources.ApplyResources(this.PayableDateFromPicker, "PayableDateFromPicker");
            this.PayableDateFromPicker.Checked = true;
            this.PayableDateFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.PayableDateFromPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.PayableDateFromPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.PayableDateFromPicker.Name = "PayableDateFromPicker";
            this.PayableDateFromPicker.Value = new System.DateTime(2024, 9, 12, 17, 40, 53, 269);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Payable
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.siticonePanel1);
            this.Name = "Payable";
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Payablereportgeneratebtn;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker PayableDateFromPicker;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker PayableDateToPicker;
        private System.Windows.Forms.Label label3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton GenerateTodayPayableReportbtn;
    }
}