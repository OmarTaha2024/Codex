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

        public MentorForm()
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
                   SELECT concat (Courses.Name, Courses.RoundNumber) AS Course, Mentors.Name AS Mentor, Mentors.MonthlyEvaluation
                    FROM     Courses INNER JOIN
                  Mentors ON Courses.MentorID = Mentors.MentorID
";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

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
    }
}
