using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookRepository : iBookStoreRepository<Book>
    {
        List<Book> books;

        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    id = 1, 
                    Title = "C# Programming", 
                    Description = "None",
                    _auther = new Auther(){ id = 2},
                    imgURL = "The_C_Programming.png"
                }
            };
        }

        public void Add(Book element)
        {
            element.id = books.Max(b => b.id) + 1;
            books.Add(element);
        }

        public void Delete(int _id)
        {
            var book = Find(_id);
            books.Remove(book);
        }

        public Book Find(int _id)
        {
            var book = books.SingleOrDefault(b => b.id == _id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int _id, Book new_element)
        {
            var book = Find(_id);
            book.Title = new_element.Title;
            book.Description = new_element.Description;
            book._auther = new_element._auther;
            book.imgURL = new_element.imgURL;
        }
    }
}
