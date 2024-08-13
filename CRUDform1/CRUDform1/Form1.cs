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
//CREATE or add new contact
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TINA\\SQLEXPRESS;Initial Catalog=CRUDform1;Integrated Security=True; ");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CMtable values(@id, @name, @phone, @address)", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully added");
        }
//READ or search a contact
        private void button2_Click(object sender, EventArgs e)
        {
        
            SqlConnection con = new SqlConnection("Data Source=TINA\\SQLEXPRESS;Initial Catalog=CRUDform1;Integrated Security=True; ");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CMtable", con);
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }
//UPDATE an information for a contact
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TINA\\SQLEXPRESS;Initial Catalog=CRUDform1;Integrated Security=True; ");
            con.Open();
            SqlCommand cmd = new SqlCommand("update CMtable set name= @name, @phone, @address where id=@id", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully updated");
        }
//DELETE a contact
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TINA\\SQLEXPRESS;Initial Catalog=CRUDform1;Integrated Security=True; ");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete CMtable where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully deleted");
        }
    }
}
