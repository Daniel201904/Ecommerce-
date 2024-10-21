using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_de_datos
{
    public class Comentarios
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
        public int ProductoId { get; set; }
        public Productos Producto { get; set; }
        public string ComentarioTexto { get; set; }
        public DateTime FechaComentario { get; set; }
    }
}
