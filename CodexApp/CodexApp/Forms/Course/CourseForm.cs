using CodexApp.CodexContext;
using CodexApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace CodexApp
{
    public partial class CourseForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";
        private int courseId;
        private int roundNumber;
        private ToolTip toolTip;



        public CourseForm()
        {
            InitializeComponent();
            toolTip = new ToolTip();


        }
        private void StyleDataGridView(DataGridView gridView)
        {
            gridView.BackgroundColor = Color.FromArgb(34, 17, 51);
            gridView.BorderStyle = BorderStyle.None;

            gridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridView.DefaultCellStyle.ForeColor = Color.White;
            gridView.DefaultCellStyle.BackColor = Color.FromArgb(48, 25, 78);
            gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 50, 150);
            gridView.DefaultCellStyle.SelectionForeColor = Color.White;

            gridView.EnableHeadersVisualStyles = false;
            gridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(42, 21, 63);
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);

            gridView.RowTemplate.Height = 35;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 20, 60);
        }
        private void LoadCourses()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT CourseID, RoundNumber, Name
                FROM Courses";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dt.Columns.Add("CompositeKey", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["CompositeKey"] = $"{row["CourseID"]}-{row["RoundNumber"]}";
                    }

                    dt.Columns.Add("DisplayName", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["DisplayName"] = $"{row["Name"]} - Round {row["RoundNumber"]}";
                    }

                    cmbCousres.DataSource = null;
                    cmbCousres.DataSource = dt;
                    cmbCousres.DisplayMember = "DisplayName";
                    cmbCousres.ValueMember = "CompositeKey";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}");

            }
        }
        private void LoadStudents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT Students.StudentID, Students.Name
                     FROM     Enrollments INNER JOIN
                  Students ON Enrollments.StudentID = Students.StudentID
                    where Enrollments.CourseID = @CourseID and Enrollments.RoundNumber = @RoundNumber";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    cmbStudents.DataSource = null;

                    cmbStudents.DataSource = dt;
                    cmbStudents.DisplayMember = "Name";
                    cmbStudents.ValueMember = "StudentID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Students: {ex.Message}");
            }
        }

        private void LoadCourse()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT Students.StudentID,Students.Name AS Student_Name, Students.Phone, Students.Email,Students.PaymentType, Enrollments.GeneralGrade,Enrollments.InstructorFeedback, Instructors.Name AS Instructor, Mentors.Name AS Mentor
                   FROM     Courses INNER JOIN
                  Enrollments ON Courses.CourseID = Enrollments.CourseID AND Courses.RoundNumber = Enrollments.RoundNumber INNER JOIN
                  Instructors ON Courses.InstructorID = Instructors.InstructorID INNER JOIN
                  Mentors ON Courses.MentorID = Mentors.MentorID INNER JOIN
                  Students ON Enrollments.StudentID = Students.StudentID
                    WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber
";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewCourse);
                    grdViewCourse.DataSource = null;
                    grdViewCourse.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Course: {ex.Message}");
            }
        }
        private void LoadCoursewithstudents(int stdid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT Students.StudentID,Students.Name AS Student_Name, Students.Phone, Students.Email,Students.PaymentType, Enrollments.GeneralGrade,Enrollments.InstructorFeedback, Instructors.Name AS Instructor, Mentors.Name AS Mentor
                   FROM     Courses INNER JOIN
                  Enrollments ON Courses.CourseID = Enrollments.CourseID AND Courses.RoundNumber = Enrollments.RoundNumber INNER JOIN
                  Instructors ON Courses.InstructorID = Instructors.InstructorID INNER JOIN
                  Mentors ON Courses.MentorID = Mentors.MentorID INNER JOIN
                  Students ON Enrollments.StudentID = Students.StudentID
                    WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber And Students.StudentID =@StudentId

";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@StudentId", stdid);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewCourse);

                    grdViewCourse.DataSource = null;
                    grdViewCourse.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Course: {ex.Message}");
            }
        }
        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            toolTip.SetToolTip(btnSave, "Click to Update Student Name & Email & Phone & PaymentType for the selected Student.");
            toolTip.SetToolTip(btnDelete, "Click to delete the selected Student.");
        }

        private void OpenForm()
        {
            Form formToOpen;
            formToOpen = new GeneralForm();
            formToOpen.Show();

            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OpenForm();
        }

        private void cmbCousres_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCousres.SelectedValue != null)
            {
                string selectedValue = cmbCousres.SelectedValue.ToString();
                string[] values = selectedValue.Split('-');
                if (values.Length == 2)
                {
                    courseId = Convert.ToInt32(values[0]);
                    roundNumber = Convert.ToInt32(values[1]);


                    LoadCourse();
                    LoadStudents();


                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewCourse.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (rowIndex >= 0)
                {
                    int sudentid = Convert.ToInt32(grdViewCourse.SelectedRows[0].Cells["StudentID"].Value);

                    using (var context = new CodexDBContext())
                    {
                        var student = context.Students.FirstOrDefault(s => s.StudentID == sudentid);
                        if (student != null)
                        {
                            student.Name = grdViewCourse.SelectedRows[0].Cells["Student_Name"].Value.ToString();
                            student.Email = grdViewCourse.SelectedRows[0].Cells["Email"].Value.ToString();
                            student.Phone = grdViewCourse.SelectedRows[0].Cells["Phone"].Value.ToString();
                            student.PaymentType = grdViewCourse.SelectedRows[0].Cells["PaymentType"].Value.ToString();
                        }
                        context.SaveChanges();

                        var enrollment = context.Enrollments.FirstOrDefault(s => s.StudentID == sudentid);
                        if (enrollment != null)
                        {
                            enrollment.StudentID = sudentid;
                            enrollment.InstructorFeedback = grdViewCourse.SelectedRows[0].Cells["InstructorFeedback"].Value.ToString();


                            context.SaveChanges();
                            MessageBox.Show("student updated successfully!");
                            LoadCoursewithstudents(sudentid);
                        }
                        else
                        {
                            MessageBox.Show($"student not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var context = new CodexDBContext())
            {
                int sudentid = Convert.ToInt32(grdViewCourse.SelectedRows[0].Cells["StudentID"].Value);
                var sudent = context.Students.FirstOrDefault(s => s.StudentID == sudentid);

                if (sudent != null)
                {
                    context.Students.Remove(sudent);
                    context.SaveChanges();
                    LoadCourse();
                    MessageBox.Show("Student deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var context = new CodexDBContext())
            {
                int studentid = int.Parse(cmbStudents.SelectedValue.ToString());
                LoadCoursewithstudents(studentid);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCourse();

        }

        private void CourseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
