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

namespace CodexApp
{
    public partial class StudentsForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";

        public StudentsForm()
        {
            InitializeComponent();
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;

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

                    // Add a composite key column for ValueMember
                    dt.Columns.Add("CompositeKey", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["CompositeKey"] = $"{row["CourseID"]}-{row["RoundNumber"]}";
                    }

                    // Add a display column for the ComboBox (Course Name with Round)
                    dt.Columns.Add("DisplayName", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["DisplayName"] = $"{row["Name"]} - Round {row["RoundNumber"]}";
                    }

                    // Bind the ComboBox
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
        private void LoadStudents(int courseId, int roundNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    CONCAT(Courses.Name, ' - Round ', Courses.RoundNumber) AS Course,
                    Students.Name AS Student,
                    Students.PaymentType,
                    Sessions.SessionName,
                    Attendance.IsAttended,
                    Instructors.Name AS Instructor,
                    Mentors.Name AS Mentor,
                    Quizzes.QuizName,
                    Quizzes.Grade AS QuizGrade,
                    Tasks.TaskName,
                    Tasks.Grade AS TaskGrade,
                    Projects.ProjectName, 
                    Projects.Grade AS ProjectGrade,
                    Enrollments.GeneralGrade
                FROM Enrollments
                INNER JOIN Courses ON Enrollments.CourseID = Courses.CourseID AND Enrollments.RoundNumber = Courses.RoundNumber
                INNER JOIN Instructors ON Courses.InstructorID = Instructors.InstructorID
                INNER JOIN Mentors ON Courses.MentorID = Mentors.MentorID
                INNER JOIN Projects ON Enrollments.EnrollmentID = Projects.EnrollmentID
                INNER JOIN Quizzes ON Enrollments.EnrollmentID = Quizzes.EnrollmentID
                INNER JOIN Sessions ON Courses.CourseID = Sessions.CourseID AND Courses.RoundNumber = Sessions.RoundNumber
                INNER JOIN Attendance ON Sessions.SessionID = Attendance.SessionID
                INNER JOIN Students ON Enrollments.StudentID = Students.StudentID AND Attendance.StudentID = Students.StudentID
                INNER JOIN Tasks ON Enrollments.EnrollmentID = Tasks.EnrollmentID
                WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    grdViewStudents.DataSource = null;
                    grdViewStudents.DataSource = dt;
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
                // Split the composite key into CourseID and RoundNumber
                string[] values = selectedValue.Split('-');
                if (values.Length == 2)
                {
                    string courseId = values[0];
                    string roundNumber = values[1];

                    // Call LoadStudents with the selected CourseID and RoundNumber
                    LoadStudents(Convert.ToInt32(courseId), Convert.ToInt32(roundNumber));
                }
            }
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

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }
    }
}
