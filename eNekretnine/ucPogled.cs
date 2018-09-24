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
    public partial class ucPogled : UserControl
    {
        private static ucPogled _instance;

        public static ucPogled Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucPogled();
                return _instance;
            }


        }
        public ucPogled()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //spajanje na bazu
            string _conStr = "Server=192.168.1.121;Port=3306;Database=nekretnine;Uid=nekret;Pwd=radnekret;";
            string Query = "select * from nekretnina;";
            MySqlConnection mysqlCon = new MySqlConnection(_conStr);
            MySqlCommand cmdmysql = new MySqlCommand(Query, mysqlCon);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdmysql;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
