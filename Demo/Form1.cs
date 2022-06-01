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
    public partial class Form1 : Form
    {
        public string connStr = @"Data Source=LAPTOP-K4IS21DB\SQLEXPRESS;Initial Catalog=WSR;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"Select IdUsera, Login, Password, Role FROM [User2] WHERE Login = '{textBox1.Text}' AND Password = '{textBox2.Text}'", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                //Form2 form = new Form2();
                //form.Show();

                if(ds.Tables[0].Rows[0].Field<int>(ds.Tables[0].Columns[3]) == 2) 
                {
                        Form3 form3 = new Form3();
                    form3.Show();

                }
                if(ds.Tables[0].Rows[0].Field<int>(ds.Tables[0].Columns[3]) == 1)
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Нет такого пользователя!");
            }
            finally
            {
                connection.Close();
            }


        }
    }
}
