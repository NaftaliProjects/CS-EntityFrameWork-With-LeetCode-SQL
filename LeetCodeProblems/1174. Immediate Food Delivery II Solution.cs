using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

/*

1174. Immediate Food Delivery II
Medium
Topics
premium lock icon
Companies
SQL Schema
Pandas Schema
Table: Delivery

+-----------------------------+---------+
| Column Name                 | Type    |
+-----------------------------+---------+
| delivery_id                 | int     |
| customer_id                 | int     |
| order_date                  | date    |
| customer_pref_delivery_date | date    |
+-----------------------------+---------+
delivery_id is the column of unique values of this table.
The table holds information about food delivery to customers that make orders at some date and specify a preferred delivery date (on the same order date or after it).
 

If the customer's preferred delivery date is the same as the order date, then the order is called immediate; otherwise, it is called scheduled.
The first order of a customer is the order with the earliest order date that the customer made. It is guaranteed that a customer has precisely one first order.
Write a solution to find the percentage of  orders in the first orders of all customers, rounded to 2 decimal places.
The result format is in the following example.

 

Example 1:

Input: 
Delivery table:
+-------------+-------------+------------+-----------------------------+
| delivery_id | customer_id | order_date | customer_pref_delivery_date |
+-------------+-------------+------------+-----------------------------+
| 1           | 1           | 2019-08-01 | 2019-08-02                  |
| 2           | 2           | 2019-08-02 | 2019-08-02                  |
| 3           | 1           | 2019-08-11 | 2019-08-12                  |
| 4           | 3           | 2019-08-24 | 2019-08-24                  |
| 5           | 3           | 2019-08-21 | 2019-08-22                  |
| 6           | 2           | 2019-08-11 | 2019-08-13                  |
| 7           | 4           | 2019-08-09 | 2019-08-09                  |
+-------------+-------------+------------+-----------------------------+
Output: 
+----------------------+
| immediate_percentage |
+----------------------+
| 50.00                |
+----------------------+
Explanation: 
The customer id 1 has a first order with delivery id 1 and it is scheduled.
The customer id 2 has a first order with delivery id 2 and it is immediate.
The customer id 3 has a first order with delivery id 5 and it is scheduled.
The customer id 4 has a first order with delivery id 7 and it is immediate.
Hence, half the customers have immediate first orders.
 */
public class Program_1174
{
    public static void Example_1174()
    {
        InitiateExample1();
        double results = solveProblem();
        printExampleResult(results);
        DbCleanup();

    }

    static void InitiateExample1()
    {
        using var problemDB = new LeetCodeProblems_1174();

        problemDB.Database.EnsureDeleted();
        problemDB.Database.EnsureCreated();
         
        var area1 = new Delivery { Customer_id = 1, Order_date = new DateTime(2019, 8, 1),  Customer_pref_delivery_date = new DateTime(2019, 8, 2)  };
        var area2 = new Delivery { Customer_id = 2, Order_date = new DateTime(2019, 8, 2),  Customer_pref_delivery_date = new DateTime(2019, 8, 2)  };
        var area3 = new Delivery { Customer_id = 1, Order_date = new DateTime(2019, 8, 11), Customer_pref_delivery_date = new DateTime(2019, 8, 12) };
        var area4 = new Delivery { Customer_id = 3, Order_date = new DateTime(2019, 8, 24), Customer_pref_delivery_date = new DateTime(2019, 8, 24) };
        var area5 = new Delivery { Customer_id = 3, Order_date = new DateTime(2019, 8, 21), Customer_pref_delivery_date = new DateTime(2019, 8, 22) };
        var area6 = new Delivery { Customer_id = 2, Order_date = new DateTime(2019, 8, 11), Customer_pref_delivery_date = new DateTime(2019, 8, 13) };
        var area7 = new Delivery { Customer_id = 4, Order_date = new DateTime(2019, 8, 9),  Customer_pref_delivery_date = new DateTime(2019, 8, 9)  };



        problemDB.Delivery.AddRange(area1, area2, area3, area4, area5, area6, area7);
        problemDB.SaveChanges();
    }



    static void DbCleanup()
    {
        using var problemDB = new LeetCodeProblems_1174();
        problemDB.Database.EnsureDeleted();
    }




    static double solveProblem()
    {
        using var problemDB = new LeetCodeProblems_1174();

       


        var firstOrders = problemDB.Delivery
            .GroupBy(c => c.Customer_id)
            .Select(g => new {
                CustomerId = g.Key,
                FirstOrder = g.OrderBy(o => o.Order_date).First()
            })
            .ToList();


        var numOfFirstImmediateOrders = firstOrders
    .Count(o => o.FirstOrder.Order_date == o.FirstOrder.Customer_pref_delivery_date); 

        var totalCustomers = firstOrders.Count; 

        double percentage = (double)numOfFirstImmediateOrders / totalCustomers * 100.0;


        return Math.Round(percentage, 2); 




    }




    static void printExampleResult(double results)
    {
        using var problemDB = new LeetCodeProblems_1174();



        Console.WriteLine(
            "Input:\n" +
            "Delivery table:\n" +
            "+-------------+-------------+----------------+-----------------------------+\n" +
            "| delivery_id | customer_id | order_date     | customer_pref_delivery_date |\n" +
            "+-------------+-------------+----------------+-----------------------------+\n" +
            "|      1      |     1       | 2019 - 08 - 01 |     2019 - 08 - 02          |\n" +
            "|      2      |     2       | 2019 - 08 - 02 |     2019 - 08 - 02          |\n" +
            "|      3      |     1       | 2019 - 08 - 11 |     2019 - 08 - 12          |\n" +
            "|      4      |     3       | 2019 - 08 - 24 |     2019 - 08 - 24          |\n" +
            "|      6      |     2       | 2019 - 08 - 11 |     2019 - 08 - 13          |\n" +
            "|      7      |     4       | 2019 - 08 - 09 |     2019 - 08 - 09          |\n" +
            "+-------------+-------------+------------+---------------------------------+"
            );



        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "If the customer's preferred delivery date is the same as the order date, then the order is called immediate; otherwise, it is called scheduled.\r\nThe first order of a customer is the order with the earliest order date that the customer made. It is guaranteed that a customer has precisely one first order.\r\nWrite a solution to find the percentage of  orders in the first orders of all customers, rounded to 2 decimal places.\r\nThe result format is in the following example."
            );

        Console.WriteLine("\n\n\n");

        Console.WriteLine("+ ----------------+--------------+---------+");
        Console.WriteLine($"The Presentacge of immediate first oreders is :  {results}");

        Console.WriteLine("+ ----------------+--------------+---------+");
    }


}
