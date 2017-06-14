using QualityMeter.Core.Interfaces;
using QualityMeter.Core.Interfaces.Repository;
using QualityMeter.Core.Models;

namespace QualityMeter.Core.Services
{
    public class CriteriaService : GenericService<Criteria>
    {
        public CriteriaService(IGenericRepository<Criteria> oRepository, ILog oLogging) : base(oRepository, oLogging)
        {
        }
    }
}
