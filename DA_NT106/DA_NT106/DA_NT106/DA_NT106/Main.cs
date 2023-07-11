using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DA_NT106
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_Shown(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sidePanel1_Click(object sender, EventArgs e)
        {

        }

        private void svgImageBox1_Click(object sender, EventArgs e)
        {

        }

        private void xtraUserControl11_Load(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void navigationPane1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void svgImageBox1_Click_1(object sender, EventArgs e)
        {
            if (panelControl2.Visible == false) panelControl2.Visible = true;
            else panelControl2.Visible = false;
        }

        private void svgImageBox5_Click(object sender, EventArgs e)
        {
            panelControl2.Visible = false;
        }
    }
}
