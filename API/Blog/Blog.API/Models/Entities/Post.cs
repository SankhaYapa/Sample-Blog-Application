using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summery { get; set; }
        public string UrlHandle { get; set; }   
        public string FeatureImageUrl { get; set; }
        public bool Visible { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate{ get; set; }
    }
}
