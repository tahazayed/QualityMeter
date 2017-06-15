using QualityMeter.Core.Interfaces;
using QualityMeter.Core.Interfaces.Repository;
using QualityMeter.Core.Models;

namespace QualityMeter.Core.Services
{
    public class ApplicationEvaluationService : GenericService<ApplicationEvaluation>
    {
        public ApplicationEvaluationService(IGenericRepository<ApplicationEvaluation> oRepository, ILog oLogging) : base(oRepository, oLogging)
        {
        }
    }
}
