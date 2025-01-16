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
    public partial class GeneralForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";

        public GeneralForm()
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

        private void GeneralForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenForm(6);
        }
        private void OpenForm(int Btn_number)
        {
            Form formToOpen = null;

            switch (Btn_number)
            {
                case 1:
                    formToOpen = new SessionsForm();
                    break;
                case 2:
                    formToOpen = new StudentsForm();
                    break;
                case 3:
                    formToOpen = new MentorForm();
                    break;
                case 4:
                    formToOpen = new InstructorForm();
                    break;
                case 5:
                    formToOpen = new CourseForm();
                    break;
                case 6:
                    formToOpen = new ClassesForm();
                    break;
            }

            formToOpen.Show();
            this.Hide();
        }

        private void btnViewCourse_Click(object sender, EventArgs e)
        {
            OpenForm(5);
        }

        private void btnViewInstructos_Click(object sender, EventArgs e)
        {
            OpenForm(4);
        }

        private void btnViewMentors_Click(object sender, EventArgs e)
        {
            OpenForm(3);
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            OpenForm(2);
        }

        private void btnViewSessions_Click(object sender, EventArgs e)
        {
            OpenForm(1);
        }
    }
}
