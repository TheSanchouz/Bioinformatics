// 2.1 Protein Translation Problem.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	string pattern;
	string peptide;

	cin >> pattern;

	for (int i = 0; i < pattern.length(); i += 3)
	{
		switch (pattern.substr(i, 3))
		{
		case "AAA":
		default:
			break;
		}
		
	}

	return 0;
}