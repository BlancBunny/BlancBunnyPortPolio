# ERP 제작 실습 프로젝트 - 데스크탑 앱(ERP 재고관리) 
[메인 Xaml](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WPF%20-%20ERP_Exercise/ERP_Exercise/ERP_Exercise/MainWindow.xaml)    
[메인 Xaml.cs](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WPF%20-%20ERP_Exercise/ERP_Exercise/ERP_Exercise/MainWindow.xaml.cs)    
## 프로젝트 설명 

+ ERP의 개념에 대해 학습하고 약식으로 가상의 기업에서 사용하는 간이 ERP를 제작   
+ 실제 기업에서의 사용 관련 정보가 부족하므로 제품의 입/출고 부분은 구현하지 않고   
<b>사용자 관리창과 현재 사용자의 정보 수정 및 관리 창고의 목록 출력, 추가, 수정 기능</b>만 구현   
+ 모든 데이터는 데이터베이스에 저장 및 연동 
+ 외부 라이브러리를 활용하여 엑셀/PDF 파일을 생성하여 정보를 저장하는 기능 추가 

--------------------------

## 사용 및 학습 기술
+ 사용 언어 - C#, Xaml 
+ GUI 디자인 - WPF(Mahapps.MetroUI)
+ DB - SQL-Server CRUD 기능 구현, SSMS를 통한 DB 관리   
EntityFramework 를 활용한 .NET 과 DB 연동 
+ Third-party Library - NFOI(Excel 파일 추출), itextsharp(PDF 파일 추출), NLog(개발 및 실행 중 로그 기록) 

--------------------------

## 실행 결과

#### 1. 로그인 화면
![GOMCAM 20210722_1517080315](https://user-images.githubusercontent.com/77951828/126596999-35344105-7a74-487f-b8c4-3d1551178e24.gif)

#### 2-1. [시스템 사용자 관리 화면](https://github.com/BlancBunny/BlancBunnyPortPolio/tree/main/WPF%20-%20ERP_Exercise/ERP_Exercise/ERP_Exercise/View/User)
![image](https://user-images.githubusercontent.com/77951828/126597300-12b7ca5c-77b3-4afd-9fd1-f4dcfb2c3e3e.png)

#### 2-2. 사용자 리스트 PDF 파일 추출   
![GOMCAM 20210722_1524530875](https://user-images.githubusercontent.com/77951828/126597659-bc283a39-5e82-431a-8aa6-382aaa792ffe.gif)

#### 2-3. 추출된 PDF 파일
![image](https://user-images.githubusercontent.com/77951828/126597778-1c2d0f06-a0fb-4691-a440-80c054e5cb81.png)

#### 3-1. 현재 사용자 정보 수정
![GOMCAM 20210722_1609080306](https://user-images.githubusercontent.com/77951828/126601728-f9b01467-7efe-49c7-9777-c10d6846d38a.gif)

#### 4-1. [관리 창고 리스트](https://github.com/BlancBunny/BlancBunnyPortPolio/tree/main/WPF%20-%20ERP_Exercise/ERP_Exercise/ERP_Exercise/View/Store)
![image](https://user-images.githubusercontent.com/77951828/126600827-7ad4c53c-3dcd-4565-85f6-be8988d3a2dc.png)

#### 4-2. 창고 리스트 DB 
![image](https://user-images.githubusercontent.com/77951828/126600896-2b58486d-2db0-4767-8777-82631ef21ff0.png)

#### 4-3. 엑셀 파일 추출 
![image](https://user-images.githubusercontent.com/77951828/126601182-71f1df50-6a29-4da3-b0b8-34f87045cdd6.png)

#### 5-1. 계정 로그아웃 및 프로그램 종료
![GOMCAM 20210722_1610570993](https://user-images.githubusercontent.com/77951828/126601940-65285be5-359f-4a45-b46d-af0f69d63ed6.gif)


--------------------------

## 기타

#### 1. DB 연동과 연결 문자열
```xaml
<entityFramework>
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
<connectionStrings>
   <add name="SMSEntities" connectionString="metadata=res://*/Model.SMSModel.csdl|res://*/Model.SMSModel.ssdl|res://*/Model.SMSModel.msl;provider=System.Data.SqlClient;provider   connection string=&quot;data source=127.0.0.1;initial catalog=SMS;persist security info=True;user id=sa;password=mssql_p@ssw0rd!;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
```

#### 2. NLog 를 활용한 로그 기록 
+ 오류 발생 가능성이 있는 모든 메소드에 Log 저장 코드를 삽입하여 코드의 구현 및 유지보수에 활용 가능
![image](https://user-images.githubusercontent.com/77951828/126603329-7fd2c894-a031-48ca-b5c5-34f35a293b10.png)
![image](https://user-images.githubusercontent.com/77951828/126603033-c0d66df6-666c-41fb-9ebf-f668a20030e1.png)
