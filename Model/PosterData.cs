using Poster.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Poster.Model
{
    class PosterData
    {
        public PosterData()
        {

        }

        #region CRUD City
        public void AddCity(string name, int cinemaId)
        {
            City city = new City(name, cinemaId);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Cities.Add(city);
                db.SaveChanges();
            }
        }

        public void RemoveCity(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                City city = db.Cities.FirstOrDefault(x => x.Id == id);

                if (city != null)
                {
                    db.Cities.Remove(city);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateCity(int id, string name = null, int cinemaId = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                City city = db.Cities.FirstOrDefault(x => x.Id == id);

                city.Update(name, cinemaId);

                db.Cities.Remove(city);
                db.SaveChanges();
            }
        }

        public ObservableCollection</*IReadOnly*/City> GetAllCities()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return new ObservableCollection<City>(db.Cities.ToList());
            }
        }

        public IReadOnlyCity GetCity(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Cities.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Cinema
        public void AddCinema(TimeSpan workTime, string title, string address)
        {
            Cinema cinema = new Cinema(/*workTime, title, address*/);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Cinemas.Add(cinema);
                db.SaveChanges();
            }
        }

        public void RemoveCinema(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Cinema cinema = db.Cinemas.FirstOrDefault(x => x.Id == id);

                if (cinema != null)
                {
                    db.Cinemas.Remove(cinema);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateCinema(int id, TimeSpan workTime = new TimeSpan(), string title = null, string address = null)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Cinema cinema = db.Cinemas.FirstOrDefault(i => i.Id == id);

                cinema.Update(workTime, title, address);

                db.Cinemas.Update(cinema);
                db.SaveChanges();
            }
        }

        public ObservableCollection</*IReadOnly*/Cinema> GetAllCinemas()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return new ObservableCollection<Cinema>(db.Cinemas.ToList());
            }
        }

        public IReadOnlyCinema GetCinema(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Cinemas.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Hall
        public void AddHall(int placesInLine, int cinemaId, int countLine)
        {
            Hall hall = new Hall(/*placesInLine, cinemaId, countLine*/);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Halls.Add(hall);
                db.SaveChanges();
            }
        }

        public void RemoveHall(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Hall hall = db.Halls.FirstOrDefault(x => x.Id == id);

                if (hall != null)
                {
                    db.Halls.Remove(hall);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateHall(int id, int placesInLine = -1, int cinemaId = -1, int countLine = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Hall hall = db.Halls.FirstOrDefault(i => i.Id == id);

                hall.Update(placesInLine, cinemaId, countLine);

                db.Halls.Update(hall);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyHall> GetAllHalls()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Halls.ToList();
            }
        }

        public IReadOnlyHall GetHall(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Halls.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Session
        public void AddSession(DateTime date, int movieId, int hallId)
        {
            Session session = new Session(/*date, movieId, hallId*/);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Sessions.Add(session);
                db.SaveChanges();
            }
        }

        public void RemoveSession(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Session session = db.Sessions.FirstOrDefault(x => x.Id == id);

                if (session != null)
                {
                    db.Sessions.Remove(session);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateSession(int id, DateTime date = new DateTime(), int movieId = -1, int hallId = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Session session = db.Sessions.FirstOrDefault(i => i.Id == id);

                session.Update(date, movieId, hallId);

                db.Sessions.Update(session);
                db.SaveChanges();
            }
        }

        public IReadOnlyList</*IReadOnly*/Session> GetAllSessions()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Sessions.Include(s=>s.Movie).ToList();
            }
        }

        public IReadOnlySession GetSession(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Sessions.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Movie
        public void AddMovie(string title, DateTime releaseDate, string producer, string description, double rating, byte[] picture)
        {
            Movie movie = new Movie(/*title, releaseDate, producer, description, rating, picture*/);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        public void RemoveMovie(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Movie movie = db.Movies.FirstOrDefault(x => x.Id == id);

                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateMovie(int id, string title = null, DateTime releaseDate = new DateTime(), string producer = null, string description = null, double rating = -1, byte[] picture = null)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Movie movie = db.Movies.FirstOrDefault(i => i.Id == id);

                movie.Update(title, releaseDate, producer, description, rating, picture);

                db.Movies.Update(movie);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyMovie> GetAllMovies()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Movies.Include(a=>a.ActorMovies).ToList();
            }
        }

        public IReadOnlyMovie GetMovie(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Movies.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Ticket
        public void AddTicket(int price, int line, int place, int userId, int sessionId)
        {
            Ticket ticket = new Ticket(/*price, line, place, userId, sessionId*/);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
            }
        }

        public void RemoveTicket(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Ticket ticket = db.Tickets.FirstOrDefault(x => x.Id == id);

                if (ticket != null)
                {
                    db.Tickets.Remove(ticket);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateTicket(int id, int price = -1, int line = -1, int place = -1, int userId = -1, int sessionId = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Ticket ticket = db.Tickets.FirstOrDefault(i => i.Id == id);

                ticket.Update(price, line, place, userId, sessionId);

                db.Tickets.Update(ticket);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyTicket> GetAllTickets()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Tickets.ToList();
            }
        }

        public IReadOnlyTicket GetTicket(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Tickets.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD User
        public void AddUser(string name, string surname, int phoneNumber)
        {
            User user = new User(/*name, surname, phoneNumber*/);

            using(PosterDbContext db = new PosterDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void RemoveUser(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                User user = db.Users.FirstOrDefault(x => x.Id == id);

                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public void UpdateUser(int id, string name = null, string surname = null, int phoneNumber = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                User user = db.Users.FirstOrDefault(x => x.Id == id);
                user.Update(name, surname , phoneNumber);

                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyUser> GetAllUsers()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Users.ToList();
            }
        }

        public IReadOnlyUser GetUser(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Actor
        public void AddActor(string name, string surname, string patronomic)
        {
            Actor actor = new Actor(name, surname , patronomic);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }
        }

        public void RemoveActor(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Actor actor = db.Actors.FirstOrDefault(x => x.Id == id);

                db.Actors.Remove(actor);
                db.SaveChanges();
            }
        }

        public void UpdateActor(int id, string name = null, string surname = null, string patronomic = null)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Actor actor = db.Actors.FirstOrDefault(x => x.Id == id);
                actor.Update(name, surname, patronomic);

                db.Actors.Remove(actor);
                db.SaveChanges();
            }
        }

        public IReadOnlyList</*IReadOnly*/Actor> GetAllActors()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Actors.ToList();
            }
        }

        public /*IReadOnly*/Actor GetActor(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Actors.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion
    }
}
