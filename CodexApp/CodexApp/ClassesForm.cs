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
    public partial class ClassesForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";

        public ClassesForm()
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
    SELECT 
        CONCAT(Courses.Name, Courses.RoundNumber) AS Course_Name,
        Courses.TotalCost,
        Mentors.Name AS MentorName,
        Instructors.Name AS InstructorName,
        COUNT(Enrollments.StudentID) AS StudentCount
    FROM Courses
    INNER JOIN Instructors ON Courses.InstructorID = Instructors.InstructorID
    INNER JOIN Mentors ON Courses.MentorID = Mentors.MentorID
    LEFT JOIN Enrollments ON Enrollments.CourseID = Courses.CourseID
    GROUP BY 
        Courses.Name,
        Courses.RoundNumber,
        Courses.TotalCost,
        Mentors.Name,
        Instructors.Name;
";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    grdViewCourses.DataSource = null;
                    grdViewCourses.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Courses: {ex.Message}");
            }
        }

        private void ClassesForm_Load(object sender, EventArgs e)
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
    }
}
