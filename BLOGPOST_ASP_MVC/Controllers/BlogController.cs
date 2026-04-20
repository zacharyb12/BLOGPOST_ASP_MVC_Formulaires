using BLOGPOST_ASP_MVC.Models;
using BLOGPOST_ASP_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BLOGPOST_ASP_MVC.Controllers
{
    public class BlogController(IBlogRepository _repository) : Controller
    {

        // Index Action par défaut
        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _repository.GetBlogs(); 

            return View(blogs);
        }



        // Action Avec un paramètres récupérer automatiquement
        public async Task<IActionResult> Details(int id)
        {
            Blog? blog = await _repository.GetById(id);

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
        public async Task<IActionResult> Create(CreateBlogDTOs newBlog)
        {
            if(!ModelState.IsValid)
            {
                return View(newBlog);
            }

            bool response = await _repository.CreateBlog(newBlog);

            if(!response)
            {
                return View(newBlog);
            }
            return RedirectToAction("Index");
        }


        // Modification d'un élément existant
        public async Task<IActionResult> Edit(int id)
        {
            Blog? blog = await _repository.GetById(id);

            if(blog == null)
            {
                return RedirectToAction("Index");
            }

            UpdateBlogDTOs blogToUpdate = new()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                IsVisible = blog.IsVisible

            };

            return View(blogToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBlogDTOs updatedBlog)
        {
            if(!ModelState.IsValid)
            {
                return View(updatedBlog);
            }

            bool response = await _repository.UpdateBlog(updatedBlog.Id,updatedBlog);

            if(!response)
            {
                return View(updatedBlog);
            }
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(int id)
        {
            Blog? blog = await _repository.GetById(id);
            
            if(blog == null)
            {
                return RedirectToAction("Index");
            }

            return View(blog);  
        }

        [HttpPost]
        public async  Task<IActionResult> Delete(int id, Blog blog)
        {
            bool response = await _repository.DeleteBlog(id);

            if(!response)
            {
                return View(blog);
            }

            return RedirectToAction("Index");
        }


    }
}
