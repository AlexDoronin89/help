using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Movie : IReadOnlyMovie, INotifyPropertyChanged
    {
        private int _id;
        private string _title;
        private DateTime? _releaseDate;
        private string _producer;
        private string _description;
        private double? _rating;
        private byte[] _picture;
        private ICollection<ActorMovie> _actorMovies;
        private ICollection<Session> _sessions;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public DateTime? ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
        public string Producer
        {
            get => _producer;
            set
            {
                _producer = value;
                OnPropertyChanged(nameof(Producer));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public double? Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }
        public byte[] Picture
        {
            get => _picture;
            set
            {
                _picture = value;
                OnPropertyChanged(nameof(Picture));
            }
        }

        public virtual ICollection<ActorMovie> ActorMovies
        {
            get => _actorMovies;
            set
            {
                _actorMovies = value;
                OnPropertyChanged(nameof(ActorMovies));
            }
        }
        public virtual ICollection<Session> Sessions
        {
            get => _sessions;
            set
            {
                _sessions = value;
                OnPropertyChanged(nameof(Sessions));
            }
        }

        //public Movie(string title, DateTime releaseDate, string producer, string description, double rating, byte[] picture)
        //{
        //    Title = title;
        //    ReleaseDate = releaseDate;
        //    Producer = producer;
        //    Description = description;
        //    Rating = rating;
        //    Picture = picture;

        //    ActorMovies = new HashSet<ActorMovie>();
        //    Sessions = new HashSet<Session>();
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(string title, DateTime releaseDate, string producer, string description, double rating, byte[] picture)
        {
            if (title != null)
                Title = title;
            if (releaseDate != null)
                ReleaseDate = releaseDate;
            if (producer != null)
                Producer = producer;
            if (description != null)
                Description = description;
            if (rating != -1)
                Rating = rating;
            if (picture != null)
                Picture = picture;
        }
    }

    public interface IReadOnlyMovie
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public string Producer { get; }
        public string Description { get; }
        public double? Rating { get; }
        public byte[] Picture { get; }
    }
}
