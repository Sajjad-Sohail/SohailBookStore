using SohailBookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;
namespace SohailBookStore.Services
{
    public class SqlCarouselRepository : IRepository<Carousel>
    {
        private SohailBookStoreDbContext context;

        public SqlCarouselRepository(SohailBookStoreDbContext _context)
        {
                context=_context;
        }
        public bool Add(Carousel item)
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

        public bool Delete(Carousel item)
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

        public bool Edit(Carousel item)
        {
            throw new NotImplementedException();
        }

        public Carousel Get(int id)
        {
            if (context.Carousels.Count(x => x.Id == id) > 0)
            {
                return context.Carousels.FirstOrDefault(x => x.Id == id);

            }
            else return null;
        }

        public IEnumerable<Carousel> GetAll()
        {
            Console.WriteLine("inside carousel");
            Console.WriteLine(context.Carousels.Find(1));
            return context.Carousels;
        }
    }
}
