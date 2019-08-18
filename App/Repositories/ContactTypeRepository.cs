using System.Data;
using CallingApp.Data.Entities;
using Translator.Core.Factories;
using Translator.MySql.Repositories;

namespace CallingApp.Data.Repositories
{
    public class ContactTypeRepository : Repository<ContactType>
    {
        public ContactTypeRepository(IDbConnection connection, IQueryFactory queryFactory) : base(connection, queryFactory)
        {
        }
    }
}
