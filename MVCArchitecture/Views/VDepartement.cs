using MVCArchitecture.Controllers;
using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VDepartement
{
    public int Menu()
    {
        Console.WriteLine("== Menu Departement ==");
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
    public void GetAll(List<Departement> departements)
    {
        foreach (var departement in departements)
        {
            GetById(departement);
        }
    }

    public void GetById(Departement departement)
    {
        Console.WriteLine("Id: " + departement.Id);
        Console.WriteLine("Name: " + departement.Name);
        Console.WriteLine("Location Id: " + departement.LocationId);
        Console.WriteLine("Manager Id: " + departement.ManagerId);
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

    public Departement InsertMenu()
    {
        Console.WriteLine("Masukkan id departement yang ingin ditambahkan: ");
        int inputId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Nama Departement: ");
        string inputName = Console.ReadLine();
        Console.WriteLine("Location Id: ");
        int inputLocationId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Manager Id: ");
        int inputManagerId = Int32.Parse(Console.ReadLine());

        return new Departement
        {
            Id = inputId,
            Name = inputName,
            LocationId = inputLocationId,
            ManagerId = inputManagerId
        };
    }

    public Departement UpdateMenu()
    {
        Console.WriteLine("Masukkan id departement yang ingin ditambahkan: ");
        int inputId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Nama Departement: ");
        string inputName = Console.ReadLine();
        Console.WriteLine("Location Id: ");
        int inputLocationId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Manager Id: ");
        int inputManagerId = Int32.Parse(Console.ReadLine());


        return new Departement
        {
            Id = inputId,
            Name = inputName,
            LocationId = inputLocationId,
            ManagerId = inputManagerId
        };
    }

    public Departement DeleteMenu()
    {
        Console.WriteLine("Masukkan Id departement yang ingin dihapus: ");
        int id = Int32.Parse(Console.ReadLine());

        return new Departement
        {
            Id = id,
        };
    }

    public Departement GetByIdMenu(Departement departement)
    {
        Console.WriteLine("Masukkan Id country yang ingin ditampilkan: ");
        int id = Int32.Parse(Console.ReadLine());

        return new Departement
        {
            Id = id,

        };

    }
}