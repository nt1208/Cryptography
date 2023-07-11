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

namespace DA_NT106
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
                MessageBox.Show(@"Dang nhap thanh cong", @"System massage") ;
                //Mở form mới và đóng form cũ 
                Main frm = new Main();
                this.Hide();
                frm.Show();
                return;
            }
            else MessageBox.Show(@"Đã nhập sai user hoặc password", @"System message");
        }


        private void Form_Login_Load_1(object sender, EventArgs e)
        {

        }

        private void txt_Register_Click(object sender, EventArgs e)
        {
            Form_Register frmrg = new Form_Register();
            frmrg.ShowDialog();
        }

        private void txt_Register_CursorChanged(object sender, EventArgs e)
        {
            txt_Register.Font = new Font(txt_Register.Font, FontStyle.Bold);
        }

    }
}