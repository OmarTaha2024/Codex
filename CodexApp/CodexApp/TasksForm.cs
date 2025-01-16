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
    public partial class TasksForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";
        private int SessionId;
        private int CourseId;
        private int RoundNumber;
        private int StudentId;
        public TasksForm()
        {
            InitializeComponent();
        }
        private void LoadTaskswithStudents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT concat (Courses.Name,'- Round ', Courses.RoundNumber) As course, Students.Name AS Student, Sessions.SessionName,Tasks.TaskName, Tasks.Grade
                        FROM     Courses INNER JOIN
                        Sessions ON Courses.CourseID = Sessions.CourseID AND Courses.RoundNumber = Sessions.RoundNumber INNER JOIN
                        Tasks ON Sessions.SessionID = Tasks.SessionID CROSS JOIN
                        Students
                    WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber And  Sessions.SessionID =@sessionID And Students.StudentID = @studentID
               ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@sessionID", SessionId);
                    adapter.SelectCommand.Parameters.AddWithValue("@studentID", StudentId);



                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    grdViewTasks.DataSource = null;
                    grdViewTasks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Tasks: {ex.Message}");
            }
        }
        private void LoadTasks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                      SELECT concat ( Courses.Name,' - Round ', Courses.RoundNumber) AS course , Sessions.SessionName, Tasks.TaskName
                    FROM     Courses INNER JOIN
                    Sessions ON Courses.CourseID = Sessions.CourseID AND Courses.RoundNumber = Sessions.RoundNumber INNER JOIN
                    Tasks ON Sessions.SessionID = Tasks.SessionID
                    WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber 
               ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@sessionID", SessionId);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    grdViewTasks.DataSource = null;
                    grdViewTasks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Tasks: {ex.Message}");
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
                     SELECT Name, StudentID
                         FROM Students";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    // Temporarily detach the event handler
                    cmbStudents.SelectedIndexChanged -= cmbStudents_SelectedIndexChanged;

                    // Set data source and bind properties correctly
                    cmbStudents.DataSource = dt;
                    cmbStudents.DisplayMember = "Name";
                    cmbStudents.ValueMember = "StudentID";

                    cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Students: {ex.Message}");
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
            SELECT SessionName, SessionID
            FROM Sessions";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    // Temporarily detach the event handler
                    cmbSession.SelectedIndexChanged -= cmbSession_SelectedIndexChanged;

                    // Set data source and bind properties correctly
                    cmbSession.DataSource = dt;
                    cmbSession.DisplayMember = "SessionName";
                    cmbSession.ValueMember = "SessionID";

                    // Reattach the event handler
                    cmbSession.SelectedIndexChanged += cmbSession_SelectedIndexChanged;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Sessions: {ex.Message}");
            }
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
        private void OpenForm()
        {
            Form formToOpen;
            formToOpen = new SessionsForm();
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

                    CourseId = Convert.ToInt32(courseId);
                    RoundNumber = Convert.ToInt32(roundNumber);

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

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedValue != null && cmbStudents.SelectedValue is int)
            {
                StudentId = (int)cmbStudents.SelectedValue;
            }
            else
            {
                MessageBox.Show("Please select a valid Student.");
            }
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadSessions();
            LoadStudents();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void btnViewSession_Click(object sender, EventArgs e)
        {
            LoadTaskswithStudents();
        }
    }
}
