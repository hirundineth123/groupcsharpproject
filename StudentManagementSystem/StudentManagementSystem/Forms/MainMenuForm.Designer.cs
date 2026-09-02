namespace StudentManagementSystem.Forms
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAuth = new System.Windows.Forms.Button();
            this.btnStudentRecords = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnGrades = new System.Windows.Forms.Button();
            this.btnFees = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.btnReportCard = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(784, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblSubTitle.Location = new System.Drawing.Point(24, 48);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(262, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "CS107.3 - Object Oriented Programming with C#";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(437, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Student Management System (LMS)";
            // 
            // btnAuth
            // 
            this.btnAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuth.ForeColor = System.Drawing.Color.White;
            this.btnAuth.Location = new System.Drawing.Point(60, 120);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(300, 60);
            this.btnAuth.TabIndex = 1;
            this.btnAuth.Text = "1. Auth / Roles (Member 1)";
            this.btnAuth.UseVisualStyleBackColor = false;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // btnStudentRecords
            // 
            this.btnStudentRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnStudentRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentRecords.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentRecords.ForeColor = System.Drawing.Color.White;
            this.btnStudentRecords.Location = new System.Drawing.Point(420, 120);
            this.btnStudentRecords.Name = "btnStudentRecords";
            this.btnStudentRecords.Size = new System.Drawing.Size(300, 60);
            this.btnStudentRecords.TabIndex = 2;
            this.btnStudentRecords.Text = "2. Student Records (Member 2)";
            this.btnStudentRecords.UseVisualStyleBackColor = false;
            this.btnStudentRecords.Click += new System.EventHandler(this.btnStudentRecords_Click);
            // 
            // btnCourses
            // 
            this.btnCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourses.ForeColor = System.Drawing.Color.White;
            this.btnCourses.Location = new System.Drawing.Point(60, 200);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(300, 60);
            this.btnCourses.TabIndex = 3;
            this.btnCourses.Text = "3. Course Management (Member 3)";
            this.btnCourses.UseVisualStyleBackColor = false;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.ForeColor = System.Drawing.Color.White;
            this.btnAttendance.Location = new System.Drawing.Point(420, 200);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(300, 60);
            this.btnAttendance.TabIndex = 4;
            this.btnAttendance.Text = "4. Attendance (Member 4)";
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnGrades
            // 
            this.btnGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrades.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrades.ForeColor = System.Drawing.Color.White;
            this.btnGrades.Location = new System.Drawing.Point(60, 280);
            this.btnGrades.Name = "btnGrades";
            this.btnGrades.Size = new System.Drawing.Size(300, 60);
            this.btnGrades.TabIndex = 5;
            this.btnGrades.Text = "5. Grades (Member 5)";
            this.btnGrades.UseVisualStyleBackColor = false;
            this.btnGrades.Click += new System.EventHandler(this.btnGrades_Click);
            // 
            // btnFees
            // 
            this.btnFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFees.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFees.ForeColor = System.Drawing.Color.White;
            this.btnFees.Location = new System.Drawing.Point(420, 280);
            this.btnFees.Name = "btnFees";
            this.btnFees.Size = new System.Drawing.Size(300, 60);
            this.btnFees.TabIndex = 6;
            this.btnFees.Text = "6. Fees (Member 6)";
            this.btnFees.UseVisualStyleBackColor = false;
            this.btnFees.Click += new System.EventHandler(this.btnFees_Click);
            // 
            // btnTimetable
            // 
            this.btnTimetable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnTimetable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimetable.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimetable.ForeColor = System.Drawing.Color.White;
            this.btnTimetable.Location = new System.Drawing.Point(60, 360);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(300, 60);
            this.btnTimetable.TabIndex = 7;
            this.btnTimetable.Text = "7. Timetable (Member 7)";
            this.btnTimetable.UseVisualStyleBackColor = false;
            this.btnTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // btnReportCard
            // 
            this.btnReportCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnReportCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportCard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportCard.ForeColor = System.Drawing.Color.White;
            this.btnReportCard.Location = new System.Drawing.Point(420, 360);
            this.btnReportCard.Name = "btnReportCard";
            this.btnReportCard.Size = new System.Drawing.Size(300, 60);
            this.btnReportCard.TabIndex = 8;
            this.btnReportCard.Text = "8. Report Card Export (Member 8)";
            this.btnReportCard.UseVisualStyleBackColor = false;
            this.btnReportCard.Click += new System.EventHandler(this.btnReportCard_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnReportCard);
            this.Controls.Add(this.btnTimetable);
            this.Controls.Add(this.btnFees);
            this.Controls.Add(this.btnGrades);
            this.Controls.Add(this.btnAttendance);
            this.Controls.Add(this.btnCourses);
            this.Controls.Add(this.btnStudentRecords);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu Hub - LMS Student Management System";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.Button btnStudentRecords;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnGrades;
        private System.Windows.Forms.Button btnFees;
        private System.Windows.Forms.Button btnTimetable;
        private System.Windows.Forms.Button btnReportCard;
    }
}
