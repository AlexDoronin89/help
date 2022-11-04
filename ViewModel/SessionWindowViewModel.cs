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
    internal class SessionWindowViewModel
    {
        private CommandTemplate _openTicketWindow;
        private Window _window;
        private IReadOnlyMovie _movie;
        private PosterData _model;
        public ObservableCollection<Session> Sessions { get; set; }
        public SessionWindowViewModel(Window window, PosterData model, IReadOnlyMovie movie)
        {
            _window = window;
            _movie = movie;
            _model = model;
            Sessions = new ObservableCollection<Session>(_model.GetAllSessions().Where(a => movie.ActorMovies.Count(b => b.MovieId == a.MovieId) > 0));
        }

        public CommandTemplate CreateTicketWindow
        {
            get
            {
                if (_openTicketWindow == null)
                    _openTicketWindow = new CommandTemplate(AddTicketWindow);
                return _openTicketWindow;
            }
        }

        public void AddTicketWindow(object obj)
        {
            TicketWindow ticketWindow = new TicketWindow();
            TicketViewModel ticketViewModel = new TicketViewModel(_model,_movie);
            _window.Hide();
            ticketWindow.DataContext = ticketViewModel;
            ticketWindow.ShowDialog();
            _window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
