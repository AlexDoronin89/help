using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Session : IReadOnlySession, INotifyPropertyChanged
    {
        private int _id;
        private int? _movieId;
        private DateTime? _date;
        private int? _hallId;
        private Hall _hall;
        private Movie _movie;
        private ICollection<Ticket> _tickets;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public int? MovieId
        {
            get => _movieId;
            set
            {
                _movieId = value;
                OnPropertyChanged(nameof(MovieId));
            }
        }
        public DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public int? HallId
        {
            get => _hallId;
            set
            {
                _hallId = value;
                OnPropertyChanged(nameof(HallId));
            }
        }

        public virtual Hall Hall
        {
            get => _hall;
            set
            {
                _hall = value;
                OnPropertyChanged(nameof(Hall));
            }
        }
        public virtual Movie Movie
        {
            get => _movie;
            set
            {
                _movie = value;
                OnPropertyChanged(nameof(Movie));
            }
        }
        public virtual ICollection<Ticket> Tickets
        {
            get => _tickets;
            set
            {
                _tickets = value;
                OnPropertyChanged(nameof(Tickets));
            }
        }

        public string CinemaTitle => Hall.Cinema.Title;

        //public Session(DateTime date, int movieId, int hallId)
        //{
        //    Date = date;
        //    MovieId = movieId;
        //    HallId = hallId;

        //    Tickets = new HashSet<Ticket>();
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(DateTime date, int movieId, int hallId)
        {
            if (date != null)
                Date = date;
            if (movieId != -1)
                MovieId = movieId;
            if (hallId != -1)
                HallId = hallId;
        }
    }

    public interface IReadOnlySession
    {
        public int Id { get; }
        public int? MovieId { get; }
        public DateTime? Date { get; }
        public int? HallId { get; }
    }
}
