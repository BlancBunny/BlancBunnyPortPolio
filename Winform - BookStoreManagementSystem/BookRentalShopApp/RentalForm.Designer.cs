
namespace BookRentalShopApp
{
    partial class RentalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReturnDate = new MetroFramework.Controls.MetroTextBox();
            this.dtpRentalDate = new MetroFramework.Controls.MetroDateTime();
            this.cboRentalState = new MetroFramework.Controls.MetroComboBox();
            this.btnSearchBooks = new MetroFramework.Controls.MetroButton();
            this.btnSearchMember = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnNew = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtBookName = new MetroFramework.Controls.MetroTextBox();
            this.txtMember = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtIdx = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.txtReturnDate);
            this.groupBox1.Controls.Add(this.dtpRentalDate);
            this.groupBox1.Controls.Add(this.cboRentalState);
            this.groupBox1.Controls.Add(this.btnSearchBooks);
            this.groupBox1.Controls.Add(this.btnSearchMember);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.txtBookName);
            this.groupBox1.Controls.Add(this.txtMember);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.txtIdx);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Location = new System.Drawing.Point(898, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(279, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상세";
            // 
            // txtReturnDate
            // 
            // 
            // 
            // 
            this.txtReturnDate.CustomButton.Image = null;
            this.txtReturnDate.CustomButton.Location = new System.Drawing.Point(132, 1);
            this.txtReturnDate.CustomButton.Name = "";
            this.txtReturnDate.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtReturnDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtReturnDate.CustomButton.TabIndex = 1;
            this.txtReturnDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtReturnDate.CustomButton.UseSelectable = true;
            this.txtReturnDate.CustomButton.Visible = false;
            this.txtReturnDate.Lines = new string[0];
            this.txtReturnDate.Location = new System.Drawing.Point(91, 163);
            this.txtReturnDate.MaxLength = 32767;
            this.txtReturnDate.Name = "txtReturnDate";
            this.txtReturnDate.PasswordChar = '\0';
            this.txtReturnDate.PromptText = "반납일";
            this.txtReturnDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReturnDate.SelectedText = "";
            this.txtReturnDate.SelectionLength = 0;
            this.txtReturnDate.SelectionStart = 0;
            this.txtReturnDate.ShortcutsEnabled = true;
            this.txtReturnDate.Size = new System.Drawing.Size(154, 23);
            this.txtReturnDate.TabIndex = 13;
            this.txtReturnDate.UseSelectable = true;
            this.txtReturnDate.WaterMark = "반납일";
            this.txtReturnDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtReturnDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dtpRentalDate
            // 
            this.dtpRentalDate.CustomFormat = "yyyy-MM-dd";
            this.dtpRentalDate.Location = new System.Drawing.Point(91, 124);
            this.dtpRentalDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpRentalDate.Name = "dtpRentalDate";
            this.dtpRentalDate.Size = new System.Drawing.Size(154, 29);
            this.dtpRentalDate.TabIndex = 12;
            // 
            // cboRentalState
            // 
            this.cboRentalState.FormattingEnabled = true;
            this.cboRentalState.ItemHeight = 23;
            this.cboRentalState.Location = new System.Drawing.Point(91, 195);
            this.cboRentalState.Name = "cboRentalState";
            this.cboRentalState.Size = new System.Drawing.Size(154, 29);
            this.cboRentalState.TabIndex = 8;
            this.cboRentalState.UseSelectable = true;
            // 
            // btnSearchBooks
            // 
            this.btnSearchBooks.BackgroundImage = global::BookRentalShopApp.Properties.Resources.KakaoTalk_20210318_145727771;
            this.btnSearchBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearchBooks.Location = new System.Drawing.Point(220, 93);
            this.btnSearchBooks.Name = "btnSearchBooks";
            this.btnSearchBooks.Size = new System.Drawing.Size(26, 20);
            this.btnSearchBooks.TabIndex = 5;
            this.btnSearchBooks.UseSelectable = true;
            this.btnSearchBooks.Click += new System.EventHandler(this.btnSearchBooks_Click);
            // 
            // btnSearchMember
            // 
            this.btnSearchMember.BackgroundImage = global::BookRentalShopApp.Properties.Resources.KakaoTalk_20210318_145727771;
            this.btnSearchMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearchMember.Location = new System.Drawing.Point(219, 61);
            this.btnSearchMember.Name = "btnSearchMember";
            this.btnSearchMember.Size = new System.Drawing.Size(26, 20);
            this.btnSearchMember.TabIndex = 3;
            this.btnSearchMember.UseSelectable = true;
            this.btnSearchMember.Click += new System.EventHandler(this.btnSearchMember_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 324);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "저장";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 324);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 35);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "신규";
            this.btnNew.UseSelectable = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(14, 203);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(76, 19);
            this.metroLabel6.TabIndex = 0;
            this.metroLabel6.Text = "대여상태 : ";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(28, 165);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(62, 19);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "반납일 : ";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(177, 324);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 35);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(28, 130);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(62, 19);
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "대여일 : ";
            // 
            // txtBookName
            // 
            // 
            // 
            // 
            this.txtBookName.CustomButton.Image = null;
            this.txtBookName.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.txtBookName.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookName.CustomButton.Name = "";
            this.txtBookName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtBookName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBookName.CustomButton.TabIndex = 1;
            this.txtBookName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBookName.CustomButton.UseSelectable = true;
            this.txtBookName.CustomButton.Visible = false;
            this.txtBookName.Lines = new string[0];
            this.txtBookName.Location = new System.Drawing.Point(91, 93);
            this.txtBookName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookName.MaxLength = 32767;
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.PasswordChar = '\0';
            this.txtBookName.PromptText = "도서명";
            this.txtBookName.ReadOnly = true;
            this.txtBookName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBookName.SelectedText = "";
            this.txtBookName.SelectionLength = 0;
            this.txtBookName.SelectionStart = 0;
            this.txtBookName.ShortcutsEnabled = true;
            this.txtBookName.Size = new System.Drawing.Size(123, 20);
            this.txtBookName.TabIndex = 4;
            this.txtBookName.UseSelectable = true;
            this.txtBookName.WaterMark = "도서명";
            this.txtBookName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBookName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtMember
            // 
            // 
            // 
            // 
            this.txtMember.CustomButton.Image = null;
            this.txtMember.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.txtMember.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMember.CustomButton.Name = "";
            this.txtMember.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtMember.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMember.CustomButton.TabIndex = 1;
            this.txtMember.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMember.CustomButton.UseSelectable = true;
            this.txtMember.CustomButton.Visible = false;
            this.txtMember.Lines = new string[0];
            this.txtMember.Location = new System.Drawing.Point(91, 61);
            this.txtMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMember.MaxLength = 32767;
            this.txtMember.Name = "txtMember";
            this.txtMember.PasswordChar = '\0';
            this.txtMember.PromptText = "대여회원";
            this.txtMember.ReadOnly = true;
            this.txtMember.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMember.SelectedText = "";
            this.txtMember.SelectionLength = 0;
            this.txtMember.SelectionStart = 0;
            this.txtMember.ShortcutsEnabled = true;
            this.txtMember.Size = new System.Drawing.Size(123, 20);
            this.txtMember.TabIndex = 2;
            this.txtMember.UseSelectable = true;
            this.txtMember.WaterMark = "대여회원";
            this.txtMember.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMember.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(28, 95);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(62, 19);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "도서명 : ";
            // 
            // txtIdx
            // 
            // 
            // 
            // 
            this.txtIdx.CustomButton.Image = null;
            this.txtIdx.CustomButton.Location = new System.Drawing.Point(137, 2);
            this.txtIdx.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdx.CustomButton.Name = "";
            this.txtIdx.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtIdx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIdx.CustomButton.TabIndex = 1;
            this.txtIdx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIdx.CustomButton.UseSelectable = true;
            this.txtIdx.CustomButton.Visible = false;
            this.txtIdx.Lines = new string[0];
            this.txtIdx.Location = new System.Drawing.Point(91, 29);
            this.txtIdx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdx.MaxLength = 6;
            this.txtIdx.Name = "txtIdx";
            this.txtIdx.PasswordChar = '\0';
            this.txtIdx.PromptText = "순번";
            this.txtIdx.ReadOnly = true;
            this.txtIdx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIdx.SelectedText = "";
            this.txtIdx.SelectionLength = 0;
            this.txtIdx.SelectionStart = 0;
            this.txtIdx.ShortcutsEnabled = true;
            this.txtIdx.Size = new System.Drawing.Size(155, 20);
            this.txtIdx.TabIndex = 1;
            this.txtIdx.UseSelectable = true;
            this.txtIdx.WaterMark = "순번";
            this.txtIdx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIdx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(14, 64);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(76, 19);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "대여회원 : ";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(46, 32);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(44, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "순번 :";
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(20, 60);
            this.dgvData.Margin = new System.Windows.Forms.Padding(0);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(875, 516);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RentalForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "대여 관리";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BooksForm_Load);
            this.Resize += new System.EventHandler(this.BooksForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnNew;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroTextBox txtMember;
        private MetroFramework.Controls.MetroTextBox txtIdx;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView dgvData;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtBookName;
        private MetroFramework.Controls.MetroButton btnSearchMember;
        private MetroFramework.Controls.MetroButton btnSearchBooks;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox cboRentalState;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroDateTime dtpRentalDate;
        private MetroFramework.Controls.MetroTextBox txtReturnDate;
    }
}