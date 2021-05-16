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
    public partial class AddEditRentalRecord : Form
    {
        private bool isEditMode;
        private readonly carRentalEntities _db;
        public AddEditRentalRecord()
        {
            InitializeComponent();
            lbltitle.Text = "Add New Rental Record";
            this.Text = "Add New Rental Record";
            isEditMode = false;
            _db = new carRentalEntities();
        }

        public AddEditRentalRecord(carRentalRecord recordToEdit)
        {
            InitializeComponent();

            lbltitle.Text = "Edit Rental Record";
            this.Text = "Edit Rental Record";

            if (recordToEdit == null)
            {
                MessageBox.Show("Please ensure that  u selected a valid record to edit");
                Close();
            }
            else
            {
                isEditMode = true;
                _db = new carRentalEntities();
                PopulateFields(recordToEdit);
            }
        }

        private void PopulateFields(carRentalRecord recordToEdit)
        {
            TbCustomerName.Text = recordToEdit.customerName;
            dtFrom.Value = (DateTime)recordToEdit.dateRanted;
            dtTo.Value = (DateTime)recordToEdit.dateReturned;
            tbCost.Text = recordToEdit.cost.ToString();
            lblrecId.Text = recordToEdit.id.ToString();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = TbCustomerName.Text;
                var dateou = dtFrom.Value;
                var datein = dtTo.Value;
                var type = cbType.Text;
                double cost = Convert.ToDouble(tbCost.Text);

                var isValid = true;
                var errMsg = "";

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(type))
                {
                    isValid = false;
                    errMsg += "Please Enter Missing Data ! \n\r";
                }
                if (dateou > datein)
                {
                    isValid = false;
                    errMsg += "Illegeal date Selection";
                }

                if (isValid)
                {
                    var rentalRecord = new carRentalRecord();
                    if (isEditMode)
                    {
                        var id = (int.Parse(lblrecId.Text));
                        rentalRecord = _db.carRentalRecords.FirstOrDefault(q => q.id == id);
                    }
                        rentalRecord.customerName = customerName;
                        rentalRecord.dateRanted = dateou;
                        rentalRecord.dateReturned = datein;
                        rentalRecord.cost = (decimal)cost;
                        rentalRecord.typeOfCarId = (int)cbType.SelectedValue;

                    if (!isEditMode)
                    {
                        _db.carRentalRecords.Add(rentalRecord);
                    }

                        _db.SaveChanges();

                        MessageBox.Show(
                        $"Customer Name : {customerName}\n\r" +
                        $"Date Rented : {dateou}\n\r" +
                        $"Date Returned : {datein}\n\r" +
                        $"Car Type : {type}\n\r" +
                        $"Cost : {cost}\n\r" +
                        $"Thank You For Renting {customerName}");

                    Close();
                }
                else
                {
                    MessageBox.Show(errMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cars = _db.typesOfCars
                .Select(q => new { id = q.id, name = q.make + " " + q.model }).ToList();
            //var cars = carRentalEntities.typesOfCars.ToList();
            cbType.DisplayMember = "name";
            cbType.ValueMember = "id";
            cbType.DataSource = cars;
        }
    }
}
