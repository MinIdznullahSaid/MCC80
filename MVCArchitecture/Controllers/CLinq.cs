using MVCArchitecture.Models;

namespace MVCArchitecture.Controllers;

public class CLinq
{
    private Employee _employee;
    private Departement _departement;
    private Location _location;
    private Country _country;
    private Region _region;

    public CLinq(Employee employee, Departement departement, Location location, Country country, Region region)
    {
        _employee = employee;
        _departement = departement;
        _location = location;
        _country = country;
        _region = region;
        
    }
    public void DetailEmployee()
    {
        var getRegion = _region.GetAll();
        var getCountry = _country.GetAll();
        var getLocation = _location.GetAll();
        var getEmployee = _employee.GetAll();
        var getDepartement = _departement.GetAll(); 


        var detailEmployee = (from e in getEmployee
                              join d in getDepartement on e.ManagerId equals d.ManagerId
                              join l in getLocation on d.LocationId equals l.Id
                              join c in getCountry on l.CountryId equals c.Id
                              join r in getRegion on c.RegionId equals r.Id
                              select new
                              {
                                    Id = e.Id,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Email = e.Email,
                                    Phone = e.PhoneNumber,
                                    Salary = e.Salary,
                                    DepartementName = d.Name,
                                    StreetAddress = l.Address,
                                    CountryName = c.Name,
                                    RegionName = r.Name
                              }
                              ).ToList();

        foreach (var employee in detailEmployee)
        {
            Console.WriteLine("Id: " + employee.Id);
            Console.WriteLine("Full Name: " + employee.FirstName + " " + employee.LastName);
            Console.WriteLine("Email: " + employee.Email);
            Console.WriteLine("Phone Number: " + employee.Phone);
            Console.WriteLine("Salary: " + employee.Salary);
            Console.WriteLine("Departement Name: " + employee.DepartementName);
            Console.WriteLine("Street Address: " + employee.StreetAddress);
            Console.WriteLine("Country Name: " + employee.CountryName);
            Console.WriteLine("Region Name: " + employee.RegionName);
            Console.WriteLine("===========================================================");
        }
    }
}