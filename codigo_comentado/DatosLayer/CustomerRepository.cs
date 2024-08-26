using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer // Define un espacio de nombres llamado 'DatosLayer', que probablemente contiene la capa de acceso a datos de la aplicación.
{
    public class CustomerRepository // Define una clase pública llamada 'CustomerRepository' que maneja operaciones CRUD sobre la entidad 'Customers'.
    {

        public List<Customers> ObtenerTodos()
        { // Método público que devuelve una lista de todos los clientes.
            using (var conexion = DataBase.GetSqlConnection())
            { // Crea una conexión a la base de datos y la cierra automáticamente al finalizar el bloque.
                String selectFrom = ""; // Declara una cadena vacía para construir la consulta SQL.
                selectFrom = selectFrom + "SELECT [CustomerID] " + "\n"; // Añade la selección de la columna CustomerID a la consulta.
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n"; // Añade la selección de la columna CompanyName.
                selectFrom = selectFrom + "      ,[ContactName] " + "\n"; // Añade la selección de la columna ContactName.
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n"; // Añade la selección de la columna ContactTitle.
                selectFrom = selectFrom + "      ,[Address] " + "\n"; // Añade la selección de la columna Address.
                selectFrom = selectFrom + "      ,[City] " + "\n"; // Añade la selección de la columna City.
                selectFrom = selectFrom + "      ,[Region] " + "\n"; // Añade la selección de la columna Region.
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n"; // Añade la selección de la columna PostalCode.
                selectFrom = selectFrom + "      ,[Country] " + "\n"; // Añade la selección de la columna Country.
                selectFrom = selectFrom + "      ,[Phone] " + "\n"; // Añade la selección de la columna Phone.
                selectFrom = selectFrom + "      ,[Fax] " + "\n"; // Añade la selección de la columna Fax.
                selectFrom = selectFrom + "  FROM [dbo].[Customers]"; // Especifica la tabla de la cual se seleccionarán los datos.

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                { // Crea un comando SQL para ejecutar la consulta.
                    SqlDataReader reader = comando.ExecuteReader(); // Ejecuta la consulta y obtiene un lector de datos para recorrer los resultados.
                    List<Customers> Customers = new List<Customers>(); // Crea una lista vacía para almacenar los clientes recuperados.

                    while (reader.Read()) // Recorre cada fila en el lector de datos.
                    {
                        var customers = LeerDelDataReader(reader); // Llama a un método para convertir la fila actual en un objeto Customers.
                        Customers.Add(customers); // Añade el objeto Customers a la lista.
                    }
                    return Customers; // Devuelve la lista de clientes.
                }
            }

        }

        public Customers ObtenerPorID(string id)
        { // Método público que devuelve un cliente según su ID.
            using (var conexion = DataBase.GetSqlConnection())
            { // Crea una conexión a la base de datos y la cierra automáticamente al finalizar el bloque.

                String selectForID = ""; // Declara una cadena vacía para construir la consulta SQL.
                selectForID = selectForID + "SELECT [CustomerID] " + "\n"; // Añade la selección de la columna CustomerID a la consulta.
                selectForID = selectForID + "      ,[CompanyName] " + "\n"; // Añade la selección de la columna CompanyName.
                selectForID = selectForID + "      ,[ContactName] " + "\n"; // Añade la selección de la columna ContactName.
                selectForID = selectForID + "      ,[ContactTitle] " + "\n"; // Añade la selección de la columna ContactTitle.
                selectForID = selectForID + "      ,[Address] " + "\n"; // Añade la selección de la columna Address.
                selectForID = selectForID + "      ,[City] " + "\n"; // Añade la selección de la columna City.
                selectForID = selectForID + "      ,[Region] " + "\n"; // Añade la selección de la columna Region.
                selectForID = selectForID + "      ,[PostalCode] " + "\n"; // Añade la selección de la columna PostalCode.
                selectForID = selectForID + "      ,[Country] " + "\n"; // Añade la selección de la columna Country.
                selectForID = selectForID + "      ,[Phone] " + "\n"; // Añade la selección de la columna Phone.
                selectForID = selectForID + "      ,[Fax] " + "\n"; // Añade la selección de la columna Fax.
                selectForID = selectForID + "  FROM [dbo].[Customers] " + "\n"; // Especifica la tabla de la cual se seleccionarán los datos.
                selectForID = selectForID + $"  Where CustomerID = @customerId"; // Añade una condición para filtrar por CustomerID.

                using (SqlCommand comando = new SqlCommand(selectForID, conexion)) // Crea un comando SQL para ejecutar la consulta.
                {
                    comando.Parameters.AddWithValue("customerId", id); // Añade el parámetro para la consulta SQL.

                    var reader = comando.ExecuteReader(); // Ejecuta la consulta y obtiene un lector de datos.
                    Customers customers = null; // Declara una variable para almacenar el cliente.

                    if (reader.Read())
                    { // Verifica si se recuperó alguna fila.
                        customers = LeerDelDataReader(reader); // Convierte la fila actual en un objeto Customers.
                    }
                    return customers; // Devuelve el cliente recuperado o null si no se encontró.
                }

            }
        }

        public Customers LeerDelDataReader(SqlDataReader reader)
        { // Método para convertir una fila de datos en un objeto Customers.
            Customers customers = new Customers(); // Crea una nueva instancia de la clase Customers.

            /*Asigna cada campo de la fila a la propiedad correspondiente del objeto Customers,
            comprobando si el valor es DBNull y asignando un valor predeterminado si es así. */
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];

            return customers; // Devuelve el objeto Customers lleno con los datos de la fila.
        }
        //-------------
        public int InsertarCliente(Customers customer)
        { // Método que inserta un nuevo cliente en la base de datos y devuelve el número de filas afectadas.
            using (var conexion = DataBase.GetSqlConnection())
            { // Establece una conexión con la base de datos y garantiza que se cierre al finalizar.
                String insertInto = ""; // Declara una cadena vacía para construir la consulta SQL.
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n"; // Añade la instrucción SQL para insertar datos en la tabla Customers.
                insertInto = insertInto + "           ([CustomerID] " + "\n"; // Añade la columna CustomerID a la instrucción de inserción.
                insertInto = insertInto + "           ,[CompanyName] " + "\n"; // Añade la columna CompanyName.
                insertInto = insertInto + "           ,[ContactName] " + "\n"; // Añade la columna ContactName.
                insertInto = insertInto + "           ,[ContactTitle] " + "\n"; // Añade la columna ContactTitle.
                insertInto = insertInto + "           ,[Address] " + "\n"; // Añade la columna Address.
                insertInto = insertInto + "           ,[City]) " + "\n"; // Añade la columna City y cierra la lista de columnas.
                insertInto = insertInto + "     VALUES " + "\n"; // Añade la instrucción SQL para especificar los valores que se van a insertar.
                insertInto = insertInto + "           (@CustomerID " + "\n"; // Añade el parámetro para CustomerID.
                insertInto = insertInto + "           ,@CompanyName " + "\n"; // Añade el parámetro para CompanyName.
                insertInto = insertInto + "           ,@ContactName " + "\n"; // Añade el parámetro para ContactName.
                insertInto = insertInto + "           ,@ContactTitle " + "\n"; // Añade el parámetro para ContactTitle.
                insertInto = insertInto + "           ,@Address " + "\n"; // Añade el parámetro para Address.
                insertInto = insertInto + "           ,@City)"; // Añade el parámetro para City y cierra la lista de valores.

                using (var comando = new SqlCommand(insertInto, conexion))
                { // Crea un comando SQL para ejecutar la consulta de inserción.
                    int insertados = parametrosCliente(customer, comando); // Llama al método 'parametrosCliente' para agregar los parámetros al comando y ejecuta la consulta.
                    return insertados; // Devuelve el número de filas afectadas por la inserción.
                }
            }
        }

        //-------------

        public int ActualizarCliente(Customers customer)
        { // Método que actualiza un cliente en la base de datos y devuelve el número de filas afectadas.
            using (var conexion = DataBase.GetSqlConnection())
            { // Establece una conexión con la base de datos y garantiza que se cierre al finalizar.
                String ActualizarCustomerPorID = ""; // Declara una cadena vacía para construir la consulta SQL.
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n"; // Añade la instrucción SQL para actualizar la tabla Customers.
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n"; // Especifica que se debe actualizar el campo CustomerID.
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n"; // Especifica que se debe actualizar el campo CompanyName.
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n"; // Especifica que se debe actualizar el campo ContactName.
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n"; // Especifica que se debe actualizar el campo ContactTitle.
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n"; // Especifica que se debe actualizar el campo Address.
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n"; // Especifica que se debe actualizar el campo City.
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID= @CustomerID"; // Especifica la condición para identificar el registro a actualizar.

                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                { // Crea un comando SQL para ejecutar la consulta de actualización.
                    int actualizados = parametrosCliente(customer, comando); // Llama al método 'parametrosCliente' para agregar los parámetros al comando y ejecuta la consulta.
                    return actualizados; // Devuelve el número de filas afectadas por la actualización.
                }
            }
        }

        public int parametrosCliente(Customers customer, SqlCommand comando)
        { // Método que agrega parámetros al comando SQL para insertar o actualizar un cliente.
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID); // Añade el parámetro para CustomerID.
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName); // Añade el parámetro para CompanyName.
            comando.Parameters.AddWithValue("ContactName", customer.ContactName); // Añade el parámetro para ContactName.
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactName); // Añade el parámetro para ContactTitle.
            comando.Parameters.AddWithValue("Address", customer.Address); // Añade el parámetro para Address.
            comando.Parameters.AddWithValue("City", customer.City); // Añade el parámetro para City.
            var insertados = comando.ExecuteNonQuery(); // Ejecuta el comando SQL (inserción o actualización) y devuelve el número de filas afectadas.
            return insertados; // Devuelve el número de filas afectadas.
        }

        public int EliminarCliente(string id)
        { // Método que elimina un cliente de la base de datos según su ID y devuelve el número de filas afectadas.
            using (var conexion = DataBase.GetSqlConnection())
            { // Establece una conexión con la base de datos y garantiza que se cierre al finalizar.
                String EliminarCliente = ""; // Declara una cadena vacía para construir la consulta SQL.
                EliminarCliente = EliminarCliente + "DELETE FROM [dbo].[Customers] " + "\n"; // Añade la instrucción SQL para eliminar un registro de la tabla Customers.
                EliminarCliente = EliminarCliente + "      WHERE CustomerID = @CustomerID"; // Especifica la condición para identificar el registro a eliminar.

                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion))
                { // Crea un comando SQL para ejecutar la consulta de eliminación.
                    comando.Parameters.AddWithValue("@CustomerID", id); // Añade el parámetro para CustomerID al comando.
                    int elimindos = comando.ExecuteNonQuery(); // Ejecuta el comando SQL de eliminación y devuelve el número de filas afectadas.
                    return elimindos; // Devuelve el número de filas afectadas por la eliminación.
                }
            }
        }
    }
}
