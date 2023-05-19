using System;

using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.News
{
	public class NewsVM
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<NewsImages> NewsImages { get; set; }
        public bool Status { get; set; } = true;
        public string CreatedDate { get; set; }
    }
}

