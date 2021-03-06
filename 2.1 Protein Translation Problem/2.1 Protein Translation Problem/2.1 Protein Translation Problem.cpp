// 2.1 Protein Translation Problem.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>
#include <map>	

using namespace std;

int main()
{
	string pattern;
	string peptide;

	map<string, char> RNACodonTable = {	{"AAA", 'K'},
										{"AAC", 'N'},
										{"AAG", 'K'},
										{"AAU", 'N'},
										{"ACA", 'T'},
										{"ACC", 'T'},
										{"ACG", 'T'},
										{"ACU", 'T'},
										{"AGA", 'R'},
										{"AGC", 'S'},
										{"AGG", 'R'},
										{"AGU", 'S'},
										{"AUA", 'I'},
										{"AUC", 'I'},
										{"AUG", 'M'},
										{"AUU", 'I'},
										{"CAA", 'Q'},
										{"CAC", 'H'},
										{"CAG", 'Q'},
										{"CAU", 'H'},
										{"CCA", 'P'},
										{"CCC", 'P'},
										{"CCG", 'P'},
										{"CCU", 'P'},
										{"CGA", 'R'},
										{"CGC", 'R'},
										{"CGG", 'R'},
										{"CGU", 'R'},
										{"CUA", 'L'},
										{"CUC", 'L'},
										{"CUG", 'L'},
										{"CUU", 'L'},
										{"GAA", 'E'},
										{"GAC", 'D'},
										{"GAG", 'E'},
										{"GAU", 'D'},
										{"GCA", 'A'},
										{"GCC", 'A'},
										{"GCG", 'A'},
										{"GCU", 'A'},
										{"GGA", 'G'},
										{"GGC", 'G'},
										{"GGG", 'G'},
										{"GGU", 'G'},
										{"GUA", 'V'},
										{"GUC", 'V'},
										{"GUG", 'V'},
										{"GUU", 'V'},
										{"UAA", ' '},
										{"UAC", 'Y'},
										{"UAG", ' '},
										{"UAU", 'Y'},
										{"UCA", 'S'},
										{"UCC", 'S'},
										{"UCG", 'S'},
										{"UCU", 'S'},
										{"UGA", ' '},
										{"UGC", 'C'},
										{"UGG", 'W'},
										{"UGU", 'C'},
										{"UUA", 'L'},
										{"UUC", 'F'},
										{"UUG", 'L'},
										{"UUU", 'F'}};

	cin >> pattern;

	for (int i = 0; i < pattern.length(); i += 3)
	{
		peptide += RNACodonTable.at(pattern.substr(i, 3));
	}

	cout << peptide << endl;
	return 0;
}