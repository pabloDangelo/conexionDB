// See https://aka.ms/new-console-template for more information

using ConexionDB.Clases;
internal class Program
{
    private static void Main(string[] args)
    {
        SqlConnection sqlConnection = null;
        DbCommand dbCommand = null;

        while (sqlConnection == null || dbCommand == null)
        {
            try
            {
                Console.Clear();
                if(sqlConnection == null) 
                {
                    Console.WriteLine("Ingrese Connection string");
                    var sqlConnectionInput = Console.ReadLine();
                    sqlConnection = new SqlConnection(sqlConnectionInput);
                }
                Console.Clear();
                Console.WriteLine("Conexion OK");


                if (dbCommand == null)
                {
                    Console.WriteLine("Ingrese instruccion T-SQL");
                    var dbCommandInput = Console.ReadLine();
                    dbCommand = new DbCommand(sqlConnection, dbCommandInput);

                    Console.WriteLine("\n");
                    dbCommand.Execute();

                    Console.ReadKey();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocurrió un error: {e.Message} \n");
            }
        }
    }
}