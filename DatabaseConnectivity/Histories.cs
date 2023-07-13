using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Net;


namespace DatabaseConnectivity;
public class Histories
{
    private static string _connectionString = "Data Source = WISNU-PC;Database = db_hrd;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Execute()
    {
        while (true)
        {
            Console.WriteLine("== Histories ==");
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
                    Console.WriteLine("Masukkan tanggal masuk karyawan yang ingin ditambahkan (yyyy-mm-dd):");
                    string startdate = Console.ReadLine();
                    Console.WriteLine("Employee Id:");
                    int employeeid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("tanggal berakhirnya kontrak:");
                    string enddate = Console.ReadLine();
                    Console.WriteLine("Departement Id:");
                    int departementid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Job Id:");
                    string jobid = Console.ReadLine();
                    InsertHistories(startdate, employeeid, enddate, departementid, jobid);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Masukkan update tanggal masuk karyawan (yyyy-mm-dd):");
                    string startdateUpdate = Console.ReadLine();
                    Console.WriteLine("Employee Id:");
                    int employeeidUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Masukkan Update tanggal berakhirnya kontrak:");
                    string enddateUpdate = Console.ReadLine();
                    Console.WriteLine("Masukkan Update Departement Id:");
                    int departementidUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Masukkan Update Job Id:");
                    string jobidUpdate = Console.ReadLine();
                    UpdateHistories(startdateUpdate, employeeidUpdate, enddateUpdate, departementidUpdate, jobidUpdate);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Masukkan tanggal masuk karyawan (yyyy-mm-dd):");
                    string startdateDelete = Console.ReadLine();
                    Console.WriteLine("Masukkan Employee Id Data History yang ingin dihapus:");
                    int employeeidDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteHistories(startdateDelete, employeeidDelete);
                    break;
                case "4":
                    Console.WriteLine("Masukkan Employee Id Data History yang ingin ditampilkan:");
                    int employeeidGet = Convert.ToInt32(Console.ReadLine());
                    GetByIdHistories(employeeidGet);
                    break;
                case "5":
                    GetHistories();
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

    // GET ALL HISTORIES    
    public static void GetHistories()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_histories";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Start Date: " + reader.GetDateTime(0));
                    Console.WriteLine("Employee Id: " + reader.GetInt32(1));
                    Console.WriteLine("End Date: " + reader.GetDateTime(2));
                    Console.WriteLine("Departement Id: " + reader.GetInt32(3));
                    Console.WriteLine("Job Id: " + reader.GetString(4));
                }
            }
            else
            {
                Console.WriteLine("No Histories found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }

    // INSERT HISTORIES

    public static void InsertHistories(string startdate, int employeeid, string enddate, int departementid, string jobid)
       {
           _connection = new SqlConnection(_connectionString);

           SqlCommand sqlCommand = new SqlCommand();
           sqlCommand.Connection = _connection;
           sqlCommand.CommandText = "INSERT INTO tbl_histories VALUES (@startdate, @employeeid, @enddate, @departementid, @jobid)";

           _connection.Open();
           SqlTransaction transaction = _connection.BeginTransaction();
           sqlCommand.Transaction = transaction;

           try
           {
               SqlParameter pStartDate = new SqlParameter();
               pStartDate.ParameterName = "@startdate";
               pStartDate.SqlDbType = SqlDbType.DateTime;
               pStartDate.Value = startdate;
               sqlCommand.Parameters.Add(pStartDate);

               SqlParameter pEmployeeId = new SqlParameter();
               pEmployeeId.ParameterName = "@employeeid";
               pEmployeeId.SqlDbType = SqlDbType.Int;
               pEmployeeId.Value = employeeid;
               sqlCommand.Parameters.Add(pEmployeeId);

               SqlParameter pEndDate = new SqlParameter();
               pEndDate.ParameterName = "@enddate";
               pEndDate.SqlDbType = SqlDbType.DateTime;
               pEndDate.Value = enddate;
               sqlCommand.Parameters.Add(pEndDate);

               SqlParameter pDepartementId = new SqlParameter();
               pDepartementId.ParameterName = "@departementid";
               pDepartementId.SqlDbType = SqlDbType.Int;
               pDepartementId.Value = departementid;
               sqlCommand.Parameters.Add(pDepartementId);

               SqlParameter pJobId = new SqlParameter();
               pJobId.ParameterName = "@jobid";
               pJobId.SqlDbType = SqlDbType.Char;
               pJobId.Value = jobid;
               sqlCommand.Parameters.Add(pJobId);

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
   
    // UPDATE HISTORY
    public static void UpdateHistories(string startdateUpdate, int employeeidUpdate, string enddateUpdate, int departementidUpdate, string jobidUpdate)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE tbl_histories SET end_date = (@enddateUpdate), departement_id = (@departementidUpdate), job_id = (@jobidUpdate) WHERE start_date = (@startdateUpdate) AND employee_id = (@employeeidUpdate)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pStartDateUpdate = new SqlParameter();
            pStartDateUpdate.ParameterName = "@startdateUpdate";
            pStartDateUpdate.SqlDbType = SqlDbType.DateTime;
            pStartDateUpdate.Value = startdateUpdate;
            sqlCommand.Parameters.Add(pStartDateUpdate);

            SqlParameter pEmployeeIdUpdate = new SqlParameter();
            pEmployeeIdUpdate.ParameterName = "@employeeidUpdate";
            pEmployeeIdUpdate.SqlDbType = SqlDbType.VarChar;
            pEmployeeIdUpdate.Value = employeeidUpdate;
            sqlCommand.Parameters.Add(pEmployeeIdUpdate);

            SqlParameter pEndDateUpdate = new SqlParameter();
            pEndDateUpdate.ParameterName = "@enddateUpdate";
            pEndDateUpdate.SqlDbType = SqlDbType.VarChar;
            pEndDateUpdate.Value = enddateUpdate;
            sqlCommand.Parameters.Add(pEndDateUpdate);

            SqlParameter pDepartementIdUpdate = new SqlParameter();
            pDepartementIdUpdate.ParameterName = "@departementidUpdate";
            pDepartementIdUpdate.SqlDbType = SqlDbType.Int;
            pDepartementIdUpdate.Value = departementidUpdate;
            sqlCommand.Parameters.Add(pDepartementIdUpdate);

            SqlParameter pJobIdUpdate = new SqlParameter();
            pJobIdUpdate.ParameterName = "@jobidUpdate";
            pJobIdUpdate.SqlDbType = SqlDbType.Char;
            pJobIdUpdate.Value = jobidUpdate;
            sqlCommand.Parameters.Add(pJobIdUpdate);

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

    // DELETE HISTORY
    public static void DeleteHistories(string startdateDelete, int employeeidDelete)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM tbl_histories WHERE start_date = (@startdateDelete) AND employee_id = (@employeeidDelete)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pEmployeeIdDelete = new SqlParameter();
            pEmployeeIdDelete.ParameterName = "@employeeidDelete";
            pEmployeeIdDelete.SqlDbType = SqlDbType.Int;
            pEmployeeIdDelete.Value = employeeidDelete;
            sqlCommand.Parameters.Add(pEmployeeIdDelete);

            SqlParameter pStartDateDelete = new SqlParameter();
            pStartDateDelete.ParameterName = "@startdateDelete";
            pStartDateDelete.SqlDbType = SqlDbType.DateTime;
            pStartDateDelete.Value = startdateDelete;
            sqlCommand.Parameters.Add(pStartDateDelete);

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
    public static void GetByIdHistories(int employeeidGet)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_histories WHERE employee_id = (@employeeidGet)";

        try
        {
            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employeeidGet";
            pEmployeeId.SqlDbType = SqlDbType.Int;
            pEmployeeId.Value = employeeidGet;
            sqlCommand.Parameters.Add(pEmployeeId);

            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Start Date: " + reader.GetDateTime(0));
                    Console.WriteLine("Employee Id: " + reader.GetInt32(1));
                    Console.WriteLine("End Date: " + reader.GetDateTime(2));
                    Console.WriteLine("Departement Id: " + reader.GetInt32(3));
                    Console.WriteLine("Job Id: " + reader.GetString(4));
                }
            }
            else
            {
                Console.WriteLine("No History found.");
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

