using Dapper;
using System.Data;
using Translator.Core.Constants;
using Translator.Core.Factories;
using Translator.Core.Models;
using Translator.Core.Repositories;

namespace Translator.MySql.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected internal ITableMap TableMap { get; }
        protected internal IDbConnection Connection { get; }
        protected internal IQueryFactory QueryFactory { get; }

        public Repository(IDbConnection connection, IQueryFactory queryFactory)
        {
            Connection = connection;
            QueryFactory = queryFactory;
            TableMap = TableMap<T>.Instance;
        }

        private void ExecuteScalar(QueryTemplateOption option, T entity)
        {
            using (IDbConnection db = Connection)
            {
                var sql = QueryFactory.Build(option, TableMap);
                db.ExecuteScalarAsync(sql, entity);
            }
        }

        private void ExecuteScalar(QueryTemplateOption option)
        {
            using (IDbConnection db = Connection)
            {
                var sql = QueryFactory.Build(option, TableMap);
                db.ExecuteScalarAsync(sql);
            }
        }

        public void Delete(T entity) => ExecuteScalar(QueryTemplateOption.Delete, entity);
        public void Insert(T entity) => ExecuteScalar(QueryTemplateOption.Insert, entity);
        public void InsertIgnore(T entity) => ExecuteScalar(QueryTemplateOption.InsertIgnore, entity);
        public void Replace(T entity) => ExecuteScalar(QueryTemplateOption.Replace, entity);
        public void Update(T entity) => ExecuteScalar(QueryTemplateOption.Update, entity);
        public void Init() => ExecuteScalar(QueryTemplateOption.TableInit);
    }
}
