using MVCArchitecture;
using MVCArchitecture.Controllers;
using MVCArchitecture.Views;
using System.Data.SqlClient;

namespace MVCArchitecture.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
    public decimal Comission { get; set; }
    public int ManagerId { get; set; }
    public string JobId { get; set; }
    public int DepartementId { get; set; }

    public List<Employee> GetAll()
    {
        var connection = Connection.Get();

        var employees = new List<Employee>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_employees";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.PhoneNumber = reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    employee.Salary = reader.GetInt32(6);
                    employee.Comission = reader.GetDecimal(7);
                    employee.ManagerId = reader.GetInt32(8);
                    employee.JobId = reader.GetString(9);
                    employee.DepartementId = reader.GetInt32(10);

                    employees.Add(employee);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return employees;
        }
        catch
        {
            return new List<Employee>();
        }
    }

    /*   public int Insert(Departement departement)
       {
           var connection = Connection.Get();

           using SqlCommand sqlCommand = new SqlCommand();
           sqlCommand.Connection = connection;
           sqlCommand.CommandText = "INSERT INTO tbl_departements VALUES (@id, @name, @locationid, @managerid)";

           connection.Open();
           using SqlTransaction transaction = connection.BeginTransaction();
           sqlCommand.Transaction = transaction;

           try
           {
               SqlParameter pId = new SqlParameter();
               pId.ParameterName = "@id";
               pId.SqlDbType = System.Data.SqlDbType.Int;
               pId.Value = departement.Id;
               sqlCommand.Parameters.Add(pId);

               SqlParameter pName = new SqlParameter();
               pName.ParameterName = "@name";
               pName.SqlDbType = System.Data.SqlDbType.VarChar;
               pName.Value = departement.Name;
               sqlCommand.Parameters.Add(pName);

               SqlParameter pLocationId = new SqlParameter();
               pLocationId.ParameterName = "@locationid";
               pLocationId.SqlDbType = System.Data.SqlDbType.Int;
               pLocationId.Value = departement.LocationId;
               sqlCommand.Parameters.Add(pLocationId);

               SqlParameter pManagerId = new SqlParameter();
               pManagerId.ParameterName = "@managerid";
               pManagerId.SqlDbType = System.Data.SqlDbType.Int;
               pManagerId.Value = departement.ManagerId;
               sqlCommand.Parameters.Add(pManagerId);

               int result = sqlCommand.ExecuteNonQuery();

               transaction.Commit();
               connection.Close();

               return result;
           }
           catch
           {
               transaction.Rollback();
               return -1;
           }
       }

       public int Update(Departement departement)
       {
           var connection = Connection.Get();

           SqlCommand sqlCommand = new SqlCommand();
           sqlCommand.Connection = connection;
           sqlCommand.CommandText = "INSERT INTO tbl_departements (id, name, location_id, manager_id) VALUES (@id, @name, @locationid, @managerid)";

           connection.Open();
           SqlTransaction transaction = connection.BeginTransaction();
           sqlCommand.Transaction = transaction;
           try
           {
               SqlParameter pId = new SqlParameter();
               pId.ParameterName = "@id";
               pId.SqlDbType = System.Data.SqlDbType.Int;
               pId.Value = departement.Id;
               sqlCommand.Parameters.Add(pId);

               SqlParameter pName = new SqlParameter();
               pName.ParameterName = "@name";
               pName.SqlDbType = System.Data.SqlDbType.VarChar;
               pName.Value = departement.Name;
               sqlCommand.Parameters.Add(pName);

               SqlParameter pLocationId = new SqlParameter();
               pLocationId.ParameterName = "@locationid";
               pLocationId.SqlDbType = System.Data.SqlDbType.Int;
               pLocationId.Value = departement.LocationId;
               sqlCommand.Parameters.Add(pLocationId);

               SqlParameter pManagerId = new SqlParameter();
               pManagerId.ParameterName = "@managerid";
               pManagerId.SqlDbType = System.Data.SqlDbType.Int;
               pManagerId.Value = departement.ManagerId;
               sqlCommand.Parameters.Add(pManagerId);

               int result = sqlCommand.ExecuteNonQuery();

               transaction.Commit();
               connection.Close();

               return result;

           }
           catch
           {
               transaction.Rollback();
               return -1;
           }
       }

       public int Delete(int id)
       {
           var connection = Connection.Get();

           SqlCommand sqlCommand = new SqlCommand();
           sqlCommand.Connection = connection;
           sqlCommand.CommandText = "DELETE FROM tbl_departements WHERE id = @id";

           connection.Open();
           SqlTransaction transaction = connection.BeginTransaction();
           sqlCommand.Transaction = transaction;
           try
           {
               SqlParameter pId = new SqlParameter();
               pId.ParameterName = "@id";
               pId.SqlDbType = System.Data.SqlDbType.Int;
               pId.Value = id;
               sqlCommand.Parameters.Add(pId);

               int result = sqlCommand.ExecuteNonQuery();

               transaction.Commit();
               connection.Close();

               return result;
           }
           catch
           {
               transaction.Rollback();
               return -1;
           }
       }*/

    public Employee GetById(int id)
       {
           var employee = new Employee();

           var connection = Connection.Get();

           SqlCommand sqlCommand = new SqlCommand();
           sqlCommand.Connection = connection;
           sqlCommand.CommandText = "SELECT * FROM tbl_employees WHERE id = @id";
           sqlCommand.Parameters.AddWithValue("@id", id);

           try
           {
               connection.Open();
               SqlDataReader reader = sqlCommand.ExecuteReader();
               if (reader.HasRows)
               {
                   reader.Read();

                employee.Id = reader.GetInt32(0);
                employee.FirstName = reader.GetString(1);
                employee.LastName = reader.GetString(2);
                employee.Email = reader.GetString(3);
                employee.PhoneNumber = reader.GetString(4);
                employee.HireDate = reader.GetDateTime(5);
                employee.Salary = reader.GetInt32(6);
                employee.Comission = reader.GetDecimal(7);
                employee.ManagerId = reader.GetInt32(8);
                employee.JobId = reader.GetString(9);
                employee.DepartementId = reader.GetInt32(10);
            }

               reader.Close();
               connection.Close();

            return employee;
        }
        catch
        {
            return null;
        }
    }
}