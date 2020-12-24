using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFApplication.WEBv1.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int Id { get; set; }
    }
}
