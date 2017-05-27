using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppication.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
            this.addresses = new List<address>();
        }

        public IList<address> addresses { get; set; }

        public class address
        {
            public int? Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}