using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Definición del espacio de nombres DatosLayer. Este espacio agrupa las clases relacionadas.
    public class Customers
    {
        // Propiedad pública que representa el identificador del cliente.
        public string CustomerID { get; set; }

        // Propiedad pública que representa el nombre de la empresa del cliente.
        public string CompanyName { get; set; }

        // Propiedad pública que representa el nombre de contacto del cliente.
        public string ContactName { get; set; }

        // Propiedad pública que representa el título de contacto del cliente.
        public string ContactTitle { get; set; }

        // Propiedad pública que representa la dirección del cliente.
        public string Address { get; set; }

        // Propiedad pública que representa la ciudad del cliente.
        public string City { get; set; }

        // Propiedad pública que representa la región o estado del cliente.
        public string Region { get; set; }

        // Propiedad pública que representa el código postal del cliente.
        public string PostalCode { get; set; }

        // Propiedad pública que representa el país del cliente.
        public string Country { get; set; }

        // Propiedad pública que representa el número de teléfono del cliente.
        public string Phone { get; set; }

        // Propiedad pública que representa el número de fax del cliente.
        public string Fax { get; set; }
    }
}

