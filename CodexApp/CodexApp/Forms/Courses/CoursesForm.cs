using CodexApp.Codex_Classes;
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
using static System.Collections.Specialized.BitVector32;

namespace CodexApp
{
    public partial class CoursesForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";
        private ToolTip toolTip;
        public CoursesForm()
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
    SELECT 
        CONCAT(Courses.Name,' - ',Courses.RoundNumber) AS Course_Name,
Courses.MarketingCost,
Courses.SalesCost,
Courses.InstCost,
Courses.MentorCost,
Courses.WorkSpaceCost,
Courses.StartDate,
Courses.EndDate,
        Courses.TotalCost,
        Mentors.Name AS MentorName,
        Instructors.Name AS InstructorName,
        COUNT(Enrollments.StudentID) AS StudentCount
    FROM Courses
    INNER JOIN Instructors ON Courses.InstructorID = Instructors.InstructorID
    INNER JOIN Mentors ON Courses.MentorID = Mentors.MentorID
    LEFT JOIN Enrollments ON Enrollments.CourseID = Courses.CourseID And Enrollments.RoundNumber = Courses.RoundNumber
    GROUP BY 
        Courses.Name,
        Courses.RoundNumber,
        Courses.TotalCost,
        Mentors.Name,
        Instructors.Name,
		Courses.MarketingCost,
Courses.SalesCost,
Courses.InstCost,
Courses.MentorCost,
Courses.WorkSpaceCost,
Courses.StartDate,
Courses.EndDate;
";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewCourses);
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
            LoadInstructors();
            LoadPaymentTypes();
            LoadMentors();
            toolTip.SetToolTip(btnAdd, "Click to add a new Course.");
            toolTip.SetToolTip(btnSave, "Click to Update Course Name & MarketingCost & SalesCost & InstCost & MentorCost & WorkSpaceCost & MentorName & InstructorName for the selected Course.");
            toolTip.SetToolTip(btnDelete, "Click to delete the selected Course.");
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

        private void LoadInstructors()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                     SELECT Name, InstructorID
                         FROM Instructors";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);




                    cmbCourseInst.DataSource = dt;
                    cmbCourseInst.DisplayMember = "Name";
                    cmbCourseInst.ValueMember = "InstructorID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Students: {ex.Message}");
            }
        }

        private void LoadMentors()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                     SELECT Name, MentorID
                         FROM Mentors";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);




                    cmbCourseMentor.DataSource = dt;
                    cmbCourseMentor.DisplayMember = "Name";
                    cmbCourseMentor.ValueMember = "MentorID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Students: {ex.Message}");
            }
        }
        private void LoadPaymentTypes()
        {
            var courseType = new List<string> { "Online", "Offline", "Hyprid" };
            cmbCoursetype.DataSource = courseType;
        }
        private bool ValidateCourse()
        {
            if (!Validator.IsRequired(txtCourseName.Text, "Course Name")) return false;
            if (!Validator.IsComboBoxSelected(cmbCourseInst, "Instructor")) return false;
            if (!Validator.IsComboBoxSelected(cmbCourseMentor, "Mentor")) return false;
            if (!Validator.IsDateRangeValid(dptstartdata.Value, dptenddata.Value)) return false;

            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtRound.Text, out int round))
                {
                    MessageBox.Show("Round must be a valid number.");
                    return;
                }

                if (!decimal.TryParse(txtMaketingCost.Text, out decimal maketingCost) ||
                    !decimal.TryParse(txtSalesCost.Text, out decimal salesCost) ||
                    !decimal.TryParse(txtinstCost.Text, out decimal instCost) ||
                    !decimal.TryParse(txtmentorCost.Text, out decimal mentorCost) ||
                    !decimal.TryParse(txtWorkspace.Text, out decimal workspace))
                {
                    MessageBox.Show("Costs must be valid decimal values.");
                    return;
                }

                if (!ValidateCourse()) return;
                string courseName = txtCourseName.Text;
                int instId = Convert.ToInt32(cmbCourseInst.SelectedValue);
                int mentorId = Convert.ToInt32(cmbCourseMentor.SelectedValue);

                using (var context = new CodexDBContext())
                {
                    var course = new Course()
                    {
                        RoundNumber = round,
                        Name = courseName,
                        Type = cmbCoursetype.Text,
                        MarketingCost = maketingCost,
                        SalesCost = salesCost,
                        InstCost = instCost,
                        MentorCost = mentorCost,
                        WorkSpaceCost = workspace,
                        StartDate = dptstartdata.Value,
                        EndDate = dptenddata.Value,
                        InstructorID = instId,
                        MentorID = mentorId
                    };

                    context.Courses.Add(course);
                    context.SaveChanges();


                    for (int i = 1; i <= 24; i++)
                    {
                        var session = new Session()
                        {
                            SessionName = $"Session {i}",
                            CourseID = course.CourseID,
                            RoundNumber = course.RoundNumber,
                            MaterialLink = null
                        };
                        context.Sessions.Add(session);
                    }
                    context.SaveChanges();

                    var sessions = context.Sessions
               .Where(s => s.CourseID == course.CourseID && s.RoundNumber == course.RoundNumber)
               .ToList();

                    foreach (var session in sessions)
                    {
                        var newQuiz = new Quiz
                        {
                            QuizName = "No Quiz",
                            EnrollmentID = null,
                            Grade = 0,
                            SessionID = session.SessionID
                        };
                        context.Quizzes.Add(newQuiz);
                        context.SaveChanges();
                        var newTask = new CodexApp.Entities.Task
                        {
                            TaskName = "No Task",
                            EnrollmentID = null,
                            Grade = 0,
                            SessionID = session.SessionID
                        };
                        context.Tasks.Add(newTask);
                        context.SaveChanges();
                        var newProject = new Project
                        {
                            ProjectName = "No Project",
                            EnrollmentID = null,
                            Grade = 0,
                            SessionID = session.SessionID
                        };
                        context.Projects.Add(newProject);
                        context.SaveChanges();

                    }
                    LoadCourses();
                    MessageBox.Show("Course, sessions, and related records added successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting data: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewCourses.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (grdViewCourses.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a course to save changes.");
                    return;
                }

                string courseName = grdViewCourses.SelectedRows[0].Cells["Course_Name"].Value.ToString().Split('-')[0];
                decimal.TryParse(grdViewCourses.SelectedRows[0].Cells["MarketingCost"].Value?.ToString(), out decimal marketingCost);
                decimal.TryParse(grdViewCourses.SelectedRows[0].Cells["SalesCost"].Value?.ToString(), out decimal salesCost);
                decimal.TryParse(grdViewCourses.SelectedRows[0].Cells["InstCost"].Value?.ToString(), out decimal instCost);
                decimal.TryParse(grdViewCourses.SelectedRows[0].Cells["MentorCost"].Value?.ToString(), out decimal mentorCost);
                decimal.TryParse(grdViewCourses.SelectedRows[0].Cells["WorkSpaceCost"].Value?.ToString(), out decimal workSpaceCost);

                string mentorName = grdViewCourses.SelectedRows[0].Cells["MentorName"].Value?.ToString();
                string instructorName = grdViewCourses.SelectedRows[0].Cells["InstructorName"].Value?.ToString();

                using (var context = new CodexDBContext())
                {
                    var course = context.Courses.FirstOrDefault(c => c.Name == courseName);
                    if (course == null)
                    {
                        MessageBox.Show($"Course '{courseName}' not found.");
                        return;
                    }

                    var mentor = context.Mentors.FirstOrDefault(m => m.Name == mentorName);
                    if (mentor == null)
                    {
                        MessageBox.Show($"Mentor '{mentorName}' not found.");
                        return;
                    }

                    var instructor = context.Instructors.FirstOrDefault(i => i.Name == instructorName);
                    if (instructor == null)
                    {
                        MessageBox.Show($"Instructor '{instructorName}' not found.");
                        return;
                    }

                    course.MarketingCost = marketingCost;
                    course.SalesCost = salesCost;
                    course.InstCost = instCost;
                    course.MentorCost = mentorCost;
                    course.WorkSpaceCost = workSpaceCost;
                    course.MentorID = mentor.MentorID;
                    course.InstructorID = instructor.InstructorID;

                    context.SaveChanges();
                    LoadCourses();

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
                    string courseName = grdViewCourses.SelectedRows[0].Cells["Course_Name"].Value.ToString().Split('-')[0];

                    var course = context.Courses.FirstOrDefault(c => c.Name == courseName);

                    if (course != null)
                    {
                        var sessions = context.Sessions.Where(s => s.CourseID == course.CourseID && s.RoundNumber == course.RoundNumber).ToList();

                        foreach (var session in sessions)
                        {
                            var quizzes = context.Quizzes.Where(q => q.SessionID == session.SessionID).ToList();
                            context.Quizzes.RemoveRange(quizzes);

                            var tasks = context.Tasks.Where(t => t.SessionID == session.SessionID).ToList();
                            context.Tasks.RemoveRange(tasks);

                            var projects = context.Projects.Where(p => p.SessionID == session.SessionID).ToList();
                            context.Projects.RemoveRange(projects);
                        }

                        context.SaveChanges();

                        context.Courses.Remove(course);
                        context.SaveChanges();

                        LoadCourses();

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

        private void CoursesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
