using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Data.Interfaces
{
    public interface IDbContext
    {
        string ConnectionString { get; }
        Task Execute<T>(string sql, T parameters);
        Task<IEnumerable<T>> Query<T, U>(string comsqlmand, U parameters);
    }
}
