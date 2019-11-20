using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refresher
{
    class Kata
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
                return new Dictionary<string, int>() { { word, wordScore } };
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
                switch (input[i])
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
            for (int i = 6; i < str.Length; i++)
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

        public static long DivisibleCount(long x, long y, long k)
        {
            //long current = x;
            //long found = 0;
            //while(current <= y)
            //{
            //    found += current % k == 0 ? 1 : 0;
            //    current++;
            //}
            //return found;

            long divisible = (y / k) - (x / k);

            if (x % k == 0)
                return divisible + 1;
            return divisible;
        }

        public static bool ValidateSolution(int[][] board)
        {

            List<int> found = new List<int>();
            int currentSquare;

            //check squares
            for (int a = 0; a < 9; a++)
            {
                for(int b = 0; b < 9; b++)
                {
                    long[] coord = SquareRegionFinder(a, b);
                    currentSquare = board[coord[0]][coord[1]];
                    if (!SquareAudit(found, currentSquare)) return false;
                }
                found.Clear();
                
            }

            //check rows
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    currentSquare = board[a][b];
                    if (!SquareAudit(found, currentSquare)) return false;
                }
                found.Clear();

            }

            //check columns
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    currentSquare = board[b][a];
                    if(!SquareAudit(found, currentSquare)) return false;
                }
                found.Clear();
            }

            return true;
        }

        public static long[] SquareRegionFinder(long a, long b)
        {
            long x = 3 * (a / 3) + (b / 3);
            long y = (b % 3) + 3 * (a % 3);
            return new long[] { x , y };
        }

        public static bool SquareAudit(List<int> found, int currentSquare)
        {
            if (found.IndexOf(currentSquare) == -1)
            {
                found.Add(currentSquare);
                return true;
            }
            return false;
        }

        public static void BoardAudit(long a, long b, long[] coord, int result, List<int> found)
        {
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"X = {coord[0]}, Y = {coord[1]}");
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Found = {string.Join(", ", found)}");
            Console.WriteLine();
        }
    }
}
