using QualityMeter.Core.Interfaces;
using QualityMeter.Core.Interfaces.Repository;
using QualityMeter.Core.Models;

namespace QualityMeter.Core.Services
{
    public class FactorService : GenericService<Factor>
    {
        public FactorService(IGenericRepository<Factor> oRepository, ILog oLogging) : base(oRepository, oLogging)
        {
        }
    }
}
