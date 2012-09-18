using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OKU.Core.Entities.PageStructure;
using OKU.Core.Entities;

namespace OKU.Core.Repositories.Implementation
{
    public class ExecutionDefinitionRepository : RepositoryBase<OkuDbContext, ExecutionDefinition>, IExecutionDefinitionRepository
    {
        public ExecutionDefinitionRepository()
        {
            this.Initialize(x => x.ExecutionDefinitions);
        }

        public List<int> AvailablePageSets(int IterationId)
        {
            List<int> availablePageSetIds = new List<int>();
            List<ExecutionDefinition> definitions = DbContext.ExecutionDefinitions.Where(x => x.IterationId == IterationId && x.IsActive == true && x.IsFinished == false).ToList();
            foreach (var definition in definitions)
            {
                availablePageSetIds.Add(definition.PageSetId.Value);
            }
            return availablePageSetIds;
        }

        public bool SetExecutionDefinitionFinished(int pageSetId, int userId)
        {
            var executionDefinition = this.DbContext.ExecutionDefinitions.Where(x => x.PageSetId == pageSetId).FirstOrDefault();


            if (executionDefinition == null)
            {
                return false;
            }

            executionDefinition.IsFinished = true;
            executionDefinition.ExecutionFinished = DateTime.Now;
            executionDefinition.ExecutedByUserId = userId;
            this.DbContext.SaveChanges();

            return true;

            
        }
    }
}
