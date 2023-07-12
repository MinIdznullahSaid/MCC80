using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Net;


namespace DatabaseConnectivity;
public class Locations
{
    private static string _connectionString = "Data Source = WISNU-PC;Database = db_hrd;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Execute()
    {
        while (true)
        {
            Console.WriteLine("== Locations ==");
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
                    Console.WriteLine("Masukkan alamat yang ingin ditambahkan:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Kode pos:");
                    string postcode = Console.ReadLine();
                    Console.WriteLine("Kota:");
                    string city = Console.ReadLine();
                    Console.WriteLine("Provinsi:");
                    string province = Console.ReadLine();
                    Console.WriteLine("Country Id:");
                    string countryid = Console.ReadLine();
                    InsertLocations(id, address, postcode, city, province, countryid);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin diupdate:");
                    int idUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Masukkan alamat yang ingin ditambahkan:");
                    string addressUpdate = Console.ReadLine();
                    Console.WriteLine("Kode pos:");
                    string postcodeUpdate = Console.ReadLine();
                    Console.WriteLine("Kota:");
                    string cityUpdate = Console.ReadLine();
                    Console.WriteLine("Provinsi:");
                    string provinceUpdate = Console.ReadLine();
                    Console.WriteLine("Country Id:");
                    string countryidUpdate = Console.ReadLine();
                    UpdateLocations(idUpdate, addressUpdate, postcodeUpdate, cityUpdate, provinceUpdate, countryidUpdate);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Masukkan Id Data yang ingin dihapus:");
                    int idDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteLocations(idDelete);
                    break;
                case "4":
                    Console.WriteLine("Masukkan Id Data yang ingin ditampilkan:");
                    int idGet = Convert.ToInt32(Console.ReadLine());
                    GetByIdLocations(idGet);
                    break;
                case "5":
                    GetLocations();
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

    // GET ALL LOCATIONS
    public static void GetLocations()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_locations";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Street Address: " + reader.GetString(1));
                    Console.WriteLine("Postal Code: " + reader.GetString(2));
                    Console.WriteLine("City: " + reader.GetString(3));
                    Console.WriteLine("State Province: " + reader.GetString(4));
                    Console.WriteLine("Country Id: " + reader.GetString(5));
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

    // INSERT LOCATION
    public static void InsertLocations(int id, string address, string postcode, string city, string province, string countryid)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO tbl_locations (id, street_address, postal_code, city, state_province, country_id) VALUES (@id, @address, @postcode, @city, @province, @countryid)";

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

            SqlParameter pAddress = new SqlParameter();
            pAddress.ParameterName = "@address";
            pAddress.SqlDbType = SqlDbType.VarChar;
            pAddress.Value = address;
            sqlCommand.Parameters.Add(pAddress);

            SqlParameter pPostcode = new SqlParameter();
            pPostcode.ParameterName = "@postcode";
            pPostcode.SqlDbType = SqlDbType.VarChar;
            pPostcode.Value = postcode;
            sqlCommand.Parameters.Add(pPostcode);

            SqlParameter pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = SqlDbType.VarChar;
            pCity.Value = city;
            sqlCommand.Parameters.Add(pCity);

            SqlParameter pProvince = new SqlParameter();
            pProvince.ParameterName = "@province";
            pProvince.SqlDbType = SqlDbType.VarChar;
            pProvince.Value = province;
            sqlCommand.Parameters.Add(pProvince);

            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@countryid";
            pCountryId.SqlDbType = SqlDbType.Char;
            pCountryId.Value = countryid;
            sqlCommand.Parameters.Add(pCountryId);

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

    // UPDATE LOCATION
    public static void UpdateLocations(int idUpdate, string addressUpdate, string postcodeUpdate, string cityUpdate, string provinceUpdate, string countryidUpdate)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE tbl_locations SET street_address = (@addressUpdate), postal_code = (@postcodeUpdate), city = (@cityUpdate), state_province = (@provinceUpdate), country_id = (@countryidUpdate) WHERE id = (@idUpdate)";

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

            SqlParameter pAddressUpdate = new SqlParameter();
            pAddressUpdate.ParameterName = "@addressUpdate";
            pAddressUpdate.SqlDbType = SqlDbType.VarChar;
            pAddressUpdate.Value = addressUpdate;
            sqlCommand.Parameters.Add(pAddressUpdate);

            SqlParameter pPostcodeUpdate = new SqlParameter();
            pPostcodeUpdate.ParameterName = "@postcodeUpdate";
            pPostcodeUpdate.SqlDbType = SqlDbType.VarChar;
            pPostcodeUpdate.Value = postcodeUpdate;
            sqlCommand.Parameters.Add(pPostcodeUpdate);

            SqlParameter pCityUpdate = new SqlParameter();
            pCityUpdate.ParameterName = "@cityUpdate";
            pCityUpdate.SqlDbType = SqlDbType.VarChar;
            pCityUpdate.Value = cityUpdate;
            sqlCommand.Parameters.Add(pCityUpdate);

            SqlParameter pProvinceUpdate = new SqlParameter();
            pProvinceUpdate.ParameterName = "@provinceUpdate";
            pProvinceUpdate.SqlDbType = SqlDbType.VarChar;
            pProvinceUpdate.Value = provinceUpdate;
            sqlCommand.Parameters.Add(pProvinceUpdate);

            SqlParameter pCountryIdUpdate = new SqlParameter();
            pCountryIdUpdate.ParameterName = "@countryidUpdate";
            pCountryIdUpdate.SqlDbType = SqlDbType.Char;
            pCountryIdUpdate.Value = countryidUpdate;
            sqlCommand.Parameters.Add(pCountryIdUpdate);

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
    public static void DeleteLocations(int idDelete)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM tbl_locations WHERE id = (@idDelete)";

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
    public static void GetByIdLocations(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_locations WHERE id = (@id)";

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
                    Console.WriteLine("Street Address: " + reader.GetString(1));
                    Console.WriteLine("Postal Code: " + reader.GetString(2));
                    Console.WriteLine("City: " + reader.GetString(3));
                    Console.WriteLine("State Province: " + reader.GetString(4));
                    Console.WriteLine("Country Id: " + reader.GetString(5));
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

