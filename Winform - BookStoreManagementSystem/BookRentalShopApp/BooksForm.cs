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
    public partial class BooksForm : MetroForm
    {
        #region 전역 변수
            public bool isNew { get; set; }
        #endregion

        public BooksForm()
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
                AsignControls(selData);
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
                        query = @"INSERT INTO [dbo].[bookstbl]
                                                   ([Names]
                                                   ,[Author]
                                                   ,[Division]
                                                   ,[ReleaseDate]
                                                   ,[ISBN]
                                                   ,[Price]
                                                   ,[Descriptions])
                                             VALUES
                                                   (@Title
                                                   ,@Author
                                                   ,@Division
                                                   ,@ReleaseDate
                                                   ,@ISBN
                                                   ,@Price
                                                   ,@Description); ";
                    }

                    else
                    {
                        query = @"UPDATE [dbo].[bookstbl]
                                       SET [Names] = @Title
                                          ,[Author] = @Author
                                          ,[Division] = @Division
                                          ,[ReleaseDate] = @ReleaseDate
                                          ,[ISBN] = @ISBN
                                          ,[Price] = @Price
                                          ,[Descriptions] = @Description
                                     WHERE Idx = @Idx; ";
                    }

                    cmd.CommandText = query;

                    if (!isNew)
                    {
                        var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = txtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }
                    
                    
                    var pTitle = new SqlParameter("@Title", SqlDbType.NVarChar, 100);
                    pTitle.Value = txtTitle.Text;
                    cmd.Parameters.Add(pTitle);
                    var pAuthor = new SqlParameter("@Author", SqlDbType.NVarChar, 50);
                    pAuthor.Value = txtAuthor.Text;
                    cmd.Parameters.Add(pAuthor);
                    var pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pDivision.Value = cboDivision.SelectedValue;
                    cmd.Parameters.Add(pDivision);
                    var pReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date, 30);
                    pReleaseDate.Value = dtpReleaseDate.Text;
                    cmd.Parameters.Add(pReleaseDate);
                    var pISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                    pISBN.Value = txtISBN.Text;
                    cmd.Parameters.Add(pISBN);
                    var pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                    pPrice.Value = txtPrice.Text;
                    cmd.Parameters.Add(pPrice);
                    var pDescription = new SqlParameter("@Description", SqlDbType.NVarChar, 200);
                    pDescription.Value = Helper.Common.ReplaceCmdText(txtDescription.Text);
                    cmd.Parameters.Add(pDescription);


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
                    var query = @"SELECT [Idx]
                                        ,b.[Names] 
                                        ,[Author]
                                        ,b.[Division]
                                        ,d.[Names] as Division
                                        ,[ReleaseDate]
                                        ,FORMAT(ReleaseDate, N'yyyy년 MM월 dd일') AS ReleaseDate
                                        ,[ISBN]
                                        ,[Price] 
                                        ,FORMAT(Price, 'C') AS Price
                                        ,[Descriptions]
                                    FROM [dbo].[bookstbl] as b
                                    INNER JOIN [dbo].[divtbl] as d
                                    ON b.Division = d.Division";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");
                    dgvData.DataSource = ds;
                    dgvData.DataMember = "bookstbl";
                    dgvData.Columns[3].Visible = false;
                    dgvData.Columns[5].Visible = false;
                    dgvData.Columns[8].Visible = false;
                    dgvData.Columns[10].Visible = false;
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
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtAuthor.Text)
                || (cboDivision.SelectedIndex == -1) || string.IsNullOrEmpty(dtpReleaseDate.Text)
                || string.IsNullOrEmpty(txtISBN.Text) || string.IsNullOrEmpty(txtPrice.Text))
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
            txtIdx.Text = txtTitle.Text = txtISBN.Text = 
                txtPrice.Text = txtAuthor.Text = txtDescription.Text = "";
            dtpReleaseDate.Value = DateTime.Now; // 오늘 날짜
            cboDivision.SelectedIndex = -1;
            isNew = true;
        }
        
        /// <summary>
        /// 콤보 박스 데이터 초기 설정
        /// </summary>
        private void InitCboData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.connString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    var query = "SELECT Division, Names FROM dbo.divtbl ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while(reader.Read())
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString());
                    }
                    //
                    cboDivision.DataSource = new BindingSource(temp, null);
                    cboDivision.DisplayMember = "Value";
                    cboDivision.ValueMember = "Key";
                        
                    cboDivision.SelectedIndex = -1;
                } 
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
            txtTitle.Text = selData.Cells[1].Value.ToString();
            txtAuthor.Text = selData.Cells[2].Value.ToString();
            cboDivision.SelectedValue = selData.Cells[3].Value;
            // [4] : 분류명
            dtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
            // [6] : 날짜 변환 포맷
            txtISBN.Text = selData.Cells[7].Value.ToString();
            txtPrice.Text = selData.Cells[8].Value.ToString();
            // [8] : 가격 변환 포맷
            txtDescription.Text = selData.Cells[10].Value.ToString();
        }

        #endregion


    }
}
