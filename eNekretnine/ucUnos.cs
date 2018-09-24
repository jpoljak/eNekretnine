using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace eNekretnine
{


    public partial class ucUnos : UserControl
    {
        private static ucUnos _instance;

        public static ucUnos Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucUnos();
                return _instance;
            }


        }

        // Nekakav pokusaj
        


        public ucUnos()
        {
            InitializeComponent();
            Fillcombo();
            FillVlas();
            FillNarav();
        }

        //Ispis iz baze za comobox status nekretnine
        public void Fillcombo()
        {
            //spajanje na bazu
            string _conStr = "Server=192.168.1.121;Port=3306;Database=nekretnine;Uid=nekret;Pwd=radnekret;";
            string Query = "select * from nekretnine.status;";
            MySqlConnection mysqlCon = new MySqlConnection(_conStr);
            MySqlCommand cmdmysql = new MySqlCommand(Query, mysqlCon);
            MySqlDataReader myReader;
            try
            {
                mysqlCon.Open();
                myReader = cmdmysql.ExecuteReader();

                while (myReader.Read())
                {

                    string sName = myReader.GetString("statnekret");
                    //string sName2 = myReader.GetString("id_status");
                    int test2 = Convert.ToInt32(myReader.GetString("id_status"));
                    //un_stat.Items.Add(sName);
                    //un_stat.ValueMember = sName2.ToString();
                    int sName3;
                    Dictionary<string, Int32> test = new Dictionary<string, Int32>();
                    test.Add(sName, test2);
                    foreach(KeyValuePair<string, Int32>stat in test)
                    {
                        un_stat.SelectedValue = stat.Value.ToString();
                        un_stat.Items.Add(sName);


                    }
                   



                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        //Ispis iz baze za comobox vlasništvo nekretnine
        void FillVlas()
        {
            //spajanje na bazu
            string _conStr = "Server=192.168.1.121;Port=3306;Database=nekretnine;Uid=nekret;Pwd=radnekret;";
            string Query = "select * from nekretnine.vlasnistvo;";
            MySqlConnection mysqlCon = new MySqlConnection(_conStr);
            MySqlCommand cmdmysql = new MySqlCommand(Query, mysqlCon);
            MySqlDataReader myReader;
            try
            {
                mysqlCon.Open();
                myReader = cmdmysql.ExecuteReader();

                while (myReader.Read())
                {

                    string sName = myReader.GetString("vlastnekret");
                    un_vlas.Items.Add(sName);



                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        //Ispis iz baze za comobox narav nekretnine
        void FillNarav()
        {
            //spajanje na bazu
            string _conStr = "Server=192.168.1.121;Port=3306;Database=nekretnine;Uid=nekret;Pwd=radnekret;";
            string Query = "select * from nekretnine.narav;";
            MySqlConnection mysqlCon = new MySqlConnection(_conStr);
            MySqlCommand cmdmysql = new MySqlCommand(Query, mysqlCon);
            MySqlDataReader myReader;
            
            try
            {
                mysqlCon.Open();
                myReader = cmdmysql.ExecuteReader();

                while (myReader.Read())
                {

                    string sName = myReader.GetString("narnekret");
                    un_narav.Items.Add(sName);
                    


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void un_stat_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void un_vlas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.un_vlas.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ucUnos_Load(object sender, EventArgs e)
        {
            
        }

        private void un_narav_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.un_narav.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void unos_Click(object sender, EventArgs e)
        {
            //spajanje na bazu
            string _conStr = "Server=192.168.1.121;Port=3306;Database=nekretnine;Uid=nekret;Pwd=radnekret;";
            string sQuery = "select * nekretnine.narav;";

           
            string Query = "insert into test (id_status) values ('" +un_stat.SelectedValue.ToString() + "');";
            
            //string Query = "insert into nekretnina (id_status,id_vlasnistvo,id_narav,prij_vals,br_os,datum,br_zk,br_zk_ul,kat_op,br_kat_c,pov,nab_vr,vr_zem,biljeske) values ('"+ this.un_stat.SelectedValue.ToString() + "','" + this.un_vlas.Text + "','" + this.un_narav.Text + "','" + this.pr_vlas.Text + "','" + this.br_os.Text + "','" + this.datum.Text + "','" + this.br_zk.Text + "','" + this.br_zk_ul.Text + "','" + this.kat_op.Text + "','" + this.br_kat_c.Text + "','" + this.pov.Text + "','" + this.nab_vrij.Text + "','" + this.vr_zem.Text + "','" + this.biljeske.Text + "') ;";
            MySqlConnection conDataBase = new MySqlConnection(_conStr);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Spremljeno!");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
