using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Collections.Generic;

namespace StudentUnion0105.SQLRepositories
{
    public class SQLProcessTemplateGroupRepository : IProcessTemplateGroupRepository
    {
        private readonly SuDbContext context;

        public SQLProcessTemplateGroupRepository(SuDbContext context)
        {
            this.context = context;
        }
        public SuProcessTemplateGroupModel AddProcessTemplateGroup(SuProcessTemplateGroupModel suProcessTemplateGroup)
        {
            context.DbProcessTemplateGroup.Add(suProcessTemplateGroup);
            context.SaveChanges();
            return suProcessTemplateGroup;
        }

        public SuProcessTemplateGroupModel DeleteProcessTemplateGroup(int Id)
        {
            var suProcessTemplateGroup = context.DbProcessTemplateGroup.Find(Id);
            if (suProcessTemplateGroup != null)
            {
                context.DbProcessTemplateGroup.Remove(suProcessTemplateGroup);
                context.SaveChanges();

            }
            return suProcessTemplateGroup;
        }

        public IEnumerable<SuProcessTemplateGroupModel> GetAllProcessTemplateGroups()
        {
            return context.DbProcessTemplateGroup;

        }

        public SuProcessTemplateGroupModel GetProcessTemplateGroup(int Id)
        {
            return context.DbProcessTemplateGroup.Find(Id);
        }

        public SuProcessTemplateGroupModel UpdateProcessTemplateGroup(SuProcessTemplateGroupModel suProcessTemplateGroupChanges)
        {
            var changedProcessTemplateGroup = context.DbProcessTemplateGroup.Attach(suProcessTemplateGroupChanges);
            changedProcessTemplateGroup.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return suProcessTemplateGroupChanges;

        }
    }
}
