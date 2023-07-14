using MVCArchitecture;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace MVCArchitecture.Models;

public class Location
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string CountryId { get; set; }

    public List<Location> GetAll()
    {
        var connection = Connection.Get();

        var locations = new List<Location>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_locations";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Location location = new Location();
                    location.Id = reader.GetInt32(0);
                    location.Address = reader.GetString(1);
                    location.PostCode = reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.Province = reader.GetString(4);
                    location.CountryId = reader.GetString(5);

                    locations.Add(location);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return locations;
        }
        catch
        {
            return new List<Location>();
        }
    }

    public int Insert(Location location)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO tbl_countries VALUES (@id, @address, @postcode, @city, @province, @countryid)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = location.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pAddress = new SqlParameter();
            pAddress.ParameterName = "@address";
            pAddress.SqlDbType = System.Data.SqlDbType.VarChar;
            pAddress.Value = location.Address;
            sqlCommand.Parameters.Add(pAddress);

            SqlParameter pPostcode = new SqlParameter();
            pPostcode.ParameterName = "@postcode";
            pPostcode.SqlDbType = System.Data.SqlDbType.VarChar;
            pPostcode.Value = location.PostCode;
            sqlCommand.Parameters.Add(pPostcode);

            SqlParameter pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = System.Data.SqlDbType.VarChar;
            pCity.Value = location.City;
            sqlCommand.Parameters.Add(pCity);

            SqlParameter pProvince = new SqlParameter();
            pProvince.ParameterName = "@province";
            pProvince.SqlDbType = System.Data.SqlDbType.VarChar;
            pProvince.Value = location.Province;
            sqlCommand.Parameters.Add(pProvince);

            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@countryid";
            pCountryId.SqlDbType = System.Data.SqlDbType.Char;
            pCountryId.Value = location.CountryId;
            sqlCommand.Parameters.Add(pCountryId);

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

    public int Update(Location location)
    {
        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE tbl_locations SET street_address = (@address), postal_code = (@postcode), city = (@city), state_province = (@province), country_id = (@countryid) WHERE id = (@id)";

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = location.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pAddress = new SqlParameter();
            pAddress.ParameterName = "@address";
            pAddress.SqlDbType = System.Data.SqlDbType.VarChar;
            pAddress.Value = location.Address;
            sqlCommand.Parameters.Add(pAddress);

            SqlParameter pPostcode = new SqlParameter();
            pPostcode.ParameterName = "@postcode";
            pPostcode.SqlDbType = System.Data.SqlDbType.VarChar;
            pPostcode.Value = location.PostCode;
            sqlCommand.Parameters.Add(pPostcode);

            SqlParameter pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = System.Data.SqlDbType.VarChar;
            pCity.Value = location.City;
            sqlCommand.Parameters.Add(pCity);

            SqlParameter pProvince = new SqlParameter();
            pProvince.ParameterName = "@province";
            pProvince.SqlDbType = System.Data.SqlDbType.VarChar;
            pProvince.Value = location.Province;
            sqlCommand.Parameters.Add(pProvince);

            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@countryid";
            pCountryId.SqlDbType = System.Data.SqlDbType.Char;
            pCountryId.Value = location.CountryId;
            sqlCommand.Parameters.Add(pCountryId);

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
        sqlCommand.CommandText = "DELETE FROM tbl_locations WHERE id = @id";

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

    public Location GetById(int id)
    {
        var location = new Location();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_locations WHERE id = @id";
        sqlCommand.Parameters.AddWithValue("@id", id);

        try
        {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                location.Id = reader.GetInt32(0);
                location.Address = reader.GetString(1);
                location.PostCode = reader.GetString(2);
                location.City = reader.GetString(3);
                location.Province = reader.GetString(4);
                location.CountryId = reader.GetString(5);

            }

            reader.Close();
            connection.Close();

            return location;
        }
        catch
        {
            return null;
        }
    }
}