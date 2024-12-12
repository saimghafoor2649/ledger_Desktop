namespace Ahmad_Saleem_and_Company.App
{
    partial class ReportViewForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ledger_systemDataSet = new Ahmad_Saleem_and_Company.ledger_systemDataSet();
            this.ledgersystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ledger_systemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgersystemDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ReportDataSet";
            reportDataSource1.Value = this.ledgersystemDataSetBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Ahmad_Saleem_and_Company.Report.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1070, 742);
            this.reportViewer2.TabIndex = 0;
            // 
            // ledger_systemDataSet
            // 
            this.ledger_systemDataSet.DataSetName = "ledger_systemDataSet";
            this.ledger_systemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ledgersystemDataSetBindingSource
            // 
            this.ledgersystemDataSetBindingSource.DataSource = this.ledger_systemDataSet;
            this.ledgersystemDataSetBindingSource.Position = 0;
            // 
            // ReportViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 742);
            this.Controls.Add(this.reportViewer2);
            this.Name = "ReportViewForm";
            this.Text = "ReportViewForm";
            this.Load += new System.EventHandler(this.ReportViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledger_systemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgersystemDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource ledgersystemDataSetBindingSource;
        private ledger_systemDataSet ledger_systemDataSet;
    }
}