using DeliveriApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriApp.DataAccess.Query
{
    public class GetOrderByTime : IRequestHendler<int>
    {
        public Task HendlerAsync(int request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
