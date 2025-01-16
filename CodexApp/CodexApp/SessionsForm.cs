using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodexApp
{
    public partial class SessionsForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";

        public SessionsForm()
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


        private void LoadSeesions(int courseId, int roundNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    CONCAT(Courses.Name, ' - Round ', Courses.RoundNumber) AS Course,
                    Sessions.SessionName, 
                    Sessions.MaterialLink,
                    Projects.ProjectName, Tasks.TaskName, Quizzes.QuizName
                FROM Courses
                INNER JOIN Sessions ON Courses.CourseID = Sessions.CourseID AND Courses.RoundNumber = Sessions.RoundNumber
				  INNER JOIN
                  Projects ON Sessions.SessionID = Projects.SessionID INNER JOIN
                  Quizzes ON Sessions.SessionID = Quizzes.SessionID INNER JOIN
                  Tasks ON Sessions.SessionID = Tasks.SessionID
                WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    grdViewSessions.DataSource = null;
                    grdViewSessions.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sessions: {ex.Message}");
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
        private void QuizesForm()
        {
            Form formToOpen;
            formToOpen = new QuizesForm();
            formToOpen.Show();

            this.Hide();
        }
        private void toolStripViewQuizes_Click(object sender, EventArgs e)
        {
            QuizesForm();
        }
        private void TasksForm()
        {
            Form formToOpen;
            formToOpen = new TasksForm();
            formToOpen.Show();

            this.Hide();
        }
        private void toolStripViewTasks_Click(object sender, EventArgs e)
        {
            TasksForm();
        }
        private void ProjectsForm()
        {
            Form formToOpen;
            formToOpen = new ProjectsForm();
            formToOpen.Show();

            this.Hide();
        }
        private void toolStripViewProjects_Click(object sender, EventArgs e)
        {
            ProjectsForm();
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


                    LoadSeesions(Convert.ToInt32(courseId), Convert.ToInt32(roundNumber));

                }
            }
        }

        private void SessionsForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }
    }
}
