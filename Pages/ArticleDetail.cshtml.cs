using ArticleWebSite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArticleWebSite.Pages
{
    public class ArticleDetailModel : PageModel
    {
        public Article Article { get; set; }

        private readonly ArticleContext _context;

        public ArticleDetailModel(ArticleContext context)
        {
            _context = context;
        }

        public void OnGet(long id)
        {
            Article = _context.Articles.FirstOrDefault(x => x.Id == id)!;
        }
    }
}
