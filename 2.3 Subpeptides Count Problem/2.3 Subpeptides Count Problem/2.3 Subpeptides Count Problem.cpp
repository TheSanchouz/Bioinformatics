// 2.3 Subpeptides Count Problem.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

using namespace std;

int main()
{
	double length;
	cin >> length;

	cout.precision(0);
	cout.setf(ios::fixed);
	cout << length * (length - 1);

	return 0;
}