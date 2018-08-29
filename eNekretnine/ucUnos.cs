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
        


        
        public ucUnos()
        {
            InitializeComponent();
            Fillcombo();
        }

        //Ispis iz baze za comobox status nekretnine
        void Fillcombo()
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
                    un_stat.Items.Add(sName);



                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         

            
        }

        private void un_stat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.un_stat.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
