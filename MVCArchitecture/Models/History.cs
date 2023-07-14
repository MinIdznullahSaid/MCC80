using MVCArchitecture;
using MVCArchitecture.Controllers;
using MVCArchitecture.Views;
using System.Data;
using System.Data.SqlClient;

namespace MVCArchitecture.Models;

public class History
{
    public string StartDate { get; set; }
    public int EmployeeId { get; set; }
    public string EndDate { get; set; }
    public int DepartementId { get; set; }
    public int JobId { get; set; }

    public List<History> GetAll()
    {
        var connection = Connection.Get();

        var histories = new List<History>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_histories";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    History history = new History();
                    history.StartDate = reader.GetString(0);
                    history.EmployeeId = reader.GetInt32(1);
                    history.EndDate = reader.GetString(2);
                    history.DepartementId = reader.GetInt32(3);
                    history.JobId = reader.GetInt32(4);

                    histories.Add(history);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return histories;
        }
        catch
        {
            return new List<History>();
        }
    }

    public int Insert(History history)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO tbl_histories VALUES (@startdate, @employeeid, @enddate, @departementid, @jobid)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pStartDate = new SqlParameter();
            pStartDate.ParameterName = "@startdate";
            pStartDate.SqlDbType = System.Data.SqlDbType.DateTime;
            pStartDate.Value = history.StartDate;
            sqlCommand.Parameters.Add(pStartDate);

            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employeeid";
            pEmployeeId.SqlDbType = System.Data.SqlDbType.Int;
            pEmployeeId.Value = history.StartDate;
            sqlCommand.Parameters.Add(pEmployeeId);

            SqlParameter pEndDate = new SqlParameter();
            pEndDate.ParameterName = "@enddate";
            pEndDate.SqlDbType = System.Data.SqlDbType.DateTime;
            pEndDate.Value = history.EndDate;
            sqlCommand.Parameters.Add(pEndDate);

            SqlParameter pDepartementId = new SqlParameter();
            pDepartementId.ParameterName = "@departementid";
            pDepartementId.SqlDbType = System.Data.SqlDbType.Int;
            pDepartementId.Value = history.DepartementId;
            sqlCommand.Parameters.Add(pDepartementId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@jobid";
            pJobId.SqlDbType = System.Data.SqlDbType.Int;
            pJobId.Value = history.JobId;
            sqlCommand.Parameters.Add(pJobId);

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

    public int Update(History history)
    {
        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE tbl_histories SET end_date = (@enddateUpdate), departement_id = (@departementidUpdate), job_id = (@jobidUpdate) WHERE employee_id = (@employeeidUpdate)";

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pStartDate = new SqlParameter();
            pStartDate.ParameterName = "@startdate";
            pStartDate.SqlDbType = System.Data.SqlDbType.DateTime;
            pStartDate.Value = history.StartDate;
            sqlCommand.Parameters.Add(pStartDate);

            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employeeid";
            pEmployeeId.SqlDbType = System.Data.SqlDbType.Int;
            pEmployeeId.Value = history.StartDate;
            sqlCommand.Parameters.Add(pEmployeeId);

            SqlParameter pEndDate = new SqlParameter();
            pEndDate.ParameterName = "@enddate";
            pEndDate.SqlDbType = System.Data.SqlDbType.DateTime;
            pEndDate.Value = history.EndDate;
            sqlCommand.Parameters.Add(pEndDate);

            SqlParameter pDepartementId = new SqlParameter();
            pDepartementId.ParameterName = "@departementid";
            pDepartementId.SqlDbType = System.Data.SqlDbType.Int;
            pDepartementId.Value = history.DepartementId;
            sqlCommand.Parameters.Add(pDepartementId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@jobid";
            pJobId.SqlDbType = System.Data.SqlDbType.Int;
            pJobId.Value = history.JobId;
            sqlCommand.Parameters.Add(pJobId);

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

    public int Delete(int employeeid)
    {
        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "DELETE FROM tbl_histories WHERE employee_id = @employeeid";

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employeeid";
            pEmployeeId.SqlDbType = System.Data.SqlDbType.Int;
            pEmployeeId.Value = employeeid;
            sqlCommand.Parameters.Add(pEmployeeId);

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

    public History GetById(int employeeid)
    {
        var history = new History();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_histories WHERE employee_id = @employeeid";
        sqlCommand.Parameters.AddWithValue("@employee_id", employeeid);

        try
        {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                history.StartDate = reader.GetString(0);
                history.EmployeeId = reader.GetInt32(1);
                history.EndDate = reader.GetString(2);
                history.DepartementId = reader.GetInt32(3);
                history.JobId = reader.GetInt32(4);
            }

            reader.Close();
            connection.Close();

            return history;
        }
        catch
        {
            return null;
        }
    }
}