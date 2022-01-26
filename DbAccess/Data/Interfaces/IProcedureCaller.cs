using DbAccess.Data.Models;

namespace DbAccess.Data
{
    public interface IProcedureCaller
    {
        void Execute(StoredProcedureModel sp);
        void ExecuteMultiple(IEnumerable<StoredProcedureModel> sps);
        T? GetValue<T>(StoredProcedureModel sp);
        T? GetRow<T>(StoredProcedureModel sp);
        IEnumerable<T> GetRows<T>(StoredProcedureModel sp);
    }
}
