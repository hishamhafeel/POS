using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Customers.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CreditCard { get; set; }
    }
}
