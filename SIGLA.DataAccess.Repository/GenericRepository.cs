using Dapper;
using Dapper.Contrib.Extensions;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SIGLA.DataAccess.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly string _statement;

        public GenericRepository(string statement)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return type.Name; };
            this._statement = statement;
        }

        public async Task<int> ExecRecordAsync(string command, object param, CommandType commandType)
        {
            using (var connection = new SqlConnection(_statement))
            {
                return await connection.ExecuteAsync(command, param: param, commandType: commandType);
            }
        }

        public async Task<int> ExecRecordScopeAsync(string command, object param, string scope, CommandType commandType)
        {
            using (var connection = new SqlConnection(_statement))
            {
                var parameters = new DynamicParameters();
                parameters.AddDynamicParams(param);

                await connection.ExecuteAsync(command, param: parameters, commandType: commandType);

                return parameters.Get<int>(scope);
            }
        }

        public async Task<TEntity> ExecRecordScopeAsync<TEntity>(string command, object param, string scope, CommandType commandType)
        {
            using (var connection = new SqlConnection(_statement))
            {
                var parameters = new DynamicParameters();
                parameters.AddDynamicParams(param);

                await connection.ExecuteAsync(command, param: parameters, commandType: commandType);

                return parameters.Get<TEntity>(scope);
            }
        }

        public async Task<int> ExecScalarAsync(string command, object param, CommandType commandType)
        {
            using (var connection = new SqlConnection(_statement))
            {
                return await connection.ExecuteScalarAsync<int>(command, param: param, commandType: commandType);
            }
        }

        public async Task<TEntity> PostRecordAsync<TEntity>(string command, object param, CommandType commandType) where TEntity : class
        {
            using (var connection = new SqlConnection(this._statement))
            {
                return await connection.QueryFirstOrDefaultAsync<TEntity>(command, param: param, commandType: commandType);
            }
        }

        public async Task<TEntity> PostRecordAsync<TEntity>(string command, CommandType commandType) where TEntity : class
        {
            using (var connection = new SqlConnection(this._statement))
            {
                return await connection.QueryFirstOrDefaultAsync<TEntity>(command, commandType: commandType);
            }
        }

        public async Task<IEnumerable<TEntity>> PostRecordsAsync<TEntity>(string command, object param, CommandType commandType) where TEntity : class
        {
            using (var connection = new SqlConnection(this._statement))
            {
                return (IEnumerable<TEntity>)await connection.QueryAsync<TEntity>(command, param: param, commandType: commandType);
            }
        }

        public async Task<IEnumerable<TEntity>> PostRecordsAsync<TEntity>(string command, CommandType commandType) where TEntity : class
        {
            using (var connection = new SqlConnection(this._statement))
            {
                return (IEnumerable<TEntity>)await connection.QueryAsync<TEntity>(command, commandType: commandType);
            }
        }
    }
}
