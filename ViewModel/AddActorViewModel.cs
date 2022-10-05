using Poster.Model.DBModels;
using Poster.Model.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Poster.ViewModel
{
    class AddActorViewModel : INotifyPropertyChanged
    {
        private CommandTemplate _addCommand;
        private string _actorName;
        private string _actorSurname;
        private string _actorPatronymic;
        public ObservableCollection<Actor> Actors { get; set; }

        public string ActorName
        {
            get => _actorName;
            set
            {
                _actorName = value;
                OnPropertyChanged(nameof(ActorName));
            }
        }
        public string ActorSurname
        {
            get => _actorSurname;
            set
            {
                _actorSurname = value;
                OnPropertyChanged(nameof(ActorSurname));
            }
        }
        public string ActorPatronymic
        {
            get => _actorPatronymic;
            set
            {
                _actorPatronymic = value;
                OnPropertyChanged(nameof(ActorPatronymic));
            }
        }
        public CommandTemplate AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new CommandTemplate(obj =>
                    {
                        Actor actor = new Actor(ActorName, ActorSurname, ActorPatronymic);
                    });
                }
                return _addCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
