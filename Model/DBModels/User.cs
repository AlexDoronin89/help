using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class User : IReadOnlyUser
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int? PhoneNumber { get; private set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        //public User(string name, string surname, int phoneNumber)
        //{
        //    Name = name;
        //    Surname = surname;
        //    PhoneNumber = phoneNumber;

        //    Tickets = new HashSet<Ticket>();
        //}

        public void Update(string name, string surname, int phoneNumber)
        {
            if (name != null)
                Name = name;
            if (surname != null)
                Surname = surname;
            if (phoneNumber != -1)
                PhoneNumber = phoneNumber;
        }
    }

    public interface IReadOnlyUser
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public int? PhoneNumber { get; }
    }
}
