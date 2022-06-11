using System.Data.Entity;
using PublishingActivity.DAL.EF;
using PublishingActivity.DAL.Entities;
using PublishingActivity.DAL.Interfaces;
using System.Linq;

namespace PublishingActivity.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }
 
        public void Create(ProfessorProfile item)
        {
            Database.ProfessorProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Update(ProfessorProfile item)
        {
            Database.Entry(item).State = EntityState.Modified;
            Database.SaveChanges();
        }

        public ProfessorProfile GetById(string id)
        {
            var entity = Database.ProfessorProfiles.FirstOrDefault(e => e.Id == id);

            return entity;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}