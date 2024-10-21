﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_de_datos
{
    public class EstadisticasVentas
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Productos Producto { get; set; } 
        public int CantidadVendida { get; set; }
        public decimal IngresosGenerados { get; set; }
        public DateTime FechaReporte { get; set; }
    }
}
