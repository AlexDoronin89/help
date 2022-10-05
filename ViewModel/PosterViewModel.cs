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
        private Movie _selectedMovie;
        private PosterData _model;
       
        public ObservableCollection<PosterMovieViewModel> PosterMovies { get; set; }

        public ObservableCollection<IReadOnlyMovie> Movies { get; private set; }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        public PosterViewModel(PosterData model)
        {
            _model = model;
            Movies = new ObservableCollection<IReadOnlyMovie>(_model.GetAllMovies());
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    internal class PosterMovieViewModel
    {
        Movie _movie;
        private CommandTemplate _openMovieWindow;
        private Window _window;

        public PosterMovieViewModel(Window window,Movie movie)
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
            MovieViewModel movieViewModel = new MovieViewModel(_window,_movie);

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
