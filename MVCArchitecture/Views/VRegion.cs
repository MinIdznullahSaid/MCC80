using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VRegion
{
    public void GetAll(List<Region> regions)
    {
        foreach (var region in regions)
        {
            GetById(region);
        }
    }

    public void GetById(Region region)
    {
        Console.WriteLine("Id: " + region.Id);
        Console.WriteLine("Name: " + region.Name);
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
        Console.WriteLine("Fail, Id not found!");
    }

    public void Error()
    {
        Console.WriteLine("Error retrieving from database!");
    }

    public int Menu()
    {
        Console.WriteLine("== Menu Region ==");
        Console.WriteLine("1. Tambah");
        Console.WriteLine("2. Update");
        Console.WriteLine("3. Hapus");
        Console.WriteLine("4. Get By Id");
        Console.WriteLine("5. Get All");
        Console.WriteLine("6. Back");
        Console.WriteLine("Enter your choice (1-6): ");

        int input = Int32.Parse(Console.ReadLine());
        return input;
    }

    public Region InsertMenu()
    {
        Console.WriteLine("Masukan nama region yang ingin ditambahkan: ");
        string? inputName = Console.ReadLine();

        return new Region
        {
            Id = 0,
            Name = inputName
        };
    }

    public Region UpdateMenu()
    {
        Console.WriteLine("Id region yang ingin diupdate: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Masukkan update nama region: ");
        string name = Console.ReadLine();

        return new Region
        {
            Id = id,
            Name = name
        };
    }
}