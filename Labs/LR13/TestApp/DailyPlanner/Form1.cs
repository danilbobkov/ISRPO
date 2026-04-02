using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DailyPlanner
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=DESKTOP-3CVUA48\SQLEXPRESS;Database=DailyPlannerDB;Trusted_Connection=True;";
        int selectedNoteId = -1;

        public Form1()
        {
            InitializeComponent();
            LoadNotes();
        }

        private void LoadNotes()
        {
            listBoxNotes.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Id, NoteDate, NoteText 
                                 FROM Notes 
                                 WHERE CAST(NoteDate AS DATE) = @date
                                 ORDER BY NoteDate";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", monthCalendar1.SelectionStart.Date);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    listBoxNotes.Items.Add("Нет заметок на этот день");
                    return;
                }

                while (reader.Read())
                {
                    DateTime dt = (DateTime)reader["NoteDate"];
                    string text = reader["NoteText"].ToString();

                    string display = $"{dt:HH:mm} - {TrimText(text)}";

                    listBoxNotes.Items.Add(new NoteItem
                    {
                        Id = (int)reader["Id"],
                        Display = display,
                        FullText = text,
                        Time = dt
                    });
                }
            }
        }

        private string TrimText(string text)
        {
            return text.Length > 60 ? text.Substring(0, 60) + "..." : text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Введите текст заметки!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                DateTime date = monthCalendar1.SelectionStart.Date + timePicker.Value.TimeOfDay;

                string query = "INSERT INTO Notes (NoteDate, NoteText) VALUES (@date, @text)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@text", txtNote.Text.Trim());

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Заметка успешно добавлена!");
            ClearForm();
            LoadNotes();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedNoteId == -1)
            {
                MessageBox.Show("Сначала выберите заметку!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Введите текст заметки!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                DateTime date = monthCalendar1.SelectionStart.Date + timePicker.Value.TimeOfDay;

                string query = "UPDATE Notes SET NoteDate=@date, NoteText=@text WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@text", txtNote.Text.Trim());
                cmd.Parameters.AddWithValue("@id", selectedNoteId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Заметка обновлена!");
            ClearForm();
            LoadNotes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedNoteId == -1)
            {
                MessageBox.Show("Выберите заметку!");
                return;
            }

            if (MessageBox.Show("Удалить заметку?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Notes WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedNoteId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Удалено!");
            ClearForm();
            LoadNotes();
        }

        private void listBoxNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedItem is NoteItem item)
            {
                selectedNoteId = item.Id;
                txtNote.Text = item.FullText;
                timePicker.Value = item.Time;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadNotes();
        }

        private void ClearForm()
        {
            txtNote.Clear();
            timePicker.Value = DateTime.Now;
            selectedNoteId = -1;
        }
    }

    public class NoteItem
    {
        public int Id { get; set; }
        public string Display { get; set; }
        public string FullText { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}