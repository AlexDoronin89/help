using Poster.Model;
using Poster.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Poster.ViewModel
{
    class TicketViewModel : INotifyPropertyChanged
    {
        private IReadOnlyMovie _movie;
        private PosterData _model;
        private ObservableCollection<IReadOnlyHall> _halls;
        public ObservableCollection<TicketButton> TicketButtons { get; set; }
        public TicketViewModel(PosterData model, IReadOnlyMovie movie)
        {
            _movie = movie;
            _model = model;
            _halls = new ObservableCollection<IReadOnlyHall>(_model.GetAllHalls());
            TicketButtons =new ObservableCollection<TicketButton>();
            foreach (var hall in _halls)
            {
                TicketButtons.Add(new TicketButton(hall,_model)); ;
            }
        }

        public string Title
        {
            get => _movie.Title;

        }

        public byte[] Picture
        {
            get => _movie.Picture;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    class TicketButton
    {
        private IReadOnlyHall _hall;
        private PosterData _model;

        public TicketButton(IReadOnlyHall hall, PosterData model)
        {
            _hall = hall;
            _model = model;
        }

        public int? PlacesInLine
        {
            get => _hall.PlacesInLine;
        }
        public int? CountLine
        {
            get => _hall.CountLine;
        }
    }

}
