using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Cinema : IReadOnlyCinema, INotifyPropertyChanged
    {
        private int _id;
        private TimeSpan? _workTime;
        private string _title;
        private string _address;
        private ICollection<City> _cities;
        private ICollection<Hall> _halls;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public TimeSpan? WorkTime
        {
            get => _workTime;
            set
            {
                _workTime = value;
                OnPropertyChanged(nameof(WorkTime));
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
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public virtual ICollection<City> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged(nameof(Cities));
            }
        }
        public virtual ICollection<Hall> Halls
        {
            get => _halls;
            set
            {
                _halls = value;
                OnPropertyChanged(nameof(Halls));
            }
        }

        //public Cinema(TimeSpan workTime, string title, string address)
        //{
        //    WorkTime = workTime;
        //    Title = title;
        //    Address = address;

        //    Cities = new HashSet<City>();
        //    Halls = new HashSet<Hall>();
        //}

        public override string ToString()
        {
            return Title;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(TimeSpan workTime, string title, string address)
        {
            if (workTime != null)
                WorkTime = workTime;
            if (title != null)
                Title = title;
            if (address != null)
                Address = address;
        }
    }

    public interface IReadOnlyCinema
    {
        public int Id { get; }
        public TimeSpan? WorkTime { get; }
        public string Title { get; }
        public string Address { get; }
    }
}
