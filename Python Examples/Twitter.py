#!/usr/bin/python
import sys
import time
from twython import Twython

app_key = "QH1CZDChcuIQA1nWNzJCO2AZ5"
app_secret = "shwmjxooHqeQhfLW0ZMrUMNG5RFT8eEEuJGPzU0fXgLF8ZF8EH"
oauth_token = "4432182135-WI9m14FJXQLejBVi9dL44MovkWEsKGSxUoZmgBU"
oauth_token_secret = "5CPnkLz6BJMhoa3neOPaaf6f21lRo72A79hFBPvbfpKrc"

api= Twython(app_key, app_secret, oauth_token, oauth_token_secret)

tweets = api.get_home_timeline(screen_name='@JamesUSW15')
while True:
    for tweet in tweets:
        print(tweet['text'])
        time.sleep(5)
        print ('\n')