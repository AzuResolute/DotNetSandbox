using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refresher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Again");
            //Console.WriteLine();
            //Console.WriteLine("Select A Number");
            //Console.WriteLine();

            //long.TryParse(Console.ReadLine(), out long query); 
            //long rowSumOddNumbersResult = Kata.rowSumOddNumbers(query);
            //Console.WriteLine($"Kata 1 - rowSum ===> {rowSumOddNumbersResult}");

            //string sentence = Console.ReadLine();
            ////string result = Kata.High(sentence);
            ////Console.WriteLine($"Kata 2 - high ===> {result}");

            ////string result = Kata.PigIt(sentence);
            ////Console.WriteLine($"Kata 3 - PigIt ===> {result}");

            ////bool result = Kata.ValidParentheses(sentence);
            ////Console.WriteLine($"Kata 4 - ValidParenthesis ===> {result}");

            //HashSet<string> result = Kata.Check1800(sentence);
            //Console.WriteLine($"Kata 4 - Check 1800 ===> {result.First()}");

            ADONetPractice("Hello");

            Console.ReadKey();
        }

        protected static void ADONetPractice(string input)
        {
            string CS = "data source=localhost; database = Northwind; integrated security=SSPI";
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
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


        public static HashSet<string> Check1800(string str)
        {
            string answer = "1-800-";
            for(int i = 6; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        answer += '2';
                        break;
                    case 'D':
                    case 'E':
                    case 'F':
                        answer += '3';
                        break;
                    case 'G':
                    case 'H':
                    case 'I':
                        answer += '4';
                        break;
                    case 'J':
                    case 'K':
                    case 'L':
                        answer += '5';
                        break;
                    case 'M':
                    case 'N':
                    case 'O':
                        answer += '6';
                        break;
                    case 'P':
                    case 'Q':
                    case 'R':
                    case 'S':
                        answer += '7';
                        break;
                    case 'T':
                    case 'U':
                    case 'V':
                        answer += '8';
                        break;
                    case 'W':
                    case 'X':
                    case 'Y':
                    case 'Z':
                        answer += '9';
                        break;
                    default:
                        answer += str[i];
                        break;
                }
            }
            return new HashSet<string>() { answer };
        }
    }
}
