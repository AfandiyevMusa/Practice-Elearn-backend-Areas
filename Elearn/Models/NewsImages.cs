using System;
namespace Elearn.Models
{
	public class NewsImages:BaseEntity
	{
        public string Image { get; set; }
        public bool IsMain { get; set; } = false;
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}

