using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3_Leaderboard_Cyclopeptide_Sequencing_Problem
{
    class Program
    {
        static Dictionary<char, int> aminoacidMassTable = new Dictionary<char, int>()
        {
                {'G', 57},  {'A', 71},  {'S', 87},  {'P', 97},  {'V', 99},
                {'T', 101}, {'C', 103}, {'I', 113}, {'L', 113}, {'N', 114},
                {'D', 115}, {'K', 128}, {'Q', 128}, {'E', 129}, {'M', 131},
                {'H', 137}, {'F', 147}, {'R', 156}, {'Y', 163}, {'W', 186}
        };
        static int Mass(string peptide)
        {
            int mass = 0;
            foreach (var s in peptide)
            {
                mass += aminoacidMassTable[s];
            }
           
            return mass;
        }
        static List<string> Expand(List<string> peptides)
        {
            List<string> newPeptides = new List<string>();

            foreach (var peptide in peptides)
            {
                foreach (var p in aminoacidMassTable.Keys)
                {
                    newPeptides.Add(peptide + p);
                }
            }
            return newPeptides;
        }
        static string LinearSpectrum(string peptide)
        {
            if (peptide.Length == 1) return aminoacidMassTable[peptide[0]].ToString();

            List<int> outMasses = new List<int>() { 0 };
            int m = 0;

            foreach (var s in peptide)
            {
                outMasses.Add(aminoacidMassTable[s]);
                m += aminoacidMassTable[s];
            }
            outMasses.Add(m);

            string cyclePeptide = peptide + peptide;

            for (int i = 2; i < peptide.Length; i++)
            {
                for (int j = 0; j < peptide.Length - i; j++)
                {
                    string subpeptide = cyclePeptide.Substring(j, i);
                    int curMass = 0;

                    foreach (var s in subpeptide)
                    {
                        curMass += aminoacidMassTable[s];
                    }
                    outMasses.Add(curMass);
                }
            }

            outMasses.Sort();

            return string.Join(" ", outMasses);
        }
        static int Score(string peptide, string spectrum)
        {
            List<string> peptideMasses = LinearSpectrum(peptide).Split(' ').ToList();
            List<string> spectrumMasses = spectrum.Split(' ').ToList();

            int score = 0;
            foreach (var mass in peptideMasses)
            {
                if (spectrumMasses.Contains(mass))
                {
                    spectrumMasses.Remove(mass);
                    score++;
                }
            }

            return score;
        }
        static List<string> Trim(List<string> leaderboard, string spectrum, int n)
        {
            leaderboard.Sort((a, b) => Score(b, spectrum).CompareTo(Score(a, spectrum)));
            if (leaderboard.Count > n)
            {
                int last = n;
                for (int i = n; i < leaderboard.Count; i++)
                {
                    if (Score(leaderboard[n - 1], spectrum) == Score(leaderboard[i], spectrum))
                    {
                        last = i;
                    }
                    else break;
                }

                leaderboard = leaderboard.Take(last + 1).ToList();
            }

            return leaderboard;
        }

        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(),
                               Console.InputEncoding,
                               false,
                               bufferSize: 1024));

            int n = int.Parse(Console.ReadLine());
            string spectrum = Console.ReadLine();
            int parentMass = int.Parse(spectrum.Split(' ').Last());

            List<string> leaderboard = new List<string>() { "" };
            string leaderPeptide = "";

            while (leaderboard.Count() > 0)
            {
                leaderboard = Expand(leaderboard);  
                List<string> immutablePeptides = new List<string>(leaderboard);
                foreach (var peptide in immutablePeptides)
                {
                    if (Mass(peptide) == parentMass)
                    {
                        if (Score(peptide, spectrum) > Score(leaderPeptide, spectrum))
                        {
                            leaderPeptide = peptide;
                        }
                    }
                    else if (Mass(peptide) > parentMass)
                    {
                        leaderboard.Remove(peptide);
                    }
                }

                leaderboard = Trim(leaderboard, spectrum, n);
            }

            List<string> outputMasses = new List<string>();
            foreach (var s in leaderPeptide)
            {
                outputMasses.Add(aminoacidMassTable[s].ToString());
            }

            Console.WriteLine(string.Join("-", outputMasses));
            Console.ReadKey();
        }
    }
}
