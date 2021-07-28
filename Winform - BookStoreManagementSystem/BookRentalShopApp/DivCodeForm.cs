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
    public partial class DivCodeForm : MetroForm
    {
        #region 전역 변수
            public bool isNew { get; set; }
        #endregion

        public DivCodeForm()
        {
            InitializeComponent();
        }
        

        #region Event_Handler

        private void DivCodeForm_Load(object sender, EventArgs e)
        {
            DivCodeForm_Resize(sender, e);
            RefreshData();
        }

        private void DivCodeForm_Resize(object sender, EventArgs e)
        {
            //groupBox1.Location = new Point(dgvData.Width + 25 ,60);
            //groupBox1.Width = this.Width - 45 - dgvData.Width;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckValidation() == false) return;
            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DeleteData();
            RefreshData();
            ClearInputs();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtDiv.Focus();
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
                txtDiv.Text = selData.Cells[0].Value.ToString();
                txtDivName.Text = selData.Cells[1].Value.ToString();
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
                        query = "INSERT INTO divTbl " +
                            "VALUES (@Division, @Names); ";
                    }

                    else
                    {
                        query = "UPDATE divTbl " +
                            "SET Names = @Names " +
                            "WHERE Division = @Division; ";
                    }

                    cmd.CommandText = query;
                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pDivision.Value = txtDiv.Text;
                    cmd.Parameters.Add(pDivision);
                    SqlParameter pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 45);
                    pNames.Value = txtDivName.Text;
                    cmd.Parameters.Add(pNames);

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
                    pDivision.Value = txtDiv.Text;
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

                    var query = "SELECT [Division] " +
                                "      ,[Names]" +
                                "   FROM [dbo].[divTbl] ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    
                    adapter.Fill(ds, "divTbl");
                    
                    dgvData.DataSource = ds;
                    dgvData.DataMember = "divTbl";
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
            if (string.IsNullOrEmpty(txtDiv.Text) || string.IsNullOrEmpty(txtDivName.Text))
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
            txtDiv.Text = txtDivName.Text = "";
            txtDiv.ReadOnly = false;
            txtDivName.ReadOnly = false;
            isNew = true;
        }

        #endregion
    }
}
