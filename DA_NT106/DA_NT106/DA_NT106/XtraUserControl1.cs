using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_NT106
{
    public partial class XtraUserControl1 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl1()
        {
            InitializeComponent();
        }

        private void XtraUserControl1_Load(object sender, EventArgs e)
        {

        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = "user1"; labelControl1.Text = "User1"; }
        }
        private Image _icon;
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureEdit1.Image = value; }
        }

    }
}
