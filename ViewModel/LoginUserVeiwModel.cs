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
    class LoginUserVeiwModel : INotifyPropertyChanged
    {
        private CommandTemplate _openPosterWindow;
        private CommandTemplate _getCities;
        private PosterData _model;
        private Window _window;

        public ObservableCollection</*IReadOnly*/City> Cities { get; private set; }
        public ObservableCollection</*IReadOnly*/Cinema> Cinemas { get; private set; }


        public LoginUserVeiwModel(Window window, PosterData model)
        {
            _window = window;
            _model = model;
            Cities = (ObservableCollection</*IReadOnly*/City>)_model.GetAllCities();
            Cinemas = (ObservableCollection</*IReadOnly*/Cinema>)_model.GetAllCinemas();
        }

        public CommandTemplate CreatePosterWindow
        {
            get
            {
                if (_openPosterWindow == null)
                    _openPosterWindow = new CommandTemplate(AddPosterWindow);
                return _openPosterWindow;
            }

        }

        public CommandTemplate GetCities
        {
            get
            {
                if (_getCities == null)
                {
                    _getCities = new CommandTemplate(obj =>
                    {

                    }
                    );
                }

                return _getCities;
            }
        }

        public void AddPosterWindow(object obj)
        {
            PosterWindow posterWindow = new PosterWindow();
            PosterViewModel posterWindowViewModel = new PosterViewModel(_model);

            _window.Hide();

            posterWindow.DataContext = posterWindowViewModel;
            posterWindow.ShowDialog();
            _window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
