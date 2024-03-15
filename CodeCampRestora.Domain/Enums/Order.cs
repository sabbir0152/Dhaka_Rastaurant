using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Domain.Enums
{
    public enum BookingType
    {
        Dining,
        Takeout
    }

    public enum OrderStatus
    {
        Placed,
        InProgress,
        Served,
        Calcelled
    }
}
