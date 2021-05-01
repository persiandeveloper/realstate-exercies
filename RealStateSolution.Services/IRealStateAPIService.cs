using RealStateSolution.Services.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static RealStateSolution.Services.Domain.RealstateResult;

namespace RealStateSolution.Services
{
    public interface IRealStateAPIService
    {
        Task<IEnumerable<RealStateObject>> GetByAgentsOrderByCountAsync();

        Task<IEnumerable<RealStateObject>> GetTopTenAsync();
    }
}
