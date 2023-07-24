using Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public float price { get; set; }
    }
}