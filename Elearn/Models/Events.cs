using System;
namespace Elearn.Models
{
	public class Events:BaseEntity
	{
		public string Title { get; set; }
		public string Location { get; set; }
        public bool Status { get; set; } = true;
    }
}

