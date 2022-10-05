using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class PosterDbContext : DbContext
    {
        public PosterDbContext()
        {
            //Database.EnsureCreated();
        }

        public PosterDbContext(DbContextOptions<PosterDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ActorMovie> ActorMovies { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=project;charset=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<ActorMovie>(entity =>
            {
                entity.ToTable("actor_movie");

                entity.HasIndex(e => e.ActorId, "FK_actor_movie_actor_id");

                entity.HasIndex(e => e.MovieId, "FK_actor_movie_movie_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorMovies)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_actor_movie_actor_id");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ActorMovies)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_actor_movie_movie_id");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("cinema");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.WorkTime)
                    .HasColumnType("time")
                    .HasColumnName("work_time");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.CinemaId, "FK_city_cinema");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CinemaId).HasColumnName("cinema_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("FK_city_cinema");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.ToTable("hall");

                entity.HasIndex(e => e.CinemaId, "FK_hall_cinema");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CinemaId).HasColumnName("cinema_id");

                entity.Property(e => e.CountLine).HasColumnName("count_line");

                entity.Property(e => e.PlacesInLine).HasColumnName("places_in_line");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("FK_hall_cinema");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Picture)
                    .HasColumnType("blob")
                    .HasColumnName("picture");

                entity.Property(e => e.Producer)
                    .HasMaxLength(50)
                    .HasColumnName("producer");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.HasIndex(e => e.HallId, "FK_session_hall");

                entity.HasIndex(e => e.MovieId, "FK_session_movie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.HallId).HasColumnName("hall_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.HallId)
                    .HasConstraintName("FK_session_hall");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_session_movie");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.HasIndex(e => e.SessionId, "FK_ticket_session");

                entity.HasIndex(e => e.UserId, "FK_ticket_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Line).HasColumnName("line");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_ticket_session");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ticket_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
