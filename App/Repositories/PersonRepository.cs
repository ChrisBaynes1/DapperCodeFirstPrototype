using CallingApp.Data.Entities;
using Dapper;
using System.Data;
using Translator.Core.Constants;
using Translator.Core.Factories;
using Translator.MySql.Repositories;

namespace CallingApp.Data.Repositories
{
    public class PersonRepository : Repository<Person> 
    {
        public PersonRepository(IDbConnection connection, IQueryFactory queryFactory) : base(connection, queryFactory)
        {
        }

        public Person FindSingle(long Id)
        {
            using (IDbConnection db = Connection)
            {
                string sql = QueryFactory.Build(QueryTemplateOption.FindSingle, TableMap);
                Person result = db.QueryFirstOrDefault<Person>(sql, new Person() { Id = Id });
                return result;
            }
        }

    }
}
