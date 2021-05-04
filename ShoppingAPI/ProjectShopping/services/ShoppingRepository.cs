using ProjectShopping.DbContexts;
using ProjectShopping.Entities;
using ProjectShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.services
{
    public class ShoppingRepository : IShoppingRepository
    {
        private readonly ShopingDbContext _context;
        public ShoppingRepository(ShopingDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<Product> GetProducts()
        {
            Console.WriteLine("inside");
            var res = _context.products.ToList();
           foreach(var prod in res)
            {
                prod.Inventory = _context.stocks.Where(s => s.PID == prod.PID).ToList();
            }
            return res;
        }

        public IEnumerable<Product> GetProducts(String gender,String search)
        {
            if (String.IsNullOrWhiteSpace(gender) && String.IsNullOrWhiteSpace(search))
            {
                return GetProducts();
            }
            var collection = _context.products as IQueryable<Product>;
            if (!String.IsNullOrWhiteSpace(gender))
            {
                collection = collection.Where(p =>p.Gender.ToLower() == gender.ToLower());
            }
            if (!String.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                collection = collection.Where(p => p.MainCategory.ToLower() == search.ToLower());
            }

            return collection.ToList();
        }
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            product.PID = new Guid();
            foreach (var tag in product.TagList)
            {
                tag.PID = product.PID;  
            }
            foreach(var item in product.Inventory)
            {
                item.PID = product.PID;
            }
            _context.Add(product);
        }

        public Product GetProduct(Guid id)
        {
            Product p = _context.products.Find(id);
            Console.WriteLine("inside");
            var json = 
            p.Inventory = _context.stocks.Where(s => s.PID == id).ToList();
            return p;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return (_context.users);
        }
        public bool AddUser(User user)
        {
            var u = _context.users.Where(u => u.email == user.email);
            if (u.Count()!= 0)
            {
                return false;
            }
            user.UID = new Guid();
            _context.users.Add(user);
            return true;
        }
        public User validateUser(UserLoginDTO user) {
            Console.WriteLine(user.email + " " + user.password);
            var u = _context.users.Where(us => (us.email == user.email) && (us.password == user.password));
            if (u.Count() == 0)
            {
                return null;
            }
            return u.First();


        }
        public User validateUserAdmin(UserLoginDTO user)
        {
            Console.WriteLine(user.email + " " + user.password);
            var u = _context.users.Where(us => (us.email == user.email) && (us.password == user.password)&&(us.role=='A'));
            if (u.Count() == 0)
            {
                return null;
            }
            return u.First();


        }

        public void UpdateProduct()
        {

        }
        public void AddOrder(Order order,Guid uid)
        {
            order.OID = new Guid();
            order.UID = uid;
            order.oDate = DateTime.Today;
            float grandTotal = 0f;
            foreach(var item in order.CartItems)
            {
                item.CID = new Guid();
                Console.WriteLine(item.PID);
                item.OID = order.OID;
                item.UID = uid;

                grandTotal += ((int)item.price * (int)item.quantity);

            }
            
            order.total = grandTotal * 1.18;
            Console.WriteLine(order.total);
            _context.Add(order);
        }
        public IEnumerable<Order> GetOrders(Guid uid)
        {
            IEnumerable<Order> orders = _context.orders.Where(o => o.UID == uid).ToList();
            foreach(var order in orders)
            {
                order.CartItems = _context.carts.Where(item => item.OID == order.OID).ToList();
            }
            return orders;
        }

        public bool save()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
