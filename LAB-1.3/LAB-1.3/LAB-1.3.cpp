// LAB-1.3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	string directPattern, reservePattern;
	cin >> directPattern;

	int length = directPattern.length();
	reservePattern.resize(length);
	for (int i = 0; i < length; i++)
	{
		switch (directPattern[i])
		{
		case 'A':
			reservePattern[length - i - 1] = 'T';
			break;
		case 'C':
			reservePattern[length - i - 1] = 'G';
			break;
		case 'G':
			reservePattern[length - i - 1] = 'C';
			break;
		case 'T':
			reservePattern[length - i - 1] = 'A';
			break;
		}
	}

	cout << reservePattern << endl;

	return 0;
}