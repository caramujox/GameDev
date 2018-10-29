#include <iostream>
#include <string>

using namespace std;


int main()
{
	constexpr int WORD_LENGTH = 5;
	cout  << "Bulls And Cows" << endl << "Guess the magical number " << WORD_LENGTH;
	cout << endl;
	cout << "Your Guess: ";

	string Guess = "";
	
	getline(cin, Guess);
	cout << "U guessed: " << Guess;


	cout << endl;
	return 0;
}