using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateStepRepository : IProcessTemplateStepRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateStepRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateStepModel AddProcessTemplateStep(SuProcessTemplateStepModel suProcessTemplateStep)
        {
            context.dbProcessTemplateStep.Add(suProcessTemplateStep);
            context.SaveChanges();
            return suProcessTemplateStep;
        }

        public SuProcessTemplateStepModel DeleteProcessTemplateStep(int Id)
        {
            var suProcessTemplateStep = context.dbProcessTemplateStep.Find(Id);
            if (suProcessTemplateStep != null)
            {
                context.dbProcessTemplateStep.Remove(suProcessTemplateStep);
                context.SaveChanges();

            }
            return suProcessTemplateStep;
        }

        public IEnumerable<SuProcessTemplateStepModel> GetAllProcessTemplateSteps()
        {
            return context.dbProcessTemplateStep;

        }

        public SuProcessTemplateStepModel GetProcessTemplateStep(int Id)
        {
            return context.dbProcessTemplateStep.Find(Id);
        }

        public SuProcessTemplateStepModel UpdateProcessTemplateStep(SuProcessTemplateStepModel suProcessTemplateStepChanges)
        {
            var changedProcessTemplateStep = context.dbProcessTemplateStep.Attach(suProcessTemplateStepChanges);
            changedProcessTemplateStep.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateStepChanges;

        }
    }
}
