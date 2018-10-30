// 2.5 Counting Peptides with Given Mass Problem.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>
#include <unordered_map>

using namespace std;

int aminoacidMasses[18] = { 57, 71, 87, 97, 99, 101, 103, 113, 114, 115, 128, 129, 131, 137, 147, 156, 163, 186 };

int main()
{
	int mass;
	cin >> mass;
	
	unordered_map<int, uint64_t> count = { {0, 1} };

	for (int i = 57; i <= mass; i++)
	{
		count[i] = 0;

		for (int j = 0; j < 18; j++)
		{
			if (count.find(i - aminoacidMasses[j]) != count.end())
			{
				count[i] = count[i - aminoacidMasses[j]] + count[i];
			}
		}
	}

	cout << count[mass];
	return 0;
}
