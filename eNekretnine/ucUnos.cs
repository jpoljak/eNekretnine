using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
