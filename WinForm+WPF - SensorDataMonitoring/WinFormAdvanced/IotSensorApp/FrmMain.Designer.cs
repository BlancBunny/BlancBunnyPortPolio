
namespace IotSensorApp
{
    partial class FrmMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSimulation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBeginSim = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEndSim = new System.Windows.Forms.ToolStripMenuItem();
            this.lblConnectTime = new System.Windows.Forms.Label();
            this.txtSensorNum = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prbPhotoResistor = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.libPhotoResistor = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboSerialPort = new System.Windows.Forms.ComboBox();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnZoom = new System.Windows.Forms.Button();
            this.chtPhotoResistor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtPhotoResistor)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuSimulation});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(57, 20);
            this.mnuFile.Text = "파일(&F)";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(137, 22);
            this.mnuOpen.Text = "열기(&O)";
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(137, 22);
            this.mnuSave.Text = "저장하기(&S)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(137, 22);
            this.mnuExit.Text = "종료(&X)";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuSimulation
            // 
            this.mnuSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBeginSim,
            this.mnuEndSim});
            this.mnuSimulation.Name = "mnuSimulation";
            this.mnuSimulation.Size = new System.Drawing.Size(94, 20);
            this.mnuSimulation.Text = "시뮬레이션(&S)";
            // 
            // mnuBeginSim
            // 
            this.mnuBeginSim.Name = "mnuBeginSim";
            this.mnuBeginSim.Size = new System.Drawing.Size(113, 22);
            this.mnuBeginSim.Text = "시작(&B)";
            this.mnuBeginSim.Click += new System.EventHandler(this.mnuBeginSim_Click);
            // 
            // mnuEndSim
            // 
            this.mnuEndSim.Name = "mnuEndSim";
            this.mnuEndSim.Size = new System.Drawing.Size(113, 22);
            this.mnuEndSim.Text = "종료(&E)";
            this.mnuEndSim.Click += new System.EventHandler(this.mnuEndSim_Click);
            // 
            // lblConnectTime
            // 
            this.lblConnectTime.AutoSize = true;
            this.lblConnectTime.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConnectTime.Location = new System.Drawing.Point(12, 30);
            this.lblConnectTime.Name = "lblConnectTime";
            this.lblConnectTime.Size = new System.Drawing.Size(228, 15);
            this.lblConnectTime.TabIndex = 1;
            this.lblConnectTime.Text = "Connection Time : 2021-03-16 10:32:16";
            // 
            // txtSensorNum
            // 
            this.txtSensorNum.Location = new System.Drawing.Point(261, 29);
            this.txtSensorNum.Name = "txtSensorNum";
            this.txtSensorNum.ReadOnly = true;
            this.txtSensorNum.Size = new System.Drawing.Size(68, 21);
            this.txtSensorNum.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.prbPhotoResistor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(13, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 78);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MeasureValue";
            // 
            // prbPhotoResistor
            // 
            this.prbPhotoResistor.Location = new System.Drawing.Point(6, 22);
            this.prbPhotoResistor.Maximum = 1023;
            this.prbPhotoResistor.Name = "prbPhotoResistor";
            this.prbPhotoResistor.Size = new System.Drawing.Size(340, 23);
            this.prbPhotoResistor.TabIndex = 2;
            this.prbPhotoResistor.Value = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "1023";
            // 
            // libPhotoResistor
            // 
            this.libPhotoResistor.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.libPhotoResistor.FormattingEnabled = true;
            this.libPhotoResistor.ItemHeight = 15;
            this.libPhotoResistor.Location = new System.Drawing.Point(13, 152);
            this.libPhotoResistor.Name = "libPhotoResistor";
            this.libPhotoResistor.ScrollAlwaysVisible = true;
            this.libPhotoResistor.Size = new System.Drawing.Size(352, 94);
            this.libPhotoResistor.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDisplay);
            this.groupBox2.Controls.Add(this.btnDisconnect);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.cboSerialPort);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(371, 27);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 225);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.btnDisplay.Location = new System.Drawing.Point(5, 165);
            this.btnDisplay.Margin = new System.Windows.Forms.Padding(5);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(90, 50);
            this.btnDisplay.TabIndex = 3;
            this.btnDisplay.Text = "COM3";
            this.btnDisplay.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(5, 109);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(5);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(90, 50);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 53);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 50);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboSerialPort
            // 
            this.cboSerialPort.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSerialPort.FormattingEnabled = true;
            this.cboSerialPort.Location = new System.Drawing.Point(6, 26);
            this.cboSerialPort.Margin = new System.Windows.Forms.Padding(5);
            this.cboSerialPort.Name = "cboSerialPort";
            this.cboSerialPort.Size = new System.Drawing.Size(89, 21);
            this.cboSerialPort.TabIndex = 0;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewAll.Location = new System.Drawing.Point(96, 553);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(144, 23);
            this.btnViewAll.TabIndex = 4;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZoom.Location = new System.Drawing.Point(246, 553);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(144, 23);
            this.btnZoom.TabIndex = 5;
            this.btnZoom.Text = "Zoom";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // chtPhotoResistor
            // 
            chartArea1.Name = "ChartArea1";
            this.chtPhotoResistor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtPhotoResistor.Legends.Add(legend1);
            this.chtPhotoResistor.Location = new System.Drawing.Point(13, 259);
            this.chtPhotoResistor.Name = "chtPhotoResistor";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtPhotoResistor.Series.Add(series1);
            this.chtPhotoResistor.Size = new System.Drawing.Size(459, 288);
            this.chtPhotoResistor.TabIndex = 6;
            this.chtPhotoResistor.Text = "chart1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 611);
            this.Controls.Add(this.chtPhotoResistor);
            this.Controls.Add(this.btnZoom);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.libPhotoResistor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSensorNum);
            this.Controls.Add(this.lblConnectTime);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iot Photoresistor Monitoring";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtPhotoResistor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuSimulation;
        private System.Windows.Forms.ToolStripMenuItem mnuBeginSim;
        private System.Windows.Forms.ToolStripMenuItem mnuEndSim;
        private System.Windows.Forms.Label lblConnectTime;
        private System.Windows.Forms.TextBox txtSensorNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar prbPhotoResistor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox libPhotoResistor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboSerialPort;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtPhotoResistor;
    }
}

