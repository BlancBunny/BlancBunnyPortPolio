# Winform - [도서 대여점 관리 프로그램](https://github.com/BlancBunny/StudyDesktopApp/tree/main/WinformApp/WinFormAdvancedBank/BookRentalShopApp)
제작툴 : Visual Studio, Winform Metro UI Framework 사용   
주요 기능 : 관리자 로그인 기능, 회원 관리, 도서 관리, 대여 현황 관리, DB CRUD   

## 실행 화면
1) 로그인 화면  
![로그인 화면](https://user-images.githubusercontent.com/77951828/111719135-9d49c580-889e-11eb-9c7d-e56db775adf8.png)  
2) 회원 관리창  
![회원 관리창](https://user-images.githubusercontent.com/77951828/111718946-3c21f200-889e-11eb-8656-b4f02b6030fc.png)  
3) 도서 목록 관리  
![도서 목록 관리](https://user-images.githubusercontent.com/77951828/111719095-85724180-889e-11eb-8215-2aa10b0a3d6a.png)  
4) 대여 현황 관리  
![대여 현황 관리](https://user-images.githubusercontent.com/77951828/111719193-b9e5fd80-889e-11eb-9ea7-2e5ee7b6d3f7.png)  
5) DB 연동 (MS-SQL)
![DB 연동](https://user-images.githubusercontent.com/77951828/111719285-e7cb4200-889e-11eb-958b-58821a0c000d.png)  

------------------------

## 주요 코드

[메인 Form](https://github.com/BlancBunny/StudyDesktopApp/blob/main/WinformApp/WinFormAdvancedBank/BookRentalShopApp/MainForm.cs)    
[로그인 화면](https://github.com/BlancBunny/StudyDesktopApp/blob/main/WinformApp/WinFormAdvancedBank/BookRentalShopApp/LoginForm.cs)   
[회원 관리](https://github.com/BlancBunny/StudyDesktopApp/blob/main/WinformApp/WinFormAdvancedBank/BookRentalShopApp/MemberForm.cs)   
[도서 관리](https://github.com/BlancBunny/StudyDesktopApp/blob/main/WinformApp/WinFormAdvancedBank/BookRentalShopApp/BooksForm.cs)   
[대여 관리](https://github.com/BlancBunny/StudyDesktopApp/blob/main/WinformApp/WinFormAdvancedBank/BookRentalShopApp/RentalForm.cs)   

## 데이터베이스

사용 RDBMS : MS-SQL   
<pre><code>
bookstbl : 도서 목록    
divtbl : 도서 분류코드   
rentaltbl : 대여 목록   
membertbl : 회원 목록   
</code></pre>
![image](https://user-images.githubusercontent.com/77951828/126252062-56637ac9-9dee-4c6f-a6e4-4d8641c6ea19.png)

