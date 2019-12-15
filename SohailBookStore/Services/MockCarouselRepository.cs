using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MockCarouselRepository : IRepository<Carousel>
    {
        List<Carousel> _carousels;

        public MockCarouselRepository()
        {
            _carousels = new List<Carousel>();
            _carousels.Add(new Carousel
            {
                Id = 0,
                Title = "Discounted books",
                Description = "Get Discounted books of all the authors",
                ImageURL = "car1.jpg"
            }) ;
            _carousels.Add(new Carousel
            {
                Id = 1,
                Title = "New books",
                Description = "All new brand books with great prices",
                ImageURL = "car2.jpg"
            });
            _carousels.Add(new Carousel
            {
                Id = 2,
                Title = "Subscription",
                Description = "Discount on monthly subcription any time",
                ImageURL = "car3.jpg"
            });
            
        }
        public bool Add(Carousel item)
        {

            try
            {
                Carousel carousel = item;
                carousel.Id = _carousels.Max(x => x.Id) + 1;
                _carousels.Add(carousel);
                return true;
            }
            catch (Exception e) {
                return false;
            
            }
        }

        public bool Delete(Carousel item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Carousel item)
        {
            throw new NotImplementedException();
        }

        public Carousel Get(int id)
        {
            return _carousels.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Carousel> GetAll()
        {
            return _carousels;
        }
    }
}
