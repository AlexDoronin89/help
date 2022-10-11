using Poster.Model.DBModels;
using Poster.Model.Tools;
using Poster.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Poster.ViewModel
{
    class MovieViewModel : INotifyPropertyChanged
    {
        private string _title;
        private DateTime? _releaseDate;
        private string _producer;
        private string _description;
        private double? _rating;
        private byte[] _picture;
        private ICollection<ActorMovie> _actorMovies;
        private CommandTemplate _openTicketWindow;
        private Window _window;
        private IReadOnlyMovie _movie;
        public MovieViewModel (Window window,IReadOnlyMovie movie)
        {
            _window = window;
            _movie = movie;
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
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public DateTime? ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
        public string Producer
        {
            get => _producer;
            set
            {
                _producer = value;
                OnPropertyChanged(nameof(Producer));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public double? Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }
        public byte[] Picture
        {
            get => _picture;
            set
            {
                _picture = value;
                OnPropertyChanged(nameof(Picture));
            }
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
