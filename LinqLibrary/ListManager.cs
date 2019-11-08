using System;
using System.Collections.Generic;
using System.Text;

namespace LinqLibrary
{
    public class ListManager
    {
        public static List<Activity> LoadSampleData()
        {
            List<Activity> results = new List<Activity>();

            results.Add(new Activity { Title = "Networking for Nurses", Description = "Meeting registered nurses from all over New York who specialize in different units ", Category = "Health/Medical", StartDate = DateTime.ParseExact("20191002T18:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("20191002T20:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), City = "New York, NY", Venue = "TBD" , Attendees = 25});

            results.Add(new Activity { Title = "Unity Games", Description = "Competition to foster the love of the brotherhood", Category = "Sports", StartDate = DateTime.ParseExact("20191014T08:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("20191014T16:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), City = "Boston, MA", Venue = "Sports Complex", Attendees = 150});

            results.Add(new Activity { Title = "Kadiwa Spartan Race", Description = "Where challengers are tested. The strong will previal.", Category = "Social", StartDate = DateTime.ParseExact("20191102T08:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("20191102T16:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), City = "Bellmore, NY", Venue = "Spartan Race", Attendees = 12});

            results.Add(new Activity { Title = "Ice Skating", Description = "A world-class ice skating facility, the City Ice Pavilion features a NHL-size ice rink that is open year-round and is sheltered from winter weather by a sky-high Yeadon air dome", Category = "Sports", StartDate = DateTime.ParseExact("20191215T13:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("20191215T15:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), City = "Long Island City, NY", Venue = "City Ice Pavillion", Attendees = 32});

            results.Add(new Activity { Title = "Kadiwa Formal", Description = "INC promenade", Category = "Social", StartDate = DateTime.ParseExact("20200209T10:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("20200209T18:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), City = "New York, NY", Venue = "Le Estelle", Attendees = 75});

            results.Add(new Activity { Title = "Apple Picking", Description = "Picking Apples", Category = "Social", StartDate = DateTime.ParseExact("20191019T08:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("20191019T15:00:00Z", "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture), City = "Farmingdale, NY", Venue = "Farm", Attendees = 40});

            return results;
        }

        public static void WriteAll()
        {
            LoadSampleData()
                .ForEach(x => {
                    Console.WriteLine($"Title: {x.Title}");
                    Console.WriteLine($"Description: {x.Description}");
                    Console.WriteLine($"Category: {x.Category}");
                    Console.WriteLine($"City: {x.City}");
                    Console.WriteLine($"Attendees: {x.Attendees}");
                    Console.WriteLine();
                }
            );
        }

        public static void WriteAll(List<Activity> activityList)
        {
            activityList
                .ForEach(x => {
                    Console.WriteLine($"Title: {x.Title}");
                    Console.WriteLine($"Description: {x.Description}");
                    Console.WriteLine($"Category: {x.Category}");
                    Console.WriteLine($"City: {x.City}");
                    Console.WriteLine($"Attendees: {x.Attendees}");
                    Console.WriteLine();
                }
            );
        }
    }
}
