using System;
using System.Threading.Tasks;
using project.Data.Models;

namespace project.Service.Services
{
    public interface IStoreService
    {
        Task<Store> AddStoreAsync(Store store);
    }
}