﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SheaduleASP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SheaduleContext : DbContext
    {
        public SheaduleContext()
            : base("name=SheaduleContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTIVITY> ACTIVITY { get; set; }
        public virtual DbSet<AUDITORIUM> AUDITORIUM { get; set; }
        public virtual DbSet<DISCIPLINE> DISCIPLINE { get; set; }
        public virtual DbSet<FACULTY> FACULTY { get; set; }
        public virtual DbSet<GROUPS> GROUPS { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TEACHER> TEACHER { get; set; }
        public virtual DbSet<TIME> TIME { get; set; }
        public virtual DbSet<TIMETABLE> TIMETABLE { get; set; }
        public virtual DbSet<WEEKDAY> WEEKDAY { get; set; }
    }
}
