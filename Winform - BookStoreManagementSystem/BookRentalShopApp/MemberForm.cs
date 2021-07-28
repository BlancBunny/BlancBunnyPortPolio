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
    public partial class MemberForm : MetroForm
    {
        #region 전역 변수
            public bool isNew { get; set; }
        #endregion

        public MemberForm()
        {
            InitializeComponent();
            
        }
        

        #region Event_Handler

        private void FormDivCode_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void FormDivCode_Resize(object sender, EventArgs e)
        {
            //groupBox1.Location = new Point(dgvData.Width + 25 ,60);
            //groupBox1.Width = this.Width - 45 - dgvData.Width;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckValidation() == false) return;
            if (MetroMessageBox.Show(Parent, "삭제하시겠습니까?", "삭제",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DeleteData();
            RefreshData();
            ClearInputs();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtIdx.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation() == false) return;
            
            SaveData();
            RefreshData();
            ClearInputs();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isNew = false;
            if (e.RowIndex > -1) // 선택된 값이 있으면 
            {
                var selData = dgvData.Rows[e.RowIndex];
                txtIdx.Text = selData.Cells[0].Value.ToString();
                txtName.Text = selData.Cells[1].Value.ToString();
                txtAddress.Text = selData.Cells[3].Value.ToString();
                txtMobile.Text = selData.Cells[4].Value.ToString();
                txtEmail.Text = selData.Cells[5].Value.ToString();
                txtUserID.Text = selData.Cells[6].Value.ToString();
                cboLevel.SelectedItem = selData.Cells[2].Value.ToString();
            }
        }

        #endregion


        #region Custom_Methods

        /// <summary>
        /// 데이터 입력
        /// </summary>
        private void SaveData()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Helper.Common.connString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    if (isNew)
                    {
                        query = @"INSERT INTO [dbo].[membertbl]
                                                   ([Names]
                                                   ,[Levels]
                                                   ,[Addr]
                                                   ,[Mobile]
                                                   ,[Email]
                                                   ,[userID]
                                                   ,[passwords])
                                             VALUES
                                                   (@Names
                                                   ,@Levels
                                                   ,@Addr
                                                   ,@Mobile
                                                   ,@Email
                                                   ,@userID
                                                   ,@passwords); ";
                    }

                    else
                    {
                        query = @"UPDATE [dbo].[membertbl]
                                       SET [Names] = @Names
                                          ,[Levels] = @Levels
                                          ,[Addr] = @Addr 
                                          ,[Mobile] = @Mobile
                                          ,[Email] = @Email 
                                          ,[userID] = @userID 
                                          ,[passwords] = @passwords 
                                     WHERE Idx = @Idx; ";
                    }

                    if (!isNew)
                    {
                        var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = txtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }
                    cmd.CommandText = query;
                    var pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 50);
                    pNames.Value = txtName.Text;
                    cmd.Parameters.Add(pNames);
                    var pLevels = new SqlParameter("@Levels", SqlDbType.Char, 1);
                    pLevels.Value = cboLevel.SelectedItem.ToString();
                    cmd.Parameters.Add(pLevels);
                    var pAddr = new SqlParameter("@Addr", SqlDbType.NVarChar, 100);
                    pAddr.Value = txtAddress.Text;
                    cmd.Parameters.Add(pAddr);
                    var pMobile = new SqlParameter("@Mobile", SqlDbType.VarChar, 13);
                    pMobile.Value = txtMobile.Text;
                    cmd.Parameters.Add(pMobile);
                    var pEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                    pEmail.Value = txtEmail.Text;
                    cmd.Parameters.Add(pEmail);
                    var pUserID = new SqlParameter("@UserID", SqlDbType.VarChar, 20);
                    pUserID.Value = txtUserID.Text;
                    cmd.Parameters.Add(pUserID);
                    var pPasswords = new SqlParameter("@Passwords", SqlDbType.VarChar, 100);
                    pPasswords.Value = txtPassword.Text;
                    cmd.Parameters.Add(pPasswords);
                    

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "저장 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "저장 실패", "경고",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 데이터 삭제
        /// </summary>
        private void DeleteData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.connString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    query = "DELETE FROM divTbl " +
                            "WHERE Division = @Division; ";
                    cmd.CommandText = query;
                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pDivision.Value = txtIdx.Text;
                    cmd.Parameters.Add(pDivision);

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "삭제 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "삭제 실패", "경고",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DataGridView 새로고침
        /// </summary>
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.connString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = $"SELECT [Idx] " +
                                $"      ,[Names] " +
                                $"      ,[Levels] " +
                                $"      ,[Addr]" +
                                $"      ,[Mobile]" +
                                $"      ,[Email]" +
                                $"      ,[userID]" +
                                $"      ,[lastLoginDt]" +
                                $"      ,[loginIpAddr]" +
                                $"   FROM[dbo].[membertbl]; ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    
                    adapter.Fill(ds, "memberTbl");
                    
                    dgvData.DataSource = ds;
                    dgvData.DataMember = "memberTbl";
                    dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 입력값 유효성 체크
        /// </summary>
        /// <returns></returns>
        private bool CheckValidation()
        {
            if (string.IsNullOrEmpty(txtName.Text)
                || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtMobile.Text)
                || string.IsNullOrEmpty(txtEmail.Text) || cboLevel.SelectedIndex == -1
                || string.IsNullOrEmpty(txtUserID.Text))
            {
                MetroMessageBox.Show(this, "빈 값은 처리할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 입력 텍스트 초기화 
        /// </summary>
        private void ClearInputs()
        {
            txtIdx.Text = txtName.Text = txtAddress.Text = txtEmail.Text = 
                txtMobile.Text = txtUserID.Text = txtPassword.Text = "";
            cboLevel.SelectedIndex = -1;
            isNew = true;
        }

        #endregion
    }
}
