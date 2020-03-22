using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AutherRepository : iBookStoreRepository<Auther>
    {
        IList<Auther> authers;
        public AutherRepository()
        {
            authers = new List<Auther>()
            {
                new Auther {id = 1, FullName = "Naguib Mahfouz"},
                new Auther {id = 2, FullName = "Khaula Hamdy"},
            };
        }
        public void Add(Auther element)
        {
            element.id = authers.Max(a => a.id) + 1;
            authers.Add(element);
        }

        public void Delete(int _id)
        {
            var auther = Find(_id);
            authers.Remove(auther);
        }

        public Auther Find(int _id)
        {
            var auther = authers.SingleOrDefault(a => a.id == _id);
            return auther;
        }

        public IList<Auther> List()
        {
            return authers;
        }

        public List<Auther> Search(string term)
        {
            return authers.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int _id, Auther element)
        {
            var auther = Find(_id);
            auther.FullName = element.FullName;
        }
    }
}
