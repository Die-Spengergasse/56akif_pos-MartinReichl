using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spg.PluePos._01.Model;

namespace Spg.PluePos._01
{
    public class SmartPhoneApp : List<Post>
    {
        public string SmartPhoneId { get; set; } = string.Empty;

        public SmartPhoneApp(string smartPhoneId)
        {
            SmartPhoneId = smartPhoneId;
        }


        public new void Add(Post post) 
        {
            if (post is not null)
            {
                base.Add(post);
                post.SmartPhone = this;
            }
        }

        public string ProcessPosts()
        {
            string allPosts = "";

            foreach (Post post in this)
            {
                allPosts += post.ToString();
            }

            return allPosts;
        }

        public int CalcRating()
        {
            int sum = 0;

            foreach (Post post in this)
            {
                sum += post.Rating;
            }

            return sum;
        }

        public Post? this[string title] => FindPost(title);

        private Post? FindPost(string title)
        {
            foreach (Post post in this)
            {
                if (post.Title == title)
                {
                    return post;
                }
            }

            return null;
        }
    }
}
