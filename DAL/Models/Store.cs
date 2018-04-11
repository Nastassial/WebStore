using System.Collections.Generic;

namespace DAL.Models
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string WorkingTime { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
