using Poster.Model;
using Poster.Model.DBModels;
using Poster.Model.Tools;
using Poster.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Poster.ViewModel
{
    class PosterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PosterMovieViewModel> PosterMovies { get; set; }
        private Movie _selectedMovie;
        private PosterData _model;
        private ObservableCollection<IReadOnlyMovie> _movies;
        private Window _window;


        public PosterViewModel(PosterData model,Window window)
        {
            _model = model;
            _movies = new ObservableCollection<IReadOnlyMovie>(_model.GetAllMovies());
            _window = window;
            PosterMovies = new ObservableCollection<PosterMovieViewModel>();

            foreach(var movie in _movies)
            {
                PosterMovies.Add(new PosterMovieViewModel(_window,movie,model)); ;
            }
        }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    internal class PosterMovieViewModel
    {
        private CommandTemplate _openMovieWindow;
        private Window _window;
        private IReadOnlyMovie _movie;
        private PosterData _model;
        public int Id
        {
            get => _movie.Id;
        }

        public string Title
        {
            get => _movie.Title;
        }

        public byte[] Picture
        {
            get => _movie.Picture;
            
        }

        public PosterMovieViewModel(Window window, IReadOnlyMovie movie,PosterData model)
        {
            _window = window;
            _model= model;
            _movie = movie;
        }

        public CommandTemplate OpenMovieWindow
        {
            get
            {
                if (_openMovieWindow == null)
                    _openMovieWindow = new CommandTemplate(AddMovieWindow);
                return _openMovieWindow;
            }
        }

        public void AddMovieWindow(object obj)
        {
            MovieWindow movieWindow = new MovieWindow();
            MovieViewModel movieViewModel = new MovieViewModel(_window, _model,_movie);

            _window.Hide();

            movieWindow.DataContext = movieViewModel;
            movieWindow.ShowDialog();
            _window.Show();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }


}
