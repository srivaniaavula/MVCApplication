using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppication.Models
{
    public class CustomerModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName{get;set;}
        public string LastName { get; set; }
        public string AddressPhone { get; set; }
    }
}