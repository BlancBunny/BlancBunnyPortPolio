
namespace BookRentalShopApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.관리MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDivCode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMember = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBook = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRental = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.관리MToolStripMenuItem,
            this.mnuExit});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1240, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 관리MToolStripMenuItem
            // 
            this.관리MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDivCode,
            this.mnuMember,
            this.mnuBook,
            this.toolStripMenuItem1,
            this.mnuRental});
            this.관리MToolStripMenuItem.Name = "관리MToolStripMenuItem";
            this.관리MToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.관리MToolStripMenuItem.Text = "관리(&M)";
            // 
            // mnuDivCode
            // 
            this.mnuDivCode.Name = "mnuDivCode";
            this.mnuDivCode.Size = new System.Drawing.Size(180, 22);
            this.mnuDivCode.Text = "구분 코드(&C)";
            this.mnuDivCode.Click += new System.EventHandler(this.mnuDivCode_Click);
            // 
            // mnuMember
            // 
            this.mnuMember.Name = "mnuMember";
            this.mnuMember.Size = new System.Drawing.Size(180, 22);
            this.mnuMember.Text = "회원(&M)";
            this.mnuMember.Click += new System.EventHandler(this.mnuMember_Click);
            // 
            // mnuBook
            // 
            this.mnuBook.Name = "mnuBook";
            this.mnuBook.Size = new System.Drawing.Size(180, 22);
            this.mnuBook.Text = "도서(&B)";
            this.mnuBook.Click += new System.EventHandler(this.mnuBook_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuRental
            // 
            this.mnuRental.Name = "mnuRental";
            this.mnuRental.Size = new System.Drawing.Size(180, 22);
            this.mnuRental.Text = "대여(&R) ";
            this.mnuRental.Click += new System.EventHandler(this.mnuRental_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(58, 20);
            this.mnuExit.Text = "종료(&X)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Book Rental Shop v0.5";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 관리MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDivCode;
        private System.Windows.Forms.ToolStripMenuItem mnuMember;
        private System.Windows.Forms.ToolStripMenuItem mnuBook;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuRental;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}

