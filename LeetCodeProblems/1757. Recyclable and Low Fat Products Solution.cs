using System;
using System.Threading.Tasks;

using System;

/*
 
Table: Products

+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| product_id  | int     |
| low_fats    | enum    |
| recyclable  | enum    |
+-------------+---------+
product_id is the primary key (column with unique values) for this table.
low_fats is an ENUM (category) of type ('Y', 'N') where 'Y' means this product is low fat and 'N' means it is not.
recyclable is an ENUM (category) of types ('Y', 'N') where 'Y' means this product is recyclable and 'N' means it is not.
 

Write a solution to find the ids of products that are both low fat and recyclable.

Return the result table in any order.

The result format is in the following example.


Example 1:

Input: 
Products table:
+-------------+----------+------------+
| product_id  | low_fats | recyclable |
+-------------+----------+------------+
| 0           | Y        | N          |
| 1           | Y        | Y          |
| 2           | N        | Y          |
| 3           | Y        | Y          |
| 4           | N        | N          |
+-------------+----------+------------+
Output: 
+-------------+
| product_id  |
+-------------+
| 1           |
| 3           |
+-------------+
Explanation: Only products 1 and 3 are both low fat and recyclable.
 
 */


public class Program_1757
{
    public static void Example_1757()
    {
        InitiateExample1();
        List<Products> results = solveProblem();
        printExampleResult(results);
        DbCleanup();
 
    }

    static void InitiateExample1()
    {
        using var problemDB = new LeetCodeProblem();

        problemDB.Database.EnsureDeleted();
        problemDB.Database.EnsureCreated();

        var product1 = new Products { low_fats = 'Y', recyclable = 'N' };
        var product2 = new Products { low_fats = 'Y', recyclable = 'Y' };
        var product3 = new Products { low_fats = 'N', recyclable = 'Y' };
        var product4 = new Products { low_fats = 'Y', recyclable = 'Y' };
        var product5 = new Products { low_fats = 'N', recyclable = 'N' };

        problemDB.products.AddRange(product1, product2, product3, product4, product5);
        problemDB.SaveChanges();
    }



    static void DbCleanup()
    {
        using var problemDB = new LeetCodeProblem();
        problemDB.Database.EnsureDeleted(); 
    }




    static List<Products> solveProblem()
    {
        using var problemDB = new LeetCodeProblem();

        var bothLowFatAndRecyclable = problemDB.products
            .Where(p => p.low_fats == 'Y' && p.recyclable == 'Y')
            .ToList();

        return bothLowFatAndRecyclable;
    }




    static void printExampleResult(List<Products> results)
    {
        using var problemDB = new LeetCodeProblem();

        Console.WriteLine(
            "Table: Products:\n" +
            "+--------+-----------+------------+\n" +
            "|   id   |  low_fat  | recyclable |\n" +
            "+--------+-----------+------------+"
            );

        if (problemDB.products.Any())
        {
            foreach (var p in (problemDB.products.ToList()))
            {
                Console.WriteLine($"|   {p.ProductId}    |     {p.low_fats}     |     {p.recyclable}      |");
            }
        }
        else
        {
            Console.WriteLine("No recyclable products found.");
        }
        Console.WriteLine("+---------------------------------+");

        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "MISSION: \nWrite a solution to find the ids of products that are both low fat and recyclable.\nReturn the result table in any order."
            );

        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "SELECT OutPut:\n\n" +
            "Products table:\n" +
            "+----------------+\n" +
            "|   product_id   |\n" +
            "+----------------+"
            );

        if (results.Any())
        {
            foreach (var p in results)
            {
                Console.WriteLine($"|        {p.ProductId}       |");
            }
        }
        else
        {
            Console.WriteLine("No recyclable products found.");
        }

        Console.WriteLine("+----------------+");
    }
        

}
