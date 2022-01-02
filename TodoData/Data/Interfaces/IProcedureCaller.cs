using TodoData.Data.Models;

namespace TodoData.Data.Interfaces
{
    public interface IProcedureCaller
    {
        void Execute(StoredProcedureModel sp);
        T? GetValue<T>(StoredProcedureModel sp);
        T? GetRow<T>(StoredProcedureModel sp);
        IEnumerable<T> GetRows<T>(StoredProcedureModel sp);
    }
}
