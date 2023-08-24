using ArticleWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleWebSite
{
    public class ArticleContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ArticleContext(DbContextOptions<ArticleContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
