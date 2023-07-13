using MVCArchitecture.Controllers;
using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VCountry
{
    public void GetAll(List<Country> countries)
    {
        foreach (var country in countries)
        {
            GetById(country);
        }
    }

    public void GetById(Country country)
    {
        Console.WriteLine("Id: " + country.Id);
        Console.WriteLine("Name: " + country.Name);
        Console.WriteLine("Region Id: " + country.RegionId);
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
        Console.WriteLine("== Menu Country ==");
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

    public Country InsertMenu()
    {
        Console.WriteLine("Masukkan id country yang ingin ditambahkan: ");
        string inputId = Console.ReadLine();
        Console.WriteLine("Masukkan nama country yang ingin ditambahkan: ");
        string inputName = Console.ReadLine();
        Console.WriteLine("Masukkan region id yang ingin ditambahkan: ");
        int inputRegionId = Int32.Parse(Console.ReadLine());

        return new Country
        {
            Id = inputId,
            Name = inputName,
            RegionId = inputRegionId
        };
    }

    public Country UpdateMenu()
    {
        Console.WriteLine("Masukkan id country yang ingin diupdate: ");
        string inputId = Console.ReadLine();
        Console.WriteLine("Masukkan update nama country: ");
        string inputName = Console.ReadLine();
        Console.WriteLine("Masukkan update region id: ");
        int inputRegionId = Int32.Parse(Console.ReadLine());


        return new Country
        {
            Id = inputId,
            Name = inputName,
            RegionId = inputRegionId
        };
    }

    public Country DeleteMenu()
    {
        Console.WriteLine("Masukkan Id country yang ingin dihapus: ");
        string id = Console.ReadLine();

        return new Country
        {
            Id = id,
        };
    }

    public Country GetByIdMenu(Country country)
    {
        Console.WriteLine("Masukkan Id country yang ingin ditampilkan: ");
        string id = Console.ReadLine();

        return new Country
        {
            Id = id,

        };

    }
}