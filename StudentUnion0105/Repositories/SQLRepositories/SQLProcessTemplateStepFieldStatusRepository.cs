using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateStepFieldStatusRepository : IProcessTemplateStepFieldStatusRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateStepFieldStatusRepository(SuDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuProcessTemplateStepFieldStatusModel> GetAllProcessTemplateStepFieldStatus()
        {
            return context.dbProcessTemplateStepFieldStatus;

        }

        public SuProcessTemplateStepFieldStatusModel GetProcessTemplateStepFieldStatus(int Id)
        {
            return context.dbProcessTemplateStepFieldStatus.Find(Id);
        }
    }
}
