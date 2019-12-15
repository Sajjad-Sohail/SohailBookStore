using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MockBooksRepository : IRepository<Book>
    {
        List<Book> _books;
        public MockBooksRepository()
        {
            _books = new List<Book>();
            _books.Add(new Book()
            {
                Id = 0,
                Title = "Software Architecture with C# 8 and .NET Core 5",
                Description = "Learn to build and run your first application with .NET Core MVC.",
                Author = "Ronnie Rahman",
                PublishDate = "July, 2018",
                image = "0.jpg"
            });
            _books.Add(new Book()
            {
                Id = 1,
                Title = "Unity Game Optimization",
                Description = "Learn to build optimized apps",
                Author = "Ronnie Rahman",
                PublishDate = "July, 2019",
                image = "1.jpg",
                Price=29.99
            });
            _books.Add(new Book()
            {
                Id = 2,
                Title = "Microsoft PowerApps",
                Description = "PowerApps development to fast development",
                Author = "Bruno Joseph D'mello, Sai Srinivas Sriparasa",
                PublishDate = "April, 2018",
                Price = 30,
                image = "2.jpg"
            });
            _books.Add(new Book()
            {
                Id = 3,
                Title = "Electron",
                Description = "Develop a simple, yet fully-functional modern web application using Electron",
                Author = "Valario De Sanctis",
                PublishDate = "November, 2017",
                Price = 20,
                image = "3.jpg"
            });
            _books.Add(new Book()
            {
                Id = 4,
                Title = "Nest.js",
                Description = "A Progressive Node.js Framework",
                Author = "Marino Posadas, tadit Dash",
                PublishDate = "November, 2017",
                Price = 25,
                image = "5.jpg"
            });
            _books.Add(new Book()
            {
                Id = 5,
                Title = "Vue.js",
                Description = "Understanding its tools and ecosystem",
                Author = "Loiane Groner",
                PublishDate = "April, 2018",
                Price = 29.99,
                image = "6.jpg"
            });
            _books.Add(new Book()
            {
                Id = 6,
                Title = "Java Deep Learning",
                Description = "Quick cook book about java",
                Author = "Ravi Sethi, Alfred Aho",
                PublishDate = "April, 2019",
                Price = 24.99,
                image = "7.jpg"
            });


            _books.Add(new Book()
            {
                Id = 7,
                Title = "Java Workshop",
                Description = "A new interactive approach to learning java",
                Author = "Timothy Fisher",
                PublishDate = "January, 2018",
                Price = 19.99,
                image = "8.jpg"
            });
            _books.Add(new Book()
            {
                Id = 8,
                Title = "Programming in C#",
                Description = "Learn to build on C#",
                Author = "Michael James Fitzgerald",
                PublishDate = "July, 2017",
                Price = 39.99,
                image = "9.jpg"
            });
            _books.Add(new Book()
            {
                Id = 9,
                Title = "The Ruby Workshop",
                Description = "A new interactive approach to learning ruby",
                Author = "Richard Petersen",
                PublishDate = "April, 2016",
                Price = 30,
                image = "11.jpg"
            });
            _books.Add(new Book()
            {
                Id = 10,
                Title = "Building forms with Vue.js",
                Description = "Develop a simple, yet fully-functional Vue Application",
                Author = "Michael James Fitzgerald",
                PublishDate = "February, 2017",
                Price = 20.99,
                image = "12.jpg"
            });
            _books.Add(new Book()
            {
                Id = 11,
                Title = "Testing Vue.js",
                Description = "Testing Components with Jest",
                Author = "James Edwards, Ara Pehlivanian",
                PublishDate = "November, 2019",
                Price = 30.99,
                image = "13.jpg"
            });
            _books.Add(new Book()
            {
                Id = 12,
                Title = "Visual Studio 2019",
                Description = "Mastering Visual studio 2019",
                Author = "Michael C. Daconta",
                PublishDate = "May, 2018",
                Price = 29.99,
                image = "4.jpg"
            });
            _books.Add(new Book()
            {
                Id = 13,
                Title = "C# 8.0 and .NET Core 3.0",
                Description = "Learn about XML",
                Author = "Simon St. Laurent, Michael James Fitzgerald",
                PublishDate = "April, 2018",
                Price = 24.99,
                image = "10.jpg"
            });

        }
        public bool Add(Book item)
        {
            try
            {
                Book book = item;
                book.Id = _books.Max(x => x.Id) + 1;
                _books.Add(item);
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        public bool Delete(Book item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Book item)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault( x => x.Id==id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.ToList();
        }
    }
}
