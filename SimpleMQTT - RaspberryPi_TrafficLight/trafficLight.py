import paho.mqtt.client as mqtt
import time 
import signal
import os
import RPi.GPIO as GPIO
import threading
import sys
import multiprocessing as mp 

'''
mqtt 받아서 신호등 켜기 
1. mqtt client connect
2. GPIO setup
'''

task_queue = mp.Queue()
red_pin = 18
yellow_pin = 23
green_pin = 24

event_signal = threading.Event()
event_signal.clear()

# sys.argv[1] : Broker IP Address
# sys.argv[2] : MQTT Connection Topic
if len(sys.argv) == 1:
    broker_Address = '210.119.12.96'
    topic = 'TRAFFICLIGHT/TEST/'
elif len(sys.argv) != 3:
    print('Usage : python {0} [Broker IP] [Topic]'.format(sys.argv[0]))
    sys.exit()
else:
    broker_Address = sys.argv[1]
    topic = sys.argv[2]

def init_signal():
    GPIO.output(red_pin, False)
    GPIO.output(yellow_pin, False)
    GPIO.output(green_pin, False)
    time.sleep(0.05)

def set_signal(signal):
    init_signal()
    GPIO.output(signal, True)
    time.sleep(0.1)

def red_signal():
    set_signal(red_pin)

def yellow_signal():
    set_signal(yellow_pin)

def green_signal():
    set_signal(green_pin)

def start_signal():
    while(1):
        init_signal()
        # loop escape flag check
        if event_signal.is_set():
            event_signal.clear()
            break
        set_signal(red_pin)
        time.sleep(5)
        set_signal(green_pin)
        time.sleep(5)
        set_signal(yellow_pin)
        time.sleep(1)

def on_message(client, userdata, message):
    payload = message.payload.decode("utf-8")
    print(' < received message : ' + payload)
    if payload == 'r':
        red_signal()
    elif payload == 'y':
        yellow_signal()
    elif payload == 'g':
        green_signal()
    elif payload == 's':
        start_signal_thread = threading.Thread(target=start_signal)
        start_signal_thread.daemon = True
        start_signal_thread.start()
    elif payload == 't':
        event_signal.set()

def send_message():
    print('sending message every 7 seconds!')
    publish(topic, "message from client every 7 seconds!")

def publish(topic, message, wait_for_ack = False):
    Qos = 2 if wait_for_ack else 0
    message_info = client.publish(topic, message, Qos)
    if wait_for_ack:
        print(' > awaiting ACK for {}'.format(message_info.mid))
        message_info.wait_for_publish()
        print(' < received ACK for {}'.format(message_info.mid))

def on_publish(client, userdata, mid):
    print(' > published message : {}'.format(mid))

def device_loop():
    while True:
        task_queue.put(send_message)
        time.sleep(7)


def GPIO_Setup():
    GPIO.setmode(GPIO.BCM)
    GPIO.setup(red_pin, GPIO.OUT)
    GPIO.setup(yellow_pin, GPIO.OUT)
    GPIO.setup(green_pin, GPIO.OUT)

client = mqtt.Client("Client1")
client.on_message = on_message
client.on_publish = on_publish

client.connect(broker_Address)
client.loop_start()
publish(topic, 'Python trafficLight device connection!', wait_for_ack = True)
print('Python trafficLight device connection!')

client.subscribe(topic)

device_loop_thread = threading.Thread(target=device_loop)
device_loop_thread.daemon = True
device_loop_thread.start()

try:
    GPIO_Setup()
    while True:
        task = task_queue.get()
        task()
except (KeyboardInterrupt, SystemExit):
    print('Received keyboard interrupt, quitting...')
    GPIO.cleanup()
    exit(0)

