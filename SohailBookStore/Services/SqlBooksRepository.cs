using SohailBookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace SohailBookStore.Services
{
    public class SqlBooksRepository : IRepository<Book>
    {
        private SohailBookStoreDbContext context;

        public SqlBooksRepository(SohailBookStoreDbContext _context)
        {
            context = _context;
        }
        public bool Add(Book item)
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

        public bool Delete(Book item)
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

        public bool Edit(Book item)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            if (context.Books.Count(x => x.Id == id) > 0)
            {
                return context.Books.FirstOrDefault(x => x.Id == id);

            }
            else return null;
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books;
        }
    }
}
