//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelCinemaContainer1 : DbContext
    {
        public ModelCinemaContainer1()
            : base("name=ModelCinemaContainer1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActerFilm> ActerFilm { get; set; }
        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CountryFilm> CountryFilm { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<DirectorFilm> DirectorFilm { get; set; }
        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<GenreFilms> GenreFilms { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<OccupiedPlace> OccupiedPlace { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SaleTicket> SaleTicket { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
    }
}
