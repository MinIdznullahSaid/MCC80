﻿using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;

namespace DatabaseConnectivity;
public class Countries
{
    private static string _connectionString = "Data Source = WISNU-PC;Database = db_hrd;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Execute()
    {
        while (true)
        {
            Console.WriteLine("== Countries ==");
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
                    string id = Console.ReadLine();
                    Console.WriteLine("Masukkan nama country yang ingin ditambahkan:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Country Id:");
                    int regionid = Convert.ToInt32(Console.ReadLine());
                    InsertCountries(id, name, regionid);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin diupdate:");
                    string idUpdate = Console.ReadLine();
                    Console.WriteLine("Masukkan update nama country:");
                    string nameUpdate = Console.ReadLine();
                    Console.WriteLine("Country Id:");
                    int regionidUpdate = Convert.ToInt32(Console.ReadLine());
                    UpdateCountries(idUpdate, nameUpdate, regionidUpdate);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin dihapus:");
                    int idDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteCountries(idDelete);
                    break;
                case "4":
                    Console.WriteLine("Masukkan Id Data yang ingin ditampilkan:");
                    int idGet = Convert.ToInt32(Console.ReadLine());
                    GetByIdCountries(idGet);
                    break;
                case "5":
                    GetCountries();
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

    // GET ALL COUNTRIES
    public static void GetCountries()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_countries";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("Region Id: " + reader.GetInt32(2));

                }
            }
            else
            {
                Console.WriteLine("No Country found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }

    // INSERT COUNTRY
    public static void InsertCountries(string id, string name, int regionid)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO tbl_countries (id, name, region_id) VALUES (@id, @name, @regionid)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Char;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@regionid";
            pRegionId.SqlDbType = SqlDbType.Int;
            pRegionId.Value = regionid;
            sqlCommand.Parameters.Add(pRegionId);

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

    // EDIT COUNTRY
    public static void UpdateCountries(string idUpdate, string nameUpdate, int regionidUpdate)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE tbl_countries SET name = (@nameUpdate), region_id = (@regionidUpdate) WHERE id = (@idUpdate)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pIdUpdate = new SqlParameter();
            pIdUpdate.ParameterName = "@idUpdate";
            pIdUpdate.SqlDbType = SqlDbType.Char;
            pIdUpdate.Value = idUpdate;
            sqlCommand.Parameters.Add(pIdUpdate);

            SqlParameter pNameUpdate = new SqlParameter();
            pNameUpdate.ParameterName = "@nameUpdate";
            pNameUpdate.SqlDbType = SqlDbType.VarChar;
            pNameUpdate.Value = nameUpdate;
            sqlCommand.Parameters.Add(pNameUpdate);

            SqlParameter pRegionIdUpdate = new SqlParameter();
            pRegionIdUpdate.ParameterName = "@regionidUpdate";
            pRegionIdUpdate.SqlDbType = SqlDbType.Int;
            pRegionIdUpdate.Value = regionidUpdate;
            sqlCommand.Parameters.Add(pRegionIdUpdate);

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

    // DELETE COUNTRIES
    public static void DeleteCountries(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM tbl_countries WHERE id = (@id)";

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
    public static void GetByIdCountries(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_countries WHERE id = (@id)";

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
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("Region Id: " + reader.GetInt32(2));
                }
            }
            else
            {
                Console.WriteLine("No Countries found.");
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

