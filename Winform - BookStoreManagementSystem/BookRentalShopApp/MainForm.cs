using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace BookRentalShopApp
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            
        }

        private void InitChildForm(Form form, string strTitle)
        {
            form.Text = strTitle;
            form.Dock = DockStyle.Fill;
            form.MdiParent = this; // FrmMain
            form.FormBorderStyle = FormBorderStyle.None;
            form.Width = this.ClientSize.Width - 1000; // 추가
            form.Height = this.Height - menuStrip1.Height; // 추가
            form.Show();
            form.WindowState = FormWindowState.Maximized;

        }

        private void mnuDivCode_Click(object sender, EventArgs e)
        {
            DivCodeForm form = new DivCodeForm();
            InitChildForm(form, "구분코드 관리");
        }

        private void mnuMember_Click(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm();
            InitChildForm(form, "회원 관리");
        }

        private void mnuBook_Click(object sender, EventArgs e)
        {
            BooksForm form = new BooksForm();
            InitChildForm(form, "도서 관리");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this, "종료하시겠습니까?", "종료",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else e.Cancel = true; // 종료 안함 
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            menuStrip1.Width = this.Width;
            menuStrip1.Height = this.Height;
        }

        private void mnuRental_Click(object sender, EventArgs e)
        {
            RentalForm form = new RentalForm();
            InitChildForm(form, "대여 관리");
        }
    }
}
