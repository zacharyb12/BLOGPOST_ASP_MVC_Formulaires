# Projet ASP MVC

## Dépendances :
- EntityFrameworkCore
- EntityFrameworkCore Design
- EntityFrameworkCore Tools
- EntityFrameworkCore SqlServer

## Structure du projet 

### Asp MVC
- Controller : Gère les actions
- Models : Contient les Modèles
- Views : Contient les vues de l'applications
- Data : Contient le context et la configuration entityFramework
- Repositories : Contient la logique 


## 1er étape: 
- Définir les modèles dans le dossier Models
```csharp
public class CreateBlogDTOs
    {
        [Required(ErrorMessage = "Le champ titre est requis")]
        [MaxLength(50,ErrorMessage = "Le titre ne peut pas dépasser 50 caractères")]
        [MinLength(5 , ErrorMessage ="Le titre doit faire au minimum 5 caractères")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Le contenu est requis")]
        [MaxLength(500,ErrorMessage = "Le contenu ne peut dépasser 500 caractères")]
        public string Content { get; set; }

        
```

## 2iem étape: 
- Définir le context et la configuration Entity
- Ajouter la configuration dans program.cs
- Effectuer une migration
```csharp
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {}

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
        }
    }
```
```csharp
// Configuration Entity
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"))
);
```

## 3iem étape:
- Créer dans un dossier Repositories
- une classe et une interface ( blogRepository et IBlogRepository)
- La classe BlogRepository hérite de IBlogrepository
- Configurer l'injection de dépendances dans le program.cs


## 4iem étape:
- Injecter le context dans BlogRepository
- Implementer l'utilisation de entityFramework(CRUD)
```csharp
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetBlogs();

        Task<Blog?> GetById(int id);

        Task<IEnumerable<Blog>> GetBlogByUser(int id);

        Task<bool> CreateBlog(CreateBlogDTOs newBlog);

        Task<bool> UpdateBlog(int id, UpdateBlogDTOs updatedBlog);

        Task<bool> DeleteBlog(int id);
    }
```

```csharp
 public class BlogRepository(BlogContext _context) : IBlogRepository
    {
        public async Task<bool> CreateBlog(CreateBlogDTOs newBlog)
        {
            Blog blogToAdd = new()
            {
                Title = newBlog.Title,
                Content = newBlog.Content,
                IsVisible = newBlog.IsVisible,
                UserId = "1"
            };

            await _context.AddAsync(blogToAdd);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }
        public async Task<Blog?> GetById(int id)
        {
            Blog? blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if(blog == null)
            {
                return null;
            }
            return blog;
        }
        public async Task<bool> UpdateBlog(int id, UpdateBlogDTOs updatedBlog)
        {
            Blog? blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if(blog == null)
            {
                return false;
            }

            blog.Title = updatedBlog.Title;
            blog.Content = updatedBlog.Content;
            blog.IsVisible = updatedBlog.IsVisible;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteBlog(int id)
        {
            Blog? blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if(blog == null)
            {
                return false;
            }
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return true;
        }


        public Task<IEnumerable<Blog>> GetBlogByUser(int id)
        {
            throw new NotImplementedException();
        }


    }
```


## 5iem étape: 
- Dans le controlleur
- Injecter l'interface IBlogRepository
- Définir les actions du controlleur 

```csharp
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


```


## 6iem étape: 
- Ajouter les vues
- Attention à ce que les modèles correspondent entre le controlleur et la vue

```csharp
@model Blog





 <h3 class="text-center">@Model.Title</h3>

<div class="card w-75 mx-auto text-center">

    <p>@Model.Id</p>
    <p>@Model.Content</p>
    <p>@Model.CreatedAt</p>
    <p>@Model.UserId</p>
    <a asp-controller="Blog" asp-action="Edit" asp-route-id="@Model.Id">Edit Blog</a>
    <a asp-controller="Blog" asp-action="Delete" asp-route-id="@Model.Id">Delete Blog</a>
</div>
```