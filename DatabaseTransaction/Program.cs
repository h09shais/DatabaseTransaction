using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace DatabaseTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            void Execute(string message, Action<SqlConnection> action)
            {
                Console.WriteLine(message);
                using (var conn = new SqlConnection(connectionString))
                {
                    action(conn);
                }

                Console.WriteLine();
            }

            Execute("Return a list of order", conn =>
            {
                var result = conn.Query("SELECT [Id], [Title] FROM dbo.[Order]");
                foreach (var item in result)
                {
                    Console.WriteLine($"{item}");   
                }
                 
            });

            Console.ReadKey();
        }
    }
}
