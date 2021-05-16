
namespace CarRental
{
    partial class ManageVehicleListing
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
            this.gvRecList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddRec = new System.Windows.Forms.Button();
            this.btnEditRec = new System.Windows.Forms.Button();
            this.btnDeleteRec = new System.Windows.Forms.Button();
            this.btnRefreshRec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecList)).BeginInit();
            this.SuspendLayout();
            // 
            // gvRecList
            // 
            this.gvRecList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRecList.Location = new System.Drawing.Point(12, 94);
            this.gvRecList.Name = "gvRecList";
            this.gvRecList.Size = new System.Drawing.Size(585, 261);
            this.gvRecList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 40F);
            this.label1.Location = new System.Drawing.Point(105, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Vehicle Listing";
            // 
            // btnAddRec
            // 
            this.btnAddRec.Location = new System.Drawing.Point(12, 373);
            this.btnAddRec.Name = "btnAddRec";
            this.btnAddRec.Size = new System.Drawing.Size(116, 58);
            this.btnAddRec.TabIndex = 2;
            this.btnAddRec.Text = "Add Record";
            this.btnAddRec.UseVisualStyleBackColor = true;
            this.btnAddRec.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // btnEditRec
            // 
            this.btnEditRec.Location = new System.Drawing.Point(158, 373);
            this.btnEditRec.Name = "btnEditRec";
            this.btnEditRec.Size = new System.Drawing.Size(116, 58);
            this.btnEditRec.TabIndex = 3;
            this.btnEditRec.Text = "Edit record";
            this.btnEditRec.UseVisualStyleBackColor = true;
            this.btnEditRec.Click += new System.EventHandler(this.btnEditCar_Click);
            // 
            // btnDeleteRec
            // 
            this.btnDeleteRec.Location = new System.Drawing.Point(318, 373);
            this.btnDeleteRec.Name = "btnDeleteRec";
            this.btnDeleteRec.Size = new System.Drawing.Size(116, 58);
            this.btnDeleteRec.TabIndex = 4;
            this.btnDeleteRec.Text = "Delete Record";
            this.btnDeleteRec.UseVisualStyleBackColor = true;
            this.btnDeleteRec.Click += new System.EventHandler(this.btnDeleteCar_Click);
            // 
            // btnRefreshRec
            // 
            this.btnRefreshRec.Location = new System.Drawing.Point(481, 373);
            this.btnRefreshRec.Name = "btnRefreshRec";
            this.btnRefreshRec.Size = new System.Drawing.Size(116, 58);
            this.btnRefreshRec.TabIndex = 5;
            this.btnRefreshRec.Text = "Refresh Record";
            this.btnRefreshRec.UseVisualStyleBackColor = true;
            this.btnRefreshRec.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ManageVehicleListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefreshRec);
            this.Controls.Add(this.btnDeleteRec);
            this.Controls.Add(this.btnEditRec);
            this.Controls.Add(this.btnAddRec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvRecList);
            this.Name = "ManageVehicleListing";
            this.Text = "Manage Vehicle Listing";
            this.Load += new System.EventHandler(this.ManageVehicleListing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRecList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvRecList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddRec;
        private System.Windows.Forms.Button btnEditRec;
        private System.Windows.Forms.Button btnDeleteRec;
        private System.Windows.Forms.Button btnRefreshRec;
    }
}