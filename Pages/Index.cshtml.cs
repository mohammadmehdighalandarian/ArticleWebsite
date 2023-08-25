using ArticleWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArticleWebSite.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        private readonly ArticleContext _context;

        public IndexModel(ArticleContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // projection in C#
            Articles = _context.Articles
                .Where(x => x.IsDeleted == false)
                .Select(r => new ArticleViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    picture = r.picture,
                    CreationDate = r.CreationDate.ToString(),
                    PictureAlt = r.PictureAlt,
                    PictureTitle = r.PictureTitle,
                    ShortDescription = r.ShortDescription,
                    Isdeleted = r.IsDeleted

                }).OrderByDescending(x => x.Id).ToList();

        }

        public IActionResult OnGetDelete(int id)
        {
            Article article = _context.Articles.FirstOrDefault(x => x.Id == id);
            article.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToPage("/index");
        }
    }
}