using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace FilesApp
{
    public partial class SimbolsCount : Form
    {
        string connectionString = @"Server=DESKTOP-3CVUA48\SQLEXPRESS;Database=FileHistoryDB;Trusted_Connection=True;";

        public SimbolsCount()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = dialog.FileName;
                    txtText.Text = File.ReadAllText(dialog.FileName);

                    CountSymbols();
                    SaveToDatabase(dialog.FileName, txtText.Text, txtText.Text.Length, "Открытие");
                }
            }
        }

        private void btnCountUp_Click(object sender, EventArgs e)
        {
            CountSymbols();
        }

        private void CountSymbols()
        {
            int count = txtText.Text.Length;
            txtCount.Text = count.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                File.WriteAllText(txtPath.Text, txtText.Text);

                SaveToDatabase(txtPath.Text, txtText.Text, txtText.Text.Length, "Сохранение");

                MessageBox.Show("Файл сохранён");
            }
            else
            {
                MessageBox.Show("Сначала откройте файл");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtText.Clear();
            txtCount.Clear();
            txtPath.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SaveToDatabase(string filePath, string content, int symbolCount, string operationType)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO FileOperations 
                    (FilePath, Content, SymbolCount, OperationType) 
                    VALUES (@FilePath, @Content, @SymbolCount, @OperationType)";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FilePath", filePath ?? "Без пути");
                        cmd.Parameters.AddWithValue("@Content", content ?? "");
                        cmd.Parameters.AddWithValue("@SymbolCount", symbolCount);
                        cmd.Parameters.AddWithValue("@OperationType", operationType);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}