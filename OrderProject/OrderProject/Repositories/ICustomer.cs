using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProject.Models;

namespace OrderProject.Repositories
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        void Save(); 
    }
}
