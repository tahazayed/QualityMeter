using QualityMeter.Core.Interfaces;
using QualityMeter.Core.Interfaces.Repository;
using QualityMeter.Core.Models;

namespace QualityMeter.Core.Services
{
    public class ApplicationService : GenericService<Application>
    {
        public ApplicationService(IGenericRepository<Application> oRepository, ILog oLogging) : base(oRepository, oLogging)
        {
        }
    }
}
