// 2.3 Subpeptides Count Problem.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

using namespace std;

int main()
{
	long int length;
	cin >> length;

	cout << length * (length - 1);

	return 0;
}