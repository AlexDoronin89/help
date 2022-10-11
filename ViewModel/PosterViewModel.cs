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
                PosterMovies.Add(new PosterMovieViewModel(_window,movie)); ;
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

        public int Id
        {
            get => _movie.Id;
            //set
            //{
            //    _id = value;
            //    OnPropertyChanged(nameof(Id));
            //}
        }

        public string Title
        {
            get => _movie.Title;
            //set
            //{
            //    _title = value;
            //    OnPropertyChanged(nameof(Title));
            //}
        }

        public byte[] Picture
        {
            get => _movie.Picture;
            //set
            //{
            //    _picture = value;
            //    OnPropertyChanged(nameof(Picture));
            //}
        }

        public PosterMovieViewModel(Window window, IReadOnlyMovie movie)
        {
            _window = window;
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
            MovieViewModel movieViewModel = new MovieViewModel(movieWindow, _movie);

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
