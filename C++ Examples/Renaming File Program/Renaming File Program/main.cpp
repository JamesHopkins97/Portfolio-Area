#include <iostream>
#include <string>
#include <fstream>
#include <cstdio>

using namespace std;

//Will rename a list of files needed to be renamed.

int main()
{
	
	//not needed to change, increments the counter as character variables.
	int digitOne = 48;
	int digitTwo = 49;
	char num = digitOne;
	char num2 = digitTwo;
	//Don't forget to change the amountOfFiles for the For loop.
	int amountOfFiles = 0;
	
	//for loop to loop the amount of files you are changing. The maximum number can be changed if needed.
	for (int i = 0; i < amountOfFiles; i++)
	{
		//The string address is where the file is located. Can copy in the address, just add an extra '\' where needed.
		string address = "";
		//Same as above, but change the file name to what you want.
		string newname = "";
		//The subscript of the string is the number along the path that you want to change.
		address[80] = num;
		address[81] = num2;

		newname[80] = num;
		newname[81] = num2;

		//renames the file with newname!
		rename(address.c_str(), newname.c_str());

		//displays address
		cout << address << "\n\n";

		//does the incrementing
		digitTwo++;
		if (digitTwo == 58)
		{
			digitTwo = 48;
			digitOne++;
		}
		num = digitOne;
		num2 = digitTwo;

	}
	cout << "\n";
	system("pause");
	return 0;
}