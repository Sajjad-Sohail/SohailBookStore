using SohailBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace SohailBookStore.ViewModels
{
    public class OrderViewModel
    {
        public Book BookToOrder { get; set; }
        public Order OrderDetails { get; set; }
    }
}
