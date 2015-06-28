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
            const string crisisQuery =
                "INSERT INTO Crisis(Id, [Where], WhenHappend) " +
                "VALUES (@Id, @Where, @WhenHappened)";
            _connection.Execute(crisisQuery, new { data.Id, data.Where, WhenHappened = DateTime.Now });

            const string crisisEmployeesQuery =
                "INSERT INTO CrisisEmployees(Id, EmployeeAffected) " +
                "VALUES (@Id, @EmployeeAffected)";
            
            foreach (var person in data.AffectedPeople)
            {
                _connection.Execute(crisisEmployeesQuery, new { data.Id, EmployeeAffected=person });
            }
        }

        public Crisis Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
