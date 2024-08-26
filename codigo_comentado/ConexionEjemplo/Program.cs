using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    // Clase interna estática que contiene el punto de entrada principal para la aplicación.
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        // Atributo que indica que el hilo de la aplicación debe usar un modelo de subprocesos de apartamento único (STA).
        [STAThread]
        static void Main()
        {
            // Habilita los estilos visuales para los controles de la aplicación. Esto aplica la apariencia moderna de los controles.
            Application.EnableVisualStyles();

            // Establece la opción de renderizado de texto compatible, que define si el texto en los controles se debe renderizar 
            // usando GDI+ para mejorar la apariencia del texto en algunos controles.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación y muestra el formulario principal (Form1) de la aplicación.
            Application.Run(new Form1());
        }
    }
}

