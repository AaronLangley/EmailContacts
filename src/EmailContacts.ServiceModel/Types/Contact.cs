using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace EmailContacts.ServiceModel.Types
{
    public class Contact
    {
		public Contact()
		{
			Tags = new List<AvailableTags>();
		}
		
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
		public List<AvailableTags> Tags { get; set; }
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