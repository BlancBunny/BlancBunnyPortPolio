using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IotSensorApp
{
    public partial class FrmMain : Form
    {
        private double xCount = 200; // 차트에 보여지는 데이터 개수
        List<SensorData> myData = new List<SensorData>();
        private Timer t = new Timer();
        private Random r = new Random();
        private bool simulationFlag;
        SerialPort sPort;
        private int value = 0;
        private string connString = $"Data Source=127.0.0.1;Initial Catalog=IoTData;Persist Security Info=True;User ID=sa;Password=mssql_p@ssw0rd!";


        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
            // Combobox Initialize 
            foreach (var port in SerialPort.GetPortNames())
            {
                cboSerialPort.Items.Add(port);
            }
            cboSerialPort.Text = "Select Port";

            // Value Domain
            prbPhotoResistor.Minimum = 0;
            prbPhotoResistor.Maximum = 1023;
            prbPhotoResistor.Value = 0;

            // Chart Initialize 
            InitChart();

            // btnDisplay Initialize 
            btnDisplay.BackColor = Color.BlueViolet;
            btnDisplay.ForeColor = Color.WhiteSmoke;
            btnDisplay.Text = "None";
            btnDisplay.Font = new Font("맑은 고딕", 14, FontStyle.Bold);

            // Initialize
            lblConnectTime.Text = "Connect Time : ";
            txtSensorNum.TextAlign = HorizontalAlignment.Right;
            txtSensorNum.Text = "0";
            btnConnect.Enabled = btnDisconnect.Enabled = false;
            
        }
        
        private void InitChart()
        {
            ChartShape();
            // Series
            chtPhotoResistor.Series.Clear();
            chtPhotoResistor.Series.Add("PhotoValue");
            chtPhotoResistor.Series["PhotoValue"].ChartType = SeriesChartType.Line;
            chtPhotoResistor.Series["PhotoValue"].Color = Color.LightGreen;
            chtPhotoResistor.Series["PhotoValue"].BorderWidth = 3;
            
            // Legends
            if (chtPhotoResistor.Legends.Count > 0) chtPhotoResistor.Legends.RemoveAt(0);
            
        }
        private void ChartShape()
        {
            chtPhotoResistor.ChartAreas[0].BackColor = Color.Blue;

            // Axis X
            chtPhotoResistor.ChartAreas[0].AxisX.Minimum = 0;
            chtPhotoResistor.ChartAreas[0].AxisX.Maximum = xCount;
            chtPhotoResistor.ChartAreas[0].AxisX.Interval = xCount / 8;
            chtPhotoResistor.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.WhiteSmoke;
            chtPhotoResistor.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Axis Y
            chtPhotoResistor.ChartAreas[0].AxisY.Minimum = 200;
            chtPhotoResistor.ChartAreas[0].AxisY.Maximum = 700;
            chtPhotoResistor.ChartAreas[0].AxisY.Interval = 100;
            chtPhotoResistor.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.WhiteSmoke;
            chtPhotoResistor.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Scroll
            chtPhotoResistor.ChartAreas[0].CursorX.AutoScroll = true;
            chtPhotoResistor.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chtPhotoResistor.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;
            chtPhotoResistor.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // TODO 실제 작업 시 작성
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // TODO 실제 작업 시 작성
        }

        private long timespan = 0;
        private int randMaxVal = 0;
        private void T_Tick(object sender, EventArgs e)
        {
            ChartShape();
            timespan += 1;
            var temp = timespan % 30;

            if (temp < 20)
            {
                randMaxVal = 300;
            }
            else randMaxVal = 600;
            
            value = r.Next(randMaxVal - 40, randMaxVal);
            ShowValue(value.ToString());
        }

        

        /// <summary>
        /// 측정 값 출력
        /// </summary>
        /// <param name="value"></param>
        private void ShowValue(string value)
        {
            var currentTime = DateTime.Now;
            int.TryParse(value, out int v);
            prbPhotoResistor.Value = v;
            SensorData data = new SensorData(currentTime, v, simulationFlag);
            myData.Add(data);
            txtSensorNum.Text = $"{myData.Count}";

            if (simulationFlag == false) btnDisplay.Text = sPort.PortName + "\n" + value;
            else btnDisplay.Text = value;

            var item = currentTime.ToString($"yyyy-MM-dd HH:mm:ss\t{v}");
            libPhotoResistor.Items.Add(item);
            libPhotoResistor.SelectedIndex = libPhotoResistor.Items.Count - 1;

            chtPhotoResistor.Series[0].Points.Add(v);

            chtPhotoResistor.ChartAreas[0].AxisX.Minimum = 0;
            chtPhotoResistor.ChartAreas[0].AxisX.Maximum
                = (myData.Count >= xCount) ? myData.Count : xCount;

            

            if (myData.Count > xCount)
            {
                chtPhotoResistor.ChartAreas[0].AxisX.ScaleView.Zoom(
                    myData.Count - xCount, myData.Count);
            }
            else chtPhotoResistor.ChartAreas[0].AxisX.ScaleView.Zoom(0, xCount);

            DBInsert(data);
        }

        private void DBInsert(SensorData data)
        {
            string query = $"INSERT INTO PhotoResisterTbl " +
                $"(currTime, value, simFlag) VALUES ('{data.CurrTime:yyyy-MM-dd HH:mm:ss}', '{data.Value}', '{data.SimFlag}')";

            using (SqlConnection conn = new SqlConnection(connString)) 
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 시뮬레이션 시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuBeginSim_Click(object sender, EventArgs e)
        {
            simulationFlag = true;
            mnuBeginSim.Enabled = false;
            mnuEndSim.Enabled = true;
            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
        }
        /// <summary>
        /// 시뮬레이션 끝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEndSim_Click(object sender, EventArgs e)
        {
            t.Tick -= T_Tick;
            mnuBeginSim.Enabled = true;
            mnuEndSim.Enabled = false;
            t.Stop();
            simulationFlag = false;
        }
        
        /// <summary>
        /// 종료버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (simulationFlag)
            {
                MessageBox.Show("You must stop Simulate!","Exit",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Environment.Exit(0);
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            chtPhotoResistor.ChartAreas[0].AxisX.Minimum = 0;
            chtPhotoResistor.ChartAreas[0].AxisX.Maximum = myData.Count;

            chtPhotoResistor.ChartAreas[0].AxisX.ScaleView.Zoom(0, myData.Count);
            chtPhotoResistor.ChartAreas[0].AxisX.Interval = myData.Count / 4;
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            chtPhotoResistor.ChartAreas[0].AxisX.Minimum = 0;
            chtPhotoResistor.ChartAreas[0].AxisX.Maximum = myData.Count;

            chtPhotoResistor.ChartAreas[0].AxisX.ScaleView.Zoom(myData.Count - xCount, myData.Count);
            chtPhotoResistor.ChartAreas[0].AxisX.Interval = myData.Count / 4;
        }
    }
}
