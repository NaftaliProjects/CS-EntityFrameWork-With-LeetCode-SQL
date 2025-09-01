using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

Table: Customer

+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| id          | int     |
| name        | varchar |
| referee_id  | int     |
+-------------+---------+
In SQL, id is the primary key column for this table.
Each row of this table indicates the id of a customer, their name, and the id of the customer who referred them.
 

Find the names of the customer that are either:

referred by any customer with id != 2.
not referred by any customer.
Return the result table in any order.

The result format is in the following example.

 

Example 1:

Input: 
Customer table:
+----+------+------------+
| id | name | referee_id |
+----+------+------------+
| 1  | Will | null       |
| 2  | Jane | null       |
| 3  | Alex | 2          |
| 4  | Bill | null       |
| 5  | Zack | 1          |
| 6  | Mark | 2          |
+----+------+------------+
Output: 
+------+
| name |
+------+
| Will |
| Jane |
| Bill |
| Zack |
+------+ 

 */
public class Program_584
{
    public static void Example_584()
    {
        InitiateExample1();
        List<Customer> results = solveProblem();
        printExampleResult(results);
        DbCleanup();

    }

    static void InitiateExample1()
    {
        using var problemDB = new LeetCodeProblems_584();

        problemDB.Database.EnsureDeleted();
        problemDB.Database.EnsureCreated();

        var customer1 = new Customer { Name = "Will" };
        var customer2= new Customer { Name = "Jane" };
        var customer3 = new Customer { Name = "Alex", Referee_id = 1};
        var customer4 = new Customer { Name = "Bill" };
        var customer5 = new Customer { Name = "Zack", Referee_id = 1 };
        var customer6 = new Customer { Name = "Mark", Referee_id = 2 };


        problemDB.Customer.AddRange(customer1, customer2, customer3, customer4, customer5, customer6);
        problemDB.SaveChanges();
    }



    static void DbCleanup()
    {
        using var problemDB = new LeetCodeProblems_584();
        problemDB.Database.EnsureDeleted();
    }




    static List<Customer> solveProblem()
    {
        using var problemDB = new LeetCodeProblems_584();

        var result = problemDB.Customer
            .Where(p => p.Referee_id != 2 || p.Referee_id == null)
            .ToList();

        return result;
    }




    static void printExampleResult(List<Customer> results)
    {
        using var problemDB = new LeetCodeProblems_584();

        
        Console.WriteLine(
            "Example :\nInput:\n" +
            "Customer table:\n"+
            "+-------+----------+------------+\n"+
            "|  id   |  name    | referee_id |\n"+
            "+-------+----------+------------+"
            );

        if (problemDB.Customer.Any())
        {
            foreach (var p in (problemDB.Customer.ToList()))
            {
                Console.WriteLine($"|   {p.Id}   |   {p.Name}   | {(p.Referee_id.HasValue ? p.Referee_id.ToString()+"   " : "null")} |");
            }
        }
        else
        {
            Console.WriteLine("No recyclable products found.");
        }
        Console.WriteLine("+-------------------------+");


        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "MISSION: \nWrite a solution to find the ids of products that are both low fat and recyclable.\nReturn the result table in any order."
            );

        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "Example 1:\nSELECT OutPut:\n" +
            "Customer table:\n" +
            "+------+\n" +
            "| name |\n" +
            "+------+"
            );

        if (results.Any())
        {
            foreach (var p in results)
            {
                Console.WriteLine($"| {p.Name} |");
            }
        }
        else
        {
            Console.WriteLine("No recyclable products found.");
        }

        Console.WriteLine("+------+");
    }


}
