#ifndef TORTOISE
#define TORTOISE
#include <iostream>
#include <fstream>
#include <string>
#include <ctime>
#include <cstdlib>

using namespace std;

class Tortoise
{
private:
	int tortoiseYPosition;
	int tortoiseXPosition;
	string nextTortoiseMove;
	string tortoiseMoveName[10];
	int nextTortoiseNumber;
	int moveNumber[10];
	int subscriptNum;
	int a = 0;
public:
	void file()
	{
		ifstream tortoiseText("TortoiseMoves.txt");
		while (!tortoiseText.eof())
		{
			tortoiseText >> tortoiseMoveName[a] >> moveNumber[a];
			a++;
		}
	}
	int setRandomNumber()
	{
		randomNumberGenerator();
		subscriptNum = randomNumberGenerator();
		return subscriptNum;
	}
	string getName()
	{
		int subscriptNum = setRandomNumber();
		nextTortoiseMove = tortoiseMoveName[subscriptNum];
		return nextTortoiseMove;
	}
	int getNumber()
	{
		int subscriptNum = setRandomNumber();
		nextTortoiseNumber = moveNumber[subscriptNum];
		return nextTortoiseNumber;
	}
	void setXpos(int defaultXpos = 5)
	{
		tortoiseXPosition = defaultXpos;
	}
	int getXpos()
	{
		return tortoiseXPosition;
	}
	void setYpos(int defaultYpos = 5)
	{
		tortoiseYPosition = defaultYpos;
	}
	int getYpos()
	{
		return tortoiseYPosition;
	}
	int randomNumberGenerator()
	{
		srand(static_cast<int>(time(NULL)));
		rand();
		int num;
		num = rand() % 10;
		return num;
	}
	Tortoise();
	~Tortoise();
};

#endif