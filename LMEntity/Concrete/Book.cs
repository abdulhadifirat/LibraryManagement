using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Entity.Concrete
{
    public sealed class Book : BaseEntity
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public bool StockStatus { get; set; }= true;
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
       

      
    }
}
