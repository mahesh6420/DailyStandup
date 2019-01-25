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
    public class WorkService : IWorkService
    {
        private readonly IBaseRepository _repository;

        public WorkService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<DataResult> Create(WorkViewModel viewModel)
        {
            try
            {
                Work model = new Work
                {
                    Description = viewModel.Description,
                    ProjectId = viewModel.ProjectId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                return await _repository.Create<Work>(model);
            }
            catch(Exception ex)
            {
                return new DataResult
                {
                    Status = Status.Exception,
                    Message = $"{ex.Message}"
                };
            }
        }

        public async Task<DataResult> Update(WorkViewModel viewModel)
        {
            try
            {
                Work model = new Work
                {
                    Id = viewModel.Id,
                    Description = viewModel.Description,
                    ProjectId = viewModel.ProjectId,
                    UpdatedDate = DateTime.Now
                };

                return await _repository.Update<Work>(model);
            }
            catch (Exception ex)
            {
                return new DataResult
                {
                    Status = Status.Exception,
                    Message = $"{ex.Message}"
                };
            }
        }

        public async Task<IEnumerable<Work>> GetAll(string day = null)
        {
            if(day!=null)
            {
                if(day.ToLowerInvariant() == Day.Today.ToString().ToLowerInvariant())
                {
                    return await _repository.GetAllAsync<Work>().Where(w => w.CreatedDate.Date == DateTime.Today).ToList();
                }

                if (day.ToLowerInvariant() == Day.Yesterday.ToString().ToLowerInvariant())
                {
                    return await _repository.GetAllAsync<Work>().Where(w => w.CreatedDate.Date == DateTime.Today.AddDays(-1)).ToList();
                }

                if (day.ToLowerInvariant() == Day.Old.ToString().ToLowerInvariant())
                {
                    return await _repository.GetAllAsync<Work>().Where(w => w.CreatedDate.Date < DateTime.Today.AddDays(-1)).ToList();
                }

                Work[] works = new Work[] { };
                return works.ToList();
            }

            return await _repository.GetAllAsync<Work>().ToList();/*Where(predicate(args))*/
        }

        //Func<Work, bool> predicate(string args)
        //{
        //    if(args.CreatedDate.Date.ToShortDateString().ToLowerInvariant() == Day.Today.ToString().ToLowerInvariant())
        //    {
        //        return args.CreatedDate.Date.Day;
        //    }
        //}

        public async Task<Work> GetById(Guid id)
        {
            return await _repository.GetById<Work, Guid>(id);
        }

    }
}
