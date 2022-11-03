using Birlik.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Birlik.Core.Interfaces
{
    public interface IFileRepository
    {
        public Task<FileModel> GetAsync(string path);
        public Task<FileModel> GetAsync(int id);
        public Task<int> CreateAsync(string env, FileModel model, IFormFile uploadFile);
        public Task UpdateAsync(int id, FileModel model, IFormFile uploadFile);
        public Task DeleteAsync(int id);
    }
}