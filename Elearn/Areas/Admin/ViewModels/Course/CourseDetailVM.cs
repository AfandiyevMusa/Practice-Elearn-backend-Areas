using System;
using Elearn.Models;

namespace Elearn.Areas.Admin.ViewModels.Course
{
	public class CourseDetailVM
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<CourseImage> courseImages { get; set; }
        public bool Status { get; set; } = true;
        public string CreatedDate { get; set; }
    }
}

