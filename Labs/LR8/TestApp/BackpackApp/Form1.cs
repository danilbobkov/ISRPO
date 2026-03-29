using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using BackpackApp.Models;

namespace BackpackApp
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=DESKTOP-3CVUA48\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private List<Item> LoadItems()
        {
            var items = new List<Item>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Name, Weight, Cost FROM objects";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            Name = reader.GetString(0),
                            Weight = reader.GetInt32(1),
                            Cost = reader.GetInt32(2)
                        });
                    }
                }
            }

            return items;
        }

        private void ShowItems(List<Item> items)
        {
            listView1.Items.Clear();

            foreach (var item in items)
            {
                var row = new ListViewItem(item.Name);
                row.SubItems.Add(item.Weight.ToString());
                row.SubItems.Add(item.Cost.ToString());
                listView1.Items.Add(row);
            }
        }

        // КНОПКА "Показать данные"
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var items = LoadItems();
            ShowItems(items);
        }

        // КНОПКА "Решить"
        private void btnSolve_Click(object sender, EventArgs e)
        {
            int maxWeight = int.Parse(textBox1.Text);
            var items = LoadItems();

            var bestSet = SolveKnapsack(items, maxWeight);

            ShowItems(bestSet);
        }

        // Решение задачи (полный перебор)
        private List<Item> SolveKnapsack(List<Item> items, int maxWeight)
        {
            List<Item> best = new List<Item>();
            int bestCost = 0;

            int n = items.Count;

            // перебор всех комбинаций
            for (int i = 0; i < (1 << n); i++)
            {
                int totalWeight = 0;
                int totalCost = 0;
                List<Item> subset = new List<Item>();

                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        totalWeight += items[j].Weight;
                        totalCost += items[j].Cost;
                        subset.Add(items[j]);
                    }
                }

                if (totalWeight <= maxWeight && totalCost > bestCost)
                {
                    bestCost = totalCost;
                    best = subset;
                }
            }

            return best;
        }
    }
}