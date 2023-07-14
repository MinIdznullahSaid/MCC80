using MVCArchitecture;
using MVCArchitecture.Controllers;
using MVCArchitecture.Views;
using System.Data.SqlClient;

namespace MVCArchitecture.Models;

public class Departement
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int LocationId { get; set; }
    public int ManagerId { get; set; }

    public List<Departement> GetAll()
    {
        var connection = Connection.Get();

        var departements = new List<Departement>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_departements";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Departement departement = new Departement();
                    departement.Id = reader.GetInt32(0);
                    departement.Name = reader.GetString(1);
                    departement.LocationId = reader.GetInt32(2);
                    departement.ManagerId = reader.GetInt32(3);

                    departements.Add(departement);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return departements;
        }
        catch
        {
            return new List<Departement>();
        }
    }

    public int Insert(Departement departement)
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
    }

    public Departement GetById(int id)
    {
        var departement = new Departement();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_departements WHERE id = @id";
        sqlCommand.Parameters.AddWithValue("@id", id);

        try
        {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                departement.Id = reader.GetInt32(0);
                departement.Name = reader.GetString(1);
                departement.LocationId = reader.GetInt32(2);
                departement.ManagerId = reader.GetInt32(3);
            }

            reader.Close();
            connection.Close();

            return departement;
        }
        catch
        {
            return null;
        }
    }
}