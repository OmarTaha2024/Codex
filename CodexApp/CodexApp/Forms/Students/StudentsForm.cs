using CodexApp.Codex_Classes;
using CodexApp.CodexContext;
using CodexApp.Entities;
using Microsoft.EntityFrameworkCore;
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
        int courseId; int roundNumber;
        private int SessionId;
        private ToolTip toolTip;
        public StudentsForm()
        {
            InitializeComponent();
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
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
        private void LoadStudent()
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
                Instructors.Name AS Instructor,
                Mentors.Name AS Mentor
                FROM Enrollments
                INNER JOIN Courses ON Enrollments.CourseID = Courses.CourseID AND Enrollments.RoundNumber = Courses.RoundNumber
                INNER JOIN Instructors ON Courses.InstructorID = Instructors.InstructorID
                INNER JOIN Mentors ON Courses.MentorID = Mentors.MentorID
                INNER JOIN Students ON Enrollments.StudentID = Students.StudentID 
                WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    StyleDataGridView(grdViewStudents);
                    grdViewStudents.DataSource = null;
                    grdViewStudents.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
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
                WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber  And Sessions.SessionID = @sessionid
                 And Quizzes.SessionID = @sessionid And Tasks.SessionID = @sessionid And Projects.SessionID = @sessionid
";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@sessionid", SessionId);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewStudents);


                    grdViewStudents.DataSource = null;
                    grdViewStudents.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
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
            FROM Sessions
Where Sessions.CourseID = @CourseID And Sessions.RoundNumber = @RoundNumber
            ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmbSession.SelectedIndexChanged -= cmbSession_SelectedIndexChanged;
                    cmbSession.DataSource = null;

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

        private void cmbCousres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCousres.SelectedValue != null)
            {
                string selectedValue = cmbCousres.SelectedValue.ToString();
                string[] values = selectedValue.Split('-');
                if (values.Length == 2)
                {
                    courseId = Convert.ToInt32(values[0]);
                    roundNumber = Convert.ToInt32(values[1]);
                    LoadSessions();
                    LoadStudents();
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
            LoadPaymentTypes();
            LoadStudents();
            toolTip.SetToolTip(btnAdd, "Click to add a new Student to the selected Course .");
            toolTip.SetToolTip(btnUpdata, "Click to update Attendence and all Grades for  the selected Student.");
            toolTip.SetToolTip(btnDelete, "Click to delete the selected Student .");
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
                     FROM     Enrollments INNER JOIN
                  Students ON Enrollments.StudentID = Students.StudentID
                    where Enrollments.CourseID = @CourseID and Enrollments.RoundNumber = @RoundNumber";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    cmbStudents.DataSource = null;

                    cmbStudents.DataSource = dt;
                    cmbStudents.DisplayMember = "Name";
                    cmbStudents.ValueMember = "StudentID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Students: {ex.Message}");
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
            LoadStudent();
            LoadStudents();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadStudentsWithSession();

        }
        private void LoadPaymentTypes()
        {
            var paymentTypes = new List<string> { "Cash", "installment" };
            ddlPaymentType.DataSource = paymentTypes;
        }
        private void InsertData(string studentName,
                          string phone,
                          string email,
                          string paymentType)
        {
            try
            {
                using (var context = new CodexDBContext())
                {
                    var hasStudents = context.Enrollments.Any(e => e.CourseID == courseId && e.RoundNumber == roundNumber);

                    if (!hasStudents)
                    {
                        var tasksToRemove = context.Tasks.Where(t => t.EnrollmentID == null).ToList();
                        context.Tasks.RemoveRange(tasksToRemove);

                        var projectsToRemove = context.Projects.Where(p => p.EnrollmentID == null).ToList();
                        context.Projects.RemoveRange(projectsToRemove);

                        var quizzesToRemove = context.Quizzes.Where(q => q.EnrollmentID == null).ToList();
                        context.Quizzes.RemoveRange(quizzesToRemove);

                        context.SaveChanges();
                    }

                    var student = context.Students
                        .AsNoTracking()
                        .FirstOrDefault(s => s.Email == email && s.Phone == phone);

                    if (student == null)
                    {
                        student = new Student
                        {
                            Name = studentName,
                            Phone = phone,
                            Email = email,
                            PaymentType = paymentType,
                        };
                        context.Students.Add(student);
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Entry(student).State = EntityState.Detached;
                    }

                    var enrollment = context.Enrollments
                        .FirstOrDefault(e => e.StudentID == student.StudentID && e.CourseID == courseId && e.RoundNumber == roundNumber);

                    if (enrollment == null)
                    {
                        enrollment = new Enrollment
                        {
                            StudentID = student.StudentID,
                            CourseID = courseId,
                            RoundNumber = roundNumber,
                        };
                        context.Enrollments.Add(enrollment);
                        context.SaveChanges();
                    }

                    var sessions = context.Sessions
                        .Where(s => s.CourseID == courseId && s.RoundNumber == roundNumber)
                        .ToList();

                    foreach (var session in sessions)
                    {
                        var attendance = new Attendance
                        {
                            SessionID = session.SessionID,
                            StudentID = student.StudentID,
                            IsAttended = false
                        };
                        context.Attendances.Add(attendance);

                        var quiz = new Quiz
                        {
                            QuizName = "No quiz",
                            EnrollmentID = enrollment.EnrollmentID,
                            Grade = 0,
                            SessionID = session.SessionID
                        };
                        context.Quizzes.Add(quiz);

                        var task = new CodexApp.Entities.Task
                        {
                            TaskName = "No Task",
                            EnrollmentID = enrollment.EnrollmentID,
                            Grade = 0,
                            SessionID = session.SessionID
                        };
                        context.Tasks.Add(task);

                        var project = new Project
                        {
                            ProjectName = "No project",
                            EnrollmentID = enrollment.EnrollmentID,
                            Grade = 0,
                            SessionID = session.SessionID
                        };
                        context.Projects.Add(project);
                    }

                    context.SaveChanges();

                    LoadStudents();
                    LoadStudent();

                    MessageBox.Show("Student added, enrolled in the course, and assigned all related data successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting data: {ex.Message}");
            }
        }


        private bool ValidateStudent()
        {
            if (!Validator.IsRequired(txtStudentName.Text, "Student Name")) return false;
            if (!Validator.IsRequired(txtPhone.Text, "Phone")) return false;
            if (!Validator.IsValidEmail(txtEmail.Text)) return false;
            if (!Validator.IsComboBoxSelected(ddlPaymentType, "Payment Type")) return false;

            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateStudent()) return;
            string studentName = txtStudentName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Fill All Data Please");
                return;
            }
            if (ddlPaymentType.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment type.");
                return;
            }
            string paymentType = ddlPaymentType.SelectedItem.ToString();
            InsertData(
                       studentName,
                       phone,
                       email,
                        paymentType
                        );
        }
        private void LoadCoursewithstudents(int stdid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT Students.StudentID,Students.Name AS Student_Name, Students.Phone, Students.Email,Students.PaymentType, Enrollments.GeneralGrade,Enrollments.InstructorFeedback, Instructors.Name AS Instructor, Mentors.Name AS Mentor
                   FROM     Courses INNER JOIN
                  Enrollments ON Courses.CourseID = Enrollments.CourseID AND Courses.RoundNumber = Enrollments.RoundNumber INNER JOIN
                  Instructors ON Courses.InstructorID = Instructors.InstructorID INNER JOIN
                  Mentors ON Courses.MentorID = Mentors.MentorID INNER JOIN
                  Students ON Enrollments.StudentID = Students.StudentID
                    WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber And Students.StudentID =@StudentId

";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", roundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@StudentId", stdid);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    grdViewStudents.DataSource = null;
                    grdViewStudents.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Course: {ex.Message}");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var context = new CodexDBContext())
            {
                int studentid = int.Parse(cmbStudents.SelectedValue.ToString());
                LoadCoursewithstudents(studentid);
            }
        }
        private void DeleteStudent(int studentId)
        {
            try
            {
                using (var context = new CodexDBContext())
                {
                    var student = context.Students
                        .Include(s => s.Enrollments)
                        .FirstOrDefault(s => s.StudentID == studentId);

                    if (student != null)
                    {
                        context.Students.Remove(student);
                        context.SaveChanges();
                        LoadStudents();
                        LoadStudent();


                        MessageBox.Show("Student and related enrollments/attendance removed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Student not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var context = new CodexDBContext())
            {
                int studentid = int.Parse(cmbStudents.SelectedValue.ToString());
                DeleteStudent(studentid);
                LoadStudents();

            }
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewStudents.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (rowIndex == -1)
                {
                    MessageBox.Show("Please Select Row To Update it and Check for Empty Columns");

                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        int studentId = Convert.ToInt32(grdViewStudents.SelectedRows[0].Cells["StudentID"].Value);
                        int sessionId = int.Parse(cmbSession.SelectedValue.ToString());

                        string query = @"
                          UPDATE Attendance 
                          SET IsAttended = @IsAttended
                          WHERE StudentID = @StudentID AND SessionID = @SessionID;

                         UPDATE Quizzes 
                      SET Grade =@QuizGrade
                      WHERE EnrollmentID IN (
                      SELECT EnrollmentID FROM Enrollments 
                      WHERE StudentID = @StudentID
                      ) And Quizzes.SessionID = @SessionID;


                          UPDATE Tasks 
                          SET Grade = @TaskGrade
                          WHERE EnrollmentID IN (
                              SELECT EnrollmentID FROM Enrollments 
                              WHERE StudentID = @StudentID 
                          )And Tasks.SessionID = @SessionID;

                          UPDATE Projects 
                          SET Grade = @ProjectGrade
                          WHERE EnrollmentID IN (
                              SELECT EnrollmentID FROM Enrollments 
                              WHERE StudentID = @StudentID
                          ) AND Projects.SessionID = @SessionID;
                        UPDATE Enrollments 
                    SET GeneralGrade = @GeneralGrade
                    WHERE Enrollments.StudentID = @StudentID

                      ";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", studentId);
                            cmd.Parameters.AddWithValue("@SessionID", sessionId);
                            cmd.Parameters.AddWithValue("@IsAttended", Convert.ToBoolean(grdViewStudents.SelectedRows[0].Cells["IsAttended"].Value));
                            cmd.Parameters.AddWithValue("@QuizGrade", Convert.ToDouble(grdViewStudents.SelectedRows[0].Cells["QuizGrade"].Value));
                            cmd.Parameters.AddWithValue("@TaskGrade", Convert.ToDouble(grdViewStudents.SelectedRows[0].Cells["TaskGrade"].Value));
                            cmd.Parameters.AddWithValue("@ProjectGrade", Convert.ToDouble(grdViewStudents.SelectedRows[0].Cells["ProjectGrade"].Value));
                            cmd.Parameters.AddWithValue("@GeneralGrade", Convert.ToDouble(grdViewStudents.SelectedRows[0].Cells["GeneralGrade"].Value));

                            cmd.ExecuteNonQuery();
                        }


                        MessageBox.Show("Data updated successfully!");
                        LoadStudentsWithSession();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }
        }

        private void StudentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
