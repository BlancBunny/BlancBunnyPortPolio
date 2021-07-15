# Sensor 측정 값 모니터링 시스템 (Winform / WPF)

+ 측정 수치 모니터링(Winform) 
+ 실시간 수치 확인과 히스토리 확인(WPF) 
+ MS-SQL DB 연동

![image](https://user-images.githubusercontent.com/77951828/125412399-da136c80-e3f9-11eb-97d0-1895058e09e7.png)
-----------------------------


## 1. Winform 센서값 모니터링 프로그램
[코드 전문](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WinForm%2BWPF%20-%20SensorDataMonitoring/WinFormAdvanced/IotSensorApp/FrmMain.cs)
##### 실행 화면
![GOMCAM 20210715_0950470363](https://user-images.githubusercontent.com/77951828/125710966-e1929822-bb6f-4a8a-8883-34ed123df7ee.gif)
##### DB 저장 화면
![image](https://user-images.githubusercontent.com/77951828/125711139-a604a295-bf54-4f73-be1f-99fe725260b3.png)

### 주요 기능
+ DB 연결   
<pre><code>

private string connString = $"Data Source=127.0.0.1;Initial Catalog=IoTData;Persist Security Info=True;User ID=sa;Password=mssql_p@ssw0rd!";   

</code></pre>

+ 센서값 생성(random() 함수 활용)
<pre><code>

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

</code></pre>

+ 측정값 차트에 표시
<pre><code>

private void ShowValue(string value)
{
    int.TryParse(value, out int v);
    prbPhotoResistor.Value = v;
    SensorData data = new SensorData(currentTime, v, simulationFlag);
    myData.Add(data); 
    txtSensorNum.Text = $"{myData.Count}";

    var item = currentTime.ToString($"yyyy-MM-dd HH:mm:ss\t{v}");
    libPhotoResistor.Items.Add(item);
    libPhotoResistor.SelectedIndex = libPhotoResistor.Items.Count - 1;

    chtPhotoResistor.Series[0].Points.Add(v); // 측정값 좌표 차트에 추가하기

    DBInsert(data); // DB에 데이터 입력
}

</code></pre>

+ DB Insert 쿼리문 실행
<pre><code>

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

</code></pre>

## 2. WPF DB 데이터 모니터링 프로그램
[MainWindow.xaml.cs](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WinForm%2BWPF%20-%20SensorDataMonitoring/WpfAdvanced/SensorMonitoringApp/MainWindow.xaml.cs)

##### 실행 화면
![image](https://user-images.githubusercontent.com/77951828/125714444-0313789e-7f74-4d0d-a976-9c36e9a98bae.png)   
##### winform 앱과 연동
![GOMCAM 20210715_1034580985](https://user-images.githubusercontent.com/77951828/125714263-d75107b4-b264-4e9e-b02e-3923957e38e7.gif)




