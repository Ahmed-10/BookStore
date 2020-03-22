using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public interface iBookStoreRepository<Type>
    {
        IList<Type> List();
        Type Find(int _id);
        void Add(Type element);
        void Update(int _id, Type element);
        void Delete(int _id);
        List<Type> Search(string term);
    }
}
