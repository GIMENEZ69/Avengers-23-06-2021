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
    public partial class SuperVilains : Form
    {
        public SuperVilains()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new(@"Data Source=DESKTOP-TKJHI8I;Initial Catalog=AvengersDB;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            MessageBox.Show("Connecté !");
            string query = "INSERT INTO SuperVilains (Id_SuperVilains,Nom_SuperVilains,Degats_SuperVilains,Commentaire_SuperVilains) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            SqlDataAdapter SDA = new(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTION REUSSI ! ! !");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT *  FROM SuperVilains";
            SqlDataAdapter SDA = new(query, con);
            DataTable dt = new();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE SuperVilains SET Nom_SuperVilains = '" + textBox2.Text + "',Degats_SuperVilains='" + textBox3.Text + "',Commentaire_SuperVilains='" + textBox4.Text + "' WHERE Id_SuperVilains = '" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Modification réussi ! !");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM SuperVilains where Id_SuperVilains = '" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Identifiant supprimer :");
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
