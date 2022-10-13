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
    class MovieViewModel : INotifyPropertyChanged
    {
        private DateTime? _releaseDate;
        private ICollection<ActorMovie> _actorMovies;
        private CommandTemplate _openTicketWindow;
        private Window _window;
        private IReadOnlyMovie _movie;
        public MovieViewModel (Window window,IReadOnlyMovie movie)
        {
            _window = window;
            _movie = movie;
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
            TicketViewModel ticketWindowViewModel = new TicketViewModel();

            ticketWindow.DataContext = ticketWindowViewModel;
            ticketWindow.ShowDialog();
            _window.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    internal class MovieTicket
    {

    }


}
