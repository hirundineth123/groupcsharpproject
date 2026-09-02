using System;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            if (cmbAccountType.Items.Count > 0)
                cmbAccountType.SelectedIndex = 1; // Default Student

            if (cmbGender.Items.Count > 0)
                cmbGender.SelectedIndex = 0; // Default Male
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && 
                !txtEmail.Text.EndsWith("@students.nsbm.ac.lk") && 
                cmbAccountType.SelectedItem != null && 
                cmbAccountType.SelectedItem.ToString() == "Student")
            {
                MessageBox.Show("Student email must end with @students.nsbm.ac.lk", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Registration functionality to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LinkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
