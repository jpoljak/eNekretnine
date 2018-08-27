using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace eNekretnine
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            textBox3.Select();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            
            textBox2.UseSystemPasswordChar = true;
            textBox2.Text = "";
        }
        

        private void label2_Click(object sender, EventArgs e)
        {
            //spajanje na bazu
            string _conStr = "Server=192.168.1.121;Port=3306;Database=nekretnine;Uid=nekret;Pwd=radnekret;";
            MySqlConnection mysqlCon = new MySqlConnection(_conStr);
            mysqlCon.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter("Select Count(*) from korisnici where korime='" + textBox1.Text + "'and lozinka ='" + textBox2.Text + "'", mysqlCon);
            //string login = "Select Count(*) from korisnici where korime='" +textBox1.Text+"'and lozinka ='"+textBox2.Text+"'";
            DataTable dt = new DataTable();
            MyDA.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                //nakon što se klikne na prijavi, sakrij login formu i otvori glavnu formu
                Main frm = new Main();
                frm.Show();
                this.Hide();
                //this.Hide();
                mysqlCon.Close();

            }
            else
            {
                MessageBox.Show("Pogrešno korisničko ime ili lozinka!");
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //spajanje na bazu
            string _conStr = "Server=192.168.1.121;Port=3306;Database=nekretnine;Uid=nekret;Pwd=radnekret;";
            MySqlConnection mysqlCon = new MySqlConnection(_conStr);
            mysqlCon.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter("Select Count(*) from korisnici where korime='" + textBox1.Text + "'and lozinka ='" + textBox2.Text + "'", mysqlCon);
            //string login = "Select Count(*) from korisnici where korime='" +textBox1.Text+"'and lozinka ='"+textBox2.Text+"'";
            DataTable dt = new DataTable();
            MyDA.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                // sakrivanje login forme i otvaranje glavne forme
                Main frm = new Main();
                frm.Show();
                this.Hide();
                mysqlCon.Close();
            }
            else
            {
                MessageBox.Show("Pogrešno korisničko ime ili lozinka!");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            textBox2.UseSystemPasswordChar = true;
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //spajanje na bazu
                string _conStr = "Server=192.168.1.121;Port=3306;Database=nekretnine;Uid=nekret;Pwd=radnekret;";
                MySqlConnection mysqlCon = new MySqlConnection(_conStr);
                mysqlCon.Open();
                MySqlDataAdapter MyDA = new MySqlDataAdapter("Select Count(*) from korisnici where korime='" + textBox1.Text + "'and lozinka ='" + textBox2.Text + "'", mysqlCon);
                //string login = "Select Count(*) from korisnici where korime='" +textBox1.Text+"'and lozinka ='"+textBox2.Text+"'";
                DataTable dt = new DataTable();
                MyDA.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    // sakrivanje login forme i otvaranje glavne forme
                    Main frm = new Main();
                    frm.Show();
                    this.Hide();
                    mysqlCon.Close();
                }
                else
                {
                    MessageBox.Show("Pogrešno korisničko ime ili lozinka!");
                }
            }
        }
    }
}
