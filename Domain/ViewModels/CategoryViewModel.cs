using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        //public List<Book> Books { get; set; }
        public bool IsValide
        {
            get
            {
                return (!string.IsNullOrEmpty(Name));
            }
        }
    }
}
