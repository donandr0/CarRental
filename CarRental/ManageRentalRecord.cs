using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{

    public partial class ManageRentalRecord : Form
    {
        private readonly carRentalEntities _db;
        public ManageRentalRecord()
        {
            InitializeComponent();
            _db = new carRentalEntities();
        }

        private void ManageRentalRecord_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void PopulateGrid()
        {
            var records = _db.carRentalRecords.Select(q => new
            {
                Customer = q.customerName,
                Dateout = q.dateRanted,
                Datein = q.dateReturned,
                Id = q.id,
                q.cost,
                Car = q.typesOfCar.make + " " + q.typesOfCar.model
            }).ToList();

            gvRecordList.DataSource = records;
            gvRecordList.Columns["Datein"].HeaderText = "DateIn";
            gvRecordList.Columns["Dateout"].HeaderText = "Date out";
            gvRecordList.Columns["Id"].Visible = false;

        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                //get id
                var id = (int)gvRecordList.SelectedRows[0].Cells["id"].Value;
                //query database
                var record = _db.carRentalRecords.FirstOrDefault(q => q.id == id);
                //launch with edit
               
                var addEditRentalRecord = new AddEditRentalRecord(record);
                addEditRentalRecord.MdiParent = this.MdiParent;
                addEditRentalRecord.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                //get id
                var id = (int)gvRecordList.SelectedRows[0].Cells["id"].Value;

                //query database
                var record = _db.carRentalRecords.FirstOrDefault(q => q.id == id);

                //delete from table
                _db.carRentalRecords.Remove(record);
                _db.SaveChanges();
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
