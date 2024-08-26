using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    // Clase pública parcial que hereda de la clase base Form. Esta clase representa un formulario en una aplicación Windows Forms.
    public partial class Form2 : Form
    {
        // Constructor de la clase Form2. Se llama al inicializador de componentes para configurar el formulario.
        public Form2()
        {
            InitializeComponent();
        }

        // Manejador de eventos para el clic en el botón de guardado en el navegador de datos (BindingNavigator).
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Valida todos los controles en el formulario, verificando si cumplen con las reglas de validación establecidas.
            this.Validate();

            // Finaliza la edición en el origen de datos asociado, aplicando los cambios realizados en los controles vinculados.
            this.customersBindingSource.EndEdit();

            // Actualiza todos los datos en el conjunto de datos (DataSet) mediante el TableAdapterManager.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }


private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.Customers' Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }

        private void cajaTextoID_Click(object sender, EventArgs e)
        {
            // Método vacío que no realiza ninguna acción cuando se hace clic en cajaTextoID.
        }

        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es Enter (código ASCII 13).
            if (e.KeyChar == (char)13)
            {
                // Busca el índice del elemento en customersBindingSource que coincide con el valor de cajaTextoID.
                var index = customersBindingSource.Find("customerID", cajaTextoID.Text);

                // Si se encuentra el elemento (índice mayor o igual a 0).
                if (index > -1)
                {
                    // Establece la posición del binding source al índice encontrado, lo que selecciona el elemento correspondiente.
                    customersBindingSource.Position = index;
                    return;
                }
                else
                {
                    // Si no se encuentra el elemento, muestra un mensaje indicando que no se encontró.
                    MessageBox.Show("Elemento no encontrado");
                }
            }
        }
    }
}
