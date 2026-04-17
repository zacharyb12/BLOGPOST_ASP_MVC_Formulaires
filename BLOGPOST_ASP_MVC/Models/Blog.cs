namespace BLOGPOST_ASP_MVC.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public bool IsVisible { get; set; }
    }
}
