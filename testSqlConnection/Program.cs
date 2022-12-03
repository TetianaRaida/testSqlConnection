// See https://aka.ms/new-console-template for more information

using Microsoft.Data.Sqlite;

//SqliteConnection sqlite_conn = new SqliteConnection("Data Source=database.db;");

using (var connection = new SqliteConnection("Data Source=hello.db"))
{
    connection.Open();

    var id = 1;
    var command = connection.CreateCommand();
    command.CommandText =
    @"
        SELECT name
        FROM user
        WHERE id = $id
    ";
    command.Parameters.AddWithValue("$id", id);

    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            var name = reader.GetString(0);

            Console.WriteLine($"Hello, {name}!");
        }
    }
}
Console.ReadLine();
Console.WriteLine("Hello, World!");