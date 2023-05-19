using System;
using Elearn.Models;

namespace Elearn.ViewModels
{
	public class HomeVM
	{
        public IEnumerable<Slider> sliders { get; set; }
        public IEnumerable<Course> courses { get; set; }
        public IEnumerable<Advertising> advertisings { get; set; }
        public IEnumerable<Choose> chooses { get; set; }
        public IEnumerable<Events> events { get; set; }
        public IEnumerable<News> news { get; set; }
    }
}

