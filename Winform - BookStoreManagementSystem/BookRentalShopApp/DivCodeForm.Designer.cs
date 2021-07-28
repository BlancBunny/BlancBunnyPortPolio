
namespace BookRentalShopApp
{
    partial class DivCodeForm
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
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnNew = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.txtDivName = new MetroFramework.Controls.MetroTextBox();
            this.txtDiv = new MetroFramework.Controls.MetroTextBox();
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
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.txtDivName);
            this.groupBox1.Controls.Add(this.txtDiv);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Location = new System.Drawing.Point(903, 94);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(274, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상세";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(192, 124);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "저장";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(102, 124);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 40);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "신규";
            this.btnNew.UseSelectable = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 124);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDivName
            // 
            // 
            // 
            // 
            this.txtDivName.CustomButton.Image = null;
            this.txtDivName.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.txtDivName.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDivName.CustomButton.Name = "";
            this.txtDivName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtDivName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDivName.CustomButton.TabIndex = 1;
            this.txtDivName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDivName.CustomButton.UseSelectable = true;
            this.txtDivName.CustomButton.Visible = false;
            this.txtDivName.Lines = new string[0];
            this.txtDivName.Location = new System.Drawing.Point(102, 68);
            this.txtDivName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDivName.MaxLength = 32767;
            this.txtDivName.Name = "txtDivName";
            this.txtDivName.PasswordChar = '\0';
            this.txtDivName.PromptText = "구분 코드명 입력";
            this.txtDivName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDivName.SelectedText = "";
            this.txtDivName.SelectionLength = 0;
            this.txtDivName.SelectionStart = 0;
            this.txtDivName.ShortcutsEnabled = true;
            this.txtDivName.Size = new System.Drawing.Size(155, 29);
            this.txtDivName.TabIndex = 2;
            this.txtDivName.UseSelectable = true;
            this.txtDivName.WaterMark = "구분 코드명 입력";
            this.txtDivName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDivName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDiv
            // 
            // 
            // 
            // 
            this.txtDiv.CustomButton.Image = null;
            this.txtDiv.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.txtDiv.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiv.CustomButton.Name = "";
            this.txtDiv.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtDiv.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDiv.CustomButton.TabIndex = 1;
            this.txtDiv.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDiv.CustomButton.UseSelectable = true;
            this.txtDiv.CustomButton.Visible = false;
            this.txtDiv.Lines = new string[0];
            this.txtDiv.Location = new System.Drawing.Point(102, 39);
            this.txtDiv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiv.MaxLength = 32767;
            this.txtDiv.Name = "txtDiv";
            this.txtDiv.PasswordChar = '\0';
            this.txtDiv.PromptText = "구분 코드 입력";
            this.txtDiv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDiv.SelectedText = "";
            this.txtDiv.SelectionLength = 0;
            this.txtDiv.SelectionStart = 0;
            this.txtDiv.ShortcutsEnabled = true;
            this.txtDiv.Size = new System.Drawing.Size(155, 29);
            this.txtDiv.TabIndex = 1;
            this.txtDiv.UseSelectable = true;
            this.txtDiv.WaterMark = "구분 코드 입력";
            this.txtDiv.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDiv.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(6, 76);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(90, 19);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "구분 코드명 :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(6, 47);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(76, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "구분 코드 :";
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
            this.dgvData.Size = new System.Drawing.Size(880, 520);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // DivCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.ControlBox = false;
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DivCodeForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "책 구분코드 관리";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DivCodeForm_Load);
            this.Resize += new System.EventHandler(this.DivCodeForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnNew;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroTextBox txtDivName;
        private MetroFramework.Controls.MetroTextBox txtDiv;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView dgvData;
    }
}