using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_de_datos
{
    public class UsuariosNotificados
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; } 
        public int NotificacionId { get; set; }
        public Notificaciones Notificacion { get; set; } 
        public bool Leido { get; set; } 
        public DateTime? FechaLeido { get; set; }
    }
}
