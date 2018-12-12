using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1_Motif_Enumeration_Problem
{
    class Program
    {
        static List<string> GetAllWords(string alphabet, int length)
        {
            List<string> words = new List<string>((int)Math.Pow(4, length));
            GetAllWords(ref words,alphabet, length, "");
            return words;
        }
        static void GetAllWords(ref List<string> words, string alphabet, int length, string prefix)
        {
            if (length == 0)
            {
                words.Add(prefix);
            }
            else
                foreach (char c in alphabet)
                {
                    GetAllWords(ref words, alphabet, length - 1, prefix + c);
                }
        }
        static bool IsValidMismatches(string original, string replica, int validMismatches)
        {
            int length = original.Length;

            int mismatches = 0;
            for (int i = 0; i < length; i++)
            {
                if (original[i] != replica[i])
                {
                    mismatches++;
                }

                if (mismatches > validMismatches)
                {
                    return false;
                }
            }

            return true;
        }
        static List<string> GetAllKDMotifs(string kMer, int validMismatches)
        {
            string alphabet = "AGCT";
            List<string> patterns = new List<string>();

            foreach (var item in GetAllWords(alphabet, kMer.Length))
            {
                if (IsValidMismatches(item.ToString(), kMer, validMismatches))
                {
                    patterns.Add(item.ToString());
                }
            }

            return patterns;
        }

        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int k = int.Parse(tokens[0]);
            int q = int.Parse(tokens[1]);

            string buf = "";
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                    break;

                buf += s + ' ';
            }

            string[] dna = buf.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<string> patterns = new List<string>();

            foreach (string str in dna)
            {
                int length = str.Length;
                for (int i = 0; i < length - k + 1; i++)
                {
                    string kMer = str.Substring(i, k);

                    foreach (string pattern in GetAllKDMotifs(kMer, q))
                    {
                        int count = 0;
                        foreach (string substring in dna)
                        {
                            for (int j = 0; j < length - k + 1; j++)
                            {
                                if (IsValidMismatches(substring.Substring(j, k), pattern, q))
                                {
                                    count++;
                                    break;
                                }
                            }
                        }

                        if (count == dna.Length)
                        {
                            patterns.Add(pattern);
                        }
                    }
                }
            }

            patterns = patterns.Distinct().ToList();

            Console.WriteLine(string.Join(" ", patterns));
            Console.ReadKey();
        }
    }
}
