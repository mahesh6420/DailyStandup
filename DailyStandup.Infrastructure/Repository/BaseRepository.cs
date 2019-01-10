using DailyStandup.Common.Enums;
using DailyStandup.Entities.Models;
using DailyStandup.Infrastructure.Interfaces.IRepository;
using DailyStandup.Web.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataResult> Create<T>(T model) where T : class
        {
            using (var _transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().Add(model);
                    await _context.SaveChangesAsync();
                    _transaction.Commit();

                    return new DataResult
                    {
                        Status = Status.Success,
                        Message = "Saved Successfully",
                        ReturnId = model.GetType().GetProperty("Id").ToString()
                    };
                }
                catch(DbException ex)
                {
                    _transaction.Rollback();

                    return new DataResult
                    {
                        Status = Status.Failed,
                        Message = $"Save failed, {ex.Message}"
                    };
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();

                    return new DataResult
                    {
                        Status = Status.Exception,
                        Message = $"Save failed, {ex.Message}"
                    };
                }
            }
        }

        public async Task<DataResult> Delete<T>(T model) where T : class
        {
            using (var _transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().Remove(model);
                    await _context.SaveChangesAsync();
                    _transaction.Commit();

                    return new DataResult
                    {
                        Status = Status.Success,
                        Message = "Deleted Successfully",
                        ReturnId = model.GetType().GetProperty("Id").ToString()
                    };
                }
                catch (DbException ex)
                {
                    _transaction.Rollback();

                    return new DataResult
                    {
                        Status = Status.Failed,
                        Message = $"Delete failed, {ex.Message}"
                    };
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();

                    return new DataResult
                    {
                        Status = Status.Exception,
                        Message = $"Delete failed, {ex.Message}"
                    };
                }
            }
        }

        public async Task<DataResult> Update<T>(T model) where T : class
        {
            using (var _transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().Update(model);
                    await _context.SaveChangesAsync();
                    _transaction.Commit();

                    return new DataResult
                    {
                        Status = Status.Success,
                        Message = "Updated Successfully",
                        ReturnId = model.GetType().GetProperty("Id").ToString()
                    };
                }
                catch (DbException ex)
                {
                    _transaction.Rollback();

                    return new DataResult
                    {
                        Status = Status.Failed,
                        Message = $"Update failed, {ex.Message}"
                    };
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();

                    return new DataResult
                    {
                        Status = Status.Exception,
                        Message = $"Update failed, {ex.Message}"
                    };
                }
            }
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetById<T, TKey>(TKey key) where T : class
        {
            return await _context.Set<T>().FindAsync(key);
        }

    }
}
