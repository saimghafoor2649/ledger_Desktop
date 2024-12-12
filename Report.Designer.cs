namespace Ahmad_Saleem_and_Company.App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenerateReportTodaybtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.GenerateReportbtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.ReportDateToPicker = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.ReportDatefrompicker = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ReportDataGridView = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.GenerateReportTodaybtn);
            this.panel1.Controls.Add(this.GenerateReportbtn);
            this.panel1.Controls.Add(this.ReportDateToPicker);
            this.panel1.Controls.Add(this.ReportDatefrompicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Name = "panel1";
            // 
            // GenerateReportTodaybtn
            // 
            resources.ApplyResources(this.GenerateReportTodaybtn, "GenerateReportTodaybtn");
            this.GenerateReportTodaybtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GenerateReportTodaybtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GenerateReportTodaybtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GenerateReportTodaybtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GenerateReportTodaybtn.ForeColor = System.Drawing.Color.White;
            this.GenerateReportTodaybtn.Name = "GenerateReportTodaybtn";
            this.GenerateReportTodaybtn.Click += new System.EventHandler(this.GenerateReportTodaybtn_Click);
            // 
            // GenerateReportbtn
            // 
            resources.ApplyResources(this.GenerateReportbtn, "GenerateReportbtn");
            this.GenerateReportbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GenerateReportbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GenerateReportbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GenerateReportbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GenerateReportbtn.ForeColor = System.Drawing.Color.White;
            this.GenerateReportbtn.Name = "GenerateReportbtn";
            this.GenerateReportbtn.Click += new System.EventHandler(this.GenerateReportbtn_Click);
            // 
            // ReportDateToPicker
            // 
            resources.ApplyResources(this.ReportDateToPicker, "ReportDateToPicker");
            this.ReportDateToPicker.Checked = true;
            this.ReportDateToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.ReportDateToPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ReportDateToPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ReportDateToPicker.Name = "ReportDateToPicker";
            this.ReportDateToPicker.Value = new System.DateTime(2024, 9, 12, 12, 59, 53, 375);
            // 
            // ReportDatefrompicker
            // 
            resources.ApplyResources(this.ReportDatefrompicker, "ReportDatefrompicker");
            this.ReportDatefrompicker.Checked = true;
            this.ReportDatefrompicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.ReportDatefrompicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ReportDatefrompicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ReportDatefrompicker.Name = "ReportDatefrompicker";
            this.ReportDatefrompicker.Value = new System.DateTime(2024, 9, 12, 12, 59, 53, 375);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.ReportDataGridView);
            this.panel2.Name = "panel2";
            // 
            // ReportDataGridView
            // 
            resources.ApplyResources(this.ReportDataGridView, "ReportDataGridView");
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.ReportDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ReportDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.ReportDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ReportDataGridView.Name = "ReportDataGridView";
            this.ReportDataGridView.RowHeadersVisible = false;
            this.ReportDataGridView.RowTemplate.Height = 24;
            this.ReportDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ReportDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ReportDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ReportDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ReportDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ReportDataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ReportDataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ReportDataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ReportDataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ReportDataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportDataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.ReportDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ReportDataGridView.ThemeStyle.HeaderStyle.Height = 4;
            this.ReportDataGridView.ThemeStyle.ReadOnly = false;
            this.ReportDataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ReportDataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ReportDataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportDataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ReportDataGridView.ThemeStyle.RowsStyle.Height = 24;
            this.ReportDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ReportDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Report
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView ReportDataGridView;
        private Siticone.Desktop.UI.WinForms.SiticoneButton GenerateReportbtn;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker ReportDateToPicker;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker ReportDatefrompicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton GenerateReportTodaybtn;
    }
}