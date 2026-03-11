using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestingApp
{
    public partial class FormStart : Form
    {
        private string connectionString = @"Data Source=DESKTOP-3CVUA48\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True";

        public FormStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Пожалуйста, введите имя и фамилию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = SaveUserToDatabase(firstName, lastName);
            if (userId == -1)
            {
                MessageBox.Show("Ошибка при сохранении данных пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormQuestions questionsForm = new FormQuestions(userId);
            questionsForm.Show();
            this.Hide();
        }

        private int SaveUserToDatabase(string firstName, string lastName)
        {
            int userId = -1;
            string query = "INSERT INTO Users (FirstName, LastName, StartTime) VALUES (@FirstName, @LastName, @StartTime); SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@StartTime", DateTime.Now);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        userId = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка базы данных: " + ex.Message);
                }
            }
            return userId;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }
    }
}