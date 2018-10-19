// 1.1 Pattern Count Problem.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	string pattern;
	string genome;
	int count = 0;

	cin >> pattern;
	cin >> genome;

	for (int i = 0; i < genome.length() - pattern.length() + 1; i++)
	{
		if (genome.substr(i, pattern.length()) == pattern)
		{
			count++;
		}
	}

	cout << count;

	return 0;
}
