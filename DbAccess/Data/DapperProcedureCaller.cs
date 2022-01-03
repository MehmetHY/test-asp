using Dapper;
using DbAccess.Factory;
using DbAccess.Data.Models;
using System.Data;

namespace DbAccess.Data
{
    public class DapperProcedureCaller : ProcedureCaller
    {
        public DapperProcedureCaller(ConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public override void Execute(StoredProcedureModel sp)
        {
            using var con = _connectionFactory.CreateConnection();
            con.Open();
            DynamicParameters param = new DynamicParameters(sp.Parameters);
            con.Execute(sp.Name, param, commandType: CommandType.StoredProcedure);
        }

        public override void ExecuteMultiple(IEnumerable<StoredProcedureModel> sps)
        {
            using var con = _connectionFactory.CreateConnection();
            con.Open();
            foreach (var sp in sps)
            {
                DynamicParameters param = new DynamicParameters(sp.Parameters);
                con.Execute(sp.Name, param, commandType: CommandType.StoredProcedure);
            }
        }
        public override T GetValue<T>(StoredProcedureModel sp)
        {
            using var con = _connectionFactory.CreateConnection();
            con.Open();
            DynamicParameters param = new DynamicParameters(sp.Parameters);
            var value = con.ExecuteScalar(sp.Name, param, commandType: CommandType.StoredProcedure);
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public override T GetRow<T>(StoredProcedureModel sp)
        {
            using var con = _connectionFactory.CreateConnection();
            con.Open();
            DynamicParameters param = new DynamicParameters(sp.Parameters);
            var row = con.Query<T?>(sp.Name, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return (T)Convert.ChangeType(row, typeof(T))!;
        }

        public override IEnumerable<T> GetRows<T>(StoredProcedureModel sp)
        {
            using var con = _connectionFactory.CreateConnection();
            con.Open();
            DynamicParameters param = new DynamicParameters(sp.Parameters);
            var query = con.Query<T>(sp.Name, param, commandType: CommandType.StoredProcedure);
            return query;
        }

    }
}
