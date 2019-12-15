using SohailBookStore.Data;
using SohailBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;


namespace SohailBookStore.Services
{
    public class SqlOrderRepository : IRepository<Order>
    {
        private SohailBookStoreDbContext context;
        public SqlOrderRepository(SohailBookStoreDbContext _context)
        {
           context = _context;
        }
        public bool Add(Order item)
        {
            try
            {
                context.Add(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Order item)
        {
            try
            {
                if (Get(item.Id) != null)
                {
                    context.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Order item)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            if (context.Orders.Count(x => x.Id == id) > 0)
            {
                return context.Orders.FirstOrDefault(x => x.Id == id);

            }
            else return null;
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders;
        }
    }
}
