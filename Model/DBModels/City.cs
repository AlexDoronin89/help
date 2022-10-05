using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class City : IReadOnlyCity, INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int? _cinemaId;
        private Cinema _cinema;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
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

        public virtual Cinema Cinema
        {
            get => _cinema;
            set
            {
                _cinema = value;
                OnPropertyChanged(nameof(Cinema));
            }
        }

        public City(string name, int? cinemaId)
        {
            Name = name;
            CinemaId = cinemaId;
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(string name, int cinemaId)
        {
            if (name != null)
                Name = name;
            if (cinemaId != -1)
                CinemaId = cinemaId;
        }
    }

    public interface IReadOnlyCity
    {
        public int Id { get; }
        public string Name { get; }
        public int? CinemaId { get; }
    }
}
