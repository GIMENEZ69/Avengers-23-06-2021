using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConnecBddAvengers
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new(@"Data Source=DESKTOP-TKJHI8I;Initial Catalog=AvengersDB;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            MessageBox.Show("Connecté !");
            string query = "INSERT INTO SuperHeros (Id_SuperHeros,Nom_SuperHeros,Pouvoir_SuperHeros,PointFaible_SuperHeros,Commentaire_SuperHeros) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "')";
            SqlDataAdapter SDA = new(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTION REUSSI ! ! !");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT *  FROM SuperHeros";
            SqlDataAdapter SDA = new(query, con);
            DataTable dt = new();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE SuperHeros SET Nom_SuperHeros = '" + textBox2.Text + "',Pouvoir_SuperHeros='" + textBox3.Text + "',PointFaible_SuperHeros='" + textBox4.Text + "',Commentaire_SuperHeros='" + textBox6.Text + "' WHERE Id_SuperHeros = '" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Modification réussi ! !");
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM SuperHeros where Id_SuperHeros = '" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Identifiant supprimer :");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
