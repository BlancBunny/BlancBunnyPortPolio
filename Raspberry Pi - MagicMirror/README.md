# 라즈베리파이 기반 Open API 활용 스마트미러 제작

## 실행 화면 
메인 실행 화면  
![image](https://user-images.githubusercontent.com/77951828/127789332-141d89f3-7fae-4acd-a746-4f8bf8adf824.png)   


실행 환경 전체   
![image](https://user-images.githubusercontent.com/77951828/127789432-384c4bc8-c286-42e9-aa28-a8ab5e47c9b7.png)   
 

## 실습 환경 
H/W : Raspberry Pi 4 B   
OS : Linux Raspbian 5.10.17   
Mic : 오디오 IC 개발 도구 ReSpeaker 4Mic Array for Raspberry Pi   


## 구현 순서 
MagicMirror 패키지 설치 -> 구글 캘린더 (내 스케줄 확인) 연동 -> 뉴스 feed 표시 -> 날씨, 미세먼지 출력 모듈 설치   
-> 구글 포토 연동으로 배경화면 설정 -> 구글 어시스턴트 연동 음성 인식 

#### 0. MagicMirror 패키지 설치 
https://github.com/MichMich/MagicMirror
리포지토리 작업 폴더에 복사후 npm 을 활용하여 패키지 인스톨    

---------------------------

#### 1. Google Calendar 
구글 캘린더에 입력한 스케줄을 스마트미러 화면에 표시 

1) 구글 캘린더에 여러 스케줄 표시
![image](https://user-images.githubusercontent.com/77951828/127790237-8aef5245-0c64-4f99-82c3-dd6bd77433e5.png)   

2) 계정 고유 연동 주소를 js 파일에 복사   
![image](https://user-images.githubusercontent.com/77951828/127790309-c407409e-8084-44cd-83ac-174e5a4caee4.png)   
![image](https://user-images.githubusercontent.com/77951828/127790163-08a7d997-4e75-4349-8ecd-24609b5bc3f0.png)   


3) 캘린더 연동 결과   
![image](https://user-images.githubusercontent.com/77951828/127790242-8f0f1d6e-97bc-427b-a586-8f9e878793df.png)  

----------------------------

#### 2. 뉴스 API 연동 
사용할 뉴스 Feed Url : https://news.google.com/rss?pz=1&hl=ko&topic=po&gl=KR&ceid=KR:ko   
![image](https://user-images.githubusercontent.com/77951828/127790852-f101032d-950a-4aba-964a-4c935e88b755.png)   

화면 하단에 불러온 뉴스 표시   
![image](https://user-images.githubusercontent.com/77951828/127790937-7c65211f-59ae-4467-86fa-236827839f14.png)   

-----------------------------

#### 3. 날씨, 미세먼지 출력 
1) 패키지 설치 : [MMM-Weather](https://github.com/bugsounet/MMM-Weather), [MMM-Airquality](https://github.com/CFenner/MMM-AirQuality)   
2) OpenWeather 사이트 로그인 후 API 키 발급 
![image](https://user-images.githubusercontent.com/77951828/127791269-59a6713e-2490-4d9c-9052-533fd199d3d5.png)   
3) js 파일 편집(API 키, 날씨 표시 위도/경도 입력) 
![image](https://user-images.githubusercontent.com/77951828/127791325-e29c3484-18fd-49b7-83ad-027682cc4f58.png)   
![image](https://user-images.githubusercontent.com/77951828/127791474-657fb592-0417-478c-8d0c-48df15293cb0.png)

-----------------------------

#### 4. 구글 포토 연동 배경화면 설정   
1) 패키지 설치 : [MMM-GooglePhotos](https://github.com/aneaville/MMM-GooglePhotos)     
2) Actions on Google 에 사용할 기기 등록 및 증명서 발급   
![image](https://user-images.githubusercontent.com/77951828/127792604-4f931595-0072-47f9-a082-b44dda3daaf4.png)   
3) Google Cloud Flatform 에 프로젝트 생성 및 사용자 등록   
![image](https://user-images.githubusercontent.com/77951828/127792757-e199a6ac-4a06-48ae-9ba5-385de5211367.png)   
4) 메뉴얼에 따라 인증 토큰 생성      
$ node generate_token.js     
-> 제공되는 Url에 구글 계정으로 로그인하여 생성되는 문자열 입력      
5) 구글 포토에 앨범 생성     
![image](https://user-images.githubusercontent.com/77951828/127792941-2d5b9bc7-a826-4a36-b918-a539da11def8.png)    
6) js 파일 편집    
![image](https://user-images.githubusercontent.com/77951828/127793020-18493b5e-fe29-4acc-8681-0d7306017102.png)   

------------------------------

#### 5. 구글 어시스턴트 연동 
1) 패키지 설치 : [MMM-Detector](https://github.com/bugsounet/MMM-Detector), [MMM-GoogleAssistant](https://github.com/bugsounet/MMM-GoogleAssistant)    
Detector : 음성 인식 기능 / GoogleAssistant : 구글 제공 인공지능 비서    
3) Actions on Google 에 사용할 기기 등록 및 증명서 발급 (4-2와 동일)    
4) Google Cloud Flatform 에 프로젝트 생성 및 사용자 등록 (4-3과 동일)    
5) 인증 토큰 생성    
$ npm run tokens    
-> 제공되는 Url에 구글 계정으로 로그인하여 생성되는 문자열 입력    
6) js 파일 편집   
![image](https://user-images.githubusercontent.com/77951828/127793505-0082ed22-a26c-49c0-8e5b-ea1ae50d7058.png)   
=> Detector 모델 : jarvis 선택   
![image](https://user-images.githubusercontent.com/77951828/127793540-cf3a1d18-b24e-493c-9333-20c70f4d29d1.png)   

------------------------------

#### 6. 화면 설정 (css) 
화면에 표시되는 각 패키지가 배경화면과 겹쳐서 잘 안보이기 때문에      
반투명한 배경을 각 요소에 추가 (alpha = 0.3)    
![image](https://user-images.githubusercontent.com/77951828/127793689-33a985bc-ddbe-4090-99d0-23a991fa9114.png)    
=> 모듈 별로 css 파일을 찾아 요소 별로 background 지정    

