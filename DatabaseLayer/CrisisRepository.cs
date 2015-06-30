namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
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
            const string crisisQuery =
                "SELECT C.Id, C.Heading, C.Location, C.WhenHappend, C.Description " +
                "FROM Crisis C " +
                "WHERE C.Id=@Id";
            var crisis = _connection.Query<Crisis>(crisisQuery, new {@Id = id}).AsList().FirstOrDefault();
            if (crisis == null) return null;
            crisis.AffectedPeople = new List<string>();
            const string crisisEmployeesQuery =
                "SELECT EmployeeAffected " +
                "FROM CrisisEmployees " +
                "WHERE Id=@Id";
            var crisisEmp = _connection.Query<string>(crisisEmployeesQuery, new { @Id = id });
            foreach (var ce in crisisEmp)
            {
                crisis.AffectedPeople.Add(ce);
            }
            return crisis;
        }
    }
}
