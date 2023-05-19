using System;
using Elearn.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Elearn.ViewModels
{
	public class CourseVM
	{
        public IEnumerable<Author> authors { get; set; }
        public IEnumerable<Course> courses { get; set; }
    }
}

