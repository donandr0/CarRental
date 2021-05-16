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
    public partial class ManageUsers : Form
    {
        private readonly carRentalEntities _db;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new carRentalEntities();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var addUser = new AddUser(this);
            addUser.MdiParent = this.MdiParent;
            addUser.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //get id
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;
                //query database
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                
                var hashed_password = Utils.DefaultHashPassword();
                user.password = hashed_password;
                _db.SaveChanges();
                MessageBox.Show($"{user.username}'s Password has been reset !");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                //get id
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;
                //query database
                var user = _db.Users.FirstOrDefault(q => q.id == id);

                user.isActive = user.isActive == true ? false : true ;
                _db.SaveChanges();
                MessageBox.Show($"{user.username}'s Activa status has changed !");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            populateGrid();
        }

        public void populateGrid()
        {
            var users = _db.Users
                .Select(q => new
            {
               q.id,
               q.username,
               q.UserRoles.FirstOrDefault().Role.name,
               q.isActive,
            }).ToList();

            gvUserList.DataSource = users;
            
            gvUserList.Columns["username"].HeaderText = "Username";
            gvUserList.Columns["name"].HeaderText = "Role Name";
            gvUserList.Columns["isActive"].HeaderText = "Active";

            gvUserList.Columns["id"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populateGrid();
        }
    }
}
