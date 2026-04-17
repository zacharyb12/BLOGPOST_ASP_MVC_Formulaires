using BLOGPOST_ASP_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BLOGPOST_ASP_MVC.Controllers
{
    public class BlogController : Controller
    {
        public static List<Blog> blogs = new()
        {
            new Blog()
            {
                Id = 1,
                Title = "Test",
                Content = "Test",
                CreatedAt = DateTime.Now,
                IsVisible = true,
                UserId = "A1"
            },
            new Blog()
            {
                Id = 2,
                Title = "Test 2",
                Content = "Test 2",
                CreatedAt = DateTime.Now,
                IsVisible = true,
                UserId = "A2"
            },
        };

        // Index Action par défaut
        public IActionResult Index()
        {
            return View(blogs);
        }

        // Action Avec un paramètres récupérer automatiquement
        public IActionResult Details(int id)
        {
            Blog? blog = blogs.FirstOrDefault(b => b.Id == id );

            if(blog == null)
            {
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // Navigation vers le formulaire de création
        public IActionResult Create()
        {
            return View(new CreateBlogDTOs());
        }

        // traitement de la soumission du formulaire
        [HttpPost]
        public IActionResult Create(CreateBlogDTOs newBlog)
        {
            if (!ModelState.IsValid)
            {
                return View(newBlog);
            }

            Blog blogToAdd = new()
            {
                Id = blogs.Count() * 2,
                Title = newBlog.Title,
                Content = newBlog.Content,
                IsVisible = newBlog.IsVisible,
                CreatedAt = DateTime.Now,
                UserId = "A12"
            };

            blogs.Add(blogToAdd);

            return RedirectToAction("Index");
            
        }


        // Modification d'un élément existant
        public IActionResult Edit(int id)
        {
            Blog? blog = blogs.FirstOrDefault(b => b.Id == id);

            if(blog == null)
            {
                return RedirectToAction("Index");
            }

            UpdateBlogDTOs blogToForm = new()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                IsVisible = blog.IsVisible,
            };

            return View(blogToForm);
        }

        [HttpPost]
        public IActionResult Edit(UpdateBlogDTOs updatedBlog)
        {
            if(!ModelState.IsValid)
            {
                return View(updatedBlog);
            }

            int index = blogs.FindIndex(b => b.Id == updatedBlog.Id);

            if(index == -1)
            {
                return RedirectToAction("Index");
            }

            blogs[index].Title = updatedBlog.Title;
            blogs[index].Content = updatedBlog.Content;
            blogs[index].IsVisible = updatedBlog.IsVisible;

            return RedirectToAction("Index");
        }
    }
}
