using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AutherDbRepository: iBookStoreRepository<Auther>
    {
        BookStoreDbContext db;

        public AutherDbRepository(BookStoreDbContext _db)
        {
            db = _db;
        }
        
        public void Add(Auther element)
        {
            db.Authers.Add(element);
            db.SaveChanges();
        }

        public void Delete(int _id)
        {
            var auther = Find(_id);
            db.Authers.Remove(auther);
            db.SaveChanges();
        }

        public Auther Find(int _id)
        {
            var auther = db.Authers.SingleOrDefault(a => a.id == _id);
            return auther;
        }

        public IList<Auther> List()
        {
            return db.Authers.ToList();
        }

        public void Update(int _id, Auther element)
        {
            db.Update(element);
            db.SaveChanges();
        }
    }
}
