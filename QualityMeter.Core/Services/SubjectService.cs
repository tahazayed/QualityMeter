using QualityMeter.Core.Interfaces;
using QualityMeter.Core.Interfaces.Repository;
using QualityMeter.Core.Models;

namespace QualityMeter.Core.Services
{
    public class SubjectService : GenericService<Subject>
    {
        public SubjectService(IGenericRepository<Subject> oRepository, ILog oLogging) : base(oRepository, oLogging)
        {
        }
    }
}
