using System;
using System.Collections.Generic;
using System.IO;

namespace PhDevApp
{
    internal class Program
    {
        private static void Main()
        {

            try
            {
                using (var reader = new StreamReader("a.txt"))
                {

                    var now = DateTime.Now;

                    Console.WriteLine("Enter start date:");
                    Console.WriteLine("Year: ");
                    var startYear = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Month: ");
                    var startMonth = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Day: ");
                    var startDay = Convert.ToInt32(Console.ReadLine());

                    var startDate = new DateTime(startYear, startMonth, startDay);

                    var types = new List<string>();
                    var levels = new List<string>();
                    var dates = new List<DateTime>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line == null) continue;
                        types.Add(line.Split(',')[0]);
                        levels.Add(line.Split(',')[1]);
                        dates.Add(Convert.ToDateTime(line.Split(',')[2]));
                    }

                    // Console.WriteLine(("begin");

                    int a = -1, p = -1;
                    bool aFlag = true, pFlag = true;
                    var i = types.Count - 1;
                    while (aFlag && i > -1)
                    {
                        if (types[i].StartsWith("a"))
                        {
                            aFlag = false;
                            a = i;
                        }
                        i--;
                    }

                    i = types.Count - 1;
                    while (pFlag && i > -1)
                    {
                        if (types[i].StartsWith("p"))
                        {
                            pFlag = false;
                            p = i;
                        }
                        i--;
                    }

                    // Console.WriteLine(("events");

                    int ablue = 0, ayellow = 0, ared = 0;
                    int pblue = 0, pyellow = 0, pred = 0;
                    for (var j = 0; j < levels.Count; j++)
                    {
                        if (dates[j] <= startDate) continue;
                        if (types[j].Equals("a"))
                        {
                            if (levels[j].Equals("blue")) ablue++;
                            else if (levels[j].Equals("yellow")) ayellow++;
                            else if (levels[j].Equals("red")) ared++;
                        }
                        else if (types[j].Equals("p"))
                        {
                            if (levels[j].Equals("blue")) pblue++;
                            else if (levels[j].Equals("yellow")) pyellow++;
                            else if (levels[j].Equals("red")) pred++;
                        }
                    }

                    // Console.WriteLine(("a: " + a);
                    // Console.WriteLine(("p: " + p);

                    if (a > -1 && p > -1)
                    {
                        var zeroTime = new DateTime(1, 1, 1);
                        var span = now - dates[a];
                        var years = (zeroTime + span).Year - 1;
                        var months = (zeroTime + span).Month - 1;
                        var days = (zeroTime + span).Day - 1;
                        Console.WriteLine("");
                        Console.WriteLine("  A");
                        Console.WriteLine($"    {dates[a].Day}/{dates[a].Month}/{dates[a].Year}");
                        Console.WriteLine($"    {years} years, {months} months, {days} days");
                        Console.WriteLine($"    {ablue} blue, {ayellow} yellow, {ared} red since {startDate.Day}/{startDate.Month}/{startDate.Year}");

                        span = now - dates[p];
                        years = (zeroTime + span).Year - 1;
                        months = (zeroTime + span).Month - 1;
                        days = (zeroTime + span).Day - 1;

                        Console.WriteLine("");
                        Console.WriteLine("  P");
                        Console.WriteLine($"    {dates[p].Day}/{dates[p].Month}/{dates[p].Year}");
                        Console.WriteLine($"    {years} years, {months} months, {days} days");
                        Console.WriteLine($"    {pblue} blue, {pyellow} yellow, {pred} red since {startDate.Day}/{startDate.Month}/{startDate.Year}");
                    }
                    else
                    {
                        Console.WriteLine("Calculation went wrong.");
                    }


                    Console.ReadLine();

                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Not a valid date");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch{
                Console.WriteLine("The file could not be read");
                Console.ReadLine();
            }
            
            
        }
    }
}
