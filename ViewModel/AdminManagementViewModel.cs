using Poster.Model.Tools;
using Poster.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Poster.ViewModel
{
    class AdminManagementViewModel : INotifyPropertyChanged
    {
        private CommandTemplate _openAddMovieWindow;
        private CommandTemplate _openAddSenseWindow;
        private CommandTemplate _openAddActorWindow;

        public CommandTemplate CreateAddMovieWindow
        {
            get
            {
                if (_openAddMovieWindow == null)
                    _openAddMovieWindow = new CommandTemplate(AddMovieWindow);
                return _openAddMovieWindow;
            }
        }
        public CommandTemplate CreateAddSessionWindow
        {
            get
            {
                if (_openAddSenseWindow == null)
                    _openAddSenseWindow = new CommandTemplate(AddSenseWindow);
                return _openAddSenseWindow;
            }
        }
        public CommandTemplate CreateAddActorWindow
        {
            get
            {
                if (_openAddActorWindow == null)
                    _openAddActorWindow = new CommandTemplate(AddActorWindow);
                return _openAddActorWindow;
            }
        }


        public void AddMovieWindow(object obj)
        {
            AddMovieWindow window = new AddMovieWindow();
            AddMovieViewModel addMovieViewModel = new AddMovieViewModel();

            window.DataContext = addMovieViewModel;
            window.Show();
        }

        public void AddSenseWindow(object obj)
        {
            AddSessionWindow window = new AddSessionWindow();
            AddSessionViewModel addSessionViewModel = new AddSessionViewModel();

            window.DataContext = addSessionViewModel;
            window.Show();
        }
        public void AddActorWindow(object obj)
        {
            AddActorWindow window = new AddActorWindow();
            AddActorViewModel addActorViewModel = new AddActorViewModel();

            window.DataContext = addActorViewModel;
            window.Show();
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
