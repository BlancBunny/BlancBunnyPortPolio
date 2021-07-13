using LiveCharts;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data;
using System.Diagnostics;
using OxyPlot;

namespace SensorMonitoringApp
{

    public class SensorData
    {
        public int Idx { get; set; }
        public DateTime CurrTime { get; set; }
        public int Value { get; set; }
        public bool SimFlag { get; set; }
        public SensorData(int idx, DateTime currTime, int value, bool simFlag)
        {
            Idx = idx;
            CurrTime = currTime;
            Value = value;
            SimFlag = simFlag;
        }
    }
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        #region Global Variable
            private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            public DispatcherTimer CustomTimer { get; set; }
            public ChartValues<int> ChartValues { get; set; }
            public int SensorValue { get; set; }
            string strConn = "Data Source=210.119.12.96;Initial Catalog=IoTData;" +
                                  "Persist Security Info=True;User ID=sa;Password=mssql_p@ssw0rd!;";
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Event Handler
            private void MetroWindow_Initialized(object sender, EventArgs e)
            {
                //    var x = Enumerable.Range(0, 1001).Select(i => i / 10.0).ToArray();
                //    var y = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v).ToArray();
                //    chtLine.Plot(x, y);

                chtHistory.DataContext = ChartValues;

                CustomTimer = new DispatcherTimer();
                CustomTimer.Interval = TimeSpan.FromSeconds(1);
                CustomTimer.Tick += CustomTimer_Tick;
            }
            private void CustomTimer_Tick(object sender, EventArgs e)
            {
                // SensorValue = new Random().Next(0, 1023);
                chtSensorGauge.DataContext = GetRealTimeSensor().Value;
            }
            private void mnuBegin_Click(object sender, RoutedEventArgs e)
            {
                CustomTimer.Start();
            }
            private void mnuStop_Click(object sender, RoutedEventArgs e)
            {
                CustomTimer.Stop();
            }
            private void mnuLoad_Click(object sender, RoutedEventArgs e)
            {
                // ChartValues = GetHistorySensors(); -> LiveChart
                chtHistory.ItemsSource = GetHistorySensors();
            }
            private void mnuExit_Click(object sender, RoutedEventArgs e)
            {
                // Environment.Exit(0);
                Application.Current.Shutdown(0);
            }
        #endregion 


        /// <summary>
        /// 실시간 센서값 모니터링 
        /// </summary>
        /// <returns></returns>
        private SensorData GetRealTimeSensor()
        {
            SensorData result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT TOP 1 [idx]
                                                  ,[currTime]
                                                  ,[value]
                                                  ,[simFlag]
                                              FROM [dbo].[PhotoResisterTbl]
                                              ORDER BY idx DESC; ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    var temp = cmd.ExecuteReader();
                    if (temp.Read())
                    {
                        result = new SensorData(Convert.ToInt32(temp["idx"]),
                                                Convert.ToDateTime(temp["currTime"]),
                                                Convert.ToInt32(temp["value"]),
                                                Convert.ToBoolean(temp["simFlag"]));
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"예외발생 : {ex.Message}");
            }
            return result;
        }

        /// <summary>
        /// 저장된 센서값 히스토리 불러오기 
        /// </summary>
        /// <returns></returns>
        private List<DataPoint> GetHistorySensors()
        {
            List<DataPoint> result = new List<DataPoint>();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    var query = $@"SELECT [Idx], [Value]
                                FROM [dbo].[PhotoResisterTbl]
                                WHERE currTime > CONVERT(datetime, '{DateTime.Now.ToString("yyyy - MM - dd")}')
                                ORDER BY idx ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new DataPoint(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1])));
                    }
                }
                logger.Info("GetRealTimeSensor() completed!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"예외발생 : {ex.Message}");
                logger.Error($"GetRealTimeSensor() Error! : {ex.Message}");
            }
            return result;
        }
    }
}
