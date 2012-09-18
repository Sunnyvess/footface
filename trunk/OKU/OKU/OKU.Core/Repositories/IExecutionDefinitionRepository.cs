using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OKU.Core.Entities.PageStructure;
using OKU.Core.Entities;

namespace OKU.Core.Repositories
{
    public interface IExecutionDefinitionRepository : IRepository<ExecutionDefinition>
    {
        List<int> AvailablePageSets(int IterationId);

        bool SetExecutionDefinitionFinished(int pageSetId, int userId);
    }
}
