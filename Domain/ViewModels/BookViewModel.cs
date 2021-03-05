using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Href { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public bool IsValide { get
            {
                return (!string.IsNullOrEmpty(Name)) ||
                       (!string.IsNullOrEmpty(Author)) ||
                       (!string.IsNullOrEmpty(Href));
            } 
        }
    }
}
