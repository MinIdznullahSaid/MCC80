using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System.Globalization;

namespace MVCArchitecture.Views;

public class VHistory
{
    public int Menu()
    {
        Console.WriteLine("== Menu History ==");
        Console.WriteLine("1. Insert");
        Console.WriteLine("2. Update");
        Console.WriteLine("3. Delete");
        Console.WriteLine("4. Get By Id");
        Console.WriteLine("5. Get All");
        Console.WriteLine("6. Back");
        Console.WriteLine("Enter your choice (1-6): ");

        int input = Int32.Parse(Console.ReadLine());
        return input;
    }
    public void GetAll(List<History> histories)
    {
        foreach (var history in histories)
        {
            GetById(history);
        }
    }

    public void GetById(History history)
    {
        Console.WriteLine("Start Date: " + history.StartDate);
        Console.WriteLine("Employee Id: " + history.EmployeeId);
        Console.WriteLine("End Date Id: " + history.EndDate);
        Console.WriteLine("Departement Id: " + history.DepartementId);
        Console.WriteLine("Job Id: " + history.JobId);
        Console.WriteLine("==========================");
    }

    public void DataEmpty()
    {
        Console.WriteLine("Data Not Found!");
    }

    public void Success()
    {
        Console.WriteLine("Success!");
    }

    public void Failure()
    {
        Console.WriteLine("Failed, Id not found!");
    }

    public void Error()
    {
        Console.WriteLine("Error retrieving from database!");
    }

    public History InsertMenu()
    {
        Console.WriteLine("Masukkan start date yang ingin ditambahkan (yyyy-mm-dd): ");
        string startDate = Console.ReadLine();

        DateTime startdate;

        if (DateTime.TryParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startdate))
        {
            Console.WriteLine("Input date: " + startdate.ToString());
        }
        else
        {
            Console.WriteLine("Wrong date format");
        }

        Console.WriteLine("Masukkan employee id yang ingin ditambahkan: ");
        int employeeId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("End date (yyyy-mm-dd): ");
        string endDate = Console.ReadLine();

        DateTime enddate;

        if (DateTime.TryParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out enddate))
        {
            Console.WriteLine("Input date: " + enddate.ToString());
        }
        else
        {
            Console.WriteLine("Wrong date format");
        }

        Console.WriteLine("Departement Id: ");
        int departementId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Job Id: ");
        string jobId = Console.ReadLine();

        return new History
        {
            StartDate = startdate,
            EmployeeId = employeeId,
            EndDate = enddate,
            DepartementId = departementId,
            JobId = jobId

        };
    }

    public History UpdateMenu()
    {
        Console.WriteLine("Masukkan start date yang ingin diupdate: ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Masukkan employee id yang ingin diupdate: ");
        int employeeId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("End date: ");
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Departement Id: ");
        int departementId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Job Id: ");
        string jobId = Console.ReadLine();


        return new History
        {
            StartDate = startDate,
            EmployeeId = employeeId,
            EndDate = endDate,
            DepartementId = departementId,
            JobId = jobId
        };
    }

    public History DeleteMenu()
    {
        Console.WriteLine("Masukkan Employee Id history yang ingin dihapus: ");
        int employeeid = Int32.Parse(Console.ReadLine());

        return new History
        {
            EmployeeId = employeeid,
        };
    }

    public History GetByIdMenu(History history)
    {
        Console.WriteLine("Masukkan Employee Id history yang ingin ditampilkan: ");
        int employeeid = Int32.Parse(Console.ReadLine());

        return new History
        {
            EmployeeId = employeeid,

        };

    }
}