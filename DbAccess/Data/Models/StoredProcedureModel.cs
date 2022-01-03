namespace DbAccess.Data.Models
{
    public class StoredProcedureModel
    {
        public string Name { get; }
        public dynamic? Parameters { get; set; } = null;
        public StoredProcedureModel(string name, dynamic? param = null)
        {
            Name = name;
            Parameters = param;
        }
        public StoredProcedureModel(Type type, string methodName, dynamic? param = null)
        {
            Name = $"SP_{type.Name}_{methodName}";
            Parameters = param;
        }
    }
}
