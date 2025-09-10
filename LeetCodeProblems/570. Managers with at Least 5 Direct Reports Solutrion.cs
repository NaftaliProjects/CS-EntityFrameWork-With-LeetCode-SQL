using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*

570. Managers with at Least 5 Direct Reports
Medium
Topics
premium lock icon
Companies
Hint
SQL Schema
Pandas Schema
Table: Employee

+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| id          | int     |
| name        | varchar |
| department  | varchar |
| managerId   | int     |
+-------------+---------+
id is the primary key (column with unique values) for this table.
Each row of this table indicates the name of an employee, their department, and the id of their manager.
If managerId is null, then the employee does not have a manager.
No employee will be the manager of themself.
 

Write a solution to find managers with at least five direct reports.

Return the result table in any order.

The result format is in the following example.

Example 1:

Input: 
Employee table:
+-----+-------+------------+-----------+
| id  | name  | department | managerId |
+-----+-------+------------+-----------+
| 101 | John  | A          | null      |
| 102 | Dan   | A          | 101       |
| 103 | James | A          | 101       |
| 104 | Amy   | A          | 101       |
| 105 | Anne  | A          | 101       |
| 106 | Ron   | B          | 101       |
+-----+-------+------------+-----------+
Output: 
+------+
| name |
+------+
| John |
+------+
 
+-------------+------------+---------+
 */
public class Program_570
{
    public static void Example_570()
    {
        InitiateExample1();
        List<Employee> results = solveProblem();
        printExampleResult(results);
        DbCleanup();

    }

    static void InitiateExample1()
    {
        using var problemDB = new LeetCodeProblems_570();

        // Ensure the database is clean and freshly created for the example
        problemDB.Database.EnsureDeleted();
        problemDB.Database.EnsureCreated();

        // Create the Employee objects with explicit Id assignments to match the problem's data.
        var employee1 = new Employee { Id = 101, Name = "John" , Department = "A", ManagerId = null};
        var employee2 = new Employee { Id = 102, Name = "Dan"  , Department = "A", ManagerId = 101 };
        var employee3 = new Employee { Id = 103, Name = "James", Department = "A", ManagerId = 101 };
        var employee4 = new Employee { Id = 104, Name = "Amy"  , Department = "A", ManagerId = 101 };
        var employee5 = new Employee { Id = 105, Name = "Anne" , Department = "A", ManagerId = 101 };
        var employee6 = new Employee { Id = 106, Name = "Ron"  , Department = "B", ManagerId = 101 };

        problemDB.Employee.AddRange(employee1, employee2, employee3, employee4, employee5, employee6);
        problemDB.SaveChanges();
    }



    static void DbCleanup()
    {
        using var problemDB = new LeetCodeProblems_570();
        problemDB.Database.EnsureDeleted();
    }




    static List<Employee> solveProblem()
    {
        /*
         * Write a solution to find managers with at least five direct reports.
         * Return the result table in any order.
         * The result format is in the following example.
         */

        using var problemDB = new LeetCodeProblems_570();

        var managerIds = problemDB.Employee
            .GroupBy(e => e.ManagerId)
            .Where(g => g.Count() >= 5)
            .Select(g => g.Key)
            .Where(managerId => managerId != null)
            .ToList();


        var result = problemDB.Employee
            .Where(e => managerIds.Contains(e.Id))
            .ToList();

        return result;
    }




    static void printExampleResult(List<Employee> results)
    {
        using var problemDB = new LeetCodeProblems_570();


        Console.WriteLine(
            "Input:\n" +
            "Employee table:\n" +
            "+-----+-------+------------+-----------+\n" +
            "| id | name | department | managerId |\n" +
            "+-----+-------+------------+-----------+\n" +
            "| 101 | John | A | null |\n" +
            "| 102 | Dan | A | 101 |\n" +
            "| 103 | James | A | 101 |\n" +
            "| 104 | Amy | A | 101 |\n" +
            "| 105 | Anne | A | 101 |\n" +
            "| 106 | Ron | B | 101 |\n"+
            "+-----+-------+------------+-----------+"
            );



        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "MISSION: \nA country is big if:\r\nit has an area of at least three million (i.e., 3000000 km2), or\r\nit has a population of at least twenty-five million (i.e., 25000000).\r\nWrite a solution to find the name, population, and area of the big countries.\r\n\r\nReturn the result table in any order."
            );

        Console.WriteLine("\n\n\n");

        Console.WriteLine(
            "Example :\nSELECT OutPut:\n" +
            "+ ----------------+\n" +
            "|    name   |\n" +
            "+ ----------------+"
            );

        if (results.Any())
        {
            foreach (var p in results)
            {
                Console.WriteLine($"    {p.Name}   ");
            }
        }
        else
        {
            Console.WriteLine("No Manager found.");
        }

        Console.WriteLine("+ ----------------+");
    }


}
