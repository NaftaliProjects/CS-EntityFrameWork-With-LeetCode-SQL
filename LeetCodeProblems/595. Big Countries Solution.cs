using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

/*

595. Big Countries
Easy
Topics
premium lock icon
Companies
SQL Schema
Pandas Schema
Table: World

+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| name        | varchar |
| continent   | varchar |
| area        | int     |
| population  | int     |
| gdp         | bigint  |
+-------------+---------+
name is the primary key (column with unique values) for this table.
Each row of this table gives information about the name of a country, the continent to which it belongs, its area, the population, and its GDP value.
 

A country is big if:
it has an area of at least three million (i.e., 3000000 km2), or
it has a population of at least twenty-five million (i.e., 25000000).
Write a solution to find the name, population, and area of the big countries.

Return the result table in any order.

The result format is in the following example.

 

Example 1:

Input: 
World table:
+-------------+-----------+---------+------------+--------------+
| name        | continent | area    | population | gdp          |
+-------------+-----------+---------+------------+--------------+
| Afghanistan | Asia      | 652230  | 25500100   | 20343000000  |
| Albania     | Europe    | 28748   | 2831741    | 12960000000  |
| Algeria     | Africa    | 2381741 | 37100000   | 188681000000 |
| Andorra     | Europe    | 468     | 78115      | 3712000000   |
| Angola      | Africa    | 1246700 | 20609294   | 100990000000 |
+-------------+-----------+---------+------------+--------------+
Output: 
+-------------+------------+---------+
| name        | population | area    |
+-------------+------------+---------+
| Afghanistan | 25500100   | 652230  |
| Algeria     | 37100000   | 2381741 |
+-------------+------------+---------+
 */
public class Program_595
{
    public static void Example_595()
    {
        InitiateExample1();
        List<World> results = solveProblem();
        printExampleResult(results);
        DbCleanup();

    }
    
    static void InitiateExample1()
    {
        using var problemDB = new LeetCodeProblems_595();

        problemDB.Database.EnsureDeleted();
        problemDB.Database.EnsureCreated();

        var area1 = new World { Name = "Afghanistan",Continent = "Asia",   Area = 652230,  Population = 25500100, Gdp = 20343000000 };
        var area2 = new World { Name = "Albania",    Continent = "Europe", Area = 28748,   Population = 2831741,  Gdp = 12960000000 };
        var area3 = new World { Name = "Algeria",    Continent = "Africa", Area = 2381741, Population = 37100000, Gdp = 188681000000 };
        var area4 = new World { Name = "Andorra",    Continent = "Europe", Area = 468,     Population = 78115,    Gdp = 3712000000 };
        var area5 = new World { Name = "Angola",     Continent = "Africa", Area = 1246700, Population = 20609294, Gdp = 100990000000 };



        problemDB.World.AddRange(area1, area2, area3, area4, area5);
        problemDB.SaveChanges();
    }



    static void DbCleanup()
    {
        using var problemDB = new LeetCodeProblems_595();
        problemDB.Database.EnsureDeleted();
    }




    static List<World> solveProblem()
    {
        /*\
         A country is big if:

        it has an area of at least three million (i.e., 3000000 km2), or
        it has a population of at least twenty-five million (i.e., 25000000).
        Write a solution to find the name, population, and area of the big countries.

        Return the result table in any order.
         */

        using var problemDB = new LeetCodeProblems_595();

        var result = problemDB.World
            .Where(p => p.Area >= 3000000 || p.Population >= 25000000)
            .ToList();

        return result;
    }




    static void printExampleResult(List<World> results)
    {
        using var problemDB = new LeetCodeProblems_595();


        Console.WriteLine(
            "Input:\n"+
            "World table:\n"+
            "+ -------------+-----------+---------+------------+--------------+\n"+
            "|    name      | continent |  area   | population |    gdp       |\n"+
            "+ -------------+-----------+---------+------------+--------------+\n"+
            "| Afghanistan  | Asia      | 652230  | 25500100   | 20343000000  |\n"+
            "| Albania      | Europe    | 28748   | 2831741    | 12960000000  |\n"+
            "| Algeria      | Africa    | 2381741 | 37100000   | 188681000000 |\n"+
            "| Andorra      | Europe    | 468     | 78115      | 3712000000   |\n"+
            "| Angola       | Africa    | 1246700 | 20609294   | 100990000000 |\n"+
            "+ -------------+-----------+---------+------------+--------------+\n"
            );



        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "MISSION: \nA country is big if:\r\nit has an area of at least three million (i.e., 3000000 km2), or\r\nit has a population of at least twenty-five million (i.e., 25000000).\r\nWrite a solution to find the name, population, and area of the big countries.\r\n\r\nReturn the result table in any order."
            );

        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "Example :\nSELECT OutPut:\n" +
            "+ ----------------+--------------+---------+\n" +
            "|    name         |  population  |  area   |\n" +
            "+ ----------------+--------------+---------+" 
            );

        if (results.Any())
        {
            foreach (var p in results)
            {
                Console.WriteLine($"    {p.Name}       {p.Population}    {p.Area}   ");
            }
        }
        else
        {
            Console.WriteLine("No recyclable products found.");
        }

        Console.WriteLine("+ ----------------+--------------+---------+");
    }


}
