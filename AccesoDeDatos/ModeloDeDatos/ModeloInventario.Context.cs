﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDeDatos.ModeloDeDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InventarioBDEntities : DbContext
    {
        public InventarioBDEntities()
            : base("name=InventarioBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SEC_FORM> SEC_FORM { get; set; }
        public virtual DbSet<SEC_FORMS_ROLE> SEC_FORMS_ROLE { get; set; }
        public virtual DbSet<SEC_ROLE> SEC_ROLE { get; set; }
        public virtual DbSet<SEC_SESSION> SEC_SESSION { get; set; }
        public virtual DbSet<SEC_USER> SEC_USER { get; set; }
        public virtual DbSet<SEC_USER_ROLE> SEC_USER_ROLE { get; set; }
        public virtual DbSet<tb_categoria> tb_categoria { get; set; }
        public virtual DbSet<tb_edificio> tb_edificio { get; set; }
        public virtual DbSet<tb_espacio> tb_espacio { get; set; }
        public virtual DbSet<tb_foto> tb_foto { get; set; }
        public virtual DbSet<tb_marca> tb_marca { get; set; }
        public virtual DbSet<tb_persona> tb_persona { get; set; }
        public virtual DbSet<tb_piso> tb_piso { get; set; }
        public virtual DbSet<tb_producto> tb_producto { get; set; }
        public virtual DbSet<tb_sede> tb_sede { get; set; }
        public virtual DbSet<tb_tipoProducto> tb_tipoProducto { get; set; }
    }
}
