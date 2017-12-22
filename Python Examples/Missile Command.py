import pygame, sys, time, random, bres
from pygame.locals import *

#sramp_one, ramp_two, ramp_three = None, None, None

#Setting colours to use in the game
wood_light = (166, 124, 54)
wood_dark = (76, 47, 0)
blue = (0, 100, 255)
dark_red = (166, 25, 50)
dark_green = (25, 100, 50)
dark_blue = (25, 50, 150)
black = (0, 0, 0)
white = (255, 255, 255)
yellow = (240, 230, 140)
grey = (153, 153, 153)
green = (0, 255, 0)
width, height = 1280, 720
screen = None

# Sets the radius to 60
maxRadius = 60
#Creates a global list object for all objects
allObjects = []
delay = 15   # number of milliseconds delay before generating a USEREVENT
missileSize = 3

#Sets the ammo count for each city gun silo
ammo_per_silo = 20
#Sets gun height and width
gun_length = width/20
gun_height = height/20

#Creates global lists for guns and cities
gun_list = []
city_list = []

#Sets gun height and width
city_length =  width/20
city_height =  height/20

#Sets the amount of enemy missiles
attack_number = 5
#Sets how long it takes or the missiles
rate_of_attack = 4

#set gun positions
silos = [[80, height-150], [500, height-150], [1000, height-150]]

#returns the value of x squared
def sqr (x):
	return x*x

#A class for the explosions
class explosion:
	def __init__ (self, pos, colour):	
		self._radius = 1 # sets default radius to 1
		self._maxRadius = maxRadius #sets maxRadius to maxRadius
		self._increasing = True #sets the bool to true
		self._pos = pos #Sets pos to mouse position
		self._colour = colour # Sets colour to explosion colour
	def update (self):
		if self._increasing: #If increasing = true
			pygame.draw.circle (screen, self._colour, self._pos, self._radius, 0) #Draws the explosion circle 
			self._radius += 1 # increments explosion by 1
			if self._radius == self._maxRadius: #if the radius is at the same value of maxRadius, turn increasing to false
				self._increasing = False
		else:
			pygame.draw.circle (screen, black, self._pos, self._radius, 0) # When the explosion is done, leave a black circle behind
			self._radius -= 1 #Decrement the radius by 1
			if self._radius > 0: #If radius is more than 0, keep drawing black circles
				pygame.draw.circle (screen, self._colour, self._pos, self._radius, 0)
			else:
				globalRemove (self)# else, remove the explosion
	def erase (self):
		pygame.draw.circle (screen, black, self._pos, self._radius, 0) # erase explosion and leave a black circle
	def ignite (self, p):
		return sqr (self._pos[0]-p[0]) + sqr (self._pos[1]-p[1]) < sqr (self._radius) # ignite the explosion

class missile:
	def __init__ (self, start_pos, end_pos):
		self.route = bres.bres (start_pos, end_pos) # draws the path for the missile
		self.erase_route = bres.bres (start_pos, end_pos) # erases the missile
	def update (self):
		if self.route.finished (): #If the missile is at the end of the path
			globalRemove (self) # Remove the missile object 
			createExplosion (self.route.get_current_pos (), white) #create a white explosion
		elif ignites (self.route.get_current_pos ()): # Else ifthe missile ignites at an interrupted route			
			globalRemove(self) # remove the missile
			createExplosion (self.route.get_current_pos (), grey) # explosion colour is grey
		drawTrail (self.route.get_current_pos ()) # Draw missile trail
		drawMissile (self.route.get_next ()) # draws the missile at the route 
	def erase (self):
		while not self.erase_route.finished (): # erase the route ifits finished
			eraseBlock (self.erase_route.get_next ())
	def ignite (self, p): # return false on ignite
		return False

class city: # Class for the city
	def __init__ (self, pos):
		self._pos = pos # 
		self._epicenter = [pos[0] + city_length/2, pos[1]-city_height]# sets epicenter to the middle of the city 
		self._exploding = False # sets explosion to false
		self._explosion = None # sets exploding to null
		self.draw_city () # draws the city

	def draw_city (self):
		pygame.draw.rect (screen, green, (self._pos[0], self._pos[1], city_length, city_height), 0) # draws the city
	def update (self): 
		pass
	def ignite (self, p):
		return self._exploding # returns bool
	def erase (self):
		pygame.draw.rect (screen, black, (self._pos[0], self._pos[1], city_length, city_height), 0) # draws rectangle

	def check (self, p, radius): # checks if not exploding and missile is at city epicenter
		if (not self._exploding) and sqr (radius) > sqr (p[0]- self._epicenter[0]) + sqr (p[1]- self._epicenter[1]):
			self._exploding = True # explodes
			createExplosion (p, grey) #creates explosion in grey
			createExplosion (self._epicenter, light_grey) #creates explosion in grey
			globalRemove (self) #removes city epicenter

class gun: #class for guns
	def __init__ (self, pos):
		global screen
		self._ammo = ammo_per_silo
		self._pos = pos
		self._epicenter = [pos[0] + gun_length/2, pos[1]-gun_height]
		self._exploding = False
		self._explosion = None
		self.draw_gun ()
	#Draws the guns. Sets them as blue.
	def draw_gun (self):
		global screen
		print "rect", self._pos, gun_length, gun_height
		pygame.draw.rect (screen, dark_blue, (self._pos[0], self._pos[1], gun_length, gun_height), 0)
	#if ammo is more than 0 and is not exploding, fire a missile
	def fire (self):
		if self._ammo > 0 and (not self._exploding):
			self._ammo -= 1
			createMissile (self._epicenter, pygame.mouse.get_pos ())

	def update (self):
		pass
	#If it has been hit, return exploding
	def ignite (self, p):
		return self._exploding
	def erase (self): # draw black rectangle in place of guns
		pygame.draw.rect (screen, black, (self._pos[0], self._pos[1], gun_length, gun_height), 0)
	def check (self, p, radius): # checks if exploding, and if not, explode
		if (not self._exploding) and sqr (radius) > sqr (p[0]- self._epicenter[0]) + sqr (p[1]- self._epicenter[1]):
			self._exploding = True
			createExplosion (p, grey)#Create an explosion in Grey
			createExplosion (self._epicenter, light_grey)
			globalRemove (self)

def drawTrail (p): #draws the missile trail
	pygame.draw.rect (screen, white, (p[0], p[1], missileSize, missileSize), 0)

def drawMissile (p): #draws the missile
	pygame.draw.rect (screen, yellow, (p[0], p[1], missileSize, missileSize), 0)

def eraseBlock (p): #erases the missile
	pygame.draw.rect (screen, black, (p[0], p[1], missileSize, missileSize), 0)

def ignites (p): # ignites the missile
	for o in allObjects:
		if o.ignite (p):
			return True
	return False

# creates missile on the screen
def createMissile (start_pos, end_pos):
	global allObjects
	allObjects += [missile (start_pos, end_pos)]
	pygame.time.set_timer (USEREVENT+1, delay)

# creates explosion on the screen
def createExplosion (pos, colour):
	global allObjects
	allObjects += [explosion (pos, colour)]
	pygame.time.set_timer (USEREVENT+1, delay)

#remove all objects on the screen
def globalRemove (e):
	global allObjects
	e.erase ()
	allObjects.remove (e)
	pygame.display.flip ()

#update the objects
def updateAll ():
	if allObjects != []:
		for e in allObjects:
			e.update ()
	if allObjects != []:
		pygame.display.flip ()
		pygame.time.set_timer (USEREVENT+1, delay)


#fills city_list
def make_cities ():
	global city_list


	for p in [[((width/133)+200), height-city_height], [((width/133)+300), height-city_height], [((width/133)+400), height-city_height],
			  [((width/133)+700), height-city_height], [((width/133)+800), height-city_height], [((width/133)+900), height-city_height]]:
		c = city (p)
		city_list += [c]

# spawns enemy missiles
def spawn_attack ():
	global attack_number
	if attack_number > 0:
		if random.randint (1, rate_of_attack) == 1:
			attack_number -= 1
			c = city_list [random.randint (0, 5)]
			createMissile ([random.randint (1, 1000), 0],
						   c._epicenter)
# tracks the number of cities
def no_of_cities ():
	n = 0
	for c in city_list:
		if not c._exploding:
			n += 1
	return n

#checks end game conditions
def check_finished ():
	if attack_number == 0 and len (allObjects) == 0:
		n = no_of_cities ()
		if n == 0:
			print "you lost!"
		elif n == 1:
			print "you survived with 1 city left"
		else:
			print "you survived with", n, "cities left"
		sys.exit (0)

#checks the city list and gun list
def check_cities_guns (pos, radius):
	for c in city_list:
		c.check (pos, radius)
	for g in gun_list:
		g.check (pos, radius)

#spawns attack
def spawn_attack ():
	global attack_number
	if attack_number > 0:
		if random.randint (1, rate_of_attack) == 1:
			attack_number -= 1
			c = city_list [random.randint (0, 5)]
			createMissile ([random.randint (1, 1000), 0],
						   c._epicenter)

		if random.randint (1, rate_of_attack) == 1:
		        attack_number -= 1
			g = gun_list [random.randint (0, 2)]
			createMissile ([random.randint (1, 1000), 0], g._epicenter)

#make gun list
def make_guns ():
	global gun_list
	for p in silos:
		g = gun (p)
		gun_list += [g]

# waits for player interaction before starting
def wait_for_event ():
	global screen
	while True:
		event = pygame.event.wait ()
		if event.type == pygame.QUIT:
			sys.exit(0)
		if event.type == KEYDOWN and event.key == K_ESCAPE:
			sys.exit (0)
		if event.type == pygame.MOUSEBUTTONDOWN:
			if event.button >= 1 and event.button <= 3:
				createMissile (silos[event.button-1], pygame.mouse.get_pos ())
			print pygame.mouse.get_pos()
                spawn_attack ()
		if event.type == USEREVENT+1:
			updateAll ()
                check_finished ()

#main function
def main ():
	global screen
	pygame.init ()
	screen = pygame.display.set_mode ([width, height])
	make_cities ()
	make_guns ()
	wait_for_event ()

main () # calls main
