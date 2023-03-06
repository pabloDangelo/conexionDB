using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB.Clases
{
    /// <summary>
    /// Clase encargada de ejecutar instrucciones en la base de datos
    /// debe tener la instrucción que se enviará a la base de datos
    /// </summary>
    public class DbCommand
    {
        private DbConnection DbConnection { get; set; }
        private string TSqlInstruction { get; set; }

        /// <summary>
        /// Crea una nueva instancia de la clase DbCommand con los valorres especificados.
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="tSqlInstruction"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DbCommand(DbConnection dbConnection, string tSqlInstruction) 
        {

            if(dbConnection == null)
                throw new ArgumentNullException("Debe proporcionar un DbConnection");

            if (String.IsNullOrWhiteSpace(tSqlInstruction))
                throw new ArgumentNullException("Debe proporcionar una instruccion T-SQL");

            this.DbConnection = dbConnection;
            this.TSqlInstruction = tSqlInstruction.Trim();

        }

        public void Execute() 
        {
            DbConnection.OpenConnection();
            bool result = ExecuteInstruction(TSqlInstruction);
            if(result)
                Console.WriteLine("Instruccion ejecutada con éxito");
            else
                Console.WriteLine("Instruccion ejecutada con errores");

            DbConnection.CloseConnection();

        }

        private bool ExecuteInstruction(string instruction)
        {
            bool result = true;
            try
            {
                Console.WriteLine($"Ejecutando instruccion: '{instruction}'"); 
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
