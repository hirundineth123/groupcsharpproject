using StudentManagementSystem.Core.Data;
using StudentManagementSystem.Core.Exceptions;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class CourseManagementForm : Form
    {
        private readonly CourseRepository _courseRepository;
        private int _selectedCourseId = 0;

        public CourseManagementForm()
        {
            InitializeComponent();
            _courseRepository = new CourseRepository();
        }

        private void CourseManagementForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        /// <summary>
        /// Loads courses from the database and binds them to the DataGridView.
        /// </summary>
        private void LoadCourses()
        {
            try
            {
                var courses = _courseRepository.GetAllCourses();

                dgvCourses.DataSource = null;
                dgvCourses.DataSource = courses;

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
                MessageBox.Show($"An unexpected error occurred while loading courses: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridColumns()
        {
            if (dgvCourses.Columns["CourseID"] != null)
                dgvCourses.Columns["CourseID"].Visible = false;

            if (dgvCourses.Columns["IsActive"] != null)
                dgvCourses.Columns["IsActive"].Visible = false;

            if (dgvCourses.Columns["CourseCode"] != null)
                dgvCourses.Columns["CourseCode"].HeaderText = "Code";

            if (dgvCourses.Columns["CourseName"] != null)
                dgvCourses.Columns["CourseName"].HeaderText = "Course Title";

            if (dgvCourses.Columns["Credits"] != null)
                dgvCourses.Columns["Credits"].HeaderText = "Credits";

            if (dgvCourses.Columns["Department"] != null)
                dgvCourses.Columns["Department"].HeaderText = "Department";

            if (dgvCourses.Columns["AssignedTeacherID"] != null)
                dgvCourses.Columns["AssignedTeacherID"].HeaderText = "Teacher ID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var course = BuildCourseFromInputs();
                _courseRepository.AddCourse(course);

                MessageBox.Show($"Course '{course.CourseCode} - {course.CourseName}' successfully added!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCourses();
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
                MessageBox.Show($"Failed to add course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId == 0)
            {
                MessageBox.Show("Please select a course from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var course = BuildCourseFromInputs();
                course.CourseID = _selectedCourseId;

                _courseRepository.UpdateCourse(course);

                MessageBox.Show($"Course '{course.CourseCode}' updated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCourses();
            }
            catch (ValidationException valEx)
            {
                MessageBox.Show(valEx.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (CourseNotFoundException cnfEx)
            {
                MessageBox.Show(cnfEx.Message, "Course Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException dbEx)
            {
                MessageBox.Show($"Database Error: {dbEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId == 0)
            {
                MessageBox.Show("Please select a course from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete course code '{txtCourseCode.Text}'?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                _courseRepository.DeleteCourse(_selectedCourseId);

                MessageBox.Show("Course successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCourses();
            }
            catch (CourseNotFoundException cnfEx)
            {
                MessageBox.Show(cnfEx.Message, "Course Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException dbEx)
            {
                MessageBox.Show($"Database Error: {dbEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnOpenEnrollments_Click(object sender, EventArgs e)
        {
            CourseEnrollmentForm enrollmentForm = new CourseEnrollmentForm();
            enrollmentForm.ShowDialog();
            LoadCourses();
        }

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCourses.SelectedRows[0];
                if (row.DataBoundItem is Course selectedCourse)
                {
                    _selectedCourseId = selectedCourse.CourseID;
                    txtCourseCode.Text = selectedCourse.CourseCode;
                    txtCourseName.Text = selectedCourse.CourseName;
                    numCredits.Value = selectedCourse.Credits >= numCredits.Minimum && selectedCourse.Credits <= numCredits.Maximum 
                        ? selectedCourse.Credits 
                        : numCredits.Minimum;
                    txtDepartment.Text = selectedCourse.Department;
                }
            }
        }

        private Course BuildCourseFromInputs()
        {
            return new Course
            {
                CourseCode = txtCourseCode.Text.Trim(),
                CourseName = txtCourseName.Text.Trim(),
                Credits = (int)numCredits.Value,
                Department = txtDepartment.Text.Trim(),
                AssignedTeacherID = null // Reserved for Member 7 Timetable assignment
            };
        }

        private void ClearInputs()
        {
            _selectedCourseId = 0;
            txtCourseCode.Clear();
            txtCourseName.Clear();
            numCredits.Value = 3;
            txtDepartment.Clear();

            if (dgvCourses.SelectedRows.Count > 0)
                dgvCourses.ClearSelection();
        }
    }
}
