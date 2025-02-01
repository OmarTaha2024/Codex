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
    public partial class InstructorForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";
        private ToolTip toolTip;
        public InstructorForm()
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
        private void LoadCourses()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT concat (Courses.Name, Courses.RoundNumber) As Course, Instructors.InstructorID,Instructors.Name AS Insructor, Instructors.MonthlyEvaluation
                    FROM     Courses INNER JOIN
                  Instructors ON Courses.InstructorID = Instructors.InstructorID
";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewInstructor);
                    grdViewInstructor.DataSource = null;
                    grdViewInstructor.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Courses: {ex.Message}");
            }
        }

        private void InstructorForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadInstructors();
            toolTip.SetToolTip(btnAdd, "Click to add a new instructor.");
            toolTip.SetToolTip(btnUpdata, "Click to update Update an Instructor's evaluation for the selected instructor.");
            toolTip.SetToolTip(btnDelete, "Click to delete the selected instructor.");
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
        private bool ValidateInstructor()
        {
            if (!Validator.IsRequired(txtInstName.Text, "Instructor Name"))
                return false;

            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInstructor()) return;
            using (var context = new CodexDBContext())
            {
                var instructor = new Instructor()
                {
                    Name = txtInstName.Text,
                    MonthlyEvaluation = null
                };
                context.Instructors.Add(instructor);
                context.SaveChanges();
                LoadInstructors();

                MessageBox.Show("Instructor added successfully.");
            }
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



                    cmbInstructors.DataSource = dt;
                    cmbInstructors.DisplayMember = "Name";
                    cmbInstructors.ValueMember = "InstructorID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Students: {ex.Message}");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int instructid = Convert.ToInt32(cmbInstructors.SelectedValue);
            using (var context = new CodexDBContext())
            {
                var instructor = context.Instructors.FirstOrDefault(i => i.InstructorID == instructid);
                context.Instructors.Remove(instructor); context.SaveChanges();
                LoadCourses();
                LoadInstructors();

                MessageBox.Show("Instructor removed successfully.");
            }
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewInstructor.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (rowIndex >= 0)
                {
                    int instructid = Convert.ToInt32(grdViewInstructor.SelectedRows[0].Cells["InstructorID"].Value);

                    using (var context = new CodexDBContext())
                    {
                        var instructor = context.Instructors.FirstOrDefault(i => i.InstructorID == instructid);

                        if (instructor != null)
                        {

                            instructor.MonthlyEvaluation = grdViewInstructor.SelectedRows[0].Cells["MonthlyEvaluation"].Value.ToString();


                            context.SaveChanges();
                            LoadCourses();
                            LoadInstructors();
                            MessageBox.Show("instructor updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show($"instructor not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void InstructorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
