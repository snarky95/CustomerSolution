using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSolutions.Models.Customer
{
    public class Customer : ICustomer
    {
        public int ID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }
        [DisplayName("Social Security Number")]
        public string SSN { get; set; }

        public Customer()
        {

        }
        /*
         * Simple method to grab customer data, in a live situation, this would be from a database 
         * John Smith tests matching first name, last name, and birthdate
         * Peter Capaldi tests matching first name and last name but not birthdate
         * Donna Noble tests single user with Full name
         * Any other entry tests graceful handling of name not in Data
         */
        public List<Customer> getCustomerList()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { ID = 1, FirstName = "John", LastName = "Smith", DOB = new DateTime(1985, 01, 30), SSN = "123-45-678" },
                new Customer { ID = 2, FirstName = "Peter", LastName = "Capaldi", DOB = new DateTime(1974, 05, 24), SSN = "515-96-478" },
                new Customer { ID = 3, FirstName = "Peter", LastName = "Capaldi", DOB = new DateTime(1981, 04, 28), SSN = "564-45-852" },
                new Customer { ID = 4, FirstName = "John", LastName = "Smith", DOB = new DateTime(1985, 01, 30), SSN = "111-02-521" },
                new Customer { ID = 5, FirstName = "Donna", LastName = "Noble", DOB = new DateTime(1991, 07, 12), SSN = "564-54-852" }

            };
            return customers;
        }
        /*
         * Search customer DB for names user searched
         * Cases: User not in database, only one user for given name, more than one user for given name, multiple users share first last name and birthdate
         */
        public string compareData(List<Customer> customerList, string firstName, string lastName)
        {
            string returnData = "Sorry, there are no customers by that name, pelase try again."; //user not in DB
            List<Customer> filteredCustomers = customerList.Where(i => i.FirstName == firstName && i.LastName == lastName).ToList();
            if(filteredCustomers.Count == 1)//only one user, good to go
            {
                returnData = "Only one customer has this first and last name. Thanks for checking!";
            }
            else if (filteredCustomers.Count > 1)
            {//multiple users share first and last name
                for (int i = 0; i < filteredCustomers.Count; i++)
                {
                    List<Customer> CustomerMatchDOB = filteredCustomers.FindAll(j => j.DOB == filteredCustomers[i].DOB);
                    if (CustomerMatchDOB.Count > 1)
                    {//users share first name, last name, and birthdate
                        returnData = "More than one customer has this name and share the same birthdate! Be sure to confirm their identity via Social Security Number.";
                    }
                    else
                    { //users only share first an last name
                        returnData = "More than one customer has this name! Be sure to confrim their identity via birthdate or Social Security Number.";
                    }
                }
            }

            return returnData;
        }
    }
}
