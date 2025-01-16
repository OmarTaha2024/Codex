using System.Data.SqlClient;

namespace CodexApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }



        private void OpenForm(string name)
        {
            Form formToOpen;
            formToOpen = new GeneralForm();
            MessageBox.Show($"Welcome Mr \"{name}\"");
            formToOpen.Show();

            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS01;Initial catalog=CodexDB;Integrated Security=true";
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Updated query to fetch Role and DepartmentID
                    string query = "SELECT AdminID ,Name FROM Admins WHERE Email = @Username AND Password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            OpenForm(name);
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

     

     
    }
}
