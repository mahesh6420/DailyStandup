using DailyStandup.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Interfaces.IRepository
{
    public interface IBaseRepository
    {
        Task<DataResult> Create<T>(T model) where T : class; 
        Task<DataResult> Update<T>(T model) where T : class;
        Task<DataResult> Delete<T>(T model) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        IAsyncEnumerable<T> GetAllAsync<T>() where T : class;
        Task<T> GetById<T, TKey>(TKey key) where T : class; 
    }
}
