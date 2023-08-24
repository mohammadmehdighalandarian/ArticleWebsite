namespace ArticleWebSite.Models
{
    public class Article
    {
        public long Id { get; private set; }

        public string Title { get; private set; }

        public string picture { get; private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public string ShortDescription { get; private set; }

        public string Body { get; private set; }

        public DateTime CreationDate { get; private set; }

        public Article(string title, string picture, string pictureAlt, string pictureTitle, string shortDescription, string body)
        {
            Title = title;
            this.picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Body = body;
            CreationDate=DateTime.Now;
        }
    }
}
