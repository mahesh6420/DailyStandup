using DailyStandup.Common.Enums;
using DailyStandup.Entities.Models;
using DailyStandup.Entities.Models.Standup;
using DailyStandup.Entities.ViewModels.Standup;
using DailyStandup.Infrastructure.Interfaces.IRepository;
using DailyStandup.Infrastructure.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Services
{
    public class StandupService : IStandupService
    {
        private readonly IBaseRepository _repository;

        public StandupService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public Task<DataResult> Create(WorkViewModel viewModel)
        {
            Work model = new Work
            {
                Description = viewModel.Description,
                ProjectId = viewModel.ProjectId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            return _repository.Create<Work>(model);
        }

        public async Task<IEnumerable<Work>> GetAll(/*Work args = null*/)
        {
            return await _repository.GetAllAsync<Work>().ToList();/*Where(predicate(args))*/
        }

        public async Task<IEnumerable<Work>> GetAllByDate(DateTime date)
        {
            return await _repository.GetAllAsync<Work>().Where(a => a.CreatedDate == date).ToList();
        }

        //Func<Work, bool> predicate(Work args)
        //{
        //    if(args.CreatedDate.Date.ToShortDateString().ToLowerInvariant() == Day.Today.ToString().ToLowerInvariant())
        //    {
        //        return args.CreatedDate.Date.Day;
        //    }
        //}

        public async Task<Project> GetById(Guid id)
        {
            return await _repository.GetById<Project, Guid>(id);
        }
    }
}
