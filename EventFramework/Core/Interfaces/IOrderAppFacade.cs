using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Query;

namespace Core.Interfaces
{
    public interface IOrderAppFacade
    {
        int AddOrder(string title);
        OrderQuery OrderQuery { get; }
    }
}
