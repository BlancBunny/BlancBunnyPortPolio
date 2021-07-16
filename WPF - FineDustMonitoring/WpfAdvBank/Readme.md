# 미세먼지 모니터링 프로그램 (WPF)
[WPF Xaml 코드](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WPF%20-%20FineDustMonitoring/WpfAdvBank/DustMonitoring/MainWindow.xaml)     
[메인 Xaml 비하인드 코드](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WPF%20-%20FineDustMonitoring/WpfAdvBank/DustMonitoring/MainWindow.xaml.cs)   

+ UI - WPF(MahApps:Metro 프레임워크) 기반 제작
+ 공공데이터포털(data.go.kr) 미세먼지 측정 기록 OpenAPI XML 활용
+ 엑셀 파일 연동    

## 실행 결과
![GOMCAM 20210716_1112580474](https://user-images.githubusercontent.com/77951828/125881216-dcbccb38-997d-4b1a-b91c-806f95fd09f8.gif)

##### 엑셀 데이터 시트
![image](https://user-images.githubusercontent.com/77951828/125881505-5331f0cc-f4c0-4bd2-ba12-997380d9ca73.png)


## 주요 코드 

### 엑셀 데이터 -> 측정소 선택 콤보박스 생성 함수
<pre><code>
private List<string> LoadStationList()
{
    // xls load 
    IWorkbook workbook = null;
    ISheet sheet;

    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
        workbook = new HSSFWorkbook(fs);
    }
    List<string> listMeasuringStation = new List<string>();
    sheet = workbook.GetSheetAt(0);
    int rowCount = sheet.LastRowNum; // 측정소 수 

    try
    {
        for (int r = 0; r <= rowCount; r++)
        {
            if (r == 0) continue;
            // 뽑아낸 엑셀 데이터의 2행 데이터(측정소 이름)를 리스트에 추가
            listMeasuringStation.Add(sheet.GetRow(r).Cells[1].ToString());
        }
    }
    catch { }
    return listMeasuringStation;
}
</code></pre>

### OpenAPI URL 생성
![image](https://user-images.githubusercontent.com/77951828/125882952-18ea4b58-a9a7-4a99-9d27-d8c21cbefaf7.png)
<pre><code>
private string openApiUrl = "http://apis.data.go.kr/B552584/ArpltnInforInqireSvc/getMsrstnAcctoRltmMesureDnsty?" +
                                    "serviceKey=kOsbgBOmBq5jFUqhXW9CFA2rbbSt7oOlh7QRPwz0kFOItyhgTkGXtAQsImKyCkvQOL9vjPBk94BLUMXXh4anjA%3D%3D&" +
                                    "returnType=xml&" +
                                    "numOfRows=100&" +
                                    "pageNo=1&" +
                                    "ver=1.0&" +
                                    "dataTerm=DAILY&" +
                                    "stationName=";
</code></pre>


### OpenAPI XML -> WPF ListView 생성 함수   
<pre><code>
private List<FineDustInfo> LoadApiData()
{
    lstResult = new List<FineDustInfo>();

    if (cboStations.SelectedItem != null)
    {
        // URL에 선택된 측정소명 추가 (stationName='측정소명')
        openApiUrl = openApiUrl.Substring(0, openApiUrl.LastIndexOf("=") + 1) + cboStations.SelectedItem.ToString();
        XmlDocument xml = new XmlDocument();
        xml.Load(openApiUrl); // xml 데이터 load 
        XmlNodeList xmllist = xml.SelectNodes("/response/body/items/item");
        
        // 뽑아낸 XML 데이터를 항목별로 FineDustInfo 클래스에 저장 
        foreach (XmlNode item in xmllist) 
        {
            FineDustInfo dustInfo = new FineDustInfo()
            {
                DataTime = item["dataTime"].InnerText,
                Khai = item["khaiValue"].InnerText,
                SO2 = item["so2Value"].InnerText,
                CO = item["coValue"].InnerText,
                PM10 = item["pm10Value"].InnerText,
                PM25 = item["pm25Value"].InnerText,
                NO2 = item["no2Value"].InnerText,
                O3 = item["o3Value"].InnerText,
            };
            lstResult?.Add(dustInfo);
        }
    }

    return lstResult;
}
</code></pre>
