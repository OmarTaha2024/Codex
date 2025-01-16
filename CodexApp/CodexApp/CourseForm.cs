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
    public partial class CourseForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";

        public CourseForm()
        {
            InitializeComponent();
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
        private void LoadCourse(int courseId, int roundNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT Students.Name AS Student_Name, Students.Phone, Students.PaymentType, Enrollments.GeneralGrade, Instructors.Name AS Instructor, Mentors.Name AS Mentor
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
                // Split the composite key into CourseID and RoundNumber
                string[] values = selectedValue.Split('-');
                if (values.Length == 2)
                {
                    string courseId = values[0];
                    string roundNumber = values[1];


                    LoadCourse(Convert.ToInt32(courseId), Convert.ToInt32(roundNumber));

                }
            }
        }
    }
}
