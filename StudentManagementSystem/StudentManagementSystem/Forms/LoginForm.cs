using System;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login functionality to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
