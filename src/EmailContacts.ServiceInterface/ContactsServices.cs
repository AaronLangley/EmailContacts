﻿using System.Collections.Generic;
using EmailContacts.ServiceModel;
using EmailContacts.ServiceModel.Types;
using ServiceStack;
using ServiceStack.FluentValidation;
using ServiceStack.OrmLite;
using ServiceStack.MiniProfiler;

namespace EmailContacts.ServiceInterface
{
    public class CotntactsValidator : AbstractValidator<CreateContact>
    {
        public CotntactsValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("A Name is what's needed.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Age).GreaterThan(0);
        }
    }
		
    public class ContactsServices : Service
    {
        public Contact Any(GetContact request)
        {
            return Db.SingleById<Contact>(request.Id);
        }

        public List<Contact> Any(FindContacts request)
        {
			using ( Profiler.Current.Step("Contacts Service"))
			{
	        	System.Threading.Thread.Sleep(1000);

	            return request.Age != null
	                ? Db.Select<Contact>(q => q.Age == request.Age)
	                : Db.Select<Contact>();
	        }
        }

        public Contact Post(CreateContact request)
        {
            //var contact = request.ConvertTo<Contact>();
			
			var contact = new Contact() {
				FullName = new NameDetail(request.FirstName, request.LastName),
				Email = request.Email,
				Age = request.Age
			};
			
            Db.Save(contact);
            return contact;
        }

        public void Any(DeleteContact request)
        {
            Db.DeleteById<Contact>(request.Id);
        }
		
		public List<Contact> Any(FindSpecialContacts request)
        {
            var contacts = Db.Select<Contact>(C => C.Tags.Contains(AvailableTags.glam));
            return contacts;
        }
    }
}
