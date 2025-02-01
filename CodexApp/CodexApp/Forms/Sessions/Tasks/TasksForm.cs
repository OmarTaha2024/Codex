﻿using CodexApp.CodexContext;
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
    public partial class TasksForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";
        private int SessionId;
        private int CourseId;
        private int RoundNumber;
        private int StudentId;
        private int enrollmentID;
        private ToolTip toolTip;
        public TasksForm()
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
        private void LoadTaskswithStudents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                                              SELECT 
Tasks.TaskID,
    CONCAT(Courses.Name, '- Round ', Courses.RoundNumber) AS Course,
    Students.Name AS Student,
    Sessions.SessionID,
    Sessions.SessionName,
    Tasks.TaskName AS TaskName, 
   Tasks.Grade AS Grade 
FROM Courses
INNER JOIN Sessions 
    ON Courses.CourseID = Sessions.CourseID 
    AND Courses.RoundNumber = Sessions.RoundNumber
INNER JOIN Tasks 
    ON Sessions.SessionID = Tasks.SessionID
INNER JOIN Enrollments 
    ON Enrollments.CourseID = Courses.CourseID 
    AND Enrollments.RoundNumber = Courses.RoundNumber
INNER JOIN Students 
    ON Students.StudentID = Enrollments.StudentID
                    WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber And  
                Sessions.SessionID =@sessionID And Enrollments.StudentID = @studentID And Tasks.EnrollmentID =@enrollmentID
               ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);
                    adapter.SelectCommand.Parameters.AddWithValue("@sessionID", SessionId);
                    adapter.SelectCommand.Parameters.AddWithValue("@studentID", StudentId);
                    adapter.SelectCommand.Parameters.AddWithValue("@enrollmentID", enrollmentID);




                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewTasks);
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
                WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber
               ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewTasks);

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
                     SELECT Students.StudentID, Students.Name
                    FROM     Courses INNER JOIN
                  Enrollments ON Courses.CourseID = Enrollments.CourseID AND Courses.RoundNumber = Enrollments.RoundNumber INNER JOIN
                  Students ON Enrollments.StudentID = Students.StudentID
                   WHERE Courses.CourseID = @CourseID AND Courses.RoundNumber = @RoundNumber 
";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    adapter.SelectCommand.Parameters.AddWithValue("@CourseID", CourseId);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoundNumber", RoundNumber);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    cmbStudents.SelectedIndexChanged -= cmbStudents_SelectedIndexChanged;
                    cmbStudents.DataSource = null;

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

                    dt.Columns.Add("CompositeKey", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["CompositeKey"] = $"{row["CourseID"]}-{row["RoundNumber"]}";
                    }

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

        private void TasksForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            toolTip.SetToolTip(btnView, "Click to View Session and its Task ");
            toolTip.SetToolTip(btnViewSession, "Click to View Student in specific Session and its Task and Grade ");
            toolTip.SetToolTip(btnUpdata, "Click to Update the Task Name.");
            toolTip.SetToolTip(btnsmallUpdata, "Click to Update the Task Grade");


        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void btnViewSession_Click(object sender, EventArgs e)
        {

            LoadTaskswithStudents();
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewTasks.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (grdViewTasks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a course to save changes.");
                    return;
                }
                else
                {
                    int sessionid = Convert.ToInt32(grdViewTasks.SelectedRows[0].Cells["SessionID"].Value?.ToString());
                    string TaskName = grdViewTasks.SelectedRows[0].Cells["TaskName"].Value?.ToString();

                    using (var context = new CodexDBContext())
                    {

                        var tasks = context.Tasks
                        .Where(s => s.SessionID == sessionid)
                    .ToList();

                        foreach (var task in tasks)
                        {
                            task.TaskName = TaskName;
                            context.SaveChanges();
                        }




                        context.SaveChanges();

                        LoadTasks();


                        MessageBox.Show("Changes saved successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void btnsmallUpdata_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewTasks.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (grdViewTasks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a course to save changes.");
                    return;
                }
                else
                {
                    int taskid = Convert.ToInt32(grdViewTasks.SelectedRows[0].Cells["TaskID"].Value?.ToString());
                    decimal TaskGrade = Convert.ToDecimal(grdViewTasks.SelectedRows[0].Cells["Grade"].Value);

                    using (var context = new CodexDBContext())
                    {

                        var task = context.Tasks.FirstOrDefault(t => t.TaskID == taskid);
                        task.Grade = TaskGrade;
                        context.SaveChanges();

                        MessageBox.Show("Changes saved successfully!");
                        LoadTaskswithStudents();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void TasksForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
