using Poster.Model;
using Poster.Model.DBModels;
using Poster.Model.Tools;
using Poster.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Poster.ViewModel
{
    class MovieViewModel : INotifyPropertyChanged
    {
        private CommandTemplate _openSessionWindow;
        private Window _window;
        private IReadOnlyMovie _movie;
        private PosterData _model;
        public ObservableCollection<Actor> Actors { get; set; }

        public MovieViewModel(Window window, PosterData model,IReadOnlyMovie movie)
        {
            _window = window;
            _movie = movie;
            _model = model;
            _movie.ReleaseDate.ToString();
            Actors = new ObservableCollection<Actor>(_model.GetAllActors().Where(actor=>movie.ActorMovies.Count(b=>b.ActorId==actor.Id)>0));
        }
        
        public string Title
        {
            get => _movie.Title;

        }
        public DateTime? ReleaseDate
        {

            get => _movie.ReleaseDate;

        }
        public string Producer
        {
            get => _movie.Producer;

        }
        public string Description
        {
            get => _movie.Description;

        }
        public double? Rating
        {
            get => _movie.Rating;

        }
        public byte[] Picture
        {
            get => _movie.Picture;

        }
        public CommandTemplate CreateSessionWindow
        {
            get
            {
                if (_openSessionWindow == null)
                    _openSessionWindow = new CommandTemplate(AddSessionWindow);
                return _openSessionWindow;
            }
        }

        public void AddSessionWindow(object obj)
        {
            SessinWindow sessinWindow = new SessinWindow();
            SessionWindowViewModel sessionWindowViewModel = new SessionWindowViewModel(_window,_model,_movie);
            _window.Hide();

            sessinWindow.DataContext = sessionWindowViewModel;
            sessinWindow.ShowDialog();
            _window.Close();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
