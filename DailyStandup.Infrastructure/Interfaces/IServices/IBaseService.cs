using DailyStandup.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Interfaces.IServices
{
    public interface IBaseService<TModel, TViewModel, TKey> where TModel : class where TViewModel: class
    {
        Task<DataResult> Create(TViewModel viewModel);
        Task<DataResult> Update(TViewModel viewModel);
        Task<IEnumerable<TViewModel>> GetAll(string day = null);
        Task<TViewModel> GetById(TKey key);
    }
}
