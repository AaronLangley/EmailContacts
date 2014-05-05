using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace EmailContacts.ServiceModel.Types
{
    public class Contact
    {
		public Contact()
		{
			Tags = new List<AvailableTags>();
			FullName = new NameDetail();
		}
		
        [AutoIncrement]
        public int Id { get; set; }
       	
		//public string Name { get; set; }
		
		public string Email { get; set; }
        public int Age { get; set; }
		public List<AvailableTags> Tags { get; set; }
		
		public NameDetail FullName { get; set; }
		
		[Ignore]
		public string Name 
		{
			get { return FullName.ToString(); }	
		}
			
    }
	
	public class NameDetail	
	{
		public NameDetail()
		{ }
		public NameDetail(string first, string last)
		{
			First = first;
			Last = last;
		}

		public string First { get; set; }
		
		public string Last { get; set; }
		
		public override string ToString()
		{
			return string.Format("{0} {1}", First, Last).Trim();
		}
	}
	
	public enum AvailableTags
    {
        other,
        glam,
        hiphop,
		grunge,
		funk
    }
}