using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.DTOs
{
    public class ReadAllBooksDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Language { get; set; }

        public decimal PurchasePrice { get; set; }
    }
}
