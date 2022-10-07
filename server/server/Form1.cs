using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        string status = "Stato del server: ";

        public Form1()
        {
            InitializeComponent();
        }

        private void OnOff_Click(object sender, EventArgs e)
        {
            if (OnOff.Text == "Accendi")
            {
                OnOff.Text = "Spegni";
                //Form1.state.Text = status + "Attivo";
            }
            else
            {
                OnOff.Text = "Accendi";
               // Form1.state.Text = status + "Spento";
            }
        }
    }
}
