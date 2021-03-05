using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Book
    {
     

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Href { get; set; }
        public int CategoryId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Сategory Category { get; set; }
    }
}
