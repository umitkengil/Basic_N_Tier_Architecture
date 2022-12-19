using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:EntityBase,IEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public IList<Product> Products { get; set; }
    }
}
