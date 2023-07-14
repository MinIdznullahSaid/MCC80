using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System.Diagnostics.Metrics;

namespace MVCArchitecture.Views;

public class VLocation
{
    public void GetAll(List<Location> locations)
    {
        foreach (var location in locations)
        {
            GetById(location);
        }
    }

    public void GetById(Location location)
    {
        Console.WriteLine("Id: " + location.Id);
        Console.WriteLine("Street Addres: " + location.Address);
        Console.WriteLine("Postal Code: " + location.PostCode);
        Console.WriteLine("City: " + location.City);
        Console.WriteLine("State Province: " + location.Province);
        Console.WriteLine("Country Id: " + location.CountryId);
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
        Console.WriteLine("== Menu Location ==");
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

    public Location InsertMenu()
    {
        Console.WriteLine("Masukkan id location yang ingin ditambahkan: ");
        int Id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Street Address: ");
        string Address = Console.ReadLine();
        Console.WriteLine("Postal Code: ");
        string PostCode = Console.ReadLine();
        Console.WriteLine("City: ");
        string City = Console.ReadLine();
        Console.WriteLine("Province: ");
        string Province = Console.ReadLine();
        Console.WriteLine("Country Id: ");
        string CountryId = Console.ReadLine();

        return new Location
        {
            Id = Id,
            Address = Address,
            PostCode = PostCode,
            City = City,
            Province = Province,
            CountryId = CountryId
};
    }

    public Location UpdateMenu()
    {
        Console.WriteLine("Masukkan id location yang ingin diupdate: ");
        int Id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Street Address: ");
        string Address = Console.ReadLine();
        Console.WriteLine("Postal Code: ");
        string PostCode = Console.ReadLine();
        Console.WriteLine("City: ");
        string City = Console.ReadLine();
        Console.WriteLine("Province: ");
        string Province = Console.ReadLine();
        Console.WriteLine("Country Id: ");
        string CountryId = Console.ReadLine();


        return new Location
        {
            Id = Id,
            Address = Address,
            PostCode = PostCode,
            City = City,
            Province = Province,
            CountryId = CountryId
        };
    }

    public Location DeleteMenu()
    {
        Console.WriteLine("Masukkan Id location yang ingin dihapus: ");
        int id = Convert.ToInt32(Console.ReadLine());

        return new Location
        {
            Id = id,
        };
    }

    public Location GetByIdMenu(Location location)
    {
        Console.WriteLine("Masukkan Id region yang ingin ditampilkan: ");
        int id = Convert.ToInt32(Console.ReadLine());

        return new Location
        {
            Id = id,

        };

    }
}