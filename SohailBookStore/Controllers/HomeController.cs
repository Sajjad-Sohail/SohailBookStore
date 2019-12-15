using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SohailBookStore.Models;
using SohailBookStore.ViewModels;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
     
        IRepository<Book> _BookRepo;
        IRepository<Carousel> _CarouselRepo;
        IRepository<Order> _orderRep;
        public HomeController(IRepository<Book> book, IRepository<Carousel> carousel, IRepository<Order> order)
        {
            _BookRepo = book;
            _CarouselRepo = carousel;
            _orderRep = order;
        }
       
        public IActionResult Index()
        {

            HomeIndexViewModel model = new HomeIndexViewModel() {
                Books = _BookRepo.GetAll(),
                Carousels = _CarouselRepo.GetAll()
            
            };
            Console.WriteLine("Inside index: before Printing list:***");
            for (int i = 1; i < model.Carousels.ToList().Count; i++) {
                Console.WriteLine(model.Carousels.ToList().ElementAt(i).ImageURL);
            }
            
            Console.WriteLine("Inside index: after Printing list:***");

            return View(model);
        }

        [HttpGet]
        public IActionResult AddBook()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            { 
            Book item = new Book()
            {
                Id = _BookRepo.GetAll().Max(m => m.Id) + 1,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                PublishDate = book.PublishDate,
                image = book.image

            };
            _BookRepo.Add(item);
            return RedirectToAction("Index");
        }
        else{
        return View();
        }
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact() {

            return View();
        
        }
        public IActionResult Details(int id)
        {
            Book book = _BookRepo.Get(id);
            return View(book);
        }
        [HttpGet]
        public IActionResult Order(int? id)
        {
            if(id!=null && id > 0)
            {
                OrderViewModel model = new OrderViewModel()
                {
                    BookToOrder = _BookRepo.Get((int)id),
                    OrderDetails = new Order()
                    {
                        BookId = (int)id
                    }
                };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Order(int id,Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                if(_BookRepo.GetAll().Count(x=>x.Id == id) >= 1)
                {
                    orderDetails.BookId = id;
                    _orderRep.Add(orderDetails);
                    return RedirectToAction("ThankYou");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(new OrderViewModel()
                {
                    OrderDetails = orderDetails,
                    BookToOrder = _BookRepo.Get(id)
                });
            }
        }
        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult OrdersList()
        {
            return View(_orderRep.GetAll());
        }
    }
}
