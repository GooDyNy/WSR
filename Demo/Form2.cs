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

namespace Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Data();
        }

        public string connStr = @"Data Source=LAPTOP-K4IS21DB\SQLEXPRESS;Initial Catalog=WSR;Integrated Security=True";

        public void Data()
        {
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * FROM [User2]", connection);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            textBox1.Text = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[1]);
            textBox2.Text = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[2]);
            int role = ds.Tables[0].Rows[0].Field<int>(ds.Tables[0].Columns[3]);
            string role2 = Convert.ToString(role);   
            textBox3.Text = role2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO User2 (Login, Password, Role) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')", connection);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Good");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"UPDATE User2 SET Login = '{textBox1.Text}', Password='{textBox2.Text}', Role='{textBox3.Text}' WHERE IdUsera={dataGridView1.CurrentRow.Cells[0].Value}", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("GooDyNy!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"DELETE From User2 WHERE IdUsera={dataGridView1.CurrentRow.Cells[0].Value}", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Bingo");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Login LIKE '%{textBox4.Text}%'";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Login"], ListSortDirection.Ascending);
        }
    }
}
