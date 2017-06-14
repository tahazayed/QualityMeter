using QualityMeter.Core.Interfaces;
using QualityMeter.Core.Interfaces.Repository;
using QualityMeter.Core.Models;

namespace QualityMeter.Core.Services
{
    public class QualityAttributesMetricService : GenericService<QualityAttributesMetric>
    {
        public QualityAttributesMetricService(IGenericRepository<QualityAttributesMetric> oRepository, ILog oLogging) : base(oRepository, oLogging)
        {
        }
    }
}
