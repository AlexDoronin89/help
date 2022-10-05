using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Actor// : IReadOnlyActor
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _patronymic;
        private ICollection<ActorMovie> _actorMovies;

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
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
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

        public Actor(string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;

            ActorMovies = new HashSet<ActorMovie>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(string name, string surname, string patronymic)
        {
            if (name != null)
                Name = name;
            if (surname != null)
                Surname = surname;
            if (patronymic != null)
                Patronymic = patronymic;
        }
    }

    public interface IReadOnlyActor
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
    }
}
