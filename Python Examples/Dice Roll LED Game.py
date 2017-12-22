#!/usr/bin/python
# Import required libraries
import RPi.GPIO as GPIO
import random
import time

# Tell GPIO library to use GPIO references
GPIO.setmode(GPIO.BCM)

# List of LED GPIO numbers
LedSeq = [4,17,22,10,9,11]

# Set up GPIOs (4,17,22,10,9,11) as outputs
GPIO.setup(4, GPIO.OUT)
GPIO.setup(17, GPIO.OUT)
GPIO.setup(22, GPIO.OUT)
GPIO.setup(10, GPIO.OUT)
GPIO.setup(9, GPIO.OUT)
GPIO.setup(11, GPIO.OUT)

# Setup GPIO 7 as an input
GPIO.setup(7, GPIO.IN)

# Generate a random seed
intMinNumber=1
intMaxNumber=6

# If the button is pressed (polling the switch), hint: simple switch debounce
# Turn off all 6 LEDs

try:
  while True:
    if GPIO.input(7)==1: 
      intRollResult = random.randint(intMinNumber, intMaxNumber)
      intRollResult2 = random.randint(intMinNumber, intMaxNumber)
      # Print message to 'throw dice or CTRL-C to quit
      print 'Dice 1 threw a' , intRollResult
      print 'Dice 2 threw a' , intRollResult2
      for count in range (intRollResult):
        GPIO.setup(LedSeq[count], GPIO.OUT)
        GPIO.output(LedSeq[count],GPIO.HIGH)
        time.sleep(1)
        GPIO.output(LedSeq[count],GPIO.LOW)
    
      for count in range (intRollResult2):
        GPIO.output(LedSeq[count],GPIO.HIGH)
        time.sleep(1)
        GPIO.output(LedSeq[count],GPIO.LOW)

      if intRollResult == intRollResult2:
        print 'You got doubles with' , (intRollResult + intRollResult2)
      elif ((intRollResult + intRollResult2) == 7):
        print 'You got a' , (intRollResult + intRollResult2)
      elif (intRollResult + intRollResult2 == 11):
        print 'You got an' , (intRollResult + intRollResult2)
      else:
        print 'This equals to' , (intRollResult + intRollResult2)
 
      print("Throw Dice or CTRL-C to Quit")

      

except KeyboardInterrupt:
  print "\n\nUser Exit"
  GPIO.output(LedSeq[count],GPIO.LOW)
  GPIO.output(4, GPIO.LOW)
  GPIO.output(17, GPIO.LOW)
  GPIO.output(22, GPIO.LOW)
  GPIO.output(10, GPIO.LOW)
  GPIO.output(9, GPIO.LOW)
  GPIO.output(11, GPIO.LOW)
  # Reset GPIO settings
GPIO.cleanup()
