using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class ActorMovie : /*IReadOnlyActorMovie,*/ INotifyPropertyChanged
    {
        private int _id;
        private int? _actorId;
        private int? _movieId;
        private Actor _actor;
        private Movie _movie;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public int? ActorId
        {
            get => _actorId;
            set
            {
                _actorId = value;
                OnPropertyChanged(nameof(ActorId));
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

        public virtual Actor Actor
        {
            get => _actor;
            set
            {
                _actor = value;
                OnPropertyChanged(nameof(Actor));
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

        //public ActorMovie(object actor_id, object movie_id)
        //{
        //    ActorId = (int?)actor_id;
        //    MovieId = (int?)movie_id;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(int actor_id, int movie_id)
        {
            if (actor_id != -1)
                this.ActorId = actor_id;
            if (movie_id != -1)
                this.MovieId = movie_id;
        }
    }

    public interface IReadOnlyActorMovie
    {
        public int Id { get; }
        public int? ActorId { get; }
        public int? MovieId { get; }
    }
}
