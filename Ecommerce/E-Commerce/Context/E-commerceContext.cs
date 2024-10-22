using Base_de_datos;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commerce.Context
{
    public class E_commerceContext : DbContext
    {
        public E_commerceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Auditorias> Auditorias { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Cupones> Cupones { get; set; }
        public DbSet<DetallesPedidos> DetallesPedidos { get; set; }
        public DbSet<EmpresasEnvio> EmpresasEnvios { get; set; }
        public DbSet<Envios> Envios { get; set; }
        public DbSet<EstadisticasVentas> EstadisticasVentas { get; set; }
        public DbSet<ImagenProducto> ImagenProducto { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<LogsSistema> LogsSistema { get; set; }
        public DbSet<Notificaciones> Notificaciones { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<Productos> Productos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }

        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            //tabla auditorias
            modelBuilder.Entity<Auditorias>().ToTable("Auditorias");
            modelBuilder.Entity<Auditorias> ().HasKey(u => u.Id);
            modelBuilder.Entity<Auditorias> ().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Auditorias> ().Property(u => u.UsuarioId).HasColumnName("UsuarioId");
            modelBuilder.Entity<Auditorias> ().Property(u => u.Usuario).HasColumnName("Usuario");
            modelBuilder.Entity<Auditorias>().Property(u => u.Accion).HasColumnName("Accion");
            modelBuilder.Entity<Auditorias>().Property(u => u.FechaAccion).HasColumnName("FechaAccion");

            //tabla categoria
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Categoria>().HasKey(u => u.Id);
            modelBuilder.Entity<Categoria>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Categoria>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Categoria>().Property(u => u.Productos).HasColumnName("Productos");

            //Tabla comentarios
            modelBuilder.Entity<Comentarios>().ToTable("Comentarios");
            modelBuilder.Entity<Comentarios>().HasKey(u => u.Id);
            modelBuilder.Entity<Comentarios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Comentarios>().Property(u => u.UsuarioId).HasColumnName("UsuarioId");
            modelBuilder.Entity<Comentarios>().Property(u => u.Usuario).HasColumnName("Usuario");
            modelBuilder.Entity<Comentarios>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<Comentarios>().Property(u => u.Producto).HasColumnName("Producto");
            modelBuilder.Entity<Comentarios>().Property(u => u.ComentarioTexto).HasColumnName("ComentarioTexto");
            modelBuilder.Entity<Comentarios>().Property(u => u.FechaComentario).HasColumnName("FechaComentario");

            //Tabla cupones 
            modelBuilder.Entity<Cupones>().ToTable("Cupones");
            modelBuilder.Entity<Cupones>().HasKey(u => u.Id);
            modelBuilder.Entity<Cupones>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Cupones>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<Cupones>().Property(u => u.Producto).HasColumnName("Producto"); 
            modelBuilder.Entity<Cupones>().Property(u => u.PromocionId).HasColumnName("PromocionId");
            modelBuilder.Entity<Cupones>().Property(u => u.Promocion).HasColumnName("Promocion");

            //Tabla DetallesPedido
            modelBuilder.Entity<DetallesPedidos>().ToTable("DetallesPedidos");
            modelBuilder.Entity<DetallesPedidos>().HasKey(u => u.Id);
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.PedidoId).HasColumnName("PedidoId");
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.Pedido).HasColumnName("Pedido");
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.Producto).HasColumnName("Producto");
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.Cantidad).HasColumnName("Cantidad");
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.PrecioUnitario).HasColumnName("PrecioUnitario");

            //Tabla EmpresasEnvio
            modelBuilder.Entity<EmpresasEnvio>().ToTable("EmpresasEnvio");
            modelBuilder.Entity<EmpresasEnvio>().HasKey(u => u.Id);
            modelBuilder.Entity<EmpresasEnvio>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<EmpresasEnvio>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<EmpresasEnvio>().Property(u => u.Contacto).HasColumnName("Contacto");

            //Tabla Envio
            modelBuilder.Entity<Envios>().ToTable("Envios");
            modelBuilder.Entity<Envios>().HasKey(u => u.Id);
            modelBuilder.Entity<Envios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Envios>().Property(u => u.Pedido).HasColumnName("Pedido");
            modelBuilder.Entity<Envios>().Property(u => u.EmpresaEnvio).HasColumnName("EmpresaEnvio");
            modelBuilder.Entity<Envios>().Property(u => u.NumeroGuia).HasColumnName("NumeroGuia");
            modelBuilder.Entity<Envios>().Property(u => u.EstadoEnvio).HasColumnName("EstadoEnvio");
            modelBuilder.Entity<Envios>().Property(u => u.FechaEnvio).HasColumnName("FechaEnvio");
            modelBuilder.Entity<Envios>().Property(u => u.FechaEntrega).HasColumnName("FechaEntrega");

            //Tabla EstadisticasVentas
            modelBuilder.Entity<EstadisticasVentas>().ToTable("EstadisticasVentas");
            modelBuilder.Entity<EstadisticasVentas>().HasKey(u => u.Id);
            modelBuilder.Entity<EstadisticasVentas>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<EstadisticasVentas>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<EstadisticasVentas>().Property(u => u.Producto).HasColumnName("Producto");
            modelBuilder.Entity<EstadisticasVentas>().Property(u => u.CantidadVendida).HasColumnName("CantidadVendida");
            modelBuilder.Entity<EstadisticasVentas>().Property(u => u.IngresosGenerados).HasColumnName("IngresosGenerados");
            modelBuilder.Entity<EstadisticasVentas>().Property(u => u.FechaReporte).HasColumnName("FechaReporte");

            //Tabla ImagenProducto
            modelBuilder.Entity<ImagenProducto>().ToTable("ImagenProducto");
            modelBuilder.Entity<ImagenProducto>().HasKey(u => u.Id);
            modelBuilder.Entity<ImagenProducto>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<ImagenProducto>().Property(u => u.UrlImagen).HasColumnName("UrlImagen");
            modelBuilder.Entity<ImagenProducto>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<ImagenProducto>().Property(u => u.Producto).HasColumnName("Producto");

            //Tabla Inventarios
            modelBuilder.Entity<Inventarios>().ToTable("Inventarios");
            modelBuilder.Entity<Inventarios>().HasKey(u => u.Id);
            modelBuilder.Entity<Inventarios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventarios>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<Inventarios>().Property(u => u.Producto).HasColumnName("Producto");
            modelBuilder.Entity<Inventarios>().Property(u => u.Cantidad).HasColumnName("Cantidad");
            modelBuilder.Entity<Inventarios>().Property(u => u.UltimaActualizacion).HasColumnName("UltimaActualizacion");

            //Tabla LogsSistema
            modelBuilder.Entity<LogsSistema>().ToTable("LogsSistema");
            modelBuilder.Entity<LogsSistema>().HasKey(u => u.Id);
            modelBuilder.Entity<LogsSistema>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<LogsSistema>().Property(u => u.Nivel).HasColumnName("Nivel");
            modelBuilder.Entity<LogsSistema>().Property(u => u.Mensaje).HasColumnName("Mensaje");
            modelBuilder.Entity<LogsSistema>().Property(u => u.FechaLog).HasColumnName("FechaLog");

            //Tabla Notificaciones
            modelBuilder.Entity<Notificaciones>().ToTable("Notificaciones");
            modelBuilder.Entity<Notificaciones>().HasKey(u => u.Id);
            modelBuilder.Entity<Notificaciones>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Notificaciones>().Property(u => u.Titulo).HasColumnName("Titulo");
            modelBuilder.Entity<Notificaciones>().Property(u => u.Mensaje).HasColumnName("Mensaje");
            modelBuilder.Entity<Notificaciones>().Property(u => u.FechaEnvio).HasColumnName("FechaEnvio");

            //Tabla Pedidos
            modelBuilder.Entity<Pedidos>().ToTable("Pedidos");
            modelBuilder.Entity<Pedidos>().HasKey(u => u.Id);
            modelBuilder.Entity<Pedidos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Pedidos>().Property(u => u.ClienteId).HasColumnName("ClienteId");
            modelBuilder.Entity<Pedidos>().Property(u => u.Cliente).HasColumnName("Cliente");
            modelBuilder.Entity<Pedidos>().Property(u => u.Estado).HasColumnName("Estado");
            modelBuilder.Entity<Pedidos>().Property(u => u.Total).HasColumnName("Total");
            modelBuilder.Entity<Pedidos>().Property(u => u.FechaPedido).HasColumnName("FechaPedido");
            modelBuilder.Entity<Pedidos>().Property(u => u.Detalles).HasColumnName("Detalles");

            //tabla Permiso
            modelBuilder.Entity<Permiso>().ToTable("Permiso");
            modelBuilder.Entity<Permiso>().HasKey(u => u.Id);
            modelBuilder.Entity<Permiso>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Permiso>().Property(u => u.Nombre).HasColumnName("Nombre");

            //Tabla Productos
            modelBuilder.Entity<Productos>().ToTable("Productos");
            modelBuilder.Entity<Productos>().HasKey(u => u.Id);
            modelBuilder.Entity<Productos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Productos>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Productos>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            modelBuilder.Entity<Productos>().Property(u => u.Precio).HasColumnName("Precio");
            modelBuilder.Entity<Productos>().Property(u => u.Stock).HasColumnName("Stock");
            modelBuilder.Entity<Productos>().Property(u => u.FechaCreacion).HasColumnName("FechaCreacion");
            modelBuilder.Entity<Productos>().Property(u => u.CategoriaId).HasColumnName("CategoriaId");
            modelBuilder.Entity<Productos>().Property(u => u.Categoria).HasColumnName("Categoria");
            modelBuilder.Entity<Productos>().Property(u => u.VendedorId).HasColumnName("VendedorId");
            modelBuilder.Entity<Productos>().Property(u => u.Vendedor).HasColumnName("Vendedor");
            modelBuilder.Entity<Productos>().Property(u => u.Imagenes).HasColumnName("Imagenes");
        }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
