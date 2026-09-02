using StudentManagementSystem.Core.Data;
using StudentManagementSystem.Core.Exceptions;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class StudentRecordsForm : Form
    {
        private readonly StudentRepository _studentRepository;
        private int _selectedStudentId = 0;

        public StudentRecordsForm()
        {
            InitializeComponent();
            _studentRepository = new StudentRepository();
        }

        private void StudentRecordsForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                var students = _studentRepository.GetAllStudents();
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;

                FormatGridColumns();
                ClearInputs();
            }
            catch (DatabaseException dbEx)
            {
                MessageBox.Show($"Database Error: {dbEx.Message}\n\nInner Exception: {dbEx.InnerException?.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridColumns()
        {
            if (dgvStudents.Columns["StudentID"] != null)
                dgvStudents.Columns["StudentID"].Visible = false;

            if (dgvStudents.Columns["PersonID"] != null)
                dgvStudents.Columns["PersonID"].Visible = false;

            if (dgvStudents.Columns["IsActive"] != null)
                dgvStudents.Columns["IsActive"].Visible = false;

            if (dgvStudents.Columns["RegNumber"] != null)
                dgvStudents.Columns["RegNumber"].HeaderText = "Reg No";

            if (dgvStudents.Columns["FirstName"] != null)
                dgvStudents.Columns["FirstName"].HeaderText = "First Name";

            if (dgvStudents.Columns["LastName"] != null)
                dgvStudents.Columns["LastName"].HeaderText = "Last Name";

            if (dgvStudents.Columns["Email"] != null)
                dgvStudents.Columns["Email"].HeaderText = "Email";

            if (dgvStudents.Columns["Phone"] != null)
                dgvStudents.Columns["Phone"].HeaderText = "Phone";

            if (dgvStudents.Columns["Address"] != null)
                dgvStudents.Columns["Address"].HeaderText = "Address";

            if (dgvStudents.Columns["DateOfBirth"] != null)
                dgvStudents.Columns["DateOfBirth"].HeaderText = "DOB";

            if (dgvStudents.Columns["EnrollmentDate"] != null)
                dgvStudents.Columns["EnrollmentDate"].HeaderText = "Enrolled Date";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var student = BuildStudentFromInputs();
                _studentRepository.AddStudent(student);

                MessageBox.Show($"Student '{student.FullName}' ({student.RegNumber}) successfully registered!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStudents();
            }
            catch (ValidationException valEx)
            {
                MessageBox.Show(valEx.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DatabaseException dbEx)
            {
                MessageBox.Show($"Database Error: {dbEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student from the grid to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var student = BuildStudentFromInputs();
                student.StudentID = _selectedStudentId;

                _studentRepository.UpdateStudent(student);

                MessageBox.Show($"Student record '{student.RegNumber}' updated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStudents();
            }
            catch (ValidationException valEx)
            {
                MessageBox.Show(valEx.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DatabaseException dbEx)
            {
                MessageBox.Show($"Database Error: {dbEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student from the grid to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete student '{txtRegNumber.Text}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _studentRepository.DeleteStudent(_selectedStudentId);

                MessageBox.Show("Student record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStudents();
            }
            catch (ValidationException valEx)
            {
                MessageBox.Show(valEx.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DatabaseException dbEx)
            {
                MessageBox.Show($"Database Error: {dbEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvStudents.SelectedRows[0];
                if (row.DataBoundItem is Student selectedStudent)
                {
                    _selectedStudentId = selectedStudent.StudentID;
                    txtRegNumber.Text = selectedStudent.RegNumber;
                    txtFirstName.Text = selectedStudent.FirstName;
                    txtLastName.Text = selectedStudent.LastName;
                    txtEmail.Text = selectedStudent.Email;
                    txtPhone.Text = selectedStudent.Phone;
                    txtAddress.Text = selectedStudent.Address;
                    dtpDOB.Value = selectedStudent.DateOfBirth;
                }
            }
        }

        private Student BuildStudentFromInputs()
        {
            return new Student
            {
                RegNumber = txtRegNumber.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                DateOfBirth = dtpDOB.Value
            };
        }

        private void ClearInputs()
        {
            _selectedStudentId = 0;
            txtRegNumber.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            dtpDOB.Value = DateTime.Now.AddYears(-20);

            if (dgvStudents.SelectedRows.Count > 0)
                dgvStudents.ClearSelection();
        }
    }
}
