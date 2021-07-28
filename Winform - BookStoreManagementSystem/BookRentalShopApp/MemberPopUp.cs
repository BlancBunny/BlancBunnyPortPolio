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
    public partial class MemberPopUpForm : MetroForm
    {
        #region 전역 변수
            public int SelIdx { get; set; }
            public string SelName { get; set; }
        #endregion

        public MemberPopUpForm()
        {
            InitializeComponent();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        

        #region Event_Handler

        private void MemberPopUp_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

                    var query = $"SELECT [Idx] " +
                                $"      ,[Names] " +
                                $"      ,[Levels] " +
                                $"      ,[Mobile]" +
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

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
