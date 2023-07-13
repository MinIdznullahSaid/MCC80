using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;

namespace DatabaseConnectivity;
public class Program
{
    private static string _connectionString = "Data Source = WISNU-PC;Database = db_hrd;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("== Menu Database HR ==");
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Departements");
            Console.WriteLine("3. Jobs");
            Console.WriteLine("4. Countries");
            Console.WriteLine("5. Regions");
            Console.WriteLine("6. Locations");
            Console.WriteLine("7. Hitories");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Employees.Execute();
                    break;
                case "2":
                    Console.Clear();
                    Departements.Execute();
                    break;
                case "3":
                    Console.Clear();
                    Jobs.Execute();
                    break;
                case "4":
                    Console.Clear();
                    Countries.Execute();
                    break;
                case "5":
                    Console.Clear();
                    Regions.Execute();
                    break;
                case "6":
                    Console.Clear();
                    Locations.Execute();
                    break;
                case "7":
                    Console.Clear();
                    Histories.Execute();
                    break;
                case "8":
                    return;
                default:
                    return;
            }

            Console.WriteLine();
        }
    }
}
