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
    }
}
