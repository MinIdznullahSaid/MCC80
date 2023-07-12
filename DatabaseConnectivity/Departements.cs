using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using Microsoft.VisualBasic;
using System.Security.Cryptography;


namespace DatabaseConnectivity;
public class Departements
{
    private static string _connectionString = "Data Source = WISNU-PC;Database = db_hrd;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Execute()
    {
        while (true)
        {
            Console.WriteLine("== Departements ==");
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
                    Console.WriteLine("Masukkan nama departement yang ingin ditambahkan:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Location Id:");
                    int locationid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Manager Id:");
                    int managerid = Convert.ToInt32(Console.ReadLine());
                    InsertDepartements(id, name, locationid, managerid);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin diupdate:");
                    int idUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Masukkan update nama departement:");
                    string nameUpdate = Console.ReadLine();
                    Console.WriteLine("Location Id:");
                    int locationidUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Manager Id:");
                    int manageridUpdate = Convert.ToInt32(Console.ReadLine());
                    UpdateDepartements(idUpdate, nameUpdate, locationidUpdate, manageridUpdate);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin dihapus:");
                    int idDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteDepartements(idDelete);
                    break;
                case "4":
                    Console.WriteLine("Masukkan Id Data yang ingin ditampilkan:");
                    int idGet = Convert.ToInt32(Console.ReadLine());
                    GetByIdDepartements(idGet);
                    break;
                case "5":
                    GetDepartements();
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

    // GET ALL DEPARTEMENTS
    public static void GetDepartements()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_departements";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Nama Departement: " + reader.GetString(1));
                    Console.WriteLine("Location Id: " + reader.GetInt32(2));
                    Console.WriteLine("Manager Id: " + reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No Departement found.");
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
    public static void InsertDepartements(int id, string name, int locationid, int managerid)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO tbl_departements (id, name, location_id, manager_id) VALUES (@id, @name, @locationid, @managerid)";

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

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pLocationId = new SqlParameter();
            pLocationId.ParameterName = "@locationid";
            pLocationId.SqlDbType = SqlDbType.Int;
            pLocationId.Value = locationid;
            sqlCommand.Parameters.Add(pLocationId);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@managerid";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = managerid;
            sqlCommand.Parameters.Add(pManagerId);

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

    // UPDATE DEPARTEMENT
    public static void UpdateDepartements(int idUpdate, string nameUpdate, int locationidUpdate, int manageridUpdate)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE tbl_departements SET name = (@nameUpdate), location_id = (@locationidUpdate), manager_id = (@manageridUpdate) WHERE id = (@idUpdate)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pTitleUpdate = new SqlParameter();
            pTitleUpdate.ParameterName = "@nameUpdate";
            pTitleUpdate.SqlDbType = SqlDbType.VarChar;
            pTitleUpdate.Value = nameUpdate;
            sqlCommand.Parameters.Add(pTitleUpdate);

            SqlParameter pIdUpdate = new SqlParameter();
            pIdUpdate.ParameterName = "@idUpdate";
            pIdUpdate.SqlDbType = SqlDbType.Int;
            pIdUpdate.Value = idUpdate;
            sqlCommand.Parameters.Add(pIdUpdate);

            SqlParameter pLocationIdUpdate = new SqlParameter();
            pLocationIdUpdate.ParameterName = "@locationidUpdate";
            pLocationIdUpdate.SqlDbType = SqlDbType.Int;
            pLocationIdUpdate.Value = locationidUpdate;
            sqlCommand.Parameters.Add(pLocationIdUpdate);

            SqlParameter pManagerIdUpdate = new SqlParameter();
            pManagerIdUpdate.ParameterName = "@manageridUpdate";
            pManagerIdUpdate.SqlDbType = SqlDbType.Int;
            pManagerIdUpdate.Value = manageridUpdate;
            sqlCommand.Parameters.Add(pManagerIdUpdate);

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

    // DELETE DEPARTEMENT
    public static void DeleteDepartements(int idDelete)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM tbl_departements WHERE id = (@idDelete)";

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
    public static void GetByIdDepartements(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_departements WHERE id = (@id)";

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
                    Console.WriteLine("Nama Departement: " + reader.GetString(1));
                    Console.WriteLine("Location Id: " + reader.GetInt32(2));
                    Console.WriteLine("Manager Id: " + reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No Departement found.");
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

