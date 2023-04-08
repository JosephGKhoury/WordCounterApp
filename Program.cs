using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace P1CountWordsJoe1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Skriv en text: ");
            var input = File.ReadAllText("../../Karin-Boye-Kallocain.txt");
            var words = Regex.Split(input, @"\W+");
            int number = 2;

            Console.WriteLine("Skriv ett ord: ");
            string word = Console.ReadLine();
            int n = Occurrences(words, word);
            Console.WriteLine("I boken finns ordet " + word + " med " + n + " gånger");


            int c = LongestWord(words);
            int m = ShortestLength(words);
            int p = WordsOfLength(words, number);
            words = RemoveEmptyWords(words);

            Console.WriteLine("Det längsta ordert har: " + c + " bokstäver ");
            Console.WriteLine("Det kortaste ordert har: " + m + " bokstäver ");
            Console.WriteLine("Antal ord som har " + number + " bokstäver är: " + p);
            WriteLengths(words);
        }

        private static int Occurrences(string[] words, string word)
        {
            int count = 0;
            foreach (string j in words)
            {
                if (j == word)
                {
                    count++;
                }
            }
            return count;

        }

        private static string[] RemoveEmptyWords(string[] words)
        {
            int empties = WordsOfLength(words, 0);
            string[] result = new string[words.Length-empties];
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")
                {
                    result[count++] = words[i];
                }
            }
            return result;
        }


        private static void WriteLengths(string[] words)
        {
            for (int i = ShortestLength(words); i <= LongestWord(words); i++)
            {
                if (WordsOfLength(words, i) != 0 & i != 0)
                {
                    Console.WriteLine("Antal ord med " + i + " bokstäver: " + WordsOfLength(words, i));
                }
            }
        }

        private static int WordsOfLength(string[] words, int n)
        {
            int j = 0;
            foreach (var word in words)
            {
                if (word.Length == n)
                {
                    j++;
                }
            }
            return j;
        }

        private static int ShortestLength(string[] words)
        {
            int n = int.MaxValue;
            foreach (var word in words)

                if (word.Length < n)
                {
                    n = word.Length;
                }
            return n;
        }

        private static int LongestWord(string[] words)
        {
            int n = 0;
            foreach (var word in words)

                if (word.Length > n)
                {
                    n = word.Length;
                }
            return n;
        }
    }
}
