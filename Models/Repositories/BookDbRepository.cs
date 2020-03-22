using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookDbRepository : iBookStoreRepository<Book>
    {
        BookStoreDbContext db;

        public BookDbRepository(BookStoreDbContext _db)
        {
            db = _db;
        }

        public void Add(Book element)
        {
            db.Books.Add(element);
            db.SaveChanges();
        }

        public void Delete(int _id)
        {
            var book = Find(_id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public Book Find(int _id)
        {
            var book = db.Books.Include(a=>a._auther).SingleOrDefault(a => a.id == _id);
            return book;
        }

        public IList<Book> List()
        {
            return db.Books.Include(a=>a._auther).ToList();
        }

        public List<Book> Search(string term)
        {
            return db.Books.Where(a => a.Title.Contains(term)).ToList();
        }

        public void Update(int _id, Book element)
        {
            db.Update(element);
            db.SaveChanges();
        }
    }
}