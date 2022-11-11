using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01.Model
{
    public class ImagePost : Post
    {
        public string? Url { get; set; }

        public override string Html
        {
            get => Url is null ? throw new ArgumentNullException("Url war NULL!") : $"<h1>{Title}</h1><img src={Url} />";
        }

        public ImagePost(string title) : base(title) { }

        public ImagePost(string title, DateTime created) : base(title, created) { }
    }
}
