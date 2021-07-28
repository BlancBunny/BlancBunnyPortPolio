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
    public partial class RentalForm : MetroForm
    {
        #region 전역 변수
        private int selMemberIdx = 0;
        private string selMemberName = "";
        private int selBookIdx = 0;
        private string selBookName = "";
        public bool isNew { get; set; }
        #endregion

        public RentalForm()
        {
            InitializeComponent();
        }
        

        #region Event_Handler

        private void BooksForm_Load(object sender, EventArgs e)
        {
            isNew = true;
            InitCboData();
            RefreshData();

        }

        private void BooksForm_Resize(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(dgvData.Width + 25 ,60);
            groupBox1.Width = this.Width - 45 - dgvData.Width;
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
                AsignControls(selData);
                isNew = false;
                btnSearchBooks.Enabled = btnSearchMember.Enabled = false;
                dtpRentalDate.Enabled = false;
            }
        }

        
        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            MemberPopUpForm form = new MemberPopUpForm();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() == DialogResult.OK)
            {
                selMemberIdx = form.SelIdx;
                txtMember.Text = selMemberName = form.SelName;
            }
            
        }

        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            BooksPopUp form = new BooksPopUp();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() == DialogResult.OK)
            {
                selBookIdx = form.SelIdx;
                txtBookName.Text = selBookName = form.SelName;
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

                        query = @"INSERT INTO [dbo].[rentaltbl]
                                                   ([memberIdx]
                                                    ,[bookIdx]
                                                    ,[rentalDate]
                                                    ,[rentalState])
                                                VALUES
                                                    (@memberIdx
                                                    ,@bookIdx
                                                    ,GETDATE()
                                                    ,@rentalState)";
                    }

                    else
                    {
                        query = @"UPDATE [dbo].[rentaltbl]
                                            SET [returnDate] = case @rentalState
                                                               WHEN 'T' THEN GETDATE()
                                                               WHEN 'R' THEN null end 
                                            ,[rentalState] = @rentalState 
                                            WHERE Idx = @Idx; ";
                    }

                    cmd.CommandText = query;

                    if (!isNew)
                    {
                        var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = txtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                        var pRentalState = new SqlParameter("@rentalState", SqlDbType.Char, 1);
                        pRentalState.Value = cboRentalState.SelectedValue;
                        cmd.Parameters.Add(pRentalState);

                    }
                    else
                    {
                        var pMemberIdx = new SqlParameter("@MemberIdx", SqlDbType.Int);
                        pMemberIdx.Value = selMemberIdx;
                        cmd.Parameters.Add(pMemberIdx);

                        var pBookIdx = new SqlParameter("@BookIdx", SqlDbType.Int);
                        pBookIdx.Value = selBookIdx;
                        cmd.Parameters.Add(pBookIdx);

                        var pRentalDate = new SqlParameter("@rentalDate", SqlDbType.Date);
                        pRentalDate.Value = dtpRentalDate.Value;
                        cmd.Parameters.Add(pRentalDate);

                        var pRentalState = new SqlParameter("@rentalState", SqlDbType.Char, 1);
                        pRentalState.Value = cboRentalState.SelectedValue;
                        cmd.Parameters.Add(pRentalState);
                        

                    }

                    

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

                    var query = "DELETE FROM booksTbl " +
                            "WHERE Idx = @Idx; ";
                    cmd.CommandText = query;
                    SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    pIdx.Value = txtIdx.Text;
                    cmd.Parameters.Add(pIdx);

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
                    var query = @"SELECT r.[Idx]
                                         ,r.[memberIdx]
	                                     ,m.Names as memberName
                                         ,r.[bookIdx]
	                                     ,b.Names as bookName
                                         ,r.[rentalDate]
                                         ,r.[returnDate]
	                                     ,r.[rentalState] as r
                                         ,CASE r.[rentalState] 
                                            WHEN 'R' THEN '대여중'  
                                            WHEN 'T' THEN '반납' 
                                            ELSE '상태없음' END as rentalState
                                      FROM [dbo].[rentaltbl] as r
                                      INNER JOIN [dbo].[membertbl] as m 
	                                     on r.memberIdx = m.Idx
                                      INNER JOIN [dbo].[bookstbl] as b
	                                     on r.bookIdx = b.Idx;";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "rentaltbl");
                    dgvData.DataSource = ds;
                    dgvData.DataMember = "rentaltbl";
                    dgvData.Columns[1].Visible = false;
                    dgvData.Columns[3].Visible = false;
                    dgvData.Columns[7].Visible = false;
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
            if (string.IsNullOrEmpty(txtMember.Text) || string.IsNullOrEmpty(txtBookName.Text)
                || string.IsNullOrEmpty(dtpRentalDate.Text) || string.IsNullOrEmpty(cboRentalState.Text))
              
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
            selMemberIdx = selBookIdx = 0;
            selMemberName = selBookName = "";
            txtIdx.Text = txtBookName.Text = txtMember.Text = txtReturnDate.Text = "";
            dtpRentalDate.Value = DateTime.Now; // 오늘 날짜
            
            cboRentalState.SelectedIndex = -1;
            isNew = true;

            btnSearchBooks.Enabled = btnSearchMember.Enabled = true;
            dtpRentalDate.Enabled = true;

        }
        
        /// <summary>
        /// 콤보 박스 데이터 초기 설정
        /// </summary>
        private void InitCboData()
        {
            try
            {
                var temp = new Dictionary<string, string>();
                temp.Add("R", "대여중");
                temp.Add("T", "반납");

                cboRentalState.DataSource = new BindingSource(temp, null);
                cboRentalState.DisplayMember = "Value";
                cboRentalState.ValueMember = "Key";
                cboRentalState.SelectedIndex = -1;
            }
            catch { }
        }

        /// <summary>
        /// 셀 클릭 시 정보 출력
        /// </summary>
        /// <param name="selData"></param>
        private void AsignControls(DataGridViewRow selData)
        {
            txtIdx.Text = selData.Cells[0].Value.ToString();
            selMemberIdx = (int)selData.Cells[1].Value;
            txtMember.Text = selMemberName = selData.Cells[2].Value.ToString();
            selBookIdx = (int)selData.Cells[3].Value;
            txtBookName.Text = selBookName = selData.Cells[4].Value.ToString();
            dtpRentalDate.Value = (DateTime)selData.Cells[5].Value;
            txtReturnDate.Text = selData.Cells[6].Value.ToString();
            cboRentalState.SelectedValue = selData.Cells[7].Value;
        }
        #endregion

        
    }
}
