using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Interface.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> PostRecordAsync<TEntity>(string command, CommandType commandType) where TEntity : class;
        Task<TEntity> PostRecordAsync<TEntity>(string command, object param, CommandType commandType) where TEntity : class;
        Task<IEnumerable<TEntity>> PostRecordsAsync<TEntity>(string command, CommandType commandType) where TEntity : class;
        Task<IEnumerable<TEntity>> PostRecordsAsync<TEntity>(string command, object param, CommandType commandType) where TEntity : class;
        Task<int> ExecRecordAsync(string command, object param, CommandType commandType);
        Task<int> ExecRecordScopeAsync(string command, object param, string scope, CommandType commandType);
        Task<TEntity> ExecRecordScopeAsync<TEntity>(string command, object param, string scope, CommandType commandType);
        Task<int> ExecScalarAsync(string command, object param, CommandType commandType);
    }
}
