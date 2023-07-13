using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Net;
using System.Numerics;


namespace DatabaseConnectivity;
public class Employees
{
    private static string _connectionString = "Data Source = WISNU-PC;Database = db_hrd;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Execute()
    {
        while (true)
        {
            Console.WriteLine("== Employees ==");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Get By Id");
            Console.WriteLine("5. Get All");
            Console.WriteLine("6. Back");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin ditambahkan:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("First Name:");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Last Name:");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("Email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Phone Number:");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Hire Date (yyyy-mm-dd):");
                    string hiredate = Console.ReadLine();
                    Console.WriteLine("Salary:");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Comisson:");
                    decimal comission = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Manager Id:");
                    int managerid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Job Id:");
                    string jobid = Console.ReadLine();
                    Console.WriteLine("Departement Id:");
                    int departementid = Convert.ToInt32(Console.ReadLine());
                    InsertEmployees(id, firstname, lastname, email, phone, hiredate, salary, comission, managerid, jobid, departementid);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin diupdate:");
                    int idUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("First Name:");
                    string fnameUpdate = Console.ReadLine();
                    Console.WriteLine("Last Name:");
                    string lnameUpdate = Console.ReadLine();
                    Console.WriteLine("Email:");
                    string emailUpdate = Console.ReadLine();
                    Console.WriteLine("Phone Number:");
                    string phoneUpdate = Console.ReadLine();
                    Console.WriteLine("Hire Date (yyyy-mm-dd):");
                    string hireUpdate = Console.ReadLine();
                    Console.WriteLine("Salary:");
                    int salUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Comisson:");
                    decimal comUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Manager Id:");
                    int manidUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Job Id:");
                    string jobidUpdate = Console.ReadLine();
                    Console.WriteLine("Departement Id:");
                    int depidUpdate = Convert.ToInt32(Console.ReadLine());
                    UpdateEmployees(idUpdate, fnameUpdate, lnameUpdate, emailUpdate, phoneUpdate, hireUpdate, salUpdate, comUpdate, manidUpdate, jobidUpdate, depidUpdate);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin dihapus:");
                    int idDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteEmployees(idDelete);
                    break;
                case "4":
                    Console.WriteLine("Masukkan Id Data yang ingin ditampilkan:");
                    int idGet = Convert.ToInt32(Console.ReadLine());
                    GetByIdEmployees(idGet);
                    break;
                case "5":
                    GetEmployees();
                    break;
                case "6":
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Input tidak valid");
                    break;
            }

            Console.WriteLine();
        }
    }

    // GET ALL EMPLOYEES
    public static void GetEmployees()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_employees";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("First Name: " + reader.GetString(1));
                    Console.WriteLine("Last Name: " + reader.GetString(2));
                    Console.WriteLine("Email: " + reader.GetString(3));
                    Console.WriteLine("Phone Number: " + reader.GetString(4));
                    Console.WriteLine("Hire Date: " + reader.GetDateTime(5));
                    Console.WriteLine("Salary: " + reader.GetInt32(6));
                    Console.WriteLine("Comission: " + reader.GetDecimal(7));
                    Console.WriteLine("Manager Id: " + reader.GetInt32(8));
                    Console.WriteLine("Job Id: " + reader.GetString(9));
                    Console.WriteLine("Departement Id: " + reader.GetInt32(10));
                }
            }
            else
            {
                Console.WriteLine("No regions found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }

    // INSERT EMPLOYEE
    public static void InsertEmployees(int id, string firstname, string lastname, string email, string phone, string hiredate, int salary, decimal comission, int managerid, string jobid, int departementid)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO tbl_employees VALUES (@id, @firstname, @lastname, @email, @phone, @hiredate, @salary, @comission, @managerid, @jobid, @departementid)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@firstname";
            pFirstName.SqlDbType = SqlDbType.VarChar;
            pFirstName.Value = firstname;
            sqlCommand.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "@lastname";
            pLastName.SqlDbType = SqlDbType.VarChar;
            pLastName.Value = lastname;
            sqlCommand.Parameters.Add(pLastName);

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = SqlDbType.VarChar;
            pEmail.Value = email;
            sqlCommand.Parameters.Add(pEmail);

            SqlParameter pPhone = new SqlParameter();
            pPhone.ParameterName = "@phone";
            pPhone.SqlDbType = SqlDbType.VarChar;
            pPhone.Value = phone;
            sqlCommand.Parameters.Add(pPhone);

            SqlParameter pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hiredate";
            pHireDate.SqlDbType = SqlDbType.DateTime;
            pHireDate.Value = hiredate;
            sqlCommand.Parameters.Add(pHireDate);

            SqlParameter pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.SqlDbType = SqlDbType.Int;
            pSalary.Value = salary;
            sqlCommand.Parameters.Add(pSalary);

            SqlParameter pComission = new SqlParameter();
            pComission.ParameterName = "@comission";
            pComission.SqlDbType = SqlDbType.Decimal;
            pComission.Value = comission;
            sqlCommand.Parameters.Add(pComission);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@managerid";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = managerid;
            sqlCommand.Parameters.Add(pManagerId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@jobid";
            pJobId.SqlDbType = SqlDbType.Char;
            pJobId.Value = jobid;
            sqlCommand.Parameters.Add(pJobId);

            SqlParameter pDepartementId = new SqlParameter();
            pDepartementId.ParameterName = "@departementid";
            pDepartementId.SqlDbType = SqlDbType.Int;
            pDepartementId.Value = departementid;
            sqlCommand.Parameters.Add(pDepartementId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }

    // UPDATE EMPLOYEE
    public static void UpdateEmployees(int idUpdate, string fnameUpdate, string lnameUpdate, string emailUpdate, string phoneUpdate, string hireUpdate, int salUpdate, decimal comUpdate, int manidUpdate, string jobidUpdate, int depidUpdate)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE tbl_employees SET first_name = (@fnameUpdate), last_name = (@lnameUpdate), email = (@emailUpdate), phone_number = (@phoneUpdate), hire_date = (@hireUpdate), salary = (@salUpdate), comission_pct = (@comUpdate), manager_id = (@manidUpdate), job_id = (@jobidUpdate), departement_id = (@depidUpdate) WHERE id = (@idUpdate)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pIdUpdate = new SqlParameter();
            pIdUpdate.ParameterName = "@idUpdate";
            pIdUpdate.SqlDbType = SqlDbType.Int;
            pIdUpdate.Value = idUpdate;
            sqlCommand.Parameters.Add(pIdUpdate);

            SqlParameter pFnameUpdate = new SqlParameter();
            pFnameUpdate.ParameterName = "@fnameUpdate";
            pFnameUpdate.SqlDbType = SqlDbType.VarChar;
            pFnameUpdate.Value = fnameUpdate;
            sqlCommand.Parameters.Add(pFnameUpdate);

            SqlParameter pLnameUpdate = new SqlParameter();
            pLnameUpdate.ParameterName = "@lnameUpdate";
            pLnameUpdate.SqlDbType = SqlDbType.VarChar;
            pLnameUpdate.Value = lnameUpdate;
            sqlCommand.Parameters.Add(pLnameUpdate);

            SqlParameter pEmailUpdate = new SqlParameter();
            pEmailUpdate.ParameterName = "@emailUpdate";
            pEmailUpdate.SqlDbType = SqlDbType.VarChar;
            pEmailUpdate.Value = emailUpdate;
            sqlCommand.Parameters.Add(pEmailUpdate);

            SqlParameter pPhoneUpdate = new SqlParameter();
            pPhoneUpdate.ParameterName = "@phoneUpdate";
            pPhoneUpdate.SqlDbType = SqlDbType.VarChar;
            pPhoneUpdate.Value = phoneUpdate;
            sqlCommand.Parameters.Add(pPhoneUpdate);

            SqlParameter pHireUpdate = new SqlParameter();
            pHireUpdate.ParameterName = "@hireUpdate";
            pHireUpdate.SqlDbType = SqlDbType.DateTime;
            pHireUpdate.Value = hireUpdate;
            sqlCommand.Parameters.Add(pHireUpdate);

            SqlParameter pSalUpdate = new SqlParameter();
            pSalUpdate.ParameterName = "@salUpdate";
            pSalUpdate.SqlDbType = SqlDbType.Int;
            pSalUpdate.Value = salUpdate;
            sqlCommand.Parameters.Add(pSalUpdate);

            SqlParameter pComUpdate = new SqlParameter();
            pComUpdate.ParameterName = "@comUpdate";
            pComUpdate.SqlDbType = SqlDbType.Decimal;
            pComUpdate.Value = comUpdate;
            sqlCommand.Parameters.Add(pComUpdate);

            SqlParameter pManIdUpdate = new SqlParameter();
            pManIdUpdate.ParameterName = "@manidUpdate";
            pManIdUpdate.SqlDbType = SqlDbType.Int;
            pManIdUpdate.Value = manidUpdate;
            sqlCommand.Parameters.Add(pManIdUpdate);

            SqlParameter pJobIdUpdate = new SqlParameter();
            pJobIdUpdate.ParameterName = "@jobidUpdate";
            pJobIdUpdate.SqlDbType = SqlDbType.Char;
            pJobIdUpdate.Value = jobidUpdate;
            sqlCommand.Parameters.Add(pJobIdUpdate);

            SqlParameter pDepIdUpdate = new SqlParameter();
            pDepIdUpdate.ParameterName = "@depidUpdate";
            pDepIdUpdate.SqlDbType = SqlDbType.Int;
            pDepIdUpdate.Value = depidUpdate;
            sqlCommand.Parameters.Add(pDepIdUpdate);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }

    // DELETE EMPLOYEE
    public static void DeleteEmployees(int idDelete)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM tbl_employees WHERE id = (@idDelete)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pIdDelete = new SqlParameter();
            pIdDelete.ParameterName = "@idDelete";
            pIdDelete.SqlDbType = SqlDbType.Int;
            pIdDelete.Value = idDelete;
            sqlCommand.Parameters.Add(pIdDelete);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }

    // GET BY ID
    public static void GetByIdEmployees(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_employees WHERE id = (@id)";

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("First Name: " + reader.GetString(1));
                    Console.WriteLine("Last Name: " + reader.GetString(2));
                    Console.WriteLine("Email: " + reader.GetString(3));
                    Console.WriteLine("Phone Number: " + reader.GetString(4));
                    Console.WriteLine("Hire Date: " + reader.GetDateTime(5));
                    Console.WriteLine("Salary: " + reader.GetInt32(6));
                    Console.WriteLine("Comission: " + reader.GetDecimal(7));
                    Console.WriteLine("Manager Id: " + reader.GetInt32(8));
                    Console.WriteLine("Job Id: " + reader.GetString(9));
                    Console.WriteLine("Departement Id: " + reader.GetInt32(10));
                }
            }
            else
            {
                Console.WriteLine("No Employee found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }
}

