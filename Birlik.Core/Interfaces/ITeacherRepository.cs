using Birlik.Data.Models;

namespace Birlik.Core.Interfaces
{
    public interface ITeacherRepository : IAsyncRepository<Teacher>
    {
        public Task<Teacher> GetAsync(string UIN);
    }
}