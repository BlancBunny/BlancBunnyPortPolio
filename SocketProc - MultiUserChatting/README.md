# C언어 기반 소켓프로그래밍 실습 (Linux 환경), (TODO : windows 환경 연동 추가)

## 다중 사용자용 채팅 프로그램 구현

----------------

### 네트워크 환경
![image](https://user-images.githubusercontent.com/77951828/125376905-ef22d800-e3c6-11eb-8384-f6e1a6630a4f.png)

### 실행 결과   
 Raspberry Pi 사용자 (210.119.12.112) 와 가상 머신에 구축한 server 컴퓨터 루프백 유저 (210.119.12.96) 의 채팅 
![chat 통신](https://user-images.githubusercontent.com/77951828/125376953-0feb2d80-e3c7-11eb-830d-6e928ae465a8.JPG)

-------------------------

### 서버 모듈
[코드 전문](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/SocketProc%20-%20MultiUserChatting/chat_server.c)

사용법 : ./chatserver \<Port\>   

  socket()
<pre><code>
serv_sock=socket(PF_INET, SOCK_STREAM, 0);
</code></pre>
 
  bind(), listen()
<pre><code>
	if(bind(serv_sock, (struct sockaddr*) &serv_adr, sizeof(serv_adr)) == -1)
	  	error_handling("bind() error");
	if(listen(serv_sock, 5) == -1) 
		error_handling("listen() error");
</code></pre>
    	
  accept()
<pre><code>
	while(1) {
		clnt_adr_sz=sizeof(clnt_adr);
		clnt_sock=accept(serv_sock, (struct sockaddr*)&clnt_adr, &clnt_adr_sz);
		
		pthread_mutex_lock(&mutex);
		clnt_socks[clnt_cnt++]=clnt_sock; // 공유 데이터 임계 구역 
		pthread_mutex_unlock(&mutex);

		pthread_create(&t_id, NULL, handle_clnt, (void*)&clnt_sock); // 클라이언트의 쓰레드 생성 및 채팅 
		pthread_detach(t_id);					     
		printf("Connected client IP : %s\n", inet_ntoa(clnt_adr.sin_addr));
	}
	close(serv_sock);
</code></pre>
  
  
----------------

### 클라이언트 모듈 
[코드 전문](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/SocketProc%20-%20MultiUserChatting/chat_client.c)   
   
사용법 : ./chatserver \<IP\> \<port\> \<chatName\>

  socket()
<pre><code>
sock=socket(PF_INET, SOCK_STREAM, 0);
if(sock==-1) error_handling("socket() error");
</code></pre>

  server 소켓 정보 입력, connect()
<pre><code>
	memset(&serv_addr, 0, sizeof(serv_addr));
	serv_addr.sin_family=AF_INET;
	serv_addr.sin_addr.s_addr=inet_addr(argv[1]);
	serv_addr.sin_port=htons(atoi(argv[2]));
	
	if(connect(sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr))==-1)
		error_handling("connect() error");
</code></pre>

  송/수신용 스레드 생성
<pre><code>
	pthread_create(&snd_thread, NULL, send_msg, (void*)&sock);
	pthread_create(&rcv_thread, NULL, recv_msg, (void*)&sock);
	pthread_join(snd_thread, &thread_return);
	pthread_join(rcv_thread, &thread_return);
</code></pre>

  메시지 송신 함수
<pre><code>
  void* send_msg(void* arg) {
	int sock=*((int*)arg);
	char name_msg[NAME_SIZE+BUF_SIZE];
	while(1) {
		fgets(msg, BUF_SIZE, stdin);
		if(!strcmp(msg, "q\n") || !strcmp(msg, "Q\n")) {
			close(sock);
			exit(0);
		}
		sprintf(name_msg, "%s %s", name, msg);
		write(sock, name_msg, strlen(name_msg));
	}
	return NULL;
}
</pre></code>

  메시지 수신 함수
<pre><code>
  void* recv_msg(void* arg) {
	int sock=*((int*)arg);
	char name_msg[NAME_SIZE+BUF_SIZE];
	int str_len;
	while(1) {
		str_len=read(sock, name_msg, NAME_SIZE+BUF_SIZE-1);
		if(str_len==-1)
			return (void*)-1;
		name_msg[str_len]=0;
		fputs(name_msg, stdout);
	}
	return NULL;
}
</pre></code>




