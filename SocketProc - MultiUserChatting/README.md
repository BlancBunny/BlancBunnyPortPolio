# C언어 기반 소켓프로그래밍 실습 (Linux)

## 다중 사용자용 채팅 프로그램 구현

----------------
### 서버 모듈
[코드 전문](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/SocketProc%20-%20MultiUserChatting/chat_server.c)

사용법 : ./chatserver <Port>   

  socket 생성
'''
    serv_sock=socket(PF_INET, SOCK_STREAM, 0);
'''
  
  bind(), listen()
'''
    if(bind(serv_sock, (struct sockaddr*) &serv_adr, sizeof(serv_adr)) == -1)
	  	error_handling("bind() error");
  	if(listen(serv_sock, 5) == -1) 
  		error_handling("listen() error");
'''
  
  
----------------

### 클라이언트 모듈 
[코드 전문](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/SocketProc%20-%20MultiUserChatting/chat_client.c)

### 네트워크 환경
![image](https://user-images.githubusercontent.com/77951828/125376905-ef22d800-e3c6-11eb-8384-f6e1a6630a4f.png)

### 실행 결과   
가상 머신에 구축한 server 컴퓨터 루프백 유저와 Raspberry Pi 유저의 채팅 
![chat 통신](https://user-images.githubusercontent.com/77951828/125376953-0feb2d80-e3c7-11eb-830d-6e928ae465a8.JPG)

