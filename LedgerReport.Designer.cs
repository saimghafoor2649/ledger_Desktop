namespace Ahmad_Saleem_and_Company.App
{
    partial class LedgerReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LedgerReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.Ledgerreportcustomernamecombobox = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.LedgerReportdateto = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.LedgerReportdatefrom = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Ledgercustomeridtxtbox = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.Generateledgerreportbtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.siticonePanel2 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.Ledgerreportdatagridview = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.siticonePanel1.SuspendLayout();
            this.siticonePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ledgerreportdatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // siticonePanel1
            // 
            resources.ApplyResources(this.siticonePanel1, "siticonePanel1");
            this.siticonePanel1.BackColor = System.Drawing.Color.DarkGray;
            this.siticonePanel1.Controls.Add(this.Ledgerreportcustomernamecombobox);
            this.siticonePanel1.Controls.Add(this.LedgerReportdateto);
            this.siticonePanel1.Controls.Add(this.LedgerReportdatefrom);
            this.siticonePanel1.Controls.Add(this.label4);
            this.siticonePanel1.Controls.Add(this.Ledgercustomeridtxtbox);
            this.siticonePanel1.Controls.Add(this.Generateledgerreportbtn);
            this.siticonePanel1.Controls.Add(this.label5);
            this.siticonePanel1.Controls.Add(this.label3);
            this.siticonePanel1.Controls.Add(this.label2);
            this.siticonePanel1.Name = "siticonePanel1";
            // 
            // Ledgerreportcustomernamecombobox
            // 
            resources.ApplyResources(this.Ledgerreportcustomernamecombobox, "Ledgerreportcustomernamecombobox");
            this.Ledgerreportcustomernamecombobox.BackColor = System.Drawing.Color.Transparent;
            this.Ledgerreportcustomernamecombobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Ledgerreportcustomernamecombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ledgerreportcustomernamecombobox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Ledgerreportcustomernamecombobox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Ledgerreportcustomernamecombobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Ledgerreportcustomernamecombobox.Name = "Ledgerreportcustomernamecombobox";
            this.Ledgerreportcustomernamecombobox.SelectedIndexChanged += new System.EventHandler(this.Ledgerreportcustomernamecombobox_SelectedIndexChanged);
            // 
            // LedgerReportdateto
            // 
            resources.ApplyResources(this.LedgerReportdateto, "LedgerReportdateto");
            this.LedgerReportdateto.Checked = true;
            this.LedgerReportdateto.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.LedgerReportdateto.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.LedgerReportdateto.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.LedgerReportdateto.Name = "LedgerReportdateto";
            this.LedgerReportdateto.Value = new System.DateTime(2024, 9, 4, 15, 34, 51, 600);
            // 
            // LedgerReportdatefrom
            // 
            resources.ApplyResources(this.LedgerReportdatefrom, "LedgerReportdatefrom");
            this.LedgerReportdatefrom.Checked = true;
            this.LedgerReportdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.LedgerReportdatefrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.LedgerReportdatefrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.LedgerReportdatefrom.Name = "LedgerReportdatefrom";
            this.LedgerReportdatefrom.Value = new System.DateTime(2024, 9, 4, 15, 34, 30, 724);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Ledgercustomeridtxtbox
            // 
            resources.ApplyResources(this.Ledgercustomeridtxtbox, "Ledgercustomeridtxtbox");
            this.Ledgercustomeridtxtbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Ledgercustomeridtxtbox.DefaultText = "";
            this.Ledgercustomeridtxtbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Ledgercustomeridtxtbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Ledgercustomeridtxtbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Ledgercustomeridtxtbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Ledgercustomeridtxtbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Ledgercustomeridtxtbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Ledgercustomeridtxtbox.Name = "Ledgercustomeridtxtbox";
            this.Ledgercustomeridtxtbox.PasswordChar = '\0';
            this.Ledgercustomeridtxtbox.PlaceholderText = "";
            this.Ledgercustomeridtxtbox.SelectedText = "";
            this.Ledgercustomeridtxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ledgercustomeridtxtbox_KeyDown);
            // 
            // Generateledgerreportbtn
            // 
            resources.ApplyResources(this.Generateledgerreportbtn, "Generateledgerreportbtn");
            this.Generateledgerreportbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Generateledgerreportbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Generateledgerreportbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Generateledgerreportbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Generateledgerreportbtn.ForeColor = System.Drawing.Color.White;
            this.Generateledgerreportbtn.Name = "Generateledgerreportbtn";
            this.Generateledgerreportbtn.Click += new System.EventHandler(this.Generateledgerreportbtn_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            // siticonePanel2
            // 
            resources.ApplyResources(this.siticonePanel2, "siticonePanel2");
            this.siticonePanel2.Controls.Add(this.Ledgerreportdatagridview);
            this.siticonePanel2.Name = "siticonePanel2";
            // 
            // Ledgerreportdatagridview
            // 
            resources.ApplyResources(this.Ledgerreportdatagridview, "Ledgerreportdatagridview");
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.Ledgerreportdatagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Ledgerreportdatagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Ledgerreportdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Ledgerreportdatagridview.DefaultCellStyle = dataGridViewCellStyle6;
            this.Ledgerreportdatagridview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Ledgerreportdatagridview.Name = "Ledgerreportdatagridview";
            this.Ledgerreportdatagridview.RowHeadersVisible = false;
            this.Ledgerreportdatagridview.RowTemplate.Height = 24;
            this.Ledgerreportdatagridview.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Ledgerreportdatagridview.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Ledgerreportdatagridview.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Ledgerreportdatagridview.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Ledgerreportdatagridview.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Ledgerreportdatagridview.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.Ledgerreportdatagridview.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Ledgerreportdatagridview.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Ledgerreportdatagridview.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Ledgerreportdatagridview.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ledgerreportdatagridview.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Ledgerreportdatagridview.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.Ledgerreportdatagridview.ThemeStyle.HeaderStyle.Height = 4;
            this.Ledgerreportdatagridview.ThemeStyle.ReadOnly = false;
            this.Ledgerreportdatagridview.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Ledgerreportdatagridview.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Ledgerreportdatagridview.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ledgerreportdatagridview.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Ledgerreportdatagridview.ThemeStyle.RowsStyle.Height = 24;
            this.Ledgerreportdatagridview.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Ledgerreportdatagridview.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // LedgerReport
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.siticonePanel2);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.label1);
            this.Name = "LedgerReport";
            this.Load += new System.EventHandler(this.LedgerReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LedgerReport_KeyDown);
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            this.siticonePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ledgerreportdatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Generateledgerreportbtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox Ledgercustomeridtxtbox;
        private System.Windows.Forms.Label label4;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker LedgerReportdateto;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker LedgerReportdatefrom;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox Ledgerreportcustomernamecombobox;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel2;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView Ledgerreportdatagridview;
    }
}