using MVCArchitecture;
using System.Data.SqlClient;

namespace MVCArchitecture.Models;

public class Job
{
    public string Id { get; set; }
    public string? Title { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }

    public List<Job> GetAll()
    {
        var connection = Connection.Get();

        var jobs = new List<Job>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_jobs";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Job job = new Job();
                    job.Id = reader.GetString(0);
                    job.Title = reader.GetString(1);
                    job.MinSalary = reader.GetInt32(2);
                    job.MaxSalary = reader.GetInt32(3);

                    jobs.Add(job);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return jobs;
        }
        catch
        {
            return new List<Job>();
        }
    }

    public int Insert(Job job)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO tbl_jobs VALUES (@id, @title, @minsalary, @maxsalary)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Char;
            pId.Value = job.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@title";
            pTitle.SqlDbType = System.Data.SqlDbType.VarChar;
            pTitle.Value = job.Title;
            sqlCommand.Parameters.Add(pTitle);

            SqlParameter pMinSalary = new SqlParameter();
            pMinSalary.ParameterName = "@minsalary";
            pMinSalary.SqlDbType = System.Data.SqlDbType.Int;
            pMinSalary.Value = job.MinSalary;
            sqlCommand.Parameters.Add(pMinSalary);

            SqlParameter pMaxSalary = new SqlParameter();
            pMaxSalary.ParameterName = "@maxsalary";
            pMaxSalary.SqlDbType = System.Data.SqlDbType.Int;
            pMaxSalary.Value = job.MaxSalary;
            sqlCommand.Parameters.Add(pMaxSalary);

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

    public int Update(Job job)
    {
        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE tbl_jobs SET title = @title, min_salary = @minsalary, max_salary = @maxsalary WHERE id = @id";

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Char;
            pId.Value = job.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@title";
            pTitle.SqlDbType = System.Data.SqlDbType.VarChar;
            pTitle.Value = job.Title;
            sqlCommand.Parameters.Add(pTitle);

            SqlParameter pMinSalary = new SqlParameter();
            pMinSalary.ParameterName = "@minsalary";
            pMinSalary.SqlDbType = System.Data.SqlDbType.Int;
            pMinSalary.Value = job.MinSalary;
            sqlCommand.Parameters.Add(pMinSalary);

            SqlParameter pMaxSalary = new SqlParameter();
            pMaxSalary.ParameterName = "@maxsalary";
            pMaxSalary.SqlDbType = System.Data.SqlDbType.Int;
            pMaxSalary.Value = job.MaxSalary;
            sqlCommand.Parameters.Add(pMaxSalary);

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

    public int Delete(string id)
    {
        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "DELETE FROM tbl_jobs WHERE id = @id";

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

    public Job GetById(string id)
    {
        var job = new Job();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM tbl_jobs WHERE id = @id";
        sqlCommand.Parameters.AddWithValue("@id", id);

        try
        {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                job.Id = reader.GetString(0);
                job.Title = reader.GetString(1);
                job.MinSalary = reader.GetInt32(2);
                job.MaxSalary = reader.GetInt32(2);
            }

            reader.Close();
            connection.Close();

            return job;
        }
        catch
        {
            return null;
        }
    }
}