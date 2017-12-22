#include <iostream>
#include <fstream>
#include <algorithm>
#include <ctime>
#include <cstdlib>
#include <string>
#include <iomanip>
#include "console.h"
#include "Intro.h"
#include "Hare.h"
#include "Tortoise.h"

using namespace std;

void drawUpperLine(); 

int main()
{
	Hare h;
	Tortoise t;

	string readLine;
	string winner = "NA";
	int winningMoves = 0;
	t.setRandomNumber();
	t.file();
	t.setXpos();
	t.setYpos();
	h.setXpos();
	h.setYpos();
	h.setHareRandomNumber();
	h.file();
	int hareXposition = h.getXpos();
	int hareYposition = h.getYpos();
	int tortoiseXposition = t.getXpos();
	int tortoiseYposition = t.getYpos();
	string hareNextPosName = "";
	int hareNextPosMoves = 0;
	string tortoiseNextPosName = "";
	int tortoiseNextPosMoves = 0;
	int totalMoves = 0;

	srand(static_cast<int>(time(NULL)));
	rand();
	drawUpperLine();
	cout << tortoiseNextPosName << endl;
	cout << tortoiseNextPosMoves << endl;
	cout << hareNextPosName << endl;
	cout << hareNextPosMoves << endl;
	int max = 54;
	//DO THE CODEEEE
	while (tortoiseXposition < max && hareXposition < max)
	{
		t.setRandomNumber();
		h.setHareRandomNumber();
		
		hareNextPosName = h.getHareMoveName();
		hareNextPosMoves = h.getHareMoveNumber();
		
		hareXposition += hareNextPosMoves;
		if (hareXposition < 5)
			hareXposition = 5;
		
		tortoiseNextPosName = t.getName();
		tortoiseNextPosMoves = t.getNumber();

		tortoiseXposition += tortoiseNextPosMoves;
		if (tortoiseXposition < 5)
			tortoiseXposition = 5;

		totalMoves++;
		Console::clear();
		Intro i;
		drawUpperLine();
		
		cout << endl;
		cout << "The hare's move " << setw(16) << hareNextPosName << endl;
		cout << "The number of spaces" << setw(8) << hareNextPosMoves << endl;
		cout << endl;
		cout << "The tortoise's move " << setw(16) << tortoiseNextPosName << endl;
		cout << "The number of spaces" << setw(8) << tortoiseNextPosMoves << endl;
		cout << endl;

		if (hareXposition == tortoiseXposition)
		{
			Console::setCursorPosition(hareYposition, hareXposition);
			cout << "X";
		}
		else
		{
			Console::setCursorPosition(hareYposition, hareXposition);
			cout << "H";
			Console::setCursorPosition(tortoiseYposition, tortoiseXposition);
			cout << "T";
		}
		
		if (tortoiseXposition >= max)
		{
			ofstream winner("WinningPlayer.txt");
			winner << "\nThe winner of this race is the tortoise with " << totalMoves << " moves!" << endl;
			Console::setCursorPosition(12, 0);
			cout << "\nThe winner of this race is the tortoise with " << totalMoves << " moves!" << endl;
		}

		else if (hareXposition >= max)
		{
			ofstream winner("WinningPlayer.txt");
			winner << "The winner of this race is the hare with " << totalMoves << " moves!" << endl;
			Console::setCursorPosition(12, 0);
			cout << "The winner of this race is the hare with " << totalMoves << " moves!" << endl;
		}
		Sleep(500);
	}
	if (hareXposition == tortoiseXposition)
	{
		Console::setCursorPosition(hareYposition, hareXposition);
		cout << "X";
	}
	else
	{
		Console::setCursorPosition(hareYposition, hareXposition);
		cout << "H";
		Console::setCursorPosition(tortoiseYposition, tortoiseXposition);
		cout << "T";
	}

	Console::setCursorPosition(15, 0);
	Console::pause("Press any key to end.");
	return 0;
}

void drawUpperLine()
{
	Console::setCursorPosition(5, 5);
	for (int i = 0; i < 50; i++)
		cout << "_";
	cout << endl;
}