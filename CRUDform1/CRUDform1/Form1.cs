using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDform1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TINA\\SQLEXPRESS;Initial Catalog=CRUDform1;Integrated Security=True; ");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Table_1 values(@id, @name, @phone, @email)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@email", textBox4.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TINA\\SQLEXPRESS;Initial Catalog=CRUDform1;Integrated Security=True; ");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Table_1 set name= @name, @phone, @email where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@email", textBox4.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TINA\\SQLEXPRESS;Initial Catalog=CRUDform1;Integrated Security=True; ");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Table_1 where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully deleted");
        }
    }
}
