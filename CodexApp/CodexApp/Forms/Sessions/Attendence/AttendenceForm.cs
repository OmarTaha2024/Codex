using CodexApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodexApp.Forms.Sessions.Attendence
{
    public partial class AttendenceForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";
        private int SessionId;
        private int CourseId;
        private int RoundNumber;
        private int StudentId;
        private int enrollmentID;
        public AttendenceForm()
        {
            InitializeComponent();
        }

        private void StyleDataGridView(DataGridView gridView)
        {
            gridView.BackgroundColor = Color.FromArgb(90, 80, 160);
            gridView.BorderStyle = BorderStyle.Fixed3D;

            gridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridView.DefaultCellStyle.ForeColor = Color.White;
            gridView.DefaultCellStyle.BackColor = Color.FromArgb(105, 95, 170);
            gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(135, 125, 200);
            gridView.DefaultCellStyle.SelectionForeColor = Color.White;

            gridView.EnableHeadersVisualStyles = false;
            gridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(72, 62, 140);
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);

            gridView.RowTemplate.Height = 35;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(95, 85, 155);
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
        private void LoadSessions()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
           SELECT
           Sessions.SessionID, Sessions.SessionName
       FROM   
         Sessions
          WHERE Sessions.CourseID = @CourseID AND Sessions.RoundNumber = @RoundNumber 

";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmbSession.SelectedIndexChanged -= cmbSession_SelectedIndexChanged;

                    cmbSession.DataSource = dt;
                    cmbSession.DisplayMember = "SessionName";
                    cmbSession.ValueMember = "SessionID";
                    cmbSession.SelectedIndexChanged += cmbSession_SelectedIndexChanged;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Sessions: {ex.Message}");
            }
        }
        private void LoadStudentsWithSession()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                 CONCAT(Courses.Name, ' - Round ', Courses.RoundNumber) AS Course,
                Students.StudentID,
                Students.Name AS Student,
                Sessions.SessionName,
                Attendance.IsAttended,
                 Instructors.Name AS Instructor,
                 Mentors.Name AS Mentor
                 FROM Enrollments
                INNER JOIN Courses ON Enrollments.CourseID = Courses.CourseID AND Enrollments.RoundNumber = Courses.RoundNumber
                INNER JOIN Instructors ON Courses.InstructorID = Instructors.InstructorID
                INNER JOIN Mentors ON Courses.MentorID = Mentors.MentorID
                INNER JOIN Sessions ON Courses.CourseID = Sessions.CourseID AND Courses.RoundNumber = Sessions.RoundNumber
                INNER JOIN Attendance ON Sessions.SessionID = Attendance.SessionID
                INNER JOIN Students ON Enrollments.StudentID = Students.StudentID AND Attendance.StudentID = Students.StudentID
                WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber  And Sessions.SessionID = @sessionid
                ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@sessionid", SessionId);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewAttendence);


                    grdViewAttendence.DataSource = null;
                    grdViewAttendence.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
            }
        }

        private void cmbCousres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCousres.SelectedValue != null)
            {
                string selectedValue = cmbCousres.SelectedValue.ToString();
                string[] values = selectedValue.Split('-');
                if (values.Length == 2)
                {
                    string courseId = values[0];
                    string roundNumber = values[1];

                    CourseId = Convert.ToInt32(courseId);
                    RoundNumber = Convert.ToInt32(roundNumber);

                    LoadSessions();

                }
            }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSession.SelectedValue != null && cmbSession.SelectedValue is int)
            {
                SessionId = (int)cmbSession.SelectedValue;
            }
            else
            {
                MessageBox.Show("Please select a valid session.");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadStudentsWithSession();
        }

        private void AttendenceForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in grdViewAttendence.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                        int sessionId = int.Parse(cmbSession.SelectedValue.ToString());

                        string query = @"
                UPDATE Attendance 
                SET IsAttended = @IsAttended
                WHERE StudentID = @StudentID AND SessionID = @SessionID;

            ";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", studentId);
                            cmd.Parameters.AddWithValue("@SessionID", sessionId);
                            cmd.Parameters.AddWithValue("@IsAttended", Convert.ToBoolean(row.Cells["IsAttended"].Value));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("All data updated successfully!");
                    LoadStudentsWithSession();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }

        }

        private void AttendenceForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
