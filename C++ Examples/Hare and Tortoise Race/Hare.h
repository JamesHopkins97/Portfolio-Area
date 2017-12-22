#ifndef HARE
#define HARE
#include <iostream>
#include <fstream>
#include <string>
#include <ctime>
#include <cstdlib>

using namespace std;

class Hare
{
private:
	int hareYPosition;
	int hareXPosition;
	string nextHareMove;
	string hareMoveName[10];
	int nextHareNumber;
	int hareMoveNumber[10];
	int subscriptNum;
	int a = 0;
public:
	void file()
	{
		ifstream hareText("HareMoves.txt");
		while (!hareText.eof())
		{
			hareText >> hareMoveName[a] >> hareMoveNumber[a];
			a++;
		}

	}
	int setHareRandomNumber()
	{
		randomNumberGenerator();
		subscriptNum = randomNumberGenerator();
		return subscriptNum;
	}
	string getHareMoveName()
	{
		int subscriptNum = setHareRandomNumber();
		nextHareMove = hareMoveName[subscriptNum];
		return nextHareMove;
	}
	int getHareMoveNumber()
	{
		int nextMove = setHareRandomNumber();
		nextHareNumber = hareMoveNumber[nextMove];
		return nextHareNumber;
	}
	void setXpos(int defaultXpos = 5)
	{
		hareXPosition = defaultXpos;
	}
	int getXpos()
	{
		return hareXPosition;
	}
	void setYpos(int defaultYpos = 5)
	{
		hareYPosition = defaultYpos;
	}
	int getYpos()
	{
		return hareYPosition;
	}
	int randomNumberGenerator()
	{
		srand(static_cast<int>(time(NULL)));
		rand();
		int num;
		num = rand() % 10;
		return num;
	}
	Hare();
	~Hare();
};

#endif