using ProjectShopping.Entities;
using ProjectShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.services
{
    public interface IShoppingRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);

        Product GetProduct(Guid id);
        IEnumerable<User> GetAllUsers();
        public IEnumerable<Product> GetProducts(String gender,String search);
        bool AddUser(User user);
        User validateUser(UserLoginDTO user);
        public User validateUserAdmin(UserLoginDTO user);

        void UpdateProduct();

        void AddOrder(Order order,Guid uid);
        IEnumerable<Order> GetOrders(Guid  uid);
        bool save();
    }
}
