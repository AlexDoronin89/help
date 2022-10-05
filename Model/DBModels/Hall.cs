using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Hall : IReadOnlyHall, INotifyPropertyChanged
    {
        private int _id;
        private int? _placesInLine;
        private int? _cinemaId;
        private int? _countLine;
        private Cinema _cinema;
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
        public int? PlacesInLine
        {
            get => _placesInLine;
            set
            {
                _placesInLine = value;
                OnPropertyChanged(nameof(PlacesInLine));
            }
        }
        public int? CinemaId
        {
            get => _cinemaId;
            set
            {
                _cinemaId = value;
                OnPropertyChanged(nameof(CinemaId));
            }
        }
        public int? CountLine
        {
            get => _countLine;
            set
            {
                _countLine = value;
                OnPropertyChanged(nameof(CountLine));
            }
        }

        public virtual Cinema Cinema
        {
            get => _cinema;
            set
            {
                _cinema = value;
                OnPropertyChanged(nameof(Cinema));
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

        //public Hall(int placesInLine, int cinemaId, int countLine)
        //{
        //    PlacesInLine = placesInLine;
        //    CinemaId = cinemaId;
        //    CountLine = countLine;

        //    Sessions = new HashSet<Session>();
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(int placesInLine, int cinemaId, int countLine)
        {
            if (placesInLine != -1)
                PlacesInLine = placesInLine;
            if (cinemaId != -1)
                CinemaId = cinemaId;
            if (countLine != -1)
                CountLine = countLine;
        }
    }

    public interface IReadOnlyHall
    {
        public int Id { get; }
        public int? PlacesInLine { get; }
        public int? CinemaId { get; }
        public int? CountLine { get; }
    }
}
