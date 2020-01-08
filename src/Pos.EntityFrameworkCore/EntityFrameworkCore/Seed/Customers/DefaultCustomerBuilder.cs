using Pos.Customers;
using System.Collections.Generic;
using System.Linq;

namespace Pos.EntityFrameworkCore.Seed.Customers
{
    public class DefaultCustomerBuilder
    {
        private readonly PosDbContext _context;

        public DefaultCustomerBuilder(PosDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultCustomer();
        }

        private void CreateDefaultCustomer()
        {
            //Default customer

            if (!_context.Customers.Any())
            {
                var defaultCustomers = new List<Customer>
                {
                    new Customer { CustomerName="Hisham Hafeel", AddressLine1="No.33, Marukona Watta, Ukuwela, Matale", AddressLine2="", Email="hisham_89@live.com", Phone="0771233625", CreditCard="4111 1111 1111 1111"},
                    new Customer { CustomerName="Raes Samman", AddressLine1="No.176, Arthurs Place, Nugegoda, Colombo", AddressLine2="", Email="raess@gmail.com", Phone="0770987654", CreditCard="4123 1671 1441 1775"},
                    new Customer { CustomerName="Roshan Ahmed", AddressLine1="No.44, Hill Street, Dehiwela, Colombo", AddressLine2="", Email="roshan@gmail.com", Phone="0765552221", CreditCard="0075 1997 1098 1998"}
                };

                _context.Customers.AddRange(defaultCustomers);
            }
        }
    }
}
