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
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private ManageVehicleListing _manageVehicle;
        private readonly carRentalEntities _db;

        public AddEditVehicle(ManageVehicleListing manageVehicle = null)
        {
            InitializeComponent();
            lbltitle.Text = "Add New Vehicle";
            this.Text = "Add New Vehicle";
            isEditMode = false;
            _manageVehicle = manageVehicle;
            _db = new carRentalEntities();
        }

        public AddEditVehicle(typesOfCar carToEdit,ManageVehicleListing manageVehicle = null)
        {
            InitializeComponent();
            lbltitle.Text = "Edit Vehicle";
            this.Text = "Edit Vehicle";

            if (carToEdit == null)
            {
                MessageBox.Show("Please ensure that  u selected a valid record to edit");
                Close();
            }
            else
            {
                isEditMode = true;
                _manageVehicle = manageVehicle;
                _db = new carRentalEntities();
                PopulateFields(carToEdit);
            }
        }

        private void PopulateFields(typesOfCar car)
        {
            lblid.Text = car.id.ToString();
            tbMake.Text = car.make;
            tbModel.Text = car.model;
            tbVin.Text = car.vin;
            tbYear.Text = car.year.ToString();
            tbLicense.Text = car.licensePlateNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                //edit code
                var id = int.Parse(lblid.Text);
                var car = _db.typesOfCars.FirstOrDefault(q => q.id == id);
                
                car.model = tbModel.Text;
                car.make = tbMake.Text;
                car.vin = tbVin.Text;
                car.year = int.Parse(tbYear.Text);
                car.licensePlateNumber = tbLicense.Text;

            }
            else
            {
                //add code
                var newCar = new typesOfCar
                {
                    licensePlateNumber = tbLicense.Text,
                    make = tbMake.Text,
                    model = tbModel.Text,
                    vin = tbVin.Text,
                    year = int.Parse(tbYear.Text)
                };
                _db.typesOfCars.Add(newCar);

            }
            _db.SaveChanges();
            _manageVehicle.PopulateGrid();
            MessageBox.Show("Done");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
