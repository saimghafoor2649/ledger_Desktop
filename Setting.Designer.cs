namespace Ahmad_Saleem_and_Company.App
{
    partial class Setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.Updateloginbtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.panel1.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(441, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Setting";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.Updateloginbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 747);
            this.panel1.TabIndex = 1;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(43)))));
            this.siticonePanel1.Controls.Add(this.label1);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticonePanel1.Location = new System.Drawing.Point(200, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.Size = new System.Drawing.Size(859, 100);
            this.siticonePanel1.TabIndex = 2;
            // 
            // Updateloginbtn
            // 
            this.Updateloginbtn.Animated = true;
            this.Updateloginbtn.ButtonMode = Siticone.Desktop.UI.WinForms.Enums.ButtonMode.RadioButton;
            this.Updateloginbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Updateloginbtn.CustomBorderThickness = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.Updateloginbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Updateloginbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Updateloginbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Updateloginbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Updateloginbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.Updateloginbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Updateloginbtn.ForeColor = System.Drawing.Color.White;
            this.Updateloginbtn.HoverState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Updateloginbtn.HoverState.FillColor = System.Drawing.Color.DimGray;
            this.Updateloginbtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.Updateloginbtn.Location = new System.Drawing.Point(12, 142);
            this.Updateloginbtn.Name = "Updateloginbtn";
            this.Updateloginbtn.Size = new System.Drawing.Size(180, 45);
            this.Updateloginbtn.TabIndex = 0;
            this.Updateloginbtn.Text = "Update Login User";
            this.Updateloginbtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1059, 747);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Setting";
            this.Text = "Setting";
            this.panel1.ResumeLayout(false);
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Updateloginbtn;
    }
}