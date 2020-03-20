using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookAutherViewModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AutherID { get; set; }
        public List<Auther> Authers  { get; set; }
    }
}
