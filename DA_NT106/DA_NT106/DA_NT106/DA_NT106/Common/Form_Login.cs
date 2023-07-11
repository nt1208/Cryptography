using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_NT106.Common
{
    public partial class Form_Login : DevExpress.XtraEditors.XtraForm
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_UserName.Text))
            {
                MessageBox.Show(@"User name không được để trống", @"System massage");
                return;
            }
            if (string.IsNullOrEmpty(txt_Pass.Text))
            {
                MessageBox.Show(@"Password không được để trống", @"System massage");
                return;
            }
            if (txt_UserName.Text.Equals("admin")&& txt_Pass.Text.Equals("123456"))
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            MessageBox.Show(@"Đã nhập sai user hoặc password", @"System message");
        }


    }
}