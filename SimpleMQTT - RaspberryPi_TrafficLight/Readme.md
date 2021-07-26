# MQTT 프로토콜 테스트

## 1. 프로젝트 개요
+ MQTT 프로토콜 기반 Winform Application 과 라즈베리파이 Linux의 통신 테스트 

## 2. 사용 및 학습 기술 
+ 언어 - C# WinForm, Python
+ H/W - Raspberry Pi 4 센서/액추에이터 활용 회로 구성
+ OS - Linux(Raspbian)
+ 통신 프로토콜 - MQTT(표준 발행-구독 기반 메시지 프로토콜)   
브로커 환경 구성, 메시지 발행/구독 코드 구현 (C# / Python) 

## 3. MQTT 개요 
![image](https://user-images.githubusercontent.com/77951828/126918452-2a2b69e8-dda4-4f5c-aa39-020dfdecdc67.png)   
(이미지 출처 : https://sakshambhatla.wordpress.com)

#### 장점   
+ 프로토콜이 차지하는 리소스 점유 최소화 -> 임베디드 시스템 / 사물인터넷 환경에 적합 
+ 저성능/저품질 네트워크의 장애와 단절에 대비
+ 다수의 클라이언트 연결에 적합한 Subscribe / Publish 네트워크 채용
+ 오픈 소스 기반 메시징 프로토콜 지향 (서드 파티 hw 제조 / sw 개발 업체의 용이한 도입, 적용)

#### MQTT Broker (Server 역할)   
+ Eclipse 사의 Mosquitto 프로그램 사용 
![image](https://user-images.githubusercontent.com/77951828/126919116-857597ab-e037-41ac-a5e3-a16f2e10d11a.png)

+ 메시지 구독/발행 여부 확인 프로그램 사용 (MQTT Explorer) 
=> 서버 컴퓨터로 발행되는 메시지 감시 (127.0.0.1:1883)
![image](https://user-images.githubusercontent.com/77951828/126919285-04c5b693-4fd1-45ad-89e9-44df9760f382.png)
TRAFFICLIGHT/TEST topic으로 'r' 메시지를 전송했을 때 


#### MQTT Publisher (메시지 발행) 

+ C# 코드 
<pre><code>
private void Publish(string message)
{
    client.Publish(subscriptionTopic,                   // topic
                      Encoding.UTF8.GetBytes(message),  // message body 
                      0,                                // QoS level  0 : 최대 한번, 1 : 최소 한번(반복 요청), 2 : 정확히 한번
                      true);                            // retained (서버에 메시지를 저장했다가 구독 요청이
                                                        //          들어오면 retain 되어 있는 메시지를 전송) 
}
</code></pre>

+ python 코드 
<pre><code>
def publish(topic, message, wait_for_ack = False): // wait_for_ack : Broker로부터 ACK 수신 여부 
                                                   //                True로 설정시 모든 메시지 발행에
                                                   //                브로커로부터 ACK 수신이 필요함 
    Qos = 2 if wait_for_ack else 0 
    message_info = client.publish(topic, message, Qos)           // 메시지 발행 
    if wait_for_ack:
        print(' > awaiting ACK for {}'.format(message_info.mid)) 
        message_info.wait_for_publish()                          // ACK 수신 대기
        print(' < received ACK for {}'.format(message_info.mid))
</code></pre>

#### MQTT Subscriber (메시지 구독) 
+ python 코드 
<pre><code>
def on_message(client, userdata, message):
    payload = message.payload.decode("utf-8")
    print(' < received message : ' + payload)
</code></pre>

## 4. 실행 결과

#### Winform 초기 화면
![image](https://user-images.githubusercontent.com/77951828/126918302-a73089c6-a08b-45d8-b0aa-91975e6a4282.png)

## 5. 얻게 된 점 
