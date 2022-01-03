using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DbAccess.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableColumn : Attribute
    {
        public DbType DataType { get; }
        public TableColumn(DbType type)
        {
            DataType = type;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Unique : ValidationAttribute
    {
    }
}
