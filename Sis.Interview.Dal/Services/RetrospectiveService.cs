using Sis.Interview.Dal.Framework;
using Sis.Interview.Models.ScrumCeremony;

namespace Sis.Interview.Dal.Services
{
    public class RetrospectiveService : BaseService<Retrospective>
    {
        public RetrospectiveService(IRepository<Retrospective> repository): base(repository)
        { 
        }
    }
}