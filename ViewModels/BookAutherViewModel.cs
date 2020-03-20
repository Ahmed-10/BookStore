using BookStore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookAutherViewModel
    {
        public int BookID { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 5)]
        public string Description { get; set; }
        public int AutherID { get; set; }
        public List<Auther> Authers  { get; set; }

        //[RegularExpression(@"[a-zA-Z0-9\s_\\.\-:])+(.png|.jpg)$")]
        public IFormFile File { get; set; }
    }
}
