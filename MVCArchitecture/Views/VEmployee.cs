﻿using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System.Globalization;

namespace MVCArchitecture.Views;

public class VEmployee
{
    public int Menu()
    {
        Console.WriteLine("== Menu Employee ==");
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
    public void GetAll(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            GetById(employee);
        }
    }

    public void GetById(Employee employee)
    {
        Console.WriteLine("Id: " + employee.Id);
        Console.WriteLine("First Name: " + employee.FirstName);
        Console.WriteLine("Last Name: " + employee.LastName);
        Console.WriteLine("Email: " + employee.Email);
        Console.WriteLine("Phone Number: " + employee.PhoneNumber);
        Console.WriteLine("Hire Date: " + employee.HireDate);
        Console.WriteLine("Salary: " + employee.Salary);
        Console.WriteLine("Comission: " + employee.Comission);
        Console.WriteLine("Manager Id: " + employee.ManagerId);
        Console.WriteLine("Job Id: " + employee.JobId);
        Console.WriteLine("Departement Id: " + employee.DepartementId);
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

    public Employee InsertMenu()
    {
        Console.WriteLine("Masukkan id employee yang ingin ditambahkan: ");
        int id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("First Name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Last Name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Phone Number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Hire Date: ");
        string hireDate = Console.ReadLine();

        DateTime date;

        if (DateTime.TryParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            Console.WriteLine("Input date: " + date.ToString());
        }
        else
        {
            Console.WriteLine("Wrong date format");
        }

        Console.WriteLine("Salary: ");
        int salary = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Comission: ");
        decimal comission = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Manager Id: ");
        int managerId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Job Id: ");
        string jobId = Console.ReadLine();
        Console.WriteLine("Departement Id: ");
        int departementId = Int32.Parse(Console.ReadLine()); ;

        return new Employee
        {   
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phone,
            HireDate = date,
            Salary = salary,
            Comission = comission,
            ManagerId = managerId,
            JobId = jobId,
            DepartementId = departementId
        };
    }

    public Employee UpdateMenu()
    {
        Console.WriteLine("Masukkan id employee yang ingin diupdate: ");
        int id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("First Name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Last Name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Phone Number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Hire Date (yyyy-mm-dd): ");
        string hireDate = Console.ReadLine();

        DateTime date;

        if (DateTime.TryParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            Console.WriteLine("Input date: " + date.ToString());
        }
        else
        {
            Console.WriteLine("Wrong date format");
        }

        Console.WriteLine("Salary: ");
        int salary = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Comission: ");
        decimal comission = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Manager Id: ");
        int managerId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Job Id: ");
        string jobId = Console.ReadLine();
        Console.WriteLine("Departement Id: ");
        int departementId = Int32.Parse(Console.ReadLine());


        return new Employee
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phone,
            HireDate = date,
            Salary = salary,
            Comission = comission,
            ManagerId = managerId,
            JobId = jobId,
            DepartementId = departementId
        };
    }

    public Employee DeleteMenu()
    {
        Console.WriteLine("Masukkan Id departement yang ingin dihapus: ");
        int id = Int32.Parse(Console.ReadLine());

        return new Employee
        {
            Id = id,
        };
    }

    public Employee GetByIdMenu(Employee employee)
    {
        Console.WriteLine("Masukkan Id country yang ingin ditampilkan: ");
        int id = Int32.Parse(Console.ReadLine());

        return new Employee
        {
            Id = id,

        };

    }
}