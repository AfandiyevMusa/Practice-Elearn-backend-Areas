using System;
namespace Elearn.Models
{
	public class News:BaseEntity
	{
        public string Title { get; set; }
        public int NewsAuthorId { get; set; }
        public NewsAuthor NewsAuthor { get; set; }
        public ICollection<NewsImages> NewsImages { get; set; }
        public bool Status { get; set; } = true;
    }
}

