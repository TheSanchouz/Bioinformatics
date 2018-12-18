using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2_Median_String_Problem
{
    class Program
    {
        static List<string> GetAllWords(string alphabet, int length)
        {
            List<string> words = new List<string>((int)Math.Pow(4, length));
            GetAllWords(ref words, alphabet, length, "");
            return words;
        }
        static void GetAllWords(ref List<string> words, string alphabet, int length, string prefix)
        {
            if (length == 0)
            {
                words.Add(prefix);
            }
            else
            {
                foreach (char c in alphabet)
                {
                    GetAllWords(ref words, alphabet, length - 1, prefix + c);
                }
            }
        }
        static int Hamming(string a, string b)
        {
            int count = 0;
            int length = a.Length;

            for (int i = 0; i < length; i++)
            {
                if (a[i] != b[i])
                {
                    count++;
                }
            }

            return count;
        }
        static int D(string pattern, string text)
        {
            int length = text.Length;
            int k = pattern.Length;

            List<int> dist = new List<int>();

            for (int i = 0; i < length - k + 1; i++)
            {
                dist.Add(Hamming(pattern, text.Substring(i, k)));
            }

            return dist.Min();
        }
        static int DDNA(string pattern, string[] dna)
        {
            int sum = 0;

            foreach (string dnai in dna)
            {
                sum += D(pattern, dnai);
            }

            return sum;
        }
        static string MedianString(string[] dna, int k)
        {
            int distance = int.MaxValue;
            string median = "";
            List<string> allKmers = GetAllWords("AGCT", k);

            foreach (string kmer in allKmers)
            {
                if (distance > DDNA(kmer, dna))
                {
                    distance = DDNA(kmer, dna);
                    median = kmer;
                }
            }

            return median;
        }
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());

            string buf = "";
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                    break;

                buf += s + ' ';
            }

            string[] dna = buf.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //string[] dna =
            //{
            //    "GAAACTACGCACGTAGTGTTTTGCTACGGTTCTCA",
            //    "TATATCCACATGACCTCGACAACGCACGGTCGAAT",
            //    "TAGCGGGACAATCAGGTCTGAGTCGACTGTTGTGC",
            //    "TCCTGCCGGTTGCTAACTGTAGACGTTTACCCCTT",
            //    "TCCCTCCCTAACTCTAGGCTACTGTCGTCCGCAGT",
            //    "AGGCAGAAAGACAACGGTAGTAATCTAGAGACCGT",
            //    "CGCTCCACGCAGCTCATAGAACCGTGTTGTTCAAC",
            //    "ACTGTCTCCCGGAAACCATAAACTACTTGGTTTGT",
            //    "GGTTTTCTTGACTGTAATTACAATCCAGGAGACCA",
            //    "ATGTCGCTCTACAGTGAACACGTAACTGTCTTCGG"
            //};

            Console.WriteLine(MedianString(dna, k));
            Console.ReadKey();
        }
    }
}
