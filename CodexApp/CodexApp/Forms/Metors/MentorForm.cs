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

namespace CodexApp
{
    public partial class MentorForm : Form
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=true";
        private ToolTip toolTip;
        public MentorForm()
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
                   SELECT concat (Courses.Name, Courses.RoundNumber) AS Course, Mentors.MentorID ,Mentors.Name AS Mentor, Mentors.MonthlyEvaluation
                    FROM     Courses INNER JOIN
                  Mentors ON Courses.MentorID = Mentors.MentorID
";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StyleDataGridView(grdViewMentors);
                    grdViewMentors.DataSource = null;
                    grdViewMentors.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Courses: {ex.Message}");
            }
        }

        private void MentorForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadMentors();
            toolTip.SetToolTip(btnAdd, "Click to add a new Mentor.");
            toolTip.SetToolTip(btnUpdata, "Click to update Update a Mentor's evaluation for the selected Mentor.");
            toolTip.SetToolTip(btnDelete, "Click to delete the selected Mentor.");
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

        private bool ValidateMentor()
        {
            if (!Validator.IsRequired(txtMentorName.Text, "Mentor Name"))
                return false;

            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateMentor()) return;
            using (var context = new CodexDBContext())
            {
                var mentor = new Mentor()
                {
                    Name = txtMentorName.Text,
                    MonthlyEvaluation = null
                };
                context.Mentors.Add(mentor);
                context.SaveChanges();
                LoadMentors();

                MessageBox.Show("Mentor added successfully.");
            }
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            int rowIndex = grdViewMentors.CurrentCell?.RowIndex ?? -1;

            try
            {
                if (rowIndex >= 0)
                {
                    int mentorID = Convert.ToInt32(grdViewMentors.SelectedRows[0].Cells["MentorID"].Value);

                    using (var context = new CodexDBContext())
                    {
                        var mentor = context.Mentors.FirstOrDefault(m => m.MentorID == mentorID);

                        if (mentor != null)
                        {

                            mentor.MonthlyEvaluation = grdViewMentors.SelectedRows[0].Cells["MonthlyEvaluation"].Value.ToString();


                            context.SaveChanges();
                            LoadCourses();
                            LoadMentors();

                            MessageBox.Show("Mentor updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show($"Mentor not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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



                    cmbMentors.DataSource = dt;
                    cmbMentors.DisplayMember = "Name";
                    cmbMentors.ValueMember = "MentorID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Students: {ex.Message}");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int mentorID = Convert.ToInt32(cmbMentors.SelectedValue);
            using (var context = new CodexDBContext())
            {
                var mentor = context.Mentors.FirstOrDefault(m => m.MentorID == mentorID);

                context.Mentors.Remove(mentor); context.SaveChanges();
                LoadCourses();
                LoadMentors();

                MessageBox.Show("Mentor removed successfully.");
            }
        }

        private void MentorForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
