using DailyStandup.Entities.Models;
using DailyStandup.Entities.Models.Standup;
using DailyStandup.Entities.ViewModels.Standup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Interfaces.IServices
{
    public interface IWorkService
    {
        Task<DataResult> Create(WorkViewModel viewModel);
        Task<DataResult> Update(WorkViewModel viewModel);
        Task<IEnumerable<Work>> GetAll(string day = null);
        Task<Work> GetById(Guid id);
    }
}
