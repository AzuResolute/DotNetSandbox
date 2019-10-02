using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refresher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Again");
            Console.WriteLine();
            Console.WriteLine("Select A Number");
            Console.WriteLine();

            //long.TryParse(Console.ReadLine(), out long query); 
            //long rowSumOddNumbersResult = Kata.rowSumOddNumbers(query);
            //Console.WriteLine($"Kata 1 - rowSum ===> {rowSumOddNumbersResult}");

            string sentence = Console.ReadLine();
            //string result = Kata.High(sentence);
            //Console.WriteLine($"Kata 2 - high ===> {result}");

            //string result = Kata.PigIt(sentence);
            //Console.WriteLine($"Kata 3 - PigIt ===> {result}");

            bool result = Kata.ValidParentheses(sentence);
            Console.WriteLine($"Kata 4 - ValidParenthesis ===> {result}");

            Console.ReadKey();
        }
    }

    public static class Kata
    {
        public static long rowSumOddNumbers(long n)
        {
            return (long)Math.Pow(n, 3);
        }

        public static string High(string s)
        {
            Dictionary<string, int>[] wordsWithScores = s.Split(' ').Select(word => {
                int[] letterScores = word.ToCharArray().Select(letter => (int)Char.ToUpper(letter) - 64).ToArray();
                int wordScore = letterScores.Aggregate((x, y) => x + y);
                return new Dictionary<string, int>(){ { word, wordScore } };
            }).ToArray();
            Dictionary<string, int> answer = wordsWithScores.Aggregate((x, y) => 
                x[x.Keys.First()] > y[y.Keys.First()] ? x : y
            );
            return answer.Keys.First();
        }

        public static string HighLinq(string s)
        {
            return s
                .Split(' ')
                .Select((word, i) =>
                (
                    Word: word,
                    Score: word.Sum(c => c - 'a'),
                    Iteration: i
                ))
                .OrderByDescending(w => w.Word)
                .ThenBy(w => w.Iteration)
                .First().Word;
        }
        public static string PigIt(string str)
        {
            return string.Join(" ", str
                .Split(' ')
                .Select(word => $"{word.Substring(1)}{word[0].ToString()}ay")
            );
        }
        
        public static bool ValidParentheses(string input)
        {
            int pending = 0;
            bool valid = true;
            for (int i = 0; i < input.Length; i++)
            {
                switch(input[i])
                {
                    case '(':
                        pending++;
                        break;
                    case ')':
                        pending--;
                        valid = pending >= 0 && valid == true ? true : false;
                        break;
                }
            }
            return pending == 0 && valid ? true : false;
        }
    }
}
