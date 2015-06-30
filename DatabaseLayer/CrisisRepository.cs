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
                "INSERT INTO Crisis(Id, Heading, Location, WhenHappend, Description) " +
                "VALUES (@Id, @Heading, @Location, @WhenHappend, @Description)";
            _connection.Execute(crisisQuery, new { data.Id, data.Heading, data.Location, data.WhenHappend, data.Description });

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
