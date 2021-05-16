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
    public partial class MainWindow : Form
    {
        private Login _login;
        public string _roleName;
        public User _user;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Login login,User user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _roleName = user.UserRoles.FirstOrDefault().Role.shortname;
        }

        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new AddEditRentalRecord();
            addRentalRecord.ShowDialog();
            addRentalRecord.MdiParent = this;
           
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var IsOpen = OpenForms.Any(q => q.Name == "ManageVehicleListing");

            if (!Utils.FormIsOpen("ManageVehicleListing"))
            {
                var VehicleListing = new ManageVehicleListing();
                VehicleListing.MdiParent = this;
                VehicleListing.Show();
            }

        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageRentalRecord = new ManageRentalRecord
            {
                MdiParent = this
            };
            manageRentalRecord.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var IsOpen = OpenForms.Any(q => q.Name == "ManageUsers");

            if (!IsOpen)
            {
                var ManageUsers = new ManageUsers();
                ManageUsers.MdiParent = this;
                ManageUsers.Show();
            }
        }

        private void manageRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if(_user.password == Utils.DefaultHashPassword())
            {
                var resetpass = new ResetPassword(_user);
                resetpass.ShowDialog();
            }


            var username = _user.username;
            tsiLogin.Text = $"Logged In As : {username}";

            if(_roleName != "admin")
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
        }
    }
}
