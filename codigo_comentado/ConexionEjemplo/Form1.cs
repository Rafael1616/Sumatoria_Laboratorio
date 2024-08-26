using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;


namespace ConexionEjemplo
{
    // Clase pública parcial que hereda de la clase base Form. Esta clase representa un formulario en una aplicación Windows Forms.
    public partial class Form1 : Form
    {
        // Instancia de CustomerRepository utilizada para gestionar la información de clientes.
        CustomerRepository customerRepository = new CustomerRepository();

        // Constructor de la clase Form1. Se llama al inicializador de componentes para configurar el formulario.
        public Form1()
        {
            InitializeComponent();
        }

        // Manejador de eventos para el clic del botón btnCargar.
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Obtiene una lista de todos los clientes desde el repositorio.
            var Customers = customerRepository.ObtenerTodos();
            // Asigna la lista de clientes como fuente de datos del DataGridView dataGrid para mostrar la información en el formulario.
            dataGrid.DataSource = Customers;
        }

        // Manejador de eventos para el cambio de texto en textBox1.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Código comentado que filtra la lista de clientes basada en el texto ingresado en tbFiltro.
            // var filtro = Customers.FindAll( X => X.CompanyName.StartsWith(tbFiltro.Text));
            // dataGrid.DataSource = filtro;
        }

        // Manejador de eventos para el evento de carga del formulario Form1.
        private void Form1_Load(object sender, EventArgs e)
        {
            /* Código comentado que configura la cadena de conexión de la base de datos y la conexión SQL.
            DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
            DatosLayer.DataBase.ConnectionTimeout = 30;

            string cadenaConexion = DatosLayer.DataBase.ConnectionString;
            var conxion = DatosLayer.DataBase.GetSqlConnection();
            */
        }

        // Manejador de eventos para el clic del botón btnBuscar.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtiene un cliente del repositorio usando el ID ingresado en txtBuscar.
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            // Rellena los campos de texto del formulario con la información del cliente obtenido.
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        // Manejador de eventos para el clic en label4. Actualmente no realiza ninguna acción.
        private void label4_Click(object sender, EventArgs e)
        {
            // Método vacío que no realiza ninguna acción.
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Variable para almacenar el resultado de la operación de inserción, inicializada en 0.
            var resultado = 0;

            // Llama al método ObtenerNuevoCliente para crear una instancia de un nuevo cliente con los datos ingresados en el formulario.
            var nuevoCliente = ObtenerNuevoCliente();

            // Verifica si el cliente es válido, llamando al método validarCampoNull. 
            // Si el resultado es false, significa que no hay campos nulos.
            if (validarCampoNull(nuevoCliente) == false)
            {
                // Inserta el nuevo cliente en el repositorio y almacena el número de filas modificadas en resultado.
                resultado = customerRepository.InsertarCliente(nuevoCliente);

                // Muestra un mensaje que indica que el cliente ha sido guardado y muestra el número de filas modificadas.
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else
            {
                // Si hay campos nulos en el nuevo cliente, muestra un mensaje solicitando que se completen los campos.
                MessageBox.Show("Debe completar los campos por favor");
            }
        }
        // si encautnra un null enviara true de lo caontrario false
        public Boolean validarCampoNull(Object objeto)
        {
            // Itera sobre todas las propiedades del objeto pasado como parámetro.
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                // Obtiene el valor actual de la propiedad.
                object value = property.GetValue(objeto, null);
                // Si el valor es una cadena vacía, devuelve true, indicando que hay un campo nulo.
                if ((string)value == "")
                {
                    return true;
                }
            }
            // Si ninguna propiedad tiene un valor vacío, devuelve false, indicando que todos los campos están completos.
            return false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Método vacío que no realiza ninguna acción cuando se hace clic en label5.
        }


        private void btModificar_Click(object sender, EventArgs e)
        {
            // Llama al método ObtenerNuevoCliente para crear un objeto de cliente con los datos del formulario.
            var actualizarCliente = ObtenerNuevoCliente();

            // Actualiza la información del cliente en el repositorio y obtiene el número de filas actualizadas.
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);

            // Muestra un mensaje que indica el número de filas actualizadas.
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }


        private Customers ObtenerNuevoCliente()
        {
            // Crea una nueva instancia de Customers con los datos del formulario.
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            // Devuelve el nuevo cliente con los datos completados.
            return nuevoCliente;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Elimina el cliente del repositorio usando el ID del cliente ingresado en el formulario y guarda el número de filas eliminadas.
            int elimindas = customerRepository.EliminarCliente(tboxCustomerID.Text);

            // Muestra un mensaje que indica el número de filas eliminadas.
            MessageBox.Show("Filas eliminadas = " + elimindas);
        }

    }
}
