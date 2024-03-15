using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Domain.Entities.Orders;
using CodeCampRestora.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Infrastructure.Data.Repositories
{
    [ScopedLifetime]
    public class OrderRepository : Repository<Order, Guid>, IOrderRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Order> _orderDbSet;
        public OrderRepository(IApplicationDbContext applicationDbContext)
            : base((DbContext)applicationDbContext)
        {
            _dbContext = (DbContext)applicationDbContext;
            _orderDbSet = _dbContext.Set<Order>();
        }

        public async Task<IList<Order>> GetOrdersByBranchId(
            Guid branchId,
            string includeProperties = "",
            int pageIndex = 1,
            int pageSize = 10)
        {
            IQueryable<Order> query = _orderDbSet;


            if (branchId != null)
            {
                query = query.Where(order => order.BranchId == branchId);
            }

            foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);


            var orderList = await result.ToListAsync();
            return orderList;
        }
    }
}
