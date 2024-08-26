using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    // Definición de la clase DataBase dentro del espacio de nombres DatosLayer.
    public class DataBase
    {
        // Propiedad estática que devuelve la cadena de conexión para la base de datos.
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión desde el archivo de configuración, usando 
                // el nombre "NWConnection" como clave para encontrar la cadena correcta.
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Crea un objeto SqlConnectionStringBuilder para manipular la cadena de conexión.
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Establece el nombre de la aplicación en la cadena de conexión si 
                // ApplicationName no es nulo. Si es nulo, deja el valor actual.
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Establece el tiempo de espera de la conexión si ConnectionTimeout es mayor a 0.
                // Si ConnectionTimeout es 0 o negativo, mantiene el valor actual.
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión como un string.
                return conexionBuilder.ToString();
            }
        }

        // Propiedad estática que permite establecer o recuperar el tiempo de espera de la conexión.
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática que permite establecer o recuperar el nombre de la aplicación.
        public static string ApplicationName { get; set; }

        // Método estático que devuelve una conexión SQL abierta usando la cadena de conexión definida.
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva conexión SQL utilizando la cadena de conexión generada en ConnectionString.
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión SQL.
            conexion.Open();

            // Devuelve la conexión abierta.
            return conexion;
        }
    }
}
