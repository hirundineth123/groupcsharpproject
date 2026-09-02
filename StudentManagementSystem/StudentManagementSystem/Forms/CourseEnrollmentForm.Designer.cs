namespace StudentManagementSystem.Forms
{
    partial class CourseEnrollmentForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpEnroll = new System.Windows.Forms.GroupBox();
            this.btnUnenroll = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.lblSelectCourse = new System.Windows.Forms.Label();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.lblSelectStudent = new System.Windows.Forms.Label();
            this.dgvEnrollments = new System.Windows.Forms.DataGridView();
            this.lblEnrollmentList = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.grpEnroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(924, 65);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(18, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(326, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Course Enrollment Module";
            // 
            // grpEnroll
            // 
            this.grpEnroll.Controls.Add(this.btnUnenroll);
            this.grpEnroll.Controls.Add(this.btnEnroll);
            this.grpEnroll.Controls.Add(this.cmbCourses);
            this.grpEnroll.Controls.Add(this.lblSelectCourse);
            this.grpEnroll.Controls.Add(this.cmbStudents);
            this.grpEnroll.Controls.Add(this.lblSelectStudent);
            this.grpEnroll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEnroll.Location = new System.Drawing.Point(24, 80);
            this.grpEnroll.Name = "grpEnroll";
            this.grpEnroll.Size = new System.Drawing.Size(875, 110);
            this.grpEnroll.TabIndex = 1;
            this.grpEnroll.TabStop = false;
            this.grpEnroll.Text = "Enrollment Action";
            // 
            // btnUnenroll
            // 
            this.btnUnenroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnUnenroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnenroll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnenroll.ForeColor = System.Drawing.Color.White;
            this.btnUnenroll.Location = new System.Drawing.Point(740, 40);
            this.btnUnenroll.Name = "btnUnenroll";
            this.btnUnenroll.Size = new System.Drawing.Size(115, 38);
            this.btnUnenroll.TabIndex = 5;
            this.btnUnenroll.Text = "Drop Course";
            this.btnUnenroll.UseVisualStyleBackColor = false;
            this.btnUnenroll.Click += new System.EventHandler(this.btnUnenroll_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnroll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.ForeColor = System.Drawing.Color.White;
            this.btnEnroll.Location = new System.Drawing.Point(615, 40);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(115, 38);
            this.btnEnroll.TabIndex = 4;
            this.btnEnroll.Text = "Enroll Student";
            this.btnEnroll.UseVisualStyleBackColor = false;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // cmbCourses
            // 
            this.cmbCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourses.FormattingEnabled = true;
            this.cmbCourses.Location = new System.Drawing.Point(325, 47);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(265, 25);
            this.cmbCourses.TabIndex = 3;
            // 
            // lblSelectCourse
            // 
            this.lblSelectCourse.AutoSize = true;
            this.lblSelectCourse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCourse.Location = new System.Drawing.Point(322, 25);
            this.lblSelectCourse.Name = "lblSelectCourse";
            this.lblSelectCourse.Size = new System.Drawing.Size(91, 17);
            this.lblSelectCourse.TabIndex = 2;
            this.lblSelectCourse.Text = "Select Course:";
            // 
            // cmbStudents
            // 
            this.cmbStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(20, 47);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(280, 25);
            this.cmbStudents.TabIndex = 1;
            // 
            // lblSelectStudent
            // 
            this.lblSelectStudent.AutoSize = true;
            this.lblSelectStudent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectStudent.Location = new System.Drawing.Point(17, 25);
            this.lblSelectStudent.Name = "lblSelectStudent";
            this.lblSelectStudent.Size = new System.Drawing.Size(94, 17);
            this.lblSelectStudent.TabIndex = 0;
            this.lblSelectStudent.Text = "Select Student:";
            // 
            // dgvEnrollments
            // 
            this.dgvEnrollments.AllowUserToAddRows = false;
            this.dgvEnrollments.AllowUserToDeleteRows = false;
            this.dgvEnrollments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEnrollments.BackgroundColor = System.Drawing.Color.White;
            this.dgvEnrollments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrollments.Location = new System.Drawing.Point(24, 230);
            this.dgvEnrollments.MultiSelect = false;
            this.dgvEnrollments.Name = "dgvEnrollments";
            this.dgvEnrollments.ReadOnly = true;
            this.dgvEnrollments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnrollments.Size = new System.Drawing.Size(875, 230);
            this.dgvEnrollments.TabIndex = 2;
            // 
            // lblEnrollmentList
            // 
            this.lblEnrollmentList.AutoSize = true;
            this.lblEnrollmentList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnrollmentList.Location = new System.Drawing.Point(24, 205);
            this.lblEnrollmentList.Name = "lblEnrollmentList";
            this.lblEnrollmentList.Size = new System.Drawing.Size(185, 20);
            this.lblEnrollmentList.TabIndex = 3;
            this.lblEnrollmentList.Text = "Current Course Enrolments";
            // 
            // CourseEnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(924, 480);
            this.Controls.Add(this.lblEnrollmentList);
            this.Controls.Add(this.dgvEnrollments);
            this.Controls.Add(this.grpEnroll);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "CourseEnrollmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Course Enrollment Module - Student Management System";
            this.Load += new System.EventHandler(this.CourseEnrollmentForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpEnroll.ResumeLayout(false);
            this.grpEnroll.PerformLayout();
         
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpEnroll;
        private System.Windows.Forms.Label lblSelectStudent;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.Label lblSelectCourse;
        private System.Windows.Forms.ComboBox cmbCourses;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnUnenroll;
        private System.Windows.Forms.DataGridView dgvEnrollments;
        private System.Windows.Forms.Label lblEnrollmentList;
    }
}
