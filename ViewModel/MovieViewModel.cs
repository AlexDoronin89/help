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
        private CommandTemplate _openTicketWindow;
        private Window _window;
        private Movie _movie;
        public MovieViewModel (Window window,Movie movie)
        {
            _window = window;
            _movie = movie;
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
}
