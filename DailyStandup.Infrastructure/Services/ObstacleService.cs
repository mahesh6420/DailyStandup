using DailyStandup.Common.Enums;
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

        public async Task<IEnumerable<Obstacle>> GetAll(string day = null)
        {
            if (day != null)
            {
                if (day.ToLowerInvariant() == Day.Today.ToString().ToLowerInvariant())
                {
                    return await  _repository.GetAllAsync<Obstacle>().Where(w => w.CreatedDate.Date == DateTime.Today).ToList();
                }

                if (day.ToLowerInvariant() == Day.Yesterday.ToString().ToLowerInvariant())
                {
                    return await _repository.GetAllAsync<Obstacle>().Where(w => w.CreatedDate.Date == DateTime.Today.AddDays(-1)).ToList();
                }

                if (day.ToLowerInvariant() == Day.Old.ToString().ToLowerInvariant())
                {
                    return await _repository.GetAllAsync<Obstacle>().Where(w => w.CreatedDate.Date < DateTime.Today.AddDays(-1)).ToList();
                }

                Obstacle[] works = new Obstacle[] { };
                return works.ToList();
            }

            return await _repository.GetAllAsync<Obstacle>().ToList();/*Where(predicate(args))*/
        }

        //Func<Work, bool> predicate(string args)
        //{
        //    if(args.CreatedDate.Date.ToShortDateString().ToLowerInvariant() == Day.Today.ToString().ToLowerInvariant())
        //    {
        //        return args.CreatedDate.Date.Day;
        //    }
        //}

        public async Task<Obstacle> GetById(Guid id)
        {
            return await _repository.GetById<Obstacle, Guid>(id);
        }
    }
}
