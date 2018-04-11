using System.Collections.Generic;

namespace DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
