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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        readonly SqlConnection con = new(@"Data Source=DESKTOP-TKJHI8I;Initial Catalog=AvengersDB;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            {
                con.Open();
                MessageBox.Show("Connecté !");
                string query = "INSERT INTO Organisations (Id_Organisations,Nom_Organisations,Adresse_Organisations,CodePostale_Organisations,Ville_Organisations,Dirigeant_Organisations,Commentaire_Organisations,DateAjout_Organisations,DateDerniereModification_Organisations,NombreIncidentsDeclares_Organisations,NombreMissionsOrganisationsImplique_Organisations) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";
                SqlDataAdapter SDA = new(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INSERTION REUSSI ! ! !");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT *  FROM Organisations";
            SqlDataAdapter SDA = new(query, con);
            DataTable dt = new();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE Organisations SET Nom_Organisations = '" + textBox2.Text + "',Adresse_Organisations='" + textBox3.Text + "',CodePostale_Organisations='" + textBox4.Text + "',Ville_Organisations='" + textBox5.Text + "',Dirigeant_Organisations='" + textBox6.Text + "',Commentaire_Organisations='" + textBox7.Text + "',DateAjout_Organisations='" + textBox8.Text + "',DateDerniereModification_Organisations='" + textBox9.Text + "',NombreIncidentsDeclares_Organisations='" + textBox10.Text + "',NombreMissionsOrganisationsImplique_Organisations='" + textBox11.Text + "' WHERE Id_Organisations = '" + textBox1.Text + "'";
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
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM Organisations where Id_Organisations = '" + textBox1.Text + "'";
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
