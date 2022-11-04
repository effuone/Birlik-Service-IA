using Birlik.Core.Interfaces;
using Birlik.Data.Context;
using Birlik.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Birlik.Core.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly BirlikDbContext _context;

        public FileRepository(BirlikDbContext context)
        {
            _context = context;
        }


        public async Task<int> CreateFileAsync(string env, string path, IFormFile uploadFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await uploadFile.CopyToAsync(memoryStream);
                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    if(!Directory.Exists(env + $"{path}"))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = uploadFile.FileName;
                    var physicalPath = env + @$"{path}/" + fileName;
                    using(var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(stream);
                        using(var ms = new MemoryStream())
                        {
                            await uploadFile.CopyToAsync(ms);
                        }
                    }
                    var model = new FileModel();
                    model.FilePath = physicalPath;
                    model.FileName = uploadFile.FileName;
                    await _context.Files.AddAsync(model);
                    await _context.SaveChangesAsync();
                    return model.Id; 
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _context.Files.FindAsync(id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<FileModel> GetAsync(string path)
        {
             return await _context.Files.Where(x=>x.FilePath == path).FirstOrDefaultAsync();
        }

        public async Task<FileModel> GetAsync(int id)
        {
             return await _context.Files.FindAsync(id);
        }

        public async Task UpdateAsync(int id, FileModel model, IFormFile uploadFile)
        {
            model.Id = id;
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}