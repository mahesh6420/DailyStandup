using DailyStandup.Entities.Models;
using DailyStandup.Entities.Models.Standup;
using DailyStandup.Entities.ViewModels.Standup;
using DailyStandup.Infrastructure.Interfaces.IRepository;
using DailyStandup.Infrastructure.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IBaseRepository _repository;

        public ProjectService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public Task<DataResult> Create(ProjectViewModel viewModel)
        {
            Project model = new Project
            {
                Name = viewModel.Name,
                ShortDescription = viewModel.ShortDescription,
                LongDescription = viewModel.LongDescription,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsArchieved = false
            };

            return _repository.Create<Project>(model);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _repository.GetAllAsync<Project>().ToList();
        }

        public async Task<Project> GetById(Guid id)
        {
            return await _repository.GetById<Project, Guid>(id);
        }
    }
}
