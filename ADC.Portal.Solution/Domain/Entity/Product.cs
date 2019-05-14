using ADC.Portal.Solution.Domain.Entity.Common;
using System;

namespace ADC.Portal.Solution.Domain.Entity
{
    public class Product : EntityBase
    {
        public Product()
        {
            Id = Guid.NewGuid();
            CreatedIn = DateTime.Now;
            ChangedIn = DateTime.Now;
        }

        public Product(string name, 
                       int code,                        
                       double price)
            :this()
        {
            Name = name;
            Code = code;
            
        }

        public string Name { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Kind { get; set; }
    }
}
