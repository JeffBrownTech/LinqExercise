using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"\nSum of numbers: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"\nAverage of numbers: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            var orderAscending = numbers.OrderBy(x => x).ToList();
            Console.WriteLine("\nAscending Order:");
            orderAscending.ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in descending order and print to the console
            var orderDescending = numbers.OrderByDescending(x => x).ToList();
            Console.WriteLine("\nDescending Order:");
            orderDescending.ForEach(x => Console.WriteLine(x));

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(x => x > 6).ToList();
            Console.WriteLine("\nNumbers greater than six:");
            greaterThanSix.ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("\nFirst four numbers from ascending list:");
            foreach (var n in orderAscending.Take(4))
            {
                Console.WriteLine(n);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 40;
            orderDescending = numbers.OrderByDescending(x => x).ToList();
            Console.WriteLine("\nNew Descending Order:");
            orderDescending.ForEach(x => Console.WriteLine(x));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var listOne = (from emp in employees
                           where emp.FirstName.StartsWith("C") || emp.FirstName.StartsWith("S")
                           orderby emp.FirstName
                           select emp.FullName).ToList();
            Console.WriteLine("\nPrint FullName of employees starting with C or S orderd by FirstName:");
            listOne.ForEach(x => Console.WriteLine(x));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var over26 = (
                from emp in employees
                where emp.Age > 26
                orderby emp.Age, emp.FirstName
                select emp.FullName
            ).ToList();
            Console.WriteLine("\nPrint FullName of employees over 26, sorted by Age and FirstName:");
            over26.ForEach(x => Console.WriteLine(x));

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yoe = (
                from emp in employees
                where emp.YearsOfExperience <= 10 && emp.Age > 35
                select emp.YearsOfExperience
            ).Sum();
            Console.WriteLine($"\nSum of YearsOfExperience when YOE <= 10 AND Age > 35: {yoe}");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yoeAverage = (
                from emp in employees
                where emp.YearsOfExperience <= 10 && emp.Age > 35
                select emp.YearsOfExperience
            ).Average();
            Console.WriteLine($"\nAverage of YearsOfExperience when YOE <= 10 AND Age > 35: {yoeAverage}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            var newEmployees = new List<Employee> {new Employee("Jeff", "Brown", 40, 1)};
            employees.AddRange(newEmployees);

            Console.WriteLine("\nUpdate Employee List:");
            employees.ForEach(x => Console.WriteLine($"{x.FullName}"));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
