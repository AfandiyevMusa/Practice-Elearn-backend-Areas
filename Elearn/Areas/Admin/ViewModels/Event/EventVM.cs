using System;
namespace Elearn.Areas.Admin.ViewModels.Event
{
	public class EventVM
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public string CreatedDate { get; set; }
    }
}

