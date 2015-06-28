namespace DatabaseLayer
{
    using System;
    using System.Data;
    using Contracts;
    using Dapper;

    public class CrisisRepository : IRepository<Crisis>
    {
        private readonly IDbConnection _connection;

        public CrisisRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public void Add(Crisis data)
        {
            data.WhenHappend = DateTime.Now;
            const string query =
                "INSERT INTO Crisis(ProductCategoryID, [Name]) " +
                "VALUES (@Id, @Where, @WhenHappend, @AffectedPeople)";
            _connection.Execute(query, data);
        }

        public Crisis Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
