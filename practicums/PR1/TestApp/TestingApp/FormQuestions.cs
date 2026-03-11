using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestingApp
{
    public partial class FormQuestions : Form
    {
        private string connectionString = @"Data Source=DESKTOP-3CVUA48\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True";
        private int userId;
        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int totalQuestions = 15;
        private int timeLeft = 1500; // 25 минут
        private int[] userAnswers;

        public FormQuestions(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            userAnswers = new int[totalQuestions];
            questions = new List<Question>();
        }

        private void FormQuestions_Load(object sender, EventArgs e)
        {
            LoadQuestions();
            if (questions.Count == 0)
            {
                MessageBox.Show("Нет вопросов в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            totalQuestions = questions.Count;
            lblQuestionNumber.Text = $"Вопрос 1 из {totalQuestions}";
            DisplayQuestion(0);
            timer.Start();
        }

        private void LoadQuestions()
        {
            string query = "SELECT Id, QuestionText, Option1, Option2, Option3, Option4, CorrectOption FROM Questions";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            Id = reader.GetInt32(0),
                            Text = reader.GetString(1),
                            Options = new string[] {
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5)
                            },
                            CorrectOption = reader.GetInt32(6)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки вопросов: " + ex.Message);
                }
            }
        }

        private void DisplayQuestion(int index)
        {
            if (index < 0 || index >= questions.Count) return;
            var q = questions[index];
            lblQuestion.Text = q.Text;
            rbOption1.Text = q.Options[0];
            rbOption2.Text = q.Options[1];
            rbOption3.Text = q.Options[2];
            rbOption4.Text = q.Options[3];

            if (userAnswers[index] > 0)
            {
                switch (userAnswers[index])
                {
                    case 1: rbOption1.Checked = true; break;
                    case 2: rbOption2.Checked = true; break;
                    case 3: rbOption3.Checked = true; break;
                    case 4: rbOption4.Checked = true; break;
                }
            }
            else
            {
                rbOption1.Checked = rbOption2.Checked = rbOption3.Checked = rbOption4.Checked = false;
            }

            lblQuestionNumber.Text = $"Вопрос {index + 1} из {questions.Count}";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int selected = 0;
            if (rbOption1.Checked) selected = 1;
            else if (rbOption2.Checked) selected = 2;
            else if (rbOption3.Checked) selected = 3;
            else if (rbOption4.Checked) selected = 4;

            if (selected == 0)
            {
                MessageBox.Show("Выберите вариант ответа.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            userAnswers[currentQuestionIndex] = selected;

            if (currentQuestionIndex == questions.Count - 1)
                FinishTest();
            else
            {
                currentQuestionIndex++;
                DisplayQuestion(currentQuestionIndex);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft <= 0)
            {
                timer.Stop();
                MessageBox.Show("Время вышло! Тест будет завершен.", "Время истекло", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FinishTest();
            }
            else
            {
                TimeSpan time = TimeSpan.FromSeconds(timeLeft);
                lblTimer.Text = $"{time.Minutes:D2}:{time.Seconds:D2} осталось";
            }
        }

        private void FinishTest()
        {
            timer.Stop();
            int score = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                if (userAnswers[i] == questions[i].CorrectOption)
                    score++;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Обновление Users
                    string updateUser = "UPDATE Users SET EndTime = @EndTime, Score = @Score WHERE Id = @UserId";
                    SqlCommand cmdUpdate = new SqlCommand(updateUser, conn, transaction);
                    cmdUpdate.Parameters.AddWithValue("@EndTime", DateTime.Now);
                    cmdUpdate.Parameters.AddWithValue("@Score", score);
                    cmdUpdate.Parameters.AddWithValue("@UserId", userId);
                    cmdUpdate.ExecuteNonQuery();

                    // Сохранение ответов
                    for (int i = 0; i < questions.Count; i++)
                    {
                        string insertAnswer = "INSERT INTO UserAnswers (UserId, QuestionId, SelectedOption) VALUES (@UserId, @QuestionId, @SelectedOption)";
                        SqlCommand cmdInsert = new SqlCommand(insertAnswer, conn, transaction);
                        cmdInsert.Parameters.AddWithValue("@UserId", userId);
                        cmdInsert.Parameters.AddWithValue("@QuestionId", questions[i].Id);
                        cmdInsert.Parameters.AddWithValue("@SelectedOption", userAnswers[i]);
                        cmdInsert.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Ошибка сохранения результатов: " + ex.Message);
                }
            }

            FormFinish finishForm = new FormFinish(userId);
            finishForm.Show();
            Close();
        }

        private void FormQuestions_FormClosing(object sender, FormClosingEventArgs e) { }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string[] Options { get; set; }
        public int CorrectOption { get; set; }
    }
}