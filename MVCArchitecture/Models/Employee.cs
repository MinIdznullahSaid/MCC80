using MVCArchitecture;
using MVCArchitecture.Controllers;
using MVCArchitecture.Views;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;

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

       public int Insert(Employee employee)
       {
           var connection = Connection.Get();

           using SqlCommand sqlCommand = new SqlCommand();
           sqlCommand.Connection = connection;
           sqlCommand.CommandText = "INSERT INTO tbl_employees VALUES (@id, @firstname, @lastname, @email, @phone, @hiredate, @salary, @comission, @managerid, @jobid, @departementid)";

           connection.Open();
           using SqlTransaction transaction = connection.BeginTransaction();
           sqlCommand.Transaction = transaction;

           try
           {

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = employee.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@firstname";
            pFirstName.SqlDbType = System.Data.SqlDbType.VarChar;
            pFirstName.Value = employee.FirstName;
            sqlCommand.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "@lastname";
            pLastName.SqlDbType = System.Data.SqlDbType.VarChar;
            pLastName.Value = employee.LastName;
            sqlCommand.Parameters.Add(pLastName);

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = System.Data.SqlDbType.VarChar;
            pEmail.Value = employee.Email;
            sqlCommand.Parameters.Add(pEmail);

            SqlParameter pPhoneNumber = new SqlParameter();
            pPhoneNumber.ParameterName = "@phone";
            pPhoneNumber.SqlDbType = System.Data.SqlDbType.VarChar;
            pPhoneNumber.Value = employee.PhoneNumber;
            sqlCommand.Parameters.Add(pPhoneNumber);

            SqlParameter pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hiredate";
            pHireDate.SqlDbType = System.Data.SqlDbType.DateTime;
            pHireDate.Value = employee.HireDate;
            sqlCommand.Parameters.Add(pHireDate);

            SqlParameter pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.SqlDbType = System.Data.SqlDbType.Int;
            pSalary.Value = employee.Salary;
            sqlCommand.Parameters.Add(pSalary);

            SqlParameter pComission = new SqlParameter();
            pComission.ParameterName = "@comission";
            pComission.SqlDbType = System.Data.SqlDbType.Decimal;
            pComission.Value = employee.Comission;
            sqlCommand.Parameters.Add(pComission);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@managerid";
            pManagerId.SqlDbType = System.Data.SqlDbType.Int;
            pManagerId.Value = employee.ManagerId;
            sqlCommand.Parameters.Add(pManagerId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@jobid";
            pJobId.SqlDbType = System.Data.SqlDbType.Char;
            pJobId.Value = employee.JobId;
            sqlCommand.Parameters.Add(pJobId);

            SqlParameter pDepartementId = new SqlParameter();
            pDepartementId.ParameterName = "@departementid";
            pDepartementId.SqlDbType = System.Data.SqlDbType.Int;
            pDepartementId.Value = employee.DepartementId;
            sqlCommand.Parameters.Add(pDepartementId);

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

       public int Update(Employee employee)
       {
           var connection = Connection.Get();

           SqlCommand sqlCommand = new SqlCommand();
           sqlCommand.Connection = connection;
           sqlCommand.CommandText = "UPDATE tbl_employees SET first_name = (@firstname), last_name = (@lastname), email = (@email), phone_number = (@phone), hire_date = (@hiredate), salary = (@salary), comission_pct = (@comission), manager_id = (@managerid), job_id = (@jobid), departement_id = (@departementid) WHERE id = (@id)";

           connection.Open();
           SqlTransaction transaction = connection.BeginTransaction();
           sqlCommand.Transaction = transaction;
           try
           {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = employee.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@firstname";
            pFirstName.SqlDbType = System.Data.SqlDbType.VarChar;
            pFirstName.Value = employee.FirstName;
            sqlCommand.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "@lastname";
            pLastName.SqlDbType = System.Data.SqlDbType.VarChar;
            pLastName.Value = employee.LastName;
            sqlCommand.Parameters.Add(pLastName);

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = System.Data.SqlDbType.VarChar;
            pEmail.Value = employee.Email;
            sqlCommand.Parameters.Add(pEmail);

            SqlParameter pPhoneNumber = new SqlParameter();
            pPhoneNumber.ParameterName = "@phone";
            pPhoneNumber.SqlDbType = System.Data.SqlDbType.VarChar;
            pPhoneNumber.Value = employee.PhoneNumber;
            sqlCommand.Parameters.Add(pPhoneNumber);

            SqlParameter pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hiredate";
            pHireDate.SqlDbType = System.Data.SqlDbType.DateTime;
            pHireDate.Value = employee.HireDate;
            sqlCommand.Parameters.Add(pHireDate);

            SqlParameter pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.SqlDbType = System.Data.SqlDbType.Int;
            pSalary.Value = employee.Salary;
            sqlCommand.Parameters.Add(pSalary);

            SqlParameter pComission = new SqlParameter();
            pComission.ParameterName = "@comission";
            pComission.SqlDbType = System.Data.SqlDbType.Decimal;
            pComission.Value = employee.Comission;
            sqlCommand.Parameters.Add(pComission);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@managerid";
            pManagerId.SqlDbType = System.Data.SqlDbType.Int;
            pManagerId.Value = employee.ManagerId;
            sqlCommand.Parameters.Add(pManagerId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@jobid";
            pJobId.SqlDbType = System.Data.SqlDbType.Char;
            pJobId.Value = employee.JobId;
            sqlCommand.Parameters.Add(pJobId);

            SqlParameter pDepartementId = new SqlParameter();
            pDepartementId.ParameterName = "@departementid";
            pDepartementId.SqlDbType = System.Data.SqlDbType.Int;
            pDepartementId.Value = employee.DepartementId;
            sqlCommand.Parameters.Add(pDepartementId);

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
           sqlCommand.CommandText = "DELETE FROM tbl_employees WHERE id = @id";

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
       }

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