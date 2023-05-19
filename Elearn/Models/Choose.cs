using System;
namespace Elearn.Models
{
	public class Choose:BaseEntity
	{
		public string Title { get; set; }
		public string Details { get; set; }
		public bool Status { get; set; } = true;
	}
}

