using PublishingActivity.DAL.Entities;
using System;

namespace PublishingActivity.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ProfessorProfile item);
        void Update(ProfessorProfile item);
        ProfessorProfile GetById(string id);
    }
}