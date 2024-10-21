﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_de_datos
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Productos Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}