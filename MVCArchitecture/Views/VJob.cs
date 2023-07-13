using MVCArchitecture.Controllers;
using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VJob
{
    public void GetAll(List<Job> jobs)
    {
        foreach (var job in jobs)
        {
            GetById(job);
        }
    }

    public void GetById(Job job)
    {
        Console.WriteLine("Id: " + job.Id);
        Console.WriteLine("Title: " + job.Title);
        Console.WriteLine("Min Salary: " + job.MinSalary);
        Console.WriteLine("Max Salary: " + job.MaxSalary);
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

    public int Menu()
    {
        Console.WriteLine("== Menu Job ==");
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

    public Job InsertMenu()
    {
        Console.WriteLine("Masukkan id job yang ingin ditambahkan: ");
        string inputId = Console.ReadLine();
        Console.WriteLine("Masukkan title job yang ingin ditambahkan: ");
        string inputTitle = Console.ReadLine();
        Console.WriteLine("Masukkan min salary yang ingin ditambahkan: ");
        int inputMinSalary = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Masukkan max salary yang ingin ditambahkan: ");
        int inputMaxSalary = Int32.Parse(Console.ReadLine());

        return new Job
        {
            Id = inputId,
            Title = inputTitle,
            MinSalary = inputMinSalary,
            MaxSalary = inputMaxSalary
        };
    }

    public Job UpdateMenu()
    {
        Console.WriteLine("Masukkan id job yang ingin diupdate: ");
        string inputId = Console.ReadLine();
        Console.WriteLine("Masukkan update title job: ");
        string inputTitle = Console.ReadLine();
        Console.WriteLine("Masukkan update min salary: ");
        int inputMinSalary = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Masukkan update max salary: ");
        int inputMaxSalary = Int32.Parse(Console.ReadLine());


        return new Job
        {
            Id = inputId,
            Title = inputTitle,
            MinSalary = inputMinSalary,
            MaxSalary = inputMaxSalary
        };
    }

    public Job DeleteMenu()
    {
        Console.WriteLine("Masukkan Id job yang ingin dihapus: ");
        string id = Console.ReadLine();

        return new Job
        {
            Id = id,
        };
    }

    public Job GetByIdMenu(Job job)
    {
        Console.WriteLine("Masukkan Id country yang ingin ditampilkan: ");
        string id = Console.ReadLine();

        return new Job
        {
            Id = id,

        };

    }
}