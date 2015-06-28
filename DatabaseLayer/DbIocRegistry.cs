namespace DatabaseLayer
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using StructureMap.Configuration.DSL;

    public class DbIocRegistry : Registry
    {
        public DbIocRegistry()
        {
            var dBConnString = ConfigurationManager.ConnectionStrings["CrisisManagementContext"].ConnectionString;
            For<IDbConnection>().Use(x => new SqlConnection(dBConnString));
        }
    }
}
