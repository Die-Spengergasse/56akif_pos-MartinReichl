using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01.Model
{
    public abstract class Post
    {
        private int _rating;

        public string Title { get; }

        public DateTime Created { get; }

        public abstract string Html { get; }

        public SmartPhoneApp? SmartPhone { get; set; }

        public int Rating
        {
            get => _rating;

            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("Range muss zwischen 1 und 5 liegen!");
                }

                _rating = value;
            }
        }

        public Post(string title, DateTime created)
        {
            if (title is not null)
            {
                Title = title;
                Created = created;
            }
            else
            {
                throw new ArgumentNullException("Titel war NULL!");
            }
        }

        public Post(string title) : this(title, DateTime.Now) { }

        public override string ToString() => $"{Html}";
    }
}
