using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqLibrary;

namespace Refresher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Again");
            //Console.WriteLine();
            //string sentence = Console.ReadLine();

            //Console.WriteLine();
            //Console.WriteLine("Select an ID");
            //int id = int.Parse(Console.ReadLine());

            //Console.WriteLine();
            //Console.WriteLine("Select a new category name");
            //string newcat = Console.ReadLine();

            //Console.WriteLine();
            //Console.WriteLine("Select a new description");
            //string newdesc = Console.ReadLine();

            //long.TryParse(Console.ReadLine(), out long query); 
            //long rowSumOddNumbersResult = Kata.rowSumOddNumbers(query);
            //Console.WriteLine($"Kata 1 - rowSum ===> {rowSumOddNumbersResult}");

            //string result = Kata.High(sentence);
            //Console.WriteLine($"Kata 2 - high ===> {result}");

            //string result = Kata.PigIt(sentence);
            //Console.WriteLine($"Kata 3 - PigIt ===> {result}");

            //bool result = Kata.ValidParentheses(sentence);
            //Console.WriteLine($"Kata 4 - ValidParenthesis ===> {result}");

            //HashSet<string> result = Kata.Check1800(sentence);
            //Console.WriteLine($"Kata 4 - Check 1800 ===> {result.First()}");

            //ADOPractice.ADOReadTable(sentence);
            //ADOPractice.ADOReadTableViaAdapter(sentence);
            //Console.WriteLine();
            //ADOPractice.ADOTableSize(sentence);

            //ADOPractice.ADOCategoryInsert(newcat, newdesc);
            //ADOPractice.ADOUpdate(id, newcat, newdesc);
            //ADOPractice.ADOViewCategoriesAndProducts();
            //ADOPractice.ADOReadFromExcel();

            //Console.WriteLine();
            //Console.WriteLine("Breadth First Search");
            //Console.WriteLine();


            //List<string> results = TreeSearch.RunBreadthFirstSearch();
            //foreach(string result in results)
            //{
            //    Console.WriteLine(result);
            //}


            //Console.WriteLine();
            //Console.WriteLine("Depth First Search");
            //Console.WriteLine();

            //results = TreeSearch.RunDepthFirstSearchRecursive();
            //foreach (string result in results)
            //{
            //    Console.WriteLine(result);
            //}


            //List<Activity> activities = ListManager.LoadSampleData()
            //    .Where(act => act.Category == "Social")
            //    .OrderByDescending(act => act.Attendees)
            //    .ThenByDescending(act => act.StartDate)
            //    .ToList();

            //ListManager.WriteAll(activities);

            //Console.WriteLine($"Total Attendees: {activities.Sum(x => x.Attendees)}");
            //Console.WriteLine($"Average Attendees: {activities.Sum(x => x.Attendees) / activities.Count}");

            //Console.WriteLine($"X = {Kata.SquareRegionFinder(0,0)[0]}, Y = {Kata.SquareRegionFinder(0, 0)[1]}");
            //Console.WriteLine($"X = {Kata.SquareRegionFinder(0,1)[0]}, Y = {Kata.SquareRegionFinder(0, 1)[1]}");
            //Console.WriteLine($"X = {Kata.SquareRegionFinder(0,2)[0]}, Y = {Kata.SquareRegionFinder(0, 2)[1]}");
            //Console.WriteLine($"X = {Kata.SquareRegionFinder(3,0)[0]}, Y = {Kata.SquareRegionFinder(3, 0)[1]}");
            //Console.WriteLine($"X = {Kata.SquareRegionFinder(4,0)[0]}, Y = {Kata.SquareRegionFinder(4, 0)[1]}");
            //Console.WriteLine($"X = {Kata.SquareRegionFinder(5,0)[0]}, Y = {Kata.SquareRegionFinder(5, 0)[1]}");

            Kata.ValidateSolution();

            Console.ReadKey();
        }
    }
}
