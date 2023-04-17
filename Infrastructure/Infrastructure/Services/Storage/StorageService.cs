using Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;
        public StorageService(IStorage storage) => _storage = storage;


        public string StorageName { get => _storage.GetType().Name; }

        public Task DeleteAsync(string pathName, string fileName) => _storage.DeleteAsync(pathName, fileName);

        public List<string> GetFiles(string pathName) => _storage.GetFiles(pathName);

        public bool HasFile(string pathName, string fileName)=> _storage.HasFile(pathName,fileName);

        public Task<List<(string fileName, string pathName)>> UploadAsync(string pathName, IFormFileCollection files)
               => _storage.UploadAsync(pathName, files);
    }
}
