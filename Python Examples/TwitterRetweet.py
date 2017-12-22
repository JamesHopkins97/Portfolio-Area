#!/usr/bin/python
import sys
import time
from twython import Twython, TwythonError

app_key = "QH1CZDChcuIQA1nWNzJCO2AZ5"
app_secret = "shwmjxooHqeQhfLW0ZMrUMNG5RFT8eEEuJGPzU0fXgLF8ZF8EH"
oauth_token = "4432182135-WI9m14FJXQLejBVi9dL44MovkWEsKGSxUoZmgBU"
oauth_token_secret = "5CPnkLz6BJMhoa3neOPaaf6f21lRo72A79hFBPvbfpKrc"

api= Twython(app_key, app_secret, oauth_token, oauth_token_secret)

search_results = api.search(q="Raspberry PI", count=10)
try:
    for tweet in search_results["statuses"]:
        api.retweet(id = tweet["id_str"])

except TwythonError as e:
    print e
