using CodexApp.CodexContext;
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

namespace CodexApp
{
    public partial class QuizesForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";
        private int SessionId;
        private int CourseId;
        private int RoundNumber;
        private int StudentId;
        private int enrollmentID;

        private ToolTip toolTip;
        public QuizesForm()
        {
            InitializeComponent();
            toolTip = new ToolTip();

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
        private void LoadQuizesswithStudents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                      SELECT 
    Quizzes.QuizID,
    CONCAT(Courses.Name, '- Round ', Courses.RoundNumber) AS Course,
    Students.Name AS Student,
    Sessions.SessionID,
    Sessions.SessionName,
    Quizzes.QuizName AS QuizName, 
    Quizzes.Grade AS Grade
FROM Courses
INNER JOIN Sessions 
    ON Courses.CourseID = Sessions.CourseID 
    AND Courses.RoundNumber = Sessions.RoundNumber
INNER JOIN Quizzes 
    ON Sessions.SessionID = Quizzes.SessionID
INNER JOIN Enrollments 
    ON Enrollments.CourseID = Courses.CourseID 
    AND Enrollments.RoundNumber = Courses.RoundNumber
INNER JOIN Students 
    ON Students.StudentID = Enrollments.StudentID
WHERE Courses.CourseID = @CourseID 
  AND Courses.RoundNumber = @RoundNumber
  AND Sessions.SessionID = @sessionID
  AND Enrollments.StudentID = @studentID
  AND Quizzes.EnrollmentID = @enrollmentID;

               ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@sessionID", SessionId);
                    adapter.SelectCommand.Parameters.AddWithValue("@studentID", StudentId);
                    adapter.SelectCommand.Parameters.AddWithValue("@enrollmentID", enrollmentID);



                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewQuizes);
                    grdViewQuizes.DataSource = null;
                    grdViewQuizes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Quiz: {ex.Message}");
            }
        }
        private void LoadQuizes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
           SELECT DISTINCT
                CONCAT(Courses.Name, ' - Round ', Courses.RoundNumber) AS Course,
                Sessions.SessionID,
                Sessions.SessionName, 
                CAST(Sessions.MaterialLink AS VARCHAR(MAX)) AS MaterialLink,
            Projects.ProjectName, 
            Tasks.TaskName, 
            Quizzes.QuizName
            FROM Courses
            INNER JOIN Sessions 
            ON Courses.CourseID = Sessions.CourseID 
            AND Courses.RoundNumber = Sessions.RoundNumber
            INNER JOIN Projects 
            ON Sessions.SessionID = Projects.SessionID
            INNER JOIN Quizzes 
            ON Sessions.SessionID = Quizzes.SessionID
            INNER JOIN Tasks 
            ON Sessions.SessionID = Tasks.SessionID
                WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber; 
               ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@sessionID", SessionId);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewQuizes);

                    grdViewQuizes.DataSource = null;
                    grdViewQuizes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Quizes: {ex.Message}");
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
                    FROM     Courses INNER JOIN
                  Enrollments ON Courses.CourseID = Enrollments.CourseID AND Courses.RoundNumber = Enrollments.RoundNumber INNER JOIN
                  Students ON Enrollments.StudentID = Students.StudentID
                   WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);
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

        private void QuizesForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            toolTip.SetToolTip(btnView, "Click to View Session and its Quiz ");
            toolTip.SetToolTip(btnViewSession, "Click to View Student in specific Session and its Quiz and Grade ");
            toolTip.SetToolTip(btnUpdata, "Click to Update the Quiz Name.");
            toolTip.SetToolTip(button2, "Click to Update the Quiz Grade");

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
                    LoadSessions();
                    LoadStudents();
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
                using (var context = new CodexDBContext())
                {
                    var enrollment = context.Enrollments.FirstOrDefault(s => s.StudentID == StudentId);
                    enrollmentID = enrollment.EnrollmentID;
                }
            }
            else
            {
                MessageBox.Show("Please select a valid Student.");
            }
        }

        private void btnViewSession_Click(object sender, EventArgs e)
        {
            LoadQuizesswithStudents();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadQuizes();
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewQuizes.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (grdViewQuizes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a course to save changes.");
                    return;
                }
                else
                {
                    int sessionid = Convert.ToInt32(grdViewQuizes.SelectedRows[0].Cells["SessionID"].Value?.ToString());
                    string quizName = grdViewQuizes.SelectedRows[0].Cells["QuizName"].Value?.ToString();

                    using (var context = new CodexDBContext())
                    {

                        var quizzes = context.Quizzes
      .Where(s => s.SessionID == sessionid)
      .ToList();

                        foreach (var quiz in quizzes)
                        {
                            quiz.QuizName = quizName;
                            context.SaveChanges();
                        }



                        LoadQuizes();


                        MessageBox.Show("Changes saved successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewQuizes.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (grdViewQuizes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a course to save changes.");
                    return;
                }
                else
                {
                    int quizid = Convert.ToInt32(grdViewQuizes.SelectedRows[0].Cells["QuizID"].Value?.ToString());
                    decimal QuizGrade = Convert.ToDecimal(grdViewQuizes.SelectedRows[0].Cells["Grade"].Value);

                    using (var context = new CodexDBContext())
                    {

                        var quiz = context.Quizzes.FirstOrDefault(q => q.QuizID == quizid);
                        if (quiz != null)
                        {
                            quiz.Grade = QuizGrade; // Assuming `QuizGrade` is the new value for the quiz grade
                            context.SaveChanges();
                        }
                        context.SaveChanges();

                        MessageBox.Show("Changes saved successfully!");
                        LoadQuizesswithStudents();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void QuizesForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
