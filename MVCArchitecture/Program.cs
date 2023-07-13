using Microsoft.VisualBasic;
using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MVCArchitecture;
public class Program
{
    public static void Main()
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        bool loop = true;
        do
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
            Console.Write("Enter your choice (1-8): ");
            string choice = Console.ReadLine();

            try
            {
                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        EmployeesMenu();
                        break;
                    case "2":
                        Console.Clear();
                        DepartementsMenu();
                        break;
                    case "3":
                        Console.Clear();
                        JobsMenu();
                        break;
                    case "4":
                        Console.Clear();
                        CountriesMenu();
                        break;
                    case "5":
                        Console.Clear();
                        RegionsMenu();
                        break;
                    case "6":
                        Console.Clear();
                        LocationsMenu();
                        break;
                    case "7":
                        Console.Clear();
                        HistoriesMenu();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Enter your choice (1-8): ");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Enter your choice (1-8): ");
            }
        } while (loop);
    }

    private static void RegionsMenu()
    {
        Region region = new Region();
        VRegion vRegion = new VRegion();
        CRegion cRegion = new CRegion(region, vRegion);

        bool isTrue = true;
        do
        {
            int choice = vRegion.Menu();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Insert();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    break;
                case "4":
                    GetById();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void CountriesMenu()
    {
        Country country = new Country();
        VCountry vCountry = new VCountry();
        CCountry cCountry = new CCountry(country, vCountry);

        bool isTrue = true;
        do
        {
            int choice = vCountry.Menu();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Insert();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    break;
                case "4":
                    GetById();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void LocationsMenu()
    {
        Location location = new Location();
        VLocation vLocation = new VLocation();
        CLocation cLocation = new CLocation(location, vLocation);

        bool isTrue = true;
        do
        {
            int choice = vLocation.Menu();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Insert();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    break;
                case "4":
                    GetById();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void DepartementsMenu()
    {
        Departement departement = new Departement();
        VDepartement vDepartement = new VDepartement();
        CDepartement cDepartement = new CDepartement(departement, vDepartement);

        bool isTrue = true;
        do
        {
            int choice = vDepartement.Menu();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Insert();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    break;
                case "4":
                    GetById();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void JobsMenu()
    {
        Job job = new Job();
        VJob vJob = new VJob();
        CJob cJob = new CJob(job, vJob);

        bool isTrue = true;
        do
        {
            int choice = vJob.Menu();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Insert();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    break;
                case "4":
                    GetById();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void HistoriesMenu()
    {
        History history = new History();
        VHistory vHistory = new VHistory();
        CHistory cHistory = new CHistory(history, vHistory);

        bool isTrue = true;
        do
        {
            int choice = vHistory.Menu();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Insert();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    break;
                case "4":
                    GetById();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void EmployeesMenu()
    {
        Employee employee = new Employee();
        VEmployee vEmployee = new VEmployee();
        CEmployee cEmployee = new CEmployee(employee, vEmployee);

        bool isTrue = true;
        do
        {
            int choice = vEmployee.Menu();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Insert();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    break;
                case "4":
                    GetById();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

}
