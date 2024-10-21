using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_de_datos
{
    public class ImagenProducto
    {
        public int Id { get; set; } 
        public string UrlImagen { get; set; } 

        public int ProductoId { get; set; }
        public Productos Producto { get; set; }
    }
}
