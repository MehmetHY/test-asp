using Dapper;

namespace TodoData.Data.Interfaces
{
    public interface IProcedureCaller
    {
        void Execute(string procedureName, DynamicParameters? parameters = null);
        T GetValue<T>(string procedureName, DynamicParameters? parameters = null);
        T GetRow<T>(string procedureName, DynamicParameters? parameters = null);
        IEnumerable<T> GetRows<T>(string procedureName, DynamicParameters? parameters = null);
    }
}
