using Dapper;
namespace TodoData.Data.Models
{
    public class StoredProcedureModel
    {
        public string Name { get; }
        public DynamicParameters? Parameters { get; set; } = null;
        public StoredProcedureModel(string name, DynamicParameters? param = null)
        {
            Name = name;
            Parameters = param;
        }
        public StoredProcedureModel(Type type, string methodName, DynamicParameters? param = null)
        {
            Name = $"SP_{type.Name}_{methodName}";
            Parameters = param;
        }
    }
}
