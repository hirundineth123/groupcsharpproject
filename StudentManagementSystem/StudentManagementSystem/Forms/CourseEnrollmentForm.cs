using StudentManagementSystem.Core.Data;
using StudentManagementSystem.Core.Exceptions;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class CourseEnrollmentForm : Form
    {
        private readonly EnrollmentRepository _enrollmentRepository;
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;

        public CourseEnrollmentForm()
        {
            InitializeComponent();
            _enrollmentRepository = new EnrollmentRepository();
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
        }

        private void CourseEnrollmentForm_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadEnrollments();
        }

        private void LoadDropdowns()
        {
            try
            {
                var students = _studentRepository.GetAllStudents();
                cmbStudents.DataSource = null;
                cmbStudents.DataSource = students;
                cmbStudents.DisplayMember = "FullName";
                cmbStudents.ValueMember = "StudentID";

                var courses = _courseRepository.GetAllCourses();
                cmbCourses.DataSource = null;
                cmbCourses.DataSource = courses;
                cmbCourses.DisplayMember = "CourseName";
                cmbCourses.ValueMember = "CourseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dropdown items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEnrollments()
        {
            try
            {
                DataTable dt = _enrollmentRepository.GetAllEnrollmentsView();
                dgvEnrollments.DataSource = dt;
                FormatGridColumns();
            }
            catch (DatabaseException dbEx)
            {
                MessageBox.Show($"Database Error: {dbEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load enrollments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridColumns()
        {
            if (dgvEnrollments.Columns["EnrollmentID"] != null)
                dgvEnrollments.Columns["EnrollmentID"].Visible = false;

            if (dgvEnrollments.Columns["StudentID"] != null)
                dgvEnrollments.Columns["StudentID"].Visible = false;

            if (dgvEnrollments.Columns["CourseID"] != null)
                dgvEnrollments.Columns["CourseID"].Visible = false;

            if (dgvEnrollments.Columns["RegNumber"] != null)
                dgvEnrollments.Columns["RegNumber"].HeaderText = "Reg No";

            if (dgvEnrollments.Columns["StudentName"] != null)
                dgvEnrollments.Columns["StudentName"].HeaderText = "Student Name";

            if (dgvEnrollments.Columns["CourseCode"] != null)
                dgvEnrollments.Columns["CourseCode"].HeaderText = "Course Code";

            if (dgvEnrollments.Columns["CourseName"] != null)
                dgvEnrollments.Columns["CourseName"].HeaderText = "Course Title";

            if (dgvEnrollments.Columns["EnrollmentDate"] != null)
                dgvEnrollments.Columns["EnrollmentDate"].HeaderText = "Enrollment Date";

            if (dgvEnrollments.Columns["Status"] != null)
                dgvEnrollments.Columns["Status"].HeaderText = "Status";
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedValue == null || cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select both a student and a course.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = Convert.ToInt32(cmbStudents.SelectedValue);
            int courseId = Convert.ToInt32(cmbCourses.SelectedValue);

            try
            {
                _enrollmentRepository.EnrollStudent(studentId, courseId);

                MessageBox.Show("Student successfully enrolled in course!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadEnrollments();
            }
            catch (ValidationException valEx)
            {
                MessageBox.Show(valEx.Message, "Enrollment Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DatabaseException dbEx)
            {
                MessageBox.Show($"Database Error: {dbEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to enroll student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnenroll_Click(object sender, EventArgs e)
        {
            if (dgvEnrollments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an enrollment record from the table to drop.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView selectedRow = (DataRowView)dgvEnrollments.SelectedRows[0].DataBoundItem;
            int studentId = Convert.ToInt32(selectedRow["StudentID"]);
            int courseId = Convert.ToInt32(selectedRow["CourseID"]);
            string studentName = selectedRow["StudentName"].ToString();
            string courseCode = selectedRow["CourseCode"].ToString();

            var confirm = MessageBox.Show($"Are you sure you want to drop course '{courseCode}' for student '{studentName}'?",
                "Confirm Course Drop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _enrollmentRepository.UnenrollStudent(studentId, courseId);

                MessageBox.Show("Student successfully dropped from course.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadEnrollments();
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
                MessageBox.Show($"Failed to drop course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
