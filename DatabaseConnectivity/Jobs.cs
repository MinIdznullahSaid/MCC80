using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using Microsoft.VisualBasic;
using System.Security.Cryptography;


namespace DatabaseConnectivity;
public class Jobs
{
    private static string _connectionString = "Data Source = WISNU-PC;Database = db_hrd;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Execute()
    {
        while (true)
        {
            Console.WriteLine("== Jobs ==");
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
                    Console.WriteLine("Masukkan nama pekerjaan yang ingin ditambahkan:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Masukkan min salary:");
                    int minSalary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Masukkan max salary:");
                    int maxSalary = Convert.ToInt32(Console.ReadLine());
                    InsertJobs(id, title, minSalary, maxSalary);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin diupdate:");
                    int idUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Masukkan update nama pekerjaan:");
                    string titleUpdate = Console.ReadLine();
                    Console.WriteLine("Masukkan update min salary:");
                    int minSalaryUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Masukkan update max salary:");
                    int maxSalaryUpdate = Convert.ToInt32(Console.ReadLine());
                    UpdateJobs(idUpdate, titleUpdate, minSalaryUpdate, maxSalaryUpdate);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin dihapus:");
                    int idDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteJobs(idDelete);
                    break;
                case "4":
                    Console.WriteLine("Masukkan Id Data yang ingin ditampilkan:");
                    int idGet = Convert.ToInt32(Console.ReadLine());
                    GetByIdJobs(idGet);
                    break;
                case "5":
                    GetJobs();
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

    // GET ALL REGION
    public static void GetJobs()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_jobs";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Title: " + reader.GetString(1));
                    Console.WriteLine("Min Salary: " + reader.GetInt32(2));
                    Console.WriteLine("Max Salary: " + reader.GetInt32(3));
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

    // INSERT JOB
    public static void InsertJobs(int id, string title, int minSalary, int maxSalary)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO tbl_jobs (id, title, min_salary, max_salary) VALUES (@id, @title, @minSalary, @maxSalary)";

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

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@title";
            pTitle.SqlDbType = SqlDbType.VarChar;
            pTitle.Value = title;
            sqlCommand.Parameters.Add(pTitle);

            SqlParameter pMinSalary = new SqlParameter();
            pMinSalary.ParameterName = "@minSalary";
            pMinSalary.SqlDbType = SqlDbType.Int;
            pMinSalary.Value = minSalary;
            sqlCommand.Parameters.Add(pMinSalary);

            SqlParameter pMaxSalary = new SqlParameter();
            pMaxSalary.ParameterName = "@maxSalary";
            pMaxSalary.SqlDbType = SqlDbType.Int;
            pMaxSalary.Value = maxSalary;
            sqlCommand.Parameters.Add(pMaxSalary);

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

    // UPDATE JOB
    public static void UpdateJobs(int idUpdate, string titleUpdate, int minSalaryUpdate, int maxSalaryUpdate)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE tbl_jobs SET title = (@titleUpdate), min_salary = (@minSalaryUpdate), max_salary = (@maxSalaryUpdate) WHERE id = (@idUpdate)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pTitleUpdate = new SqlParameter();
            pTitleUpdate.ParameterName = "@titleUpdate";
            pTitleUpdate.SqlDbType = SqlDbType.VarChar;
            pTitleUpdate.Value = titleUpdate;
            sqlCommand.Parameters.Add(pTitleUpdate);

            SqlParameter pIdUpdate = new SqlParameter();
            pIdUpdate.ParameterName = "@idUpdate";
            pIdUpdate.SqlDbType = SqlDbType.Int;
            pIdUpdate.Value = idUpdate;
            sqlCommand.Parameters.Add(pIdUpdate);

            SqlParameter pMinSalaryUpdate = new SqlParameter();
            pMinSalaryUpdate.ParameterName = "@minSalaryUpdate";
            pMinSalaryUpdate.SqlDbType = SqlDbType.Int;
            pMinSalaryUpdate.Value = minSalaryUpdate;
            sqlCommand.Parameters.Add(pMinSalaryUpdate);

            SqlParameter pMaxSalaryUpdate = new SqlParameter();
            pMaxSalaryUpdate.ParameterName = "@maxSalaryUpdate";
            pMaxSalaryUpdate.SqlDbType = SqlDbType.Int;
            pMaxSalaryUpdate.Value = maxSalaryUpdate;
            sqlCommand.Parameters.Add(pMaxSalaryUpdate);

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

    // DELETE REGION
    public static void DeleteJobs(int idDelete)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM tbl_jobs WHERE id = (@idDelete)";

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
    public static void GetByIdJobs(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_jobs WHERE id = (@id)";

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
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Title: " + reader.GetString(1));
                    Console.WriteLine("Min Salary: " + reader.GetInt32(2));
                    Console.WriteLine("Max Salary: " + reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No jobs found.");
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

