using DbAccess.Data.Models;
using DbAccess.Factory;

namespace DbAccess.Data
{
    public abstract class ProcedureCaller : IProcedureCaller
    {
        protected readonly ConnectionFactory _connectionFactory;

        public ProcedureCaller(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public abstract void Execute(StoredProcedureModel sp);
        public abstract void ExecuteMultiple(IEnumerable<StoredProcedureModel> sps);

        public abstract T GetValue<T>(StoredProcedureModel sp);

        public abstract T GetRow<T>(StoredProcedureModel sp);

        public abstract IEnumerable<T> GetRows<T>(StoredProcedureModel sp);

    }
}
