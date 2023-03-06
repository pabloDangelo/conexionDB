using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConexionDB.Clases
{
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString) : base(connectionString) 
        { 
        }

        public override void OpenConnection()
        {
            // Simulacion de tiempo de apertura de conexion
            Random r = new Random();
            int rSeconds = r.Next(0, 30); // 66,6% Ok - 33,3% TimeOut

            double timeoutSeconds = TimeOut.TotalSeconds;

            if (rSeconds > timeoutSeconds)
                throw new Exception("Tiempo de espera de conexión agotado");

            Console.WriteLine("Se abrió la conexión SQL Server.");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Se cerró la conexión SQL Server.");
        }

        
    }
}
