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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new(@"Data Source=DESKTOP-TKJHI8I;Initial Catalog=AvengersDB;Integrated Security=True");

        private void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            MessageBox.Show("Connecté !");
            string query = "INSERT INTO Civils (Id_Civils,Nom_Civils,Prenom_Civils,Civilite_Civils,Adresse_Civils,CodePostale_Civils,Ville_Civils,Email_Civils,NumTel_Civils,DateDeNaissance_Civils,Nationalite_Civils,DateDeDeces_Civils,AppartenanceOrganisation_Civils,Commentaire_Civils,DateAjout_Civils,DateDeDerniereModification_Civils) VALUES ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text+"')";
            SqlDataAdapter SDA = new(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTION REUSSI ! ! !");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT *  FROM Civils";
            SqlDataAdapter SDA = new(query, con);
            DataTable dt = new();
            SDA.Fill(dt);
            dgv1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE Civils SET Nom_Civils = '" + textBox2.Text + "',Prenom_Civils='" + textBox3.Text + "',Civilite_Civils='" + comboBox1.Text + "',Adresse_Civils='" + textBox4.Text + "',CodePostale_Civils='" + textBox5.Text + "',Ville_Civils='" + textBox6.Text + "',Email_Civils='" + textBox7.Text + "',NumTel_Civils='" + textBox8.Text + "',DateDeNaissance_Civils='" + textBox9.Text + "',Nationalite_Civils='" + textBox10.Text + "',DateDeDeces_Civils='" + textBox11.Text + "',AppartenanceOrganisation_Civils='" + textBox12.Text + "',Commentaire_Civils='" + textBox13.Text + "',DateAjout_Civils='" + textBox14.Text + "',DateDeDerniereModification_Civils='" + textBox15.Text + "' WHERE Id_Civils = '" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Modification réussi ! !");
        }

        private void dgv1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dgv1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dgv1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dgv1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text =dgv1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dgv1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dgv1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dgv1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dgv1.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = dgv1.SelectedRows[0].Cells[8].Value.ToString();
            textBox9.Text = dgv1.SelectedRows[0].Cells[9].Value.ToString();
            textBox10.Text = dgv1.SelectedRows[0].Cells[10].Value.ToString();
            textBox11.Text = dgv1.SelectedRows[0].Cells[11].Value.ToString();
            textBox12.Text = dgv1.SelectedRows[0].Cells[12].Value.ToString();
            textBox13.Text = dgv1.SelectedRows[0].Cells[13].Value.ToString();
            textBox14.Text = dgv1.SelectedRows[0].Cells[14].Value.ToString();
            textBox15.Text = dgv1.SelectedRows[0].Cells[15].Value.ToString();
            textBox16.Text = dgv1.SelectedRows[0].Cells[16].Value.ToString();
            textBox17.Text = dgv1.SelectedRows[0].Cells[17].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM Civils where Id_Civils = '" + textBox1.Text + "'";
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
