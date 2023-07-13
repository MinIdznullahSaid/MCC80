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
        bool ulang = true;
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

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {
 /*                   case 1:
                        Console.Clear();
                        EmployeeMenu();
                        break;
                    case 2:
                        Console.Clear();
                        DepartementMenu();
                        break;
                    case 3:
                        Console.Clear();
                        JobMenu();
                        break;
                    case 4:
                        Console.Clear();
                        CountryMenu();
                        break;
*/                    case 5:
                        Console.Clear();
                        RegionMenu();
                        break;
 /*                    case 6:
                        Console.Clear();
                        LocationMenu();
                        break;
                    case 7:
                        Console.Clear();
                        HistoryMenu();
                        break;
*/                    case 8:
                        ulang = false;
                        break;
                    default:
                        Console.WriteLine("Enter your choice (1-8): ");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Enter your choice (1-8): ");
            }
        } while (ulang);
    }

    private static void RegionMenu()
    {
        Region region = new Region();
        VRegion vRegion = new VRegion();
        CRegion cRegion = new CRegion(region, vRegion);

        bool isTrue = true;
        do
        {
            int pilihMenu = vRegion.Menu();
            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    cRegion.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    Console.Clear();
                    cRegion.Update();
                    PressAnyKey();
                    break;
/*                case 3:
                    Console.Clear();
                    cRegion.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    cRegion.GetById();
                    PressAnyKey();
                    break;
*/                case 5:
                    cRegion.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

 /*   private static void CountryMenu()
    {
        Country country = new Country();
        VCountry vCountry = new VCountry();
        CCountry cCountry = new CCountry(country, vCountry);

        bool isTrue = true;
        do
        {
            int pilihMenu = vCountry.Menu();
            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    cCountry.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    Console.Clear();
                    cCountry.Update();
                    PressAnyKey();
                    break;
                case 3:
                    Console.Clear();
                    cCountry.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    cCountry.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    cCountry.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void LocationMenu()
    {
        Location location = new Location();
        VLocation vLocation = new VLocation();
        CLocation cLocation = new CLocation(location, vLocation);

        bool isTrue = true;
        do
        {
            int pilihMenu = vLocation.Menu();
            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    cLocation.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    Console.Clear();
                    cLocation.Update();
                    PressAnyKey();
                    break;
                case 3:
                    Console.Clear();
                    cLocation.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    cLocation.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    cLocation.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void DepartementMenu()
    {
        Departement departement = new Departement();
        VDepartement vDepartement = new VDepartement();
        CDepartement cDepartement = new CDepartement(departement, vDepartement);

        bool isTrue = true;
        do
        {
            int pilihMenu = vDepartement.Menu();
            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    cDepartement.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    Console.Clear();
                    cDepartement.Update();
                    PressAnyKey();
                    break;
                case 3:
                    Console.Clear();
                    cDepartement.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    cDepartement.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    cDepartement.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void JobMenu()
    {
        Job job = new Job();
        VJob vJob = new VJob();
        CJob cJob = new CJob(job, vJob);

        bool isTrue = true;
        do
        {
            int pilihMenu = vJob.Menu();
            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    cJob.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    Console.Clear();
                    cJob.Update();
                    PressAnyKey();
                    break;
                case 3:
                    Console.Clear();
                    cJob.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    cJob.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    cJob.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void HistoryMenu()
    {
        History history = new History();
        VHistory vHistory = new VHistory();
        CHistory cHistory = new CHistory(history, vHistory);

        bool isTrue = true;
        do
        {
            int pilihMenu = vHistory.Menu();
            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    cHistory.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    Console.Clear();
                    cHistory.Update();
                    PressAnyKey();
                    break;
                case 3:
                    Console.Clear();
                    cHistory.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    cHistory.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    cHistory.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void EmployeeMenu()
    {
        Employee employee = new Employee();
        VEmployee vEmployee = new VEmployee();
        CEmployee cEmployee = new CEmployee(employee, vEmployee);

        bool isTrue = true;
        do
        {
            int pilihMenu = vEmployee.Menu();
            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    cEmployee.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    Console.Clear();
                    cEmployee.Update();
                    PressAnyKey();
                    break;
                case 3:
                    Console.Clear();
                    cEmployee.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    cEmployee.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    cEmployee.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }
*/
    private static void InvalidInput()
    {
        Console.WriteLine("Your input is not valid!");
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
