using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Blog
{
    public class UpdateBlog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsVisible { get; set; }
    }
}
