using System.Collections.Generic;
using project.Data.Models;


namespace project.Service.ViewModels
{
    public class ShoppingViewModel
    {
        public List<Store> Stores { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
    
    }
}