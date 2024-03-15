using CodeCampRestora.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order,Guid>
    {
        Task<IList<Order>> GetOrdersByBranchId(
            Guid branchId,
            string includeProperties = "",
            int pageIndex = 1,
            int pageSize = 10);
    }
}
