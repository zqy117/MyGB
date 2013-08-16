using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OrderEntity
    {
        public int OrderID { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        //other fields
    }
}
