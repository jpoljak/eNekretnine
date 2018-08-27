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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            //Ako nije već prikazano, prikaži panel Unos
            if (!panel1.Controls.Contains(ucUnos.Instance))
            {
                panel1.Controls.Add(ucUnos.Instance);
                ucUnos.Instance.Dock = DockStyle.Fill;
                ucUnos.Instance.BringToFront();
            }
            else
                ucUnos.Instance.BringToFront();
        }

        private void btnPregled_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucPogled.Instance))
            {
                panel1.Controls.Add(ucPogled.Instance);
                ucPogled.Instance.Dock = DockStyle.Fill;
                ucPogled.Instance.BringToFront();
            }
            else
                ucPogled.Instance.BringToFront();
        }
    }
}
