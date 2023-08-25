using ArticleWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArticleWebSite.Pages
{
    public class CreateArticleModel : PageModel
    {
        public CreateArticle Command { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }

        private readonly ArticleContext _context;

        public CreateArticleModel(ArticleContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateArticle Command)
        {
            if (ModelState.IsValid)
            {
                Article newArticle = new Article(Command.Title, Command.Picture, Command.PictureAlt
                    , Command.PictureTitle, Command.ShortDescription, Command.Body,Command.Isdeleted);

                _context.Articles.Add(newArticle);
                _context.SaveChanges();

                SuccessMessage = "مقاله با موفقیت ایجاد گردید.";
               

                return RedirectToPage("/index");
            }
            else
            {
                ErrorMessage = "لطفا موارد خواسته شده را با دقت پر نمایید.";
                return Page();
            }
           
        }


    }
}
