namespace DbAccess.Data.Models
{
    public class StoredProcedureModel
    {
        public string Name { get; }
        public IDictionary<string, object?>? Parameters { get; set; } = null;
        public StoredProcedureModel(string name, IDictionary<string, object?>? param = null)
        {
            Name = name;
            Parameters = param;
        }
        public StoredProcedureModel(Type type, string methodName, IDictionary<string, object?>? param = null)
        {
            Name = $"SP_{type.Name}_{methodName}";
            Parameters = param;
        }
    }
}
