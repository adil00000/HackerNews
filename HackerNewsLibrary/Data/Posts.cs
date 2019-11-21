using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HackerNewsLibrary.Data
{
    public class Posts
    {
        [StringLength(256)]
        public string title { get; set; }
        public string uri { get; set; }
        [StringLength(256)]
        public string author { get; set; }
        public int points { get; set; }
        public int comments { get; set; }
        public int rank { get; set; }
    }
}
