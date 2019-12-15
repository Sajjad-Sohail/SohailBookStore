using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Carousel> Carousels { get; set; }

    }
}
