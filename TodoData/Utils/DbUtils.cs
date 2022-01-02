using Dapper;
using System.Data;
using TodoData.Data.Models;

namespace TodoData.Utils
{
    public static class DbUtils
    {
        public static void Exec(this IDbConnection con, StoredProcedureModel sp)
        {
            con.Execute(sp.Name, sp.Parameters, commandType: CommandType.StoredProcedure);
        }
        public static T? QueryValue<T>(this IDbConnection con, StoredProcedureModel sp)
        {
            var value = con.ExecuteScalar(sp.Name, sp.Parameters, commandType: CommandType.StoredProcedure);
            return (T?)Convert.ChangeType(value, typeof(T?));
        }
        public static T? QueryRow<T>(this IDbConnection con, StoredProcedureModel sp)
        {
            var row = con.Query<T>(sp.Name, sp.Parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return (T?)Convert.ChangeType(row, typeof(T?));
        }
        public static IEnumerable<T> QueryRows<T>(this IDbConnection con, StoredProcedureModel sp)
        {
            var query = con.Query<T>(sp.Name, sp.Parameters, commandType: CommandType.StoredProcedure);
            return query;
        }

    }
}
