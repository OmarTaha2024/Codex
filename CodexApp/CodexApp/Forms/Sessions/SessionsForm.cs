using CodexApp.Codex_Classes;
using CodexApp.CodexContext;
using CodexApp.Entities;
using CodexApp.Forms.Sessions.Attendence;
using Microsoft.EntityFrameworkCore;
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
        int courseId;
        int roundNumber;
        private ToolTip toolTip;
        public SessionsForm()
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


        private void LoadSeesions()
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
                WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewSessions);
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
                    courseId = Convert.ToInt32(values[0]);
                    roundNumber = Convert.ToInt32(values[1]);


                    LoadSeesions();

                }
            }
        }

        private void SessionsForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            toolTip.SetToolTip(btnAdd, "Click to add a new Session.");
            toolTip.SetToolTip(btnSave, "Click to update SessionName - MaterialLink(Text) - QuizName - TaskName - ProjectNamefor the selected Session.");
            toolTip.SetToolTip(btnDelete, "Click to delete the selected Session.");
        }
        private bool ValidateSession()
        {
            if (!Validator.IsComboBoxSelected(cmbCousres, "Course")) return false;
            if (!Validator.IsRequired(txtSessionName.Text, "Session Name")) return false;

            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateSession()) return;
            try
            {
                using (var context = new CodexDBContext())
                {
                    var session = new Session
                    {
                        SessionName = txtSessionName.Text,
                        MaterialLink = txtMatrialLink.Text,
                        CourseID = courseId,
                        RoundNumber = roundNumber
                    };

                    context.Sessions.Add(session);
                    context.SaveChanges();

                    var enrollments = context.Enrollments
                        .Where(e => e.CourseID == courseId && e.RoundNumber == roundNumber)
                        .ToList();

                    if (enrollments.Any())
                    {
                        foreach (var enrollment in enrollments)
                        {
                            var newQuiz = new Quiz
                            {
                                QuizName = "No Quiz",
                                EnrollmentID = enrollment.EnrollmentID,
                                Grade = null,
                                SessionID = session.SessionID
                            };
                            context.Quizzes.Add(newQuiz);

                            var newTask = new CodexApp.Entities.Task
                            {
                                TaskName = "No Task",
                                EnrollmentID = enrollment.EnrollmentID,
                                Grade = null,
                                SessionID = session.SessionID
                            };
                            context.Tasks.Add(newTask);

                            var newProject = new Project
                            {
                                ProjectName = "No Project",
                                EnrollmentID = enrollment.EnrollmentID,
                                Grade = null,
                                SessionID = session.SessionID
                            };
                            context.Projects.Add(newProject);
                        }
                    }
                    else
                    {
                        var newQuiz = new Quiz
                        {
                            QuizName = "No Quiz",
                            EnrollmentID = null,
                            Grade = null,
                            SessionID = session.SessionID
                        };
                        context.Quizzes.Add(newQuiz);

                        var newTask = new CodexApp.Entities.Task
                        {
                            TaskName = "No Task",
                            EnrollmentID = null,
                            Grade = null,
                            SessionID = session.SessionID
                        };
                        context.Tasks.Add(newTask);

                        var newProject = new Project
                        {
                            ProjectName = "No Project",
                            EnrollmentID = null,
                            Grade = null,
                            SessionID = session.SessionID
                        };
                        context.Projects.Add(newProject);
                    }

                    context.SaveChanges();

                    LoadSeesions();
                    MessageBox.Show($"Session and related records added successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting data: {ex.Message}");
            }


        }


        private void grdViewSessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grdViewSessions.Columns["MaterialLink"].Index && e.RowIndex >= 0)
            {
                string url = grdViewSessions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                try
                {
                    string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";


                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = chromePath,
                        Arguments = url,
                        UseShellExecute = false
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening link in Chrome: {ex.Message}");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int rowIndex = grdViewSessions.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (grdViewSessions.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a course to save changes.");
                    return;
                }

                // Fetch data from the selected row
                int sessionid = Convert.ToInt32(grdViewSessions.SelectedRows[0].Cells["SessionID"].Value?.ToString());
                string sessionName = grdViewSessions.SelectedRows[0].Cells["SessionName"].Value?.ToString();
                string materialLink = string.IsNullOrEmpty(txtnewMaterial.Text)
                    ? grdViewSessions.SelectedRows[0].Cells["MaterialLink"].Value?.ToString()
                    : txtnewMaterial.Text;
                string quizName = grdViewSessions.SelectedRows[0].Cells["QuizName"].Value?.ToString();
                string taskName = grdViewSessions.SelectedRows[0].Cells["TaskName"].Value?.ToString();
                string projectName = grdViewSessions.SelectedRows[0].Cells["ProjectName"].Value?.ToString();

                using (var context = new CodexDBContext())
                {
                    var session = context.Sessions.FirstOrDefault(s => s.SessionID == sessionid);
                    if (session != null)
                    {
                        session.SessionName = sessionName;
                        session.MaterialLink = materialLink;
                    }

                    var quizzes = context.Quizzes.Where(q => q.SessionID == sessionid).ToList();
                    foreach (var quiz in quizzes)
                    {
                        quiz.QuizName = quizName;
                    }

                    var tasks = context.Tasks.Where(t => t.SessionID == sessionid).ToList();
                    foreach (var task in tasks)
                    {
                        task.TaskName = taskName;
                    }

                    var projects = context.Projects.Where(p => p.SessionID == sessionid).ToList();
                    foreach (var project in projects)
                    {
                        project.ProjectName = projectName;
                    }

                    context.SaveChanges();

                    LoadSeesions();


                    MessageBox.Show("Changes saved successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new CodexDBContext())
                {
                    int sessionid = Convert.ToInt32(grdViewSessions.SelectedRows[0].Cells["SessionID"].Value);

                    var session = context.Sessions.FirstOrDefault(s => s.SessionID == sessionid);

                    if (session != null)
                    {

                        var quizzes = context.Quizzes.Where(q => q.SessionID == session.SessionID).ToList();
                        context.Quizzes.RemoveRange(quizzes);

                        var tasks = context.Tasks.Where(t => t.SessionID == session.SessionID).ToList();
                        context.Tasks.RemoveRange(tasks);

                        var projects = context.Projects.Where(p => p.SessionID == session.SessionID).ToList();
                        context.Projects.RemoveRange(projects);


                        context.SaveChanges();

                        context.Sessions.Remove(session);
                        context.SaveChanges();

                        LoadSeesions();


                        MessageBox.Show("Course and all related data deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Course not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting data: {ex.Message}");
            }
        }

        private void AttendenceForm()
        {
            Form formToOpen;
            formToOpen = new AttendenceForm();
            formToOpen.Show();

            this.Hide();
        }
        private void viewAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendenceForm();
        }

        private void SessionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
