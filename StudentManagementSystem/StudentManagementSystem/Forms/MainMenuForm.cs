using System;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Auth / Roles module placeholder (Member 1). Wire your form here!", "Member 1 Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStudentRecords_Click(object sender, EventArgs e)
        {
            // Member 2: Launch Student Records Form
            StudentRecordsForm studentForm = new StudentRecordsForm();
            studentForm.Show();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            // Member 3: Launch Course Management Form
            CourseManagementForm courseForm = new CourseManagementForm();
            courseForm.Show();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Attendance module placeholder (Member 4). Wire your form here!", "Member 4 Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Grades module placeholder (Member 5). Wire your form here!", "Member 5 Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFees_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fees module placeholder (Member 6). Wire your form here!", "Member 6 Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Timetable module placeholder (Member 7). Wire your form here!", "Member 7 Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReportCard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report Card Export module placeholder (Member 8). Wire your form here!", "Member 8 Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
