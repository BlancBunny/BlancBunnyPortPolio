using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp
{
    public partial class LoginForm : MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("로그인");
            if (string.IsNullOrEmpty(txtUserID.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MetroMessageBox.Show(this,"아이디/패스워드를 입력하세요", "오류", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.connString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string strUserId;
                    var query = $"SELECT userID FROM memberTbl " +
                                $"WHERE userID = @userID " +
                                $"AND passwords = @passwords; ";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlParameter pUserID = new SqlParameter("@userID", SqlDbType.VarChar,20);
                    pUserID.Value = txtUserID.Text;
                    cmd.Parameters.Add(pUserID);
                    SqlParameter pPasswords = new SqlParameter("@passwords", SqlDbType.VarChar, 20);
                    pPasswords.Value = txtPassword.Text;
                    cmd.Parameters.Add(pPasswords);

                    SqlDataReader reader = cmd.ExecuteReader();
                    // 비밀번호 오류 처리
                    reader.Read();
                    strUserId = reader["userID"] != null ? reader["userID"].ToString() : "";
                    reader.Close();
                    if (string.IsNullOrEmpty(strUserId))
                    {
                        MetroMessageBox.Show(this, "접속 실패", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var updateQuery = $"UPDATE memberTbl SET " +
                                          $"lastLoginDt = GETDATE(), " +
                                          $"loginIpAddr = '{Helper.Common.GetLocalIp()}' " +
                                          $"WHERE userId = '{strUserId}' ";
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();
                        MetroMessageBox.Show(this, "접속 성공", "로그인성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }


                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Error : {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtPassword.Focus();
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnLogin_Click(sender, e);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
