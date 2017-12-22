#!/usr/bin/python
import sys
import time
from twython import TwythonStreamer
import RPi.GPIO as GPIO

# Tell GPIO library to use GPIO references
GPIO.setmode(GPIO.BCM)

# List of LED GPIO numbers
TERM = ['Star Wars','China','Korea','UK','Paris','NATO']
LedSeq = [4,17,22,10,9,11]
# Set up GPIOs (4,17,22,10,9,11) as outputs
GPIO.setup(4, GPIO.OUT)
GPIO.setup(17, GPIO.OUT)
GPIO.setup(22, GPIO.OUT)
GPIO.setup(10, GPIO.OUT)
GPIO.setup(9, GPIO.OUT)
GPIO.setup(11, GPIO.OUT)

app_key = "QH1CZDChcuIQA1nWNzJCO2AZ5"
app_secret = "shwmjxooHqeQhfLW0ZMrUMNG5RFT8eEEuJGPzU0fXgLF8ZF8EH"
oauth_token = "4432182135-WI9m14FJXQLejBVi9dL44MovkWEsKGSxUoZmgBU"
oauth_token_secret = "5CPnkLz6BJMhoa3neOPaaf6f21lRo72A79hFBPvbfpKrc"

#setup callbacks
class BlinkyStreamer(TwythonStreamer):
    def on_success(self,data):
        if 'text' in data:
            tweet_stream = data['text'].encode('utf-8')
            if TERM[0] in tweet_stream:
                print ("TERM found " + TERM[0])
                GPIO.output(4,GPIO.HIGH)
                print(tweet_stream)
                print ("\n")
                time.sleep(3)
                GPIO.output(4,GPIO.LOW)
            elif TERM[1] in tweet_stream:
                print ("TERM found " + TERM[1])
                GPIO.output(17,GPIO.HIGH)
                print(tweet_stream)
                print ("\n")
                time.sleep(3)
                GPIO.output(17,GPIO.LOW)                
            elif TERM[2] in tweet_stream:
                print ("TERM found " + TERM[2])
                GPIO.output(22,GPIO.HIGH)
                print(tweet_stream)
                print ("\n")
                time.sleep(3)
                GPIO.output(22,GPIO.LOW)
            elif TERM[3] in tweet_stream:
                print ("TERM found " + TERM[3])
                GPIO.output(10,GPIO.HIGH)
                print(tweet_stream)
                print ("\n")
                time.sleep(3)
                GPIO.output(10,GPIO.LOW)
            elif TERM[4] in tweet_stream:
                print ("TERM found " + TERM[4])
                GPIO.output(9,GPIO.HIGH)
                print(tweet_stream)
                print ("\n")
                time.sleep(3)
                GPIO.output(9,GPIO.LOW)
            elif TERM[5] in tweet_stream:
                print ("TERM found " + TERM[5])
                GPIO.output(11,GPIO.HIGH)
                print(tweet_stream)
                print ("\n")
                time.sleep(3)
                GPIO.output(11,GPIO.LOW)

# Create Streamer
try:
    stream = BlinkyStreamer(app_key, app_secret, oauth_token, oauth_token_secret)
    stream.statuses.filter(track=TERM)
except KeyboardInterrupt:
    GPIO.cleanup()
