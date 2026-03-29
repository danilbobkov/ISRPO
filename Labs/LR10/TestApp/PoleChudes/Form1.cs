using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PoleChudes
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=DESKTOP-3CVUA48\SQLEXPRESS;Initial Catalog=PoleChudesDB;Integrated Security=True";

        string currentWord = "";
        List<char> shuffledLetters = new List<char>();
        Stack<string> history = new Stack<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            currentWord = GetRandomWord().ToUpper();
            shuffledLetters = Shuffle(currentWord.ToList());

            flowLetters.Controls.Clear();
            txtResult.Text = "";
            history.Clear();

            foreach (char c in shuffledLetters)
            {
                Button btn = new Button();
                btn.Text = c.ToString();
                btn.Width = 40;
                btn.Height = 40;
                btn.Click += Letter_Click;
                flowLetters.Controls.Add(btn);
            }

            lblInfo.Text = $"Длина слова: {currentWord.Length}";
        }

        private string GetRandomWord()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 Word FROM Words ORDER BY NEWID()", conn);
                return cmd.ExecuteScalar().ToString();
            }
        }

        private List<char> Shuffle(List<char> list)
        {
            Random rnd = new Random();
            return list.OrderBy(x => rnd.Next()).ToList();
        }

        private void Letter_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            history.Push(txtResult.Text);

            txtResult.Text += btn.Text;
            btn.Enabled = false;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (history.Count > 0)
            {
                txtResult.Text = history.Pop();

                foreach (Button btn in flowLetters.Controls)
                    btn.Enabled = true;

                // заново блокируем уже использованные буквы
                foreach (char c in txtResult.Text)
                {
                    foreach (Button btn in flowLetters.Controls)
                    {
                        if (btn.Text == c.ToString() && btn.Enabled)
                        {
                            btn.Enabled = false;
                            break;
                        }
                    }
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string userWord = txtResult.Text.ToUpper().Replace('Ё', 'Е');
            string correctWord = currentWord.Replace('Ё', 'Е');

            if (userWord == correctWord)
                MessageBox.Show("Правильно!");
            else
                MessageBox.Show("Неправильно!");
        }
    }
}