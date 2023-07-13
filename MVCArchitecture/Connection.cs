using System.Data.SqlClient;

namespace MVCArchitecture;

public class Connection
{
    private static string _connectionString = "Data Source=WISNU-PC;Database=db_hrd;Integrated Security=True;Connect Timeout = 30;";
    private static SqlConnection _connection;

    public static SqlConnection Get()
    {
        try
        {
            _connection = new SqlConnection(_connectionString);
            return _connection;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}