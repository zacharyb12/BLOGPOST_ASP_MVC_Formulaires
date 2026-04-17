using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Blog
{
    public class CreateBlog
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsVisible { get; set; }
    }
}
