using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Ticket : IReadOnlyTicket, INotifyPropertyChanged
    {
        private int _id;
        private int? _sessionId;
        private int? _price;
        private int? _line;
        private int? _place;
        private int? _userId;
        private Session _session;
        private User _user;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public int? SessionId
        {
            get => _sessionId;
            set
            {
                _sessionId = value;
                OnPropertyChanged(nameof(SessionId));
            }
        }
        public int? Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public int? Line
        {
            get => _line;
            set
            {
                _line = value;
                OnPropertyChanged(nameof(Line));
            }
        }
        public int? Place
        {
            get => _place;
            set
            {
                _place = value;
                OnPropertyChanged(nameof(Place));
            }
        }
        public int? UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public virtual Session Session
        {
            get => _session;
            set
            {
                _session = value;
                OnPropertyChanged(nameof(Session));
            }
        }
        public virtual User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        //public Ticket(int price, int line, int place, int userId, int sessionId)
        //{
        //    Price = price;
        //    Line = line;
        //    Place = place;
        //    UserId = userId;
        //    SessionId = sessionId;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(int price, int line, int place, int userId, int sessionId)
        {
            if (price != -1)
                Price = price;
            if (line != -1)
                Line = line;
            if (place != -1)
                Place = place;
            if (userId != -1)
                UserId = userId;
            if (sessionId != -1)
                SessionId = sessionId;
        }
    }

    public interface IReadOnlyTicket
    {
        public int Id { get; }
        public int? SessionId { get; }
        public int? Price { get; }
        public int? Line { get; }
        public int? Place { get; }
        public int? UserId { get; }
    }
}
