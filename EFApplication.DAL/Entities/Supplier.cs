using System;
using System.Collections.Generic;

namespace EFApplication.DAL.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public static implicit operator Supplier(string v)
        {
            throw new NotImplementedException();
        }
    }
}