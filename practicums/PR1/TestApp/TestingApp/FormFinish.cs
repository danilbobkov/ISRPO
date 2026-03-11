using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestingApp
{
    public partial class FormFinish : Form
    {
        private string connectionString = @"Data Source=DESKTOP-3CVUA48\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True";
        private int userId;
        private bool isClosingConfirmed = false;

        public FormFinish(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FormFinish_Load(object sender, EventArgs e)
        {
            LoadCurrentResult();
            LoadHistory();
        }

        private void LoadCurrentResult()
        {
            string query = "SELECT FirstName, LastName, StartTime, EndTime, Score FROM Users WHERE Id = @UserId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string firstName = reader.GetString(0);
                        string lastName = reader.GetString(1);
                        DateTime start = reader.GetDateTime(2);
                        DateTime end = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3);
                        int score = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

                        lblName.Text = $"{firstName} {lastName}";
                        lblResult.Text = $"Результат: {score} / 15";
                        lblTimeInfo.Text = $"Начало: {start:dd.MM.yyyy HH:mm}  Окончание: {end:dd.MM.yyyy HH:mm}";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки результата: " + ex.Message);
                }
            }
        }

        private void LoadHistory()
        {
            string query = "SELECT StartTime AS 'Начало', EndTime AS 'Конец', Score AS 'Баллы' FROM Users WHERE Id = @UserId ORDER BY StartTime DESC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                DataTable dt = new DataTable();
                try
                {
                    adapter.Fill(dt);
                    dgvHistory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки истории: " + ex.Message);
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите пройти тест заново?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FormStart startForm = new FormStart();
                startForm.Show();
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!isClosingConfirmed && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    isClosingConfirmed = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }
    }
}