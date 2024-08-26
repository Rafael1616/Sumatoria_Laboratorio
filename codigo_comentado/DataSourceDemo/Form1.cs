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
    // Definición de la clase Form1, que hereda de la clase base Form. Representa un formulario en una aplicación Windows Forms.
    public partial class Form1 : Form
    {
        // Constructor de la clase Form1. Se llama al inicializador de componentes para configurar el formulario.
        public Form1()
        {
            InitializeComponent();
        }

        // Manejador de eventos para el clic en el botón de guardado en el BindingNavigator. Este método guarda los cambios en los datos.
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Valida todos los controles del formulario, verificando si cumplen con las reglas de validación establecidas.
            this.Validate();

            // Finaliza la edición en el origen de datos asociado, aplicando los cambios realizados en los controles vinculados.
            this.customersBindingSource.EndEdit();

            // Actualiza todos los datos en el conjunto de datos (DataSet) mediante el TableAdapterManager.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Este método es otro manejador de eventos para el clic en el botón de guardado en el BindingNavigator.
        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            // Valida todos los controles del formulario.
            this.Validate();

            // Finaliza la edición en el origen de datos asociado.
            this.customersBindingSource.EndEdit();

            // Actualiza todos los datos en el conjunto de datos.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Este método es un tercer manejador de eventos para el clic en el botón de guardado en el BindingNavigator.
        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            // Valida todos los controles del formulario.
            this.Validate();

            // Finaliza la edición en el origen de datos asociado.
            this.customersBindingSource.EndEdit();

            // Actualiza todos los datos en el conjunto de datos.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.Customers' Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }

        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método vacío que no realiza ninguna acción cuando se hace clic en una celda de customersDataGridView.
        }

    }
}
