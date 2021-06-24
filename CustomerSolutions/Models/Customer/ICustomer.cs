using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSolutions.Models.Customer
{
    public interface ICustomer
    {
        public List<Customer> getCustomerList();
        public string compareData(List<Customer> customerList, string firstName, string lastName);
    }
}
