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
    public partial class ManageVehicleListing : Form
    {
        private readonly carRentalEntities _db;
        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new carRentalEntities();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
/*
            var cars = _db.typesOfCars
                .Select(q => new 
                { 
                    make = q.make,
                    model = q.model,
                    vin = q.vin,
                    year = q.year,
                    licensePlate = q.licensePlateNumber,
                    q.id
                })
                .ToList();
            gvRecList.DataSource = cars;
            gvRecList.Columns[5].Visible = false;
*/
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            var addEditVehicle = new AddEditVehicle(this);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                //get id
                var id = (int)gvRecList.SelectedRows[0].Cells["id"].Value;
                //query database
                var car = _db.typesOfCars.FirstOrDefault(q => q.id == id);
                //launch with edit
                var addEditVehicle = new AddEditVehicle(car,this);
                addEditVehicle.MdiParent = this.MdiParent;
                addEditVehicle.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }

        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                //get id
                var id = (int)gvRecList.SelectedRows[0].Cells["id"].Value;

                //query database
                var car = _db.typesOfCars.FirstOrDefault(q => q.id == id);

                DialogResult dr = MessageBox.Show("Are U sure u want to delete this record ?","delete",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                if(dr == DialogResult.Yes)
                {
                    //delete from table
                    _db.typesOfCars.Remove(car);
                    _db.SaveChanges();

                }
                PopulateGrid();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.InnerException.Message}");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            // Select a custom model collection of cars from database
            var cars = _db.typesOfCars
                .Select(q => new
                {
                    Make = q.make,
                    Model = q.model,
                    VIN = q.vin,
                    Year = q.year,
                    LicensePlateNumber = q.licensePlateNumber,
                    q.id
                })
                .ToList();
            gvRecList.DataSource = cars;
            gvRecList.Columns[4].HeaderText = "License Plate Number";
            //Hide the column for ID. Changed from the hard coded column value to the name, 
            // to make it more dynamic. 
            gvRecList.Columns["Id"].Visible = false;
        }
    }
}
