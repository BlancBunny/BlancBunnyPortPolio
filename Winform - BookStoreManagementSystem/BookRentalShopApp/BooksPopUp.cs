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
    public partial class BooksPopUp : MetroForm
    {
        #region 전역 변수
        public int SelIdx { get; set; }
        public string SelName { get; set; }
        #endregion

        public BooksPopUp()
        {
            InitializeComponent();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        

        #region Event_Handler

       
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BooksPopUp_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        #endregion


        #region Custom_Methods


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
                                        ,d.[Names] as Division
                                    FROM [dbo].[bookstbl] as b
                                    INNER JOIN [dbo].[divtbl] as d
                                    ON b.Division = d.Division";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");
                    dgvData.DataSource = ds;
                    dgvData.DataMember = "bookstbl";
                    
                    dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        #endregion

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "데이터를 선택하세요.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelIdx = (int)dgvData.SelectedRows[0].Cells[0].Value;
            SelName = dgvData.SelectedRows[0].Cells[1].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
