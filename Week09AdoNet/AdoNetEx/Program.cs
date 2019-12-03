namespace AdoNetEx
{
    using System;
    using System.Data.SqlClient;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string connectionString = "Data Source=.;Initial Catalog=Week09.Net5;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //InsertRow(connection);

            //UpdateRow(connection);

            //Count(connection);

            //DeleteRow(connection);

            //InsertRowWithSeed(connection);

            SelectAll(connection);
        }

        private static void SelectAll(SqlConnection connection)
        {
            try
            {
                var query = "select * from Publisher where PublisherId < 10";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var currentRow = dataReader;

                    var id = currentRow["PublisherId"];
                    var name = currentRow["Name"];

                    Console.WriteLine($"{id} - {name}");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void InsertRowWithSeed(SqlConnection connection)
        {
            string name = "Some Name";

            try
            {
                var commandQuery = "insert into SomeTable3 (Name) values (@NameParam); select scope_identity();";

                SqlParameter nameParam = new SqlParameter("@NameParam", name);

                SqlCommand insertCommand = new SqlCommand(commandQuery, connection);

                insertCommand.Parameters.Add(nameParam);

                var id = insertCommand.ExecuteScalar();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DeleteRow(SqlConnection connection)
        {
            Console.WriteLine("Enter id to delete: ");
            var id = Console.ReadLine();

            var command = "delete from Publisher where PublisherId = @PubIdParam";

            SqlParameter param = new SqlParameter("@PubIdParam", id);

            SqlCommand deleteCommand = new SqlCommand(command, connection);

            deleteCommand.Parameters.Add(param);

            deleteCommand.ExecuteNonQuery();
        }

        private static void Count(SqlConnection connection)
        {
            try
            {
                var commandQuery = "select count(PublisherId) from Publisher";

                SqlCommand countCommand = new SqlCommand(commandQuery, connection);

                var count = countCommand.ExecuteScalar();

                Console.WriteLine($"Count is: {count}");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdateRow(SqlConnection connection)
        {
            try
            {
                var commandQuery = "update Publisher set Name = 'Dan 3' where PublisherId = 2";

                SqlCommand updateCommand = new SqlCommand(commandQuery, connection);

                updateCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void InsertRow(SqlConnection connection)
        {
            int id = 20;
            string name = "Some Name";

            try
            {
                var commandQuery = "insert into Publisher values (@IdParam, @NameParam);";

                SqlParameter idParam = new SqlParameter("@IdParam", id);
                SqlParameter nameParam = new SqlParameter("@NameParam", name);
                
                SqlCommand insertCommand = new SqlCommand(commandQuery, connection);

                insertCommand.Parameters.Add(idParam);
                insertCommand.Parameters.Add(nameParam);

                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
