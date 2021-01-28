using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OrderProject.Models;

namespace OrderProject.Repositories
{
    public class CustomerRepository:ICustomer
    {
        private readonly OrderContext _context;

        public CustomerRepository()
        {
            _context = new OrderContext(); 
        }

        public CustomerRepository(OrderContext context)  
        {  
            _context = context;  
        } 
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();  
        }

        public IEnumerable<Customer> SearchMobile(string field)
        {
            
            return _context.Customers.Where(i => i.MobileNo ==field).ToList();
        }

        public bool SearchFullName(string field)
        {
            return !_context.Customers.Any(i => i.Fullname == field);
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);  
        }

        public void AddCustomer(Customer customer)
        {
            
            _context.Customers.Add(customer);
            Save(); 
        }

        public void UpdateCustomer(Customer customer)
        {
            customer.TimeStamp = DateTime.Now;
            customer.UserId = "User 1";
            _context.Entry(customer).State = EntityState.Modified;  
        }

        public void DeleteCustomer(int id)
        {
            var employee = _context.Customers.Find(id);
            if (employee != null) _context.Customers.Remove(employee);  
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }  
    }
}