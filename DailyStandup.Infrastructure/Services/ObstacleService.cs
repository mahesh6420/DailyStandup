using DailyStandup.Common.Enums;
using DailyStandup.Entities.Models;
using DailyStandup.Entities.Models.Standup;
using DailyStandup.Entities.ViewModels.Standup;
using DailyStandup.Infrastructure.Interfaces.IRepository;
using DailyStandup.Infrastructure.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Services
{
    public class ObstacleService : IObstacleService
    {
        private readonly IBaseRepository _repository;

        public ObstacleService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<DataResult> Create(ObstacleViewModel viewModel)
        {
            try
            {
                Obstacle model = new Obstacle
                {
                    Description = viewModel.Description,
                    WorkYesterdayId = viewModel.WorkId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                return await _repository.Create<Obstacle>(model);
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

        public async Task<DataResult> Update(ObstacleViewModel viewModel)
        {
            try
            {
                Obstacle model = new Obstacle
                {
                    Id = viewModel.Id,
                    Description = viewModel.Description,
                    WorkYesterdayId = viewModel.WorkId,
                    UpdatedDate = DateTime.Now
                };

                return await _repository.Update<Obstacle>(model);
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

        public async Task<IEnumerable<ObstacleViewModel>> GetAll(string day = null)
        {
            IQueryable<Obstacle> result = null;
            if (day != null)
            {
                if (day.ToLowerInvariant() == Day.Today.ToString().ToLowerInvariant())
                {
                    result =  _repository.GetAllAsync<Obstacle>().Where(w => w.CreatedDate.Date == DateTime.Today);
                }

                if (day.ToLowerInvariant() == Day.Yesterday.ToString().ToLowerInvariant())
                {
                    result = _repository.GetAllAsync<Obstacle>().Where(w => w.CreatedDate.Date == DateTime.Today.AddDays(-1));
                }

                if (day.ToLowerInvariant() == Day.Old.ToString().ToLowerInvariant())
                {
                    result = _repository.GetAllAsync<Obstacle>().Where(w => w.CreatedDate.Date < DateTime.Today.AddDays(-1));
                }
            }

            if(result == null) _repository.GetAllAsync<Obstacle>();/*Where(predicate(args))*/

            return await (from res in result
                          select new ObstacleViewModel
                          {
                              Id = res.Id,
                              Description = res.Description,
                              WorkId = res.WorkYesterdayId
                          }).ToListAsync();
        }

        //Func<Work, bool> predicate(string args)
        //{
        //    if(args.CreatedDate.Date.ToShortDateString().ToLowerInvariant() == Day.Today.ToString().ToLowerInvariant())
        //    {
        //        return args.CreatedDate.Date.Day;
        //    }
        //}


        public async Task<ObstacleViewModel> GetById(Guid id)
        {
             Obstacle model = await _repository.GetById<Obstacle, Guid>(id);
            return new ObstacleViewModel
            {
                Id = model.Id,
                Description = model.Description,
                Work = model.Work,
                WorkId = model.WorkYesterdayId
            }; 
        }
    }
}
