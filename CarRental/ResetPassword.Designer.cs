
namespace CarRental
{
    partial class ResetPassword
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
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.btnsubmitpass = new System.Windows.Forms.Button();
            this.tbConfirm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "enter new password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(256, 61);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Size = new System.Drawing.Size(100, 20);
            this.tbpassword.TabIndex = 1;
            // 
            // btnsubmitpass
            // 
            this.btnsubmitpass.Location = new System.Drawing.Point(268, 180);
            this.btnsubmitpass.Name = "btnsubmitpass";
            this.btnsubmitpass.Size = new System.Drawing.Size(75, 23);
            this.btnsubmitpass.TabIndex = 2;
            this.btnsubmitpass.Text = "RESET";
            this.btnsubmitpass.UseVisualStyleBackColor = true;
            this.btnsubmitpass.Click += new System.EventHandler(this.btnsubmitpass_Click);
            // 
            // tbConfirm
            // 
            this.tbConfirm.Location = new System.Drawing.Point(256, 134);
            this.tbConfirm.Name = "tbConfirm";
            this.tbConfirm.Size = new System.Drawing.Size(100, 20);
            this.tbConfirm.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "confirm password";
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnsubmitpass);
            this.Controls.Add(this.tbpassword);
            this.Controls.Add(this.label1);
            this.Name = "ResetPassword";
            this.Text = "ResetPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.Button btnsubmitpass;
        private System.Windows.Forms.TextBox tbConfirm;
        private System.Windows.Forms.Label label2;
    }
}