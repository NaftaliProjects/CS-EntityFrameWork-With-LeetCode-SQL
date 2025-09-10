using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

/*

1148. Article Views I
Easy
Topics
premium lock icon
Companies
SQL Schema
Pandas Schema
Table: Views

+---------------+---------+
| Column Name   | Type    |
+---------------+---------+
| article_id    | int     |
| author_id     | int     |
| viewer_id     | int     |
| view_date     | date    |
+---------------+---------+
There is no primary key (column with unique values) for this table, the table may have duplicate rows.
Each row of this table indicates that some viewer viewed an article (written by some author) on some date. 
Note that equal author_id and viewer_id indicate the same person.
 

Write a solution to find all the authors that viewed at least one of their own articles.

Return the result table sorted by id in ascending order.

The result format is in the following example.

 

Example 1:

Input: 
Views table:
+------------+-----------+-----------+------------+
| article_id | author_id | viewer_id | view_date  |
+------------+-----------+-----------+------------+
| 1          | 3         | 5         | 2019-08-01 |
| 1          | 3         | 6         | 2019-08-02 |
| 2          | 7         | 7         | 2019-08-01 |
| 2          | 7         | 6         | 2019-08-02 |
| 4          | 7         | 1         | 2019-07-22 |
| 3          | 4         | 4         | 2019-07-21 |
| 3          | 4         | 4         | 2019-07-21 |
+------------+-----------+-----------+------------+
Output: 
+------+
| id   |
+------+
| 4    |
| 7    |
+------+
 */
public class Program_1148
{
    public static void Example_1148()
    {
        InitiateExample1();
        List<int> results = solveProblem();
        printExampleResult(results);
        DbCleanup();

    }

    static void InitiateExample1()
    {
        using var problemDB = new LeetCodeProblems_1148();

        problemDB.Database.EnsureDeleted();
        problemDB.Database.EnsureCreated();


        var view1 = new Views { Article_id = 1, Author_id = 3, Viewer_id = 5, View_date = new DateTime(2019, 08, 01) };
        var view2 = new Views { Article_id = 1, Author_id = 3, Viewer_id = 6, View_date = new DateTime(2019, 08, 02) };
        var view3 = new Views { Article_id = 2, Author_id = 7, Viewer_id = 7, View_date = new DateTime(2019, 08, 01) };
        var view4 = new Views { Article_id = 2, Author_id = 7, Viewer_id = 6, View_date = new DateTime(2019, 08, 02) };
        var view5 = new Views { Article_id = 4, Author_id = 7, Viewer_id = 1, View_date = new DateTime(2019, 07, 22) };
        var view6 = new Views { Article_id = 3, Author_id = 4, Viewer_id = 4, View_date = new DateTime(2019, 07, 21) };
        var view7 = new Views { Article_id = 3, Author_id = 4, Viewer_id = 4, View_date = new DateTime(2019, 07, 21) };



        problemDB.Views.AddRange(view1, view2, view3, view4, view5, view6, view7);
        problemDB.SaveChanges();
    }



    static void DbCleanup()
    {
        using var problemDB = new LeetCodeProblems_1148();
        problemDB.Database.EnsureDeleted();
    }




    static List<int> solveProblem()
    {
        /*
            Write a solution to find all the authors that viewed at least one of their own articles.
            Return the result table sorted by id in ascending order.
            The result format is in the following example.
         */

        using var problemDB = new LeetCodeProblems_1148();

        var result = problemDB.Views
            .Where(p => p.Viewer_id == p.Author_id)
            .Select(x => x.Author_id)
            .Distinct()
            .Order()
            .ToList();

        return result;
    }




    static void printExampleResult(List<int> results)
    {
        using var problemDB = new LeetCodeProblems_1148();

        











        Console.WriteLine(
            "Input:\n" +
            "Views table:\n" +
            "+------------+-----------+-----------+-----------------+\n" +
            "| article_id | author_id | viewer_id |     view_date   |\n" +
            "+------------+-----------+-----------+-----------------+\n" +
            "|      1     |     3     |      5    |  2019 - 08 - 01 |\n" +
            "|      1     |     3     |      6    |  2019 - 08 - 02 |\n" +
            "|      2     |     7     |      7    |  2019 - 08 - 01 |\n" +
            "|      2     |     7     |      6    |  2019 - 08 - 02 |\n" +
            "|      4     |     7     |      1    |  2019 - 07 - 22 |\n" +
            "|      3     |     4     |      4    |  2019 - 07 - 21 |\n"+
            "|      3     |     4     |      4    |  2019 - 07 - 21 |\n"+
            "+------------+-----------+-----------+-----------------+"
            );

        

        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "MISSION: \nA Write a solution to find all the authors that viewed at least one of their own articles.\r\n\r\nReturn the result table sorted by id in ascending order.\r\n\r\nThe result format is in the following example."
            );

        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "Example :\nSELECT OutPut:\n" +
            "+ ---------+\n" +
            "|    id    |\n" +
            "+----------+"
            );

        if (results.Any())
        {
            foreach (var id in results)
            {
                Console.WriteLine($"    {id}  ");
            }
        }
        else
        {
            Console.WriteLine("No recyclable products found.");
        }

    
    }


}
