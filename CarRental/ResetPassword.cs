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
    public partial class ResetPassword : Form
    {
        private readonly carRentalEntities _db;
        private User _user;

        public ResetPassword(User user)
        {
            InitializeComponent();
            _db = new carRentalEntities();
            _user = user;
        }

        private void btnsubmitpass_Click(object sender, EventArgs e)
        {
            try
            {
                var password = tbpassword.Text;
                var confirm_pass = tbConfirm.Text;
                var user = _db.Users.FirstOrDefault(q => q.id == _user.id);

                if (password != confirm_pass)
                {
                    MessageBox.Show("Password do not match plz try again");
                }

                user.password = Utils.HashPassword(password);
                _db.SaveChanges();
                MessageBox.Show("pass was reset successfullu");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("an error has occured plz try again");
            }
        }
    }
}
