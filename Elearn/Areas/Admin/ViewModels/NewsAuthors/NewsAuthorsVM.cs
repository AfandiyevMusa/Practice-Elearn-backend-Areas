using System;
using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.NewsAuthor
{
	public class NewsAuthorsVM
	{
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool Status { get; set; } = true;
        public string CreatedDate { get; set; }
    }
}

